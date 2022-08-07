using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Gunter.Core.Solutions.Models.SavedComponent
{
    public class GunterSavedProject : GunterProject
    {
        public List<GunterSavedProcessor> SavedProcessors { get; set; } = new ();

        [JsonIgnore]
        public override List<GunterProcessor> Processors { get => base.Processors; set => base.Processors = value; }
    }
}
