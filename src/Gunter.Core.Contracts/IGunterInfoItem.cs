using System.ComponentModel;

namespace Gunter.Core.Contracts
{
    public interface IGunterInfoItem : IGunterComponent
    {
        string ClassId { get; }

        DateTime LastUpdate { get; }

        bool UpdateOnComponentChange { get; set; }

        [Browsable(false)]
        IEnumerable<object> Events { get; }

        List<IGunterInfoSource> InfoSources { get; }

        IList<byte[]> Visualizations { get; }

        List<IGunterVisualizationHandler> VisualizationHandlers { get; }

        void Update();

        void InfoSourceUpdated(IGunterInfoSource source);

        IGunterProcessor GetProcessor();

    }
}
