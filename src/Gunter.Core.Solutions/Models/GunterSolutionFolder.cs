using Gunter.Core.Constants;
using Gunter.Core.Contracts;

namespace Gunter.Core.Solutions.Models
{
    public class GunterSolutionFolder : IGunterComponent
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "New Folder";
        public string ParentFolderId { get; set; } = string.Empty;
        public string ClassId => IdentificationConstants.CLASSID.GunterSolutionFolder;

        public GunterSolutionFolder()
        {

        }

        public GunterSolutionFolder(string parentFolderId)
        {
            ParentFolderId = parentFolderId;
        }

        public GunterSolutionFolder(string id, string name, string parentFolderId)
        {
            Id = id;
            Name = name;
            ParentFolderId = parentFolderId;
        }
    }
}
