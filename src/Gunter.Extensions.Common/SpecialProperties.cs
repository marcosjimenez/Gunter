using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.Common
{
    public class SpecialProperties
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public Dictionary<string, SpecialProperty> Properties { get; set; } = new();

        public SpecialProperties()
        {

        }

        public SpecialProperties(string id = "")
        {

        }

        public SpecialProperties AddOrUpdate(string key, object value)
            => AddOrUpdate(key, value.ToString());

        public SpecialProperties AddOrUpdate(string key, string value, out SpecialProperty specialProperty)
        {
            var property = new SpecialProperty
            {
                Name = key,
                Value = value
            };

            if (!Properties.ContainsKey(key))
            {
                Properties.Add(key, property);
            }
            else
            {
                Properties[key] = property;
            }

            specialProperty = property;

            return this;
        }

        public bool TryGetProperty(string key, out string value)
        {
            Properties.TryGetValue(key, out var retVal);
            value = retVal?.Value ?? string.Empty;
            return value is not null;
        }
    }
}
