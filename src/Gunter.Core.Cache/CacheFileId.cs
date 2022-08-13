using System.Text;

namespace Gunter.Core.Infrastructure.Cache
{
    public class CacheFileId
    {
        public string NameHash { get; set; } = string.Empty;

        public List<string> PathSegments { get; set; } = new();

        public DateTimeOffset TimeStamp { get; set; } = DateTimeOffset.Now;
        public List<CacheFileId> FileVersions {get;set;}  = new();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"{NameHash}"); 
            foreach(var item in PathSegments)
                sb.Append($"_{item}");
            return sb.ToString();
        }

        public static CacheFileId FromString(string value)
        {
            var settings = value.Split('_');
            var nameHash = settings.First() ?? value;
            var values = settings.Skip(1).ToList();

            return new CacheFileId
            {
                NameHash = nameHash,
                PathSegments = values
            };
        }
    }
}
