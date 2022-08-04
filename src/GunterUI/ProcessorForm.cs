using Gunter.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Gunter.Core;
using Gunter.Extensions.InfoSources.Specialized;
using Gunter.Extensions.InfoSources;
using Gunter.Extensions.Visualization.Handlers;
using GunterUI.Extensions;
using System.Diagnostics;
using Gunter.Core.Infrastructure.Helpers;

namespace GunterUI
{
    public partial class ProcessorForm : Form
    {
        private bool loading = false;
        private readonly IGunterProcessor _processor;
        private IGunterInfoItem? selectedInfoItem = null;

        public ProcessorForm()
        {
            InitializeComponent();
            _processor = new GunterProcessor();
        }

        public ProcessorForm(IGunterProcessor processor)
        {
            InitializeComponent();
            _processor = processor;
        }

        private ListViewItem AddOrUpdateInfoItem(string id, IGunterInfoItem item)
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
                listviewitem.BeginEdit();
            }

            return listviewitem;
        }

        private void LoadListView()
        {

            lvInfoItems.BeginUpdate();
            lvInfoItems.Items.Clear();

            foreach (var item in _processor.GetInfoItems())
            {
                var listviewItem = AddOrUpdateInfoItem(item.Key, item.Value);
            }

            lvInfoItems.EndUpdate();
        }

        private void ProcessorForm_Load(object sender, EventArgs e)
        {
            loading = true;
            lblId.Text = _processor.Id.ToString();
            txtName.Text = _processor.Name;
            this.Text = _processor.Name;
            loading = false;
        }

        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            NewInfoItem();
        }

        private int infoItemCounter = 1;
        private void NewInfoItem()
        {
            var target = _processor.CreateInfoItem(string.Empty);
            target.Name = $"InfoItem {infoItemCounter}";
            _processor.AddInfoItem(target.Id.ToString(), target);
            AddOrUpdateInfoItem(target.Id.ToString(), target);
        }

        private void LoadInfoItem()
        {
            if (selectedInfoItem is null)
            {
                txtInfoItemId.Text = string.Empty;
                txtInfoItemName.Text = string.Empty;
                lvSources.Items.Clear();
                specialPropertiesViewer1.SetProperties(null);
                return;
            }


            txtInfoItemId.Text = selectedInfoItem.Id.ToString();
            txtInfoItemName.Text = selectedInfoItem.Name;

            LoadSources();
        }

        private void LoadSources()
        {
            if (selectedInfoItem is null)
                return;

            lvSources.BeginUpdate();
            lvSources.Items.Clear();

            foreach (var item in selectedInfoItem.Sources)
            {
                var lvItem = lvSources.Items.Add(item.Id, item.Name, "DataSource");
                lvItem.SubItems.Add(item.Category);
                lvItem.SubItems.Add(item.SubCategry);
            }

            lvSources.EndUpdate();


        }

        private void cmdCopyId_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lblId.Text);
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (loading)
                return;

            _processor.Name = txtName.Text;
            this.Text = txtName.Text;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
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

        private void txtInfoItemName_TextChanged(object sender, EventArgs e)
        {
            if (selectedInfoItem is null)
                return;

            selectedInfoItem.Name = txtInfoItemName.Text;
            AddOrUpdateInfoItem(selectedInfoItem.Id.ToString(), selectedInfoItem);
        }

        private void lvSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedInfoItem is null || lvSources.SelectedItems.Count == 0)
                return;

            var source = selectedInfoItem.Sources.Where(x => x.Id == lvSources.SelectedItems[0].Name).Single();
            specialPropertiesViewer1.SetProperties(source.SpecialProperties);

        }

        private void cmdAddSource_Click(object sender, EventArgs e)
        {
            if (selectedInfoItem is null)
                return;

            using var frm = new Dialogs.OrigenForm(_processor);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var source = frm.GetSelectedSource(selectedInfoItem);

                // TEMP: TESTING Visualizations
                switch (frm.SelectedType)
                {
                    case SpecializedInfoSources.Wikipedia:
                        source.Container.VisualizationHandlers.Add(new WikipediaVisualizationHandler<WikipediaInfoSource>((WikipediaInfoSource)source));
                        break;
                    case SpecializedInfoSources.OpenWeather:
                        source.Container.VisualizationHandlers.Add(new OpenWeatherVisualizationHandler<OpenWeatherInfoSource>((OpenWeatherInfoSource)source));
                        break;
                    case SpecializedInfoSources.AEMET:
                        source.Container.VisualizationHandlers.Add(new AEMETVisualizationHandler<AEMETInfoSource>((AEMETInfoSource)source));
                        break;
                }

                selectedInfoItem.Sources.Add(source);
                LoadSources();
            }
        }

        private void lvSources_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (selectedInfoItem is null || lvSources.SelectedItems.Count == 0)
                return;

            var source = selectedInfoItem.Sources.Where(x => x.Id == lvSources.SelectedItems[0].Name).Single();
            WindowManager.Instance.ShowForm(WindowManager.AvailableForm.InfoSourceForm, source.Id, source);
        }

        private void lvInfoItems_DoubleClick(object sender, EventArgs e)
        {
            if (selectedInfoItem is null)
                return;

            WindowManager.Instance.ShowForm(WindowManager.AvailableForm.InfoItemForm, selectedInfoItem.Id.ToString(), selectedInfoItem);
        }

        private void lvInfoItems_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            var lvItem = lvInfoItems.Items[e.Item];
            var infoitem = _processor.GetInfoItem(lvItem.Name);
            infoitem.Name = e.Label ?? infoitem.Name;
            lvItem.Selected = false;
            lvItem.Selected = true;
        }
    }
}
