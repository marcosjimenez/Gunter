using Gunter.Core.Contracts;
using Gunter.Extensions.InfoSources.Specialized;
using Gunter.Core.Visualizations;

namespace Gunter.Extensions.Plugins.ScriptExecution
{
    public class ScriptVisualizationHandler : VisualizationHandlerBase<ScriptInfoSource>, IGunterVisualizationHandler
    {
        public new string Name { get; set; } = "Visor de ScriptInfoSource";
        private ScriptInfoSource objectToDraw;

        public ScriptVisualizationHandler(string id)
        {
            Id = id;
            AvailableVisualizationTypes.Add(VisualizationConstants.DisplayStyleHTML);
        }

        public ScriptVisualizationHandler(ScriptInfoSource infoSource)
        {
            objectToDraw = infoSource;
            AvailableVisualizationTypes.Add(VisualizationConstants.DisplayStyleHTML);
        }

        public override string ToString()
            => objectToDraw?.GetLastItem().ToString() ?? string.Empty;

        public string GetHTML() => string.Empty;
        public byte[] GetImage() => Array.Empty<byte>();
    }
}
