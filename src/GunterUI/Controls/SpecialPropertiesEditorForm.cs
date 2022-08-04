using Gunter.Extensions.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GunterUI.Controls
{
    public partial class SpecialPropertiesEditorForm : Form
    {
        public SpecialProperties SpecialProperties { get; set; }

        public SpecialPropertiesEditorForm()
        {
            InitializeComponent();
        }

        private void SpecialPropertiesEditorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
