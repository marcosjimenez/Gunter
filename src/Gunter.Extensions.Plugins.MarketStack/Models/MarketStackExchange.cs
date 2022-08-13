using Newtonsoft.Json;

namespace Gunter.Extensions.Plugins.MarketStack.Models
{

    public class MarketStackExchangeResponse
    {
        public MarketStackInfoSourcePagination Pagination { get; set; } = new();

        [JsonProperty("data")]
        public List<MarketStackExchange> Exchanges { get; set; } = new();
    }

    public class MarketStackExchange
    {
        public string Name { get; set; } = string.Empty;
        public string Acronym { get; set; } = string.Empty;
        public string Mic { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Country_Code { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public MarketStackInfoSourceTimezone Timezone { get; set; } = new();
    }

}
