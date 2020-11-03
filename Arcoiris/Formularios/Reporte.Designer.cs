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
            this.panel2 = new System.Windows.Forms.Panel();
            this.GbxCreditos = new System.Windows.Forms.GroupBox();
            this.BtnCartera = new System.Windows.Forms.Button();
            this.BtnReporte = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CboCre = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GbxAs = new System.Windows.Forms.GroupBox();
            this.BtnRepGan = new System.Windows.Forms.Button();
            this.CboAnio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CboMes = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.GbxCreditos.SuspendLayout();
            this.panel3.SuspendLayout();
            this.GbxAs.SuspendLayout();
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
            this.GbxD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxD.Location = new System.Drawing.Point(0, 0);
            this.GbxD.Margin = new System.Windows.Forms.Padding(4);
            this.GbxD.Name = "GbxD";
            this.GbxD.Padding = new System.Windows.Forms.Padding(4);
            this.GbxD.Size = new System.Drawing.Size(765, 251);
            this.GbxD.TabIndex = 0;
            this.GbxD.TabStop = false;
            this.GbxD.Text = "Cartera";
            this.GbxD.Visible = false;
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
            this.GbxCreditos.Controls.Add(this.BtnCartera);
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
            // BtnCartera
            // 
            this.BtnCartera.Location = new System.Drawing.Point(108, 228);
            this.BtnCartera.Name = "BtnCartera";
            this.BtnCartera.Size = new System.Drawing.Size(138, 43);
            this.BtnCartera.TabIndex = 4;
            this.BtnCartera.Text = "Repore de mora Detallada";
            this.BtnCartera.UseVisualStyleBackColor = true;
            this.BtnCartera.Visible = false;
            // 
            // BtnReporte
            // 
            this.BtnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReporte.Location = new System.Drawing.Point(113, 95);
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
            // BtnRepGan
            // 
            this.BtnRepGan.Location = new System.Drawing.Point(151, 152);
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
            this.panel2.ResumeLayout(false);
            this.GbxCreditos.ResumeLayout(false);
            this.GbxCreditos.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.GbxAs.ResumeLayout(false);
            this.GbxAs.PerformLayout();
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
        private System.Windows.Forms.Button BtnCartera;
    }
}