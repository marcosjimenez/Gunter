using Gunter.Extensions.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace GunterUI.Controls
{

    [Editor(typeof(SpecialPropertiesEditor), typeof(UITypeEditor))]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class SpecialPropertiesModel
    {
        public SpecialProperties SpecialProperties { get; set; }
    }

    internal class SpecialPropertiesEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService svc = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            SpecialPropertiesModel model = value as SpecialPropertiesModel;
            if (svc != null && model != null)
            {
                using (SpecialPropertiesEditorForm form = new SpecialPropertiesEditorForm())
                {
                    form.SpecialProperties = model.SpecialProperties;
                    if (svc.ShowDialog(form) == DialogResult.OK)
                    {
                        model.SpecialProperties = form.SpecialProperties; // update object
                    }
                }
            }
            return value; // can also replace the wrapper object here
        }
    }
}
