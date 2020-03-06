namespace Arcoiris.Formularios
{
    partial class Prestamo
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Tab1 = new System.Windows.Forms.TabPage();
            this.Tab2 = new System.Windows.Forms.TabPage();
            this.GBXPrestamo = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.Tab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Tab1);
            this.tabControl1.Controls.Add(this.Tab2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(767, 445);
            this.tabControl1.TabIndex = 0;
            // 
            // Tab1
            // 
            this.Tab1.Controls.Add(this.GBXPrestamo);
            this.Tab1.Location = new System.Drawing.Point(4, 26);
            this.Tab1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tab1.Name = "Tab1";
            this.Tab1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tab1.Size = new System.Drawing.Size(759, 415);
            this.Tab1.TabIndex = 0;
            this.Tab1.Text = "Estado de solicitudes";
            this.Tab1.UseVisualStyleBackColor = true;
            // 
            // Tab2
            // 
            this.Tab2.Location = new System.Drawing.Point(4, 26);
            this.Tab2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tab2.Name = "Tab2";
            this.Tab2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tab2.Size = new System.Drawing.Size(759, 415);
            this.Tab2.TabIndex = 1;
            this.Tab2.Text = "Estado de prestamos";
            this.Tab2.UseVisualStyleBackColor = true;
            // 
            // GBXPrestamo
            // 
            this.GBXPrestamo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GBXPrestamo.Location = new System.Drawing.Point(4, 4);
            this.GBXPrestamo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GBXPrestamo.Name = "GBXPrestamo";
            this.GBXPrestamo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GBXPrestamo.Size = new System.Drawing.Size(751, 407);
            this.GBXPrestamo.TabIndex = 1;
            this.GBXPrestamo.TabStop = false;
            this.GBXPrestamo.Text = "Prestamo";
            // 
            // Prestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(767, 445);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Prestamo";
            this.Text = "Prestamo";
            this.Load += new System.EventHandler(this.Prestamo_Load);
            this.tabControl1.ResumeLayout(false);
            this.Tab1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Tab1;
        private System.Windows.Forms.GroupBox GBXPrestamo;
        private System.Windows.Forms.TabPage Tab2;
    }
}