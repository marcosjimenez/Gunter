namespace Controls
{
    partial class InfoItemViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoItemViewer));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.cmdAddSource = new System.Windows.Forms.ToolStripButton();
            this.cmdEditSource = new System.Windows.Forms.ToolStripButton();
            this.cmdRemoveSource = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdRefreshSources = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.lvSources = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.redLed = new System.Windows.Forms.PictureBox();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.lblUltimaActualizacion = new System.Windows.Forms.Label();
            this.grpActualizar = new System.Windows.Forms.GroupBox();
            this.lblSiguienteActualizacion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSegundos = new System.Windows.Forms.NumericUpDown();
            this.txtMinutos = new System.Windows.Forms.NumericUpDown();
            this.txtHoras = new System.Windows.Forms.NumericUpDown();
            this.chkActualizar = new System.Windows.Forms.CheckBox();
            this.txtDias = new System.Windows.Forms.NumericUpDown();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.greenLed = new System.Windows.Forms.PictureBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdAddVisualization = new System.Windows.Forms.ToolStripButton();
            this.cmdRemoveVisualization = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lvVisualizations = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redLed)).BeginInit();
            this.grpActualizar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenLed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAddSource,
            this.cmdEditSource,
            this.cmdRemoveSource,
            this.toolStripSeparator3,
            this.cmdRefreshSources,
            this.toolStripLabel1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(637, 27);
            this.toolStrip2.TabIndex = 56;
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
            this.cmdRefreshSources.Click += new System.EventHandler(this.cmdRefreshSources_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(60, 24);
            this.toolStripLabel1.Text = "Sources";
            // 
            // lvSources
            // 
            this.lvSources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSources.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvSources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvSources.FullRowSelect = true;
            this.lvSources.Location = new System.Drawing.Point(3, 30);
            this.lvSources.MultiSelect = false;
            this.lvSources.Name = "lvSources";
            this.lvSources.ShowGroups = false;
            this.lvSources.Size = new System.Drawing.Size(634, 336);
            this.lvSources.TabIndex = 43;
            this.lvSources.UseCompatibleStateImageBehavior = false;
            this.lvSources.View = System.Windows.Forms.View.Details;
            this.lvSources.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.lvSources.DoubleClick += new System.EventHandler(this.lvSources_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Id";
            this.columnHeader2.Width = 200;
            // 
            // redLed
            // 
            this.redLed.Image = ((System.Drawing.Image)(resources.GetObject("redLed.Image")));
            this.redLed.Location = new System.Drawing.Point(3, 13);
            this.redLed.Name = "redLed";
            this.redLed.Size = new System.Drawing.Size(96, 96);
            this.redLed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redLed.TabIndex = 49;
            this.redLed.TabStop = false;
            this.redLed.Visible = false;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdate.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdate.Image")));
            this.cmdUpdate.Location = new System.Drawing.Point(281, 83);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(105, 29);
            this.cmdUpdate.TabIndex = 46;
            this.cmdUpdate.Text = "&Actualizar";
            this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // lblUltimaActualizacion
            // 
            this.lblUltimaActualizacion.AutoSize = true;
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(105, 87);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(159, 20);
            this.lblUltimaActualizacion.TabIndex = 51;
            this.lblUltimaActualizacion.Text = "lblUltimaActualizacion";
            // 
            // grpActualizar
            // 
            this.grpActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpActualizar.Controls.Add(this.lblSiguienteActualizacion);
            this.grpActualizar.Controls.Add(this.label7);
            this.grpActualizar.Controls.Add(this.label6);
            this.grpActualizar.Controls.Add(this.label5);
            this.grpActualizar.Controls.Add(this.label1);
            this.grpActualizar.Controls.Add(this.txtSegundos);
            this.grpActualizar.Controls.Add(this.txtMinutos);
            this.grpActualizar.Controls.Add(this.txtHoras);
            this.grpActualizar.Controls.Add(this.chkActualizar);
            this.grpActualizar.Controls.Add(this.txtDias);
            this.grpActualizar.Location = new System.Drawing.Point(392, 6);
            this.grpActualizar.Name = "grpActualizar";
            this.grpActualizar.Size = new System.Drawing.Size(252, 106);
            this.grpActualizar.TabIndex = 47;
            this.grpActualizar.TabStop = false;
            this.grpActualizar.Text = " ";
            // 
            // lblSiguienteActualizacion
            // 
            this.lblSiguienteActualizacion.AutoSize = true;
            this.lblSiguienteActualizacion.Location = new System.Drawing.Point(18, 81);
            this.lblSiguienteActualizacion.Name = "lblSiguienteActualizacion";
            this.lblSiguienteActualizacion.Size = new System.Drawing.Size(177, 20);
            this.lblSiguienteActualizacion.TabIndex = 40;
            this.lblSiguienteActualizacion.Text = "lblSiguienteActualizacion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(192, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "Seg";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 20);
            this.label6.TabIndex = 34;
            this.label6.Text = "Min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(83, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 33;
            this.label5.Text = "Horas";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Días";
            // 
            // txtSegundos
            // 
            this.txtSegundos.Location = new System.Drawing.Point(189, 49);
            this.txtSegundos.Name = "txtSegundos";
            this.txtSegundos.Size = new System.Drawing.Size(46, 27);
            this.txtSegundos.TabIndex = 31;
            this.txtSegundos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSegundos.ThousandsSeparator = true;
            this.txtSegundos.ValueChanged += new System.EventHandler(this.txtTimeSpan_ValueChanged);
            // 
            // txtMinutos
            // 
            this.txtMinutos.Location = new System.Drawing.Point(134, 49);
            this.txtMinutos.Name = "txtMinutos";
            this.txtMinutos.Size = new System.Drawing.Size(49, 27);
            this.txtMinutos.TabIndex = 30;
            this.txtMinutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinutos.ThousandsSeparator = true;
            this.txtMinutos.ValueChanged += new System.EventHandler(this.txtTimeSpan_ValueChanged);
            // 
            // txtHoras
            // 
            this.txtHoras.Location = new System.Drawing.Point(75, 49);
            this.txtHoras.Name = "txtHoras";
            this.txtHoras.Size = new System.Drawing.Size(53, 27);
            this.txtHoras.TabIndex = 29;
            this.txtHoras.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHoras.ThousandsSeparator = true;
            this.txtHoras.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtHoras.ValueChanged += new System.EventHandler(this.txtTimeSpan_ValueChanged);
            // 
            // chkActualizar
            // 
            this.chkActualizar.AutoSize = true;
            this.chkActualizar.Location = new System.Drawing.Point(18, 4);
            this.chkActualizar.Name = "chkActualizar";
            this.chkActualizar.Size = new System.Drawing.Size(101, 24);
            this.chkActualizar.TabIndex = 27;
            this.chkActualizar.Text = "Programar";
            this.chkActualizar.UseVisualStyleBackColor = true;
            this.chkActualizar.CheckedChanged += new System.EventHandler(this.chkActualizar_CheckedChanged);
            // 
            // txtDias
            // 
            this.txtDias.Location = new System.Drawing.Point(18, 49);
            this.txtDias.Name = "txtDias";
            this.txtDias.Size = new System.Drawing.Size(51, 27);
            this.txtDias.TabIndex = 28;
            this.txtDias.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDias.ThousandsSeparator = true;
            this.txtDias.ValueChanged += new System.EventHandler(this.txtTimeSpan_ValueChanged);
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(105, 13);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(281, 27);
            this.txtId.TabIndex = 45;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(105, 50);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(281, 27);
            this.txtNombre.TabIndex = 44;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // greenLed
            // 
            this.greenLed.Image = ((System.Drawing.Image)(resources.GetObject("greenLed.Image")));
            this.greenLed.Location = new System.Drawing.Point(3, 13);
            this.greenLed.Name = "greenLed";
            this.greenLed.Size = new System.Drawing.Size(96, 96);
            this.greenLed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenLed.TabIndex = 50;
            this.greenLed.TabStop = false;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(3, 115);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer2.Panel1.Controls.Add(this.lvSources);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer2.Panel2.Controls.Add(this.lvVisualizations);
            this.splitContainer2.Size = new System.Drawing.Size(637, 748);
            this.splitContainer2.SplitterDistance = 369;
            this.splitContainer2.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAddVisualization,
            this.cmdRemoveVisualization,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(637, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmdAddVisualization
            // 
            this.cmdAddVisualization.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdAddVisualization.Image = ((System.Drawing.Image)(resources.GetObject("cmdAddVisualization.Image")));
            this.cmdAddVisualization.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdAddVisualization.Name = "cmdAddVisualization";
            this.cmdAddVisualization.Size = new System.Drawing.Size(29, 24);
            this.cmdAddVisualization.Click += new System.EventHandler(this.cmdAddVisualization_Click);
            // 
            // cmdRemoveVisualization
            // 
            this.cmdRemoveVisualization.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdRemoveVisualization.Image = ((System.Drawing.Image)(resources.GetObject("cmdRemoveVisualization.Image")));
            this.cmdRemoveVisualization.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdRemoveVisualization.Name = "cmdRemoveVisualization";
            this.cmdRemoveVisualization.Size = new System.Drawing.Size(29, 24);
            this.cmdRemoveVisualization.Text = "toolStripButton2";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // lvVisualizations
            // 
            this.lvVisualizations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader3});
            this.lvVisualizations.Location = new System.Drawing.Point(3, 30);
            this.lvVisualizations.Name = "lvVisualizations";
            this.lvVisualizations.ShowGroups = false;
            this.lvVisualizations.Size = new System.Drawing.Size(634, 345);
            this.lvVisualizations.TabIndex = 0;
            this.lvVisualizations.UseCompatibleStateImageBehavior = false;
            this.lvVisualizations.View = System.Windows.Forms.View.Details;
            this.lvVisualizations.DoubleClick += new System.EventHandler(this.lvVisualizations_DoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
            this.columnHeader5.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Id";
            this.columnHeader3.Width = 300;
            // 
            // InfoItemViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.redLed);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.lblUltimaActualizacion);
            this.Controls.Add(this.grpActualizar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.greenLed);
            this.Name = "InfoItemViewer";
            this.Size = new System.Drawing.Size(647, 866);
            this.Load += new System.EventHandler(this.InfoItemViewer_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.redLed)).EndInit();
            this.grpActualizar.ResumeLayout(false);
            this.grpActualizar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenLed)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStrip toolStrip2;
        private ToolStripButton cmdAddSource;
        private ToolStripButton cmdEditSource;
        private ToolStripButton cmdRemoveSource;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton cmdRefreshSources;
        private ListView lvSources;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private PictureBox redLed;
        private Button cmdUpdate;
        private Label lblUltimaActualizacion;
        private GroupBox grpActualizar;
        private Label lblSiguienteActualizacion;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label1;
        private NumericUpDown txtSegundos;
        private NumericUpDown txtMinutos;
        private NumericUpDown txtHoras;
        private CheckBox chkActualizar;
        private NumericUpDown txtDias;
        private TextBox txtId;
        private TextBox txtNombre;
        private PictureBox greenLed;
        private SplitContainer splitContainer2;
        private ToolStripLabel toolStripLabel1;
        private ToolStrip toolStrip1;
        private ToolStripButton cmdAddVisualization;
        private ToolStripButton cmdRemoveVisualization;
        private ToolStripSeparator toolStripSeparator1;
        private ListView lvVisualizations;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader3;
    }
}
