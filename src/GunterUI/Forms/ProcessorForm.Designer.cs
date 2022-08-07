namespace GunterUI
{
    partial class ProcessorForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessorForm));
            this.imageListTasks = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.nuevoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.abrirToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.guardarToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.txtName = new System.Windows.Forms.ToolStripTextBox();
            this.cmdCopyId = new System.Windows.Forms.ToolStripButton();
            this.lblId = new System.Windows.Forms.ToolStripLabel();
            this.lvInfoItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmdContext = new System.Windows.Forms.Button();
            this.txtInfoItemName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtInfoItemId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvSources = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.cmdAddSource = new System.Windows.Forms.ToolStripButton();
            this.cmdEditSource = new System.Windows.Forms.ToolStripButton();
            this.cmdRemoveSource = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdRefreshSources = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.specialPropertiesViewer1 = new GunterUI.SpecialPropertiesViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListTasks
            // 
            this.imageListTasks.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListTasks.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTasks.ImageStream")));
            this.imageListTasks.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTasks.Images.SetKeyName(0, "Process");
            this.imageListTasks.Images.SetKeyName(1, "ProcedureWarning");
            this.imageListTasks.Images.SetKeyName(2, "StatusBarBuild1");
            this.imageListTasks.Images.SetKeyName(3, "StatusBarBuild2");
            this.imageListTasks.Images.SetKeyName(4, "StatusBarBuild3");
            this.imageListTasks.Images.SetKeyName(5, "StatusBarBuild4");
            this.imageListTasks.Images.SetKeyName(6, "StatusBarBuild5");
            this.imageListTasks.Images.SetKeyName(7, "StatusBarBuild6");
            this.imageListTasks.Images.SetKeyName(8, "StatusBarBuild7");
            this.imageListTasks.Images.SetKeyName(9, "StatusBarBuild8");
            this.imageListTasks.Images.SetKeyName(10, "StatusBarBuild9");
            this.imageListTasks.Images.SetKeyName(11, "StatusBarBuild10");
            this.imageListTasks.Images.SetKeyName(12, "StatusBarBuild11");
            this.imageListTasks.Images.SetKeyName(13, "StatusBarBuild12");
            this.imageListTasks.Images.SetKeyName(14, "StatusBarBuild13");
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripButton,
            this.abrirToolStripButton,
            this.guardarToolStripButton,
            this.toolStripSeparator,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.txtName,
            this.cmdCopyId,
            this.lblId});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(966, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // nuevoToolStripButton
            // 
            this.nuevoToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.nuevoToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("nuevoToolStripButton.Image")));
            this.nuevoToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.nuevoToolStripButton.Name = "nuevoToolStripButton";
            this.nuevoToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.nuevoToolStripButton.Text = "&Nuevo";
            this.nuevoToolStripButton.Click += new System.EventHandler(this.nuevoToolStripButton_Click);
            // 
            // abrirToolStripButton
            // 
            this.abrirToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.abrirToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripButton.Image")));
            this.abrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.abrirToolStripButton.Name = "abrirToolStripButton";
            this.abrirToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.abrirToolStripButton.Text = "&Abrir";
            // 
            // guardarToolStripButton
            // 
            this.guardarToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.guardarToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripButton.Image")));
            this.guardarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.guardarToolStripButton.Name = "guardarToolStripButton";
            this.guardarToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.guardarToolStripButton.Text = "&Guardar";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // txtName
            // 
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(220, 27);
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // cmdCopyId
            // 
            this.cmdCopyId.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmdCopyId.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdCopyId.Image = ((System.Drawing.Image)(resources.GetObject("cmdCopyId.Image")));
            this.cmdCopyId.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCopyId.Name = "cmdCopyId";
            this.cmdCopyId.Size = new System.Drawing.Size(29, 24);
            this.cmdCopyId.Text = "toolStripButton2";
            this.cmdCopyId.Click += new System.EventHandler(this.cmdCopyId_Click);
            // 
            // lblId
            // 
            this.lblId.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(111, 24);
            this.lblId.Text = "toolStripLabel1";
            // 
            // lvInfoItems
            // 
            this.lvInfoItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.lvInfoItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInfoItems.FullRowSelect = true;
            this.lvInfoItems.LabelEdit = true;
            this.lvInfoItems.Location = new System.Drawing.Point(0, 0);
            this.lvInfoItems.MultiSelect = false;
            this.lvInfoItems.Name = "lvInfoItems";
            this.lvInfoItems.Size = new System.Drawing.Size(369, 696);
            this.lvInfoItems.SmallImageList = this.imageListTasks;
            this.lvInfoItems.TabIndex = 2;
            this.lvInfoItems.UseCompatibleStateImageBehavior = false;
            this.lvInfoItems.View = System.Windows.Forms.View.Details;
            this.lvInfoItems.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvInfoItems_AfterLabelEdit);
            this.lvInfoItems.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.lvInfoItems.DoubleClick += new System.EventHandler(this.lvInfoItems_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 240;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Last update";
            this.columnHeader3.Width = 180;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.cmdContext);
            this.panel1.Controls.Add(this.txtInfoItemName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtInfoItemId);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 71);
            this.panel1.TabIndex = 3;
            // 
            // cmdContext
            // 
            this.cmdContext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdContext.Location = new System.Drawing.Point(530, 3);
            this.cmdContext.Name = "cmdContext";
            this.cmdContext.Size = new System.Drawing.Size(28, 27);
            this.cmdContext.TabIndex = 7;
            this.cmdContext.Text = "...";
            this.cmdContext.UseVisualStyleBackColor = true;
            // 
            // txtInfoItemName
            // 
            this.txtInfoItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoItemName.BackColor = System.Drawing.Color.White;
            this.txtInfoItemName.Location = new System.Drawing.Point(73, 40);
            this.txtInfoItemName.Name = "txtInfoItemName";
            this.txtInfoItemName.Size = new System.Drawing.Size(485, 27);
            this.txtInfoItemName.TabIndex = 6;
            this.txtInfoItemName.TextChanged += new System.EventHandler(this.txtInfoItemName_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // txtInfoItemId
            // 
            this.txtInfoItemId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoItemId.BackColor = System.Drawing.Color.White;
            this.txtInfoItemId.Location = new System.Drawing.Point(73, 3);
            this.txtInfoItemId.Name = "txtInfoItemId";
            this.txtInfoItemId.ReadOnly = true;
            this.txtInfoItemId.Size = new System.Drawing.Size(451, 27);
            this.txtInfoItemId.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lvSources);
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Location = new System.Drawing.Point(6, 76);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 447);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sources";
            // 
            // lvSources
            // 
            this.lvSources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4,
            this.columnHeader5});
            this.lvSources.FullRowSelect = true;
            this.lvSources.Location = new System.Drawing.Point(3, 53);
            this.lvSources.Name = "lvSources";
            this.lvSources.Size = new System.Drawing.Size(547, 388);
            this.lvSources.SmallImageList = this.imageListTasks;
            this.lvSources.TabIndex = 1;
            this.lvSources.UseCompatibleStateImageBehavior = false;
            this.lvSources.View = System.Windows.Forms.View.Details;
            this.lvSources.SelectedIndexChanged += new System.EventHandler(this.lvSources_SelectedIndexChanged);
            this.lvSources.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSources_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Category";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "SubCategory";
            this.columnHeader5.Width = 120;
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAddSource,
            this.cmdEditSource,
            this.cmdRemoveSource,
            this.toolStripSeparator3,
            this.cmdRefreshSources});
            this.toolStrip2.Location = new System.Drawing.Point(3, 23);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(550, 27);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // cmdAddSource
            // 
            this.cmdAddSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdAddSource.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddSource.Image")));
            this.cmdAddSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdAddSource.Name = "cmdAddSource";
            this.cmdAddSource.Size = new System.Drawing.Size(29, 24);
            this.cmdAddSource.Text = "toolStripButton2";
            this.cmdAddSource.Click += new System.EventHandler(this.cmdAddSource_Click);
            // 
            // cmdEditSource
            // 
            this.cmdEditSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdEditSource.Image = ((System.Drawing.Image)(resources.GetObject("cmdEditSource.Image")));
            this.cmdEditSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdEditSource.Name = "cmdEditSource";
            this.cmdEditSource.Size = new System.Drawing.Size(29, 24);
            this.cmdEditSource.Text = "toolStripButton5";
            // 
            // cmdRemoveSource
            // 
            this.cmdRemoveSource.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdRemoveSource.Image = ((System.Drawing.Image)(resources.GetObject("cmdRemoveSource.Image")));
            this.cmdRemoveSource.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdRemoveSource.Name = "cmdRemoveSource";
            this.cmdRemoveSource.Size = new System.Drawing.Size(29, 24);
            this.cmdRemoveSource.Text = "toolStripButton3";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // cmdRefreshSources
            // 
            this.cmdRefreshSources.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdRefreshSources.Image = ((System.Drawing.Image)(resources.GetObject("cmdRefreshSources.Image")));
            this.cmdRefreshSources.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdRefreshSources.Name = "cmdRefreshSources";
            this.cmdRefreshSources.Size = new System.Drawing.Size(29, 24);
            this.cmdRefreshSources.Text = "toolStripButton4";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lvInfoItems);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.specialPropertiesViewer1);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(966, 696);
            this.splitContainer1.SplitterDistance = 369;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 5;
            // 
            // specialPropertiesViewer1
            // 
            this.specialPropertiesViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.specialPropertiesViewer1.CanEdit = true;
            this.specialPropertiesViewer1.Location = new System.Drawing.Point(6, 549);
            this.specialPropertiesViewer1.Name = "specialPropertiesViewer1";
            this.specialPropertiesViewer1.Size = new System.Drawing.Size(556, 144);
            this.specialPropertiesViewer1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 526);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Special Properties:";
            // 
            // ProcessorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(966, 728);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ProcessorForm";
            this.Text = "ProcessorForm";
            this.Load += new System.EventHandler(this.ProcessorForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ImageList imageListTasks;
        private ToolStrip toolStrip1;
        private ToolStripButton nuevoToolStripButton;
        private ToolStripButton abrirToolStripButton;
        private ToolStripButton guardarToolStripButton;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton toolStripButton1;
        private ListView lvInfoItems;
        private ToolTip toolTip1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel lblId;
        private ToolStripButton cmdCopyId;
        private ToolStripTextBox txtName;
        private ColumnHeader columnHeader1;
        private Panel panel1;
        private Button cmdContext;
        private TextBox txtInfoItemName;
        private PictureBox pictureBox1;
        private TextBox txtInfoItemId;
        private ColumnHeader columnHeader3;
        private GroupBox groupBox1;
        private ListView lvSources;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader4;
        private ToolStrip toolStrip2;
        private ToolStripButton cmdAddSource;
        private ToolStripButton cmdEditSource;
        private ToolStripButton cmdRemoveSource;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton cmdRefreshSources;
        private SplitContainer splitContainer1;
        private Label label1;
        private SpecialPropertiesViewer specialPropertiesViewer1;
        private ColumnHeader columnHeader5;
    }
}