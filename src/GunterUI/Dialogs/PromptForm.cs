namespace GunterUI.Dialogs
{
    public partial class PromptForm : Form
    {

        public string Title { get; set; }
        public string Label { get; set; }
        public string Value { get; set; }

        public PromptForm(string title, string label, string value)
        {
            InitializeComponent();
            Title = title;
            Label = label;
            Value = value;
            txtTextbox.Text = value;
            lblText.Text = label;
            this.Text = title;
        }

        public PromptForm()
        {
            InitializeComponent();
            Title = string.Empty;
            Label = string.Empty;
            Value = string.Empty;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            Value = txtTextbox.Text;
        }
    }
}
