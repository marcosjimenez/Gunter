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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.imageVisualization = new System.Windows.Forms.PictureBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageVisualization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDias)).BeginInit();
            this.grpActualizar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinutos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redLed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenLed)).BeginInit();
            this.SuspendLayout();
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(114, 6);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(629, 27);
            this.txtId.TabIndex = 15;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(114, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(629, 27);
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
            this.lvSources.Location = new System.Drawing.Point(501, 128);
            this.lvSources.MultiSelect = false;
            this.lvSources.Name = "lvSources";
            this.lvSources.ShowGroups = false;
            this.lvSources.Size = new System.Drawing.Size(363, 151);
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
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(400, 322);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(504, 337);
            this.splitContainer1.SplitterDistance = 119;
            this.splitContainer1.SplitterWidth = 8;
            this.splitContainer1.TabIndex = 22;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(504, 210);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(496, 177);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.imageVisualization);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(496, 177);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // imageVisualization
            // 
            this.imageVisualization.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageVisualization.Location = new System.Drawing.Point(3, 3);
            this.imageVisualization.Name = "imageVisualization";
            this.imageVisualization.Size = new System.Drawing.Size(490, 171);
            this.imageVisualization.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageVisualization.TabIndex = 0;
            this.imageVisualization.TabStop = false;
            // 
            // cmdUpdate
            // 
            this.cmdUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUpdate.Image = ((System.Drawing.Image)(resources.GetObject("cmdUpdate.Image")));
            this.cmdUpdate.Location = new System.Drawing.Point(626, 76);
            this.cmdUpdate.Name = "cmdUpdate";
            this.cmdUpdate.Size = new System.Drawing.Size(117, 29);
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
            this.chkActualizar.Size = new System.Drawing.Size(97, 24);
            this.chkActualizar.TabIndex = 27;
            this.chkActualizar.Text = "&Actualizar";
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
            this.grpActualizar.Location = new System.Drawing.Point(749, -1);
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
            this.specialPropertiesViewer1.Location = new System.Drawing.Point(12, 128);
            this.specialPropertiesViewer1.Name = "specialPropertiesViewer1";
            this.specialPropertiesViewer1.Size = new System.Drawing.Size(483, 151);
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
            this.label2.Location = new System.Drawing.Point(501, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 40;
            this.label2.Text = "Sources";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 40;
            this.label3.Text = "Special Properties";
            // 
            // cmdViewHtml
            // 
            this.cmdViewHtml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdViewHtml.Image = ((System.Drawing.Image)(resources.GetObject("cmdViewHtml.Image")));
            this.cmdViewHtml.Location = new System.Drawing.Point(870, 128);
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
            this.button1.Location = new System.Drawing.Point(870, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 31);
            this.button1.TabIndex = 41;
            this.button1.Text = "&Image";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // InfoItemViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1013, 681);
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
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.greenLed);
            this.Name = "InfoItemViewer";
            this.Text = "InfoItem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TargetToolBox_FormClosing);
            this.Load += new System.EventHandler(this.TargetToolBox_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageVisualization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDias)).EndInit();
            this.grpActualizar.ResumeLayout(false);
            this.grpActualizar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSegundos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMinutos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redLed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenLed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtId;
        private TextBox txtNombre;
        private SplitContainer splitContainer1;
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
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private PictureBox imageVisualization;
        private PictureBox redLed;
        private PictureBox greenLed;
        private SpecialPropertiesViewer specialPropertiesViewer1;
        private Label lblUltimaActualizacion;
        private Label lblSiguienteActualizacion;
        private Label label2;
        private Label label3;
        private Button cmdViewHtml;
        private Button button1;
    }
}