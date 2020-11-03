namespace Arcoiris.Formularios
{
    partial class Caja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Caja));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GbxCaja = new System.Windows.Forms.GroupBox();
            this.ChkAct = new System.Windows.Forms.CheckBox();
            this.BtnImprimir = new System.Windows.Forms.Button();
            this.BtnBusc = new System.Windows.Forms.Button();
            this.TxtIng = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtEgr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtLiquido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DgvMov = new System.Windows.Forms.DataGridView();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.CboOpe = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpFechaOpe = new System.Windows.Forms.DateTimePicker();
            this.TxtMonto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GbxCaja.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMov)).BeginInit();
            this.SuspendLayout();
            // 
            // GbxCaja
            // 
            this.GbxCaja.Controls.Add(this.ChkAct);
            this.GbxCaja.Controls.Add(this.BtnImprimir);
            this.GbxCaja.Controls.Add(this.BtnBusc);
            this.GbxCaja.Controls.Add(this.TxtIng);
            this.GbxCaja.Controls.Add(this.label6);
            this.GbxCaja.Controls.Add(this.TxtEgr);
            this.GbxCaja.Controls.Add(this.label5);
            this.GbxCaja.Controls.Add(this.TxtLiquido);
            this.GbxCaja.Controls.Add(this.label4);
            this.GbxCaja.Controls.Add(this.DgvMov);
            this.GbxCaja.Controls.Add(this.BtnActualizar);
            this.GbxCaja.Controls.Add(this.BtnEliminar);
            this.GbxCaja.Controls.Add(this.BtnAgregar);
            this.GbxCaja.Controls.Add(this.CboOpe);
            this.GbxCaja.Controls.Add(this.label3);
            this.GbxCaja.Controls.Add(this.TxtDesc);
            this.GbxCaja.Controls.Add(this.label2);
            this.GbxCaja.Controls.Add(this.DtpFechaOpe);
            this.GbxCaja.Controls.Add(this.TxtMonto);
            this.GbxCaja.Controls.Add(this.label1);
            this.GbxCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxCaja.Location = new System.Drawing.Point(0, 0);
            this.GbxCaja.Margin = new System.Windows.Forms.Padding(4);
            this.GbxCaja.Name = "GbxCaja";
            this.GbxCaja.Padding = new System.Windows.Forms.Padding(4);
            this.GbxCaja.Size = new System.Drawing.Size(764, 549);
            this.GbxCaja.TabIndex = 0;
            this.GbxCaja.TabStop = false;
            this.GbxCaja.Text = "Control de Caja";
            // 
            // ChkAct
            // 
            this.ChkAct.AutoSize = true;
            this.ChkAct.Location = new System.Drawing.Point(623, 194);
            this.ChkAct.Name = "ChkAct";
            this.ChkAct.Size = new System.Drawing.Size(70, 21);
            this.ChkAct.TabIndex = 19;
            this.ChkAct.Text = "Activar";
            this.ChkAct.UseVisualStyleBackColor = true;
            this.ChkAct.CheckedChanged += new System.EventHandler(this.ChkAct_CheckedChanged);
            // 
            // BtnImprimir
            // 
            this.BtnImprimir.FlatAppearance.BorderSize = 2;
            this.BtnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnImprimir.Location = new System.Drawing.Point(399, 230);
            this.BtnImprimir.Name = "BtnImprimir";
            this.BtnImprimir.Size = new System.Drawing.Size(100, 48);
            this.BtnImprimir.TabIndex = 18;
            this.BtnImprimir.Text = "Imprimir";
            this.BtnImprimir.UseVisualStyleBackColor = true;
            this.BtnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // BtnBusc
            // 
            this.BtnBusc.BackColor = System.Drawing.Color.Black;
            this.BtnBusc.FlatAppearance.BorderSize = 0;
            this.BtnBusc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBusc.Image = ((System.Drawing.Image)(resources.GetObject("BtnBusc.Image")));
            this.BtnBusc.Location = new System.Drawing.Point(565, 21);
            this.BtnBusc.Name = "BtnBusc";
            this.BtnBusc.Size = new System.Drawing.Size(64, 38);
            this.BtnBusc.TabIndex = 17;
            this.BtnBusc.UseVisualStyleBackColor = false;
            this.BtnBusc.Click += new System.EventHandler(this.BtnBusc_Click);
            // 
            // TxtIng
            // 
            this.TxtIng.Enabled = false;
            this.TxtIng.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtIng.Location = new System.Drawing.Point(321, 86);
            this.TxtIng.Multiline = true;
            this.TxtIng.Name = "TxtIng";
            this.TxtIng.Size = new System.Drawing.Size(106, 40);
            this.TxtIng.TabIndex = 16;
            this.TxtIng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Ingresos";
            // 
            // TxtEgr
            // 
            this.TxtEgr.Enabled = false;
            this.TxtEgr.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEgr.Location = new System.Drawing.Point(433, 86);
            this.TxtEgr.Multiline = true;
            this.TxtEgr.Name = "TxtEgr";
            this.TxtEgr.Size = new System.Drawing.Size(123, 40);
            this.TxtEgr.TabIndex = 14;
            this.TxtEgr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(430, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Egresos";
            // 
            // TxtLiquido
            // 
            this.TxtLiquido.Enabled = false;
            this.TxtLiquido.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtLiquido.Location = new System.Drawing.Point(562, 86);
            this.TxtLiquido.Multiline = true;
            this.TxtLiquido.Name = "TxtLiquido";
            this.TxtLiquido.Size = new System.Drawing.Size(123, 40);
            this.TxtLiquido.TabIndex = 12;
            this.TxtLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(559, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Liquido";
            // 
            // DgvMov
            // 
            this.DgvMov.AllowUserToAddRows = false;
            this.DgvMov.AllowUserToDeleteRows = false;
            this.DgvMov.AllowUserToResizeColumns = false;
            this.DgvMov.AllowUserToResizeRows = false;
            this.DgvMov.BackgroundColor = System.Drawing.Color.Khaki;
            this.DgvMov.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DgvMov.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvMov.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvMov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvMov.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DgvMov.EnableHeadersVisualStyles = false;
            this.DgvMov.Location = new System.Drawing.Point(4, 320);
            this.DgvMov.Margin = new System.Windows.Forms.Padding(4);
            this.DgvMov.MultiSelect = false;
            this.DgvMov.Name = "DgvMov";
            this.DgvMov.ReadOnly = true;
            this.DgvMov.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.DgvMov.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            this.DgvMov.RowTemplate.Height = 60;
            this.DgvMov.RowTemplate.ReadOnly = true;
            this.DgvMov.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvMov.Size = new System.Drawing.Size(756, 225);
            this.DgvMov.TabIndex = 10;
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.FlatAppearance.BorderSize = 2;
            this.BtnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnActualizar.Location = new System.Drawing.Point(506, 231);
            this.BtnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(100, 47);
            this.BtnActualizar.TabIndex = 9;
            this.BtnActualizar.Text = "Actualizar operacion";
            this.BtnActualizar.UseVisualStyleBackColor = true;
            this.BtnActualizar.Visible = false;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Enabled = false;
            this.BtnEliminar.FlatAppearance.BorderSize = 2;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Location = new System.Drawing.Point(507, 173);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(100, 50);
            this.BtnEliminar.TabIndex = 8;
            this.BtnEliminar.Text = "Eliminar Operacion";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.FlatAppearance.BorderSize = 2;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Location = new System.Drawing.Point(399, 173);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(100, 50);
            this.BtnAgregar.TabIndex = 7;
            this.BtnAgregar.Text = "Ingresar Operacion";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // CboOpe
            // 
            this.CboOpe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboOpe.FormattingEnabled = true;
            this.CboOpe.Location = new System.Drawing.Point(123, 65);
            this.CboOpe.Margin = new System.Windows.Forms.Padding(4);
            this.CboOpe.Name = "CboOpe";
            this.CboOpe.Size = new System.Drawing.Size(160, 25);
            this.CboOpe.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Operacion";
            // 
            // TxtDesc
            // 
            this.TxtDesc.Location = new System.Drawing.Point(123, 157);
            this.TxtDesc.Margin = new System.Windows.Forms.Padding(4);
            this.TxtDesc.MaxLength = 255;
            this.TxtDesc.Multiline = true;
            this.TxtDesc.Name = "TxtDesc";
            this.TxtDesc.Size = new System.Drawing.Size(258, 63);
            this.TxtDesc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 160);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descripcion";
            // 
            // DtpFechaOpe
            // 
            this.DtpFechaOpe.Enabled = false;
            this.DtpFechaOpe.Location = new System.Drawing.Point(223, 26);
            this.DtpFechaOpe.Margin = new System.Windows.Forms.Padding(4);
            this.DtpFechaOpe.Name = "DtpFechaOpe";
            this.DtpFechaOpe.Size = new System.Drawing.Size(335, 25);
            this.DtpFechaOpe.TabIndex = 2;
            // 
            // TxtMonto
            // 
            this.TxtMonto.Location = new System.Drawing.Point(123, 106);
            this.TxtMonto.Margin = new System.Windows.Forms.Padding(4);
            this.TxtMonto.MaxLength = 10;
            this.TxtMonto.Name = "TxtMonto";
            this.TxtMonto.Size = new System.Drawing.Size(128, 25);
            this.TxtMonto.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto";
            // 
            // Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(764, 549);
            this.Controls.Add(this.GbxCaja);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Caja";
            this.Text = "Caja";
            this.Load += new System.EventHandler(this.Caja_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Caja_KeyDown);
            this.GbxCaja.ResumeLayout(false);
            this.GbxCaja.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvMov)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxCaja;
        private System.Windows.Forms.ComboBox CboOpe;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpFechaOpe;
        private System.Windows.Forms.TextBox TxtMonto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DgvMov;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.TextBox TxtLiquido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtIng;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtEgr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnBusc;
        private System.Windows.Forms.Button BtnImprimir;
        private System.Windows.Forms.CheckBox ChkAct;
    }
}