using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gunter.Core.Solutions.Models.SavedComponent
{
    public class GunterSavedSolution : GunterSolution
    {
        public List<GunterSavedProject> SavedProjects { get; set; } = new();

        [JsonIgnore]
        public override IList<GunterProject> Projects { get => base.Projects; set => base.Projects = value; }
    }
}
