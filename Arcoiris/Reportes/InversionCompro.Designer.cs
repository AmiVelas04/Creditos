namespace Arcoiris.Reportes
{
    partial class InversionCompro
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.RpvInvComp = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InversionComDetaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InversionComDetaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RpvInvComp
            // 
            this.RpvInvComp.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "InvComp";
            reportDataSource1.Value = this.InversionComDetaBindingSource;
            this.RpvInvComp.LocalReport.DataSources.Add(reportDataSource1);
            this.RpvInvComp.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.InversionCompro.rdlc";
            this.RpvInvComp.Location = new System.Drawing.Point(0, 0);
            this.RpvInvComp.Name = "RpvInvComp";
            this.RpvInvComp.ServerReport.BearerToken = null;
            this.RpvInvComp.Size = new System.Drawing.Size(800, 450);
            this.RpvInvComp.TabIndex = 1;
            // 
            // InversionComDetaBindingSource
            // 
            this.InversionComDetaBindingSource.DataSource = typeof(Arcoiris.Reportes.InversionComDeta);
            // 
            // InversionCompro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RpvInvComp);
            this.Name = "InversionCompro";
            this.Text = "Compobante inversion";
            this.Load += new System.EventHandler(this.InversionCompro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InversionComDetaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RpvInvComp;
        private System.Windows.Forms.BindingSource InversionComDetaBindingSource;
    }
}