using Gunter.Core.Constants;
using Gunter.Core.Contracts;
using System.Text.Json.Serialization;

namespace Gunter.Core
{
    public partial class GunterInfoItem : IGunterInfoItem
    {
        public object lockObject = new();

        public string ClassId { get => IdentificationConstants.CLASSID.GunterInfoItem; }

        public string Id { get; private set; }

        public string Name { get; set; }

        public bool UpdateOnComponentChange { get; set; } = true;
        public IEnumerable<object> events { get; set; }
        public IEnumerable<object> Events { get => events; }

        [JsonIgnore]
        public List<IGunterInfoSource> InfoSources { get; } = new();

        private readonly IGunterProcessor _processor;

        public IGunterProcessor GetProcessor() => _processor;

        private readonly List<byte[]> _visualizations;
        public IList<byte[]> Visualizations { get => _visualizations; }

        [JsonIgnore]
        public List<IGunterVisualizationHandler> VisualizationHandlers { get; } = new();

        private DateTime _lastUpdate = DateTime.Now;
        public DateTime LastUpdate { get => _lastUpdate; }

        public GunterInfoItem()
        {

        }

        public GunterInfoItem(string id)
        {
            Id = id;
            events = new List<object>();
            VisualizationHandlers = new();
        }

        public GunterInfoItem(string name, IGunterProcessor processor)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            events = new List<object>();
            _processor = processor;
            VisualizationHandlers = new();
        }

        public void AddInfoSource(IGunterInfoSource source)
        {
            InfoSources.Add(source);
        }

        public void UpdateSources()
        {
            var tasks = InfoSources
                .Select(i => Task.Factory.StartNew(() => i.GetData()))
                .ToArray();

            Task.WaitAll(tasks);

            foreach (var source in InfoSources.AsParallel())
            {
                source.Update();
            }

            _lastUpdate = DateTime.Now;

            //OnUpdateHandler();
        }

        public void AddVisualizationHandler(IGunterVisualizationHandler handler)
        {
            VisualizationHandlers.Add(handler);
            VisualizationHandlerUpdated(handler);
        }

        public void Update()
        {
            UpdateSources();
            OnUpdateHandler();
        }

        public void InfoSourceUpdated(IGunterInfoSource source)
        {

        }

        public void VisualizationHandlerUpdated(IGunterVisualizationHandler handler)
        {
            if (!UpdateOnComponentChange || !VisualizationHandlers.Contains(handler)) // Not removed
                return;

            _visualizations.Add(handler.GetImage());
        }

        private void OnUpdateHandler()
            => _processor?.InfoItemUpdated(this);
    }
}
