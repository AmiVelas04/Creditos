using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcoiris.Formularios
{
    public partial class Autopass : Form
    {
        Clases.Logueo log = new Clases.Logueo();
        public delegate void permiso(int cod);
        public event permiso verificar;
        public Autopass()
        {
            InitializeComponent();
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            verificar(log.nivel(TxtPass.Text));
            this.Close();
        }
    }
}
