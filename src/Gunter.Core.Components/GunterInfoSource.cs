using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;

namespace Gunter.Core.Components
{
    public class GunterInfoSource<T> : InfoSourceBase<T>, IMessagingComponent
    {
        public GunterInfoSource() : base()
        {

        }
        public GunterInfoSource(string id) : base(id)
        {
            Id = id;
            GetClient();
        }
    }
}
