using System.Text.Json.Serialization;

namespace Gunter.Core.Solutions.Models.SavedComponent
{
    public class GunterSavedSolution : GunterSolution
    {
        public List<GunterSavedProject> SavedProjects { get; set; } = new();

        [JsonIgnore]
        public override IList<GunterProject> Projects { get => base.Projects; set => base.Projects = value; }
    }
}
