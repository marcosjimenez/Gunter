using System.Text;
using System.Text.Json;
using System.Security.Cryptography;
using Newtonsoft.Json;
using Gunter.Core.Infrastructure.Log;

namespace Gunter.Core.Infrastructure.Cache
{
    public class ExternalDataCache
    {
        private const string TempName = "mediaerrorlog.dbl";

        private readonly Dictionary<CacheFileId, ExternalDataCacheItem> _files;

        private static readonly Lazy<ExternalDataCache> lazy = new Lazy<ExternalDataCache>(() => new ExternalDataCache().FromFileSystem());

        public static ExternalDataCache Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private ExternalDataCache()
        {
            _files = new Dictionary<CacheFileId, ExternalDataCacheItem>();
        }

        public void ToFileSystem()
        {
            var file = Path.Combine(Path.GetTempPath(), TempName);
            if (File.Exists(file))
                File.Delete(file);

            var json = JsonConvert.SerializeObject(_files, Formatting.Indented);

            File.WriteAllText(file, json);
        }

        private ExternalDataCache FromFileSystem()
        {
            var file = Path.Combine(Path.GetTempPath(), TempName);
            if (File.Exists(file))
            {
                var json = File.ReadAllText(file);
                Dictionary<CacheFileId, ExternalDataCacheItem>? cache = null;
                try
                {
                    cache = JsonConvert.DeserializeObject<Dictionary<CacheFileId, ExternalDataCacheItem>>(json);
                }
                catch(Exception ex)
                {
                    GunterLog.Instance.Log(this, $"Error loading FileSystem image {file}: \n{ex.Message}");
                }

                if (cache is not null)
                {
                    _files.Clear();
                    foreach(var item in cache)
                        _files.Add(item.Key, item.Value);
                }
            }
            return this;
        }

        public void TryAddFile(string content, CacheFileId nameHash, TimeSpan expiration)
        {
            var bytes = Encoding.UTF8.GetBytes(content);
            TryAddFile(bytes, nameHash, expiration);
        }

        public void TryAddFile(byte[] bytes, CacheFileId nameHash, TimeSpan expiration)
        {
            ExternalDataCacheItem cachedItem = new ExternalDataCacheItem(bytes, DateTime.Now.Add(expiration));
            if (_files.ContainsKey(nameHash))
                _files[nameHash] = cachedItem;
            else
            {
                _files.Add(nameHash, cachedItem);
                ToFileSystem();
            }
        }

        public bool TryGetFile(CacheFileId nameHash, out byte[] bytes)
        {
            if (_files.TryGetValue(nameHash, out var cachedItem) &&
                DateTime.Now > cachedItem.Expiration)
            {
                _files.Remove(nameHash);
                cachedItem.Destroy();
                bytes = Array.Empty<byte>();
                return false;
            }
            bytes = cachedItem is not null ? cachedItem.GetData() : Array.Empty<byte>();
            return cachedItem is not null;
        }


        public static CacheFileId GenerateCacheFileID(CacheFileId cacheFileId)
            => GenerateCacheFileID(cacheFileId.Principal, cacheFileId.Middle, cacheFileId.Secondary);

        public static CacheFileId GenerateCacheFileID(string principal, string middle, string secondary)
        {
            using var md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(generateCacheFileIdString(principal, middle, secondary));
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return new CacheFileId
            {
                NameHash = Convert.ToHexString(hashBytes),
                Principal = principal,
                Middle = middle,
                Secondary = secondary
            };
        }

        private static string generateCacheFileIdString(string principal, string middle, string secondary)
            => $"{principal}_{middle}_{secondary}.gci"; // Gunter Cache Item

        private static JsonSerializerOptions GetJsonOptions()
        =>
            new JsonSerializerOptions { 
                IgnoreReadOnlyFields = true, 
                IgnoreReadOnlyProperties = true, 
                PropertyNameCaseInsensitive = false, 
                WriteIndented = false,
                DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
                };
    }
}
