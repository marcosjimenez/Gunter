using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;

namespace Gunter.Core.BaseComponents
{
    public partial class GunterInfoItem : GunterInfoItemBase, IGunterInfoItem
    {
        public GunterInfoItem() : base()
        {

        }

        public GunterInfoItem(string id) : base(id)
        {

        }

        public GunterInfoItem(string name, IGunterProcessor processor) : base(name, processor)
        {

        }

    }

}
