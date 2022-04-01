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
    public partial class login : Form
    {
        Clases.Logueo log = new Clases.Logueo();
        public login()
        {
            InitializeComponent();

        }

        private void ingreso()
        {
            string usu;
            string pass;
            usu = TxtUsu.Text;
            pass = TxtContra.Text;
            if (log.loguearse(usu, pass))
            {
               // MessageBox.Show("Acceso concedido", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Formularios.Main inicio = new Formularios.Main();
                inicio.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Acceso Denegado \nVerifique su usuario o contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiar();

            }
        }

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            ingreso();
        }

        private void limpiar()
        {
           // TxtContra.ForeColor = Color.FromArgb(210, 210, 210);
            TxtContra.Text = "";
            TxtContra.PasswordChar = '\0';
           // TxtUsu.ForeColor = Color.FromArgb(210, 210, 210);
            TxtUsu.Text = "";

        }
        private void TxtUsu_MouseEnter(object sender, EventArgs e)
        {
         /*   Color TextoCol;
            TextoCol = Color.FromArgb(0, 0, 0);
            if (TxtUsu.Text == "Usuario")
            {
                TxtUsu.Text = "";
                TxtUsu.ForeColor = TextoCol;
            }*/
        }

        private void TxtUsu_MouseLeave(object sender, EventArgs e)
        {
            /*Color TextoCol;
            TextoCol = Color.FromArgb(210, 210, 210);
            if (TxtUsu.Text == "")
            {
                TxtUsu.Text = "Usuario";
                TxtUsu.ForeColor = TextoCol;
            }*/

        }

        private void TxtContra_MouseEnter(object sender, EventArgs e)
        {
           /* Color TextoCol;
            TextoCol = Color.FromArgb(0,0,0);
            if (TxtContra.Text == "Contraseña")
            {
                TxtContra.Text = "";
                TxtContra.PasswordChar = Convert .ToChar ("*");
                TxtContra.ForeColor = TextoCol;
            }*/
        }

        private void TxtContra_MouseLeave(object sender, EventArgs e)
        {
           /* Color TextoCol;
          TextoCol = Color.FromArgb(210, 210, 210);
            if (TxtContra.Text == "")
            {
                TxtContra.Text = "Contraseña";
                TxtContra.PasswordChar = '\0';
               TxtContra.ForeColor = TextoCol;
            }*/
        }

        private void TxtContra_TextChanged(object sender, EventArgs e)
        {
            if (TxtContra.Text != "")
            {
                Color TextoCol;
                TextoCol = Color.FromArgb(0, 0, 0);
                TxtContra.ForeColor = TextoCol;
                TxtContra.PasswordChar = '*';

            }
            else
            {
         
                TxtContra.PasswordChar = '\0';
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            //BtnIngresar.Focus();
            TxtUsu.Focus();
            
        }

        private void TxtUsu_Click(object sender, EventArgs e)
        {
            Color TextoCol;
            TextoCol = Color.FromArgb(0, 0, 0);
            if (TxtUsu.Text == "Usuario")
            {
                TxtUsu.Text = "";
                TxtUsu.ForeColor = TextoCol;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TxtContra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) ingreso();
            
        }
    }
}
