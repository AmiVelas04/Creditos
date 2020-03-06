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
    public partial class Cliente : Form
    {
        Clases.Cliente clien = new Clases.Cliente();
        public Cliente()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void GbxCliente_Enter(object sender, EventArgs e)
        {
            CboScivil.Items.Add("Soltero");
            CboScivil.Items.Add("Casado");
            CboScivil.Items.Add("Viudo");
            CboScivil.Sorted = true;
            CboScivil.SelectedIndex = 0;



        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }
        private void guardar()
        {
            string nom = GBXCliente.Text;
            string ape = TxtApe .Text;
            string dir = TxtDir .Text;
            string dpi = TxtDpi.Text;
            string tel = TxtTel .Text;
            string prof = TxtProf.Text;
            string Est_civil = CboScivil .Text ;
            string Nom_cony = TxtNomcony.Text ;
            string Ape_cony = TxtApecony.Text;
            string refe = TxtRef.Text;
            string fecha = DateTime.Today.ToString();
            string[] datos = {nom,ape,dir,dpi,tel,prof,Est_civil,Nom_cony,Ape_cony,refe,fecha};
            if (clien.agregar_cliente(datos))
            {
                MessageBox.Show("Datos del cleinte guradaos");
                limpiar();
            }
            else
            {
                MessageBox.Show("Existe un error en el guardado");
                limpiar();
            }
        }


        private void buscar_cli()
        {
            DGVCliente.DataSource = clien.buscar_cli(GBXCliente .Text );
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            buscar_cli();
        }
        private void limpiar()
        {
            TxtNom.Clear();
            TxtApe.Clear();
            TxtApecony.Clear();
            TxtDir.Clear();
            TxtNomBus.Clear();
            TxtNomcony.Clear();
            TxtProf.Clear();
            TxtRef.Clear();
            TxtTel.Clear();
            CboScivil.SelectedIndex = 0;

        }
    }
}
