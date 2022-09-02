using Gunter.Core.Contracts.Chaining;

namespace Gunter.Core.Components.BaseComponents.Chaining
{
    public class ChainLinkInfo : IChainLinkInfo
    {
        public string ComponentId { get; set; } = string.Empty;
        public string LinkDestinationId { get; set; } = string.Empty;
        public string LinkOriginId { get; set; } = string.Empty;

        public void SetParent(IChainLinkInfo? parent)
        {
            LinkOriginId = parent?.ComponentId ?? string.Empty;
        }

        public void SetChild(IChainLinkInfo? child)
        {
            LinkDestinationId = child?.ComponentId ?? string.Empty;
        }

        public int CompareTo(object? obj)
        {
            int retVal;
            if (obj is not IChainLinkInfo destination)
                return 0;

            if (LinkDestinationId.ToLower() == destination.ComponentId.ToLower() ||
                string.IsNullOrWhiteSpace(LinkOriginId))
            {
                retVal = -1; // previous
            }
            else if (ComponentId.ToLower() == destination.LinkDestinationId.ToLower() ||
                string.IsNullOrWhiteSpace(LinkDestinationId))
            {
                retVal = 1; // next
            }
            else
            {
                retVal = 0; // previous
            }

            return retVal;
        }
    }
}
