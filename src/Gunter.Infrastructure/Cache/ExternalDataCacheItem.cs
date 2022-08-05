using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Gunter.Core.Infrastructure.Helpers;

namespace Gunter.Infrastructure.Cache
{
    public class ExternalDataCacheItem
    {
        public string Id { get; set; }
        public string FileWithPath { get; set; }
        public DateTimeOffset Expiration { get; set; }

        public ExternalDataCacheItem()
        {
            Id = String.Empty;
            FileWithPath = String.Empty;
            Expiration = DateTimeOffset.Now.Add(DateTimeManipulationHelper.DEFAULT_EXPIRATION);
        }

        public ExternalDataCacheItem(string id, byte[] value, DateTime expiration)
        {
            Id = id;
            FileWithPath = Path.Combine(Path.GetTempPath(), id);
            Expiration = expiration;
            File.WriteAllBytes(FileWithPath, value);
        }

        public ExternalDataCacheItem(byte[] value, DateTime expiration)
        {
            Id = Guid.NewGuid().ToString();
            FileWithPath = Path.Combine(Path.GetTempPath(), Id);
            Expiration = expiration;
            File.WriteAllBytes(FileWithPath, value);
        }

        public void Destroy()
        {
            var file = Path.Combine(Path.GetTempPath(), Id);
            if (File.Exists(file))
                File.Delete(file);
        }

        public static bool TryGetFromFile(string id, out byte[] contents)
        {
            var retVal = false;
            var file = Path.Combine(Path.GetTempPath(), id);
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
