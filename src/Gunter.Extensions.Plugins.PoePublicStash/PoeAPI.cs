using Gunter.Core.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.Plugins.PoePublicStash
{
    public static class PoeAPI
    {
        private const string BaseUrl = "https://api.pathofexile.com/";


        public const string Endpoint_PublicStashTabs = "public-stash-tabs";

        public static T? GetFromEndPoint<T>(string apiKey, string endpoint, Dictionary<string, string>? parameters = null)
        {
            if (parameters is null)
                parameters = new Dictionary<string, string>();

            var result = AsyncHelper.RunSync(() => WebManipulationHelper.Get<T>($"{BaseUrl}{endpoint}", parameters));
            return result;
        }

    }
}
