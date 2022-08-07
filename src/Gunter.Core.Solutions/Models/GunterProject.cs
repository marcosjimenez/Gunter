using Gunter.Core.Contracts;

namespace Gunter.Core.Solutions.Models
{
    public class GunterProject
    {
        private readonly object lockObject;

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "New Project";
        public string FolderId { get; set; } = string.Empty;

        public virtual List<GunterProcessor> Processors { get; set; } = new ();

        public GunterProject()
        {
            lockObject = new();
        }

        public GunterProject(string id, string name, string folderId)
        {
            lockObject = new();
            Id = id;
            Name = name;
            FolderId = folderId;
        }

        public GunterProcessor AddProcessor(GunterProcessor processor)
        {
            Processors.Add(processor);
            return processor;
        }

        public void RemoveProcessor(string id)
        {
            var processor = Processors.FirstOrDefault(x => x.Id == id);
            if (processor != null)
            {
                var name = processor.Name;
                Processors.Remove(processor);
                processor = null;
                GC.Collect();
            }
        }
    }
}
