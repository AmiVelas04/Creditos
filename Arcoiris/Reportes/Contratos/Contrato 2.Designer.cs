namespace Arcoiris.Reportes.Contratos
{
    partial class Contrato_2
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
            this.Rep1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ContratoDatosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ContratoDatosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Rep1
            // 
            this.Rep1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Datos";
            reportDataSource1.Value = this.ContratoDatosBindingSource;
            this.Rep1.LocalReport.DataSources.Add(reportDataSource1);
            this.Rep1.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.Contratos.Contrato 2.rdlc";
            this.Rep1.Location = new System.Drawing.Point(0, 0);
            this.Rep1.Name = "Rep1";
            this.Rep1.ServerReport.BearerToken = null;
            this.Rep1.Size = new System.Drawing.Size(800, 450);
            this.Rep1.TabIndex = 2;
            // 
            // ContratoDatosBindingSource
            // 
            this.ContratoDatosBindingSource.DataSource = typeof(Arcoiris.Reportes.Contratos.ContratoDatos);
            // 
            // Contrato_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Rep1);
            this.Name = "Contrato_2";
            this.Text = "Contrato_2";
            this.Load += new System.EventHandler(this.Contrato_2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ContratoDatosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Rep1;
        private System.Windows.Forms.BindingSource ContratoDatosBindingSource;
    }
}