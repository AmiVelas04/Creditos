using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Arcoiris.Formularios
{
    
    public partial class Main : Form
    {
        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            LbUsuario.Text = "Usuario: " + Form1.Nombre;
            if (Form1.Cod_U == "1" || Form1.Cod_U == "2")
            {
                BtnAsesor.Visible = true;
                //BtnReporte.Visible = true;
                BtnGuardar.Visible = true;
                BtnAdmin.Visible = true;
            }
            else if (Form1.Cod_U == "3")
            {

            }
            else if (Form1.Cod_U == "4")
            {
                BtnAsesor.Visible = false;
                //BtnReporte.Visible = true;
                BtnGuardar.Visible = false;
                BtnAdmin.Visible = false;
                button1.Visible = false;
                BtnSolicitud.Visible = false;
            }
        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            PanelCentral.Controls.Clear();
            Formularios.Cliente formul = new Formularios.Cliente();
            formul.TopLevel = false;
            PanelCentral.Controls.Add(formul);
            PanelCentral.Tag = formul;
            formul.Show();

        }

        private void BtnAsesor_Click(object sender, EventArgs e)
        {
            PanelCentral.Controls.Clear();
            Formularios.Asesor asesor = new Formularios.Asesor();
            asesor.TopLevel = false;
            PanelCentral.Controls.Add(asesor);
            PanelCentral.Tag = asesor;
            asesor.Show();
        }

        private void BtnSolicitud_Click(object sender, EventArgs e)
        {
            PanelCentral.Controls.Clear();
            Formularios.Solicitud soli =new  Solicitud();
            soli.TopLevel = false;
            PanelCentral.Controls.Add(soli);
            PanelCentral.Tag = soli;
            soli.Show();
        }

        private void BtnCredito_Click(object sender, EventArgs e)
        {
            PanelCentral.Controls.Clear();
            Formularios.Prestamo  presta = new Prestamo();
            presta.TopLevel = false;
            PanelCentral.Controls.Add(presta);
            PanelCentral.Tag = presta;
            presta.Show();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.WindowState =FormWindowState.Minimized ;
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            /*Formularios.FormRep repo = new Formularios.FormRep();
            repo.Show();*/
            PanelCentral.Controls.Clear();
            Formularios.Reporte  repo = new Formularios.Reporte();
           repo.TopLevel = false;
            PanelCentral.Controls.Add(repo);
            PanelCentral.Tag = repo;
            repo.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelCentral.Controls.Clear();
            Formularios.Caja  caj = new Formularios.Caja ();
            caj.TopLevel = false;
            PanelCentral.Controls.Add(caj);
            PanelCentral.Tag = caj;
            caj.Show();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Formularios.Respaldo resp = new Formularios.Respaldo();
            resp.Show();
        }

        private void PanelSup_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void PanelLat_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            PanelCentral.Controls.Clear();
            Formularios.Usuario usu = new Formularios.Usuario();
            usu.TopLevel = false;
            PanelCentral.Controls.Add(usu);
            PanelCentral.Tag = usu;
            usu.Show();
        }
    }
}
