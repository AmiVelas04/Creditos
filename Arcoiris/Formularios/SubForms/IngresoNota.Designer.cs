namespace Arcoiris.Formularios.SubForms
{
    partial class IngresoNota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresoNota));
            this.PanCent = new System.Windows.Forms.Panel();
            this.BtnList = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TxtNota = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtCred = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PanCent.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanCent
            // 
            this.PanCent.Controls.Add(this.BtnList);
            this.PanCent.Controls.Add(this.BtnSave);
            this.PanCent.Controls.Add(this.TxtNota);
            this.PanCent.Controls.Add(this.label2);
            this.PanCent.Controls.Add(this.TxtCred);
            this.PanCent.Controls.Add(this.label1);
            this.PanCent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCent.Location = new System.Drawing.Point(0, 0);
            this.PanCent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PanCent.Name = "PanCent";
            this.PanCent.Size = new System.Drawing.Size(268, 424);
            this.PanCent.TabIndex = 0;
            // 
            // BtnList
            // 
            this.BtnList.Image = ((System.Drawing.Image)(resources.GetObject("BtnList.Image")));
            this.BtnList.Location = new System.Drawing.Point(55, 373);
            this.BtnList.Name = "BtnList";
            this.BtnList.Size = new System.Drawing.Size(144, 45);
            this.BtnList.TabIndex = 5;
            this.BtnList.Text = "Ver Bitacora";
            this.BtnList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnList.UseVisualStyleBackColor = true;
            this.BtnList.Click += new System.EventHandler(this.BtnList_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.Image")));
            this.BtnSave.Location = new System.Drawing.Point(55, 322);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(144, 45);
            this.BtnSave.TabIndex = 4;
            this.BtnSave.Text = "Guardar nota";
            this.BtnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtNota
            // 
            this.TxtNota.Location = new System.Drawing.Point(12, 113);
            this.TxtNota.Multiline = true;
            this.TxtNota.Name = "TxtNota";
            this.TxtNota.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtNota.Size = new System.Drawing.Size(244, 203);
            this.TxtNota.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nota";
            // 
            // TxtCred
            // 
            this.TxtCred.Enabled = false;
            this.TxtCred.Location = new System.Drawing.Point(55, 33);
            this.TxtCred.Name = "TxtCred";
            this.TxtCred.Size = new System.Drawing.Size(133, 29);
            this.TxtCred.TabIndex = 1;
            this.TxtCred.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Credito";
            // 
            // IngresoNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 424);
            this.Controls.Add(this.PanCent);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "IngresoNota";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar nota de seguimiento";
            this.Load += new System.EventHandler(this.IngresoNota_Load);
            this.PanCent.ResumeLayout(false);
            this.PanCent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanCent;
        private System.Windows.Forms.TextBox TxtCred;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnList;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TxtNota;
        private System.Windows.Forms.Label label2;
    }
}