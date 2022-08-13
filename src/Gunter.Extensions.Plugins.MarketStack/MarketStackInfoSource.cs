using Gunter.Core.Components;
using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Cache;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Models;
using Gunter.Extensions.Plugins.MarketStack.Models;
using System.Text;

namespace Gunter.Extensions.Plugins.MarketStack
{
    public class MarketStackInfoSource : InfoSourceBase<MarketStackInfoSourceItem>, IGunterInfoSource
    {

        private MarketStackInfoSourceItem lastItem { get; set; } = new();

        private readonly IGunterInfoItem _container;
        private readonly TimeSpan MinInterval = new TimeSpan();

        private Dictionary<string, MarketStackInfoSourceItem> data = new();

        public MarketStackInfoSourceItem LastItem { get => lastItem; }

        public bool IsOnline => true;

        public IGunterInfoItem Container { get => _container; }

        private const string APIKEY = "{ YOUR APIKEY HERE }";
        private const string SELECTED_EXCHANGE = "Selected Exchange (Mic)";

        public string Category { get => InfoSourceConstants.CAT_INFORMATION; }
        public string SubCategory { get => InfoSourceConstants.SUB_WEATHER; }


        public MarketStackInfoSource() : base()
        {
            Name = "MarketStack InfoSource";
            SpecialProperties = new SpecialProperties();
            SpecialProperties.AddOrUpdate(SELECTED_EXCHANGE, string.Empty);
            _mandatoryInputs.AddOrUpdate("APIKEY", APIKEY);
            lastItem = new();
        }

        public MarketStackInfoSource(string id)
        {
            Id = id;
        }

        public MarketStackInfoSource(IGunterInfoItem container, string id, string name)
        {
            Id = id;
            Name = name;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("APIKEY", APIKEY);
            lastItem = new();
            _container = container;
        }
        public object GetLastItem()
        {

            if (lastItem is null ||
                (lastItem.Currencies.Currencies.Count == 0 &&
                lastItem.Exchanges.Exchanges.Count == 0))
                GetLastData();

            return lastItem;
        }

        public override Dictionary<string, MarketStackInfoSourceItem> GetLastData()
        {
            SpecialProperties.TryGetProperty("APIKEY", out string? apiKey);
            SpecialProperties.TryGetProperty(SELECTED_EXCHANGE, out string? mic);

            var currencies = TryGetFromMarketStack<MarketStackCurrenciesResponse>(
                apiKey,
                MarketStackAPI.Endpoint_Currencies,
                DateTimeManipulationHelper.OneMonth);
            if (currencies is not null)
            {
                lastItem.Currencies = currencies;
            }

            var exchanges = TryGetFromMarketStack<MarketStackExchangeResponse>(
                apiKey,
                MarketStackAPI.Endpoint_Exchanges,
                DateTimeManipulationHelper.OneMonth);
            if (exchanges is not null)
            {
                lastItem.Exchanges = exchanges;
            }

            foreach (var item in exchanges.Exchanges.Where(x => x.Mic == mic))
            {
                var marketIndices = TryGetFromMarketStack<MarketStackMarketIndicesResponse>(
                    apiKey,
                    MarketStackAPI.Endpoint_MarketIndices,
                    DateTimeManipulationHelper.OneDayTimeSpan,
                    $"Exchange_{item.Mic}",
                    new Dictionary<string, string> { { "symbols", item.Mic } });

                lastItem.MarketIndices.Add(marketIndices);
            }

            if (data.ContainsKey(apiKey))
                data[apiKey] = lastItem;
            else
                data.Add(apiKey, LastItem);

            return data;
        }

        private T? TryGetFromMarketStack<T>(
            string apiKey,
            string endpoint,
            TimeSpan expirationIfCached,
            string? cachedFilePrefix = "MARKETSTACK",
            Dictionary<string, string> parameters = null)
        {
            var fileUrl = ExternalDataCache.GenerateCacheFileID(cachedFilePrefix, apiKey, endpoint);
            T? marketData;
            if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
            {
                var json = Encoding.UTF8.GetString(content);
                marketData = System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
            else
            {
                marketData = MarketStackAPI.GetFromEndPoint<T>(apiKey, endpoint, parameters);
                var json = System.Text.Json.JsonSerializer.Serialize(marketData, typeof(T));
                ExternalDataCache.Instance.TryAddFile(json, fileUrl, expirationIfCached);
            }

            return marketData;
        }

        public void Update()
        {
            GetLastData();
        }
    }
}
