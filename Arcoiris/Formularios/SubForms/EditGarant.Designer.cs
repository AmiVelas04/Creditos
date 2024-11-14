namespace Arcoiris.Formularios.SubForms
{
    partial class EditGarant
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
            this.PanCent = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // PanCent
            // 
            this.PanCent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanCent.Location = new System.Drawing.Point(0, 0);
            this.PanCent.Name = "PanCent";
            this.PanCent.Size = new System.Drawing.Size(800, 450);
            this.PanCent.TabIndex = 0;
            // 
            // EditGarant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PanCent);
            this.Name = "EditGarant";
            this.Text = "Garantia";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanCent;
    }
}