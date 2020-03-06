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
    public partial class Solicitud : Form
    {
        Clases.ClAsesor aseso = new Clases.ClAsesor();
        Clases.Solicitud sol = new Clases.Solicitud();
        Clases.Cliente cli = new Clases.Cliente();
        public Solicitud()
        {
            InitializeComponent();
        }

        private void Solicitud_Load(object sender, EventArgs e)
        {
            int totalas;
            int totalcli;
            DataTable datosas = new DataTable();
            DataTable datoscli = new DataTable();
            datosas = aseso.busca_asesor_nom();
            datoscli = cli.Buscar_nom_cli();
            totalas = datosas .Rows.Count ;
            totalcli = datoscli.Rows.Count;
            int c1, c2;
            for (c1 = 0; c1 <= totalas - 1; c1++)
            {
                CboAsesor.Items.Add (datosas.Rows[c1][0]);
            }
            for (c2=0; c2 <= totalcli - 1; c2++)
            {
                CboCliente .Items.Add(datoscli.Rows[c2][0]);
            }
            LblFecha.Text  = "Fecha de solicitud: " + DateTime.Now.ToString("dd/MM/yyyy");
            TxtNoSol.Text = sol.id_solicitud().ToString ();
            CboPlaz.Items.Add("1 Mes");
            CboPlaz.Items.Add("Anual");



        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            TxtNoSol.Clear();
            TxtConcept.Clear();
            TxtGaran.Clear();
            TxtMonto.Clear();
            TxtNoSol.Text = sol.id_solicitud().ToString();
               
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            string asesor;
            string cliente;
            string fecha = DateTime.Now.ToString("dd/MM/yyyy");
            string fechaf = fecha.Replace("Fecha de solicitud: ", "");
            asesor = Convert .ToString ( aseso.id_asesor (CboAsesor.Text));
            cliente = Convert.ToString (cli.buscar_cod(CboCliente.Text));

            string[] datos = {TxtNoSol .Text ,TxtConcept.Text,TxtMonto.Text ,fechaf,"Espera",CboPlaz .Text,TxtGaran .Text,asesor,cliente };
            if (sol.agregar_soli(datos))
            {
                MessageBox.Show("Solicitud ingresada correctamente");
                limpiar();
            }
            else
            {
                MessageBox.Show("Error al ingresar solicitud");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1 .SelectedIndex ==1) { 
            solicitudes();
                bloquear();
            CboEstado.Items.Clear();
            CboEstado.Items.Add("Aceptado");
            CboEstado.Items.Add("Denegado");
            CboEstado.SelectedIndex = 0;
            }
        }
        private void solicitudes()
        {
            int total;
            DataTable datos = new DataTable();
            datos = sol.busca_soli_pend();
            total = datos.Rows.Count;
            CboSoli.Items.Clear();
            int c1;
            for (c1 = 0; c1 <= total - 1; c1++)
            {
                CboSoli.Items.Add(datos.Rows[c1][0]);
            }
        }

        private void CboSoli_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenado_datos();
        }
        private void llenado_datos()
        {
           
            if (CboSoli.Text != "")
            {
                string solicitud;
                DataTable datos = new DataTable();
                solicitud = CboSoli.Text;
                datos = sol.busca_datos(solicitud);
                TxtNomSoli .Text = datos.Rows[0][0].ToString();
                TxtNomAseso .Text = datos.Rows[0][1].ToString();
                TxtConcepto.Text = datos.Rows[0][2].ToString();
                TxtMonto2.Text = datos.Rows[0][3].ToString();
                TxtGarantia.Text = datos.Rows[0][5].ToString();
                TxtPlazo.Text = datos.Rows[0][4].ToString();
                LblFechasol.Text = "Fecha de solicitud: " + Convert .ToDateTime(datos.Rows[0][6]).ToString ("dd/MM/yyyy");
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            desbloquear();
        }

        private void bloquear()
        {
            TxtMonto2.Enabled = false;
            TxtConcepto.Enabled = false;
            TxtGarantia.Enabled = false;
            TxtPlazo.Enabled = false;
            CboEstado.Enabled = false;
            TxtInteres.Enabled = false;
            TxtNomAseso.Enabled = false;
            TxtNomSoli.Enabled = false;
               

        }
        private void desbloquear()
        {
            TxtMonto2.Enabled = true;
            TxtConcepto.Enabled = true;
            TxtGarantia.Enabled = true;
            TxtPlazo.Enabled = true;
            CboEstado.Enabled = true;
            TxtInteres.Enabled = true;
            TxtNomAseso.Enabled = true;
            TxtNomSoli.Enabled = true;
        }

        private void GBXPrestamo_Enter(object sender, EventArgs e)
        {

        }

        private void BntCambiar_Click(object sender, EventArgs e)
        {
            cambiar_estado();
        }
        private void cambiar_estado()
        {
            string solicitud = CboSoli.Text;
            string monto = TxtMonto2.Text;
            string plazo = TxtPlazo.Text;
            string interes=TxtInteres .Text ;
            string fecha_conc = DateTime.Now.AddDays(1).ToString("yyyy/MM/dd");
            string fecha_fin = DateTime.Now.AddDays(30).ToString("yyyy/MM/dd");
            string[] datos= { solicitud,monto,plazo ,interes,fecha_conc ,fecha_fin };
            if (sol.camb_estado(datos))
            {
                MessageBox.Show("El credito ha sido autorizado con exito");
            }
            else
            {
                MessageBox.Show("El credito no ha podido ser autorizado");
            }

        }
    }
}

