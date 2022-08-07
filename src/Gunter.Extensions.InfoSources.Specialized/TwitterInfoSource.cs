using Gunter.Extensions.Common;
using Gunter.Core.Contracts;
using Gunter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Extensions.InfoSources.Specialized.Models;
using System.Collections.Concurrent;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using Tweetinvi;
using Gunter.Infrastructure.Cache;
using Tweetinvi.Parameters;
using Tweetinvi.Models;

namespace Gunter.Extensions.InfoSources.Specialized
{
    public class TwitterInfoSource : InfoSourceBase<TwitterInfoItem>, IGunterInfoSource
    {
        private ConcurrentBag<TwitterInfoItem> _messages = new();

        private TwitterClient twitterClient;
        public TwitterInfoItem LastItem { get => lastItem; }

        public SpecialProperties SpecialProperties { get; set; }

        public bool IsOnline => true;

        public IGunterInfoItem Container { get => _container; }

        public string Category { get => InfoSourceConstants.CAT_COMMUNICATION; }
        public string SubCategry { get => InfoSourceConstants.SUB_SOCIALNETWORKS; }

        private TwitterInfoItem lastItem { get; set; }
        private readonly IGunterInfoItem _container;

        private Dictionary<string, TwitterInfoItem> data = new();
        public TwitterInfoSource()
        {
            Id = string.Empty;
            Name = string.Empty;
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

        public object GetData()
        {
            return lastItem;
        }

        public void SetSpecialProperties(SpecialProperties specialProperties)
        {
            SpecialProperties = specialProperties;
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
            _container?.InfoSourceUpdated(this);
        }
    }
}