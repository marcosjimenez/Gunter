using Newtonsoft.Json;

namespace Gunter.Extensions.Plugins.MarketStack.Models
{
    public class MarketStackMarketIndicesResponse
    {
        public Pagination Pagination { get; set; } = new();

        [JsonProperty("data")]
        public List<MarketStackMarketIndices> MarketIndices { get; set; } = new();

    }

    public class MarketStackMarketIndices
    {
        public string Date { get; set; }
        public string Symbol { get; set; }
        public string Exchange { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public double Volume { get; set; }
        public object Adj_high { get; set; }
        public object Adj_low { get; set; }
        public object Adj_close { get; set; }
        public object adj_open { get; set; }
        public object adj_volume { get; set; }
    }

}
