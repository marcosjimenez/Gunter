using AngleSharp;
using Gunter.Core.Contracts;
using Gunter.Extensions.Common;
using Gunter.Extensions.InfoSources.Specialized.Models;
using Gunter.Infrastructure.Cache;
using Gunter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class GunterBotInfoSource : InfoSourceBase<string>, IInfoSource
    {
        private string lastItem { get; set; }
        private readonly IGunterInfoItem _container;
        private readonly TimeSpan MinInterval = new TimeSpan();

        private Dictionary<string, string> data = new();

        public string LastItem { get => lastItem; }

        public SpecialProperties SpecialProperties { get; set; }

        public bool IsOnline => true;

        public string Id { get; set; }
        public string Name { get; set; }

        public IGunterInfoItem Container { get => _container; }

        public string Category { get => InfoSourceConstants.CAT_COMMUNICATION; }
        public string SubCategry { get => InfoSourceConstants.SUB_BOTS; }

        public GunterBotInfoSource()
        {
            Id = string.Empty;
            Name = string.Empty;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("city", "Chiloeches");
            _container = null;
            lastItem = string.Empty;
        }

        public GunterBotInfoSource(IGunterInfoItem container, string id, string name)
        {
            Id = id;
            Name = name;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("city", "Chiloeches");
            lastItem = string.Empty;
            _container = container;

            //var botClient = new TelegramBotClient("{YOUR_ACCESS_TOKEN_HERE}");
            //var me = await botClient.GetMeAsync();
        }
        public object GetData()
        {
            return lastItem;
        }

        public void SetSpecialProperties(SpecialProperties specialProperties)
        {
            SpecialProperties = specialProperties;
        }

        public override Dictionary<string, string> GetLastData()
        {
            _mandatoryInputs.TryGetProperty("city", out string? city);

            var fileUrl = ExternalDataCache.GenerateCacheFileName(string.Empty, "GUNTERBOT", string.Empty);

            if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
            {
                var json = Encoding.UTF8.GetString(content);
                //weather = System.Text.Json.JsonSerializer.Deserialize<OpenWeatherInfoItem.RootObject>(json);
            }
            else
            {
                //weather = WeatherApi.getOneDayWeather(city);
                //var json = System.Text.Json.JsonSerializer.Serialize(weather, typeof(OpenWeatherInfoItem.RootObject));
                //ExternalDataCache.Instance.TryAddFile(json, fileUrl, DateTimeManipulationHelper.QuarterDayTimeSpan);
            }

            //if (weather is not null)
            //{
            //    lastItem = weather;
            //}

            return data;
        }

        public void Update()
        {
            GetLastData();
            _container?.InfoSourceUpdated(this);
        }
    }
}
