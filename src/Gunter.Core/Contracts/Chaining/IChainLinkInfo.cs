namespace Gunter.Core.Contracts.Chaining
{
    public interface IChainLinkInfo : IComparable
    {
        string ComponentId { get; }
        string LinkOriginId { get; set; }
        string LinkDestinationId { get; set; }


        void SetParent(IChainLinkInfo parent);
        void SetChild(IChainLinkInfo child);

    }
}
