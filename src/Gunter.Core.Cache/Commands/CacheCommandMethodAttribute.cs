namespace Gunter.Core.Cache.Commands
{
    public class CacheCommandMethodAttribute : Attribute
    {
        public string Command { get; set; } = string.Empty;
        public string HelpText { get; set; } = string.Empty;
    }
}
