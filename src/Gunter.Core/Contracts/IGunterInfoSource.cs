using Gunter.Core.Models;

namespace Gunter.Core.Contracts
{
    public interface IGunterInfoSource : IGunterComponent
    {
        string Category { get;  }
        string SubCategory { get; }
        SpecialProperties SpecialProperties { get; set; }
        bool IsOnline { get; }
        IGunterInfoItem Container { get; }
        void SetSpecialProperties(SpecialProperties specialProperties);
        void Update();
        object GetData();
        SpecialProperties GetMandatoryParams();
    }
}
