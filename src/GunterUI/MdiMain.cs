using Controls;
using Dialogs;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Log;
using Gunter.Core.Solutions;
using Gunter.Core.Solutions.Models;
using Gunter.UI;
using GunterUI.Extensions;
using Krypton.Docking;
using Krypton.Navigator;
using Krypton.Workspace;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace GunterUI
{
    public partial class MdiMain : Form
    {
        private GunterSolution? currentSolution;

        private SolutionTreeView? solutionTreeview;
        private LogViewer? mainLogText;

        private KryptonDockableNavigator? kryptonDockableNavigator = new();

        private const string OptionsFile = "Gunter.WinUI..json";
        private Models.GunterWinUIOptions options = new();

        public MdiMain()
        {
            InitializeComponent();
            WindowManager.Instance.MainForm = this;
        }

        public void ShowOptions()
        {
            using var dlg = new OptionsDialog();
            dlg.Options = options;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                options = dlg.Options;
                SaveOptions();
            }
        }

        public void ShowLogText(GunterLogItem logItem, object component)
        {
            if (mainLogText is null)
                return;

            mainLogText.AppendText($"{DateTime.Now.ToString("HH:MM:ss:tt")} [{component.ToString() ?? string.Empty}]: {logItem.Message}");
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
                try
                {
                    currentSolution = GunterSolutionHelper.Instance.OpenSolution(dlg.FileName);
                    solutionTreeview.LoadSolution(currentSolution);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading {dlg.FileName}", ex.Message);
                }
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
            var documentWorkSpace = kryptonDockingManager.AddToWorkspace("Workspace", new KryptonPage[] { page });
            cell = kryptonDockingManager.DockingCellForPage(uniqueId);
            cell.SelectedPage = page;
        }

        public void ShowDocument(string uniqueId, GunterSolutionItemType itemType, IGunterComponent component)
        {
            var page = kryptonDockingManager.PagesWorkspace.FirstOrDefault(x => x.UniqueName == uniqueId);
            if (page is not null)
            {
                var cell = kryptonDockingManager.DockingCellForPage(uniqueId);
                if (cell is null)
                    page.Show();
                else
                    cell.SelectedPage = page;

                return;
            }

            Control? control = null;
            var id = string.Empty;
            var name = string.Empty;
            switch (itemType)
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

            GunterLog.Instance.OnLog += (sender, e) =>
            {
                ShowLogText(e.GunterLogItem, sender);
            };

            if (!options.MainLayoutAutoPersist)
                return;

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

        private void LoadOptions()
        {
            var file= Path.Combine(Directory.GetCurrentDirectory(), Constants.GeneralConfigFile);
            if (File.Exists(file))
            { 
                var json = File.ReadAllText(file);
                try
                {
                    var persistedOptions = JsonConvert.DeserializeObject<Models.GunterWinUIOptions>(json);
                    if (persistedOptions is not null)
                        options = persistedOptions;
                }
                catch(Exception ex)
                {
                    GunterLog.Instance.Log(this, $"Cannot load options from {file}, reason: {ex.Message}");
                }
            }
            else
            {
                SaveOptions();
            }

            if (options.MainLayoutAutoPersist)
            {
                if (!options.MainWindow.MainWindowLocation.Equals(Point.Empty))
                {
                    this.Location = options.MainWindow.MainWindowLocation;
                    this.Size = options.MainWindow.MainWindowSize;
                }
            }

        }

        private void SaveOptions()
        {
            if (options.MainLayoutAutoPersist)
            {
                options.MainWindow.MainWindowLocation = this.Location;
                options.MainWindow.MainWindowSize = this.Size;
                kryptonDockingManager.SaveConfigToFile(Path.Combine(Directory.GetCurrentDirectory(), Constants.DockingConfigurationFile));
            }
            var file = Path.Combine(Directory.GetCurrentDirectory(), Constants.GeneralConfigFile);
            var json = JsonConvert.SerializeObject(options);
            File.WriteAllText(file, json);
        }

        // Events

        private void MdiMain_Load(object sender, EventArgs e)
        {
            LoadOptions();
            ConfigureDocks();
            NewSolution();
        }

        private void MdiMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveOptions();
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

        private void cerrarActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kryptonDockableNavigator.PerformCloseAction(kryptonDockableNavigator.SelectedPage);
        }

        private void acercadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dlg = new AboutBox();
            dlg.ShowDialog();
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowOptions();
        }
    }
}
