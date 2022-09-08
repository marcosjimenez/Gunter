using Gunter.Core;
using Gunter.Core.Solutions;
using Gunter.Core.Solutions.Models;

namespace Gunter.UI.MAUI
{
    public partial class App : Application
    {

        public GunterSolution CurrentSolution { get; set; } = new();
        public GunterProject CurrentProject { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            var project = new GunterProject { Name = "New Project" };
            CurrentProject = project;
            CurrentSolution.Projects.Add(project);
        }
    }
}