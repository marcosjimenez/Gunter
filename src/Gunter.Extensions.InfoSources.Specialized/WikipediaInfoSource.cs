using Gunter.Core.Contracts;
using Gunter.Extensions.Common;
using Gunter.Extensions.InfoSources.Specialized.Models;
using Gunter.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WikiDotNet;
using static Gunter.Extensions.InfoSources.Specialized.Models.OpenWeatherForecastModel;
using Gunter.Core.Infrastructure.Helpers;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class WikipediaInfoSource : InfoSourceBase<WikipediaInfoItem>, IInfoSource
    {
        public string Id { get; set; }
        public string Name { get; set; }

        private WikipediaInfoItem lastItem;
        public WikipediaInfoItem LastItem { get => lastItem; }

        private readonly IGunterInfoItem _container;
        private SpecialProperties _specialProperties;
        private Dictionary<string, WikipediaInfoItem> data = new();

        public bool IsOnline => true;

        public SpecialProperties SpecialProperties { get => _specialProperties; }
        public IGunterInfoItem Container { get => _container; }

        public string Category { get => InfoSourceConstants.CAT_COMMUNICATION; }
        public string SubCategry { get => InfoSourceConstants.SUB_ENCYCLOPAEDIA; }


        public WikipediaInfoSource()
        {
            Id = string.Empty;
            Name = string.Empty;
            _container = null;
            InitializeProperties();
        }

        public WikipediaInfoSource(IGunterInfoItem container, string id, string name)
        {
            Id = id;
            Name = name;
            _container = container;
            InitializeProperties();
        }

        public object GetData()
        {
            GetLastData();
            return lastItem;
        }

        public override Dictionary<string, WikipediaInfoItem> GetLastData()
        {
            _specialProperties.TryGetProperty("expression", out string? searchString);
            _specialProperties.TryGetProperty("resultLimit", out string? resultLimitString);
            _specialProperties.TryGetProperty("language", out string? language);

            if (string.IsNullOrWhiteSpace(resultLimitString) || !Int32.TryParse(resultLimitString, out var resultLimit))
            {
                resultLimit = 5;
            }

            if (searchString is null)
            {
                throw new Exception("expression is null");
            }

            var searchSettings = new WikiSearchSettings
            {
                RequestId = Guid.NewGuid().ToString(),
                ResultLimit = resultLimit < 1 ? 1 : resultLimit,
                ResultOffset = 1,
                Language = language ?? "es"
            };
            try
            {

                var fileUrl = ExternalDataCache.GenerateCacheFileName("OPENWEATHER", searchString, "weather");
                if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
                {
                    var json = Encoding.UTF8.GetString(content);
                    lastItem = JsonSerializer.Deserialize<WikipediaInfoItem>(json) ?? lastItem;
                }
                else
                {
                    var searcher = new WikiSearcher();
                    var response = searcher.Search(searchString, searchSettings);

                    foreach(var searchResult in response.Query.SearchResults)
                    {
                        data.Add(searchResult.Title, WikipediaInfoItem.FromSearchResult(searchResult));
                    }

                    WikiSearchResult? result = response.Query.SearchResults.OrderByDescending(x => x.PageId).FirstOrDefault();
                    if (result == null)
                        throw new ArgumentNullException(nameof(result));

                    _specialProperties.AddOrUpdate("preview", result.Preview);
                    _specialProperties.AddOrUpdate("wikipedia_url", result.Url);

                    var item = WikipediaInfoItem.FromSearchResult(result);
                    lastItem = item;

                    var json = JsonSerializer.Serialize(item, typeof(WikipediaInfoItem));
                    ExternalDataCache.Instance.TryAddFile(json, fileUrl, DateTimeManipulationHelper.QuarterDayTimeSpan);
                }
            }
            catch
            {
                throw;
            }

            return data;
        }

        public void SetSpecialProperties(SpecialProperties specialProperties)
        {
            _specialProperties = specialProperties;
        }

        public void Update()
        {
            
        }

        private void InitializeProperties()
        {
            _specialProperties = new SpecialProperties()
                .AddOrUpdate("language", "es")
                .AddOrUpdate("getfirstpage", true)
                .AddOrUpdate("preview", string.Empty)
                .AddOrUpdate("json", string.Empty);

            _mandatoryInputs.AddOrUpdate("expression", "");
            _mandatoryInputs.AddOrUpdate("resultLimit", "1");
            _mandatoryInputs.AddOrUpdate("language", "es");
        }

    }
}
