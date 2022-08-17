using Gunter.Core.Cache;
using static System.Net.Mime.MediaTypeNames;

namespace Dialogs
{
    public partial class OptionsDialog : Form
    {
        public Models.GunterWinUIOptions Options { get; set; } = new();

        public OptionsDialog()
        {
            InitializeComponent();
        }

        private void cmdSelectGenerationDirectory_Click(object sender, EventArgs e)
        {
            var button = (sender as Button);
            if (button is null)
                return;

            var dirIndex = int.Parse(button.Tag.ToString() ?? "0");


            using var dlg = new FolderBrowserDialog
            {

            };


            if (dlg.ShowDialog() != DialogResult.OK)
                return;


            switch(dirIndex)
            {
                case 0:
                    txtGenerationDirectory.Text = dlg.SelectedPath;
                    break;
                case 1:
                    txtPluginDirectory.Text = dlg.SelectedPath;
                    break;
                case 2:
                    txtIODirectory.Text = dlg.SelectedPath;
                    break;
            }
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {
            chkFileSytemAutosave.Checked = Options.GunterDefaults.FileSystem.AutoSave;
            chkFileSytemVersioning.Checked = Options.GunterDefaults.FileSystem.Versioning;
            txtPluginDirectory.Text = Options.GunterDefaults.PluginDirectory;
            txtGenerationDirectory.Text = Options.GunterDefaults.GenerationDirectory;
            txtIODirectory.Text = Options.GunterDefaults.IODirectory;
            cboFilesystemType.SelectedIndex = Options.GunterDefaults.FileSystem.CacheType;
            chkAutoLoadWindoLayout.Checked = Options.MainLayoutAutoPersist;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            Options.GunterDefaults.FileSystem.AutoSave = chkFileSytemAutosave.Checked;
            Options.GunterDefaults.FileSystem.Versioning = chkFileSytemVersioning.Checked;
            Options.GunterDefaults.PluginDirectory = txtPluginDirectory.Text;
            Options.GunterDefaults.GenerationDirectory = txtGenerationDirectory.Text;
            Options.GunterDefaults.IODirectory = txtIODirectory.Text;
            Options.GunterDefaults.FileSystem.CacheType = cboFilesystemType.SelectedIndex;
            Options.MainLayoutAutoPersist = chkAutoLoadWindoLayout.Checked;
        }
    }
}
