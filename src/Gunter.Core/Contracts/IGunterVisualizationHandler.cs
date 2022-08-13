namespace Gunter.Core.Contracts
{
    public interface IGunterVisualizationHandler : IGunterComponent
    {
        List<string> AvailableVisualizationTypes { get; }

        bool CanHandle(IGunterInfoSource infoSource);

        byte[] GetImage();

        string GetHTML();
    }
}
