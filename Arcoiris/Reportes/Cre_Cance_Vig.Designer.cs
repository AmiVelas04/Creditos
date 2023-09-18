namespace Arcoiris.Reportes
{
    partial class Cre_Cance_Vig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cre_Cance_Vig));
            this.RepDetCliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RepEncBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.RepDetCliBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepEncBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RepDetCliBindingSource
            // 
            this.RepDetCliBindingSource.DataSource = typeof(Arcoiris.Reportes.RepDetCli);
            // 
            // RepEncBindingSource
            // 
            this.RepEncBindingSource.DataSource = typeof(Arcoiris.Reportes.RepEnc);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Detalle";
            reportDataSource1.Value = this.RepDetCliBindingSource;
            reportDataSource2.Name = "Encabezado";
            reportDataSource2.Value = this.RepEncBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.Cre_Cance_Vig.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(761, 276);
            this.reportViewer1.TabIndex = 0;
            // 
            // Cre_Cance_Vig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 276);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Cre_Cance_Vig";
            this.Text = "Cre_Cance_Vig";
            this.Load += new System.EventHandler(this.Cre_Cance_Vig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RepDetCliBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepEncBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RepDetCliBindingSource;
        private System.Windows.Forms.BindingSource RepEncBindingSource;
    }
}