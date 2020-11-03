namespace Arcoiris.Formularios
{
    partial class FormRep
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.RepEncBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RepDetalle1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RepDesemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PanelLat = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnDesem = new System.Windows.Forms.Button();
            this.BtnCli = new System.Windows.Forms.Button();
            this.BtnVerRep = new System.Windows.Forms.Button();
            this.CboAnio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CboMes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGanacia = new System.Windows.Forms.Button();
            this.BtnRep = new System.Windows.Forms.Button();
            this.PanelAseso = new System.Windows.Forms.Panel();
            this.CboAsesor = new System.Windows.Forms.ComboBox();
            this.ChkAsesor = new System.Windows.Forms.CheckBox();
            this.PanelCli = new System.Windows.Forms.Panel();
            this.CboClientes = new System.Windows.Forms.ComboBox();
            this.ChkClientes = new System.Windows.Forms.CheckBox();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.Lblitulo = new System.Windows.Forms.Label();
            this.PanelC = new System.Windows.Forms.Panel();
            this.ReportD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.ReportG = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Reporte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TmrMostrar = new System.Windows.Forms.Timer(this.components);
            this.TmrOcultar = new System.Windows.Forms.Timer(this.components);
            this.ReporteC = new Microsoft.Reporting.WinForms.ReportViewer();
            this.RepDetCliBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.RepEncBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepDetalle1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepDesemBindingSource)).BeginInit();
            this.PanelLat.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PanelAseso.SuspendLayout();
            this.PanelCli.SuspendLayout();
            this.PanelTitulo.SuspendLayout();
            this.PanelC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RepDetCliBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RepEncBindingSource
            // 
            this.RepEncBindingSource.DataSource = typeof(Arcoiris.Reportes.RepEnc);
            // 
            // RepDetalle1BindingSource
            // 
            this.RepDetalle1BindingSource.DataSource = typeof(Arcoiris.Reportes.RepDetalle1);
            // 
            // RepDesemBindingSource
            // 
            this.RepDesemBindingSource.DataSource = typeof(Arcoiris.Reportes.RepDesem);
            // 
            // PanelLat
            // 
            this.PanelLat.Controls.Add(this.button2);
            this.PanelLat.Controls.Add(this.panel1);
            this.PanelLat.Controls.Add(this.PanelAseso);
            this.PanelLat.Controls.Add(this.PanelCli);
            this.PanelLat.Controls.Add(this.PanelTitulo);
            this.PanelLat.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLat.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelLat.Location = new System.Drawing.Point(0, 0);
            this.PanelLat.Name = "PanelLat";
            this.PanelLat.Size = new System.Drawing.Size(149, 591);
            this.PanelLat.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(0, 540);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 26);
            this.button2.TabIndex = 19;
            this.button2.Text = "Salir";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnDesem);
            this.panel1.Controls.Add(this.BtnCli);
            this.panel1.Controls.Add(this.BtnVerRep);
            this.panel1.Controls.Add(this.CboAnio);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CboMes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.BtnGanacia);
            this.panel1.Controls.Add(this.BtnRep);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 179);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(149, 336);
            this.panel1.TabIndex = 3;
            // 
            // BtnDesem
            // 
            this.BtnDesem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDesem.Location = new System.Drawing.Point(2, 279);
            this.BtnDesem.Name = "BtnDesem";
            this.BtnDesem.Size = new System.Drawing.Size(143, 47);
            this.BtnDesem.TabIndex = 18;
            this.BtnDesem.Text = "Reporte de desembolso";
            this.BtnDesem.UseVisualStyleBackColor = true;
            this.BtnDesem.Click += new System.EventHandler(this.BtnDesem_Click);
            // 
            // BtnCli
            // 
            this.BtnCli.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCli.Location = new System.Drawing.Point(2, 209);
            this.BtnCli.Name = "BtnCli";
            this.BtnCli.Size = new System.Drawing.Size(143, 26);
            this.BtnCli.TabIndex = 17;
            this.BtnCli.Text = "Estado de cliente";
            this.BtnCli.UseVisualStyleBackColor = true;
            this.BtnCli.Click += new System.EventHandler(this.BtnCli_Click);
            // 
            // BtnVerRep
            // 
            this.BtnVerRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnVerRep.Location = new System.Drawing.Point(2, 145);
            this.BtnVerRep.Name = "BtnVerRep";
            this.BtnVerRep.Size = new System.Drawing.Size(143, 26);
            this.BtnVerRep.TabIndex = 16;
            this.BtnVerRep.Text = "Ver reporte";
            this.BtnVerRep.UseVisualStyleBackColor = true;
            this.BtnVerRep.Click += new System.EventHandler(this.BtnVerRep_Click);
            // 
            // CboAnio
            // 
            this.CboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboAnio.FormattingEnabled = true;
            this.CboAnio.Location = new System.Drawing.Point(3, 91);
            this.CboAnio.Name = "CboAnio";
            this.CboAnio.Size = new System.Drawing.Size(140, 25);
            this.CboAnio.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Año";
            // 
            // CboMes
            // 
            this.CboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboMes.FormattingEnabled = true;
            this.CboMes.Location = new System.Drawing.Point(3, 39);
            this.CboMes.Name = "CboMes";
            this.CboMes.Size = new System.Drawing.Size(140, 25);
            this.CboMes.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mes";
            // 
            // BtnGanacia
            // 
            this.BtnGanacia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGanacia.Location = new System.Drawing.Point(3, 245);
            this.BtnGanacia.Name = "BtnGanacia";
            this.BtnGanacia.Size = new System.Drawing.Size(143, 26);
            this.BtnGanacia.TabIndex = 10;
            this.BtnGanacia.Text = "Reporte Ganancia";
            this.BtnGanacia.UseVisualStyleBackColor = true;
            this.BtnGanacia.Click += new System.EventHandler(this.BtnGanacia_Click);
            // 
            // BtnRep
            // 
            this.BtnRep.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRep.Location = new System.Drawing.Point(2, 177);
            this.BtnRep.Name = "BtnRep";
            this.BtnRep.Size = new System.Drawing.Size(143, 26);
            this.BtnRep.TabIndex = 9;
            this.BtnRep.Text = "Reporte General";
            this.BtnRep.UseVisualStyleBackColor = true;
            this.BtnRep.Click += new System.EventHandler(this.BtnRep_Click);
            // 
            // PanelAseso
            // 
            this.PanelAseso.Controls.Add(this.CboAsesor);
            this.PanelAseso.Controls.Add(this.ChkAsesor);
            this.PanelAseso.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelAseso.Location = new System.Drawing.Point(0, 119);
            this.PanelAseso.Name = "PanelAseso";
            this.PanelAseso.Size = new System.Drawing.Size(149, 60);
            this.PanelAseso.TabIndex = 2;
            // 
            // CboAsesor
            // 
            this.CboAsesor.FormattingEnabled = true;
            this.CboAsesor.Location = new System.Drawing.Point(3, 29);
            this.CboAsesor.Name = "CboAsesor";
            this.CboAsesor.Size = new System.Drawing.Size(143, 25);
            this.CboAsesor.TabIndex = 1;
            // 
            // ChkAsesor
            // 
            this.ChkAsesor.AutoSize = true;
            this.ChkAsesor.Location = new System.Drawing.Point(3, 6);
            this.ChkAsesor.Name = "ChkAsesor";
            this.ChkAsesor.Size = new System.Drawing.Size(81, 21);
            this.ChkAsesor.TabIndex = 0;
            this.ChkAsesor.Text = "Asesores";
            this.ChkAsesor.UseVisualStyleBackColor = true;
            this.ChkAsesor.CheckedChanged += new System.EventHandler(this.ChkAsesor_CheckedChanged);
            // 
            // PanelCli
            // 
            this.PanelCli.Controls.Add(this.CboClientes);
            this.PanelCli.Controls.Add(this.ChkClientes);
            this.PanelCli.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelCli.Location = new System.Drawing.Point(0, 59);
            this.PanelCli.Name = "PanelCli";
            this.PanelCli.Size = new System.Drawing.Size(149, 60);
            this.PanelCli.TabIndex = 1;
            // 
            // CboClientes
            // 
            this.CboClientes.FormattingEnabled = true;
            this.CboClientes.Location = new System.Drawing.Point(3, 32);
            this.CboClientes.Name = "CboClientes";
            this.CboClientes.Size = new System.Drawing.Size(143, 25);
            this.CboClientes.TabIndex = 1;
            // 
            // ChkClientes
            // 
            this.ChkClientes.AutoSize = true;
            this.ChkClientes.Location = new System.Drawing.Point(3, 6);
            this.ChkClientes.Name = "ChkClientes";
            this.ChkClientes.Size = new System.Drawing.Size(76, 21);
            this.ChkClientes.TabIndex = 0;
            this.ChkClientes.Text = "Clientes";
            this.ChkClientes.UseVisualStyleBackColor = true;
            this.ChkClientes.CheckedChanged += new System.EventHandler(this.ChkClientes_CheckedChanged);
            // 
            // PanelTitulo
            // 
            this.PanelTitulo.Controls.Add(this.Lblitulo);
            this.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitulo.Location = new System.Drawing.Point(0, 0);
            this.PanelTitulo.Name = "PanelTitulo";
            this.PanelTitulo.Size = new System.Drawing.Size(149, 59);
            this.PanelTitulo.TabIndex = 0;
            // 
            // Lblitulo
            // 
            this.Lblitulo.Location = new System.Drawing.Point(29, 9);
            this.Lblitulo.Name = "Lblitulo";
            this.Lblitulo.Size = new System.Drawing.Size(100, 48);
            this.Lblitulo.TabIndex = 0;
            this.Lblitulo.Text = "Reporte de creditos general";
            this.Lblitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelC
            // 
            this.PanelC.Controls.Add(this.ReporteC);
            this.PanelC.Controls.Add(this.ReportD);
            this.PanelC.Controls.Add(this.ReportG);
            this.PanelC.Controls.Add(this.Reporte);
            this.PanelC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelC.Location = new System.Drawing.Point(149, 0);
            this.PanelC.Name = "PanelC";
            this.PanelC.Size = new System.Drawing.Size(688, 591);
            this.PanelC.TabIndex = 1;
            // 
            // ReportD
            // 
            this.ReportD.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DesemDet";
            reportDataSource3.Value = this.RepDesemBindingSource;
            reportDataSource4.Name = "encabezado";
            reportDataSource4.Value = this.RepEncBindingSource;
            this.ReportD.LocalReport.DataSources.Add(reportDataSource3);
            this.ReportD.LocalReport.DataSources.Add(reportDataSource4);
            this.ReportD.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.Desembolso.rdlc";
            this.ReportD.Location = new System.Drawing.Point(0, 0);
            this.ReportD.Name = "ReportD";
            this.ReportD.Size = new System.Drawing.Size(688, 591);
            this.ReportD.TabIndex = 2;
            this.ReportD.Visible = false;
            // 
            // ReportG
            // 
            this.ReportG.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource5.Name = "encabezado";
            reportDataSource5.Value = this.RepEncBindingSource;
            reportDataSource6.Name = "DetalleRep";
            reportDataSource6.Value = this.RepDetalle1BindingSource;
            this.ReportG.LocalReport.DataSources.Add(reportDataSource5);
            this.ReportG.LocalReport.DataSources.Add(reportDataSource6);
            this.ReportG.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.REpGanacia.rdlc";
            this.ReportG.Location = new System.Drawing.Point(0, 0);
            this.ReportG.Name = "ReportG";
            this.ReportG.Size = new System.Drawing.Size(688, 591);
            this.ReportG.TabIndex = 1;
            this.ReportG.Visible = false;
            // 
            // Reporte
            // 
            this.Reporte.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource7.Name = "encabezado";
            reportDataSource7.Value = this.RepEncBindingSource;
            reportDataSource8.Name = "DetalleRep";
            reportDataSource8.Value = this.RepDetalle1BindingSource;
            this.Reporte.LocalReport.DataSources.Add(reportDataSource7);
            this.Reporte.LocalReport.DataSources.Add(reportDataSource8);
            this.Reporte.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.Reporte1.rdlc";
            this.Reporte.Location = new System.Drawing.Point(0, 0);
            this.Reporte.Name = "Reporte";
            this.Reporte.ShowCredentialPrompts = false;
            this.Reporte.ShowDocumentMapButton = false;
            this.Reporte.ShowFindControls = false;
            this.Reporte.ShowParameterPrompts = false;
            this.Reporte.ShowPromptAreaButton = false;
            this.Reporte.Size = new System.Drawing.Size(688, 591);
            this.Reporte.TabIndex = 0;
            this.Reporte.Visible = false;
            // 
            // TmrMostrar
            // 
            this.TmrMostrar.Tick += new System.EventHandler(this.TmrMostrar_Tick);
            // 
            // TmrOcultar
            // 
            this.TmrOcultar.Tick += new System.EventHandler(this.TmrOcultar_Tick);
            // 
            // ReporteC
            // 
            this.ReporteC.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DetalleCli";
            reportDataSource1.Value = this.RepDetCliBindingSource;
            reportDataSource2.Name = "encabezado";
            reportDataSource2.Value = this.RepEncBindingSource;
            this.ReporteC.LocalReport.DataSources.Add(reportDataSource1);
            this.ReporteC.LocalReport.DataSources.Add(reportDataSource2);
            this.ReporteC.LocalReport.ReportEmbeddedResource = "Arcoiris.Reportes.EstadoCli.rdlc";
            this.ReporteC.Location = new System.Drawing.Point(0, 0);
            this.ReporteC.Name = "ReporteC";
            this.ReporteC.Size = new System.Drawing.Size(688, 591);
            this.ReporteC.TabIndex = 3;
            this.ReporteC.Visible = false;
            // 
            // RepDetCliBindingSource
            // 
            this.RepDetCliBindingSource.DataSource = typeof(Arcoiris.Reportes.RepDetCli);
            // 
            // FormRep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(837, 591);
            this.Controls.Add(this.PanelC);
            this.Controls.Add(this.PanelLat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRep";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportesGen";
            this.Load += new System.EventHandler(this.FormRep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RepEncBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepDetalle1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepDesemBindingSource)).EndInit();
            this.PanelLat.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PanelAseso.ResumeLayout(false);
            this.PanelAseso.PerformLayout();
            this.PanelCli.ResumeLayout(false);
            this.PanelCli.PerformLayout();
            this.PanelTitulo.ResumeLayout(false);
            this.PanelC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RepDetCliBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelLat;
        private System.Windows.Forms.Panel PanelAseso;
        private System.Windows.Forms.Panel PanelCli;
        private System.Windows.Forms.CheckBox ChkClientes;
        private System.Windows.Forms.Panel PanelTitulo;
        private System.Windows.Forms.Label Lblitulo;
        private System.Windows.Forms.CheckBox ChkAsesor;
        private System.Windows.Forms.ComboBox CboClientes;
        private System.Windows.Forms.ComboBox CboAsesor;
        private System.Windows.Forms.Panel PanelC;
        private Microsoft.Reporting.WinForms.ReportViewer Reporte;
        private System.Windows.Forms.Timer TmrMostrar;
        private System.Windows.Forms.Timer TmrOcultar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox CboAnio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CboMes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGanacia;
        private System.Windows.Forms.Button BtnRep;
        private System.Windows.Forms.Button BtnVerRep;
        private System.Windows.Forms.BindingSource RepEncBindingSource;
        private System.Windows.Forms.BindingSource RepDetalle1BindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer ReportG;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BtnCli;
        private System.Windows.Forms.Button BtnDesem;
        private Microsoft.Reporting.WinForms.ReportViewer ReportD;
        private System.Windows.Forms.BindingSource RepDesemBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer ReporteC;
        private System.Windows.Forms.BindingSource RepDetCliBindingSource;
    }
}