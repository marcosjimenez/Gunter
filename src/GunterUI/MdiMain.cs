using Gunter.Core.Solutions;
using Gunter.Core.Solutions.Models;
using GunterUI.Extensions;
using Krypton.Docking;
using Krypton.Navigator;
using Controls;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Log;
using Gunter.UI;
using Krypton.Workspace;

namespace GunterUI
{
    public partial class MdiMain : Form
    {
        private GunterSolution currentSolution;
        private GunterProject currentProject;

        private SolutionTreeView solutionTreeview;
        private LogViewer mainLogText;

        private KryptonDockableNavigator kryptonDockableNavigator = new();

        public MdiMain()
        {
            InitializeComponent();
            WindowManager.Instance.MainForm = this;
        }

        public void ShowLogText(GunterLogItem logItem, IGunterComponent component)
        {
            if (mainLogText is null)
                return;

            mainLogText.AppendText($"{DateTime.Now.ToString("HH:MM:ss:tt")} [{component?.Name ?? string.Empty}]: {logItem.Message}");
            mainLogText.AppendText(Environment.NewLine);
        }

        private void NewSolution()
        {
            currentSolution = GunterSolutionHelper.Instance.NewSolution();
            solutionTreeview.LoadSolution(currentSolution);
            solutionTreeview.Reload();
        }

        private void OpenSolution()
        {
            using var dlg = new OpenFileDialog
            {
                InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString(),
                Filter = "Gunter Solution (*.gsl)|*.gsl"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                currentSolution = GunterSolutionHelper.Instance.OpenSolution(dlg.FileName);
                solutionTreeview.LoadSolution(currentSolution);
            }
        }

        private void SaveSolution()
        {
            if (string.IsNullOrWhiteSpace(currentSolution.FileName))
            {
                using var dlg = new SaveFileDialog
                {
                    InitialDirectory = Environment.SpecialFolder.MyComputer.ToString(),
                    Filter = "Gunter Solution (*.gsl)|*.gsl",
                    CheckPathExists = true
                };

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;

                currentSolution.FileName = Path.GetFileName(dlg.FileName);
                currentSolution.FilePath = Path.GetFullPath(dlg.FileName);
                        
            }
            GunterSolutionHelper.Instance.SaveSolutionAs(currentSolution, currentSolution.FilePath);
        }

        private KryptonDockingWorkspace documentWorkSpace;
        private void ShowDocument(Control control, string uniqueId, string title)
        {
            KryptonWorkspaceCell cell;
            if (kryptonDockingManager.PagesWorkspace.Any(x => x.UniqueName == uniqueId))
            {
                var pageWorkSpace = kryptonDockingManager.PagesWorkspace.FirstOrDefault(x => x.UniqueName == uniqueId);
                cell = kryptonDockingManager.DockingCellForPage(uniqueId);
                cell.SelectedPage = pageWorkSpace;
                return;
            }

            var page = NewDocument(control, title);
            page.UniqueName = uniqueId;
            documentWorkSpace = kryptonDockingManager.AddToWorkspace("Workspace", new KryptonPage[] { page });
            cell = kryptonDockingManager.DockingCellForPage(uniqueId);
            cell.SelectedPage = page;
        }

        public void ShowDocument(string uniqueId, GunterSolutionItemType itemType, IGunterComponent component)
        {
            var page = kryptonDockingManager.PagesWorkspace.FirstOrDefault(x => x.UniqueName == uniqueId);
            if (page is not null)
            {
                var cell = kryptonDockingManager.DockingCellForPage(uniqueId);
                cell.SelectedPage = page;
                return;
            }

            Control control = null;
            var id = string.Empty;
            var name = string.Empty;
            switch(itemType)
            {
                case GunterSolutionItemType.Processor:
                    var processorViewer = new ProcessorViewer((IGunterProcessor)component);
                    processorViewer.OnGunterItemShow += (sender, e) =>
                    {
                        var component = new InfoItemViewer((IGunterInfoItem)e.Component);

                        component.OnGunterInfoSourceShow += (sender, e) =>
                        {
                            var component = new InfoSourceViewer((IGunterInfoSource)e.Component);
                            ShowDocument(component, e.Id, e.Component.Name);
                        };

                        component.OnGunterVisualizationHandlerShow += (sender, e) =>
                        {
                            var webViewer = string.IsNullOrWhiteSpace(e.HTML) ? new WebViewer(e.Uri) : new WebViewer(e.HTML);
                            ShowDocument(webViewer, e.Id, e.Name);
                        };
                        ShowDocument(component, e.Id, e.Component.Name);
                    };
                    id = component.Id;
                    name = component.Name;
                    control = processorViewer;
                    processorViewer.LoadListView();
                    break;
            }

            if (control is not null)
                ShowDocument(control, id, name);

        }

