using Gunter.Core.Contracts;

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
            var retVal = GunterEnvironmentHelper.Instance.CreateInstance<IGunterVisualizationHandler>(infoItem.SystemType, infoItem.Id);
            retVal.Name = infoItem.Name;

            return retVal;
        }
    }
}
