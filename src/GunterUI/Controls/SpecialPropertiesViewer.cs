using Gunter.Core.Contracts;
using Gunter.Core.Models;
using GunterUI.Extensions;

namespace GunterUI
{
    public partial class SpecialPropertiesViewer : UserControl
    {

        public class PropertyUpdatedEventArgs : EventArgs
        {
            public SpecialProperty Property { get; set; } = new();
        }

        public delegate void PropertyUpdatedDelegate(object sender, PropertyUpdatedEventArgs e);
        public event PropertyUpdatedDelegate OnPropertyChanged;

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
                lvItem.SubItems.Add(item.Value.Value.ToString());
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

            SpecialProperties.AddOrUpdate(item.Text, newValue, out var property);
            item.SubItems[1].Text = newValue;

            OnPropertyChanged?.Invoke(this, new PropertyUpdatedEventArgs { Property = (SpecialProperty)property });

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newValue = Prompt.ShowDialog("Nueva variable", "Añadir", string.Empty);
            if (string.IsNullOrWhiteSpace(newValue))
                return;

            SpecialProperties.AddOrUpdate(newValue, string.Empty, out var property);
            OnPropertyChanged?.Invoke(this, new PropertyUpdatedEventArgs { Property = (SpecialProperty)property });
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            var bEnable = listView1.HitTest(e.X, e.Y) is not null;
            editToolStripMenuItem.Enabled = bEnable;
            removeToolStripMenuItem.Enabled = bEnable;

            mnuProperty.Show(listView1, e.X, e.Y);

        }
    }
}
