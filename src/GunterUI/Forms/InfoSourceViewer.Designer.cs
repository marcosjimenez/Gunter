namespace GunterUI
{
    partial class InfoSourceViewer
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
            this.specialPropertiesViewer1 = new GunterUI.SpecialPropertiesViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // specialPropertiesViewer1
            // 
            this.specialPropertiesViewer1.CanEdit = false;
            this.specialPropertiesViewer1.Location = new System.Drawing.Point(42, 170);
            this.specialPropertiesViewer1.Name = "specialPropertiesViewer1";
            this.specialPropertiesViewer1.Size = new System.Drawing.Size(617, 128);
            this.specialPropertiesViewer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Special Properties";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(51, 20);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label2";
            // 
            // InfoSourceViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.specialPropertiesViewer1);
            this.Name = "InfoSourceViewer";
            this.Text = "InfoSourceViewer";
            this.Load += new System.EventHandler(this.InfoSourceViewer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SpecialPropertiesViewer specialPropertiesViewer1;
        private Label label1;
        private Label lblName;
    }
}