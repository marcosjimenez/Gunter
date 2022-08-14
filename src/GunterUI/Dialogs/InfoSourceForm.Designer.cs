namespace Dialogs
{
    partial class InfoSourceForm
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
            this.cmdCancel = new System.Windows.Forms.Button();
            this.cmdOk = new System.Windows.Forms.Button();
            this.specialPropertiesViewer1 = new GunterUI.SpecialPropertiesViewer();
            this.lvSources = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(651, 468);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(139, 33);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // cmdOk
            // 
            this.cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cmdOk.Location = new System.Drawing.Point(506, 468);
            this.cmdOk.Name = "cmdOk";
            this.cmdOk.Size = new System.Drawing.Size(139, 33);
            this.cmdOk.TabIndex = 7;
            this.cmdOk.Text = "&Ok";
            this.cmdOk.UseVisualStyleBackColor = true;
            // 
            // specialPropertiesViewer1
            // 
            this.specialPropertiesViewer1.CanEdit = true;
            this.specialPropertiesViewer1.Location = new System.Drawing.Point(263, 12);
            this.specialPropertiesViewer1.Name = "specialPropertiesViewer1";
            this.specialPropertiesViewer1.Size = new System.Drawing.Size(525, 187);
            this.specialPropertiesViewer1.TabIndex = 6;
            // 
            // lvSources
            // 
            this.lvSources.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lvSources.Location = new System.Drawing.Point(12, 12);
            this.lvSources.Name = "lvSources";
            this.lvSources.Size = new System.Drawing.Size(245, 484);
            this.lvSources.TabIndex = 5;
            this.lvSources.UseCompatibleStateImageBehavior = false;
            this.lvSources.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // InfoSourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 513);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOk);
            this.Controls.Add(this.specialPropertiesViewer1);
            this.Controls.Add(this.lvSources);
            this.Name = "InfoSourceForm";
            this.Text = "InfoSourceForm";
            this.Load += new System.EventHandler(this.InfoSourceForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button cmdCancel;
        private Button cmdOk;
        private GunterUI.SpecialPropertiesViewer specialPropertiesViewer1;
        private ListView lvSources;
        private ColumnHeader columnHeader1;
    }
}