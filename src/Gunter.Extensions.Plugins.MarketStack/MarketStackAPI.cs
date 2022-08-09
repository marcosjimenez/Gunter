using Gunter.Core.Infrastructure.Helpers;
using Gunter.Extensions.Plugins.MarketStack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.Plugins.MarketStack
{
    public class MarketStackAPI
    {
        private const string BaseUrl = "http://api.marketstack.com/v1/";


        public const string Endpoint_Exchanges = "exchanges";
        public const string Endpoint_Currencies = "currencies";

        public static T GetFromEndPoint<T>(string apiKey, string endpoint, Dictionary<string, string> parameters = null)
        {
            if (parameters is null)
                parameters = new Dictionary<string, string>();

            parameters.Add("access_key", apiKey);

            var result = AsyncHelper.RunSync(() => WebManipulationHelper.Get<T>($"{BaseUrl}{endpoint}", parameters));
            return result;
        }

        public static MarketStackExchangeResponse GetExchanges(string apiKey)
        {
            var parameters = new Dictionary<string, string>
                {
                    { "access_key", apiKey }
                };

            var result = AsyncHelper.RunSync(() => WebManipulationHelper.Get<MarketStackExchangeResponse>($"{BaseUrl}exchanges", parameters));
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

    }
}
