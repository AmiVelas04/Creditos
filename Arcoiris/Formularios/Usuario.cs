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
        public Usuario()
        {
            InitializeComponent();
        }

        private void Usuario_Load(object sender, EventArgs e)
        {
            CboNivel.Items.Add("Administrador");
            CboNivel.Items.Add("Gerente");
            CboNivel.Items.Add("Asesor");
            CboNivel.Items.Add("Receptor");
            
            CboNivel.SelectedIndex = 0;

            CargaUsu();

            /*for (cont = 1; cont <= total; cont++)
            {
               CboUser.Items.Add(dt.Rows [cont-1][1]);
            }*/
        }

        private void CargaUsu()
        {
            DataTable dt = new DataTable();
            dt = usu.bucarusu();
            int total = dt.Rows.Count;
            //   int cont;
            LstUsu.DataSource = dt;
            LstUsu.DisplayMember = "Nombre";
            LstUsu.ValueMember = "cod_usuario";
            //CboUser.Items.Clear();
            //CboUser.DataSource = dt;
            //CboUser.DisplayMember = "nombre";
            //CboUser.ValueMember = "cod_usuario";
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EditarUsu();
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
            CboNivel.SelectedIndex = 3;
        }

        private void BtnAgegar_Click(object sender, EventArgs e)
        {
            agregarUsu();
          
        }

        private void agregarUsu()
        {
            if (TxtPass1.Text == TxtPass2.Text) { ingreso(); }

            else
            {
                MessageBox.Show("Las contraseñas no coinciden");
                TxtPass2.Clear();
                TxtPass1.Clear();
            }
        }

        private void EditarUsu()
        {
            string nivel = "0";
            if (CboNivel.SelectedIndex == 0)
            { nivel = "2"; }
            else if (CboNivel.SelectedIndex == 1) { nivel = "5"; }
            else if (CboNivel.SelectedIndex == 2) { nivel = "4"; }
            else if (CboNivel.SelectedIndex == 3) { nivel = "3"; }
            string[] datos = { LblId.Text, TxtNom.Text, TxtUsu.Text, TxtPass2.Text, nivel };
           
                if (usu.updat(datos))
                {
                    MessageBox.Show("Datos del usuario actualizados correctamente");
                }
                else
                {
                    MessageBox.Show("Error al actualizar datos");
                }
          
            limpiar();
        }


        private void ingreso()
        {
            string nivel = "0";
            if (CboNivel.SelectedIndex == 0)
            { nivel = "2"; }


            else if (CboNivel.SelectedIndex == 1) { nivel = "5"; }
            else if (CboNivel.SelectedIndex == 2) { nivel = "4"; }
            else if (CboNivel.SelectedIndex == 3) { nivel = "3"; }
            string[] datos = { LblId.Text, TxtNom.Text, TxtUsu.Text, TxtPass2.Text, nivel };

            if (usu.ingre(datos))
            {
                MessageBox.Show("Datos del usuario ingresados correctamente");
            }
            else
            {
                MessageBox.Show("Error al ingresar datos");
            }

        }

        private void LstUsu_DoubleClick(object sender, EventArgs e)
        {
            CargaUsuDatos();
        }

        private void CargaUsuDatos()
        {
            int idusu = int.Parse(LstUsu.SelectedValue.ToString());
            LblId.Text = idusu.ToString();
            DataTable dt = new DataTable();
            dt = usu.bucarusucod(LblId.Text);
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("No existen datos que modficar");
            }
            else
            {
               // LblId.Text = dt.Rows[0][0].ToString();
                TxtNom.Text = dt.Rows[0][1].ToString();
                TxtUsu.Text = dt.Rows[0][2].ToString();
                if (dt.Rows[0][4].ToString() == "2") CboNivel.SelectedIndex = 0;
                if (dt.Rows[0][4].ToString() == "5") CboNivel.SelectedIndex = 1;
                if (dt.Rows[0][4].ToString() == "4") CboNivel.SelectedIndex = 2;
                if (dt.Rows[0][4].ToString() == "3") CboNivel.SelectedIndex = 3;
            }
        }
    }
}
