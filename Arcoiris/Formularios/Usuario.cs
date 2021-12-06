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
    public partial class Usuario : Form
    {
        Clases.Usuario usu = new Clases.Usuario();
        Clases.ClAsesor ase = new Clases.ClAsesor();
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            CboNivel.Items.Add("Administrador");
            CboNivel.Items.Add("Receptor");
            CboNivel.Items.Add("Cobrador");
            CboNivel.SelectedIndex = 0;

            DataTable dt = new DataTable();
            dt = usu.bucarusu();
            int total = dt.Rows.Count;
         //   int cont;
            CboUser.Items.Clear();
            CboUser.DataSource = dt;
            CboUser.DisplayMember = "nombre";
            CboUser.ValueMember = "cod_usuario";
            /*for (cont = 1; cont <= total; cont++)
            {
               CboUser.Items.Add(dt.Rows [cont-1][1]);
            }*/
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt=usu.bucarusucod(CboUser .SelectedValue.ToString ());
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos que modficar");

            }
            else
            {
                LblId.Text = dt.Rows[0][0].ToString();
                TxtNom .Text = dt.Rows[0][1].ToString();
                TxtUsu .Text= dt.Rows[0][2].ToString();
                if (dt.Rows[0][4].ToString()=="2")  CboNivel.SelectedIndex = 0;
                if (dt.Rows[0][4].ToString() == "3") CboNivel.SelectedIndex = 1;
                if (dt.Rows[0][4].ToString() == "4") CboNivel.SelectedIndex = 2;


            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            TxtNom.Clear();
            TxtUsu.Clear();
            TxtPass1.Clear();
            TxtPass2.Clear();
            LblId.Text = "0";
        }

        private void BtnAgegar_Click(object sender, EventArgs e)
        {
            if (TxtPass1 .Text==TxtPass2.Text) { ingreso(); }
            
            else{
                MessageBox.Show("Las contraseñas no coinciden");
                TxtPass2.Clear();
                TxtPass1.Clear();
            }
        }

        private void ingreso()
        {
            string nivel = "0";
            if (CboNivel.Text == "Administrador")
            { nivel = "2"; }
            else if (CboNivel.Text == "Receptor")
            { nivel = "3"; }
            else if (CboNivel.Text == "Cobrador")
            { nivel = "4"; }
            else { nivel = "0"; }
            string[] datos = {LblId .Text ,TxtNom.Text ,TxtUsu.Text,TxtPass2.Text,nivel };
            if (usu.existe(LblId.Text))
            {
                if (usu.updat(datos))
                {
                    MessageBox.Show("Datos del usuario actualizados correctamente");
                }
                else
                {
                    MessageBox.Show("Error al actualizar datos");
                }
            }
            else
            {
             
                if (usu.ingre(datos))
                {

                    if (nivel == "4")
                    {
                        string[] aseso = new string[3];
                        aseso[0] = datos[1];
                        aseso[1] = "";
                        aseso[2] = "";


                        if (ase.ingresar_asesor(aseso))
                        { MessageBox.Show("Datos del cobrador ingresados correctamente","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information); }
                        else
                        { MessageBox.Show("Ocurrio un problema al ingresar datos del cobrador","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation); }
                    }
                    MessageBox.Show("Datos del usuario ingresados correctamente","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al ingresar datos del usuario","Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

            }
            limpiar();
        }
    }
}
