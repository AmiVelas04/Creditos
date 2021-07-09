namespace Arcoiris.Reportes
{
    partial class CuentayPago
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.EstadoDetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EstadoEncBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RvCuenta = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.EstadoDetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadoEncBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // EstadoDetBindingSource
            // 
            this.EstadoDetBindingSource.DataSource = typeof(Arcoiris.Reportes.EstadoDet);
            // 
            // EstadoEncBindingSource
            // 
            this.EstadoEncBindingSource.DataSource = typeof(Arcoiris.Reportes.EstadoEnc);
            // 
            // RvCuenta
            // 
            this.RvCuenta.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DetalleEst";
            reportDataSource1.Value = this.EstadoDetBindingSource;
            reportDataSource2.Name = "EncabezadoEst";
            reportDataSource2.Value = this.EstadoEncBindingSource;
            this.RvCuenta.LocalReport.DataSources.Add(reportDataSource1);
            this.RvCuenta.LocalReport.DataSources.Add(reportDataSource2);
            this.RvCuenta.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.CuentaPag.rdlc";
            this.RvCuenta.Location = new System.Drawing.Point(0, 0);
            this.RvCuenta.Name = "RvCuenta";
            this.RvCuenta.Size = new System.Drawing.Size(724, 261);
            this.RvCuenta.TabIndex = 0;
            // 
            // CuentayPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 261);
            this.Controls.Add(this.RvCuenta);
            this.Name = "CuentayPago";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CuentayPago_Load);
            ((System.ComponentModel.ISupportInitialize)(this.EstadoDetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadoEncBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer RvCuenta;
        private System.Windows.Forms.BindingSource EstadoDetBindingSource;
        private System.Windows.Forms.BindingSource EstadoEncBindingSource;
    }
}