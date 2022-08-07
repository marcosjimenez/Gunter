using Gunter.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GunterUI
{
    public partial class InfoSourceViewer : Form
    {
        private readonly IGunterInfoSource _infoSource;

        public InfoSourceViewer()
        {
            InitializeComponent();
        }

        public InfoSourceViewer(IGunterInfoSource infoSouce)
        {
            _infoSource = infoSouce;
            InitializeComponent();
        }

        private void LoadData()
        {
            if (_infoSource is null)
                return;

            lblName.Text = _infoSource.Name;
        }

        private void InfoSourceViewer_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
