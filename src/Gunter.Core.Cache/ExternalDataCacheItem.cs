using Gunter.Core.Infrastructure.Helpers;

namespace Gunter.Core.Infrastructure.Cache
{
    public abstract class ExternalDataCacheItemBase
    {
        public string ParentFolderId { get; set; } = string.Empty;

    }

    public class ExternalDataCacheItem : ExternalDataCacheItemBase
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string LocalPath { get; set; } = string.Empty;
        public string CachePath { get; set; } = string.Empty;

        public DateTimeOffset Expiration { get; set; }
        public string MD5 { get; set; } = string.Empty;

        public ExternalDataCacheItem()
        {
            Id = string.Empty;
            LocalPath = string.Empty;
            Expiration = DateTimeOffset.Now.Add(DateTimeManipulationHelper.DEFAULT_EXPIRATION);
        }

        public ExternalDataCacheItem(string id, byte[] value, DateTime expiration)
        {
            Id = id;
            LocalPath = Path.Combine(ExternalDataCache.InitialDirectory, id);
            Expiration = expiration;
            File.WriteAllBytes(LocalPath, value);
        }

        public ExternalDataCacheItem(byte[] value, DateTime expiration)
        {
            Id = Guid.NewGuid().ToString();
            LocalPath = Path.Combine(ExternalDataCache.InitialDirectory, Id);
            Expiration = expiration;
            File.WriteAllBytes(LocalPath, value);
        }

        public void Destroy()
        {
            var file = Path.Combine(ExternalDataCache.InitialDirectory, Id);
            if (File.Exists(file))
                File.Delete(file);
        }

        public static bool TryGetFromFile(string id, out byte[] contents)
        {
            var retVal = false;
            var file = Path.Combine(ExternalDataCache.InitialDirectory, id);
            if (File.Exists(file))
            {
                contents = File.ReadAllBytes(file);
            }
            else
                contents = Array.Empty<byte>();

            return retVal;
        }

        public byte[] GetData()
            => File.ReadAllBytes(Path.Combine(Path.GetTempPath(), Id));
    }
}
