using Newtonsoft.Json;

namespace Gunter.Extensions.Plugins.MarketStack.Models
{
    public class MarketStackCurrenciesResponse
    {
        public Pagination Pagination { get; set; } = new();

        [JsonProperty("data")]
        public List<MarketStackCurrency> Currencies { get; set; } = new();
    }

    public class MarketStackCurrency
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Symbol_native { get; set; } = string.Empty;
    }

    public class Pagination
    {
        public int Limit { get; set; }
        public int Offset { get; set; }
        public int Count { get; set; }
        public int Total { get; set; }
    }
}
