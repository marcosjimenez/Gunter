using Gunter.Extensions.Plugins.WindowsPerformanceCounters.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Gunter.Extensions.Plugins.WindowsPerformanceCounters
{
    internal class WindowsPerformanceCounters
    {
        private const string InstanceName = "WPCountersInfoSource";

        private static readonly Lazy<WindowsPerformanceCounters> lazy = new (() => new WindowsPerformanceCounters());

        public static WindowsPerformanceCounters Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private List<PerformanceCounter> counters = new();

        private WindowsPerformanceCounters()
        {
            
        }

        private bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

        private void ThrowIfNoWindows()
        {
            if (!IsWindows())
                throw new InvalidOperationException("Performance counter only runs on windows");
        }

        public List<string> GetCategories()
        {
            ThrowIfNoWindows();

            var categories = PerformanceCounterCategory.GetCategories();

            return categories.Select(x => x.CategoryName).ToList();
        }

        public List<string> GetCounters(string categoryName)
        {
            ThrowIfNoWindows();
            PerformanceCounterCategory category = PerformanceCounterCategory.GetCategories().First(c => c.CategoryName == categoryName);
            Console.WriteLine("{0} [{1}]", category.CategoryName, category.CategoryType);

            string[] instanceNames = category.GetInstanceNames();

            var retVal = new List<string>();
            if (instanceNames.Length == 0)
            {
                // SingleInstance categories
                retVal = ListInstances(category, string.Empty);
            }
            else
            {
                // MultiInstance categories
                foreach (string instanceName in instanceNames)
                    retVal.AddRange(ListInstances(category, instanceName));
            }

            return retVal;
        }

        private static List<string> ListInstances(PerformanceCounterCategory category, string instanceName)
        {
            PerformanceCounter[] counters = category.GetCounters(instanceName);
            var retVal = new List<string>();
            foreach (PerformanceCounter counter in counters)
                retVal.Add(counter.CounterName);

            return retVal;
        }

        public void AddCounter(string counterName, string categoryName)
        {
            ThrowIfNoWindows();
            var counter = new PerformanceCounter(categoryName, counterName);
            counters.Add(counter);
        }

        public void RemoveCounter(string counterName)
        {
            ThrowIfNoWindows();
            var counter = counters.Where(x => x.CounterName == counterName).SingleOrDefault();
            counters.Remove(counter);
            counter.Close();
            counter = null;
        }

        public WPCountersInfoSourceItem GetCurrentData()
        {
            ThrowIfNoWindows();
            
            var retVal = new List<WPCountersInfoSourceItemData>();

            foreach(var counter in counters)
            {
                var sample = counter.NextSample();
                retVal.Add(new WPCountersInfoSourceItemData
                {
                    Name = $"{counter.CounterName} [{counter.InstanceName}]",
                    BaseValue = sample.BaseValue,
                    RawValue = sample.RawValue
                });
            }

            return new WPCountersInfoSourceItem { CounterData = retVal };
        }

    }
}
