using Newtonsoft.Json;

namespace Gunter.Extensions.Plugins.PoePublicStash.PoENinja
{
    public partial class PoENinjaAPIResponse
    {
        [JsonProperty("lines")]
        public Line[] Lines { get; set; } = Array.Empty<Line>();

        [JsonProperty("currencyDetails")]
        public CurrencyDetail[] CurrencyDetails { get; set; } = Array.Empty<CurrencyDetail>();

        [JsonProperty("language")]
        public Language Language { get; set; }
    }

    public partial class CurrencyDetail
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("icon")]
        public Uri Icon { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tradeId")]
        public string TradeId { get; set; }
    }

    public partial class Language
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("translations")]
        public Translations Translations { get; set; }
    }

    public partial class Translations
    {
    }

    public partial class Line
    {
        [JsonProperty("currencyTypeName")]
        public string CurrencyTypeName { get; set; }

        [JsonProperty("pay")]
        public Receive Pay { get; set; }

        [JsonProperty("receive")]
        public Receive Receive { get; set; }

        [JsonProperty("paySparkLine")]
        public PaySparkLine PaySparkLine { get; set; }

        [JsonProperty("receiveSparkLine")]
        public ReceiveSparkLine ReceiveSparkLine { get; set; }

        [JsonProperty("chaosEquivalent")]
        public double? ChaosEquivalent { get; set; }

        [JsonProperty("lowConfidencePaySparkLine")]
        public PaySparkLine LowConfidencePaySparkLine { get; set; }

        [JsonProperty("lowConfidenceReceiveSparkLine")]
        public ReceiveSparkLine LowConfidenceReceiveSparkLine { get; set; }

        [JsonProperty("detailsId")]
        public string DetailsId { get; set; }
    }

    public partial class PaySparkLine
    {
        [JsonProperty("data")]
        public double?[] Data { get; set; } = Array.Empty<double?>();

        [JsonProperty("totalChange")]
        public double? TotalChange { get; set; }
    }

    public partial class ReceiveSparkLine
    {
        [JsonProperty("data")]
        public double?[] Data { get; set; } = Array.Empty<double?>();

        [JsonProperty("totalChange")]
        public double? TotalChange { get; set; }
    }

    public partial class Receive
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("league_id")]
        public long LeagueId { get; set; }

        [JsonProperty("pay_currency_id")]
        public long PayCurrencyId { get; set; }

        [JsonProperty("get_currency_id")]
        public long GetCurrencyId { get; set; }

        [JsonProperty("sample_time_utc")]
        public DateTimeOffset SampleTimeUtc { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("value")]
        public double? Value { get; set; }

        [JsonProperty("data_point_count")]
        public long DataPointCount { get; set; }

        [JsonProperty("includes_secondary")]
        public bool IncludesSecondary { get; set; }

        [JsonProperty("listing_count")]
        public long ListingCount { get; set; }
    }
}
