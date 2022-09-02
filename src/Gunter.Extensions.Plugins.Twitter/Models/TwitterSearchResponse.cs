using System.Text.Json.Serialization;

namespace Gunter.Extensions.Plugins.Twitter.Models
{
    internal class TwitterSearchResponse
    {
        public IEnumerable<TwitterItem> Data { get; set; } = new List<TwitterItem>();
        public TwitterSearchMeta Meta { get; set; } = new();
    }

    internal class TwitterItem
    {
        public string Id { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }

    internal class TwitterSearchMeta
    {

        [JsonPropertyName("newest_id")]
        public string NewestId { get; set; } = string.Empty;

        [JsonPropertyName("oldest_id")]
        public string OldestId { get; set; } = string.Empty;

        [JsonPropertyName("result_count")]
        public string ResultCount { get; set; } = string.Empty;

        [JsonPropertyName("next_token")]
        public string NextToken { get; set; } = string.Empty;
    }
}
