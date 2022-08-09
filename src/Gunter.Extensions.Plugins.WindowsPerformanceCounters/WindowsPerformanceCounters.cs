﻿using Gunter.Extensions.Plugins.WindowsPerformanceCounters.Models;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Gunter.Extensions.Plugins.WindowsPerformanceCounters
{
    internal class WindowsPerformanceCounters
    {

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
            var category = new PerformanceCounterCategory(categoryName);
            var counters = category.GetCounters();
            return counters.Select(x => x.CounterName).ToList();
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

        public List<WPCountersInfoSourceItem> GetCurrentData()
        {
            ThrowIfNoWindows();
            
            var retval = new List<WPCountersInfoSourceItem>();

            foreach(var counter in counters)
            {
                var sample = counter.NextSample();
                retval.Add(new WPCountersInfoSourceItem
                {
                    Name = $"{counter.CounterName} [{counter.InstanceName}]",
                    BaseValue = sample.BaseValue,
                    RawValue = sample.RawValue
                });
            }
            return retval;
        }

    }
}