using Gunter.Core;
using Gunter.Core.Contracts;
using Gunter.Extensions.InfoSources;
using Gunter.Extensions.InfoSources.Specialized;
using Gunter.Extensions.Models;
using Gunter.Extensions.Visualization.Handlers;
using GunterUI.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GunterUI.Extensions.WindowManager;

namespace GunterUI
{
    public partial class MainForm : Form
    {
        private Dictionary<string, IGunterProcessor> processors = new Dictionary<string, IGunterProcessor>();
        private IGunterProcessor? selectedProcessor;
        private IGunterInfoItem? selectedTarget;

        public MainForm()
        {
            InitializeComponent();
        }

        private void ListProcessors()
        {
            lvProcessors.BeginUpdate();

            lvProcessors.Items.Clear();
            lvProcessors.Groups.Clear();
            foreach (var processor in processors)
            {
                CreateProcesssorListViewGroup(processor);
            }

            lvProcessors.EndUpdate();
        }

        private ListViewGroup CreateProcesssorListViewGroup(KeyValuePair<string, IGunterProcessor> processor)
        {
            var group = GetGroup(processor.Key);

            foreach(var persona in processor.Value.GetInfoItems())
            {
                CreateProcessorListViewItem(persona.Value, group);
            }

            return group;
        }

        private ListViewItem CreateProcessorListViewItem(IGunterInfoItem persona, ListViewGroup group)
            => CreateProcessorListViewItem(persona.Id.ToString(), persona.Name, "Persona", group, $"{persona.Sources.Count()} sources");

        private ListViewItem CreateProcessorListViewItem(string key, string value, string imageKey, ListViewGroup group, params string[] subitems)
        {
            var item = lvProcessors.Items.Add(key, value, imageKey);
            item.Group = group;

            foreach (var subitem in subitems)
                item.SubItems.Add(subitem);

            return item;
        }

        private ListViewGroup GetGroup(string id)
        {
            var group = lvProcessors.Groups[id];
            group ??= lvProcessors.Groups.Add(id, $"ID: {id}");

            return group;
        }

        private void NewPersona()
        {
            if (selectedProcessor is null)
                return;

            using var frm = new Dialogs.TargetForm(selectedProcessor);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var persona = frm.Target;
                selectedProcessor.AddInfoItem(persona.Id.ToString(), persona);
                CreateProcessorListViewItem(persona, GetGroup(selectedProcessor.Id.ToString()));
            }
        }

        static int counter = 0;
        private void NewProcessor()
        {
            var id = Guid.NewGuid();
            var processor = new GunterProcessor(id, (counter++).ToString());
            processors.Add(id.ToString(), processor);
            CreateProcesssorListViewGroup(new KeyValuePair<string, IGunterProcessor>(id.ToString(), processor));

            selectedProcessor = processor;
        }

        private void LoadSources(IGunterInfoItem persona)
        {
            lvSources.BeginUpdate();

            lvSources.Items.Clear();
            lvSources.Groups.Clear();

            foreach(var source in persona.Sources)
            {
                lvSources.Items.Add(source.Id, source.Name);
            }

            lvSources.EndUpdate();
        }

        private void OnProcessorUpdate(IGunterProcessor processor)
        {

            var target = processor.GetInfoItem(processor.Id.ToString());

            var item = lvProcessors.Items[target.Id.ToString()];

        }


        // EVENTS

        private void Form1_Load(object sender, EventArgs e)
        {
            NewProcessor();
            ListProcessors();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvProcessors_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (lvProcessors.SelectedItems.Count == 0)
            {
                selectedProcessor = null;
                propertyGrid1.SelectedObject = null;
                propertyGrid2.SelectedObject = null;
                return;
            }

            var item = lvProcessors.SelectedItems[0];
            if (!processors.TryGetValue(lvProcessors.SelectedItems[0].Group.Name ?? String.Empty, out var processor))
                return;

            selectedProcessor = processor;
            selectedTarget = selectedProcessor.GetInfoItem(item.Name);
            propertyGrid1.SelectedObject = selectedProcessor;
            propertyGrid2.SelectedObject = selectedTarget;

            LoadSources(selectedTarget);
        }

        private void añadirPersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewPersona();
        }

        private void añadirProcesadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewProcessor();
        }

        private void origenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedTarget is null || selectedProcessor is null)
                return;

            using var frm = new Dialogs.OrigenForm(selectedProcessor);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var source = frm.GetSelectedSource(selectedTarget);

                // TEMP: TESTING Visualizations
                switch (frm.SelectedType)
                {
                    case SpecializedInfoSources.Wikipedia:
                        source.Container.VisualizationHandlers.Add(new WikipediaVisualizationHandler<WikipediaInfoSource>((WikipediaInfoSource) source));
                        break;
                    case SpecializedInfoSources.OpenWeather:
                        source.Container.VisualizationHandlers.Add(new OpenWeatherVisualizationHandler<OpenWeatherInfoSource>((OpenWeatherInfoSource)source));
                        break;
                    case SpecializedInfoSources.AEMET:
                        source.Container.VisualizationHandlers.Add(new AEMETVisualizationHandler<AEMETInfoSource>((AEMETInfoSource)source));
                        break;
                }

                selectedTarget.Sources.Add(source);
                ListProcessors();
            }
        }

        private void abrirToolStripButton_Click(object sender, EventArgs e)
        {
            if (selectedTarget is not null)
            {
                WindowManager.Instance.ShowForm(WindowManager.AvailableForm.InfoItemForm, selectedTarget.Id.ToString(), selectedTarget);
            }
        }
    }
}
