using Gunter.Core.Constants;
using Gunter.Core.Contracts;
using Gunter.Core.Infrastructure.Log;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Controls
{
    public partial class InfoSourceViewer : UserControl
    {
        public IGunterInfoSource? InfoSource { get; set; }

        public InfoSourceViewer()
        {
            InitializeComponent();
        }

        public InfoSourceViewer(IGunterInfoSource infoSource)
        {
            InitializeComponent();
            InfoSource = infoSource;
            LoadInfoItem();
        }

        private void LoadInfoItem()
        {
            if (InfoSource is null)
                return;

            txtId.Text = InfoSource.Id;
            txtBaseClass.Text = IdentificationConstants.CLASSID.ClassIdNameOf(InfoSource.ClassId);
            txtNombre.Text = InfoSource.Name;
            txtCategory.Text = InfoSource.Category;
            txtSubCategory.Text = InfoSource.SubCategory;
            specialPropertiesViewer1.SetProperties(InfoSource.SpecialProperties);

            var data = InfoSource.GetLastItem();
            if (data is null)
                return;

            try
            {
                string json = JsonConvert.SerializeObject(data);
                JObject obj = JObject.Parse(json);

                jsonViewer.LoadObject(data);
            }
            catch (Exception ex)
            {
                GunterLog.Instance.Log(this, ex.Message, GunterLogItem.GunterLogItemSeverity.Error, InfoSource.Id);

            }
        }

        private void specialPropertiesViewer1_OnPropertyChanged(object sender, GunterUI.SpecialPropertiesViewer.PropertyUpdatedEventArgs e)
        {
            InfoSource?.SetSpecialProperties(specialPropertiesViewer1.SpecialProperties);
        }
    }
}
