using Gunter.Core.Contracts;
using Gunter.Extensions.InfoSources;
using Gunter.Extensions.InfoSources.Specialized;
using Gunter.Core;
using System.Runtime.CompilerServices;
using Gunter.Core.Models;

namespace GunterUI.Dialogs
{
    public partial class OrigenForm : Form
    {

        public IGunterInfoSource? SelectedType { get; set; }
        public SpecialProperties SpecialProperties { get; set; }

        private readonly IGunterProcessor _processor;

        public OrigenForm(IGunterProcessor processor)
        {
            _processor = processor;
            SelectedType = null;
            SpecialProperties = new SpecialProperties();
            InitializeComponent();
        }

        public OrigenForm()
        {
            SelectedType = null;
            SpecialProperties = new SpecialProperties();
            InitializeComponent();
        }

        public IGunterInfoSource? GetSelectedSource(IGunterInfoItem item)
        {
            var retVal = cboTipo.SelectedValue as IGunterInfoSource;
            retVal?.SetSpecialProperties(specialPropertiesViewer1.SpecialProperties);

            return retVal;
        }


        private void LoadList()
        {
            var availableInfoSources = GunterEnvironmentHelper.Instance.GetAvailableInfoSources();
            cboTipo.Items.Clear();

            var instances = new List<InfoSourceDropDownItem>();
            foreach (var item in availableInfoSources)
            {
                IGunterInfoSource? instance = null;
                try
                {
                    instance = GunterEnvironmentHelper.Instance
                        .CreateInstance<IGunterInfoSource>(GunterEnvironmentHelper.GetSystemTypeName(item), null);
                    if (instance is not null)
                        instances.Add(new InfoSourceDropDownItem
                        {
                            Id = instance.Id,
                            Name = instance.Name,
                            InfoSource = instance
                        });
                }
                catch
                {

                }

                if (instance is null)
                    continue;
            }

            cboTipo.DataSource = instances; 
            cboTipo.DisplayMember = "Name";
            cboTipo.ValueMember = "InfoSource";
            cboTipo.Refresh();
        }

        private void LoadProperties()
        {
            var value = cboTipo.Text;
            if (string.IsNullOrWhiteSpace(value))
                return;

            var infoSource = cboTipo.SelectedValue as IGunterInfoSource;
            if (infoSource is not null)
                specialPropertiesViewer1.SetProperties(infoSource.GetMandatoryParams());
        }

        private void OrigenForm_Load(object sender, EventArgs e)
        {
            LoadList();
            LoadProperties();
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProperties();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            SelectedType = cboTipo.SelectedValue as IGunterInfoSource;
            if (SelectedType is null)
                return; 

            SpecialProperties = (SpecialProperties)specialPropertiesViewer1.SpecialProperties;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
    public class InfoSourceDropDownItem
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public IGunterInfoSource? InfoSource { get; set; } = null;
    }

}
