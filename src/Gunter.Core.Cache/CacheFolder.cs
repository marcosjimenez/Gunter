using Gunter.Core.Infrastructure.Cache;
using Newtonsoft.Json.Linq;

namespace Gunter.Core.Cache
{
    public class CacheFolder
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ParentId { get; set; } = string.Empty;

        public Dictionary<string ,CacheFolder> Folders { get; set; } = new();
        public List<ExternalDataCacheItem> Files { get; set; } = new();

        [Newtonsoft.Json.JsonIgnore]
        public CacheFolder Parent { get; set; }

        public CacheFolder? GetFolder(string name)
        {
            var folder = Folders.FirstOrDefault(x => x.Value.Name == name).Value;
            if (folder is not null)
            {
                folder.Parent = this;
                return folder;
            }
            
            return null;
        }
    }
}
