namespace Arcoiris.Formularios.SubForms
{
    partial class IngresoGarantia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresoGarantia));
            this.PanCent = new System.Windows.Forms.Panel();
            this.PanInfIn = new System.Windows.Forms.Panel();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.PanSupIn = new System.Windows.Forms.Panel();
            this.GbxGaranFia = new System.Windows.Forms.GroupBox();
            this.NudValuF = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDetaGaranF = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GbxGaranDeu = new System.Windows.Forms.GroupBox();
            this.NudValuD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtDetaGaranD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanCent.SuspendLayout();
            this.PanInfIn.SuspendLayout();
            this.PanSupIn.SuspendLayout();
            this.GbxGaranFia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudValuF)).BeginInit();
            this.GbxGaranDeu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudValuD)).BeginInit();
            this.SuspendLayout();
            // 
            // PanCent
            // 
            this.PanCent.Controls.Add(this.PanInfIn);
            this.PanCent.Controls.Add(this.PanSupIn);
            this.PanCent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCent.Location = new System.Drawing.Point(0, 0);
            this.PanCent.Margin = new System.Windows.Forms.Padding(4);
            this.PanCent.Name = "PanCent";
            this.PanCent.Size = new System.Drawing.Size(496, 263);
            this.PanCent.TabIndex = 0;
            // 
            // PanInfIn
            // 
            this.PanInfIn.Controls.Add(this.BtnCancel);
            this.PanInfIn.Controls.Add(this.BtnSave);
            this.PanInfIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanInfIn.Location = new System.Drawing.Point(0, 185);
            this.PanInfIn.Name = "PanInfIn";
            this.PanInfIn.Size = new System.Drawing.Size(496, 78);
            this.PanInfIn.TabIndex = 1;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("BtnCancel.Image")));
            this.BtnCancel.Location = new System.Drawing.Point(364, 22);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(120, 47);
            this.BtnCancel.TabIndex = 1;
            this.BtnCancel.Text = "Cancelar";
            this.BtnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.Location = new System.Drawing.Point(6, 22);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(120, 47);
            this.BtnSave.TabIndex = 0;
            this.BtnSave.Text = "Guardar";
            this.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // PanSupIn
            // 
            this.PanSupIn.Controls.Add(this.GbxGaranFia);
            this.PanSupIn.Controls.Add(this.GbxGaranDeu);
            this.PanSupIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanSupIn.Location = new System.Drawing.Point(0, 0);
            this.PanSupIn.Name = "PanSupIn";
            this.PanSupIn.Size = new System.Drawing.Size(496, 185);
            this.PanSupIn.TabIndex = 0;
            // 
            // GbxGaranFia
            // 
            this.GbxGaranFia.Controls.Add(this.NudValuF);
            this.GbxGaranFia.Controls.Add(this.label3);
            this.GbxGaranFia.Controls.Add(this.TxtDetaGaranF);
            this.GbxGaranFia.Controls.Add(this.label4);
            this.GbxGaranFia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbxGaranFia.Location = new System.Drawing.Point(247, 0);
            this.GbxGaranFia.Name = "GbxGaranFia";
            this.GbxGaranFia.Size = new System.Drawing.Size(249, 185);
            this.GbxGaranFia.TabIndex = 3;
            this.GbxGaranFia.TabStop = false;
            this.GbxGaranFia.Text = "Garantia del fiador";
            // 
            // NudValuF
            // 
            this.NudValuF.Location = new System.Drawing.Point(6, 152);
            this.NudValuF.Name = "NudValuF";
            this.NudValuF.Size = new System.Drawing.Size(120, 22);
            this.NudValuF.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Valuacion";
            // 
            // TxtDetaGaranF
            // 
            this.TxtDetaGaranF.Location = new System.Drawing.Point(6, 52);
            this.TxtDetaGaranF.Multiline = true;
            this.TxtDetaGaranF.Name = "TxtDetaGaranF";
            this.TxtDetaGaranF.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDetaGaranF.Size = new System.Drawing.Size(235, 60);
            this.TxtDetaGaranF.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Detalle";
            // 
            // GbxGaranDeu
            // 
            this.GbxGaranDeu.Controls.Add(this.NudValuD);
            this.GbxGaranDeu.Controls.Add(this.label2);
            this.GbxGaranDeu.Controls.Add(this.TxtDetaGaranD);
            this.GbxGaranDeu.Controls.Add(this.label1);
            this.GbxGaranDeu.Dock = System.Windows.Forms.DockStyle.Left;
            this.GbxGaranDeu.Location = new System.Drawing.Point(0, 0);
            this.GbxGaranDeu.Name = "GbxGaranDeu";
            this.GbxGaranDeu.Size = new System.Drawing.Size(247, 185);
            this.GbxGaranDeu.TabIndex = 2;
            this.GbxGaranDeu.TabStop = false;
            this.GbxGaranDeu.Text = "Garantia del deudor";
            // 
            // NudValuD
            // 
            this.NudValuD.Location = new System.Drawing.Point(6, 152);
            this.NudValuD.Name = "NudValuD";
            this.NudValuD.Size = new System.Drawing.Size(120, 22);
            this.NudValuD.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Valuacion";
            // 
            // TxtDetaGaranD
            // 
            this.TxtDetaGaranD.Location = new System.Drawing.Point(6, 52);
            this.TxtDetaGaranD.Multiline = true;
            this.TxtDetaGaranD.Name = "TxtDetaGaranD";
            this.TxtDetaGaranD.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtDetaGaranD.Size = new System.Drawing.Size(235, 60);
            this.TxtDetaGaranD.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detalle";
            // 
            // IngresoGarantia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 263);
            this.Controls.Add(this.PanCent);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IngresoGarantia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ingreso de la garantia";
            this.Load += new System.EventHandler(this.IngresoGarantia_Load);
            this.PanCent.ResumeLayout(false);
            this.PanInfIn.ResumeLayout(false);
            this.PanSupIn.ResumeLayout(false);
            this.GbxGaranFia.ResumeLayout(false);
            this.GbxGaranFia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudValuF)).EndInit();
            this.GbxGaranDeu.ResumeLayout(false);
            this.GbxGaranDeu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudValuD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanCent;
        private System.Windows.Forms.Panel PanInfIn;
        private System.Windows.Forms.Panel PanSupIn;
        private System.Windows.Forms.GroupBox GbxGaranFia;
        private System.Windows.Forms.GroupBox GbxGaranDeu;
        private System.Windows.Forms.TextBox TxtDetaGaranD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown NudValuF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDetaGaranF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown NudValuD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
    }
}