using Gunter.Core.Cache;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Infrastructure.Log;
using Newtonsoft.Json;
using System.Text;

namespace Gunter.Core.Infrastructure.Cache
{
    public class ExternalDataCache
    {
        public const string VolumeName = "MAINCACHE";

        public ExternalDataCacheOptions Options { get; set; } = new();

        public CacheFolder RootFolder { get; set; } = new CacheFolder { Id = Guid.NewGuid().ToString(), Name = $"root" };

        private static readonly Lazy<ExternalDataCache> lazy = new Lazy<ExternalDataCache>(() => FromFileSystem(VolumeName));

        public static ExternalDataCache Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private ExternalDataCache()
        {
        }

        #region From / To FileSystem

        private static string _initialDirectory = Path.Combine(Directory.GetCurrentDirectory(), "IO");
        public static string InitialDirectory { get => _initialDirectory; }

        public void ToFileSystem()
        {
            var file = Path.Combine(_initialDirectory, VolumeName);
            if (File.Exists(file))
                File.Delete(file);

            var json = JsonConvert.SerializeObject(this, Formatting.Indented);

            if (!Directory.Exists(_initialDirectory))
                Directory.CreateDirectory(_initialDirectory);

            File.WriteAllText(file, json);
        }

        private static ExternalDataCache? FromFileSystem(string volumeName)
        {
            var file = Path.Combine(InitialDirectory, volumeName);
            ExternalDataCache retVal;
            if (!File.Exists(file))
            {
                retVal = new ExternalDataCache();
                retVal.ToFileSystem();
            }
            else
            {
                var json = File.ReadAllText(file);
                try
                {
                    retVal = JsonConvert.DeserializeObject<ExternalDataCache>(json);
                }
                catch (Exception ex)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine($"Error loading FileSystem image {file}: \n{ex.Message}");
                    var newFile = $"{file}_corrupted_{DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss")}";
                    File.WriteAllText(newFile, json);
                    sb.AppendLine($"Created corrupted project file {newFile}");
                    File.Delete(file);
                    GunterLog.Instance.Log("ExternalDataCache", $"Created corrupted project file {newFile}");
                    retVal = new ExternalDataCache();
                }
            }

            return retVal;
        }

        #endregion

        #region Folders

        public CacheFolder? GetFolderByKey(string key = "", CacheFolder? folder = null)
        {
            folder ??= RootFolder;
            var retVal = folder.Folders.ContainsKey(key) ? folder.Folders[key] : null;
            while (retVal is null)
            {
                foreach (var subFolder in folder.Folders.Values)
                    retVal ??= GetFolderByKey(key, subFolder);
            }

            return retVal;
        }

        public CacheFolder? GetFolderByName(string name = "", CacheFolder? folder = null)
        {
            folder ??= RootFolder;
            var retVal = folder.Folders.FirstOrDefault(x => x.Value.Name == name).Value;
            while (retVal is null)
            {
                foreach (var subFolder in folder.Folders.Values)
                    retVal ??= GetFolderByKey(name, subFolder);
            }

            return retVal;
        }

        public void TryCreateFolder(string folderName, CacheFolder parent, out CacheFolder? folder)
        {
            var retVal = string.Empty;
            folder = null;

            if (parent.Folders.Any(x => x.Value.Name == folderName))
                return;

            folder = new CacheFolder
            {
                Id = Guid.NewGuid().ToString(),
                Name = folderName,
                ParentId = parent.Id
            };

            parent.Folders.Add(folder.Id, folder);

            if (Options.AutoSave)
                ToFileSystem();

            return;
        }

        #endregion

        public bool TryUploadFile(string localFile, string remoteFile, CacheFolder folder)
        {
            var retVal = File.Exists(localFile);

            if (retVal)
            {
                var fileId = new CacheFileId();
                if (folder.Parent is not null)
                {
                    var destination = folder.Parent;
                    do
                    {
                        fileId.PathSegments.Insert(0, $"{folder.Name}\\");
                        destination = folder.Parent;
                    } while (destination is not null);
                }

                fileId.PathSegments.Add(Path.GetFileName(remoteFile));

                var bytes = File.ReadAllBytes(localFile);
                TryAddFile(bytes, fileId, TimeSpan.Zero);

            }

            return retVal;
        }

        public void TryAddFile(string content, CacheFileId cacheFileId, TimeSpan expiration)
        {
            var bytes = Encoding.UTF8.GetBytes(content);
            TryAddFile(bytes, cacheFileId, expiration);
        }

        public void TryAddFile(byte[] bytes, CacheFileId cacheFileId, TimeSpan expiration)
        {
            ExternalDataCacheItem newVersion = new ExternalDataCacheItem(bytes, DateTime.Now.Add(expiration));
            newVersion.Name = cacheFileId.PathSegments.Last(); // TODO, versioning 

            var key = cacheFileId.ToString();
            CacheFolder? folder = GetFolderFromCacheId(RootFolder.Folders, cacheFileId.PathSegments);
            if (folder is not null && folder.Files.Any(x => x.Name == cacheFileId.PathSegments.Last()))
            {
                var file = folder.Files.SingleOrDefault(x => x.Name == cacheFileId.PathSegments.Last());
                if (Options.UseVersions)
                {
                    // TODO VERSIONING
                    //var lastVersion = Files[key];
                    //newVersion.Versions
                }
                folder.Files.Remove(file);
                folder.Files.Add(newVersion);
            }
            else
            {
                folder = RootFolder;
                string fullPath = RootFolder.Name;
                for (int i = 0; i < cacheFileId.PathSegments.Count - 1; i++)
                {
                    var item = cacheFileId.PathSegments[i];
                    TryCreateFolder(item, folder, out var newFolder);
                    folder = newFolder;
                    fullPath = Path.Combine(fullPath, newFolder.Name);
                    newVersion.CachePath = fullPath;
                }

                folder.Files.Add(newVersion);
            }
            if (Options.AutoSave)
                ToFileSystem();
        }

        public bool TryGetFile(CacheFileId cacheFileId, out byte[] bytes)
        {
            var key = cacheFileId.ToString();
            var folder = GetFolderFromCacheId(RootFolder.Folders, cacheFileId.PathSegments);
            if (folder is null || folder.Files.Count == 0)
            {
                bytes = Array.Empty<byte>();
                return false;
            }

            if (folder.Files.Any(x => x.Name == cacheFileId.PathSegments.Last()))
            {
                var cachedItem = folder.Files.Where(x => x.Name == cacheFileId.PathSegments.Last()).SingleOrDefault();
                if (cachedItem.Expiration < DateTime.Now)
                {
                    folder.Files.Remove(cachedItem);
                    cachedItem.Destroy();
                }

                bytes = File.ReadAllBytes(cachedItem.LocalPath);
                return true;
            }
            else
            {
                bytes = Array.Empty<byte>();
                return false;
            }
        }

        public CacheFolder GetFolder(CacheFolder parent, string hash)
        {
            if (parent.Folders.ContainsKey(hash))
                return parent;

            var retVal = default(CacheFolder);
            foreach (var item in parent.Folders)
            {
                retVal = GetFolder(item.Value, hash);
                if (retVal is not null)
                    break;
            }

            return retVal;
        }

        public CacheFolder? GetFolderFromCacheId(Dictionary<string, CacheFolder> folders, IEnumerable<string> values, int deepCounter = 0)
        {
            var name = values.ElementAt(values.Count() - 1);
            CacheFolder? retVal = null;
            foreach (var item in folders.Values)
            {
                if (item.Name == name)
                    return item;

                if (item.Files.Any(x => x.Name == name))
                    return item;

                retVal = GetFolderFromCacheId(item.Folders, values.Skip(deepCounter), deepCounter++);
                if (retVal is not null)
                    break;
            }

            return retVal ?? default(CacheFolder);
        }

        public bool TryDeleteFile(string folderId, string fileName)
        {
            var folder = GetFolderByKey(folderId.ToUpper());
            var file = folder?.Files.Where(x => x.Name == fileName).SingleOrDefault();
            var retVal = (file is not null);

            if (retVal)
                retVal = (file.ParentFolderId == folderId);

            if (retVal)
            {
                folder.Files.Remove(file);
                if (Options.AutoSave)
                    ToFileSystem();
            }

            return retVal;
        }

        public bool TryDeleteFolder(string folderName)
        {
            var folder = GetFolderByName(folderName);
            if (folder is null)
                return false;

            return folder.Parent.Folders.Remove(folder.Id);
        }

        public bool TryDeleteCollection(string collectionName)
        {
            //var retVal = Files.Remove(collectionName, out var cacheItem);
            //if (retVal)
            //{
            //    try
            //    {
            //        File.Delete(cacheItem.LocalPath);
            //    }
            //    catch { }
            //    finally { retVal = true; }

            //    if(Options.AutoSave)
            //        ToFileSystem();
            //}

            //return retVal;
            return true;
        }

        public static CacheFileId GenerateCacheFileID(params string[] parameters)
        {
            var itemString = GenerateCacheFileIdString(parameters);
            var hash = MD5Helper.GetHash(itemString);

            var retVal = CacheFileId.FromString(itemString);
            retVal.NameHash = hash;

            return retVal;
        }

        public static string GenerateCacheFileIdString(params string[] values)
            => $"{string.Join('_', values)}"; // Gunter Cache Item

    }
}
