﻿namespace Arcoiris.Reportes
{
    partial class AtrasOrd
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
            this.Rep1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.AtrasosEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.AtrasosDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AtrasosEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtrasosDBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Rep1
            // 
            this.Rep1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Titulo";
            reportDataSource1.Value = this.AtrasosEBindingSource;
            reportDataSource2.Name = "Detalle";
            reportDataSource2.Value = this.AtrasosDBindingSource;
            this.Rep1.LocalReport.DataSources.Add(reportDataSource1);
            this.Rep1.LocalReport.DataSources.Add(reportDataSource2);
            this.Rep1.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.Atrasos.rdlc";
            this.Rep1.Location = new System.Drawing.Point(0, 0);
            this.Rep1.Name = "Rep1";
            this.Rep1.Size = new System.Drawing.Size(898, 313);
            this.Rep1.TabIndex = 0;
            // 
            // AtrasosEBindingSource
            // 
            this.AtrasosEBindingSource.DataSource = typeof(Arcoiris.Reportes.AtrasosE);
            // 
            // AtrasosDBindingSource
            // 
            this.AtrasosDBindingSource.DataSource = typeof(Arcoiris.Reportes.AtrasosD);
            // 
            // AtrasOrd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 313);
            this.Controls.Add(this.Rep1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AtrasOrd";
            this.Text = "Creditos atrasados";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AtrasOrd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AtrasosEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AtrasosDBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer Rep1;
        private System.Windows.Forms.BindingSource AtrasosEBindingSource;
        private System.Windows.Forms.BindingSource AtrasosDBindingSource;
    }
}