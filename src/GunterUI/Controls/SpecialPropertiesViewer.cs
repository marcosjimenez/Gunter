using Gunter.Extensions.Common;
using GunterUI.Extensions;

namespace GunterUI
{
    public partial class SpecialPropertiesViewer : UserControl
    {
        public bool CanEdit { get; set; }

        public SpecialPropertiesViewer()
        {
            InitializeComponent();
            SpecialProperties = new SpecialProperties();
        }

        public SpecialProperties SpecialProperties { get; private set; }

        public void SetProperties(SpecialProperties properties)
        {
            SpecialProperties = properties;
            ReloadListView();
        }

        private void SpecialPropertiesViewer_Load(object sender, EventArgs e)
        {
            ReloadListView();
        }

        private void ReloadListView()
        {
            if (SpecialProperties?.Properties is null)
                return;

            listView1.BeginUpdate();
            listView1.Items.Clear();

            foreach(var item in SpecialProperties.Properties)
            {
                var lvItem = listView1.Items.Add(item.Key, item.Key);
                lvItem.SubItems.Add(item.Value.ToString());
                lvItem.SubItems.Add(string.Empty);
            }

            listView1.EndUpdate();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            if (!this.CanEdit)
                return;

            var item = listView1.SelectedItems[0];
            var newValue = Prompt.ShowDialog("Introduce el nuevo valor", "Nuevo Valor", item.SubItems[1].Text);
            if (string.IsNullOrWhiteSpace(newValue.Trim()))
                return;

            SpecialProperties.AddOrUpdate(item.Text, newValue);
            item.SubItems[1].Text = newValue;
        }
    }
}
