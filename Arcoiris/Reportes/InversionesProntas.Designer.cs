namespace Arcoiris.Reportes
{
    partial class InversionesProntas
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Rpv1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InvDetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InvDetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Rpv1
            // 
            this.Rpv1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "Datos";
            reportDataSource2.Value = this.InvDetBindingSource;
            this.Rpv1.LocalReport.DataSources.Add(reportDataSource2);
            this.Rpv1.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.InversionPronta.rdlc";
            this.Rpv1.Location = new System.Drawing.Point(0, 0);
            this.Rpv1.Name = "Rpv1";
            this.Rpv1.ServerReport.BearerToken = null;
            this.Rpv1.Size = new System.Drawing.Size(800, 450);
            this.Rpv1.TabIndex = 1;
            // 
            // InvDetBindingSource
            // 
            this.InvDetBindingSource.DataSource = typeof(Arcoiris.Reportes.InvDet);
            // 
            // InversionesProntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Rpv1);
            this.Name = "InversionesProntas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inversiones prontas a vencer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.InversionesProntas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InvDetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Rpv1;
        private System.Windows.Forms.BindingSource InvDetBindingSource;
    }
}