﻿namespace Arcoiris.Reportes
{
    partial class CajaRep
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CajaRep));
            this.RepEncBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RepDetCliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.RepEncBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepDetCliBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RepEncBindingSource
            // 
            this.RepEncBindingSource.DataSource = typeof(Arcoiris.Reportes.RepEnc);
            // 
            // RepDetCliBindingSource
            // 
            this.RepDetCliBindingSource.DataSource = typeof(Arcoiris.Reportes.RepDetCli);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Encabezado";
            reportDataSource1.Value = this.RepEncBindingSource;
            reportDataSource2.Name = "Detalle";
            reportDataSource2.Value = this.RepDetCliBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.CajaRep.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(645, 261);
            this.reportViewer1.TabIndex = 0;
            // 
            // CajaRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 261);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CajaRep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CajaRep";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CajaRep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RepEncBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepDetCliBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource RepEncBindingSource;
        private System.Windows.Forms.BindingSource RepDetCliBindingSource;
    }
}