        private void ConfigureDocks()
        {
            // Setup docking functionality
            KryptonDockingWorkspace w = kryptonDockingManager.ManageWorkspace(kryptonDockableWorkspace);
            kryptonDockingManager.ManageControl(kryptonPanel, w);
            kryptonDockingManager.ManageFloating(this);
            kryptonDockingManager.ManageNavigator(kryptonDockableNavigator);

            // Add docking pages
            var leftDock = kryptonDockingManager.AddDockspace("Control", DockingEdge.Right, new KryptonPage[] { CreateSolutionTreeView() });
            kryptonDockingManager.AddAutoHiddenGroup("Control", DockingEdge.Right, new KryptonPage[] { NewPropertyGrid() });
            kryptonDockingManager.AddDockspace("Control", DockingEdge.Bottom, new KryptonPage[] { CreateMainLog(), CreateConsoleView() }); ;

            GunterLog.Instance.OnLog += (sender, e) => {
                ShowLogText(e.GunterLogItem, sender as IGunterComponent);
            };
            var file = Path.Combine(Directory.GetCurrentDirectory(), Constants.DockingConfigurationFile);
            if (File.Exists(file))
                kryptonDockingManager.LoadConfigFromFile(file);
        }

        private KryptonPage CreateSolutionTreeView()
        {
            solutionTreeview = new SolutionTreeView();
            solutionTreeview.OnGunterItemAdded += (sender, e) =>
            {
                ShowDocument(e.Id, e.SolutionItemType, e.Component);
            };
            solutionTreeview.OnGunterItemRemoved += (sender, e) =>
            {
                GunterLog.Instance.Log(sender, $"Removed {e.SolutionItemType.ToString()} with Id {e.Id}", GunterLogItem.GunterLogItemSeverity.Warning);
            };
            solutionTreeview.OnGunterItemShow += (sender, e) =>
            {
                ShowDocument(e.Id, e.SolutionItemType, e.Component);
            };

            KryptonPage page = NewPage("Solution Explorer", 0, solutionTreeview);
            page.TextTitle = "Solution Explorer";
            return page;
        }

        private KryptonPage NewDocument(Control control, string name)
        {
            KryptonPage page = NewPage(name, 0, control);

            // Document pages cannot be docked or auto hidden
            page.ClearFlags(KryptonPageFlags.DockingAllowAutoHidden | KryptonPageFlags.DockingAllowDocked);

            return page;
        }

        private KryptonPage CreateConsoleView()
        {
            return NewPage("Console", 1, new ConsoleViewer());
        }

        private KryptonPage CreateMainLog()
        {
            mainLogText = new LogViewer();
            mainLogText.AppendText($"Log initialized. at {DateTime.Now}{Environment.NewLine}");
            return NewPage("System Log", 1, mainLogText);
        }
       
        private KryptonPage NewPropertyGrid()
        {
            return NewPage("Properties ", 2, new PropertyGrid());
        }

        private KryptonPage NewPage(string name, int image, Control content)
        {
            // Create new page with title and image
            KryptonPage p = new KryptonPage();
            p.Text = name;
            p.TextTitle = name;
            p.TextDescription = name;
            p.UniqueName = p.Text;
            //p.ImageSmall = imageListSmall.Images[image];

            // Add the control for display inside the page
            content.Dock = DockStyle.Fill;
            p.Controls.Add(content);
            content.Refresh();

            return p;
        }

        // Events

        private void MdiMain_Load(object sender, EventArgs e)
        {
            ConfigureDocks();
            NewSolution();
        }

        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            NewSolution();
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            OpenSolution();
        }

        private void guardarToolStripButton_Click(object sender, EventArgs e)
        {
            SaveSolution();
        }

        private void MdiMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            kryptonDockingManager.SaveConfigToFile(Path.Combine(Directory.GetCurrentDirectory(), Constants.DockingConfigurationFile));
        }

        private void cerrarActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kryptonDockableNavigator.PerformCloseAction(kryptonDockableNavigator.SelectedPage);
        }
    }
}
