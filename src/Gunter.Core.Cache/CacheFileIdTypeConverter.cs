using Gunter.Core.Cache;
using System.ComponentModel;
using System.Globalization;

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
