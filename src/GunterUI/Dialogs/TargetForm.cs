﻿using Gunter.Core.Contracts;

namespace GunterUI.Dialogs
{
    public partial class TargetForm : Form
    {
        public IGunterInfoItem Target { get; set; }

        private readonly IGunterProcessor _processor;

        public TargetForm(IGunterProcessor processor)
        {
            _processor = processor;
            Target = processor.CreateInfoItem(string.Empty);
            InitializeComponent();
        }

        public TargetForm()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                return;
            }

            this.Target = _processor.CreateInfoItem(textBox1.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
