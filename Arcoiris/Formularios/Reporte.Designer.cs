namespace Arcoiris.Formularios
{
    partial class Reporte
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.GbxD = new System.Windows.Forms.GroupBox();
            this.GbxPrest = new System.Windows.Forms.GroupBox();
            this.RdbPMens = new System.Windows.Forms.RadioButton();
            this.RdbPDia = new System.Windows.Forms.RadioButton();
            this.RdbPtodos = new System.Windows.Forms.RadioButton();
            this.BtnColo = new System.Windows.Forms.Button();
            this.BtnComi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CboAsesor = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DtpComiFin = new System.Windows.Forms.DateTimePicker();
            this.DtpComIni = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.GbxCreditos = new System.Windows.Forms.GroupBox();
            this.DtpFechaR = new System.Windows.Forms.DateTimePicker();
            this.LblFechaR = new System.Windows.Forms.Label();
            this.BtnReporte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CboCre = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GbxAs = new System.Windows.Forms.GroupBox();
            this.GbxGan = new System.Windows.Forms.GroupBox();
            this.RdbMes = new System.Windows.Forms.RadioButton();
            this.RdbDia = new System.Windows.Forms.RadioButton();
            this.RdbTodos = new System.Windows.Forms.RadioButton();
            this.BtnRepGan = new System.Windows.Forms.Button();
            this.CboAnio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CboMes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.GbxD.SuspendLayout();
            this.GbxPrest.SuspendLayout();
            this.panel2.SuspendLayout();
            this.GbxCreditos.SuspendLayout();
            this.panel3.SuspendLayout();
            this.GbxAs.SuspendLayout();
            this.GbxGan.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GbxD);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 298);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 251);
            this.panel1.TabIndex = 0;
            // 
            // GbxD
            // 
            this.GbxD.Controls.Add(this.GbxPrest);
            this.GbxD.Controls.Add(this.BtnColo);
            this.GbxD.Controls.Add(this.BtnComi);
            this.GbxD.Controls.Add(this.label6);
            this.GbxD.Controls.Add(this.CboAsesor);
            this.GbxD.Controls.Add(this.label5);
            this.GbxD.Controls.Add(this.label4);
            this.GbxD.Controls.Add(this.DtpComiFin);
            this.GbxD.Controls.Add(this.DtpComIni);
            this.GbxD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxD.Location = new System.Drawing.Point(0, 0);
            this.GbxD.Margin = new System.Windows.Forms.Padding(4);
            this.GbxD.Name = "GbxD";
            this.GbxD.Padding = new System.Windows.Forms.Padding(4);
            this.GbxD.Size = new System.Drawing.Size(765, 251);
            this.GbxD.TabIndex = 0;
            this.GbxD.TabStop = false;
            this.GbxD.Text = "Calculo de Comisiones";
            this.GbxD.Visible = false;
            // 
            // GbxPrest
            // 
            this.GbxPrest.Controls.Add(this.RdbPMens);
            this.GbxPrest.Controls.Add(this.RdbPDia);
            this.GbxPrest.Controls.Add(this.RdbPtodos);
            this.GbxPrest.Location = new System.Drawing.Point(370, 42);
            this.GbxPrest.Name = "GbxPrest";
            this.GbxPrest.Size = new System.Drawing.Size(155, 113);
            this.GbxPrest.TabIndex = 8;
            this.GbxPrest.TabStop = false;
            this.GbxPrest.Text = "Categoria";
            // 
            // RdbPMens
            // 
            this.RdbPMens.AutoSize = true;
            this.RdbPMens.Location = new System.Drawing.Point(7, 78);
            this.RdbPMens.Name = "RdbPMens";
            this.RdbPMens.Size = new System.Drawing.Size(91, 21);
            this.RdbPMens.TabIndex = 2;
            this.RdbPMens.Text = "Mensuales";
            this.RdbPMens.UseVisualStyleBackColor = true;
            // 
            // RdbPDia
            // 
            this.RdbPDia.AutoSize = true;
            this.RdbPDia.Location = new System.Drawing.Point(7, 51);
            this.RdbPDia.Name = "RdbPDia";
            this.RdbPDia.Size = new System.Drawing.Size(70, 21);
            this.RdbPDia.TabIndex = 1;
            this.RdbPDia.Text = "Diarios";
            this.RdbPDia.UseVisualStyleBackColor = true;
            // 
            // RdbPtodos
            // 
            this.RdbPtodos.AutoSize = true;
            this.RdbPtodos.Checked = true;
            this.RdbPtodos.Location = new System.Drawing.Point(7, 24);
            this.RdbPtodos.Name = "RdbPtodos";
            this.RdbPtodos.Size = new System.Drawing.Size(63, 21);
            this.RdbPtodos.TabIndex = 0;
            this.RdbPtodos.TabStop = true;
            this.RdbPtodos.Text = "Todos";
            this.RdbPtodos.UseVisualStyleBackColor = true;
            // 
            // BtnColo
            // 
            this.BtnColo.Location = new System.Drawing.Point(370, 161);
            this.BtnColo.Name = "BtnColo";
            this.BtnColo.Size = new System.Drawing.Size(149, 44);
            this.BtnColo.TabIndex = 7;
            this.BtnColo.Text = "Colocación de creditos";
            this.BtnColo.UseVisualStyleBackColor = true;
            this.BtnColo.Click += new System.EventHandler(this.BtnColo_Click);
            // 
            // BtnComi
            // 
            this.BtnComi.Location = new System.Drawing.Point(28, 147);
            this.BtnComi.Name = "BtnComi";
            this.BtnComi.Size = new System.Drawing.Size(149, 39);
            this.BtnComi.TabIndex = 6;
            this.BtnComi.Text = "Mostrar Comisiones";
            this.BtnComi.UseVisualStyleBackColor = true;
            this.BtnComi.Click += new System.EventHandler(this.BtnComi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Asesor";
            // 
            // CboAsesor
            // 
            this.CboAsesor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboAsesor.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboAsesor.FormattingEnabled = true;
            this.CboAsesor.Location = new System.Drawing.Point(28, 42);
            this.CboAsesor.Name = "CboAsesor";
            this.CboAsesor.Size = new System.Drawing.Size(320, 23);
            this.CboAsesor.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(196, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "Hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Desde";
            // 
            // DtpComiFin
            // 
            this.DtpComiFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpComiFin.Location = new System.Drawing.Point(199, 94);
            this.DtpComiFin.Name = "DtpComiFin";
            this.DtpComiFin.Size = new System.Drawing.Size(149, 25);
            this.DtpComiFin.TabIndex = 1;
            // 
            // DtpComIni
            // 
            this.DtpComIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpComIni.Location = new System.Drawing.Point(28, 94);
            this.DtpComIni.Name = "DtpComIni";
            this.DtpComIni.Size = new System.Drawing.Size(138, 25);
            this.DtpComIni.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.GbxCreditos);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(348, 298);
            this.panel2.TabIndex = 1;
            // 
            // GbxCreditos
            // 
            this.GbxCreditos.Controls.Add(this.DtpFechaR);
            this.GbxCreditos.Controls.Add(this.LblFechaR);
            this.GbxCreditos.Controls.Add(this.BtnReporte);
            this.GbxCreditos.Controls.Add(this.label1);
            this.GbxCreditos.Controls.Add(this.CboCre);
            this.GbxCreditos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxCreditos.Location = new System.Drawing.Point(0, 0);
            this.GbxCreditos.Margin = new System.Windows.Forms.Padding(4);
            this.GbxCreditos.Name = "GbxCreditos";
            this.GbxCreditos.Padding = new System.Windows.Forms.Padding(4);
            this.GbxCreditos.Size = new System.Drawing.Size(348, 298);
            this.GbxCreditos.TabIndex = 0;
            this.GbxCreditos.TabStop = false;
            this.GbxCreditos.Text = "Creditos";
            // 
            // DtpFechaR
            // 
            this.DtpFechaR.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFechaR.Location = new System.Drawing.Point(154, 92);
            this.DtpFechaR.Name = "DtpFechaR";
            this.DtpFechaR.Size = new System.Drawing.Size(133, 25);
            this.DtpFechaR.TabIndex = 6;
            this.DtpFechaR.Visible = false;
            // 
            // LblFechaR
            // 
            this.LblFechaR.AutoSize = true;
            this.LblFechaR.Location = new System.Drawing.Point(55, 98);
            this.LblFechaR.Name = "LblFechaR";
            this.LblFechaR.Size = new System.Drawing.Size(83, 17);
            this.LblFechaR.TabIndex = 5;
            this.LblFechaR.Text = "Dia de pago";
            this.LblFechaR.Visible = false;
            // 
            // BtnReporte
            // 
            this.BtnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReporte.Location = new System.Drawing.Point(107, 135);
            this.BtnReporte.Name = "BtnReporte";
            this.BtnReporte.Size = new System.Drawing.Size(133, 38);
            this.BtnReporte.TabIndex = 2;
            this.BtnReporte.Text = "Ver Reporte";
            this.BtnReporte.UseVisualStyleBackColor = true;
            this.BtnReporte.Click += new System.EventHandler(this.BtnReporte_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Creditos";
            // 
            // CboCre
            // 
            this.CboCre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboCre.FormattingEnabled = true;
            this.CboCre.Location = new System.Drawing.Point(28, 49);
            this.CboCre.Name = "CboCre";
            this.CboCre.Size = new System.Drawing.Size(296, 25);
            this.CboCre.TabIndex = 0;
            this.CboCre.SelectedIndexChanged += new System.EventHandler(this.CboCre_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.GbxAs);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(385, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(380, 298);
            this.panel3.TabIndex = 2;
            // 
            // GbxAs
            // 
            this.GbxAs.Controls.Add(this.GbxGan);
            this.GbxAs.Controls.Add(this.BtnRepGan);
            this.GbxAs.Controls.Add(this.CboAnio);
            this.GbxAs.Controls.Add(this.label3);
            this.GbxAs.Controls.Add(this.CboMes);
            this.GbxAs.Controls.Add(this.label2);
            this.GbxAs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxAs.Location = new System.Drawing.Point(0, 0);
            this.GbxAs.Margin = new System.Windows.Forms.Padding(4);
            this.GbxAs.Name = "GbxAs";
            this.GbxAs.Padding = new System.Windows.Forms.Padding(4);
            this.GbxAs.Size = new System.Drawing.Size(380, 298);
            this.GbxAs.TabIndex = 0;
            this.GbxAs.TabStop = false;
            this.GbxAs.Text = "Asesores";
            // 
            // GbxGan
            // 
            this.GbxGan.Controls.Add(this.RdbMes);
            this.GbxGan.Controls.Add(this.RdbDia);
            this.GbxGan.Controls.Add(this.RdbTodos);
            this.GbxGan.Location = new System.Drawing.Point(183, 144);
            this.GbxGan.Name = "GbxGan";
            this.GbxGan.Size = new System.Drawing.Size(155, 116);
            this.GbxGan.TabIndex = 5;
            this.GbxGan.TabStop = false;
            this.GbxGan.Text = "Categoria";
            // 
            // RdbMes
            // 
            this.RdbMes.AutoSize = true;
            this.RdbMes.Location = new System.Drawing.Point(22, 84);
            this.RdbMes.Name = "RdbMes";
            this.RdbMes.Size = new System.Drawing.Size(91, 21);
            this.RdbMes.TabIndex = 2;
            this.RdbMes.Text = "Mensuales";
            this.RdbMes.UseVisualStyleBackColor = true;
            // 
            // RdbDia
            // 
            this.RdbDia.AutoSize = true;
            this.RdbDia.Location = new System.Drawing.Point(22, 54);
            this.RdbDia.Name = "RdbDia";
            this.RdbDia.Size = new System.Drawing.Size(70, 21);
            this.RdbDia.TabIndex = 1;
            this.RdbDia.Text = "Diarios";
            this.RdbDia.UseVisualStyleBackColor = true;
            // 
            // RdbTodos
            // 
            this.RdbTodos.AutoSize = true;
            this.RdbTodos.Checked = true;
            this.RdbTodos.Location = new System.Drawing.Point(22, 26);
            this.RdbTodos.Name = "RdbTodos";
            this.RdbTodos.Size = new System.Drawing.Size(63, 21);
            this.RdbTodos.TabIndex = 0;
            this.RdbTodos.TabStop = true;
            this.RdbTodos.Text = "Todos";
            this.RdbTodos.UseVisualStyleBackColor = true;
            // 
            // BtnRepGan
            // 
            this.BtnRepGan.Location = new System.Drawing.Point(48, 163);
            this.BtnRepGan.Name = "BtnRepGan";
            this.BtnRepGan.Size = new System.Drawing.Size(120, 35);
            this.BtnRepGan.TabIndex = 4;
            this.BtnRepGan.Text = "Ganancias";
            this.BtnRepGan.UseVisualStyleBackColor = true;
            this.BtnRepGan.Click += new System.EventHandler(this.BtnRepGan_Click);
            // 
            // CboAnio
            // 
            this.CboAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboAnio.FormattingEnabled = true;
            this.CboAnio.Location = new System.Drawing.Point(128, 92);
            this.CboAnio.Name = "CboAnio";
            this.CboAnio.Size = new System.Drawing.Size(210, 25);
            this.CboAnio.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Año";
            // 
            // CboMes
            // 
            this.CboMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboMes.FormattingEnabled = true;
            this.CboMes.Location = new System.Drawing.Point(128, 45);
            this.CboMes.Name = "CboMes";
            this.CboMes.Size = new System.Drawing.Size(210, 25);
            this.CboMes.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mes";
            // 
            // Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(765, 549);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Reporte";
            this.Text = "Reporte";
            this.Load += new System.EventHandler(this.Reporte_Load);
            this.panel1.ResumeLayout(false);
            this.GbxD.ResumeLayout(false);
            this.GbxD.PerformLayout();
            this.GbxPrest.ResumeLayout(false);
            this.GbxPrest.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.GbxCreditos.ResumeLayout(false);
            this.GbxCreditos.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.GbxAs.ResumeLayout(false);
            this.GbxAs.PerformLayout();
            this.GbxGan.ResumeLayout(false);
            this.GbxGan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox GbxD;
        private System.Windows.Forms.GroupBox GbxCreditos;
        private System.Windows.Forms.GroupBox GbxAs;
        private System.Windows.Forms.Button BtnReporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CboCre;
        private System.Windows.Forms.Button BtnRepGan;
        private System.Windows.Forms.ComboBox CboAnio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CboMes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnComi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CboAsesor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtpComiFin;
        private System.Windows.Forms.DateTimePicker DtpComIni;
        private System.Windows.Forms.GroupBox GbxGan;
        private System.Windows.Forms.RadioButton RdbMes;
        private System.Windows.Forms.RadioButton RdbDia;
        private System.Windows.Forms.RadioButton RdbTodos;
        private System.Windows.Forms.DateTimePicker DtpFechaR;
        private System.Windows.Forms.Label LblFechaR;
        private System.Windows.Forms.Button BtnColo;
        private System.Windows.Forms.GroupBox GbxPrest;
        private System.Windows.Forms.RadioButton RdbPMens;
        private System.Windows.Forms.RadioButton RdbPDia;
        private System.Windows.Forms.RadioButton RdbPtodos;
    }
}