namespace Arcoiris.Reportes
{
    partial class BoletaPag
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
            this.BoletaRep = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PagoDescBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PagoDescBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // BoletaRep
            // 
            this.BoletaRep.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Pago";
            reportDataSource1.Value = this.PagoDescBindingSource;
            this.BoletaRep.LocalReport.DataSources.Add(reportDataSource1);
            this.BoletaRep.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.Pago.rdlc";
            this.BoletaRep.Location = new System.Drawing.Point(0, 0);
            this.BoletaRep.Name = "BoletaRep";
            this.BoletaRep.Size = new System.Drawing.Size(737, 261);
            this.BoletaRep.TabIndex = 0;
            // 
            // PagoDescBindingSource
            // 
            this.PagoDescBindingSource.DataSource = typeof(Arcoiris.Reportes.PagoDesc);
            // 
            // BoletaPag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 261);
            this.Controls.Add(this.BoletaRep);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BoletaPag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boleta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BoletaPag_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PagoDescBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer BoletaRep;
        private System.Windows.Forms.BindingSource PagoDescBindingSource;
    }
}