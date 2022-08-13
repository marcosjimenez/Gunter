using Contracts;
using Dialogs;
using Gunter.Core.Components.BaseComponents;
using Gunter.Core.Contracts;
using Gunter.Core.Solutions;
using Gunter.Core.Solutions.Models;
using Infrastructure.EvengArgs;

namespace Controls
{
    public partial class SolutionTreeView : UserControl
    {

        private GunterSolution currentSolution = new GunterSolution();
        private TreeNode selectedNode = new TreeNode();

        public event Delegates.GunterItemAddedDelegate OnGunterItemAdded;

        public event Delegates.GunterItemRemovedDelegate OnGunterItemRemoved;

        public event Delegates.GunterItemShowDelegate OnGunterItemShow;

        //Counters
        private int processorCounter = 1;

        public SolutionTreeView()
        {
            InitializeComponent();
        }

        public void Reload()
        {
            if (currentSolution == null)
                return;

            var expanded = selectedNode?.IsExpanded ?? false;
            var selectedId = selectedNode?.Name;

            tv.BeginUpdate();
            tv.Nodes.Clear();
            var root = CreateTopLevelNode(currentSolution.Id, currentSolution.Name);

            foreach (var folder in currentSolution.Folders)
            {
                if (!string.IsNullOrWhiteSpace(folder.ParentFolderId) &&
                    root.Nodes.ContainsKey(folder.ParentFolderId))
                {
                    var parentNode = root.Nodes[folder.ParentFolderId];
                    var temp = CreateNode(GunterSolutionItemType.Folder, parentNode, folder.Id, folder.Name);
                }
                else
                    CreateNode(GunterSolutionItemType.Folder, null, folder.Id, folder.Name);
            }

            foreach (var project in currentSolution.Projects)
            {
                var node = CreateProjectNode(root, project);
                node.Parent.Expand();
            }
            root.Expand();

            //if (!string.IsNullOrWhiteSpace(selectedId))
            //{
            //    tv.SelectedNode =  tv.Nodes[selectedId];
            //    if (expanded)
            //        tv.SelectedNode.Expand();

            //}

            tv.EndUpdate();
        }


        private TreeNode CreateTopLevelNode(string id, string name)
        {
            var node = tv.Nodes.Add(id, name, "Solution", "Solution");
            node.Tag = GunterSolutionItemType.Solution;
            return node;
        }

        private TreeNode CreateNode(GunterSolutionItemType itemType, TreeNode parent, string id, string name)
        {
            if (parent is null)
                parent = tv.Nodes[0];

            string icon = string.Empty;
            string selectedIcon = string.Empty;

            switch (itemType)
            {
                case GunterSolutionItemType.Folder:
                    icon = "FolderClosed";
                    selectedIcon = "FolderOpened";
                    break;
                default:
                    icon = itemType.ToString();
                    break;

            }
            if (string.IsNullOrWhiteSpace(selectedIcon))
                selectedIcon = icon;

            var retVal = parent.Nodes.Add(id, name, icon, selectedIcon);
            retVal.Tag = itemType;

            return retVal;
        }

        private TreeNode CreateProjectNode(TreeNode parent, GunterProject project)
        {
            TreeNode destinationNode = parent;
            if (!string.IsNullOrWhiteSpace(project.FolderId))
                if (!TryGetNode(project.FolderId, out destinationNode))
                    destinationNode = parent;

            var retVal = CreateNode(GunterSolutionItemType.Project, destinationNode, project.Id, project.Name);

            foreach (var processor in project.Processors)
                CreateProcessorNode(retVal, processor);

            return retVal;
        }

        private TreeNode CreateProcessorNode(TreeNode parent, IGunterProcessor processor)
        {
            var retVal = CreateNode(GunterSolutionItemType.Processor, parent, processor.Id, processor.Name);

            foreach (var item in processor.InfoItems)
                CreateInfoItemNode(retVal, item);

            return retVal;
        }

        private TreeNode CreateInfoItemNode(TreeNode parent, IGunterInfoItem infoItem)
        {
            var retVal = CreateNode(GunterSolutionItemType.InfoItem, parent, infoItem.Id, infoItem.Name);

            foreach (var item in infoItem.InfoSources)
                CreateInfoSourceNode(retVal, item);

            foreach (var item in infoItem.VisualizationHandlers)
                CreateVisualizationHandlerNode(retVal, item);

            return retVal;
        }

