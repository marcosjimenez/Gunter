using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Exceptions;
using Gunter.Core.Solutions.Models.SavedComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public GunterProcessor? GetProcessorFromSavedProcessor(GunterSavedProcessor savedProcessor)
        {
            var type = Type.GetType(savedProcessor.SystemType);
            if (type is null)
                throw new GunterSolutionException($"invalid SystemType ({type})");

            try
            {
                var instance = Activator.CreateInstance(type, savedProcessor.Id, savedProcessor.Name) as GunterProcessor;
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
