using Gunter.Core.Models;

namespace Gunter.Core.Solutions.Models.SavedComponent
{
    public abstract class GunterSavedComponentBase<T>
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public SpecialProperties SpecialProperties { get; set; } = new SpecialProperties();
        public string SystemType { get; set; } = string.Empty;
    }
}
