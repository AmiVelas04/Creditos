using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcoiris.Formularios.SubForms
{
    public partial class Dpi : Form
    {
        public Bitmap dpi { get; set; }
        public Dpi()
        {
            InitializeComponent();
        }

        private void PcbDpi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Dpi_Load(object sender, EventArgs e)
        {
         
                PcbDpi.Image = dpi;
                 }
    }
}
