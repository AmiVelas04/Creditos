namespace Arcoiris.Reportes
{
    partial class Pagohoy
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
            this.Rp1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DatosCreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EstadoEncBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DatosCreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadoEncBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Rp1
            // 
            this.Rp1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Detalle";
            reportDataSource1.Value = this.DatosCreBindingSource;
            reportDataSource2.Name = "Encabezado";
            reportDataSource2.Value = this.EstadoEncBindingSource;
            this.Rp1.LocalReport.DataSources.Add(reportDataSource1);
            this.Rp1.LocalReport.DataSources.Add(reportDataSource2);
            this.Rp1.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.Pagohoy.rdlc";
            this.Rp1.Location = new System.Drawing.Point(0, 0);
            this.Rp1.Name = "Rp1";
            this.Rp1.Size = new System.Drawing.Size(1011, 395);
            this.Rp1.TabIndex = 0;
            // 
            // DatosCreBindingSource
            // 
            this.DatosCreBindingSource.DataSource = typeof(Arcoiris.Reportes.DatosCre);
            // 
            // EstadoEncBindingSource
            // 
            this.EstadoEncBindingSource.DataSource = typeof(Arcoiris.Reportes.EstadoEnc);
            // 
            // Pagohoy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 395);
            this.Controls.Add(this.Rp1);
            this.Name = "Pagohoy";
            this.Text = "Pagohoy";
            this.Load += new System.EventHandler(this.Pagohoy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatosCreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EstadoEncBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Rp1;
        private System.Windows.Forms.BindingSource DatosCreBindingSource;
        private System.Windows.Forms.BindingSource EstadoEncBindingSource;
    }
}