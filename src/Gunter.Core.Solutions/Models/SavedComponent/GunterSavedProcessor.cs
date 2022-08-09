using Gunter.Core.BaseComponents;
using Gunter.Core.Contracts;

namespace Gunter.Core.Solutions.Models.SavedComponent
{
    public class GunterSavedProcessor : GunterSavedComponentBase<GunterSavedProcessor>
    {
        public List<GunterSavedInfoItem> InfoItems { get; set; } = new();

        public static GunterSavedProcessor FromProcessor(GunterProcessor processor)
        {
            var retVal = new GunterSavedProcessor {
                Id = processor.Id,
                Name = processor.Name,
                SystemType = GunterEnvironmentHelper.GetSystemTypeName(processor.GetType())
            };

            foreach (var infoItem in processor.InfoItems)
                retVal.InfoItems.Add(GunterSavedInfoItem.FromInfoItem(infoItem));

            return retVal;
        }

        public static GunterProcessor ToProcessor(GunterSavedProcessor processor)
        {
            var retVal = GunterEnvironmentHelper.Instance.CreateInstance<IGunterProcessor>(processor.SystemType, processor.Id);
            retVal.Name = processor.Name;

            foreach (var infoItem in processor.InfoItems)
                retVal.InfoItems.Add(GunterSavedInfoItem.ToInfoItem(infoItem));

            return (GunterProcessor)retVal;
        }
    }
}