        private TreeNode CreateInfoSourceNode(TreeNode parent, IGunterInfoSource infoSource)
        {
            var retVal = CreateNode(GunterSolutionItemType.InfoSource, parent, infoSource.Id, infoSource.Name);

            return retVal;
        }

        private TreeNode CreateVisualizationHandlerNode(TreeNode parent, IGunterVisualizationHandler handler)
        {
            var retVal = CreateNode(GunterSolutionItemType.VisualizationHandler, parent, handler.Id, handler.Name);

            return retVal;
        }

        private bool TryGetNode(string id, out TreeNode node, TreeNode fromNode = null)
        {
            if (fromNode is null)
                fromNode = tv.Nodes[0];

            node = fromNode.Nodes[id];
            if (node is null)
                foreach (var innerNode in fromNode.Nodes)
                    if (TryGetNode(id, out TreeNode searchInnerNode, (TreeNode)innerNode))
                    {
                        node = searchInnerNode;
                        break;
                    }

            return (node is not null);
        }

        private string CurrentNodeId()
            => selectedNode?.Name ?? string.Empty;

        public void LoadSolution(GunterSolution solution)
        {
            currentSolution = solution;
            processorCounter = solution.Projects.SelectMany(x => x.Processors).Count() + 1;
            Reload();
        }

        private void NewProject()
        {
            string currentNodeId = CurrentNodeId();

            var folderId = currentSolution.Folders.Any(x => x.Id == currentNodeId) ?
                selectedNode?.Name ?? string.Empty :
                tv.Nodes[0].Name;

            if (!TryGetNode(folderId, out var parentNode))
                parentNode = tv.Nodes[0];

            using var dlg = new ProjectDialog
            {
                ProjectFolderId = folderId
            };
            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            var project = new GunterProject
            {
                FolderId = dlg.ProjectFolderId,
                Name = dlg.ProjectName,
                Description = dlg.ProjectDescription
            };
            project = currentSolution.AddProject(project);
            var node = CreateProjectNode(parentNode, project);
            node.EnsureVisible();
            tv.SelectedNode = node;
        }

        private void NewFolder()
        {
            string folderId = CurrentNodeId();
            if (currentSolution.Folders.Any(x => x.Id == folderId))
                folderId = selectedNode?.Name ?? string.Empty;

            var folder = new GunterSolutionFolder(folderId);
            currentSolution.Folders.Add(folder);

            var node = CreateNode(GunterSolutionItemType.Folder, selectedNode, folder.Id, folder.Name);
            tv.SelectedNode = node;
            node.EnsureVisible();
            //Reload();
        }

        public IGunterProcessor? NewProcessor()
        {
            var project = currentSolution.Projects.FirstOrDefault(x => x.Id == selectedNode.Name);
            if (project is null)
                return null;

            var processor = new GunterProcessorBase();
            processor.Name = $"Processor {processorCounter++}";
            project.AddProcessor(processor);
            var args = new GunterSolutionItemEventArgs
            {
                Id = processor.Id,
                Component = processor,
                SolutionItemType = GunterSolutionItemType.Processor
            };

            OnGunterItemAdded?.Invoke(this, args);
            OnGunterItemShow?.Invoke(this, args);

            var node = CreateNode(GunterSolutionItemType.Processor, selectedNode, processor.Id, processor.Name);
            tv.SelectedNode = node;
            node.EnsureVisible();
            return processor;
        }

        private GunterProject? GetProject(string id)
            => currentSolution.Projects.FirstOrDefault(x => x.Id == id);

        private GunterProcessorBase? GetProcessor(GunterProject project, string id)
        => project.Processors.Where(x => x.Id == selectedNode.Name).SingleOrDefault();

        public IGunterInfoItem? NewInfoItem(GunterProcessorBase? processor = null)
        {
            if (processor is null)
            {
                var type = GetSolutionItemType(selectedNode);
                if (type != GunterSolutionItemType.InfoSource)
                    return null;

                var project = GetProject(selectedNode.Parent.Name);
                if (project is null)
                    return null;

                processor = GetProcessor(project, selectedNode.Name);
            }

            var target = processor.CreateInfoItem(string.Empty);
            target.Name = $"New InfoItem";
            processor.AddInfoItem(target.Id, target);

            var args = new GunterSolutionItemEventArgs
            {
                Id = processor.Id,
                Component = processor,
                SolutionItemType = GunterSolutionItemType.Processor
            };

            OnGunterItemAdded?.Invoke(this, args);
            OnGunterItemShow?.Invoke(this, args);

            var node = CreateNode(GunterSolutionItemType.Processor, selectedNode, processor.Id, processor.Name);
            tv.SelectedNode = node;
            node.EnsureVisible();

            return target;
        }


