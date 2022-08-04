using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Models.Solutions
{
    public class GunterSolutionFolder
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "New Folder";

        public GunterSolutionFolder(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
