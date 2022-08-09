using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Models;
using Gunter.Extensions.InfoSources;
using Gunter.Extensions.Plugins.MarketStack.Models;
using Gunter.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public string Category { get => InfoSourceConstants.CAT_INFORMATION; }
        public string SubCategory { get => InfoSourceConstants.SUB_WEATHER; }


        public MarketStackInfoSource() : base()
        {
            Name = "MarketStack InfoSource";
            SpecialProperties = new SpecialProperties();
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
        public object GetData()
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

            var exchanges = TryGetFromMarketStack<MarketStackExchangeResponse>(apiKey, MarketStackAPI.Endpoint_Exchanges);
            if (exchanges is not null)
            {
                lastItem.Exchanges = exchanges;
            }

            var currencies = TryGetFromMarketStack<MarketStackCurrenciesResponse>(apiKey, MarketStackAPI.Endpoint_Currencies);
            if (currencies is not null)
            {
                lastItem.Currencies = currencies;
            }


            if (data.ContainsKey(apiKey))
                data[apiKey] = lastItem;
            else
                data.Add(apiKey, LastItem);

            return data;
        }

        private T? TryGetFromMarketStack<T>(string apiKey, string endpoint)
        {
            var fileUrl = ExternalDataCache.GenerateCacheFileName("MARKETSTACK", apiKey, endpoint);
            T? marketData;
            if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
            {
                var json = Encoding.UTF8.GetString(content);
                marketData = System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
            else
            {
                marketData = MarketStackAPI.GetFromEndPoint<T>(apiKey, endpoint);
                var json = System.Text.Json.JsonSerializer.Serialize(marketData, typeof(T));
                ExternalDataCache.Instance.TryAddFile(json, fileUrl, DateTimeManipulationHelper.QuarterDayTimeSpan);
            }

            return marketData;
        }

        public void Update()
        {
            GetLastData();
            _container?.InfoSourceUpdated(this);
        }
    }
}
