namespace Gunter.Core.Contracts
{
    public interface IGunterProcessor
    {

        public Guid Id { get; }

        public string Name { get; set; }

        IGunterInfoItem CreateInfoItem(string name);

        void AddInfoItem(IGunterInfoItem persona);

        void AddInfoItem(string id, IGunterInfoItem persona);

        IGunterInfoItem RemoveInfoItem(string id);

        IEnumerable<KeyValuePair<string, IGunterInfoItem>> GetInfoItems();
        IGunterInfoItem GetInfoItem(string Id);
        IEnumerable<string> GetIds();

        void InfoItemUpdated(IGunterInfoItem item);

    }
}
