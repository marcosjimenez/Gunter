using Gunter.Core;
using Gunter.Core.Contracts;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Dialogs
{
    public partial class VisualizationForm : Form
    {
        public object Destination { get; set; } = new object();

        public IGunterVisualizationHandler? Visualization { get; private set; }

        private readonly List<IGunterVisualizationHandler> handlers = new();

        public VisualizationForm()
        {
            InitializeComponent();
        }

        private void LoadList()
        {

            lvVisualizations.BeginUpdate();
            lvVisualizations.Items.Clear();
            handlers.Clear();

            var availableHandlers = GunterEnvironmentHelper.Instance.GetAvailableVisualizationHandlers();

            foreach (var item in availableHandlers)
            {
                IGunterVisualizationHandler? instance = null;
                try
                {
                    instance = GunterEnvironmentHelper.Instance
                        .CreateInstance<IGunterVisualizationHandler>(GunterEnvironmentHelper.GetSystemTypeName(item), Destination);
                }
                catch
                {

                }

                if (instance is null)
                    continue;

                if (instance.CanHandle((IGunterInfoSource)Destination))
                { 
                    var lvItem = lvVisualizations.Items.Add(instance.Name, instance.Name);
                    lvItem.Tag = instance;
                }
            }

            lvVisualizations.EndUpdate();
        }

        private void VisualizationForm_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            
        }

        private void lvVisualizations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvVisualizations.SelectedItems.Count == 0)
            {
                pictureBox1.Image = null;
                Visualization = null;
                return;
            }

            var visualization = (IGunterVisualizationHandler)lvVisualizations.SelectedItems[0].Tag;
            var infoSource = (IGunterInfoSource)Destination;
            specialPropertiesViewer1.SetProperties(infoSource.SpecialProperties);
            infoSource.Update();

            var image = Image.FromStream(new MemoryStream(visualization.GetImage()));
            pictureBox1.Image = image;
            Visualization = visualization;
        }
    }
}
