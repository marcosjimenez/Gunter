namespace Gunter.Core.Models.Solutions
{
    public class GunterSolution
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = "New Solution";

        public string FullPath { get; set; } = string.Empty;
        public List<GunterSolutionFolder> Folders { get; set; }
        public List<GunterSolutionItem> Items { get; set; }

        public GunterSolution(string id, string name)
        {
            Id = id;
            Name = name;
            Folders = new List<GunterSolutionFolder>();
            Items = new List<GunterSolutionItem>();
        }

        public GunterSolution(string id, string name, List<GunterSolutionFolder> folders, List<GunterSolutionItem> items)
        {
            Id = id;
            Name = name;
            Folders = folders;
            Items = items;
        }
    }
}