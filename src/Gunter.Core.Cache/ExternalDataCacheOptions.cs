using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Cache
{
    public class ExternalDataCacheOptions
    {
        public bool UseVersions { get; set; } = true;
        public bool AutoSave { get; set; } = true;
    }
}
