namespace Gunter.Core.Contracts
{
    public interface IGunterComponent
    {
        string ClassId { get; }
        string Id { get; }
        string Name { get; set; }
    }
}
