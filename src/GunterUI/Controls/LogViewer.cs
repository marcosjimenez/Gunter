using GunterUI.Extensions;
using static Gunter.Core.Infrastructure.Log.GunterLogItem;

namespace Controls
{
    public partial class LogViewer : UserControl
    {
        public LogViewer()
        {
            InitializeComponent();
        }

        public void AppendText(string text) => AppendText(text, GunterLogItemSeverity.Information);

        public void AppendText(string text, GunterLogItemSeverity severity) => AppendText(text, SeverityColor(severity));

        public void AppendText(string text, (Color backColor, Color foreColor) colors)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)delegate
                {
                    appendText(text, colors);
                });
            else
                appendText(text, colors);

        }

        private void appendText(string text, (Color backColor, Color foreColor) colors)
        {
            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.SelectionLength = 0;

            txtLog.SelectionColor = colors.foreColor;
            txtLog.SelectionBackColor = colors.backColor;
            txtLog.AppendText(text);

            txtLog.SelectionStart = txtLog.TextLength;
            txtLog.SelectionLength = 0;
        }

        private (Color, Color) SeverityColor(GunterLogItemSeverity severity)
        {
            switch (severity)
            {
                case GunterLogItemSeverity.Warning:
                    return new(Color.OrangeRed, Color.White);
                case GunterLogItemSeverity.Error:
                    return new(txtLog.BackColor, Color.White);
                case GunterLogItemSeverity.Critical:
                    return new(Color.Red, Color.White);
                default:
                    return new(txtLog.BackColor, txtLog.ForeColor);
            }
        }

        private void cmdDeleteAll_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        private void LogViewer_Load(object sender, EventArgs e)
        {
            var values = (GunterLogItemSeverity[])Enum.GetValues(typeof(GunterLogItemSeverity));

            foreach (var item in values)
            {
                cboSeverity.Items.Add(item);
            }
            cboSeverity.SelectedIndex = 0;
        }

        private void cmdBuscar_Click(object sender, EventArgs e)
        {
            if(Prompt.ShowPromptDialog("Search text", "Search", string.Empty, out var newValue))
                txtLog.Find(newValue);
        }

        private void cmdFindNext_Click(object sender, EventArgs e)
        {
        }
    }
}