        private IGunterComponent? GetComponentFromNode(TreeNode node)
        {
            IGunterComponent? retVal = null;

            var type = GetSolutionItemType(node);
            switch (type)
            {
                case GunterSolutionItemType.Processor:
                    retVal = currentSolution.Projects
                        .Where(x => x.Id == node.Parent.Name).SingleOrDefault()?
                        .Processors.Where(x => x.Id == node.Name).SingleOrDefault();
                    break;
                case GunterSolutionItemType.InfoItem:
                    break;
                case GunterSolutionItemType.InfoSource:
                    break;
                case GunterSolutionItemType.Solution:
                    break;
                case GunterSolutionItemType.OtherItem:
                default:
                    break;
            }

            return retVal;
        }

        private static GunterSolutionItemType GetSolutionItemType(TreeNode node)
        {
            if (Enum.TryParse<GunterSolutionItemType>(node.Tag.ToString(), out var solutionItemType))
            {
                return solutionItemType;
            }
            else
                return GunterSolutionItemType.OtherItem;
        }


        //

        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            NewProject();
        }

        private void createFolderToolStripButton_Click(object sender, EventArgs e)
        {
            NewFolder();
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            selectedNode = e.Node;
        }

        private void cmdCollapseAll_Click(object sender, EventArgs e)
        {
            tv.CollapseAll();
        }

        private void cmdExpandAll_Click(object sender, EventArgs e)
        {
            tv.ExpandAll();
        }

        private void tv_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            var node = tv.GetNodeAt(new Point(e.X, e.Y));
            if (node is not null)
            {
                var nodeType = node.Tag.ToString();
                procesadorToolStripMenuItem.Enabled = nodeType == GunterSolutionItemType.Project.ToString();
                infoItemToolStripMenuItem.Enabled = nodeType == GunterSolutionItemType.Processor.ToString();
                infoSourceToolStripMenuItem.Enabled = nodeType == GunterSolutionItemType.InfoItem.ToString();
                visualizationHandlerToolStripMenuItem.Enabled = nodeType == GunterSolutionItemType.InfoItem.ToString();

                eliminarToolStripMenuItem.Enabled = nodeType != GunterSolutionItemType.Solution.ToString();

                tv.SelectedNode = node;
                selectedNode = node;
                mnuProject.Show(tv, new Point(e.X, e.Y));
            }
        }

        private void procesadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProcessor();
        }

        private void tv_DoubleClick(object sender, EventArgs e)
        {
            if (selectedNode is null)
                return;

            var relatedComponent = GetComponentFromNode(selectedNode);
            if (relatedComponent is null)
                return;

            OnGunterItemShow?.Invoke(this,
                new GunterSolutionItemEventArgs
                {
                    Id = selectedNode.Name,
                    SolutionItemType = (GunterSolutionItemType)selectedNode.Tag,
                    Component = relatedComponent
                });
        }

        private void tv_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {

        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedNode.Tag.ToString() == GunterSolutionItemType.Solution.ToString() ||
                MessageBox.Show($"Confirm delete of {selectedNode.Text} ?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                return;

            var type = GetSolutionItemType(selectedNode);
            GunterProject? project;
            switch (type)
            {
                case GunterSolutionItemType.Project:
                    project = currentSolution.GetProject(selectedNode.Name);
                    if (project is not null)
                    {
                        currentSolution.RemoveProject(project);
                        OnGunterItemRemoved?
                            .Invoke(this,
                                new GunterSolutionItemEventArgs { Id = selectedNode.Name, SolutionItemType = type });

                        //MdiMain.RemoveGunterItem(string id, GunterSolutionItemType type);
                    }
                    break;
                case GunterSolutionItemType.Processor:
                    project = currentSolution.GetProject(selectedNode.Parent.Name);
                    if (project is not null)
                        project.RemoveProcessor(selectedNode.Name);
                    break;
                case GunterSolutionItemType.InfoItem:
                    break;
                case GunterSolutionItemType.InfoSource:
                    break;
                case GunterSolutionItemType.OtherItem:
                    break;
                default:
                    break;
            }

            selectedNode.Remove();
            selectedNode = null;
        }

        private void propiedadesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void infoItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewInfoItem();
        }
    }
}
