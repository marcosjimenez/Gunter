using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Extensions.InfoSources.Specialized;
using Gunter.Extensions.InfoSources;
using Gunter.Extensions.Visualization.Handlers;
using GunterUI.Extensions;
using GunterUI.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Contracts;
using Dialogs;

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

            ShowData();
            CalculateNextUpdate();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer.Enabled = chkActualizar.Checked;

        }

        public void ShowData()
        {
            txtNombre.Text = InfoItem.Name;
            txtId.Text = InfoItem.Id.ToString();
            LoadSources();
            LoadVisualizations();

            if (InfoItem.VisualizationHandlers.Count > 0)
            {
                var handler = InfoItem.VisualizationHandlers[0];
                var html = handler.GetHTML();
                if (!string.IsNullOrWhiteSpace(html))
                    try
                    {
                        //WindowManager.Instance.ShowForm(WindowManager.AvailableForm.WebViewer, "HTML", html);
                    }
                    catch { }
                else
                {

                    //using var bmp = new Bitmap(1200, 600, PixelFormat.Format24bppRgb);
                    //using var g = Graphics.FromImage(bmp);
                    //using var ms = new MemoryStream(handler.GetImage());
                    //var image = Image.FromStream(ms);
                    //imageVisualization.Image = image;

                    //var base64Image = Convert.ToBase64String(handler.GetImage());
                    //html = @$"<!DOCTYPE html>
                    //        <html>
                    //          <body>
                    //            <img src=""data:image/png;base64, {base64Image}"" alt=""{ txtNombre.Text }"" />
                    //          </body>
                    //        </html>";

                }
            }
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

        private void LoadSources()
        {
            lvSources.BeginUpdate();
            lvSources.Items.Clear();

            foreach (var item in InfoItem.InfoSources)
            {
                try
                {
                    CreateSourceListViewItem(item.Id, item.Name, "DataSource", null, item.Id);
                }
                catch { }
            }

            lvSources.EndUpdate();
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
            greenLed.Visible = false;
            redLed.Visible = true;
            var enableTimer = timer.Enabled;
            timer.Enabled = false;
            InfoItem?.Update();
            lblUltimaActualizacion.Text = $"Updated {DateTime.Now.ToString()}";
            ShowData();
            CalculateNextUpdate();
            greenLed.Visible = true;
            redLed.Visible = false;
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
    }
}
