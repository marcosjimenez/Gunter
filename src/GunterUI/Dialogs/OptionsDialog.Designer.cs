namespace Dialogs
{
    partial class OptionsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsDialog));
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkAutoLoadWindoLayout = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFileSytemAutosave = new System.Windows.Forms.CheckBox();
            this.chkFileSytemVersioning = new System.Windows.Forms.CheckBox();
            this.cboFilesystemType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdSelectIODirectory = new System.Windows.Forms.Button();
            this.cmdSelectPluginDirectory = new System.Windows.Forms.Button();
            this.txtIODirectory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPluginDirectory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdSelectGenerationDirectory = new System.Windows.Forms.Button();
            this.txtGenerationDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(514, 449);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(139, 33);
            this.cmdCancel.TabIndex = 10;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOk
            // 
            this.cmdOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOk.Location = new System.Drawing.Point(369, 449);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(139, 33);
            this.cmdOk.TabIndex = 9;
            this.cmdOk.Text = "&Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            this.cmdOk.Click += new System.EventHandler(this.cmdOk_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(641, 431);
            this.tabControl1.TabIndex = 11;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkAutoLoadWindoLayout);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(633, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Interface";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkAutoLoadWindoLayout
            // 
            this.chkAutoLoadWindoLayout.AutoSize = true;
            this.chkAutoLoadWindoLayout.Location = new System.Drawing.Point(35, 27);
            this.chkAutoLoadWindoLayout.Name = "chkAutoLoadWindoLayout";
            this.chkAutoLoadWindoLayout.Size = new System.Drawing.Size(271, 24);
            this.chkAutoLoadWindoLayout.TabIndex = 0;
            this.chkAutoLoadWindoLayout.Text = "Auto load/save last layout at startup";
            this.chkAutoLoadWindoLayout.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.cmdSelectIODirectory);
            this.tabPage2.Controls.Add(this.cmdSelectPluginDirectory);
            this.tabPage2.Controls.Add(this.txtIODirectory);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtPluginDirectory);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cmdSelectGenerationDirectory);
            this.tabPage2.Controls.Add(this.txtGenerationDirectory);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(633, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Gunter defaults";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkFileSytemAutosave);
            this.groupBox1.Controls.Add(this.chkFileSytemVersioning);
            this.groupBox1.Controls.Add(this.cboFilesystemType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(6, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 102);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FileSystem";
            // 
            // chkFileSytemAutosave
            // 
            this.chkFileSytemAutosave.AutoSize = true;
            this.chkFileSytemAutosave.Checked = true;
            this.chkFileSytemAutosave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFileSytemAutosave.Enabled = false;
            this.chkFileSytemAutosave.Location = new System.Drawing.Point(463, 72);
            this.chkFileSytemAutosave.Name = "chkFileSytemAutosave";
            this.chkFileSytemAutosave.Size = new System.Drawing.Size(94, 24);
            this.chkFileSytemAutosave.TabIndex = 5;
            this.chkFileSytemAutosave.Text = "AutoSave";
            this.chkFileSytemAutosave.UseVisualStyleBackColor = true;
            // 
            // chkFileSytemVersioning
            // 
            this.chkFileSytemVersioning.AutoSize = true;
            this.chkFileSytemVersioning.Checked = true;
            this.chkFileSytemVersioning.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFileSytemVersioning.Enabled = false;
            this.chkFileSytemVersioning.Location = new System.Drawing.Point(463, 26);
            this.chkFileSytemVersioning.Name = "chkFileSytemVersioning";
            this.chkFileSytemVersioning.Size = new System.Drawing.Size(100, 24);
            this.chkFileSytemVersioning.TabIndex = 4;
            this.chkFileSytemVersioning.Text = "Versioning";
            this.chkFileSytemVersioning.UseVisualStyleBackColor = true;
            // 
            // cboFilesystemType
            // 
            this.cboFilesystemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFilesystemType.FormattingEnabled = true;
            this.cboFilesystemType.Items.AddRange(new object[] {
            "JsonDiskWriter",
            "Redis",
            "Underlying filesystem"});
            this.cboFilesystemType.Location = new System.Drawing.Point(6, 58);
            this.cboFilesystemType.Name = "cboFilesystemType";
            this.cboFilesystemType.Size = new System.Drawing.Size(321, 28);
            this.cboFilesystemType.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Cache Type:";
            // 
            // cmdSelectIODirectory
            // 
            this.cmdSelectIODirectory.Image = ((System.Drawing.Image)(resources.GetObject("cmdSelectIODirectory.Image")));
            this.cmdSelectIODirectory.Location = new System.Drawing.Point(591, 175);
            this.cmdSelectIODirectory.Name = "cmdSelectIODirectory";
            this.cmdSelectIODirectory.Size = new System.Drawing.Size(36, 27);
            this.cmdSelectIODirectory.TabIndex = 5;
            this.cmdSelectIODirectory.Tag = "2";
            this.cmdSelectIODirectory.UseVisualStyleBackColor = true;
            this.cmdSelectIODirectory.Click += new System.EventHandler(this.cmdSelectGenerationDirectory_Click);
            // 
            // cmdSelectPluginDirectory
            // 
            this.cmdSelectPluginDirectory.Image = ((System.Drawing.Image)(resources.GetObject("cmdSelectPluginDirectory.Image")));
            this.cmdSelectPluginDirectory.Location = new System.Drawing.Point(591, 102);
            this.cmdSelectPluginDirectory.Name = "cmdSelectPluginDirectory";
            this.cmdSelectPluginDirectory.Size = new System.Drawing.Size(36, 27);
            this.cmdSelectPluginDirectory.TabIndex = 5;
            this.cmdSelectPluginDirectory.Tag = "1";
            this.cmdSelectPluginDirectory.UseVisualStyleBackColor = true;
            this.cmdSelectPluginDirectory.Click += new System.EventHandler(this.cmdSelectGenerationDirectory_Click);
            // 
            // txtIODirectory
            // 
            this.txtIODirectory.Location = new System.Drawing.Point(6, 175);
            this.txtIODirectory.Name = "txtIODirectory";
            this.txtIODirectory.ReadOnly = true;
            this.txtIODirectory.Size = new System.Drawing.Size(579, 27);
            this.txtIODirectory.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "IO Directory:";
            // 
            // txtPluginDirectory
            // 
            this.txtPluginDirectory.Location = new System.Drawing.Point(6, 102);
            this.txtPluginDirectory.Name = "txtPluginDirectory";
            this.txtPluginDirectory.ReadOnly = true;
            this.txtPluginDirectory.Size = new System.Drawing.Size(579, 27);
            this.txtPluginDirectory.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Plugin directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Plugin directory:";
            // 
            // cmdSelectGenerationDirectory
            // 
            this.cmdSelectGenerationDirectory.Image = ((System.Drawing.Image)(resources.GetObject("cmdSelectGenerationDirectory.Image")));
            this.cmdSelectGenerationDirectory.Location = new System.Drawing.Point(591, 38);
            this.cmdSelectGenerationDirectory.Name = "cmdSelectGenerationDirectory";
            this.cmdSelectGenerationDirectory.Size = new System.Drawing.Size(36, 27);
            this.cmdSelectGenerationDirectory.TabIndex = 2;
            this.cmdSelectGenerationDirectory.Tag = "0";
            this.cmdSelectGenerationDirectory.UseVisualStyleBackColor = true;
            this.cmdSelectGenerationDirectory.Click += new System.EventHandler(this.cmdSelectGenerationDirectory_Click);
            // 
            // txtGenerationDirectory
            // 
            this.txtGenerationDirectory.Location = new System.Drawing.Point(6, 38);
            this.txtGenerationDirectory.Name = "txtGenerationDirectory";
            this.txtGenerationDirectory.ReadOnly = true;
            this.txtGenerationDirectory.Size = new System.Drawing.Size(579, 27);
            this.txtGenerationDirectory.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generation directory:";
            // 
            // OptionsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 494);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsDialog";
            this.Text = "OptionsDialog";
            this.Load += new System.EventHandler(this.OptionsDialog_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button cmdCancel;
        private Button cmdOk;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private CheckBox chkAutoLoadWindoLayout;
        private TabPage tabPage2;
        private Button cmdSelectGenerationDirectory;
        private TextBox txtGenerationDirectory;
        private Label label1;
        private Button cmdSelectPluginDirectory;
        private TextBox txtPluginDirectory;
        private Label label2;
        private Button cmdSelectIODirectory;
        private TextBox txtIODirectory;
        private Label label4;
        private Label label3;
        private GroupBox groupBox1;
        private ComboBox cboFilesystemType;
        private Label label5;
        private CheckBox chkFileSytemAutosave;
        private CheckBox chkFileSytemVersioning;
    }
}