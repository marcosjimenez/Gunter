namespace Gunter.Extensions.Plugins.WindowsPerformanceCounters.Models
{
    public class WPCountersInfoSourceItem
    {
        public List<WPCountersInfoSourceItemData> CounterData { get; set; } = new();

    }

    public class WPCountersInfoSourceItemData
    {
        public string Name { get; set; } = string.Empty;
        public object BaseValue { get; set; } = new();
        public object RawValue { get; set; } = new();
    }
}
