using Gunter.Core.Contracts;
using Gunter.Core.Models;
using Gunter.Extensions.InfoSources;
using Gunter.Extensions.Plugins.WindowsPerformanceCounters.Models;
using System.Text;

namespace Gunter.Extensions.Plugins.WindowsPerformanceCounters
{
    public class WPCountersInfoSource : InfoSourceBase<WPCountersInfoSourceItem>, IGunterInfoSource
    {
        public string Category { get => InfoSourceConstants.CAT_MEASURED_VALUES; }
        public string SubCategory { get => InfoSourceConstants.SUB_PERFORMANCE_COUNTERS; }

        private const string MachineName = "Machine Name";
        private const string Priority = "Priority (1-5) (NOT WORKING)";

        private WPCountersInfoSourceItem lastItem { get; set; } = new();

        private readonly TimeSpan MinInterval = new TimeSpan();

        private Dictionary<string, WPCountersInfoSourceItem> data = new();

        public WPCountersInfoSourceItem LastItem { get => lastItem; }

        public bool IsOnline => false;

        private readonly IGunterInfoItem? _container;
        public IGunterInfoItem? Container { get => _container; }

        public WPCountersInfoSource() : base()
        {
            Name = "MarketStack InfoSource";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(MachineName, Environment.MachineName);
            _mandatoryInputs.AddOrUpdate(Priority, 1);
            lastItem = new();
        }

        public WPCountersInfoSource(string id)
        {
            Id = id;
        }

        public WPCountersInfoSource(IGunterInfoItem container, string id, string name)
        {
            Id = id;
            Name = name;
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(MachineName, Environment.MachineName);
            _mandatoryInputs.AddOrUpdate(Priority, 1);
            lastItem = new();
            _container = container;
        }
        public object GetData()
        {

            if (lastItem is null)
                GetLastData();

            return lastItem;
        }

        public override Dictionary<string, WPCountersInfoSourceItem> GetLastData()
        {
            SpecialProperties.TryGetProperty(MachineName, out string? machineName);

            ////var exchanges = TryGetFromMarketStack<WPCountersInfoSourceItem>(apiKey, MarketStackAPI.Endpoint_Exchanges);
            //if (exchanges is not null)
            //{
            //    lastItem.Exchanges = exchanges;
            //}

            //WindowsPerformanceCounters.Instance.


            if (data.ContainsKey(machineName))
                data[machineName] = lastItem;
            else
                data.Add(machineName, LastItem);

            return data;
        }

        public void Update()
        {
            GetLastData();
            _container?.InfoSourceUpdated(this);
        }
    }
}
