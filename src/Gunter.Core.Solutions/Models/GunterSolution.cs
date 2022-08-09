using Gunter.Core.Constants;
using Gunter.Core.Contracts;

namespace Gunter.Core.Solutions.Models
{
    public class GunterSolution : IGunterComponent
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; } = "New Solution";

        public string ClassId => IdentificationConstants.CLASSID.GunterSolution;

        public string FileName { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;

        public IList<GunterSolutionFolder> Folders { get; set; }
        public virtual IList<GunterProject> Projects { get; set; }


        public GunterSolution()
        {
            Folders = new List<GunterSolutionFolder>();
            Projects = new List<GunterProject>();
        }

        public GunterProject AddProject(GunterProject project)
        {
            Projects.Add(project);
            return project;
        }

        public void RemoveProject(GunterProject project)
            => Projects.Remove(project);

        public GunterProject? GetProject(string id)
            => Projects.Where(x => x.Id == id).FirstOrDefault();

        public void AddFolder(GunterSolutionFolder folder)
            => Folders.Add(folder);
        public GunterSolutionFolder AddFolder(string name)
        {
            var retVal = new GunterSolutionFolder();
            retVal.Name = name;

            return retVal;
        }
    }
}