using Gunter.Core.Constants;
using Gunter.Core.Contracts;

namespace Gunter.Extensions.Visualization
{
    public abstract class VisualizationHandlerBase<T>
    {
        public string ClassId { get => IdentificationConstants.CLASSID.GunterVisualizationHandler; }
        public string Id { get; protected set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Visualizador";

        public bool CanHandle(IGunterInfoSource infoSource)
         => typeof(T).Equals(infoSource.GetType());

    }
}
