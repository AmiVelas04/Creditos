namespace Arcoiris.Formularios
{
    partial class Usuario
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
            this.GbxUsuario = new System.Windows.Forms.GroupBox();
            this.BtnNuevo = new System.Windows.Forms.Button();
            this.TxtPass2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LblId = new System.Windows.Forms.Label();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnAgegar = new System.Windows.Forms.Button();
            this.CboNivel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtPass1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtUsu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtNom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CboUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GbxUsuario.SuspendLayout();
            this.SuspendLayout();
            // 
            // GbxUsuario
            // 
            this.GbxUsuario.Controls.Add(this.BtnNuevo);
            this.GbxUsuario.Controls.Add(this.TxtPass2);
            this.GbxUsuario.Controls.Add(this.label6);
            this.GbxUsuario.Controls.Add(this.LblId);
            this.GbxUsuario.Controls.Add(this.BtnEditar);
            this.GbxUsuario.Controls.Add(this.BtnAgegar);
            this.GbxUsuario.Controls.Add(this.CboNivel);
            this.GbxUsuario.Controls.Add(this.label5);
            this.GbxUsuario.Controls.Add(this.TxtPass1);
            this.GbxUsuario.Controls.Add(this.label4);
            this.GbxUsuario.Controls.Add(this.TxtUsu);
            this.GbxUsuario.Controls.Add(this.label3);
            this.GbxUsuario.Controls.Add(this.TxtNom);
            this.GbxUsuario.Controls.Add(this.label2);
            this.GbxUsuario.Controls.Add(this.CboUser);
            this.GbxUsuario.Controls.Add(this.label1);
            this.GbxUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxUsuario.Location = new System.Drawing.Point(0, 0);
            this.GbxUsuario.Name = "GbxUsuario";
            this.GbxUsuario.Size = new System.Drawing.Size(764, 549);
            this.GbxUsuario.TabIndex = 0;
            this.GbxUsuario.TabStop = false;
            this.GbxUsuario.Text = "Usuario";
            // 
            // BtnNuevo
            // 
            this.BtnNuevo.Location = new System.Drawing.Point(174, 121);
            this.BtnNuevo.Name = "BtnNuevo";
            this.BtnNuevo.Size = new System.Drawing.Size(124, 49);
            this.BtnNuevo.TabIndex = 15;
            this.BtnNuevo.Text = "Limpiar";
            this.BtnNuevo.UseVisualStyleBackColor = true;
            this.BtnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
            // 
            // TxtPass2
            // 
            this.TxtPass2.Location = new System.Drawing.Point(466, 266);
            this.TxtPass2.Name = "TxtPass2";
            this.TxtPass2.PasswordChar = '*';
            this.TxtPass2.Size = new System.Drawing.Size(268, 25);
            this.TxtPass2.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(473, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Repetir contraseña";
            // 
            // LblId
            // 
            this.LblId.AutoSize = true;
            this.LblId.Location = new System.Drawing.Point(609, 475);
            this.LblId.Name = "LblId";
            this.LblId.Size = new System.Drawing.Size(15, 17);
            this.LblId.TabIndex = 12;
            this.LblId.Text = "0";
            this.LblId.Visible = false;
            // 
            // BtnEditar
            // 
            this.BtnEditar.Location = new System.Drawing.Point(44, 121);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(124, 49);
            this.BtnEditar.TabIndex = 11;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnAgegar
            // 
            this.BtnAgegar.Location = new System.Drawing.Point(466, 396);
            this.BtnAgegar.Name = "BtnAgegar";
            this.BtnAgegar.Size = new System.Drawing.Size(124, 49);
            this.BtnAgegar.TabIndex = 10;
            this.BtnAgegar.Text = "Guardar";
            this.BtnAgegar.UseVisualStyleBackColor = true;
            this.BtnAgegar.Click += new System.EventHandler(this.BtnAgegar_Click);
            // 
            // CboNivel
            // 
            this.CboNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboNivel.FormattingEnabled = true;
            this.CboNivel.Location = new System.Drawing.Point(466, 328);
            this.CboNivel.Name = "CboNivel";
            this.CboNivel.Size = new System.Drawing.Size(167, 25);
            this.CboNivel.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nivel";
            // 
            // TxtPass1
            // 
            this.TxtPass1.Location = new System.Drawing.Point(466, 198);
            this.TxtPass1.Name = "TxtPass1";
            this.TxtPass1.PasswordChar = '*';
            this.TxtPass1.Size = new System.Drawing.Size(268, 25);
            this.TxtPass1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(473, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contraseña";
            // 
            // TxtUsu
            // 
            this.TxtUsu.Location = new System.Drawing.Point(466, 134);
            this.TxtUsu.Name = "TxtUsu";
            this.TxtUsu.Size = new System.Drawing.Size(268, 25);
            this.TxtUsu.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(473, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Usuario";
            // 
            // TxtNom
            // 
            this.TxtNom.Location = new System.Drawing.Point(466, 66);
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(268, 25);
            this.TxtNom.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // CboUser
            // 
            this.CboUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboUser.FormattingEnabled = true;
            this.CboUser.Location = new System.Drawing.Point(35, 66);
            this.CboUser.Name = "CboUser";
            this.CboUser.Size = new System.Drawing.Size(261, 25);
            this.CboUser.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccionar usuario";
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(764, 549);
            this.Controls.Add(this.GbxUsuario);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Usuario";
            this.Text = "Usuario";
            this.Load += new System.EventHandler(this.Usuario_Load);
            this.GbxUsuario.ResumeLayout(false);
            this.GbxUsuario.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GbxUsuario;
        private System.Windows.Forms.ComboBox CboUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnAgegar;
        private System.Windows.Forms.ComboBox CboNivel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtPass1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtUsu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtNom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblId;
        private System.Windows.Forms.TextBox TxtPass2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnNuevo;
    }
}