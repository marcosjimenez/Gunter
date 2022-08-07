using AngleSharp;
using Gunter.Core.Contracts;
using Gunter.Extensions.Common;
using Gunter.Extensions.InfoSources.Specialized.Models;
using Gunter.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Net;
using Gunter.Core.Infrastructure.Helpers;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class OpenWeatherInfoSource : InfoSourceBase<string>, IGunterInfoSource
    {
        private OpenWeatherInfoItem.RootObject lastItem { get; set; }
        private readonly IGunterInfoItem _container;
        private readonly TimeSpan MinInterval = new TimeSpan();

        private Dictionary<string, string> data = new();

        public OpenWeatherInfoItem.RootObject LastItem { get => lastItem; }

        public SpecialProperties SpecialProperties { get; set; }

        public bool IsOnline => true;

        public IGunterInfoItem Container { get => _container; }

        private const string BaseUrl = "http://api.openweathermap.org/data/2.5";
        private const string APPID = "3ad3bbc4ae8ad572fc1b8252553aeb26"; // NEED NEW ONE

        public string Category { get => InfoSourceConstants.CAT_WEATHER; }
        public string SubCategry { get => InfoSourceConstants.SUB_NONOFFICIAL; }


        public OpenWeatherInfoSource() : base()
        {
            Id = string.Empty;
            Name = string.Empty;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("city", "Chiloeches");
            lastItem = new();
        }

        public OpenWeatherInfoSource(string id)
        {
            Id = id;
        }

        public OpenWeatherInfoSource(IGunterInfoItem container, string id, string name)
        {
            Id = id;
            Name = name;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("city", "Chiloeches");
            lastItem = new();
            _container = container;
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
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            _mandatoryInputs.TryGetProperty("city", out string? city);

            var fileUrl = ExternalDataCache.GenerateCacheFileName("OPENWEATHER", city, "weather");
            OpenWeatherInfoItem.RootObject weather = null;
            if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
            {
                var json = Encoding.UTF8.GetString(content);
                weather = System.Text.Json.JsonSerializer.Deserialize<OpenWeatherInfoItem.RootObject>(json);
            }
            else
            {
                weather = WeatherApi.getOneDayWeather(city);
                var json = System.Text.Json.JsonSerializer.Serialize(weather, typeof(OpenWeatherInfoItem.RootObject));
                ExternalDataCache.Instance.TryAddFile(json, fileUrl, DateTimeManipulationHelper.QuarterDayTimeSpan);
            }

            if (weather is not null)
            {
                lastItem = weather;
            }

            return data;
        }

        public void Update()
        {
            GetLastData();
            _container?.InfoSourceUpdated(this);
        }

        class WeatherApi
        {
            public static OpenWeatherInfoItem.RootObject getOneDayWeather(string cityName)
            {

                var parameters = new Dictionary<string, string>
                {
                    { "APPID", APPID },
                    { "q", cityName },
                    { "units", "metric" }
                };

                var result = AsyncHelper.RunSync(() => WebManipulationHelper.Get<OpenWeatherInfoItem.RootObject>($"{BaseUrl}/weather", parameters));
                return result;

                //string url = string.Format("http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric", cityName, APPID);
                //WebClient client = new WebClient();
                //try
                //{
                //    var json = client.DownloadString(url);
                //    var result = JsonConvert.DeserializeObject<WeatherModel.RootObject>(json);
                //    WeatherModel.RootObject weatherData = result;
                //    return weatherData;
                //}
                //catch (WebException e)
                //{
                //    return null;
                //}
            }

            public static OpenWeatherForecastModel.RootObject getHoursForecast(string cityName)
            {
                var parameters = new Dictionary<string, string>
                {
                    { "q", cityName },
                    { "APPID", APPID },
                    { "units", "metric" },
                    { "cnt", "5" }
                };

                var result = AsyncHelper.RunSync(() => WebManipulationHelper.Get<OpenWeatherForecastModel.RootObject>($"{BaseUrl}/forecast", parameters));
                return result;

                //string url = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&APPID={1}&units=metric&cnt=5", cityName, APPID);
                //WebClient client = new WebClient();
                //var json = client.DownloadString(url);
                //var result = JsonConvert.DeserializeObject<OpenWeatherForecastModel.RootObject>(json);
                //OpenWeatherForecastModel.RootObject forecastData = result;
                //return forecastData;
            }

        }


    }
}
