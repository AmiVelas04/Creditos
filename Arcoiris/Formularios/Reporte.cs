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
    public partial class Reporte : Form
    {
        Reportes.LlenarReport repor = new Reportes.LlenarReport();
        public Reporte()
        {
            InitializeComponent();
        }

        private void Reporte_Load(object sender, EventArgs e)
        {

            if (Form1.Cod_U == "1" || Form1.Cod_U == "2")
            {

                CboCre.Items.Add("Creditos Atrasados Diarios");
                CboCre.Items.Add("Creditos Atrasados Mensuales");
                CboCre.Items.Add("Creditos Cancelados Diarios");
                CboCre.Items.Add("Creditos Cancelados Mensuales"); ;
                CboCre.Items.Add("Creditos Vigentes Diarios");
                CboCre.Items.Add("Creditos Vigentes Mensuales");
                CboCre.Items.Add("Reporte de Mora Creditos Diarios");
                CboCre.Items.Add("Reporte de Mora Creditos Mensuales");

                CboCre.SelectedIndex = 0;
                //BtnCartera.Visible = true;
                mes();
                anio();
            }
            else
            {
                GbxAs.Visible = false;
                CboCre.Items.Add("Creditos Atrasados Diarios");
                CboCre.Items.Add("Creditos Atrasados Mensuales");
                CboCre.Items.Add("Creditos Cancelados Diarios");
                CboCre.Items.Add("Creditos Cancelados Mensuales");
                
            }


        }
        private void mes()
        {
            CboMes.Items.Add("Enero");
            CboMes.Items.Add("Febrero");
            CboMes.Items.Add("Marzo");
            CboMes.Items.Add("Abril");
            CboMes.Items.Add("Mayo");
            CboMes.Items.Add("Junio");
            CboMes.Items.Add("Julio");
            CboMes.Items.Add("Agosto");
            CboMes.Items.Add("Septiembre");
            CboMes.Items.Add("Octubre");
            CboMes.Items.Add("Noviembre");
            CboMes.Items.Add("Diciembre");
            CboMes.SelectedIndex = 0;

        }
        private void anio()
        {
            int cont,inicio=2019,fin=2030;
            for (cont = inicio; cont <= fin; cont++)
            {
                CboAnio.Items.Add(cont);
            }
            CboAnio.SelectedIndex = 0;
        }
        private void BtnReporte_Click(object sender, EventArgs e)
        {

            verreportes();
            
        }
        private void verreportes()
        {
            /*
             0 Atrasados diarios
             1 Atrasados Mensulaes
             2 Cancelados diarios
             3 Cancelados Mensuales
             4 Vigentes diarios
             5 Vigerntes mensuales
             */
            string tipo ="",titulo="";

            if (CboCre.SelectedIndex == 4)
            {
                titulo = "Listado de creditos vigentes Diarios";
                tipo = "Diario";
                repor.RepCreActi(titulo,tipo);
            }
            else if (CboCre.SelectedIndex == 5)
            {
                titulo = "Listado de creditos vigentes Mensuales";
                tipo = "Mensual";
                repor.RepCreActi(titulo,tipo);

            }
            else if (CboCre.SelectedIndex == 0)
            {
                titulo = "Listado Creditos Atrasados Diarios";
                tipo = "Diario";
                repor.Venc_ord(titulo,tipo);
                //repor.Cred_venc(titulo);

            }
            else if (CboCre.SelectedIndex == 1)
            {
                titulo = "Listado Credito Atrasados Mensual";
                tipo = "Mensual";
                repor.Venc_ord(titulo, tipo);
                //repor.Cred_venc(titulo);

            }
            else if (CboCre.SelectedIndex == 2)
            {
                titulo = "Listado creditos Terminados diarios";
                tipo = "Diario";
                repor.Cred_ver(tipo, titulo);
            }
            else if (CboCre.SelectedIndex == 3)
            {
                titulo = "Listado creditos Termnados Mensulaes";
                tipo = "Mensual";
                repor.Cred_ver(tipo, titulo);
            }
            else if (CboCre.SelectedIndex == 6)
            {
                titulo = "Reporte de mora creditos diarios";
                tipo = "Diario";
                repor.ColAct(titulo,tipo);
            }
            else if (CboCre.SelectedIndex == 7)
            {
                titulo = "Reporte de mora creditos mensuales";
                tipo = "Mensual";
                repor.ColAct(titulo,tipo);
            }




        }
        private void BtnRepGan_Click(object sender, EventArgs e)
        {
           Rep_gan();
        }
        private void Rep_gan()
        {
            //Crear fechas
            string Finicio = FechaI(CboMes.Text, CboAnio.Text);
            string Ffin= FechaF (CboMes.Text, CboAnio.Text);
            string nomfecha;
            nomfecha = CboMes.Text + " de " + CboAnio.Text;
            repor.Ganancia(Finicio, Ffin,nomfecha);

        }

        private string FechaI(string Mes, string anio)
        {
            string fecha;

            string Mmes = "";


            switch (Mes)
            {
                case "Enero":
                    Mmes = "1";
                    break;
                case "Febrero":
                    Mmes = "2";
                    break;
                case "Marzo":
                    Mmes = "3";
                    break;
                case "Abril":
                    Mmes = "4";
                    break;
                case "Mayo":
                    Mmes = "5";
                    break;
                case "Junio":
                    Mmes = "6";
                    break;
                case "Julio":
                    Mmes = "7";
                    break;
                case "Agosto":
                    Mmes = "8";
                    break;
                case "Septiembre":
                    Mmes = "9";
                    break;
                case "Octubre":
                    Mmes = "10";
                    break;
                case "Noviembre":
                    Mmes = "11";
                    break;
                case "Diciembre":
                    Mmes = "12";
                    break;

            }
            fecha = anio + "/" + Mmes + "/01";
            return fecha;
        }
        private string FechaF(string Mes, string anio)
        {

            string fecha;

            string Mmes = "";
            string Ddia = "";

            switch (Mes)
            {
                case "Enero":
                    Mmes = "1";
                    Ddia = "31";
                    break;
                case "Febrero":
                    Mmes = "2";
                    Ddia = "29";
                    break;
                case "Marzo":
                    Mmes = "3";
                    Ddia = "31";
                    break;
                case "Abril":
                    Mmes = "4";
                    Ddia = "30";
                    break;
                case "Mayo":
                    Mmes = "5";
                    Ddia = "31";
                    break;
                case "Junio":
                    Mmes = "6";
                    Ddia = "30";
                    break;
                case "Julio":
                    Mmes = "7";
                    Ddia = "31";
                    break;
                case "Agosto":
                    Mmes = "8";
                    Ddia = "31";
                    break;
                case "Septiembre":
                    Mmes = "9";
                    Ddia = "30";
                    break;
                case "Octubre":
                    Mmes = "10";
                    Ddia = "31";
                    break;
                case "Noviembre":
                    Mmes = "11";
                    Ddia = "30";
                    break;
                case "Diciembre":
                    Mmes = "12";
                    Ddia = "30";
                    break;

            }
            fecha = anio + "/" + Mmes + "/" + Ddia;
            return fecha;
        }

        private void BtnOrden_Click(object sender, EventArgs e)
        {
           
        }

        private void CboCre_SelectedIndexChanged(object sender, EventArgs e)
        {
         /*   if (CboCre.SelectedIndex == 0)
            { BtnOrden.Visible = true; }
            else
            { BtnOrden.Visible = false; }*/

        }

        private void BtnCartera_Click(object sender, EventArgs e)
        {
           // repor.ColAct();
        }
    }
}
