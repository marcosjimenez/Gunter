using Gunter.Core.Contracts;

namespace Gunter.Core.Solutions.Models.SavedComponent
{
    public class GunterSavedInfoSource : GunterSavedComponentBase<GunterSavedInfoSource>
    {
        public static GunterSavedInfoSource FromInfoSource(IGunterInfoSource source)
        {
            var retVal = new GunterSavedInfoSource
            {
                Id = source.Id,
                Name = source.Name,
                SystemType = GunterEnvironmentHelper.GetSystemTypeName(source.GetType()),
                SpecialProperties = source.SpecialProperties
            };
           
            return retVal;
        }

        public static IGunterInfoSource ToInfoSource(GunterSavedInfoSource infoSource)
        {
            var retVal = GunterEnvironmentHelper.Instance.GetInstance<IGunterInfoSource>(infoSource.SystemType, infoSource.Id);
            retVal.Name = infoSource.Name;
            retVal.SetSpecialProperties(infoSource.SpecialProperties);

            return retVal;
        }

    }
}
