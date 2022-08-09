using Gunter.Core.BaseComponents;
using Gunter.Core.Contracts;

namespace Gunter.Core.Solutions.Models.SavedComponent
{
    public class GunterSavedInfoItem : GunterSavedComponentBase<GunterSavedInfoItem>
    {
        public List<GunterSavedInfoSource> InfoSources { get; set; } = new();
        public List<GunterSavedVisualizationHandler> VisualizationHandlers { get; set; } = new();

        public static GunterSavedInfoItem FromInfoItem(IGunterInfoItem infoItem)
        {
            var retVal = new GunterSavedInfoItem
            {
                Id = infoItem.Id,
                Name = infoItem.Name,
                SystemType = GunterEnvironmentHelper.GetSystemTypeName(infoItem.GetType())
            };

            foreach (var infoSource in infoItem.InfoSources)
                retVal.InfoSources.Add(GunterSavedInfoSource.FromInfoSource(infoSource));

            foreach (var visualization in infoItem.VisualizationHandlers)
                retVal.VisualizationHandlers.Add(GunterSavedVisualizationHandler.FromVisualizationHandler(visualization));

            return retVal;
        }


        public static GunterInfoItem ToInfoItem(GunterSavedInfoItem infoItem)
        {
            var retVal = GunterEnvironmentHelper.Instance.CreateInstance<IGunterInfoItem>(infoItem.SystemType, infoItem.Id);
            retVal.Name = infoItem.Name;

            foreach (var infoSource in infoItem.InfoSources)
                retVal.InfoSources.Add(GunterSavedInfoSource.ToInfoSource(infoSource));

            foreach (var visualization in infoItem.VisualizationHandlers)
                retVal.VisualizationHandlers.Add(GunterSavedVisualizationHandler.ToVisualizationHandler(visualization));

            return (GunterInfoItem)retVal;
        }
    }
}
