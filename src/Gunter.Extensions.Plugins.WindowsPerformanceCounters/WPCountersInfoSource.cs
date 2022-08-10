using Gunter.Core.Contracts;
using Gunter.Core.Models;
using Gunter.Extensions.InfoSources;
using Gunter.Extensions.Plugins.WindowsPerformanceCounters.Models;
using System.Diagnostics;
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
            Name = "Windows Performance Counters InfoSource";
            SpecialProperties = new SpecialProperties();
            _mandatoryInputs.AddOrUpdate(MachineName, Environment.MachineName);
            _mandatoryInputs.AddOrUpdate(Priority, 1);
            AddAllCounters();
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
            AddAllCounters();
            lastItem = new();
            _container = container;
        }

        private void AddAllCounters()
        {
            //var categories = WindowsPerformanceCounters.Instance.GetCategories();

            //foreach(var cat in categories)
            //{ 
            //    var counters = WindowsPerformanceCounters.Instance.GetCounters(cat);
            //    foreach(var counter in counters)
            //        _mandatoryInputs.AddOrUpdate(counter, false);
            //}
        }

        public void CreateCounter(string counterName, string categoryName)
        {
            WindowsPerformanceCounters.Instance.AddCounter(counterName, categoryName);
        }

        public object GetLastItem()
        {

            if (lastItem is null)
                GetLastData();

            return lastItem;
        }

        public override Dictionary<string, WPCountersInfoSourceItem> GetLastData()
        {
            SpecialProperties.TryGetProperty(MachineName, out string? machineName);

            var countersData = WindowsPerformanceCounters.Instance.GetCurrentData();
            if (countersData.CounterData.Count == 0)
                return data;

            lastItem = countersData;
                
            if (data.ContainsKey(machineName))
                data[machineName] = lastItem;
            else
                data.Add(machineName, LastItem);

            return data;
        }

        public void Update()
        {
            GetLastData();
        }
    }
}
