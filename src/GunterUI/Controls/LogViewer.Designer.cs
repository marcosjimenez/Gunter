namespace Controls
{
    partial class LogViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogViewer));
            this.txtLog = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonToolStrip1 = new Krypton.Toolkit.KryptonToolStrip();
            this.cboSeverity = new System.Windows.Forms.ToolStripComboBox();
            this.cmdBuscar = new System.Windows.Forms.ToolStripButton();
            this.cmdFindNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdDeleteAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.kryptonToolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(0, 30);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(701, 402);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // kryptonToolStrip1
            // 
            this.kryptonToolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kryptonToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.kryptonToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboSeverity,
            this.cmdBuscar,
            this.cmdFindNext,
            this.toolStripSeparator2,
            this.cmdDeleteAll,
            this.toolStripButton1});
            this.kryptonToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.kryptonToolStrip1.Name = "kryptonToolStrip1";
            this.kryptonToolStrip1.Size = new System.Drawing.Size(701, 28);
            this.kryptonToolStrip1.TabIndex = 2;
            this.kryptonToolStrip1.Text = "kryptonToolStrip1";
            // 
            // cboSeverity
            // 
            this.cboSeverity.Name = "cboSeverity";
            this.cboSeverity.Size = new System.Drawing.Size(180, 28);
            // 
            // cmdBuscar
            // 
            this.cmdBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdBuscar.Image = ((System.Drawing.Image)(resources.GetObject("cmdBuscar.Image")));
            this.cmdBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdBuscar.Name = "cmdBuscar";
            this.cmdBuscar.Size = new System.Drawing.Size(29, 25);
            this.cmdBuscar.Text = "&Nuevo";
            this.cmdBuscar.Click += new System.EventHandler(this.cmdBuscar_Click);
            // 
            // cmdFindNext
            // 
            this.cmdFindNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdFindNext.Image = ((System.Drawing.Image)(resources.GetObject("cmdFindNext.Image")));
            this.cmdFindNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdFindNext.Name = "cmdFindNext";
            this.cmdFindNext.Size = new System.Drawing.Size(29, 25);
            this.cmdFindNext.Click += new System.EventHandler(this.cmdFindNext_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // cmdDeleteAll
            // 
            this.cmdDeleteAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdDeleteAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdDeleteAll.Image")));
            this.cmdDeleteAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDeleteAll.Name = "cmdDeleteAll";
            this.cmdDeleteAll.Size = new System.Drawing.Size(29, 25);
            this.cmdDeleteAll.Text = "&Abrir";
            this.cmdDeleteAll.Click += new System.EventHandler(this.cmdDeleteAll_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 25);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // LogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kryptonToolStrip1);
            this.Controls.Add(this.txtLog);
            this.Name = "LogViewer";
            this.Size = new System.Drawing.Size(701, 432);
            this.Load += new System.EventHandler(this.LogViewer_Load);
            this.kryptonToolStrip1.ResumeLayout(false);
            this.kryptonToolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonRichTextBox txtLog;
        private Krypton.Toolkit.KryptonToolStrip kryptonToolStrip1;
        private ToolStripButton cmdBuscar;
        private ToolStripButton cmdDeleteAll;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton1;
        private ToolStripComboBox cboSeverity;
        private ToolStripButton cmdFindNext;
    }
}
