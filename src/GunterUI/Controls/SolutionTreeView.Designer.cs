namespace Controls
{
    partial class SolutionTreeView
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolutionTreeView));
            this.kryptonToolStrip1 = new Krypton.Toolkit.KryptonToolStrip();
            this.nuevoToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.createFolderToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmdCollapseAll = new System.Windows.Forms.ToolStripButton();
            this.cmdExpandAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.mnuProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.compilarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.procesadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizationHandlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.agregarElementoExternoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.cambiarNombreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propiedadesToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.propiedadesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSolution = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tv = new System.Windows.Forms.TreeView();
            this.smallImageList = new System.Windows.Forms.ImageList(this.components);
            this.kryptonToolStrip1.SuspendLayout();
            this.mnuProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonToolStrip1
            // 
            this.kryptonToolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kryptonToolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.kryptonToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripButton,
            this.createFolderToolStripButton,
            this.toolStripSeparator2,
            this.cmdCollapseAll,
            this.cmdExpandAll,
            this.toolStripSeparator,
            this.toolStripButton1});
            this.kryptonToolStrip1.Location = new System.Drawing.Point(0, 0);
            this.kryptonToolStrip1.Name = "kryptonToolStrip1";
            this.kryptonToolStrip1.Size = new System.Drawing.Size(430, 27);
            this.kryptonToolStrip1.TabIndex = 1;
            this.kryptonToolStrip1.Text = "kryptonToolStrip1";
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
            // createFolderToolStripButton
            // 
            this.createFolderToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.createFolderToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("createFolderToolStripButton.Image")));
            this.createFolderToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createFolderToolStripButton.Name = "createFolderToolStripButton";
            this.createFolderToolStripButton.Size = new System.Drawing.Size(29, 24);
            this.createFolderToolStripButton.Text = "&Abrir";
            this.createFolderToolStripButton.Click += new System.EventHandler(this.createFolderToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // cmdCollapseAll
            // 
            this.cmdCollapseAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdCollapseAll.Image")));
            this.cmdCollapseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdCollapseAll.Name = "cmdCollapseAll";
            this.cmdCollapseAll.Size = new System.Drawing.Size(29, 24);
            this.cmdCollapseAll.Text = "Contraer todo";
            this.cmdCollapseAll.Click += new System.EventHandler(this.cmdCollapseAll_Click);
            // 
            // cmdExpandAll
            // 
            this.cmdExpandAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("cmdExpandAll.Image")));
            this.cmdExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdExpandAll.Name = "cmdExpandAll";
            this.cmdExpandAll.Size = new System.Drawing.Size(29, 24);
            this.cmdExpandAll.Text = "Expandir todo";
            this.cmdExpandAll.Click += new System.EventHandler(this.cmdExpandAll_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // mnuProject
            // 
            this.mnuProject.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuProject.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compilarToolStripMenuItem,
            this.limpiarToolStripMenuItem,
            this.generarToolStripMenuItem,
            this.toolStripMenuItem2,
            this.procesadorToolStripMenuItem,
            this.infoItemToolStripMenuItem,
            this.infoSourceToolStripMenuItem,
            this.visualizationHandlerToolStripMenuItem,
            this.toolStripMenuItem3,
            this.agregarElementoExternoToolStripMenuItem1,
            this.toolStripMenuItem5,
            this.cambiarNombreToolStripMenuItem,
            this.eliminarToolStripMenuItem,
            this.propiedadesToolStripMenuItem,
            this.propiedadesToolStripMenuItem1});
            this.mnuProject.Name = "mnuProject";
            this.mnuProject.Size = new System.Drawing.Size(267, 342);
            // 
            // compilarToolStripMenuItem
            // 
            this.compilarToolStripMenuItem.Enabled = false;
            this.compilarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("compilarToolStripMenuItem.Image")));
            this.compilarToolStripMenuItem.Name = "compilarToolStripMenuItem";
            this.compilarToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.compilarToolStripMenuItem.Text = "Compilar...";
            // 
            // limpiarToolStripMenuItem
            // 
            this.limpiarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("limpiarToolStripMenuItem.Image")));
            this.limpiarToolStripMenuItem.Name = "limpiarToolStripMenuItem";
            this.limpiarToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.limpiarToolStripMenuItem.Text = "&Limpiar...";
            // 
            // generarToolStripMenuItem
            // 
            this.generarToolStripMenuItem.Enabled = false;
            this.generarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("generarToolStripMenuItem.Image")));
            this.generarToolStripMenuItem.Name = "generarToolStripMenuItem";
            this.generarToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.generarToolStripMenuItem.Text = "&Generar...";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(263, 6);
            // 
            // procesadorToolStripMenuItem
            // 
            this.procesadorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("procesadorToolStripMenuItem.Image")));
            this.procesadorToolStripMenuItem.Name = "procesadorToolStripMenuItem";
            this.procesadorToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.procesadorToolStripMenuItem.Text = "Nuevo Procesador";
            this.procesadorToolStripMenuItem.Click += new System.EventHandler(this.procesadorToolStripMenuItem_Click);
            // 
            // infoItemToolStripMenuItem
            // 
            this.infoItemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("infoItemToolStripMenuItem.Image")));
            this.infoItemToolStripMenuItem.Name = "infoItemToolStripMenuItem";
            this.infoItemToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.infoItemToolStripMenuItem.Text = "Nuevo InfoItem";
            this.infoItemToolStripMenuItem.Click += new System.EventHandler(this.infoItemToolStripMenuItem_Click);
            // 
            // infoSourceToolStripMenuItem
            // 
            this.infoSourceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("infoSourceToolStripMenuItem.Image")));
            this.infoSourceToolStripMenuItem.Name = "infoSourceToolStripMenuItem";
            this.infoSourceToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.infoSourceToolStripMenuItem.Text = "Nuevo InfoSource";
            // 
            // visualizationHandlerToolStripMenuItem
            // 
            this.visualizationHandlerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("visualizationHandlerToolStripMenuItem.Image")));
            this.visualizationHandlerToolStripMenuItem.Name = "visualizationHandlerToolStripMenuItem";
            this.visualizationHandlerToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.visualizationHandlerToolStripMenuItem.Text = "Nuevo VisualizationHandler";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(263, 6);
            // 
            // agregarElementoExternoToolStripMenuItem1
            // 
            this.agregarElementoExternoToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("agregarElementoExternoToolStripMenuItem1.Image")));
            this.agregarElementoExternoToolStripMenuItem1.Name = "agregarElementoExternoToolStripMenuItem1";
            this.agregarElementoExternoToolStripMenuItem1.Size = new System.Drawing.Size(266, 26);
            this.agregarElementoExternoToolStripMenuItem1.Text = "Agregar elemento externo...";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(263, 6);
            // 
            // cambiarNombreToolStripMenuItem
            // 
            this.cambiarNombreToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cambiarNombreToolStripMenuItem.Image")));
            this.cambiarNombreToolStripMenuItem.Name = "cambiarNombreToolStripMenuItem";
            this.cambiarNombreToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.cambiarNombreToolStripMenuItem.Text = "Cambiar nombre...";
            // 
            // eliminarToolStripMenuItem
            // 
            this.eliminarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eliminarToolStripMenuItem.Image")));
            this.eliminarToolStripMenuItem.Name = "eliminarToolStripMenuItem";
            this.eliminarToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.eliminarToolStripMenuItem.Text = "Eliminar...";
            this.eliminarToolStripMenuItem.Click += new System.EventHandler(this.eliminarToolStripMenuItem_Click);
            // 
            // propiedadesToolStripMenuItem
            // 
            this.propiedadesToolStripMenuItem.Name = "propiedadesToolStripMenuItem";
            this.propiedadesToolStripMenuItem.Size = new System.Drawing.Size(263, 6);
            // 
            // propiedadesToolStripMenuItem1
            // 
            this.propiedadesToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("propiedadesToolStripMenuItem1.Image")));
            this.propiedadesToolStripMenuItem1.Name = "propiedadesToolStripMenuItem1";
            this.propiedadesToolStripMenuItem1.Size = new System.Drawing.Size(266, 26);
            this.propiedadesToolStripMenuItem1.Text = "&Propiedades";
            this.propiedadesToolStripMenuItem1.Click += new System.EventHandler(this.propiedadesToolStripMenuItem1_Click);
            // 
            // mnuSolution
            // 
            this.mnuSolution.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mnuSolution.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnuSolution.Name = "mnuSolution";
            this.mnuSolution.Size = new System.Drawing.Size(61, 4);
            // 
            // tv
            // 
            this.tv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv.FullRowSelect = true;
            this.tv.ImageIndex = 0;
            this.tv.ImageList = this.smallImageList;
            this.tv.Location = new System.Drawing.Point(0, 30);
            this.tv.Name = "tv";
            this.tv.SelectedImageIndex = 0;
            this.tv.Size = new System.Drawing.Size(427, 494);
            this.tv.TabIndex = 2;
            this.tv.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tv_AfterLabelEdit);
            this.tv.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_AfterSelect);
            this.tv.DoubleClick += new System.EventHandler(this.tv_DoubleClick);
            this.tv.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tv_MouseDown);
            // 
            // smallImageList
            // 
            this.smallImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.smallImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("smallImageList.ImageStream")));
            this.smallImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.smallImageList.Images.SetKeyName(0, "Solution");
            this.smallImageList.Images.SetKeyName(1, "Project");
            this.smallImageList.Images.SetKeyName(2, "Processor");
            this.smallImageList.Images.SetKeyName(3, "FolderClosed");
            this.smallImageList.Images.SetKeyName(4, "FolderOpened");
            this.smallImageList.Images.SetKeyName(5, "Processor");
            this.smallImageList.Images.SetKeyName(6, "InfoItem");
            this.smallImageList.Images.SetKeyName(7, "InfoSource");
            this.smallImageList.Images.SetKeyName(8, "Visualization");
            // 
            // SolutionTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tv);
            this.Controls.Add(this.kryptonToolStrip1);
            this.Name = "SolutionTreeView";
            this.Size = new System.Drawing.Size(430, 524);
            this.kryptonToolStrip1.ResumeLayout(false);
            this.kryptonToolStrip1.PerformLayout();
            this.mnuProject.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Krypton.Toolkit.KryptonToolStrip kryptonToolStrip1;
        private ToolStripButton nuevoToolStripButton;
        private ToolStripButton createFolderToolStripButton;
        private ToolStripButton cmdCollapseAll;
        private ToolStripButton cmdExpandAll;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButton1;
        private ContextMenuStrip mnuProject;
        private ToolStripMenuItem compilarToolStripMenuItem;
        private ToolStripMenuItem limpiarToolStripMenuItem;
        private ToolStripMenuItem generarToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem cambiarNombreToolStripMenuItem;
        private ToolStripMenuItem eliminarToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem3;
        private ContextMenuStrip mnuSolution;
        private TreeView tv;
        private ImageList smallImageList;
        private ToolStripMenuItem procesadorToolStripMenuItem;
        private ToolStripMenuItem agregarElementoExternoToolStripMenuItem1;
        private ToolStripSeparator toolStripMenuItem5;
        private ToolStripMenuItem infoItemToolStripMenuItem;
        private ToolStripMenuItem infoSourceToolStripMenuItem;
        private ToolStripMenuItem visualizationHandlerToolStripMenuItem;
        private ToolStripSeparator propiedadesToolStripMenuItem;
        private ToolStripMenuItem propiedadesToolStripMenuItem1;
    }
}
