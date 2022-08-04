using System.ComponentModel;

namespace Gunter.Core.Contracts
{
    public interface IGunterInfoItem
    {
        Guid Id { get; }
        string Name { get; set; }

        DateTime LastUpdate { get; }

        bool UpdateOnComponentChange { get; set; }

        [Browsable(false)]
        IEnumerable<object> Events { get; }

        IList<IInfoSource> Sources { get; }

        IGunterProcessor Processor { get; }

        IList<byte[]> Visualizations { get; }

        IList<IGunterVisualizationHandler> VisualizationHandlers { get; }


        void Update();

        void InfoSourceUpdated(IInfoSource source);
    }
}
