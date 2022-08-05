using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Models.Solutions
{
    public class GunterSolutionItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "New Item";

        public string FolderId { get; set; } = string.Empty;

        public GunterSolutionItem(string id, string name, string? folderId = null)
        {
            Id = id;
            Name = name;
            FolderId = folderId ?? string.Empty;
        }
    }
}
