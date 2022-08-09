using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.Plugins.WindowsPerformanceCounters.Models
{
    public class WPCountersInfoSourceItem
    {
        public string Name { get; set; } = string.Empty;
        public object BaseValue { get; set; } = new();
        public object RawValue { get; set; } = new();

    }
}
