using Newtonsoft.Json;

namespace Gunter.Extensions.Plugins.MarketStack.Models
{
    public class MarketStackInfoSourceItem
    {
        [JsonProperty("Exchanges")]
        public MarketStackExchangeResponse Exchanges { get; set; } = new();

        [JsonProperty("Currencies")]
        public MarketStackCurrenciesResponse Currencies { get; set; } = new();
    }
}
