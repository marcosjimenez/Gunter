namespace Dialogs
{
    public partial class ProjectDialog : Form
    {
        public string ProjectId { get; set; } = Guid.NewGuid().ToString();
        public string ProjectFolderId { get; set; } = string.Empty;
        public string ProjectFolderName { get; set; } = string.Empty;
        public string ProjectName { get; set; } = "New Project";
        public string ProjectDescription { get; set; } = "Project description";
        public byte[] ProjectImage { get; set; } = { };

        public ProjectDialog()
        {
            InitializeComponent();
        }

        private void ProjectDialog_Load(object sender, EventArgs e)
        {
            txtId.Text = ProjectId;
            txtName.Text = ProjectName;
            txtFolder.Text = ProjectFolderName;
            txtDescription.Text = ProjectDescription;
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {

            ProjectName = txtName.Text;
            ProjectDescription = txtDescription.Text;

            this.Close();
        }
    }
}
