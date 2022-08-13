using Gunter.Core.Infrastructure.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Cache
{
    public class CacheFileIdTypeConverter : TypeConverter
    {
        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
        {
            return CacheFileId.FromString(value.ToString());
        }

    }
}
