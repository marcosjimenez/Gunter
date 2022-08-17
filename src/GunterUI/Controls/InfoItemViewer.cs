using Contracts;
using Dialogs;
using Gunter.Core.Contracts;
using Gunter.Core.Contracts.Chaining;
using Gunter.Core.Infrastructure.Helpers;
using GunterUI.Dialogs;
using System.Data;

namespace Controls
{
    public partial class InfoItemViewer : UserControl
    {
        public IGunterInfoItem InfoItem { get; set; }

        public event Delegates.GunterItemShowDelegate OnGunterInfoSourceShow;
        public event Delegates.WebViewControlDelegate OnGunterVisualizationHandlerShow;

        private IGunterInfoSource? selectedInfoSource;

        private System.Windows.Forms.Timer timer = new();

        private int timerCounter = 0;
        private int MaxTimerCounter = 30;

        private DateTimeOffset nextUpdate;

        public InfoItemViewer()
        {
            InitializeComponent();
        }

        public InfoItemViewer(IGunterInfoItem target)
        {
            InfoItem = target;
            InitializeComponent();

            UpdateData();
            CalculateNextUpdate();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer.Enabled = chkActualizar.Checked;
            greenLed.Image = imlBalls.Images["BlueBall"];
        }

        public void UpdateData()
        {
            txtNombre.Text = InfoItem.Name;
            txtId.Text = InfoItem.Id.ToString();
            LoadSources();
            //LoadVisualizations();
        }

        private ListViewItem CreateSourceListViewItem(string key, string value, string imageKey, ListViewGroup group, params string[] subitems)
        {
            var item = lvSources.Items.Add(key, value, imageKey);
            item.Group = group;
            foreach (var subitem in subitems)
                item.SubItems.Add(subitem);

            return item;
        }

        private ListViewItem CreateVisualizationListViewItem(string key, string value, string imageKey = "", ListViewGroup? group = null, params string[] subitems)
        {
            var item = lvVisualizations.Items.Add(key, value, imageKey);
            item.Group = group;
            foreach (var subitem in subitems)
                item.SubItems.Add(subitem);

            return item;
        }

        private void ReLoadChain()
        {
            tvChain.BeginUpdate();
            var startNode = tvChain.Nodes[0];
            var currentNode = tvChain.Nodes[0];

            startNode.Nodes.Clear();
            foreach(var item in InfoItem.Chain.Links)
            {
                currentNode = string.IsNullOrEmpty(item.LinkOriginId) 
                    ? startNode 
                    : SearchNode(item.LinkOriginId, startNode);

                var ds = InfoItem.InfoSources.FirstOrDefault(x => x.Id == item.ComponentId);
                if (ds is not null)
                {
                    currentNode.Nodes.Add(ds.Id, ds.Name, "SilverBall", "BlueBall");
                    currentNode.Expand();
                }
            }

            tvChain.EndUpdate();
        }

        private TreeNode SearchNode(string id, TreeNode parent)
        {
            TreeNode retVal = parent;
            if (!parent.Nodes.ContainsKey(id))
            {
                foreach (TreeNode node in parent.Nodes)
                {
                    retVal = SearchNode(id, node);
                    if (retVal.Name == id)
                        break;
                }
            }

            return retVal;
        }

        private void LoadSources()
        {
            lvSources.BeginUpdate();
            lvSources.Items.Clear();
            foreach (var item in InfoItem.InfoSources)
            {
                try
                {
                    AddAvailableChainLink(item);
                    CreateSourceListViewItem(item.Id, item.Name, "DataSource", null, item.Id);
                }
                catch { }
            }
            lvSources.EndUpdate();

            if (InfoItem.Chain.Links.Count() > 0)
                ReLoadChain();

        }

        private void AddAvailableChainLink(IGunterInfoSource infosource)
        {
            if (cmdAddChainLink.DropDownItems.ContainsKey(infosource.Id))
                return;

            var item = new ToolStripMenuItem(infosource.Name, imlBalls.Images["SilverBall"], (sender, e) => AddChainLink_Click(sender, e));
            item.Name = infosource.Id;
            cmdAddChainLink.DropDownItems.Add(item);
        }

        private void AddChainLink_Click(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            var id = menu?.Name ?? "";

            if (InfoItem.Chain.Links.Any(x => x.ComponentId == id))
                return;

            InfoItem.Chain.AddLink("New Link", InfoItem.InfoSources.First(x => x.Id == id), string.Empty, string.Empty);

            ReLoadChain();
        }

        private void LoadVisualizations()
        {
            lvVisualizations.BeginUpdate();
            lvVisualizations.Items.Clear();

            foreach (var item in InfoItem.VisualizationHandlers)
            {
                CreateVisualizationListViewItem(item.Id, item.Name);
            }

            lvSources.EndUpdate();
        }

        private void UpdateAll()
        {
            greenLed.Image = imlBalls.Images["OrangeBall"];
            //redLed.Visible = true;
            var enableTimer = timer.Enabled;
            timer.Enabled = false;
            InfoItem?.Update();
            lblUltimaActualizacion.Text = $"Updated {DateTime.Now}";
            UpdateData();
            CalculateNextUpdate();
            greenLed.Image = imlBalls.Images["GreenBall"];
            //redLed.Visible = false;
            timer.Enabled = enableTimer;
        }

