using Gunter.Core.Contracts;
using Gunter.Core.Contracts.Chaining;

namespace Gunter.Core.Components.BaseComponents.Chaining
{
    public class GunterInfoSourceChainBase : IChain<IGunterInfoSource>
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = string.Empty;
        
        private List<IChainLinkInfo> _links = new List<IChainLinkInfo>();
        public IEnumerable<IChainLinkInfo> Links 
        { 
            get => SortLinks(_links); 
            set 
            {
                if (value is null)
                    return;

                _links.Clear();
                _links.AddRange(value);
            }
        }

        public IChainLinkInfo AddLink(string linkName, IGunterInfoSource source, IChainLinkInfo parent, IChainLinkInfo child)
        {
            if (parent is not null && child is not null &&
                parent == child)
                throw new Exception("Child and parent cannot be the same component.");

            return AddLink(linkName, source, parent?.ComponentId ?? string.Empty, child?.ComponentId ?? string.Empty);
        }

        public IChainLinkInfo AddLink(string linkName, IGunterInfoSource source, string parentId, string childId)
        {
            var newLink = new ChainLinkInfo
            {
                ComponentId = source.Id ?? string.Empty,
                LinkDestinationId = childId,
                LinkOriginId = parentId
            };
            _links.Add(newLink);

            return newLink;

        }

        private List<IChainLinkInfo> SortLinks(IList<IChainLinkInfo> unsortedList)
        {
            var myList = new List<IChainLinkInfo>(unsortedList);
            myList.Sort(
                delegate (IChainLinkInfo firstPair,
                 IChainLinkInfo nextPair)
                {
                    return firstPair.CompareTo(nextPair);
                }
            );
            return myList;
        }
    }
}
