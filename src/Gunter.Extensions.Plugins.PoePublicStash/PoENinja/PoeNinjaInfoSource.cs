using Gunter.Core.Cache;
using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Components;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Models;
using System.Text;
using Gunter.Core.Infrastructure.Log;

namespace Gunter.Extensions.Plugins.PoePublicStash.PoENinja
{
    public class PoeNinjaInfoSource : InfoSourceBase<PoeNinjaInfoSourceItem>, IGunterInfoSource
    {
        private PoeNinjaInfoSourceItem lastItem { get; set; } = new();
        public override PoeNinjaInfoSourceItem LastItem { get => lastItem; protected set { lastItem = value; } }

        private Dictionary<string, PoeNinjaInfoSourceItem> data = new();

        private readonly IGunterInfoItem? _container;
        public IGunterInfoItem? Container => _container;

        private const string TYPE = "Type";
        private const string LEAGUE = "League";
        private const string LEAGUE_START_DATE = "League Start Date";

        public string Category { get => InfoSourceConstants.CAT_INFORMATION; }
        public string SubCategory { get => InfoSourceConstants.SUB_PRICES; }

        public PoeNinjaInfoSource() : base(Guid.NewGuid().ToString())
        {
            Name = "PoENinja currency status";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(LEAGUE, "Sentinel");
            _mandatoryInputs.AddOrUpdate(TYPE, "Currency");
            _mandatoryInputs.AddOrUpdate(LEAGUE_START_DATE, "13/05/2022");
            lastItem = new();
        }

        public PoeNinjaInfoSource(string id) : base(id)
        {
            Name = "PoENinja currency status";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(LEAGUE, "Sentinel");
            _mandatoryInputs.AddOrUpdate(TYPE, "Currency");
            _mandatoryInputs.AddOrUpdate(LEAGUE_START_DATE, "13/05/2022");
            lastItem = new();
            Id = id;
        }

        public PoeNinjaInfoSource(IGunterInfoItem container, string id, string name) : base(id)
        {
            Name = name;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(LEAGUE, "Sentinel");
            _mandatoryInputs.AddOrUpdate(TYPE, "Currency");
            _mandatoryInputs.AddOrUpdate(LEAGUE_START_DATE, "13/05/2022");
            lastItem = new();
            _container = container;
        }

        public override Dictionary<string, PoeNinjaInfoSourceItem> GetLastData()
        {
            SpecialProperties.TryGetProperty(LEAGUE, out string? league);
            SpecialProperties.TryGetProperty(LEAGUE_START_DATE, out string? startDateString);
            SpecialProperties.TryGetProperty(TYPE, out string? type);

            Dictionary<string, string> parameters = new() {
                { LEAGUE.ToLower(), league},
                { TYPE.ToLower(), type}
            };

            var startDate = DateTime.Parse(startDateString);

            PoENinjaAPIResponse? response = null;
            try
            {
                response = TryGetCurrencies(
                    DateTimeManipulationHelper.HalfDayTimeSpan,
                    parameters,
                    "PoE",
                    league,
                    "Currency");

            }
            catch (Exception ex)
            {
                GunterLog.Instance.Log(this, ex.Message, GunterLogItem.GunterLogItemSeverity.Error);
            }

            if (response is not null)
            {
                lastItem = GenerateItem(response, startDate);
                if (data.ContainsKey(league))
                    data[league] = lastItem;
                else
                    data.Add(league, LastItem);
            }

            return data;
        }

        private static PoeNinjaInfoSourceItem GenerateItem(PoENinjaAPIResponse response, DateTime startDate)
        {
            var difference = DateTimeOffset.UtcNow - startDate;
            var leagueDay = (int)difference.TotalDays;

            var retVal = new PoeNinjaInfoSourceItem()
            {
                UtcDateTime = DateTime.UtcNow
            };

            foreach(var item in response.Lines.AsParallel())
            {
                retVal.Currencies.Add(new PoeNinjaInfoSourceItemCurrency
                {
                    LeagueDay = leagueDay,
                    ChaosEquivalent = item.ChaosEquivalent ?? 0,
                    Currency = item.CurrencyTypeName
                });
            }

            return retVal;
        }

        private PoENinjaAPIResponse TryGetCurrencies(
            TimeSpan expirationIfCached,
            Dictionary<string, string>? parameters = null,
            params string[] cacheFolders)
        {
            var fileUrl = ExternalDataCache.GenerateCacheFileID(cacheFolders);
            PoENinjaAPIResponse? apiResponse = null;
            if (ExternalDataCache.Instance.TryGetFile(fileUrl, out byte[] content))
            {
                var json = Encoding.UTF8.GetString(content);
                var result = System.Text.Json.JsonSerializer.Deserialize<PoENinjaAPIResponse>(json);
                if (result is not null)
                    apiResponse = result;
            }
            else
            {
                var newStashData = PoeAPI.GetFromEndPoint<PoENinjaAPIResponse>(PoeAPI.Endpoint_PoENinjaAPI, string.Empty, parameters);
                if (newStashData is not null)
                {
                    var json = System.Text.Json.JsonSerializer.Serialize(newStashData, typeof(PoENinjaAPIResponse));
                    ExternalDataCache.Instance.TryAddFile(json, fileUrl, expirationIfCached);
                    apiResponse = newStashData;
                }
            }

            return apiResponse ?? new PoENinjaAPIResponse();
        }

        public void Update()
        {
            GetLastData();
        }
    }
}
