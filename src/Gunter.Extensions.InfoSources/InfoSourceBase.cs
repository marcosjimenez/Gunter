using AngleSharp.Dom;
using Gunter.Extensions.Common;
using Gunter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Extensions.InfoSources
{
    public abstract class InfoSourceBase<T>
    {
        protected SpecialProperties _mandatoryInputs = new();

       public SpecialProperties GetMandatoryParams()
        {
            return _mandatoryInputs;
        }

        public object? GetMandatoryParam(string name)
        {
            if (_mandatoryInputs.TryGetProperty(name, out object? value))
            {
                return value;
            }

            return null;
        }

        public abstract Dictionary<string, T> GetLastData();

        //public SpecialProperties GetMandatoryParams()
        //    => _mandatoryInputs;

        protected void AddMandatoryParam(string key, string value)
        {
            if (!_mandatoryInputs.TryGetProperty<string>(key, out var input))
            {
                throw new GunterInfoSourceException($"Unexpected mandatory property {key}");
            }
            _mandatoryInputs.AddOrUpdate(key, value);
        }

        public bool IsReady()
        {
            foreach (var item in _mandatoryInputs.Properties)
            {
                if (string.IsNullOrWhiteSpace(item.Value.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
