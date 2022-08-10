using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Models;
using Gunter.Extensions.InfoSources.Specialized.Models;
using System.Collections.Concurrent;
using Tweetinvi;
using Tweetinvi.Models;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class TwitterInfoSource : InfoSourceBase<TwitterInfoItem>, IGunterInfoSource
    {
        private ConcurrentBag<TwitterInfoItem> _messages = new();

        private TwitterClient twitterClient;
        public TwitterInfoItem LastItem { get => lastItem; }

        public bool IsOnline => true;

        public IGunterInfoItem Container { get => _container; }

        public string Category { get => InfoSourceConstants.CAT_COMMUNICATION; }
        public string SubCategory { get => InfoSourceConstants.SUB_SOCIALNETWORKS; }

        private TwitterInfoItem lastItem { get; set; }
        private readonly IGunterInfoItem _container;

        private Dictionary<string, TwitterInfoItem> data = new();
        public TwitterInfoSource()
        {
            Name = "Twitter InfoSource";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("CONSUMER_KEY", "{YOUR_ACCESS_TOKEN_HERE}");
            _mandatoryInputs.AddOrUpdate("CONSUMER_SECRET", "{YOUR_ACCESS_TOKEN_HERE}");
            _mandatoryInputs.AddOrUpdate("BEARER_TOKEN", "{YOUR_ACCESS_TOKEN_HERE}");
            //_mandatoryInputs.AddOrUpdate("ACCESS_TOKEN", "{YOUR_ACCESS_TOKEN_HERE}");
            //_mandatoryInputs.AddOrUpdate("ACCESS_TOKEN_SECRET", "{YOUR_ACCESS_TOKEN_HERE}");
            _container = null;
            lastItem = new TwitterInfoItem();
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
            _mandatoryInputs.AddOrUpdate("CONSUMER_KEY", "{YOUR_ACCESS_TOKEN_HERE}");
            _mandatoryInputs.AddOrUpdate("CONSUMER_SECRET", "{YOUR_ACCESS_TOKEN_HERE}");
            _mandatoryInputs.AddOrUpdate("BEARER_TOKEN", "{YOUR_ACCESS_TOKEN_HERE}");
            //_mandatoryInputs.AddOrUpdate("ACCESS_TOKEN", "{YOUR_ACCESS_TOKEN_HERE}");
            //_mandatoryInputs.AddOrUpdate("ACCESS_TOKEN_SECRET", "{YOUR_ACCESS_TOKEN_HERE}");
            lastItem = new TwitterInfoItem();
            _container = container;
        }

        //~TwitterInfoSource()
        //{
        //    if (receivingCancelToken is not null)
        //        receivingCancelToken.Cancel();

        //    //AsyncHelper.RunSync(() => twitterClient.CloseAsync());
        //}

        public object GetLastItem()
        {
            return lastItem;
        }

        public override Dictionary<string, TwitterInfoItem> GetLastData()
        {

            var client = GetTwitterClient();
            if (client is null)
                return data;

            ITweet[] tweets = { };
            try
            {
                tweets = AsyncHelper.RunSync(() => client.Timelines.GetHomeTimelineAsync());
            }
            catch
            {

            }

            foreach (var mensaje in tweets)
            {
                if (data.ContainsKey(mensaje.Id.ToString()))
                    continue;

                data.Add(mensaje.Id.ToString(), new TwitterInfoItem
                {
                    Id  = mensaje.Id.ToString(),
                    Date = mensaje.CreatedAt,
                    Name = mensaje.CreatedBy.Name,
                    PersonId = mensaje.CreatedBy.Id.ToString(),
                    Text = mensaje.Text
                });
            }

            return data;
        }

        private TwitterClient GetTwitterClient()
        {

            SpecialProperties.TryGetProperty("CONSUMER_KEY", out string? CONSUMER_KEY);
            SpecialProperties.TryGetProperty("CONSUMER_SECRET", out string? CONSUMER_SECRET);
            SpecialProperties.TryGetProperty("BEARER_TOKEN", out string? BEARER_TOKEN);

            var consumerOnlyCredentials = new ConsumerOnlyCredentials(CONSUMER_KEY, CONSUMER_SECRET, BEARER_TOKEN);
            var appClient = new TwitterClient(consumerOnlyCredentials);

            //AsyncHelper.RunSync(() => appClient.Auth.InitializeClientBearerTokenAsync());

            return appClient;
        }

        public void Update()
        {
            GetLastData();
        }
    }
}