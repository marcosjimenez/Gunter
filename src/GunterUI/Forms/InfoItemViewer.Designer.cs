namespace GunterUI.ToolBox
{
    partial class InfoItemViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoItemViewer));
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lvSources = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.cmdUpdate = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chkActualizar = new System.Windows.Forms.CheckBox();
            this.txtDias = new System.Windows.Forms.NumericUpDown();
            this.grpActualizar = new System.Windows.Forms.GroupBox();
            this.lblSiguienteActualizacion = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSegundos = new System.Windows.Forms.NumericUpDown();
            this.txtMinutos = new System.Windows.Forms.NumericUpDown();
            this.txtHoras = new System.Windows.Forms.NumericUpDown();
            this.redLed = new System.Windows.Forms.PictureBox();
            this.greenLed = new System.Windows.Forms.PictureBox();
            this.specialPropertiesViewer1 = new GunterUI.SpecialPropertiesViewer();
            this.lblUltimaActualizacion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdViewHtml = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.cmdAddSource = new System.Windows.Forms.ToolStripButton();
            this.cmdEditSource = new System.Windows.Forms.ToolStripButton();
            this.cmdRemoveSource = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdRefreshSources = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDias)).BeginInit();
            this.grpActualizar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redLed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenLed)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(114, 6);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(381, 27);
            this.txtId.TabIndex = 15;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(114, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(381, 27);
            this.txtNombre.TabIndex = 13;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // lvSources
            // 
            this.lvSources.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lvSources.FullRowSelect = true;
            this.lvSources.Location = new System.Drawing.Point(501, 138);
            this.lvSources.MultiSelect = false;
            this.lvSources.Name = "lvSources";
            this.lvSources.ShowGroups = false;
            this.lvSources.Size = new System.Drawing.Size(363, 141);
            this.lvSources.TabIndex = 6;
            this.lvSources.UseCompatibleStateImageBehavior = false;
            this.lvSources.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 200;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdate.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdate.Image")));
            this.cmdUpdate.Location = new System.Drawing.Point(501, 6);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(105, 29);
            this.cmdUpdate.TabIndex = 23;
            this.cmdUpdate.Text = "&Actualizar";
            this.cmdUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdUpdate.UseVisualStyleBackColor = true;
            this.cmdUpdate.Click += new System.EventHandler(this.cmdUpdate_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Processor");
            this.imageList1.Images.SetKeyName(1, "DataSource");
            // 
            // chkActualizar
            // 
            this.chkActualizar.AutoSize = true;
            this.chkActualizar.Checked = true;
            this.chkActualizar.CheckState = System.Windows.Forms.CheckState.Checked;
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
            this.grpActualizar.Location = new System.Drawing.Point(612, -1);
            this.grpActualizar.Name = "grpActualizar";
            this.grpActualizar.Size = new System.Drawing.Size(252, 106);
            this.grpActualizar.TabIndex = 29;
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
            // redLed
            // 
            this.redLed.Image = ((System.Drawing.Image)(resources.GetObject("redLed.Image")));
            this.redLed.Location = new System.Drawing.Point(12, 6);
            this.redLed.Name = "redLed";
            this.redLed.Size = new System.Drawing.Size(96, 96);
            this.redLed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redLed.TabIndex = 36;
            this.redLed.TabStop = false;
            this.redLed.Visible = false;
            // 
            // greenLed
            // 
            this.greenLed.Image = ((System.Drawing.Image)(resources.GetObject("greenLed.Image")));
            this.greenLed.Location = new System.Drawing.Point(12, 6);
            this.greenLed.Name = "greenLed";
            this.greenLed.Size = new System.Drawing.Size(96, 96);
            this.greenLed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenLed.TabIndex = 37;
            this.greenLed.TabStop = false;
            // 
            // specialPropertiesViewer1
            // 
            this.specialPropertiesViewer1.CanEdit = false;
            this.specialPropertiesViewer1.Location = new System.Drawing.Point(12, 138);
            this.specialPropertiesViewer1.Name = "specialPropertiesViewer1";
            this.specialPropertiesViewer1.Size = new System.Drawing.Size(483, 141);
            this.specialPropertiesViewer1.TabIndex = 36;
            // 
            // lblUltimaActualizacion
            // 
            this.lblUltimaActualizacion.AutoSize = true;
            this.lblUltimaActualizacion.Location = new System.Drawing.Point(114, 82);
            this.lblUltimaActualizacion.Name = "lblUltimaActualizacion";
            this.lblUltimaActualizacion.Size = new System.Drawing.Size(159, 20);
            this.lblUltimaActualizacion.TabIndex = 39;
            this.lblUltimaActualizacion.Text = "lblUltimaActualizacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(501, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Sources";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Special Properties";
            // 
            // cmdViewHtml
            // 
            this.cmdViewHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdViewHtml.Image = ((System.Drawing.Image)(resources.GetObject("cmdViewHtml.Image")));
            this.cmdViewHtml.Location = new System.Drawing.Point(733, 326);
            this.cmdViewHtml.Name = "cmdViewHtml";
            this.cmdViewHtml.Size = new System.Drawing.Size(131, 31);
            this.cmdViewHtml.TabIndex = 41;
            this.cmdViewHtml.Text = "&HTML";
            this.cmdViewHtml.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cmdViewHtml.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cmdViewHtml.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(733, 377);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 31);
            this.button1.TabIndex = 41;
            this.button1.Text = "&Image";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdAddSource,
            this.cmdEditSource,
            this.cmdRemoveSource,
            this.toolStripSeparator3,
            this.cmdRefreshSources});
            this.toolStrip2.Location = new System.Drawing.Point(728, 108);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(174, 27);
            this.toolStrip2.TabIndex = 42;
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
            // InfoItemViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(876, 681);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmdViewHtml);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.specialPropertiesViewer1);
            this.Controls.Add(this.lvSources);
            this.Controls.Add(this.redLed);
            this.Controls.Add(this.cmdUpdate);
            this.Controls.Add(this.lblUltimaActualizacion);
            this.Controls.Add(this.grpActualizar);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.greenLed);
            this.Name = "InfoItemViewer";
            this.Text = "InfoItem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TargetToolBox_FormClosing);
            this.Load += new System.EventHandler(this.TargetToolBox_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtDias)).EndInit();
            this.grpActualizar.ResumeLayout(false);
            this.grpActualizar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redLed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenLed)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtId;
        private TextBox txtNombre;
        private Button cmdUpdate;
        private ListView lvSources;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ImageList imageList1;
        private CheckBox chkActualizar;
        private NumericUpDown txtDias;
        private GroupBox grpActualizar;
        private NumericUpDown txtSegundos;
        private NumericUpDown txtMinutos;
        private NumericUpDown txtHoras;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label1;
        private PictureBox redLed;
        private PictureBox greenLed;
        private SpecialPropertiesViewer specialPropertiesViewer1;
        private Label lblUltimaActualizacion;
        private Label lblSiguienteActualizacion;
        private Label label2;
        private Label label3;
        private Button cmdViewHtml;
        private Button button1;
        private ToolStrip toolStrip2;
        private ToolStripButton cmdAddSource;
        private ToolStripButton cmdEditSource;
        private ToolStripButton cmdRemoveSource;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton cmdRefreshSources;
    }
}