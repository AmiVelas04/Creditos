namespace Arcoiris.Reportes
{
    partial class Credi_Activ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Credi_Activ));
            this.RepEncBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Credi_ActivityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Rpv1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.RepEncBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Credi_ActivityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RepEncBindingSource
            // 
            this.RepEncBindingSource.DataSource = typeof(Arcoiris.Reportes.RepEnc);
            // 
            // Credi_ActivityBindingSource
            // 
            this.Credi_ActivityBindingSource.DataSource = typeof(Arcoiris.Reportes.Credi_Activity);
            // 
            // Rpv1
            // 
            this.Rpv1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Encabezado";
            reportDataSource1.Value = this.RepEncBindingSource;
            reportDataSource2.Name = "Detalle";
            reportDataSource2.Value = this.Credi_ActivityBindingSource;
            this.Rpv1.LocalReport.DataSources.Add(reportDataSource1);
            this.Rpv1.LocalReport.DataSources.Add(reportDataSource2);
            this.Rpv1.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.Credi_Activ.rdlc";
            this.Rpv1.Location = new System.Drawing.Point(0, 0);
            this.Rpv1.Name = "Rpv1";
            this.Rpv1.Size = new System.Drawing.Size(791, 351);
            this.Rpv1.TabIndex = 0;
            // 
            // Credi_Activ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 351);
            this.Controls.Add(this.Rpv1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Credi_Activ";
            this.Text = "Creditos Activos";
            this.Load += new System.EventHandler(this.Credi_Activ_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RepEncBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Credi_ActivityBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Rpv1;
        private System.Windows.Forms.BindingSource RepEncBindingSource;
        private System.Windows.Forms.BindingSource Credi_ActivityBindingSource;
    }
}