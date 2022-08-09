using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Helpers;
using Contracts;
using Gunter.Core.BaseComponents;

namespace Controls
{
    public partial class ProcessorViewer : UserControl
    {

        public event Delegates.GunterItemShowDelegate OnGunterItemShow;

        private int infoItemCounter = 1; 
        private readonly IGunterProcessor _processor;
        private IGunterInfoItem? selectedInfoItem = null;

        public ProcessorViewer()
        {
            InitializeComponent();
            _processor = new GunterProcessor();
        }

        public ProcessorViewer(IGunterProcessor processor)
        {
            InitializeComponent();
            _processor = processor;
        }

        private ListViewItem AddOrUpdateInfoItem(string id, IGunterInfoItem item, bool editName = true)
        {
            ListViewItem listviewitem;
            if (lvInfoItems.Items.ContainsKey(id))
            {
                listviewitem = lvInfoItems.Items[id];
                listviewitem.Text = item.Name;
                listviewitem.SubItems[1].Text = DateTimeManipulationHelper.GetRelativeDateTime(item.LastUpdate);
            }
            else
            {
                listviewitem = lvInfoItems.Items.Add(id, item.Name, "Process");
                listviewitem.SubItems.Add(DateTimeManipulationHelper.GetRelativeDateTime(item.LastUpdate));

                listviewitem.Selected = true;
            }
            if (editName) 
                listviewitem.BeginEdit();

            return listviewitem;
        }

        public void LoadListView()
        {

            lvInfoItems.BeginUpdate();
            lvInfoItems.Items.Clear();

            foreach (var item in _processor.GetInfoItems())
            {
                var listviewItem = AddOrUpdateInfoItem(item.Id.ToString(), item, false);
            }

            lvInfoItems.EndUpdate();
        }

        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            NewInfoItem();
        }

        private void NewInfoItem()
        {
            var target = _processor.CreateInfoItem(string.Empty);
            target.Name = $"InfoItem {infoItemCounter++}";
            AddOrUpdateInfoItem(target.Id.ToString(), target);
        }

        private void LoadInfoItem()
        {
            

        }
             

        private void lvInfoItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvInfoItems.SelectedItems.Count == 0)
            {
                selectedInfoItem = null;
                LoadInfoItem();
                return;
            }

            var listviewItem = lvInfoItems.SelectedItems[0];
            selectedInfoItem = _processor.GetInfoItem(listviewItem.Name);

            LoadInfoItem();
        }

        private void lvInfoItems_DoubleClick(object sender, EventArgs e)
        {
            if (selectedInfoItem is null)
                return;

            OnGunterItemShow?.Invoke(this, new Infrastructure.EvengArgs.GunterSolutionItemEventArgs
            {
                Id = selectedInfoItem.Id,
                Component = selectedInfoItem,
                SolutionItemType = Gunter.Core.Solutions.GunterSolutionItemType.InfoItem
            });
        }

        private void lvInfoItems_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            var lvItem = lvInfoItems.Items[e.Item];
            var infoitem = _processor.GetInfoItem(lvItem.Name);
            if (infoitem is null)
                return;

            infoitem.Name = e.Label ?? infoitem.Name;
            lvItem.Selected = false;
            lvItem.Selected = true;
        }

        private void ProcessorViewer_Load(object sender, EventArgs e)
        {
            lvInfoItems.View = View.Details;
            LoadListView();
        }

    }
}
