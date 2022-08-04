using GunterUI.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GunterUI
{
    public partial class MdiMain : Form
    {
        private int windowCounter = 1;
        public MdiMain()
        {
            InitializeComponent();
            WindowManager.Instance.MainForm = this;
        }

        private void NewProcessor()
        {
            var processor = new Gunter.Core.GunterProcessor();
            processor.Name = $"Processor {windowCounter++}";
            WindowManager.Instance.ShowForm(WindowManager.AvailableForm.ProcessForm, processor.Id.ToString(), processor);
        }

        private void MdiMain_Load(object sender, EventArgs e)
        {
            NewProcessor();
        }

        private void nuevoToolStripButton_Click(object sender, EventArgs e)
        {
            NewProcessor();
        }
    }
}
