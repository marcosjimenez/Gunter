using Gunter.Core.Contracts;
using System.Diagnostics;
using System.Xml.Linq;

namespace Gunter.Core
{
    public partial class Target : IGunterInfoItem
    {
        public Guid Id { get; private set; }

        public string Name { get; set; }

        public bool UpdateOnComponentChange { get; set; } = true;

        public IEnumerable<object> Events { get; private set; }

        private List<IInfoSource> _sources;
        public IList<IInfoSource> Sources { get => _sources; }

        private readonly IGunterProcessor _processor;
        public IGunterProcessor Processor { get => _processor; }

        private readonly List<byte[]> _visualizations;
        public IList<byte[]> Visualizations { get => _visualizations; }

        private readonly List<IGunterVisualizationHandler> _visualizationHandlers;
        public IList<IGunterVisualizationHandler> VisualizationHandlers { get => _visualizationHandlers; }

        private DateTime _lastUpdate = DateTime.Now;
        public DateTime LastUpdate { get => _lastUpdate; }

        public Target()
        {
            Id = Guid.NewGuid();
            Name = Id.ToString();
            Events = new List<object>();
            _sources = new ();
            _visualizationHandlers = new();
        }

        public Target(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
            Events = new List<object>();
            _sources = new List<IInfoSource>();
            _visualizationHandlers = new();
        }

        public Target(string name, IGunterProcessor processor)
        {
            Id = Guid.NewGuid();
            Name = name;
            Events = new List<object>();
            _sources = new List<IInfoSource>();
            _processor = processor;
            _visualizationHandlers = new();
        }

        public void AddSource(IInfoSource source)
        {
            _sources.Add(source);
        }

        public void UpdateSources()
        {
            var tasks =  _sources
                .Select(i => Task.Factory.StartNew(() => i.GetData()))
                .ToArray();

            Task.WaitAll(tasks);

            foreach (var source in _sources.AsParallel())
            {
                source.Update();
            }

            _lastUpdate = DateTime.Now;

            //OnUpdateHandler();
        }

        public void AddVisualizationHandler(IGunterVisualizationHandler handler)
        {
            _visualizationHandlers.Add(handler);
            VisualizationHandlerUpdated(handler);
        }

        public void Update()
        {
            UpdateSources();
            OnUpdateHandler();
        }

        public void InfoSourceUpdated(IInfoSource source)
        {

        }

        public void VisualizationHandlerUpdated(IGunterVisualizationHandler handler)
        {
            if (!UpdateOnComponentChange || !_visualizationHandlers.Contains(handler)) // Not removed
                return;

            _visualizations.Add(handler.GetImage());
        }

        private void OnUpdateHandler()
            => _processor?.InfoItemUpdated(this);

    }
}
