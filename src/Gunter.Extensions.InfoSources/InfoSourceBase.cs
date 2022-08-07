using Gunter.Core.Constants;
using Gunter.Core.Infrastructure.Exceptions;
using Gunter.Extensions.Common;

namespace Gunter.Extensions.InfoSources
{
    public abstract class InfoSourceBase<T>
    {
        public string ClassId { get => IdentificationConstants.CLASSID.GunterInfoSource; }

        public string Id { get; protected set; }
        public string Name { get; set; }

        protected SpecialProperties _mandatoryInputs = new();

        public InfoSourceBase()
        {

        }

        public InfoSourceBase(string id)
        {
            Id = id;
        }

        public SpecialProperties GetMandatoryParams()
        {
            return _mandatoryInputs;
        }

        public object? GetMandatoryParam(string name)
        {
            if (_mandatoryInputs.TryGetProperty(name, out var value))
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
            if (!_mandatoryInputs.TryGetProperty(key, out var input))
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

        public virtual void CreateComponentsFromIdentification()
        {
            //lock (lockObject)
            //{
            //    foreach (var item in ComponentIdentification.CreateComponentFromIdentification<IGunterInfoSource>(Identifications))
            //    {
            //        AddInfoSource(item);
            //        item.CreateComponentsFromIdentification();
            //    }
            //}
        }

        public virtual void CreateIdentification()
        {
            //lock (lockObject)
            //{
            //    Identifications.Clear();
            //    foreach (var item in InfoSources)
            //        Identifications.Add(new ComponentIdentification { Id = item.Id, SystemType = item.GetType().ToString() });
            //}
        }
    }
}
