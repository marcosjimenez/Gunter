namespace Gunter.Core.Infrastructure.Cache
{
    public class CacheFileId
    {
        public string NameHash { get; set; } = string.Empty;
        public string Principal { get; set; } = string.Empty;
        public string Middle { get; set; } = string.Empty;
        public string Secondary { get; set; } = string.Empty;

        public override string ToString() => NameHash;

    }
}
