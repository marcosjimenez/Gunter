namespace Gunter.Core.Solutions.Models
{
    public class GunterSolutionFolder
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "New Folder";
        public string ParentFolderId { get; set; } = string.Empty;

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
