using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Extensions.InfoSources;
using Gunter.Extensions.InfoSources.Specialized;
using Gunter.Extensions.Visualization.Handlers;
using GunterUI.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GunterUI.ToolBox
{
    public partial class InfoItemViewer : Form
    {
        private System.Windows.Forms.Timer timer = new();
        
        private int timerCounter = 0;
        private int MaxTimerCounter = 30;

        private DateTimeOffset nextUpdate;

        private IGunterInfoItem currentInfoItem;

        public IGunterInfoItem Target { get => currentInfoItem; set { currentInfoItem = value; } }

        public InfoItemViewer(IGunterInfoItem target)
        {
            currentInfoItem = target;
            InitializeComponent();

            ShowData();

            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer.Enabled = true;

        }

        public InfoItemViewer()
        {
            InitializeComponent();
        }

        public void ShowData()
        {
            txtNombre.Text = currentInfoItem.Name;
            txtId.Text = currentInfoItem.Id.ToString();
            LoadSources();

            if (currentInfoItem.VisualizationHandlers.Count > 0)
            {
                var handler = currentInfoItem.VisualizationHandlers[0];
                var html = handler.GetHTML();
                if (!string.IsNullOrWhiteSpace(html))
                    try
                    {
                        WindowManager.Instance.ShowForm(WindowManager.AvailableForm.WebViewer, "HTML", html);
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

        private void LoadSources()
        {
            lvSources.BeginUpdate();
            lvSources.Items.Clear();

            foreach(var item in currentInfoItem.InfoSources)
            {
                CreateSourceListViewItem(item.Id, item.Id, "DataSource", null, item.Name);
            }

            lvSources.EndUpdate();
        }

        private void UpdateAll()
        {
            greenLed.Visible = false;
            redLed.Visible = true;
            var enableTimer = timer.Enabled;
            timer.Enabled = false;
            currentInfoItem?.Update();
            ShowData();
            CalculateNextUpdate();
            greenLed.Visible = true;
            redLed.Visible = false;
            timer.Enabled = enableTimer;
        }

        private void CalculateNextUpdate ()
        {
            var enableTimer = timer.Enabled;
            timer.Enabled = false;
            txtSegundos.Minimum = (txtDias.Value == 0 && txtHoras.Value == 0 && txtMinutos.Value == 0) ? 10 : 0;
            lblUltimaActualizacion.Text = $"Updated {nextUpdate.ToString()}";
            var nextTimeSpan = GetUITimeSpan();
            nextUpdate = currentInfoItem.LastUpdate.Add(nextTimeSpan);

            MaxTimerCounter = (int)nextTimeSpan.TotalSeconds;
            timerCounter = 0;

            lblSiguienteActualizacion.Text = $"Next {nextUpdate.ToString()}";
            timer.Enabled = enableTimer;
        }

        private TimeSpan GetUITimeSpan()
            => new TimeSpan((int)txtDias.Value, (int)txtHoras.Value, (int)txtMinutos.Value, (int)txtSegundos.Value);


        // Events
        private void TargetToolBox_Load(object sender, EventArgs e)
        {
            LoadSources();
            CalculateNextUpdate();
        }

        private void cmdUpdate_Click(object sender, EventArgs e)
        {
            UpdateAll();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            lblUltimaActualizacion.Text = $"Updated {DateTimeManipulationHelper.GetRelativeDateTime(currentInfoItem.LastUpdate)}";
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

        private void lvSources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentInfoItem is null || lvSources.SelectedItems.Count == 0)
                return;

            var source = currentInfoItem.InfoSources.Where(x => x.Id == lvSources.SelectedItems[0].Name).Single();
            specialPropertiesViewer1.SetProperties(source.SpecialProperties);

        }

        private void cmdAddSource_Click(object sender, EventArgs e)
        {
            if (currentInfoItem is null)
                return;

            using var frm = new Dialogs.OrigenForm(currentInfoItem.GetProcessor());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var source = frm.GetSelectedSource(currentInfoItem);

                // TEMP: TESTING Visualizations
                switch (frm.SelectedType)
                {
                    case SpecializedInfoSources.Wikipedia:
                        source.Container.VisualizationHandlers.Add(new WikipediaVisualizationHandler((WikipediaInfoSource)source));
                        break;
                    case SpecializedInfoSources.OpenWeather:
                        source.Container.VisualizationHandlers.Add(new OpenWeatherVisualizationHandler((OpenWeatherInfoSource)source));
                        break;
                    case SpecializedInfoSources.AEMET:
                        source.Container.VisualizationHandlers.Add(new AEMETVisualizationHandler((AEMETInfoSource)source));
                        break;
                    case SpecializedInfoSources.GunterBot:
                        source.Container.VisualizationHandlers.Add(new GunterBotVisualizationHandler((GunterBotInfoSource)source));
                        break;
                }

                currentInfoItem.InfoSources.Add(source);
                LoadSources();
            }
        }

        private void lvSources_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (currentInfoItem is null || lvSources.SelectedItems.Count == 0)
                return;

            var source = currentInfoItem.InfoSources.Where(x => x.Id == lvSources.SelectedItems[0].Name).Single();
            WindowManager.Instance.ShowForm(WindowManager.AvailableForm.InfoSourceForm, source.Id, source);
        }
    }
}
