using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Cache.Commands
{
    public class CacheCommandMethodAttribute : Attribute
    {
        public string Command { get; set; } = string.Empty;
        public string HelpText { get; set; } = string.Empty;
    }
}
