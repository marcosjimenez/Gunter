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

namespace Controls
{
    public partial class InfoItemViewer : UserControl
    {

        public event Delegates.GunterItemShowDelegate OnGunterItemShow;

        private System.Windows.Forms.Timer timer = new();

        private int timerCounter = 0;
        private int MaxTimerCounter = 30;

        private DateTimeOffset nextUpdate;

        private IGunterInfoItem _infoItem;
        public IGunterInfoItem Target { get => _infoItem; set { _infoItem = value; } }

        public InfoItemViewer()
        {
            InitializeComponent();
        }

        public InfoItemViewer(IGunterInfoItem target)
        {
            _infoItem = target;
            InitializeComponent();

            ShowData();
            CalculateNextUpdate();
            timer.Tick += timer_Tick;
            timer.Interval = 1000;
            timer.Enabled = true;

        }

        public void ShowData()
        {
            txtNombre.Text = _infoItem.Name;
            txtId.Text = _infoItem.Id.ToString();
            LoadSources();

            if (_infoItem.VisualizationHandlers.Count > 0)
            {
                var handler = _infoItem.VisualizationHandlers[0];
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

            foreach (var item in _infoItem.InfoSources)
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
            _infoItem?.Update();
            ShowData();
            CalculateNextUpdate();
            greenLed.Visible = true;
            redLed.Visible = false;
            timer.Enabled = enableTimer;
        }

        private void CalculateNextUpdate()
        {
            var enableTimer = timer.Enabled;
            timer.Enabled = false;
            txtSegundos.Minimum = (txtDias.Value == 0 && txtHoras.Value == 0 && txtMinutos.Value == 0) ? 10 : 0;
            lblUltimaActualizacion.Text = $"Updated {nextUpdate.ToString()}";
            var nextTimeSpan = GetUITimeSpan();
            nextUpdate = _infoItem.LastUpdate.Add(nextTimeSpan);

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
            lblUltimaActualizacion.Text = $"Updated {DateTimeManipulationHelper.GetRelativeDateTime(_infoItem.LastUpdate)}";
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
            if (_infoItem is null || lvSources.SelectedItems.Count == 0)
            {
                specialPropertiesViewer1.SetProperties(new Gunter.Extensions.Common.SpecialProperties());
                return;
            }

            var source = _infoItem.InfoSources.Where(x => x.Id == lvSources.SelectedItems[0].Name).Single();
            specialPropertiesViewer1.SetProperties(source.SpecialProperties);
        }

        private void InfoItemViewer_Load(object sender, EventArgs e)
        {

        }

        private void cmdAddSource_Click(object sender, EventArgs e)
        {
            if (_infoItem is null)
                return;

            using var frm = new OrigenForm(_infoItem.GetProcessor());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var source = frm.GetSelectedSource(_infoItem);

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

                _infoItem.InfoSources.Add(source);
                LoadSources();
            }
        }

        private void lvSources_DoubleClick(object sender, EventArgs e)
        {
            if (_infoItem is null || lvSources.SelectedItems.Count == 0)
                return;

            var source = _infoItem.InfoSources.SingleOrDefault(x => x.Id == lvSources.SelectedItems[0].Name);
            if (source is null)
                return;

            OnGunterItemShow?.Invoke(this, new Infrastructure.EvengArgs.GunterSolutionItemEventArgs
            {
                Id = source.Id,
                Component = source,
                SolutionItemType = Gunter.Core.Solutions.GunterSolutionItemType.InfoSource
            });


        }

        private void cmdAddVisualization_Click(object sender, EventArgs e)
        {




        }
    }
}
