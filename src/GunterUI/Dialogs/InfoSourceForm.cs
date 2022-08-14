using Gunter.Core;
using Gunter.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace Dialogs
{
    public partial class InfoSourceForm : Form
    {
        public object Destination { get; set; } = new object();

        public IGunterInfoSource? Visualization { get; private set; }

        private readonly List<IGunterInfoSource> handlers = new();

        public InfoSourceForm()
        {
            InitializeComponent();
        }

        private void LoadList()
        {

            lvSources.BeginUpdate();
            lvSources.Items.Clear();
            handlers.Clear();

            //var availableHandlers = GunterEnvironmentHelper.Instance.GetAvailableVisualizationHandlers();

            //foreach (var item in availableHandlers)
            //{
            //    IGunterInfoSource? instance = null;
            //    try
            //    {
            //        instance = GunterEnvironmentHelper.Instance
            //            .CreateInstance<IGunterInfoSource>(GunterEnvironmentHelper.GetSystemTypeName(item), Destination);
            //    }
            //    catch
            //    {

            //    }

            //    if (instance is null)
            //        continue;

            //    if (instance.CanHandle((IGunterInfoSource)Destination))
            //    {
            //        var lvItem = lvSources.Items.Add(instance.Name, instance.Name);
            //        lvItem.Tag = instance;
            //    }
            //}

            lvSources.EndUpdate();
        }

        private void InfoSourceForm_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        //private void lvSources_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (lvSources.SelectedItems.Count == 0)
        //    {
        //        Visualization = null;
        //        return;
        //    }

        //    var visualization = (IGunterInfoSource)lvSources.SelectedItems[0].Tag;
        //    var infoSource = (IGunterInfoItem)Destination;
        //    specialPropertiesViewer1.SetProperties(infoSource.SpecialProperties);
        //    infoSource.Update();

        //    var image = Image.FromStream(new MemoryStream(visualization.GetImage()));
        //    pictureBox1.Image = image;
        //    Visualization = visualization;
        //}
    }
}
