namespace Gunter.Core.Contracts.Chaining
{
    public interface IChain<T>
    {
        IEnumerable<IChainLinkInfo> Links { get; set; }

        IChainLinkInfo AddLink(string linkName, T source, IChainLinkInfo parent, IChainLinkInfo child);
        IChainLinkInfo AddLink(string linkName, T source, string parentId, string childId);

        Task<bool> ExecuteChain(CancellationToken token, IList<IGunterInfoSource> infoSources, Action<string, string> onItemUpdated);
    }
}
