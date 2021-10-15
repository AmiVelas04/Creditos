namespace Arcoiris.Formularios
{
    partial class Solicitud
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Solicitud));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Tab1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.NupPlazo = new System.Windows.Forms.NumericUpDown();
            this.LblPlazo = new System.Windows.Forms.Label();
            this.TxtGaran = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CboTipo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.LblFecha = new System.Windows.Forms.Label();
            this.TxtNoSol = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.CboAsesor = new System.Windows.Forms.ComboBox();
            this.TxtConcept = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtMonto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CboCliente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Tab2 = new System.Windows.Forms.TabPage();
            this.GBXPrestamo = new System.Windows.Forms.GroupBox();
            this.CboTipo2 = new System.Windows.Forms.ComboBox();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.TxtGastos = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.LblRef = new System.Windows.Forms.Label();
            this.LblCodCli = new System.Windows.Forms.Label();
            this.DtpConc = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.TxtNomAseso = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.TxtNomSoli = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.TxtInteres = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.LblFechasol = new System.Windows.Forms.Label();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BntCambiar = new System.Windows.Forms.Button();
            this.CboEstado = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtPlazo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtGarantia = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TxtConcepto = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtMonto2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.CboSoli = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.CboTipGarant = new System.Windows.Forms.ComboBox();
            this.GbxDetGarant = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.TxtValu = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.TxtTipEsc = new System.Windows.Forms.TextBox();
            this.DtpValu = new System.Windows.Forms.DateTimePicker();
            this.TxtAuth = new System.Windows.Forms.TextBox();
            this.TxtLocation = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.Tab1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NupPlazo)).BeginInit();
            this.Tab2.SuspendLayout();
            this.GBXPrestamo.SuspendLayout();
            this.GbxDetGarant.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Tab1);
            this.tabControl1.Controls.Add(this.Tab2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(765, 549);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyDown);
            // 
            // Tab1
            // 
            this.Tab1.Controls.Add(this.groupBox1);
            this.Tab1.Location = new System.Drawing.Point(4, 26);
            this.Tab1.Margin = new System.Windows.Forms.Padding(4);
            this.Tab1.Name = "Tab1";
            this.Tab1.Padding = new System.Windows.Forms.Padding(4);
            this.Tab1.Size = new System.Drawing.Size(757, 519);
            this.Tab1.TabIndex = 0;
            this.Tab1.Text = "Ingreso de solicitud";
            this.Tab1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Khaki;
            this.groupBox1.Controls.Add(this.TxtValu);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.GbxDetGarant);
            this.groupBox1.Controls.Add(this.CboTipGarant);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.NupPlazo);
            this.groupBox1.Controls.Add(this.LblPlazo);
            this.groupBox1.Controls.Add(this.TxtGaran);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.CboTipo);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.BtnLimpiar);
            this.groupBox1.Controls.Add(this.BtnAgregar);
            this.groupBox1.Controls.Add(this.LblFecha);
            this.groupBox1.Controls.Add(this.TxtNoSol);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.CboAsesor);
            this.groupBox1.Controls.Add(this.TxtConcept);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TxtMonto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CboCliente);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(749, 511);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Solicitud de credito";
            // 
            // NupPlazo
            // 
            this.NupPlazo.Location = new System.Drawing.Point(175, 302);
            this.NupPlazo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NupPlazo.Name = "NupPlazo";
            this.NupPlazo.Size = new System.Drawing.Size(57, 25);
            this.NupPlazo.TabIndex = 21;
            this.NupPlazo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NupPlazo.Visible = false;
            // 
            // LblPlazo
            // 
            this.LblPlazo.AutoSize = true;
            this.LblPlazo.Location = new System.Drawing.Point(60, 304);
            this.LblPlazo.Name = "LblPlazo";
            this.LblPlazo.Size = new System.Drawing.Size(89, 17);
            this.LblPlazo.TabIndex = 20;
            this.LblPlazo.Text = "Plazo(Meses)";
            this.LblPlazo.Visible = false;
            // 
            // TxtGaran
            // 
            this.TxtGaran.Location = new System.Drawing.Point(517, 143);
            this.TxtGaran.Margin = new System.Windows.Forms.Padding(4);
            this.TxtGaran.MaxLength = 255;
            this.TxtGaran.Multiline = true;
            this.TxtGaran.Name = "TxtGaran";
            this.TxtGaran.Size = new System.Drawing.Size(176, 55);
            this.TxtGaran.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(423, 158);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 40);
            this.label7.TabIndex = 18;
            this.label7.Text = "Detalle de garantia";
            // 
            // CboTipo
            // 
            this.CboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipo.FormattingEnabled = true;
            this.CboTipo.Location = new System.Drawing.Point(175, 255);
            this.CboTipo.Margin = new System.Windows.Forms.Padding(4);
            this.CboTipo.Name = "CboTipo";
            this.CboTipo.Size = new System.Drawing.Size(176, 25);
            this.CboTipo.TabIndex = 17;
            this.CboTipo.SelectedIndexChanged += new System.EventHandler(this.CboPlaz_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 258);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tipo Prestamos";
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLimpiar.Location = new System.Drawing.Point(218, 435);
            this.BtnLimpiar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(133, 44);
            this.BtnLimpiar.TabIndex = 15;
            this.BtnLimpiar.Text = "Limpiar Datos";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Location = new System.Drawing.Point(31, 435);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(139, 44);
            this.BtnAgregar.TabIndex = 14;
            this.BtnAgregar.Text = "Agregar Solicitud";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // LblFecha
            // 
            this.LblFecha.AutoSize = true;
            this.LblFecha.Location = new System.Drawing.Point(98, 221);
            this.LblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblFecha.Name = "LblFecha";
            this.LblFecha.Size = new System.Drawing.Size(43, 17);
            this.LblFecha.TabIndex = 13;
            this.LblFecha.Text = "Fecha";
            this.LblFecha.Visible = false;
            // 
            // TxtNoSol
            // 
            this.TxtNoSol.Enabled = false;
            this.TxtNoSol.Location = new System.Drawing.Point(175, 47);
            this.TxtNoSol.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNoSol.Name = "TxtNoSol";
            this.TxtNoSol.Size = new System.Drawing.Size(115, 25);
            this.TxtNoSol.TabIndex = 12;
            this.TxtNoSol.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 51);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Solicitud No.";
            // 
            // CboAsesor
            // 
            this.CboAsesor.FormattingEnabled = true;
            this.CboAsesor.Location = new System.Drawing.Point(175, 119);
            this.CboAsesor.Margin = new System.Windows.Forms.Padding(4);
            this.CboAsesor.Name = "CboAsesor";
            this.CboAsesor.Size = new System.Drawing.Size(214, 25);
            this.CboAsesor.TabIndex = 10;
            // 
            // TxtConcept
            // 
            this.TxtConcept.Location = new System.Drawing.Point(519, 26);
            this.TxtConcept.Margin = new System.Windows.Forms.Padding(4);
            this.TxtConcept.MaxLength = 255;
            this.TxtConcept.Multiline = true;
            this.TxtConcept.Name = "TxtConcept";
            this.TxtConcept.Size = new System.Drawing.Size(176, 46);
            this.TxtConcept.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 37);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Concepto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 119);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Asesor";
            // 
            // TxtMonto
            // 
            this.TxtMonto.Location = new System.Drawing.Point(175, 152);
            this.TxtMonto.Margin = new System.Windows.Forms.Padding(4);
            this.TxtMonto.Name = "TxtMonto";
            this.TxtMonto.Size = new System.Drawing.Size(132, 25);
            this.TxtMonto.TabIndex = 3;
            this.TxtMonto.Text = "0";
            this.TxtMonto.TextChanged += new System.EventHandler(this.TxtMonto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 156);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monto solicitado";
            // 
            // CboCliente
            // 
            this.CboCliente.FormattingEnabled = true;
            this.CboCliente.Location = new System.Drawing.Point(175, 86);
            this.CboCliente.Margin = new System.Windows.Forms.Padding(4);
            this.CboCliente.Name = "CboCliente";
            this.CboCliente.Size = new System.Drawing.Size(214, 25);
            this.CboCliente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 90);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del cliente";
            // 
            // Tab2
            // 
            this.Tab2.BackColor = System.Drawing.Color.Khaki;
            this.Tab2.Controls.Add(this.GBXPrestamo);
            this.Tab2.Location = new System.Drawing.Point(4, 26);
            this.Tab2.Margin = new System.Windows.Forms.Padding(4);
            this.Tab2.Name = "Tab2";
            this.Tab2.Padding = new System.Windows.Forms.Padding(4);
            this.Tab2.Size = new System.Drawing.Size(757, 519);
            this.Tab2.TabIndex = 1;
            this.Tab2.Text = "Cambiar estado de solicutd";
            // 
            // GBXPrestamo
            // 
            this.GBXPrestamo.Controls.Add(this.CboTipo2);
            this.GBXPrestamo.Controls.Add(this.BtnCancelar);
            this.GBXPrestamo.Controls.Add(this.TxtGastos);
            this.GBXPrestamo.Controls.Add(this.label18);
            this.GBXPrestamo.Controls.Add(this.comboBox1);
            this.GBXPrestamo.Controls.Add(this.button1);
            this.GBXPrestamo.Controls.Add(this.LblRef);
            this.GBXPrestamo.Controls.Add(this.LblCodCli);
            this.GBXPrestamo.Controls.Add(this.DtpConc);
            this.GBXPrestamo.Controls.Add(this.label17);
            this.GBXPrestamo.Controls.Add(this.TxtNomAseso);
            this.GBXPrestamo.Controls.Add(this.label16);
            this.GBXPrestamo.Controls.Add(this.TxtNomSoli);
            this.GBXPrestamo.Controls.Add(this.label15);
            this.GBXPrestamo.Controls.Add(this.TxtInteres);
            this.GBXPrestamo.Controls.Add(this.label14);
            this.GBXPrestamo.Controls.Add(this.LblFechasol);
            this.GBXPrestamo.Controls.Add(this.BtnEditar);
            this.GBXPrestamo.Controls.Add(this.BntCambiar);
            this.GBXPrestamo.Controls.Add(this.CboEstado);
            this.GBXPrestamo.Controls.Add(this.label8);
            this.GBXPrestamo.Controls.Add(this.TxtPlazo);
            this.GBXPrestamo.Controls.Add(this.label9);
            this.GBXPrestamo.Controls.Add(this.TxtGarantia);
            this.GBXPrestamo.Controls.Add(this.label10);
            this.GBXPrestamo.Controls.Add(this.TxtConcepto);
            this.GBXPrestamo.Controls.Add(this.label11);
            this.GBXPrestamo.Controls.Add(this.TxtMonto2);
            this.GBXPrestamo.Controls.Add(this.label12);
            this.GBXPrestamo.Controls.Add(this.CboSoli);
            this.GBXPrestamo.Controls.Add(this.label13);
            this.GBXPrestamo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GBXPrestamo.Location = new System.Drawing.Point(4, 4);
            this.GBXPrestamo.Margin = new System.Windows.Forms.Padding(4);
            this.GBXPrestamo.Name = "GBXPrestamo";
            this.GBXPrestamo.Padding = new System.Windows.Forms.Padding(4);
            this.GBXPrestamo.Size = new System.Drawing.Size(749, 511);
            this.GBXPrestamo.TabIndex = 2;
            this.GBXPrestamo.TabStop = false;
            this.GBXPrestamo.Text = "Prestamo";
            // 
            // CboTipo2
            // 
            this.CboTipo2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipo2.Enabled = false;
            this.CboTipo2.FormattingEnabled = true;
            this.CboTipo2.Location = new System.Drawing.Point(184, 259);
            this.CboTipo2.Name = "CboTipo2";
            this.CboTipo2.Size = new System.Drawing.Size(152, 25);
            this.CboTipo2.TabIndex = 31;
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancelar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancelar.Image")));
            this.BtnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnCancelar.Location = new System.Drawing.Point(536, 248);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(152, 58);
            this.BtnCancelar.TabIndex = 30;
            this.BtnCancelar.Text = "Cancelar   Solicitud";
            this.BtnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // TxtGastos
            // 
            this.TxtGastos.Location = new System.Drawing.Point(184, 369);
            this.TxtGastos.Name = "TxtGastos";
            this.TxtGastos.Size = new System.Drawing.Size(100, 25);
            this.TxtGastos.TabIndex = 29;
            this.TxtGastos.Text = "0";
            this.TxtGastos.TextChanged += new System.EventHandler(this.TxtGastos_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(24, 372);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(124, 17);
            this.label18.TabIndex = 28;
            this.label18.Text = "Gastos de apertura";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(377, 422);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 25);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 29);
            this.button1.TabIndex = 26;
            this.button1.Text = "Cambiar fecha";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LblRef
            // 
            this.LblRef.AutoSize = true;
            this.LblRef.Location = new System.Drawing.Point(582, 390);
            this.LblRef.Name = "LblRef";
            this.LblRef.Size = new System.Drawing.Size(15, 17);
            this.LblRef.TabIndex = 25;
            this.LblRef.Text = "0";
            // 
            // LblCodCli
            // 
            this.LblCodCli.AutoSize = true;
            this.LblCodCli.Location = new System.Drawing.Point(287, 61);
            this.LblCodCli.Name = "LblCodCli";
            this.LblCodCli.Size = new System.Drawing.Size(0, 17);
            this.LblCodCli.TabIndex = 24;
            this.LblCodCli.Visible = false;
            // 
            // DtpConc
            // 
            this.DtpConc.Location = new System.Drawing.Point(185, 23);
            this.DtpConc.Name = "DtpConc";
            this.DtpConc.Size = new System.Drawing.Size(279, 25);
            this.DtpConc.TabIndex = 23;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(24, 262);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(102, 17);
            this.label17.TabIndex = 21;
            this.label17.Text = "Tipo de credito";
            // 
            // TxtNomAseso
            // 
            this.TxtNomAseso.Enabled = false;
            this.TxtNomAseso.Location = new System.Drawing.Point(184, 120);
            this.TxtNomAseso.Name = "TxtNomAseso";
            this.TxtNomAseso.Size = new System.Drawing.Size(280, 25);
            this.TxtNomAseso.TabIndex = 20;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 120);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 17);
            this.label16.TabIndex = 19;
            this.label16.Text = "Asesor";
            // 
            // TxtNomSoli
            // 
            this.TxtNomSoli.Enabled = false;
            this.TxtNomSoli.Location = new System.Drawing.Point(184, 85);
            this.TxtNomSoli.Name = "TxtNomSoli";
            this.TxtNomSoli.Size = new System.Drawing.Size(280, 25);
            this.TxtNomSoli.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 88);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(149, 17);
            this.label15.TabIndex = 17;
            this.label15.Text = "Nombre del solicitante";
            // 
            // TxtInteres
            // 
            this.TxtInteres.Location = new System.Drawing.Point(184, 323);
            this.TxtInteres.MaxLength = 4;
            this.TxtInteres.Name = "TxtInteres";
            this.TxtInteres.Size = new System.Drawing.Size(40, 25);
            this.TxtInteres.TabIndex = 16;
            this.TxtInteres.Text = "1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(24, 331);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 17);
            this.label14.TabIndex = 15;
            this.label14.Text = "Interes %";
            // 
            // LblFechasol
            // 
            this.LblFechasol.AutoSize = true;
            this.LblFechasol.Location = new System.Drawing.Point(133, 29);
            this.LblFechasol.Name = "LblFechasol";
            this.LblFechasol.Size = new System.Drawing.Size(43, 17);
            this.LblFechasol.TabIndex = 14;
            this.LblFechasol.Text = "Fecha";
            // 
            // BtnEditar
            // 
            this.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("BtnEditar.Image")));
            this.BtnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEditar.Location = new System.Drawing.Point(536, 109);
            this.BtnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(152, 64);
            this.BtnEditar.TabIndex = 13;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BntCambiar
            // 
            this.BntCambiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BntCambiar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BntCambiar.Image = ((System.Drawing.Image)(resources.GetObject("BntCambiar.Image")));
            this.BntCambiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BntCambiar.Location = new System.Drawing.Point(536, 181);
            this.BntCambiar.Margin = new System.Windows.Forms.Padding(4);
            this.BntCambiar.Name = "BntCambiar";
            this.BntCambiar.Size = new System.Drawing.Size(152, 60);
            this.BntCambiar.TabIndex = 12;
            this.BntCambiar.Text = "Autorizar Desembolso";
            this.BntCambiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BntCambiar.UseVisualStyleBackColor = true;
            this.BntCambiar.Click += new System.EventHandler(this.BntCambiar_Click);
            // 
            // CboEstado
            // 
            this.CboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboEstado.FormattingEnabled = true;
            this.CboEstado.Location = new System.Drawing.Point(528, 63);
            this.CboEstado.Margin = new System.Windows.Forms.Padding(4);
            this.CboEstado.Name = "CboEstado";
            this.CboEstado.Size = new System.Drawing.Size(160, 25);
            this.CboEstado.TabIndex = 11;
            this.CboEstado.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(525, 42);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 17);
            this.label8.TabIndex = 10;
            this.label8.Text = "Cambiar Estado";
            this.label8.Visible = false;
            // 
            // TxtPlazo
            // 
            this.TxtPlazo.Enabled = false;
            this.TxtPlazo.Location = new System.Drawing.Point(184, 291);
            this.TxtPlazo.Margin = new System.Windows.Forms.Padding(4);
            this.TxtPlazo.Name = "TxtPlazo";
            this.TxtPlazo.Size = new System.Drawing.Size(155, 25);
            this.TxtPlazo.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 295);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Plazo";
            // 
            // TxtGarantia
            // 
            this.TxtGarantia.Enabled = false;
            this.TxtGarantia.Location = new System.Drawing.Point(184, 222);
            this.TxtGarantia.Margin = new System.Windows.Forms.Padding(4);
            this.TxtGarantia.Name = "TxtGarantia";
            this.TxtGarantia.Size = new System.Drawing.Size(280, 25);
            this.TxtGarantia.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 226);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "Garantia";
            // 
            // TxtConcepto
            // 
            this.TxtConcepto.Enabled = false;
            this.TxtConcepto.Location = new System.Drawing.Point(184, 185);
            this.TxtConcepto.Margin = new System.Windows.Forms.Padding(4);
            this.TxtConcepto.Name = "TxtConcepto";
            this.TxtConcepto.Size = new System.Drawing.Size(280, 25);
            this.TxtConcepto.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 189);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "Concepto";
            // 
            // TxtMonto2
            // 
            this.TxtMonto2.Enabled = false;
            this.TxtMonto2.Location = new System.Drawing.Point(184, 152);
            this.TxtMonto2.Margin = new System.Windows.Forms.Padding(4);
            this.TxtMonto2.Name = "TxtMonto2";
            this.TxtMonto2.Size = new System.Drawing.Size(155, 25);
            this.TxtMonto2.TabIndex = 3;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 156);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 17);
            this.label12.TabIndex = 2;
            this.label12.Text = "Monto";
            // 
            // CboSoli
            // 
            this.CboSoli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboSoli.FormattingEnabled = true;
            this.CboSoli.Location = new System.Drawing.Point(184, 53);
            this.CboSoli.Margin = new System.Windows.Forms.Padding(4);
            this.CboSoli.Name = "CboSoli";
            this.CboSoli.Size = new System.Drawing.Size(78, 25);
            this.CboSoli.TabIndex = 1;
            this.CboSoli.SelectedIndexChanged += new System.EventHandler(this.CboSoli_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(24, 57);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(147, 17);
            this.label13.TabIndex = 0;
            this.label13.Text = "Solicitudes Pendientes";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(423, 90);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 36);
            this.label19.TabIndex = 22;
            this.label19.Text = "Tipo de garantia";
            // 
            // CboTipGarant
            // 
            this.CboTipGarant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboTipGarant.FormattingEnabled = true;
            this.CboTipGarant.Items.AddRange(new object[] {
            "Prendaria",
            "Hipotecaria",
            "Vehículo",
            "Fiduciaria"});
            this.CboTipGarant.Location = new System.Drawing.Point(517, 101);
            this.CboTipGarant.Name = "CboTipGarant";
            this.CboTipGarant.Size = new System.Drawing.Size(176, 25);
            this.CboTipGarant.TabIndex = 23;
            // 
            // GbxDetGarant
            // 
            this.GbxDetGarant.Controls.Add(this.TxtLocation);
            this.GbxDetGarant.Controls.Add(this.TxtAuth);
            this.GbxDetGarant.Controls.Add(this.DtpValu);
            this.GbxDetGarant.Controls.Add(this.TxtTipEsc);
            this.GbxDetGarant.Controls.Add(this.label24);
            this.GbxDetGarant.Controls.Add(this.label23);
            this.GbxDetGarant.Controls.Add(this.label22);
            this.GbxDetGarant.Controls.Add(this.label21);
            this.GbxDetGarant.Location = new System.Drawing.Point(407, 258);
            this.GbxDetGarant.Name = "GbxDetGarant";
            this.GbxDetGarant.Size = new System.Drawing.Size(338, 246);
            this.GbxDetGarant.TabIndex = 24;
            this.GbxDetGarant.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(423, 229);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(68, 17);
            this.label20.TabIndex = 25;
            this.label20.Text = "Valuación";
            // 
            // TxtValu
            // 
            this.TxtValu.Location = new System.Drawing.Point(517, 221);
            this.TxtValu.Name = "TxtValu";
            this.TxtValu.Size = new System.Drawing.Size(176, 25);
            this.TxtValu.TabIndex = 26;
            this.TxtValu.Text = "0";
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(18, 21);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(86, 38);
            this.label21.TabIndex = 0;
            this.label21.Text = "Tipo de escritura";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(18, 78);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(86, 35);
            this.label22.TabIndex = 1;
            this.label22.Text = "Fecha de valuación";
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(18, 129);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 21);
            this.label23.TabIndex = 2;
            this.label23.Text = "Autorizó";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(18, 191);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(68, 17);
            this.label24.TabIndex = 3;
            this.label24.Text = "Ubicacion";
            // 
            // TxtTipEsc
            // 
            this.TxtTipEsc.Location = new System.Drawing.Point(112, 24);
            this.TxtTipEsc.Name = "TxtTipEsc";
            this.TxtTipEsc.Size = new System.Drawing.Size(176, 25);
            this.TxtTipEsc.TabIndex = 4;
            // 
            // DtpValu
            // 
            this.DtpValu.Location = new System.Drawing.Point(110, 78);
            this.DtpValu.MinDate = new System.DateTime(2021, 10, 1, 0, 0, 0, 0);
            this.DtpValu.Name = "DtpValu";
            this.DtpValu.Size = new System.Drawing.Size(178, 25);
            this.DtpValu.TabIndex = 5;
            // 
            // TxtAuth
            // 
            this.TxtAuth.Location = new System.Drawing.Point(110, 126);
            this.TxtAuth.Name = "TxtAuth";
            this.TxtAuth.Size = new System.Drawing.Size(178, 25);
            this.TxtAuth.TabIndex = 6;
            // 
            // TxtLocation
            // 
            this.TxtLocation.Location = new System.Drawing.Point(110, 166);
            this.TxtLocation.Multiline = true;
            this.TxtLocation.Name = "TxtLocation";
            this.TxtLocation.Size = new System.Drawing.Size(178, 55);
            this.TxtLocation.TabIndex = 7;
            // 
            // Solicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(765, 549);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Solicitud";
            this.Text = "Solicitud";
            this.Load += new System.EventHandler(this.Solicitud_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Solicitud_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.Tab1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NupPlazo)).EndInit();
            this.Tab2.ResumeLayout(false);
            this.GBXPrestamo.ResumeLayout(false);
            this.GBXPrestamo.PerformLayout();
            this.GbxDetGarant.ResumeLayout(false);
            this.GbxDetGarant.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Tab1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblFecha;
        private System.Windows.Forms.TextBox TxtNoSol;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CboAsesor;
        private System.Windows.Forms.TextBox TxtConcept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtMonto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CboCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage Tab2;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.TextBox TxtGaran;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CboTipo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox GBXPrestamo;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BntCambiar;
        private System.Windows.Forms.ComboBox CboEstado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtPlazo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtGarantia;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtConcepto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtMonto2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox CboSoli;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label LblFechasol;
        private System.Windows.Forms.TextBox TxtInteres;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox TxtNomAseso;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox TxtNomSoli;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label LblPlazo;
        private System.Windows.Forms.NumericUpDown NupPlazo;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DateTimePicker DtpConc;
        private System.Windows.Forms.Label LblCodCli;
        private System.Windows.Forms.Label LblRef;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtGastos;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.ComboBox CboTipo2;
        private System.Windows.Forms.ComboBox CboTipGarant;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox TxtValu;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox GbxDetGarant;
        private System.Windows.Forms.TextBox TxtLocation;
        private System.Windows.Forms.TextBox TxtAuth;
        private System.Windows.Forms.DateTimePicker DtpValu;
        private System.Windows.Forms.TextBox TxtTipEsc;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
    }
}