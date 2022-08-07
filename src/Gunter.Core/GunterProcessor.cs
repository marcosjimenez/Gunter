using Gunter.Core.Constants;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Exceptions;
using Gunter.Core.Infrastructure.Log;
using System.Collections.Concurrent;
using System.Text;
using System.Text.Json.Serialization;

namespace Gunter.Core
{
    public class GunterProcessor : IGunterProcessor
    {
        public object lockObject = new();
        public StringBuilder logStringBuilder = new StringBuilder();

        public string ClassId { get => IdentificationConstants.CLASSID.GunterProcessor; }

        private readonly ConcurrentDictionary<string, IGunterInfoItem> data;

        public string Id { get; private set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public List<IGunterInfoItem> InfoItems { get; set; } = new();

        public IEnumerable<IGunterInfoItem> GetInfoItems()
            => InfoItems;

        public GunterProcessor()
        {
            GunterLogHelper.Instance.Log(this, $"Created new Processor Id: {this.Id}");
            data = new ConcurrentDictionary<string, IGunterInfoItem>();
        }

        public GunterProcessor(string id)
        {
            Id = id;
            data = new ConcurrentDictionary<string, IGunterInfoItem>();
        }

        public GunterProcessor(string id, string name)
        {
            Id = id;
            data = new ConcurrentDictionary<string, IGunterInfoItem>();
            Name = name;
        }

        ~GunterProcessor()
        {
            GunterLogHelper.Instance.Log(this, $"Unloading {this.Name} with Id {this.Id}");
        }

        public string GetLogAndClear()
        {
            var text = logStringBuilder.ToString();
            logStringBuilder.Clear();
            return text;
        }

        private void LogMessage(string message, Models.GunterLogItem.GunterLogItemSeverity severity = Models.GunterLogItem.GunterLogItemSeverity.Information)
        {
            GunterLogHelper.Instance.Log(this, message, severity);
            logStringBuilder.AppendLine(message);
        }

        public IGunterInfoItem CreateInfoItem(string name)
        => AddInfoItem(Guid.NewGuid().ToString(), new GunterInfoItem(name, this));

        public IGunterInfoItem AddInfoItem(string id, IGunterInfoItem infoItem)
        {
            GunterLogHelper.Instance.Log(this, $"Trying to add InfoItem with Id: {id}");
            InfoItems.Add(infoItem);
            return infoItem;
        }

        public IGunterInfoItem RemoveInfoItem(string id)
        {
            GunterLogHelper.Instance.Log(this, $"Trying to remove InfoItem with Id: {id}");
            lock (lockObject)
            {
                if (!data.TryRemove(id, out var infoItem))
                    throw new GunterCoreException($"Cannot remove InfoItem with id {id}");

                return infoItem;
            }
        }

        public IEnumerable<IGunterInfoItem> GetInfoItems(string targetId)
        {
            foreach (var infoItem in data.Where(x => x.Key == targetId))
                yield return infoItem.Value;
        }

        public IEnumerable<string> GetIds()
        {
            foreach (var infoItem in data)
                yield return infoItem.Key;
        }

        public IGunterInfoItem GetInfoItem(string id)
            => InfoItems.FirstOrDefault(x => x.Id == id);

        public void InfoItemUpdated(IGunterInfoItem item)
        {
            GunterLogHelper.Instance.Log(this, $"InfoItem with Id: { Id } updated");
        }
    }
}