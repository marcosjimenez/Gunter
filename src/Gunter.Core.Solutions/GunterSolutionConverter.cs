using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Exceptions;
using Gunter.Core.Solutions.Models.SavedComponent;

namespace Gunter.Core.Solutions
{
    public class GunterSolutionConverter
    {
        private static readonly Lazy<GunterSolutionConverter> lazy = new(() => new GunterSolutionConverter());

        public static GunterSolutionConverter Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private GunterSolutionConverter()
        {

        }
        public GunterProcessorBase? GetProcessorFromSavedProcessor(GunterSavedProcessor savedProcessor)
        {
            var type = Type.GetType(savedProcessor.SystemType);
            if (type is null)
                throw new GunterSolutionException($"invalid SystemType ({type})");

            try
            {
                var instance = Activator.CreateInstance(type, savedProcessor.Id, savedProcessor.Name) as GunterProcessorBase;
                return instance;

            }
            catch (Exception ex)
            {
                throw new GunterSolutionException($"Cannot create instance of {type}", ex);
            }
        }

        public static GunterSavedProcessor FromGunterProcessor(IGunterProcessor data)
        => new GunterSavedProcessor
        {
            Id = data.Id,
            Name = data.Name,
            SystemType = data.GetType().ToString()
            //SpecialProperties = data.getspa
        };


        //public GunterInfoItem? GetInfoItemFromSavedInfoItem(GunterSavedInfoItem infoITem)
        //{


        //}

    }
}
