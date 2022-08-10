using ZTn.Json.JsonTreeView.Controls;

namespace Controls
{
    partial class JsonViewer
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JsonViewer));
            this.jsonTreeViewSplitContainer = new System.Windows.Forms.SplitContainer();
            this.jTokenTree = new ZTn.Json.JsonTreeView.Controls.JTokenTreeUserControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.jsonValueTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.jsonTypeComboBox = new System.Windows.Forms.ComboBox();
            this.jsonValueLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.newtonsoftJsonTypeTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.formMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newJsonObjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newJsonArrayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutJsonEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guiStatusStrip = new System.Windows.Forms.StatusStrip();
            this.actionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.jsonStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.jsonTreeViewSplitContainer)).BeginInit();
            this.jsonTreeViewSplitContainer.Panel1.SuspendLayout();
            this.jsonTreeViewSplitContainer.Panel2.SuspendLayout();
            this.jsonTreeViewSplitContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.formMenuStrip.SuspendLayout();
            this.guiStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // jsonTreeViewSplitContainer
            // 
            this.jsonTreeViewSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jsonTreeViewSplitContainer.Location = new System.Drawing.Point(0, 37);
            this.jsonTreeViewSplitContainer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.jsonTreeViewSplitContainer.Name = "jsonTreeViewSplitContainer";
            // 
            // jsonTreeViewSplitContainer.Panel1
            // 
            this.jsonTreeViewSplitContainer.Panel1.Controls.Add(this.jTokenTree);
            this.jsonTreeViewSplitContainer.Panel1MinSize = 200;
            // 
            // jsonTreeViewSplitContainer.Panel2
            // 
            this.jsonTreeViewSplitContainer.Panel2.BackColor = System.Drawing.Color.Transparent;
            this.jsonTreeViewSplitContainer.Panel2.Controls.Add(this.panel2);
            this.jsonTreeViewSplitContainer.Panel2.Controls.Add(this.panel1);
            this.jsonTreeViewSplitContainer.Panel2MinSize = 320;
            this.jsonTreeViewSplitContainer.Size = new System.Drawing.Size(662, 419);
            this.jsonTreeViewSplitContainer.SplitterDistance = 337;
            this.jsonTreeViewSplitContainer.SplitterWidth = 5;
            this.jsonTreeViewSplitContainer.TabIndex = 8;
            // 
            // jTokenTree
            // 
            this.jTokenTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jTokenTree.CollapsedFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.jTokenTree.ExpandedFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.jTokenTree.Location = new System.Drawing.Point(4, 5);
            this.jTokenTree.Margin = new System.Windows.Forms.Padding(8, 9, 8, 9);
            this.jTokenTree.Name = "jTokenTree";
            this.jTokenTree.Size = new System.Drawing.Size(329, 410);
            this.jTokenTree.TabIndex = 2;
            this.jTokenTree.AfterSelect += new System.EventHandler<ZTn.Json.JsonTreeView.AfterSelectEventArgs>(this.jTokenTree_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.jsonValueTextBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 154);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(320, 265);
            this.panel2.TabIndex = 1;
            // 
            // jsonValueTextBox
            // 
            this.jsonValueTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jsonValueTextBox.Location = new System.Drawing.Point(0, 0);
            this.jsonValueTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.jsonValueTextBox.Name = "jsonValueTextBox";
            this.jsonValueTextBox.Size = new System.Drawing.Size(320, 265);
            this.jsonValueTextBox.TabIndex = 15;
            this.jsonValueTextBox.Text = "";
            this.jsonValueTextBox.TextChanged += new System.EventHandler(this.jsonValueTextBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.jsonTypeComboBox);
            this.panel1.Controls.Add(this.jsonValueLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.newtonsoftJsonTypeTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 154);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(215, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(632, 410);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // jsonTypeComboBox
            // 
            this.jsonTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.jsonTypeComboBox.Enabled = false;
            this.jsonTypeComboBox.FormattingEnabled = true;
            this.jsonTypeComboBox.Location = new System.Drawing.Point(4, 91);
            this.jsonTypeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.jsonTypeComboBox.Name = "jsonTypeComboBox";
            this.jsonTypeComboBox.Size = new System.Drawing.Size(204, 28);
            this.jsonTypeComboBox.TabIndex = 18;
            // 
            // jsonValueLabel
            // 
            this.jsonValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.jsonValueLabel.AutoSize = true;
            this.jsonValueLabel.Location = new System.Drawing.Point(4, 125);
            this.jsonValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.jsonValueLabel.Name = "jsonValueLabel";
            this.jsonValueLabel.Size = new System.Drawing.Size(84, 20);
            this.jsonValueLabel.TabIndex = 17;
            this.jsonValueLabel.Text = "JSON Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 5);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "NewtonSoft.Json Type";
            // 
            // newtonsoftJsonTypeTextBox
            // 
            this.newtonsoftJsonTypeTextBox.Location = new System.Drawing.Point(4, 29);
            this.newtonsoftJsonTypeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.newtonsoftJsonTypeTextBox.Name = "newtonsoftJsonTypeTextBox";
            this.newtonsoftJsonTypeTextBox.ReadOnly = true;
            this.newtonsoftJsonTypeTextBox.Size = new System.Drawing.Size(204, 27);
            this.newtonsoftJsonTypeTextBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "JSON Type";
            // 
            // formMenuStrip
            // 
            this.formMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.formMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.formMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.formMenuStrip.Name = "formMenuStrip";
            this.formMenuStrip.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.formMenuStrip.Size = new System.Drawing.Size(662, 30);
            this.formMenuStrip.TabIndex = 0;
            this.formMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newJsonObjectToolStripMenuItem,
            this.newJsonArrayToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShowShortcutKeys = false;
            this.newToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // newJsonObjectToolStripMenuItem
            // 
            this.newJsonObjectToolStripMenuItem.Name = "newJsonObjectToolStripMenuItem";
            this.newJsonObjectToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.newJsonObjectToolStripMenuItem.Text = "New Json &Object";
            this.newJsonObjectToolStripMenuItem.Click += new System.EventHandler(this.newJsonObjectToolStripMenuItem_Click);
            // 
            // newJsonArrayToolStripMenuItem
            // 
            this.newJsonArrayToolStripMenuItem.Name = "newJsonArrayToolStripMenuItem";
            this.newJsonArrayToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.newJsonArrayToolStripMenuItem.Text = "New Json &Array";
            this.newJsonArrayToolStripMenuItem.Click += new System.EventHandler(this.newJsonArrayToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutJsonEditorToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(30, 24);
            this.aboutToolStripMenuItem.Text = "?";
            // 
            // aboutJsonEditorToolStripMenuItem
            // 
            this.aboutJsonEditorToolStripMenuItem.Name = "aboutJsonEditorToolStripMenuItem";
            this.aboutJsonEditorToolStripMenuItem.Size = new System.Drawing.Size(209, 26);
            this.aboutJsonEditorToolStripMenuItem.Text = "About Json Editor";
            this.aboutJsonEditorToolStripMenuItem.Click += new System.EventHandler(this.aboutJsonEditorToolStripMenuItem_Click);
            // 
            // guiStatusStrip
            // 
            this.guiStatusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.guiStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.actionStatusLabel,
            this.toolStripStatusLabel1,
            this.jsonStatusLabel});
            this.guiStatusStrip.Location = new System.Drawing.Point(0, 469);
            this.guiStatusStrip.Name = "guiStatusStrip";
            this.guiStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.guiStatusStrip.Size = new System.Drawing.Size(662, 26);
            this.guiStatusStrip.TabIndex = 9;
            this.guiStatusStrip.Text = "statusStrip";
            // 
            // actionStatusLabel
            // 
            this.actionStatusLabel.Name = "actionStatusLabel";
            this.actionStatusLabel.Size = new System.Drawing.Size(49, 20);
            this.actionStatusLabel.Text = "Status";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(516, 20);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // jsonStatusLabel
            // 
            this.jsonStatusLabel.Name = "jsonStatusLabel";
            this.jsonStatusLabel.Size = new System.Drawing.Size(77, 20);
            this.jsonStatusLabel.Text = "JsonStatus";
            // 
            // JsonViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guiStatusStrip);
            this.Controls.Add(this.jsonTreeViewSplitContainer);
            this.Controls.Add(this.formMenuStrip);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "JsonViewer";
            this.Size = new System.Drawing.Size(662, 495);
            this.jsonTreeViewSplitContainer.Panel1.ResumeLayout(false);
            this.jsonTreeViewSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.jsonTreeViewSplitContainer)).EndInit();
            this.jsonTreeViewSplitContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.formMenuStrip.ResumeLayout(false);
            this.formMenuStrip.PerformLayout();
            this.guiStatusStrip.ResumeLayout(false);
            this.guiStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.MenuStrip formMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.SplitContainer jsonTreeViewSplitContainer;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newJsonObjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newJsonArrayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutJsonEditorToolStripMenuItem;
        private JTokenTreeUserControl jTokenTree;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.StatusStrip guiStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel actionStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel jsonStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox jsonValueTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox jsonTypeComboBox;
        public System.Windows.Forms.Label jsonValueLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox newtonsoftJsonTypeTextBox;
        private System.Windows.Forms.Label label1;

        #endregion

        private PictureBox pictureBox1;
    }
}
