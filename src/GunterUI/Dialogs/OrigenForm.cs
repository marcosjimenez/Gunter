using Gunter.Extensions.Common;
using Gunter.Core.Contracts;
using Gunter.Extensions.InfoSources;
using Gunter.Extensions.InfoSources.Specialized;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GunterUI.Dialogs
{
    public partial class OrigenForm : Form
    {

        public string SelectedType { get; set; }
        public SpecialProperties SpecialProperties { get; set; }

        private readonly IGunterProcessor _processor;

        public OrigenForm(IGunterProcessor processor)
        {
            _processor = processor;
            SelectedType = string.Empty;
            SpecialProperties = new SpecialProperties();
            InitializeComponent();
        }

        public OrigenForm()
        {
            SelectedType = string.Empty;
            SpecialProperties = new SpecialProperties();
            InitializeComponent();
        }

        public IGunterInfoSource GetSelectedSource(IGunterInfoItem item)
        {
            IGunterInfoSource retVal;
            var specialProperties = specialPropertiesViewer1.SpecialProperties;

            var id = Guid.NewGuid().ToString();
            switch (cboTipo.Text)
            {
                case SpecializedInfoSources.Wikipedia:
                    retVal = new WikipediaInfoSource(item, id, cboTipo.Text);
                    break;
                case SpecializedInfoSources.OpenWeather:
                    retVal = new OpenWeatherInfoSource(item, id, cboTipo.Text);
                    break;
                case SpecializedInfoSources.AEMET:
                    retVal = new AEMETInfoSource(item, id, cboTipo.Text);
                    break;
                case SpecializedInfoSources.GunterBot:
                    retVal = new GunterBotInfoSource(item, id, cboTipo.Text);
                    break;
                case SpecializedInfoSources.Twitter:
                    retVal = new TwitterInfoSource(item, id, cboTipo.Text);
                    break;
                default:
                    retVal = new AEMETInfoSource(item, id, cboTipo.Text);
                    break;
            }
            retVal.SetSpecialProperties(specialPropertiesViewer1.SpecialProperties);
            return retVal;
        }

        private void OrigenForm_Load(object sender, EventArgs e)
        {
            foreach(var item in SpecializedInfoSources.GetList())
            {
                cboTipo.Items.Add(item);
            }
            cboTipo.SelectedIndex = 0;
            SelectedType = cboTipo.SelectedText;
            specialPropertiesViewer1.SetProperties(SpecialProperties);
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = cboTipo.Text;
            if (string.IsNullOrWhiteSpace(value))
                return;

            switch (value)
            {
                case SpecializedInfoSources.Wikipedia:
                    specialPropertiesViewer1.SetProperties(new WikipediaInfoSource().GetMandatoryParams());
                    break;
                case SpecializedInfoSources.OpenWeather:
                    specialPropertiesViewer1.SetProperties(new OpenWeatherInfoSource().GetMandatoryParams());
                    break;
                case SpecializedInfoSources.AEMET:
                    specialPropertiesViewer1.SetProperties(new AEMETInfoSource().GetMandatoryParams());
                    break;
                case SpecializedInfoSources.GunterBot:
                    specialPropertiesViewer1.SetProperties(new GunterBotInfoSource().GetMandatoryParams());
                    break;
                case SpecializedInfoSources.Twitter:
                    specialPropertiesViewer1.SetProperties(new TwitterInfoSource().GetMandatoryParams());
                    break;
                default:
                    specialPropertiesViewer1.SetProperties(new SpecialProperties());
                    break;
            }
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            SelectedType = cboTipo.Text;
            if (string.IsNullOrWhiteSpace(SelectedType))
                return; 

            SpecialProperties = specialPropertiesViewer1.SpecialProperties;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
