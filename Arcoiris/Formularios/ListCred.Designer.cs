namespace Arcoiris.Formularios
{
    partial class ListCred
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListCred));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnCerrar = new System.Windows.Forms.Button();
            this.DgvCre = new System.Windows.Forms.DataGridView();
            this.BtnRef = new System.Windows.Forms.Button();
            this.LblNom = new System.Windows.Forms.Label();
            this.LblCant = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCre)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnCerrar
            // 
            this.BtnCerrar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BtnCerrar.FlatAppearance.BorderSize = 0;
            this.BtnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("BtnCerrar.Image")));
            this.BtnCerrar.Location = new System.Drawing.Point(621, 2);
            this.BtnCerrar.Name = "BtnCerrar";
            this.BtnCerrar.Size = new System.Drawing.Size(41, 38);
            this.BtnCerrar.TabIndex = 0;
            this.BtnCerrar.UseVisualStyleBackColor = false;
            this.BtnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
            // 
            // DgvCre
            // 
            this.DgvCre.AllowUserToAddRows = false;
            this.DgvCre.AllowUserToDeleteRows = false;
            this.DgvCre.AllowUserToResizeColumns = false;
            this.DgvCre.AllowUserToResizeRows = false;
            this.DgvCre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvCre.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.DgvCre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DgvCre.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.DgvCre.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.DgvCre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvCre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DgvCre.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.DgvCre.Location = new System.Drawing.Point(0, 113);
            this.DgvCre.MultiSelect = false;
            this.DgvCre.Name = "DgvCre";
            this.DgvCre.ReadOnly = true;
            this.DgvCre.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.DgvCre.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvCre.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCre.Size = new System.Drawing.Size(662, 272);
            this.DgvCre.TabIndex = 1;
            // 
            // BtnRef
            // 
            this.BtnRef.BackColor = System.Drawing.Color.DimGray;
            this.BtnRef.FlatAppearance.BorderSize = 0;
            this.BtnRef.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRef.ForeColor = System.Drawing.Color.White;
            this.BtnRef.Location = new System.Drawing.Point(21, 27);
            this.BtnRef.Name = "BtnRef";
            this.BtnRef.Size = new System.Drawing.Size(131, 43);
            this.BtnRef.TabIndex = 2;
            this.BtnRef.Text = "Refinanciar";
            this.BtnRef.UseVisualStyleBackColor = false;
            this.BtnRef.Click += new System.EventHandler(this.BtnRef_Click);
            // 
            // LblNom
            // 
            this.LblNom.AutoSize = true;
            this.LblNom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNom.Location = new System.Drawing.Point(186, 27);
            this.LblNom.Name = "LblNom";
            this.LblNom.Size = new System.Drawing.Size(57, 19);
            this.LblNom.TabIndex = 3;
            this.LblNom.Text = "Cliente";
            // 
            // LblCant
            // 
            this.LblCant.AutoSize = true;
            this.LblCant.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCant.Location = new System.Drawing.Point(186, 50);
            this.LblCant.Name = "LblCant";
            this.LblCant.Size = new System.Drawing.Size(66, 19);
            this.LblCant.TabIndex = 4;
            this.LblCant.Text = "Creditos";
            // 
            // ListCred
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(662, 385);
            this.Controls.Add(this.LblCant);
            this.Controls.Add(this.LblNom);
            this.Controls.Add(this.BtnRef);
            this.Controls.Add(this.DgvCre);
            this.Controls.Add(this.BtnCerrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListCred";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListCred";
            this.Load += new System.EventHandler(this.ListCred_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnCerrar;
        private System.Windows.Forms.DataGridView DgvCre;
        private System.Windows.Forms.Button BtnRef;
        private System.Windows.Forms.Label LblNom;
        private System.Windows.Forms.Label LblCant;
    }
}