        private void CalculateNextUpdate()
        {

            if (!chkActualizar.Checked)
            {
                lblSiguienteActualizacion.Text = "Nunca (Manual)";
                return;
            }

            var enableTimer = timer.Enabled;
            timer.Enabled = false;
            txtSegundos.Minimum = (txtDias.Value == 0 && txtHoras.Value == 0 && txtMinutos.Value == 0) ? 10 : 0;
            var nextTimeSpan = GetUITimeSpan();
            nextUpdate = InfoItem.LastUpdate.Add(nextTimeSpan);

            MaxTimerCounter = (int)nextTimeSpan.TotalSeconds;
            timerCounter = 0;

            lblSiguienteActualizacion.Text = $"Next {nextUpdate.ToString()}";
            timer.Enabled = enableTimer;
        }

        private TimeSpan GetUITimeSpan()
            => new TimeSpan((int)txtDias.Value, (int)txtHoras.Value, (int)txtMinutos.Value, (int)txtSegundos.Value);


        // Events
        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            UpdateAll();
        }

        private void chkActualizar_CheckedChanged(object sender, EventArgs e)
        {
            timer.Enabled = chkActualizar.Checked;
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            timerCounter++;
            timer.Enabled = false;
            if (timerCounter > MaxTimerCounter)
            {
                if (chkActualizar.Checked)
                    UpdateAll();
                timerCounter = 0;
            }
            lblUltimaActualizacion.Text = $"Updated {DateTimeManipulationHelper.GetRelativeDateTime(InfoItem.LastUpdate)}";
            timer.Enabled = true;
        }

        private void TargetToolBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Enabled = false;
        }
        private void txtTimeSpan_ValueChanged(object sender, EventArgs e)
        {
            CalculateNextUpdate();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            this.Text = txtNombre.Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InfoItem is null || lvSources.SelectedItems.Count == 0)
            {
                selectedInfoSource = null;
                return;
            }

            selectedInfoSource = InfoItem.InfoSources.Where(x => x.Id == lvSources.SelectedItems[0].Name).Single();
        }

        private void InfoItemViewer_Load(object sender, EventArgs e)
        {

        }

        private void cmdAddSource_Click(object sender, EventArgs e)
        {
            if (InfoItem is null)
                return;

            using var frm = new OrigenForm(InfoItem.GetProcessor());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var source = frm.GetSelectedSource(InfoItem);

                if (source is null)
                    return;

                InfoItem.InfoSources.Add(source);
                CreateSourceListViewItem(source.Id, source.Name, "", null);
            }
        }

        private void lvSources_DoubleClick(object sender, EventArgs e)
        {
            if (InfoItem is null || lvSources.SelectedItems.Count == 0)
                return;

            var source = InfoItem.InfoSources.SingleOrDefault(x => x.Id == lvSources.SelectedItems[0].Name);
            if (source is null)
                return;

            OnGunterInfoSourceShow?.Invoke(this, new Infrastructure.EvengArgs.GunterSolutionItemEventArgs
            {
                Id = source.Id,
                Component = source,
                SolutionItemType = Gunter.Core.Solutions.GunterSolutionItemType.InfoSource
            });


        }

        private void cmdAddVisualization_Click(object sender, EventArgs e)
        {
            if (selectedInfoSource is null)
                return;

            using var dlg = new VisualizationForm();
            dlg.Destination = selectedInfoSource;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var visualization = dlg.Visualization;
                InfoItem.VisualizationHandlers.Add(visualization);
                CreateVisualizationListViewItem(visualization.Id, visualization.Name);
            }
        }

        private void cmdRefreshSources_Click(object sender, EventArgs e)
        {
            LoadSources();
            LoadVisualizations();
        }

        private void lvVisualizations_DoubleClick(object sender, EventArgs e)
        {
            if (lvVisualizations.SelectedItems.Count == 0)
                return;

            var item = lvVisualizations.SelectedItems[0];
            var visualization = InfoItem.VisualizationHandlers.Where(x => x.Id == item.Name).SingleOrDefault();
            if (visualization is not null)
                OnGunterVisualizationHandlerShow?.Invoke(this, new Infrastructure.EvengArgs.WebViewControlEventArgs
                {
                    Id = visualization.Id,
                    HTML = visualization.GetHTML(),
                    SolutionItemType = Gunter.Core.Solutions.GunterSolutionItemType.VisualizationHandler,
                    Name = visualization.Name
                });

        }

        private void tvChain_DragDrop(object sender, DragEventArgs e)
        {
            Point targetPoint = tvChain.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = tvChain.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node and that target node isn't null
            // (for example if you drag outside the control)
            if (!draggedNode.Equals(targetNode) && targetNode != null && !draggedNode.Parent.Equals(targetNode) && !targetNode.FullPath.Contains(draggedNode.Text))
            {
                draggedNode.Remove();
                targetNode.Nodes.Add(draggedNode);

                // Expand the node at the location 
                // to show the dropped node.
                targetNode.Expand();
            }
        }

        private void tvChain_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tvChain_ItemDrag(object sender, ItemDragEventArgs e)
        {
            var node = e.Item as TreeNode;

            if (node?.Parent is null)
                return;

            DoDragDrop(e.Item, DragDropEffects.Move);
        }
    }
}
