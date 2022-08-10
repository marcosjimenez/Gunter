using Gunter.Infrastructure.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Security.Cryptography;

namespace Gunter.Infrastructure.Cache
{
    public class ExternalDataCache
    {
        private const string TempName = "mediaerrorlog.dbl";

        private readonly Dictionary<string, ExternalDataCacheItem> _files;

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
            _files = new Dictionary<string, ExternalDataCacheItem>();
        }

        public void ToFileSystem()
        {
            var file = Path.Combine(Path.GetTempPath(), TempName);
            if (File.Exists(file))
                File.Delete(file);

            var json = JsonSerializer.Serialize(_files, GetJsonOptions());

            File.WriteAllText(file, json);
        }

        public ExternalDataCache FromFileSystem()
        {
            var file = Path.Combine(Path.GetTempPath(), TempName);
            if (File.Exists(file))
            {
                var json = File.ReadAllText(file);
                var cache = JsonSerializer.Deserialize<Dictionary<string, ExternalDataCacheItem>>(json, GetJsonOptions());
                if (cache is not null)
                {
                    _files.Clear();
                    foreach(var item in cache.AsParallel())
                        _files.Add(item.Key, item.Value);
                    return this;
                }
            }
            return this;
        }

        public void TryAddFile(string content, string name, TimeSpan expiration)
        {
            var bytes = Encoding.UTF8.GetBytes(content);
            TryAddFile(bytes, name, expiration);
        }

        public void TryAddFile(byte[] bytes, string name, TimeSpan expiration)
        {
            var nextExpiration = DateTime.Now.Add(expiration);
            var cachedItem = new ExternalDataCacheItem(bytes, nextExpiration);
            if (_files.ContainsKey(name))
            { 
                _files[name] = cachedItem;
            }
            else
            {
                _files.Add(name, cachedItem);
                ToFileSystem();
            }
        }

        public bool TryGetFileFromFileSystem(string name, out string content)
        {
            var retVal = TryGetFile(name, out byte[] bytes);
            if (!retVal)
            {
                if (ExternalDataCacheItem.TryGetFromFile(name, out byte[] fileContent))
                {
                    content = Encoding.UTF8.GetString(fileContent);
                }
                else
                    content = string.Empty;
            }
            else
                content = Encoding.UTF8.GetString(bytes);

            return retVal;
        }

        public bool TryGetFile(string name, out byte[] bytes)
        {
            if (_files.TryGetValue(name, out var cachedItem) &&
                DateTime.Now > cachedItem.Expiration)
            {
                _files.Remove(name);
                cachedItem.Destroy();
                bytes = Array.Empty<byte>();
                return false;
            }
            bytes = cachedItem is not null ? cachedItem.GetData() : Array.Empty<byte>();
            return cachedItem is not null;
        }

        private static string generateCacheFileName(string principal, string middle, string secondary)
            => $"{principal}_{middle}_{secondary}.dbl";

        public static string GenerateCacheFileName(string principal, string middle, string secondary)
        {
            using var md5 = MD5.Create();
            byte[] inputBytes = Encoding.UTF8.GetBytes(generateCacheFileName(principal, middle, secondary));
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            return Convert.ToHexString(hashBytes);
        }

        private static JsonSerializerOptions GetJsonOptions()
        =>
            new JsonSerializerOptions {   };
    }
}
