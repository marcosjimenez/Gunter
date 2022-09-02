using Gunter.Core.Constants;
using Gunter.Core.Contracts;
using Gunter.Core.Contracts.Chaining;
using Gunter.Core.Infrastructure.Log;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Concurrent;
using System.Threading.Tasks;

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

        public async Task<bool> ExecuteChain(CancellationToken token, IList<IGunterInfoSource> infoSources, Action<string, string> onItemUpdated)
        {

            GunterLog.Instance.Log(this, $"Executing chain {this.Name} [{this.Id}].");

            var retVal = true;

            var tasks = new List<Task>();
            var infoSourceList = new ConcurrentBag<IGunterInfoSource>(infoSources);

            onItemUpdated?.Invoke(string.Empty, ChainConstants.LinkStatus.Started);

            foreach(var item in _links.Where(x => string.IsNullOrWhiteSpace(x.LinkOriginId)))
            {
                tasks.Add(executeChainLink(item, infoSourceList, token, onItemUpdated));
            }

            await Task.WhenAll(tasks.ToArray());

            onItemUpdated?.Invoke(string.Empty, ChainConstants.LinkStatus.Completed);

            GunterLog.Instance.Log(this, $"Completed chain execution {this.Name} [{this.Id}].");

            return retVal;
        }

        private Task<bool> executeChainLink(
            IChainLinkInfo chainLink, 
            ConcurrentBag<IGunterInfoSource> infoSources, 
            CancellationToken token,
            Action<string, string> onItemUpdated)
        {
            var retVal = false;

            onItemUpdated?.Invoke(chainLink.ComponentId, ChainConstants.LinkStatus.Started);
            // Execute and get result
            var currentDs = infoSources.FirstOrDefault(x => x.Id.Equals(chainLink.ComponentId));
            retVal = (currentDs is not null);

            if (retVal)
            {
                currentDs.Update();
                var currentDsLasItem = currentDs.GetLastItem();
                if (currentDsLasItem is not null)
                {
                    var json = JsonConvert.SerializeObject(currentDsLasItem);
                    currentDs.SpecialProperties.AddOrUpdate("ChainInput", json);

                    // Send result to childs
                    foreach (var item in _links.Where(x => x.LinkOriginId.Equals(chainLink.ComponentId)))
                    {
                        var targetDs = infoSources.FirstOrDefault(x => x.Id.Equals(chainLink.ComponentId));
                        targetDs.SpecialProperties.AddOrUpdate("ChainInput", json);
                        if (currentDs is not null)
                        {
                            executeChainLink(item, infoSources, token, onItemUpdated);
                        }
                    }
                }
            }

            onItemUpdated?.Invoke(chainLink.ComponentId, ChainConstants.LinkStatus.Completed);
            return Task.FromResult(retVal);
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
