using Gunter.Core.Components.BaseComponents.Chaining;
using Gunter.Core.Contracts;
using Gunter.Core.Contracts.Chaining;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Solutions.Models.SavedComponent
{
    public class GunterSavedChainLink
    {
        public string ComponentId { get; set; } = string.Empty;
        public string LinkOriginId { get; set; } = string.Empty;
        public string LinkDestinationId { get; set; } = string.Empty;

        public static GunterSavedChainLink FromChainLink(IChainLinkInfo chainLink)
        => new GunterSavedChainLink
            {
                ComponentId = chainLink.ComponentId,
                LinkOriginId = chainLink.LinkOriginId,
                LinkDestinationId = chainLink.LinkDestinationId
            };

        public static IChainLinkInfo FromSavedChainLink(GunterSavedChainLink chainLink)
        => new ChainLinkInfo
            {
                ComponentId = chainLink.ComponentId,
                LinkOriginId = chainLink.LinkOriginId,
                LinkDestinationId = chainLink.LinkDestinationId
            };
    }
}
