﻿using Gunter.Core.Contracts;
using Gunter.Core.Solutions;
using Gunter.Core.Solutions.Models;
using Infrastructure.EvengArgs;
using Contracts;
using static Gunter.Core.Solutions.GunterSolutionConstants;

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

            foreach(var folder in currentSolution.Folders)
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

            foreach(var project in currentSolution.Projects)
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
                    selectedIcon = icon;
                    break;
                case GunterSolutionItemType.Solution:
                    icon = "Solution";
                    break;
                case GunterSolutionItemType.Project:
                    icon = "Project";
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

            var retVal = CreateNode(GunterSolutionItemType.Project, parent, project.Id, project.Name);

            foreach (var processor in project.Processors)
                CreateNode(GunterSolutionItemType.Processor, retVal, processor.Id.ToString(), processor.Name);

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

            var project = currentSolution.AddProject(new GunterProject { FolderId = folderId });
            var node = CreateProjectNode(parentNode, project);
            node.EnsureVisible();
            tv.SelectedNode = node;

            //Reload();
        }

        private void NewFolder()
        {
            string folderId = CurrentNodeId();
            if (currentSolution.Folders.Any(x => x.Id == folderId))
                folderId = selectedNode?.Name ?? string.Empty;

            var folder = new GunterSolutionFolder(folderId);
            currentSolution.Folders.Add(folder);
            Reload();
        }

        public IGunterProcessor NewProcessor(GunterProject project)
        {
            if (project is null)
                throw new ArgumentNullException(nameof(project));

            var processor = new Gunter.Core.GunterProcessor();
            processor.Name = $"Processor {processorCounter++}";
            project.AddProcessor(processor);
            return processor;
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
                eliminarToolStripMenuItem.Enabled = node.Tag.ToString() != GunterSolutionItemType.Solution.ToString();
                tv.SelectedNode = node;
                selectedNode = node;
                mnuProject.Show(tv, new Point(e.X, e.Y));
            }
        }

        private void procesadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var project = currentSolution.Projects.FirstOrDefault(x => x.Id == selectedNode.Name);
            if (project is null)
                return;

            var processor = NewProcessor(project);
            var args = new GunterSolutionItemEventArgs
            {
                Id = processor.Id,
                Component = processor,
                SolutionItemType = GunterSolutionItemType.Processor
            };

            OnGunterItemAdded?.Invoke(this, args);
            OnGunterItemShow?.Invoke(this, args);

            CreateNode(GunterSolutionItemType.Processor, selectedNode, processor.Id, processor.Name);
        }

        private void tv_DoubleClick(object sender, EventArgs e)
        {
            if (selectedNode is null)
                return;

            var relatedComponent = GetComponentFromNode(selectedNode);
            if (relatedComponent is null)
                return;

            OnGunterItemShow?.Invoke(this, 
                new GunterSolutionItemEventArgs { 
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
    }
}