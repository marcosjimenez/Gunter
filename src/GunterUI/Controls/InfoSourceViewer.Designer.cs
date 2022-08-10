namespace Controls
{
    partial class InfoSourceViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoSourceViewer));
            this.redLed = new System.Windows.Forms.PictureBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtBaseClass = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.txtSubCategory = new System.Windows.Forms.TextBox();
            this.specialPropertiesViewer1 = new GunterUI.SpecialPropertiesViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.jsonViewer = new Controls.JsonViewer();
            ((System.ComponentModel.ISupportInitialize)(this.redLed)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // redLed
            // 
            this.redLed.Image = ((System.Drawing.Image)(resources.GetObject("redLed.Image")));
            this.redLed.Location = new System.Drawing.Point(3, 3);
            this.redLed.Name = "redLed";
            this.redLed.Size = new System.Drawing.Size(96, 96);
            this.redLed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redLed.TabIndex = 52;
            this.redLed.TabStop = false;
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(426, 36);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(329, 27);
            this.txtId.TabIndex = 51;
            // 
            // txtBaseClass
            // 
            this.txtBaseClass.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBaseClass.Location = new System.Drawing.Point(105, 3);
            this.txtBaseClass.Name = "txtBaseClass";
            this.txtBaseClass.ReadOnly = true;
            this.txtBaseClass.Size = new System.Drawing.Size(315, 27);
            this.txtBaseClass.TabIndex = 50;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(104, 36);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(316, 27);
            this.txtNombre.TabIndex = 53;
            // 
            // txtCategory
            // 
            this.txtCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCategory.Location = new System.Drawing.Point(426, 3);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(143, 27);
            this.txtCategory.TabIndex = 54;
            // 
            // txtSubCategory
            // 
            this.txtSubCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubCategory.Location = new System.Drawing.Point(575, 3);
            this.txtSubCategory.Name = "txtSubCategory";
            this.txtSubCategory.ReadOnly = true;
            this.txtSubCategory.Size = new System.Drawing.Size(180, 27);
            this.txtSubCategory.TabIndex = 55;
            // 
            // specialPropertiesViewer1
            // 
            this.specialPropertiesViewer1.CanEdit = true;
            this.specialPropertiesViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.specialPropertiesViewer1.Location = new System.Drawing.Point(3, 3);
            this.specialPropertiesViewer1.Name = "specialPropertiesViewer1";
            this.specialPropertiesViewer1.Size = new System.Drawing.Size(741, 366);
            this.specialPropertiesViewer1.TabIndex = 56;
            this.specialPropertiesViewer1.OnPropertyChanged += new GunterUI.SpecialPropertiesViewer.PropertyUpdatedDelegate(this.specialPropertiesViewer1_OnPropertyChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "label1";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 105);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(755, 405);
            this.tabControl1.TabIndex = 58;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.specialPropertiesViewer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(747, 372);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Properties";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.jsonViewer);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(747, 372);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "JSon Editor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // jsonViewer
            // 
            this.jsonViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jsonViewer.Location = new System.Drawing.Point(3, 3);
            this.jsonViewer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.jsonViewer.Name = "jsonViewer";
            this.jsonViewer.Size = new System.Drawing.Size(741, 366);
            this.jsonViewer.TabIndex = 0;
            // 
            // InfoSourceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSubCategory);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.redLed);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.txtBaseClass);
            this.Name = "InfoSourceViewer";
            this.Size = new System.Drawing.Size(758, 513);
            ((System.ComponentModel.ISupportInitialize)(this.redLed)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox redLed;
        private TextBox txtId;
        private TextBox txtBaseClass;
        private TextBox txtNombre;
        private TextBox txtCategory;
        private TextBox txtSubCategory;
        private GunterUI.SpecialPropertiesViewer specialPropertiesViewer1;
        private Label label1;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private JsonViewer jsonViewer;
    }
}
