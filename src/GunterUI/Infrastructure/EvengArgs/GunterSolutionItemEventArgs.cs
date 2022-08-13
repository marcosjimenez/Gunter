using Gunter.Core.Contracts;
using Gunter.Core.Solutions;

namespace Infrastructure.EvengArgs
{
    public class GunterSolutionItemEventArgs : EventArgs
    {
        public string Id { get; set; } = string.Empty;
        public GunterSolutionItemType SolutionItemType { get; set; } = GunterSolutionItemType.OtherItem;

        public IGunterComponent Component { get; set; }
    }
}
