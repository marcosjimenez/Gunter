using Gunter.Extensions.Common;

namespace Gunter.Core.Contracts
{
    public interface IGunterInfoSource : IGunterComponent
    {
        string Category { get;  }
        string SubCategry { get; }
        SpecialProperties SpecialProperties { get; set; }
        bool IsOnline { get; }
        IGunterInfoItem Container { get; }
        void SetSpecialProperties(SpecialProperties specialProperties);
        void Update();
        object GetData();
        SpecialProperties GetMandatoryParams();
    }
}
