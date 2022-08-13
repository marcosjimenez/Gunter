namespace Gunter.Core.Contracts
{
    public interface IGunterInfoItem : IGunterComponent
    {
        DateTime LastUpdate { get; }

        bool UpdateOnComponentChange { get; set; }

        IEnumerable<object> Events { get; }

        List<IGunterInfoSource> InfoSources { get; }

        List<IGunterVisualizationHandler> VisualizationHandlers { get; }

        void Update();

        IGunterProcessor GetProcessor();
    }
}
