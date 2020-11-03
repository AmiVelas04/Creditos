namespace Arcoiris.Reportes
{
    partial class CreCartera
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
            this.AtrasosDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AtrasosEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Rep1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.AtrasosDBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtrasosEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // AtrasosDBindingSource
            // 
            this.AtrasosDBindingSource.DataSource = typeof(Arcoiris.Reportes.AtrasosD);
            // 
            // AtrasosEBindingSource
            // 
            this.AtrasosEBindingSource.DataSource = typeof(Arcoiris.Reportes.AtrasosE);
            // 
            // Rep1
            // 
            this.Rep1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Detalle";
            reportDataSource1.Value = this.AtrasosDBindingSource;
            reportDataSource2.Name = "Encabezado";
            reportDataSource2.Value = this.AtrasosEBindingSource;
            this.Rep1.LocalReport.DataSources.Add(reportDataSource1);
            this.Rep1.LocalReport.DataSources.Add(reportDataSource2);
            this.Rep1.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.CreCartera.rdlc";
            this.Rep1.Location = new System.Drawing.Point(0, 0);
            this.Rep1.Name = "Rep1";
            this.Rep1.Size = new System.Drawing.Size(918, 388);
            this.Rep1.TabIndex = 0;
            // 
            // CreCartera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 388);
            this.Controls.Add(this.Rep1);
            this.Name = "CreCartera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cartera Activa";
            this.Load += new System.EventHandler(this.CreCartera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AtrasosDBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtrasosEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Rep1;
        private System.Windows.Forms.BindingSource AtrasosDBindingSource;
        private System.Windows.Forms.BindingSource AtrasosEBindingSource;
    }
}