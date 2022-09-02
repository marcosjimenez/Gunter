using Gunter.Core.Cache;
using Gunter.Core.Components;
using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Models;
using Gunter.Extensions.Plugins.PoePublicStash.Models;
using System.Text;

namespace Gunter.Extensions.Plugins.PoePublicStash
{
    public class PoePublicStashInfoSource : InfoSourceBase<PoePublicStashInfoSourceItem>, IGunterInfoSource
    {
        private PoePublicStashInfoSourceItem lastItem { get; set; } = new();
        public override PoePublicStashInfoSourceItem LastItem { get => lastItem; protected set { lastItem = value; } }

        private Dictionary<string, PoePublicStashInfoSourceItem> data = new();

        public bool IsOnline => true;

        private readonly IGunterInfoItem? _container;
        public IGunterInfoItem? Container => _container;

        private const string NEXT_CHANGE_ID  = "next_change_id";

        public string Category { get => InfoSourceConstants.CAT_INFORMATION; }
        public string SubCategory { get => InfoSourceConstants.SUB_PRICES; }

        public PoePublicStashInfoSource() : base(Guid.NewGuid().ToString())
        {
            Name = "Path of Exile Public Stash API";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(NEXT_CHANGE_ID, NEXT_CHANGE_ID);
            lastItem = new();
        }

        public PoePublicStashInfoSource(string id) : base(id)
        {
            Name = "Path of Exile Public Stash API";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(NEXT_CHANGE_ID, NEXT_CHANGE_ID);
            lastItem = new();
            Id = id;
        }

        public PoePublicStashInfoSource(IGunterInfoItem container, string id, string name) : base(id)
        {
            Name = name;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(NEXT_CHANGE_ID, NEXT_CHANGE_ID);
            lastItem = new();
            _container = container;
        }

        public override Dictionary<string, PoePublicStashInfoSourceItem> GetLastData()
        {
            SpecialProperties.TryGetProperty(NEXT_CHANGE_ID, out string? next_change_id);

            Dictionary<string, string> parameters = new () {
                { "next_change_id", next_change_id}
            };

            var response = TryGetPublicStash(
                PoeAPI.Endpoint_PublicStashTabs,
                DateTimeManipulationHelper.OneMonth,
                "PoE",
                string.IsNullOrWhiteSpace(next_change_id) ? "FirstPage" : next_change_id,
                parameters);
            if (response is not null)
            {
                lastItem = response as PoePublicStashInfoSourceItem;
                SpecialProperties.AddOrUpdate(NEXT_CHANGE_ID, response.next_change_id);
            }

            if (lastItem is not null)
            {
                if (data.ContainsKey(next_change_id))
                    data[next_change_id] = lastItem;
                else
                    data.Add(next_change_id, LastItem);
            }

            return data;
        }

        private PoePublicStashApiResponse TryGetPublicStash(
            string endpoint,
            TimeSpan expirationIfCached,
            string cachedFilePrefix = "PoE",
            string cachedFileMiddle = "API",
            Dictionary<string, string>? parameters = null)
        {
            var fileUrl = ExternalDataCache.GenerateCacheFileID(cachedFilePrefix, cachedFileMiddle, DateTime.Now.ToString("ddMMyyyHHmmss"));
            PoePublicStashApiResponse? stashData = null;
            if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
            {
                var json = Encoding.UTF8.GetString(content);
                var result = System.Text.Json.JsonSerializer.Deserialize<PoePublicStashApiResponse>(json);
                if (result is not null)
                    stashData = result;
            }
            else
            {
                var newStashData = PoeAPI.GetFromEndPoint<PoePublicStashApiResponse>(PoeAPI.Endpoint_PublicStashTabs, endpoint, parameters);
                if (newStashData is not null)
                {
                    newStashData.stashes.RemoveAll(x => !x.IsPublic);
                    var json = System.Text.Json.JsonSerializer.Serialize(newStashData, typeof(PoePublicStashApiResponse));
                    ExternalDataCache.Instance.TryAddFile(json, fileUrl, expirationIfCached);
                    stashData = newStashData;
                }
            }

            return stashData ?? new PoePublicStashApiResponse();
        }

        public void Update()
        {
            GetLastData();
        }
    }
}
