using Gunter.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Solutions.Models.SavedComponent
{
    public class GunterSavedVisualizationHandler : GunterSavedComponentBase<GunterSavedVisualizationHandler>
    {
        public static GunterSavedVisualizationHandler FromVisualizationHandler(IGunterVisualizationHandler handler)
        {
            var retVal = new GunterSavedVisualizationHandler
            {
                Id = handler.Id,
                Name = handler.Name,
                SystemType = GunterEnvironmentHelper.GetSystemTypeName(handler.GetType())
            };
            return retVal;
        }

        public static IGunterVisualizationHandler ToVisualizationHandler(GunterSavedVisualizationHandler infoItem)
        {
            var retVal = GunterEnvironmentHelper.Instance.GetInstance<IGunterVisualizationHandler>(infoItem.SystemType, infoItem.Id);
            retVal.Name = infoItem.Name;

            return retVal;
        }
    }
}
