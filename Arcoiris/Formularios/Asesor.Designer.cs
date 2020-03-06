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
            this.panelSup = new System.Windows.Forms.Panel();
            this.panelInf = new System.Windows.Forms.Panel();
            this.DGVAsesor = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.BtnEditar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtNom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDir = new System.Windows.Forms.TextBox();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.GBXAsesor.SuspendLayout();
            this.panelSup.SuspendLayout();
            this.panelInf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVAsesor)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GBXAsesor
            // 
            this.GBXAsesor.Controls.Add(this.panelInf);
            this.GBXAsesor.Controls.Add(this.panelSup);
            this.GBXAsesor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GBXAsesor.Location = new System.Drawing.Point(0, 0);
            this.GBXAsesor.Name = "GBXAsesor";
            this.GBXAsesor.Size = new System.Drawing.Size(766, 400);
            this.GBXAsesor.TabIndex = 0;
            this.GBXAsesor.TabStop = false;
            this.GBXAsesor.Text = "Datos del Asesor";
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
            this.panelSup.Location = new System.Drawing.Point(3, 16);
            this.panelSup.Name = "panelSup";
            this.panelSup.Size = new System.Drawing.Size(760, 117);
            this.panelSup.TabIndex = 0;
            // 
            // panelInf
            // 
            this.panelInf.Controls.Add(this.DGVAsesor);
            this.panelInf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelInf.Location = new System.Drawing.Point(3, 133);
            this.panelInf.Name = "panelInf";
            this.panelInf.Size = new System.Drawing.Size(760, 264);
            this.panelInf.TabIndex = 1;
            // 
            // DGVAsesor
            // 
            this.DGVAsesor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVAsesor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVAsesor.Location = new System.Drawing.Point(0, 0);
            this.DGVAsesor.Name = "DGVAsesor";
            this.DGVAsesor.Size = new System.Drawing.Size(760, 264);
            this.DGVAsesor.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.BtnGuardar);
            this.flowLayoutPanel1.Controls.Add(this.BtnEditar);
            this.flowLayoutPanel1.Controls.Add(this.BtnEliminar);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(631, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(129, 117);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Location = new System.Drawing.Point(3, 3);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(117, 33);
            this.BtnGuardar.TabIndex = 0;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // BtnEditar
            // 
            this.BtnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEditar.Location = new System.Drawing.Point(3, 42);
            this.BtnEditar.Name = "BtnEditar";
            this.BtnEditar.Size = new System.Drawing.Size(117, 28);
            this.BtnEditar.TabIndex = 1;
            this.BtnEditar.Text = "Editar";
            this.BtnEditar.UseVisualStyleBackColor = true;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Location = new System.Drawing.Point(3, 76);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(117, 35);
            this.BtnEliminar.TabIndex = 2;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // TxtNom
            // 
            this.TxtNom.Location = new System.Drawing.Point(80, 17);
            this.TxtNom.Name = "TxtNom";
            this.TxtNom.Size = new System.Drawing.Size(182, 20);
            this.TxtNom.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Telefono";
            // 
            // TxtTel
            // 
            this.TxtTel.Location = new System.Drawing.Point(80, 76);
            this.TxtTel.MaxLength = 8;
            this.TxtTel.Name = "TxtTel";
            this.TxtTel.Size = new System.Drawing.Size(127, 20);
            this.TxtTel.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Direccion";
            // 
            // TxtDir
            // 
            this.TxtDir.Location = new System.Drawing.Point(409, 13);
            this.TxtDir.Name = "TxtDir";
            this.TxtDir.Size = new System.Drawing.Size(176, 20);
            this.TxtDir.TabIndex = 6;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.FlatAppearance.BorderSize = 0;
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.Location = new System.Drawing.Point(268, 17);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(75, 26);
            this.BtnBuscar.TabIndex = 7;
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // Asesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(766, 400);
            this.Controls.Add(this.GBXAsesor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Asesor";
            this.Text = "Asesor";
            this.GBXAsesor.ResumeLayout(false);
            this.panelSup.ResumeLayout(false);
            this.panelSup.PerformLayout();
            this.panelInf.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVAsesor)).EndInit();
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