namespace Gunter.Core.Contracts
{
    public interface IGunterProcessor : IGunterComponent
    {
        List<IGunterInfoItem> InfoItems { get; set; }

        string GetLogAndClear();
        IGunterInfoItem CreateInfoItem(string name);
        IGunterInfoItem AddInfoItem(string id, IGunterInfoItem persona);
        IGunterInfoItem RemoveInfoItem(string id);
        IGunterInfoItem GetInfoItem(string Id);
        IEnumerable<string> GetIds();
        IEnumerable<IGunterInfoItem> GetInfoItems();
        void InfoItemUpdated(IGunterInfoItem item);
    }
}
