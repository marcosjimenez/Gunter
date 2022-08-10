using Gunter.Core.Contracts;
using Gunter.Extensions.InfoSources.Specialized.Models;
using Gunter.Infrastructure.Cache;
using System.Text;
using System.Text.Json;
using WikiDotNet;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Models;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class WikipediaInfoSource : InfoSourceBase<WikipediaInfoItem>, IGunterInfoSource
    {
        private WikipediaInfoItem lastItem;
        public WikipediaInfoItem LastItem { get => lastItem; }

        private readonly IGunterInfoItem _container;
        private Dictionary<string, WikipediaInfoItem> data = new();

        public bool IsOnline => true;

        public IGunterInfoItem Container { get => _container; }

        public string Category { get => InfoSourceConstants.CAT_COMMUNICATION; }
        public string SubCategory { get => InfoSourceConstants.SUB_ENCYCLOPAEDIA; }


        public WikipediaInfoSource()
        {
            Name = "Wikipedia InfoSource";
            _container = null;
            InitializeProperties();
        }

        public WikipediaInfoSource(string id)
        {
            Id = id;
            Name = "Wikipedia InfoSource";
        }

        public WikipediaInfoSource(IGunterInfoItem container, string id, string name)
        {
            Id = id;
            Name = name;
            _container = container;
            InitializeProperties();
        }

        public object GetLastItem()
        {
            GetLastData();
            return lastItem;
        }

        public override Dictionary<string, WikipediaInfoItem> GetLastData()
        {
            SpecialProperties.TryGetProperty("expression", out string? searchString);
            SpecialProperties.TryGetProperty("resultLimit", out string? resultLimitString);
            SpecialProperties.TryGetProperty("language", out string? language);

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
                    if (result is null)
                        return data;

                    SpecialProperties.AddOrUpdate("preview", result.Preview);
                    SpecialProperties.AddOrUpdate("wikipedia_url", result.Url);

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

        public void Update()
        {
            
        }

        private void InitializeProperties()
        {
            SpecialProperties = new SpecialProperties()
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
