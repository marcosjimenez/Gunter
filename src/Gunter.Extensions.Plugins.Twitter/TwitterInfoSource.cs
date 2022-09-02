using Gunter.Core.Components;
using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;
using Gunter.Core.Models;
using Gunter.Extensions.InfoSources.Specialized.Models;
using System.Collections.Concurrent;
using Flurl;
using Flurl.Http;
using Gunter.Extensions.Plugins.Twitter.Models;
using Gunter.Core.Infrastructure.Helpers;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class TwitterInfoSource : InfoSourceBase<TwitterData>, IGunterInfoSource
    {

        private const string BaseAddress = @"https://api.twitter.com/2/";
        private const string CONSUMER_KEY = "CONSUMER_KEY";
        private const string CONSUMER_SECRET = "CONSUMER_SECRET";
        private const string BEARER_TOKEN = "BEARER_TOKEN";

        private ConcurrentBag<TwitterData> _messages = new();

        public bool IsOnline => true;

        private readonly IGunterInfoItem? _container;
        public IGunterInfoItem? Container { get => _container; }

        public string Category { get => InfoSourceConstants.CAT_COMMUNICATION; }
        public string SubCategory { get => InfoSourceConstants.SUB_SOCIALNETWORKS; }

        private TwitterData lastItem { get; set; }
        public override TwitterData LastItem { get => LastItem; protected set { lastItem = value; } }

        private Dictionary<string, TwitterData> data = new();
        public TwitterInfoSource()
        {
            Name = "Twitter InfoSource";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(CONSUMER_KEY, "{YOUR_ACCESS_TOKEN_HERE}");
            _mandatoryInputs.AddOrUpdate(CONSUMER_SECRET, "{YOUR_ACCESS_TOKEN_HERE}");
            _mandatoryInputs.AddOrUpdate(BEARER_TOKEN, "{YOUR_ACCESS_TOKEN_HERE}");

            _container = null;
            lastItem = new TwitterData();
        }

        public TwitterInfoSource(string id)
        {
            Id = id;
        }

        public TwitterInfoSource(IGunterInfoItem container, string id, string name)
        {
            Id = id;
            Name = name;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(CONSUMER_KEY, "{YOUR_ACCESS_TOKEN_HERE}");
            _mandatoryInputs.AddOrUpdate(CONSUMER_SECRET, "{YOUR_ACCESS_TOKEN_HERE}");
            _mandatoryInputs.AddOrUpdate(BEARER_TOKEN, "{YOUR_ACCESS_TOKEN_HERE}");

            lastItem = new TwitterData();
            _container = container;
        }


        public object GetLastItem()
        {
            return lastItem;
        }

        public override Dictionary<string, TwitterData> GetLastData()
        {

            var request = CreateRequest("tweets", "search", "recent");
            request.SetQueryParam("query", $"from:twitterdev");

            var results = AsyncHelper.RunSync(() => request.GetJsonAsync<TwitterSearchResponse>());

            foreach(var item in results.Data)
            {
                if (!data.ContainsKey(item.Id.ToString()))
                    data.Add(item.Id.ToString(), new TwitterData
                    {
                        Id = item.Id,
                        Text = item.Text
                    });
            }

            return data;
        }

        public void Update()
        {
            GetLastData();
        }

        private IFlurlRequest CreateRequest(params string[] segments)
        {

            SpecialProperties.TryGetProperty(BEARER_TOKEN, out string token);

            return BaseAddress
                .AppendPathSegments(segments)
                .WithOAuthBearerToken(token)
                .ConfigureRequest(settings =>
                {
                    
                });
        }
    }
}