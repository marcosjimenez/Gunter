namespace Gunter.Extensions.Plugins.MarketStack.Models
{
    public class MarketStackInfoSourceTimezone
    {
        public string Timezone { get; set; } = string.Empty;
        public string Abbr { get; set; } = string.Empty;
        public string AbbrDst { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{this.Timezone} {Abbr} {AbbrDst}";
        }

    }
}
