using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.Common
{
    public class SpecialProperties
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();

        public SpecialProperties()
        {
            _properties = new Dictionary<string, object>();
        }

        public SpecialProperties AddOrUpdate(string key, object value)
        {
            if (!_properties.ContainsKey(key))
            {
                _properties.Add(key, value);
            }
            else
            {
                _properties[key] = value;
            }

            return this;
        }

        public bool TryGetProperty<T>(string key, out T? value)
        {
            _properties.TryGetValue(key, out var retVal);

            if (retVal == null)
            {
                value =  default(T);
            }
            else
            {
                value = (T?)retVal;
            }

            return !(retVal is null);
        }

        public Dictionary<string, object> Properties => _properties;

    }
}
