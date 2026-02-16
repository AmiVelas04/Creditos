namespace Arcoiris.Formularios.SubForms
{
    partial class Dpi
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
            this.PanCentral = new System.Windows.Forms.Panel();
            this.PcbDpi = new System.Windows.Forms.PictureBox();
            this.PanCentral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PcbDpi)).BeginInit();
            this.SuspendLayout();
            // 
            // PanCentral
            // 
            this.PanCentral.Controls.Add(this.PcbDpi);
            this.PanCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCentral.Location = new System.Drawing.Point(0, 0);
            this.PanCentral.Name = "PanCentral";
            this.PanCentral.Size = new System.Drawing.Size(856, 417);
            this.PanCentral.TabIndex = 0;
            // 
            // PcbDpi
            // 
            this.PcbDpi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PcbDpi.Location = new System.Drawing.Point(0, 0);
            this.PcbDpi.Name = "PcbDpi";
            this.PcbDpi.Size = new System.Drawing.Size(856, 417);
            this.PcbDpi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PcbDpi.TabIndex = 0;
            this.PcbDpi.TabStop = false;
            this.PcbDpi.Click += new System.EventHandler(this.PcbDpi_Click);
            // 
            // Dpi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 417);
            this.Controls.Add(this.PanCentral);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dpi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dpi";
            this.Load += new System.EventHandler(this.Dpi_Load);
            this.PanCentral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PcbDpi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanCentral;
        private System.Windows.Forms.PictureBox PcbDpi;
    }
}