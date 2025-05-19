namespace Arcoiris.Reportes
{
    partial class Inversiones
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
            this.Rpv1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InvEncBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InvDetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InvEncBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvDetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Rpv1
            // 
            this.Rpv1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Encabezado";
            reportDataSource1.Value = this.InvEncBindingSource;
            reportDataSource2.Name = "Detalle";
            reportDataSource2.Value = this.InvDetBindingSource;
            this.Rpv1.LocalReport.DataSources.Add(reportDataSource1);
            this.Rpv1.LocalReport.DataSources.Add(reportDataSource2);
            this.Rpv1.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.Inversiones.rdlc";
            this.Rpv1.Location = new System.Drawing.Point(0, 0);
            this.Rpv1.Name = "Rpv1";
            this.Rpv1.ServerReport.BearerToken = null;
            this.Rpv1.Size = new System.Drawing.Size(800, 450);
            this.Rpv1.TabIndex = 0;
            // 
            // InvEncBindingSource
            // 
            this.InvEncBindingSource.DataSource = typeof(Arcoiris.Reportes.InvEnc);
            // 
            // InvDetBindingSource
            // 
            this.InvDetBindingSource.DataSource = typeof(Arcoiris.Reportes.InvDet);
            // 
            // Inversiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Rpv1);
            this.Name = "Inversiones";
            this.Text = "Inversiones";
            this.Load += new System.EventHandler(this.Inversiones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InvEncBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvDetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Rpv1;
        private System.Windows.Forms.BindingSource InvEncBindingSource;
        private System.Windows.Forms.BindingSource InvDetBindingSource;
    }
}