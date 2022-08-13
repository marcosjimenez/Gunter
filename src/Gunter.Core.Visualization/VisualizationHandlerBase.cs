using Gunter.Core.Constants;
using Gunter.Core.Contracts;

namespace Gunter.Core.Visualizations
{
    public abstract class VisualizationHandlerBase<T>
    {
        public string ClassId { get => IdentificationConstants.CLASSID.GunterVisualizationHandler; }
        public string Id { get; protected set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Visualizador";

        public virtual List<string> AvailableVisualizationTypes { get; protected set; } = new() { VisualizationConstants.DisplayStyleString };

        public bool CanHandle(IGunterInfoSource infoSource)
         => typeof(T).Equals(infoSource.GetType());

    }
}
