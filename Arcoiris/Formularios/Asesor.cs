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
    public partial class Asesor : Form
    {
        Clases.ClAsesor ase =new  Clases.ClAsesor();
        public Asesor()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        private void Guardar() {
            string[] datos = {TxtNom.Text ,TxtTel .Text ,TxtDir.Text};
            if (ase.ingresar_asesor(datos))
            {
                MessageBox.Show("ASesor ingresado con exito");
                limpiar();
            }
            else
            {
                MessageBox.Show("Error al ingredas asesor");
                limpiar();

            }
                    }

        private void limpiar()
        {
            TxtDir.Clear();
            TxtNom.Clear();
            TxtTel.Clear();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            DGVAsesor .DataSource = ase.busca_asesor(TxtNom.Text);

        }
    }
}
