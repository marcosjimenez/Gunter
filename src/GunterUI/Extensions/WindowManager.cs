using Contracts;
using Gunter.Core.Contracts;
using Gunter.Infrastructure.Cache;
using GunterUI.ToolBox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunterUI.Extensions
{
    public class WindowManager
    {
        public enum AvailableForm
        {
            ProcessForm = 10,
            InfoItemForm = 20,
            InfoSourceForm = 30,
            WebViewer = 40
        }

        private readonly Dictionary<string, Form> _forms;
        
        public MdiMain MainForm { get; set; }

        private static readonly Lazy<WindowManager> lazy = new Lazy<WindowManager>(() => new WindowManager());

        public static WindowManager Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        private WindowManager()
        {
            _forms = new();
        }


        // TEMP
        public void ShowForm(AvailableForm availableForm, string id, object data = null)
        {
            if (data is null)
                return;

            if (_forms.TryGetValue(id, out Form? form))
            {

                form.BringToFront();
                form.Update();

                var withExtraData = form as IDataWindow;
                withExtraData?.SetExtraData(data);
            }
            else
            {
                switch (availableForm)
                {
                    case AvailableForm.InfoItemForm:
                        form = new InfoItemViewer((IGunterInfoItem)data);
                        break;
                    case AvailableForm.ProcessForm:
                        form = new ProcessorForm((IGunterProcessor)data);
                        break;
                    case AvailableForm.InfoSourceForm:
                        form = new InfoSourceViewer((IInfoSource)data);
                        break;
                    case AvailableForm.WebViewer:
                        form = new WebViewForm(data.ToString() ?? string.Empty);
                        break;
                    default:
                        form = new Form();
                        break;
                }
                form.FormClosing += (obj, e) => { _forms.Remove(id); };
                form.MdiParent = MainForm;
                form.Show();
                _forms.Add(id, form);
            }
        }
    }
}
