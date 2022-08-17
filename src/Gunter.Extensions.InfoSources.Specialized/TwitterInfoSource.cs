using Gunter.Core.Components;
using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Models;
using Gunter.Extensions.InfoSources.Specialized.Models;
using System.Collections.Concurrent;


namespace Gunter.Extensions.InfoSources.Specialized
{
    public class TwitterInfoSource : InfoSourceBase<TwitterData>, IGunterInfoSource
    {
        private ConcurrentBag<TwitterData> _messages = new();

        public bool IsOnline => true;

        private readonly IGunterInfoItem? _container;
        public IGunterInfoItem? Container { get => _container; }

        public string Category { get => InfoSourceConstants.CAT_COMMUNICATION; }
        public string SubCategory { get => InfoSourceConstants.SUB_SOCIALNETWORKS; }

        private TwitterData lastItem { get; set; }

        private Dictionary<string, TwitterData> data = new();
        public TwitterInfoSource()
        {
            Name = "Twitter InfoSource";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate("CONSUMER_KEY", "{YOUR_ACCESS_TOKEN_HERE}");
            _mandatoryInputs.AddOrUpdate("CONSUMER_SECRET", "{YOUR_ACCESS_TOKEN_HERE}");
            _mandatoryInputs.AddOrUpdate("BEARER_TOKEN", "{YOUR_ACCESS_TOKEN_HERE}");

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
            _mandatoryInputs.AddOrUpdate("CONSUMER_KEY", "{YOUR_ACCESS_TOKEN_HERE}");
            _mandatoryInputs.AddOrUpdate("CONSUMER_SECRET", "{YOUR_ACCESS_TOKEN_HERE}");
            _mandatoryInputs.AddOrUpdate("BEARER_TOKEN", "{YOUR_ACCESS_TOKEN_HERE}");

            lastItem = new TwitterData();
            _container = container;
        }


        public object GetLastItem()
        {
            return lastItem;
        }

        public override Dictionary<string, TwitterData> GetLastData()
        {
                   
            

            

            return data;
        }

        

        public void Update()
        {
            GetLastData();
        }
    }
}