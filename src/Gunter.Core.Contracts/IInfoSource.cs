using Gunter.Extensions.Common;

namespace Gunter.Core.Contracts
{
    public interface IInfoSource
    {
        string Id { get; set; }

        string Name { get; set; }

        string Category { get;  }
        string SubCategry { get; }

        SpecialProperties SpecialProperties { get; }

        bool IsOnline { get; }

        void SetSpecialProperties(SpecialProperties specialProperties);

        void Update();

        object GetData();

        SpecialProperties GetMandatoryParams();

        IGunterInfoItem Container { get; }

    }
}
