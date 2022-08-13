using Gunter.Core.Components.BaseComponents;
using System.Text.Json.Serialization;

namespace Gunter.Core.Solutions.Models.SavedComponent
{
    public class GunterSavedProject : GunterProject
    {
        public List<GunterSavedProcessor> SavedProcessors { get; set; } = new();

        [JsonIgnore]
        public override List<GunterProcessorBase> Processors { get => base.Processors; set => base.Processors = value; }
    }
}
