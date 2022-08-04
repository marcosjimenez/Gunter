using Gunter.Extensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.InfoSources.Specialized.Models
{
    public class WindowsEventLogInfoItem : SystemEventLogValoration<WindowsEventLevel>
    {
        public override WindowsEventLevel Severity { get; set; }
    }
}
