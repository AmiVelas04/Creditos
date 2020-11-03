namespace Arcoiris.Formularios
{
    partial class Asesor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Asesor));
            this.GBXAsesor = new System.Windows.Forms.GroupBox();
            this.panelInf = new System.Windows.Forms.Panel();
            this.DGVAsesor = new System.Windows.Forms.DataGridView();
            this.panelSup = new System.Windows.Forms.Panel();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.TxtDir = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtTel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtNom = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.GBXAsesor.SuspendLayout();
            this.panelInf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAsesor)).BeginInit();
            this.panelSup.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBXAsesor
            // 
            this.GBXAsesor.Controls.Add(this.panelInf);
            this.GBXAsesor.Controls.Add(this.panelSup);
            this.GBXAsesor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GBXAsesor.Location = new System.Drawing.Point(0, 0);
            this.GBXAsesor.Margin = new System.Windows.Forms.Padding(4);
            this.GBXAsesor.Name = "GBXAsesor";
            this.GBXAsesor.Padding = new System.Windows.Forms.Padding(4);
            this.GBXAsesor.Size = new System.Drawing.Size(737, 549);
            this.GBXAsesor.TabIndex = 0;
            this.GBXAsesor.TabStop = false;
            this.GBXAsesor.Text = "Datos del Asesor";
            // 
            // panelInf
            // 
            this.panelInf.Controls.Add(this.DGVAsesor);
            this.panelInf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInf.Location = new System.Drawing.Point(4, 175);
            this.panelInf.Margin = new System.Windows.Forms.Padding(4);
            this.panelInf.Name = "panelInf";
            this.panelInf.Size = new System.Drawing.Size(729, 370);
            this.panelInf.TabIndex = 1;
            // 
            // DGVAsesor
            // 
            this.DGVAsesor.AllowUserToAddRows = false;
            this.DGVAsesor.AllowUserToDeleteRows = false;
            this.DGVAsesor.AllowUserToResizeColumns = false;
            this.DGVAsesor.AllowUserToResizeRows = false;
            this.DGVAsesor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAsesor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVAsesor.Location = new System.Drawing.Point(0, 0);
            this.DGVAsesor.Margin = new System.Windows.Forms.Padding(4);
            this.DGVAsesor.Name = "DGVAsesor";
            this.DGVAsesor.ReadOnly = true;
            this.DGVAsesor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVAsesor.Size = new System.Drawing.Size(729, 370);
            this.DGVAsesor.TabIndex = 0;
            // 
            // panelSup
            // 
            this.panelSup.Controls.Add(this.BtnBuscar);
            this.panelSup.Controls.Add(this.TxtDir);
            this.panelSup.Controls.Add(this.label3);
            this.panelSup.Controls.Add(this.TxtTel);
            this.panelSup.Controls.Add(this.label2);
            this.panelSup.Controls.Add(this.TxtNom);
            this.panelSup.Controls.Add(this.label1);
            this.panelSup.Controls.Add(this.flowLayoutPanel1);
            this.panelSup.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSup.Location = new System.Drawing.Point(4, 22);
            this.panelSup.Margin = new System.Windows.Forms.Padding(4);
            this.panelSup.Name = "panelSup";
            this.panelSup.Size = new System.Drawing.Size(729, 153);
            this.panelSup.TabIndex = 0;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.FlatAppearance.BorderSize = 0;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.Location = new System.Drawing.Point(422, 17);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(64, 34);
            this.BtnBuscar.TabIndex = 7;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // TxtDir
            // 
            this.TxtDir.Location = new System.Drawing.Point(107, 97);
            this.TxtDir.Margin = new System.Windows.Forms.Padding(4);
            this.TxtDir.Name = "TxtDir";
            this.TxtDir.Size = new System.Drawing.Size(175, 25);
            this.TxtDir.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 100);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Direccion";
            // 
            // TxtTel
            // 
            this.TxtTel.Location = new System.Drawing.Point(107, 55);
            this.TxtTel.Margin = new System.Windows.Forms.Padding(4);
            this.TxtTel.MaxLength = 8;
            this.TxtTel.Name = "TxtTel";
            this.TxtTel.Size = new System.Drawing.Size(175, 25);
            this.TxtTel.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Telefono";
            // 
            // TxtNom
            // 
            this.TxtNom.Location = new System.Drawing.Point(107, 22);
            this.TxtNom.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(307, 25);
            this.TxtNom.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BtnGuardar);
            this.flowLayoutPanel1.Controls.Add(this.BtnEditar);
            this.flowLayoutPanel1.Controls.Add(this.BtnEliminar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(557, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(172, 153);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Location = new System.Drawing.Point(4, 4);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(156, 43);
            this.BtnGuardar.TabIndex = 0;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditar.Location = new System.Drawing.Point(4, 55);
            this.BtnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(156, 37);
            this.BtnEditar.TabIndex = 1;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            this.BtnEditar.Visible = false;
            this.BtnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Location = new System.Drawing.Point(4, 100);
            this.BtnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(156, 46);
            this.BtnEliminar.TabIndex = 2;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Visible = false;
            // 
            // Asesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(737, 549);
            this.Controls.Add(this.GBXAsesor);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Asesor";
            this.Text = "Asesor";
            this.GBXAsesor.ResumeLayout(false);
            this.panelInf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAsesor)).EndInit();
            this.panelSup.ResumeLayout(false);
            this.panelSup.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GBXAsesor;
        private System.Windows.Forms.Panel panelInf;
        private System.Windows.Forms.DataGridView DGVAsesor;
        private System.Windows.Forms.Panel panelSup;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button BtnEditar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.TextBox TxtDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtTel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtNom;
        private System.Windows.Forms.Label label1;
    }
}