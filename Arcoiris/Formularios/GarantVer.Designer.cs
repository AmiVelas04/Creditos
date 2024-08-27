namespace Arcoiris.Formularios
{
    partial class GarantVer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GarantVer));
            this.PanCentral = new System.Windows.Forms.Panel();
            this.TxtEstado = new System.Windows.Forms.TextBox();
            this.CboEstado = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ChkChanFecha = new System.Windows.Forms.CheckBox();
            this.CboTipGar = new System.Windows.Forms.ComboBox();
            this.BtnDesbloq = new System.Windows.Forms.Button();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.TxtAut = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.LblGarant = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.TxtUbi = new System.Windows.Forms.TextBox();
            this.TxtValu = new System.Windows.Forms.TextBox();
            this.TxtFEsc = new System.Windows.Forms.TextBox();
            this.TxtTipEsc = new System.Windows.Forms.TextBox();
            this.TxtGarDet = new System.Windows.Forms.TextBox();
            this.TxtCli = new System.Windows.Forms.TextBox();
            this.TxtCre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmdContra = new System.Windows.Forms.Button();
            this.PanCentral.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanCentral
            // 
            this.PanCentral.Controls.Add(this.CmdContra);
            this.PanCentral.Controls.Add(this.TxtEstado);
            this.PanCentral.Controls.Add(this.CboEstado);
            this.PanCentral.Controls.Add(this.label10);
            this.PanCentral.Controls.Add(this.ChkChanFecha);
            this.PanCentral.Controls.Add(this.CboTipGar);
            this.PanCentral.Controls.Add(this.BtnDesbloq);
            this.PanCentral.Controls.Add(this.DtpFecha);
            this.PanCentral.Controls.Add(this.TxtAut);
            this.PanCentral.Controls.Add(this.label9);
            this.PanCentral.Controls.Add(this.LblGarant);
            this.PanCentral.Controls.Add(this.BtnGuardar);
            this.PanCentral.Controls.Add(this.TxtUbi);
            this.PanCentral.Controls.Add(this.TxtValu);
            this.PanCentral.Controls.Add(this.TxtFEsc);
            this.PanCentral.Controls.Add(this.TxtTipEsc);
            this.PanCentral.Controls.Add(this.TxtGarDet);
            this.PanCentral.Controls.Add(this.TxtCli);
            this.PanCentral.Controls.Add(this.TxtCre);
            this.PanCentral.Controls.Add(this.label8);
            this.PanCentral.Controls.Add(this.label7);
            this.PanCentral.Controls.Add(this.label6);
            this.PanCentral.Controls.Add(this.label5);
            this.PanCentral.Controls.Add(this.label4);
            this.PanCentral.Controls.Add(this.label3);
            this.PanCentral.Controls.Add(this.label2);
            this.PanCentral.Controls.Add(this.label1);
            this.PanCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCentral.Location = new System.Drawing.Point(0, 0);
            this.PanCentral.Margin = new System.Windows.Forms.Padding(4);
            this.PanCentral.Name = "PanCentral";
            this.PanCentral.Size = new System.Drawing.Size(886, 333);
            this.PanCentral.TabIndex = 0;
            // 
            // TxtEstado
            // 
            this.TxtEstado.Enabled = false;
            this.TxtEstado.Location = new System.Drawing.Point(697, 223);
            this.TxtEstado.Name = "TxtEstado";
            this.TxtEstado.Size = new System.Drawing.Size(143, 25);
            this.TxtEstado.TabIndex = 29;
            // 
            // CboEstado
            // 
            this.CboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboEstado.FormattingEnabled = true;
            this.CboEstado.Items.AddRange(new object[] {
            "En Posesión",
            "Entregado"});
            this.CboEstado.Location = new System.Drawing.Point(536, 221);
            this.CboEstado.Name = "CboEstado";
            this.CboEstado.Size = new System.Drawing.Size(142, 25);
            this.CboEstado.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(445, 226);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 17);
            this.label10.TabIndex = 27;
            this.label10.Text = "Estado";
            // 
            // ChkChanFecha
            // 
            this.ChkChanFecha.AutoSize = true;
            this.ChkChanFecha.Location = new System.Drawing.Point(149, 298);
            this.ChkChanFecha.Name = "ChkChanFecha";
            this.ChkChanFecha.Size = new System.Drawing.Size(115, 21);
            this.ChkChanFecha.TabIndex = 26;
            this.ChkChanFecha.Text = "Cambiar fecha";
            this.ChkChanFecha.UseVisualStyleBackColor = true;
            // 
            // CboTipGar
            // 
            this.CboTipGar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipGar.Enabled = false;
            this.CboTipGar.FormattingEnabled = true;
            this.CboTipGar.Items.AddRange(new object[] {
            "Prendaria",
            "Hipotecária",
            "Vehiculos",
            "Fiduciaria",
            "Compromiso de deuda",
            "Ninguna"});
            this.CboTipGar.Location = new System.Drawing.Point(149, 117);
            this.CboTipGar.Name = "CboTipGar";
            this.CboTipGar.Size = new System.Drawing.Size(277, 25);
            this.CboTipGar.TabIndex = 25;
            this.CboTipGar.SelectedIndexChanged += new System.EventHandler(this.CboTipGar_SelectedIndexChanged);
            // 
            // BtnDesbloq
            // 
            this.BtnDesbloq.Location = new System.Drawing.Point(594, 274);
            this.BtnDesbloq.Name = "BtnDesbloq";
            this.BtnDesbloq.Size = new System.Drawing.Size(115, 45);
            this.BtnDesbloq.TabIndex = 24;
            this.BtnDesbloq.Text = "Desbloquear";
            this.BtnDesbloq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDesbloq.UseVisualStyleBackColor = true;
            this.BtnDesbloq.Click += new System.EventHandler(this.BtnDesbloq_Click);
            // 
            // DtpFecha
            // 
            this.DtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpFecha.Location = new System.Drawing.Point(318, 265);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(108, 25);
            this.DtpFecha.TabIndex = 23;
            this.DtpFecha.Visible = false;
            this.DtpFecha.ValueChanged += new System.EventHandler(this.DtpFecha_ValueChanged);
            // 
            // TxtAut
            // 
            this.TxtAut.Enabled = false;
            this.TxtAut.Location = new System.Drawing.Point(536, 75);
            this.TxtAut.Name = "TxtAut";
            this.TxtAut.Size = new System.Drawing.Size(304, 25);
            this.TxtAut.TabIndex = 22;
            this.TxtAut.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(445, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Autorizo";
            this.label9.Visible = false;
            // 
            // LblGarant
            // 
            this.LblGarant.AutoSize = true;
            this.LblGarant.Location = new System.Drawing.Point(475, 159);
            this.LblGarant.Name = "LblGarant";
            this.LblGarant.Size = new System.Drawing.Size(15, 17);
            this.LblGarant.TabIndex = 20;
            this.LblGarant.Text = "0";
            this.LblGarant.Visible = false;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("BtnGuardar.Image")));
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnGuardar.Location = new System.Drawing.Point(473, 274);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(115, 45);
            this.BtnGuardar.TabIndex = 18;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Visible = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // TxtUbi
            // 
            this.TxtUbi.Enabled = false;
            this.TxtUbi.Location = new System.Drawing.Point(536, 122);
            this.TxtUbi.Multiline = true;
            this.TxtUbi.Name = "TxtUbi";
            this.TxtUbi.Size = new System.Drawing.Size(304, 70);
            this.TxtUbi.TabIndex = 17;
            this.TxtUbi.Visible = false;
            // 
            // TxtValu
            // 
            this.TxtValu.Enabled = false;
            this.TxtValu.Location = new System.Drawing.Point(536, 29);
            this.TxtValu.Name = "TxtValu";
            this.TxtValu.Size = new System.Drawing.Size(304, 25);
            this.TxtValu.TabIndex = 16;
            this.TxtValu.Text = "0";
            // 
            // TxtFEsc
            // 
            this.TxtFEsc.Enabled = false;
            this.TxtFEsc.Location = new System.Drawing.Point(149, 265);
            this.TxtFEsc.Name = "TxtFEsc";
            this.TxtFEsc.Size = new System.Drawing.Size(109, 25);
            this.TxtFEsc.TabIndex = 15;
            this.TxtFEsc.Visible = false;
            // 
            // TxtTipEsc
            // 
            this.TxtTipEsc.Enabled = false;
            this.TxtTipEsc.Location = new System.Drawing.Point(149, 226);
            this.TxtTipEsc.Name = "TxtTipEsc";
            this.TxtTipEsc.Size = new System.Drawing.Size(277, 25);
            this.TxtTipEsc.TabIndex = 14;
            this.TxtTipEsc.Visible = false;
            // 
            // TxtGarDet
            // 
            this.TxtGarDet.Enabled = false;
            this.TxtGarDet.Location = new System.Drawing.Point(149, 159);
            this.TxtGarDet.Multiline = true;
            this.TxtGarDet.Name = "TxtGarDet";
            this.TxtGarDet.Size = new System.Drawing.Size(277, 53);
            this.TxtGarDet.TabIndex = 13;
            // 
            // TxtCli
            // 
            this.TxtCli.Enabled = false;
            this.TxtCli.Location = new System.Drawing.Point(149, 72);
            this.TxtCli.Name = "TxtCli";
            this.TxtCli.Size = new System.Drawing.Size(277, 25);
            this.TxtCli.TabIndex = 11;
            // 
            // TxtCre
            // 
            this.TxtCre.Enabled = false;
            this.TxtCre.Location = new System.Drawing.Point(149, 29);
            this.TxtCre.Name = "TxtCre";
            this.TxtCre.Size = new System.Drawing.Size(87, 25);
            this.TxtCre.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(445, 125);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 17);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ubicación";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fecha Escritura";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo de Escritura";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Detalle";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valuación";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de garantia";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Credito";
            // 
            // CmdContra
            // 
            this.CmdContra.Image = ((System.Drawing.Image)(resources.GetObject("CmdContra.Image")));
            this.CmdContra.Location = new System.Drawing.Point(725, 274);
            this.CmdContra.Name = "CmdContra";
            this.CmdContra.Size = new System.Drawing.Size(115, 45);
            this.CmdContra.TabIndex = 30;
            this.CmdContra.Text = "Contrato";
            this.CmdContra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CmdContra.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CmdContra.UseVisualStyleBackColor = true;
            this.CmdContra.Click += new System.EventHandler(this.CmdContra_Click);
            // 
            // GarantVer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 333);
            this.Controls.Add(this.PanCentral);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "GarantVer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ver garantía";
            this.Load += new System.EventHandler(this.GarantVer_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GarantVer_KeyDown);
            this.PanCentral.ResumeLayout(false);
            this.PanCentral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanCentral;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtUbi;
        private System.Windows.Forms.TextBox TxtValu;
        private System.Windows.Forms.TextBox TxtFEsc;
        private System.Windows.Forms.TextBox TxtTipEsc;
        private System.Windows.Forms.TextBox TxtGarDet;
        private System.Windows.Forms.TextBox TxtCli;
        private System.Windows.Forms.TextBox TxtCre;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label LblGarant;
        private System.Windows.Forms.TextBox TxtAut;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Button BtnDesbloq;
        private System.Windows.Forms.ComboBox CboTipGar;
        private System.Windows.Forms.CheckBox ChkChanFecha;
        private System.Windows.Forms.ComboBox CboEstado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtEstado;
        private System.Windows.Forms.Button CmdContra;
    }
}