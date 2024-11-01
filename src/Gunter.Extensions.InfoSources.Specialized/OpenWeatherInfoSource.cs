﻿using Gunter.Core.Components;
using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;
using Gunter.Core.Cache;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Models;
using Gunter.Extensions.InfoSources.Specialized.Models;
using System.Text;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class OpenWeatherInfoSource : InfoSourceBase<OpenWeatherData>, IGunterInfoSource
    {
        public override OpenWeatherData LastItem { get; protected set; }

        private readonly IGunterInfoItem _container;

        private Dictionary<string, OpenWeatherData> data = new();
        public IGunterInfoItem Container { get => _container; }

        private const string BaseUrl = "http://api.openweathermap.org/data/2.5";
        private const string APPID = "3ad3bbc4ae8ad572fc1b8252553aeb26"; // NEED NEW ONE

        public string Category { get => InfoSourceConstants.CAT_INFORMATION; }
        public string SubCategory { get => InfoSourceConstants.SUB_WEATHER; }


        public OpenWeatherInfoSource() : base()
        {
            Name = "OpenWeather InfoSource";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("APPID", APPID);
            _mandatoryInputs.AddOrUpdate("city", "Chiloeches");
            LastItem = new();
        }

        public OpenWeatherInfoSource(string id)
        {
            Id = id;
            Name = "OpenWeather InfoSource";
        }

        public OpenWeatherInfoSource(IGunterInfoItem container, string id, string name)
        {
            Id = id;
            Name = name;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("APPID", APPID);
            _mandatoryInputs.AddOrUpdate("city", "Chiloeches");
            LastItem = new();
            _container = container;
        }
        public object GetLastItem()
        {
            return LastItem;
        }

        public override Dictionary<string, OpenWeatherData> GetLastData()
        {
            SpecialProperties.TryGetProperty("city", out string? city);
            SpecialProperties.TryGetProperty("APPID", out string? appid);

            var fileUrl = ExternalDataCache.GenerateCacheFileID("OPENWEATHER", city, "weather");
            OpenWeatherData? weather = null;
            if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
            {
                var json = Encoding.UTF8.GetString(content);
                weather = System.Text.Json.JsonSerializer.Deserialize<OpenWeatherData>(json);
            }
            else
            {
                weather = WeatherApi.getOneDayWeather(city);
                var json = System.Text.Json.JsonSerializer.Serialize(weather, typeof(OpenWeatherData));
                ExternalDataCache.Instance.TryAddFile(json, fileUrl, DateTimeManipulationHelper.QuarterDayTimeSpan);
            }

            if (weather is not null)
            {
                LastItem = weather;
            }

            return data;
        }

        public void Update()
        {
            GetLastData();
        }

        class WeatherApi
        {
            public static OpenWeatherData getOneDayWeather(string cityName)
            {
                var parameters = new Dictionary<string, string>
                {
                    { "APPID", APPID },
                    { "q", cityName },
                    { "units", "metric" }
                };

                var result = AsyncHelper.RunSync(() => WebManipulationHelper.Get<OpenWeatherResponseModel.RootObject>($"{BaseUrl}/weather", parameters));
                return OpenWeatherData.FromOpenWeatherResponseModel(result);

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
