using Gunter.Core.Contracts;
using Gunter.Infrastructure;
using Gunter.Infrastructure.Cache;
using System.Collections.Concurrent;

namespace Gunter.Core
{
    public class GunterProcessor : IGunterProcessor
    {
        private readonly Guid _id;
        private readonly ConcurrentDictionary<string, IGunterInfoItem> _targets;

        public Guid Id { get => _id; }

        public string Name { get; set; } = string.Empty;

        public GunterProcessor()
        {
            _id = Guid.NewGuid();
            _targets = new ConcurrentDictionary<string, IGunterInfoItem>();
        }

        public GunterProcessor(Guid id, string name)
        {
            _id = id;
            _targets = new ConcurrentDictionary<string, IGunterInfoItem>();
            Name = name;
        }

        public IGunterInfoItem CreateInfoItem(string name)
        => new Target(name, this);

        public void AddInfoItem(IGunterInfoItem persona)
            => AddInfoItem(Guid.NewGuid().ToString(), persona: persona);

        public void AddInfoItem(string id, IGunterInfoItem persona)
        {
            if (!_targets.TryAdd(id, value: persona))
            {
                throw new GunterCoreException($"Cannot add persona with id {id}");
            }
        }

        public IGunterInfoItem RemoveInfoItem(string id)
        {
            if (!_targets.TryRemove(id, out var persona))
                    throw new GunterCoreException($"Cannot remove persona with id {id}");

            return persona;
        }
        public IEnumerable<KeyValuePair<string, IGunterInfoItem>> GetInfoItems()
        {
            foreach (var persona in _targets)
                yield return persona;
        }
        public IEnumerable<IGunterInfoItem> GetInfoITems(string targetId)
        {
            foreach (var persona in _targets.Where(x => x.Key == targetId))
                yield return persona.Value;
        }
        public IEnumerable<string> GetIds()
        {
            foreach (var persona in _targets)
                yield return persona.Key;
        }
        public IGunterInfoItem GetInfoItem(string Id)
        => _targets[Id];

        public void InfoItemUpdated(IGunterInfoItem item)
        {
            
        }

        public void ReceiveInfoItemMessage(IGunterInfoItem item, string message)
        {
            
        }

        public void SendInfoItemMessage(IGunterInfoItem item, string message)
        {

        }
    }
}