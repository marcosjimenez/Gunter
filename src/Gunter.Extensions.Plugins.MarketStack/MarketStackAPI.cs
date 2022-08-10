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
        public const string Endpoint_MarketIndices = "eod";

        public static T GetFromEndPoint<T>(string apiKey, string endpoint, Dictionary<string, string> parameters = null)
        {
            if (parameters is null)
                parameters = new Dictionary<string, string>();

            parameters.Add("access_key", apiKey);

            var result = AsyncHelper.RunSync(() => WebManipulationHelper.Get<T>($"{BaseUrl}{endpoint}", parameters));
            return result;
        }
    }
}
