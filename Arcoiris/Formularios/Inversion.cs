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
    public partial class Inversion : Form
    {
        Clases.Cliente cli = new Clases.Cliente();
        Clases.Inversion Inver = new Clases.Inversion();
        private int idinvUniver = 0;
        public Inversion()
        {
            InitializeComponent();
        }



        private void CboCliNom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Operaciones

        private void listacli()
        {
            DataTable listadocli = new DataTable();
            listadocli = cli.Buscar_nom_cli();
            CboCliNom.DataSource = listadocli;
            CboCliNom.DisplayMember = "Nombre";
            CboCliNom.ValueMember = "Codigo_Cli";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in listadocli.Rows)
            {
                coleccion.Add(row["Nombre"].ToString());
            }
            CboCliNom.AutoCompleteCustomSource = coleccion;
            CboCliNom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboCliNom.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void listaInv()
        {
            int total;
            //DtpFecha1.
            DataTable datos = new DataTable();
            string valor;
            if (CboCliNom.Text == "")
            {
                valor = "-1";
            }
            else
            {
                valor = idinvUniver.ToString();
            }
            datos = Inver.InverByCli(valor);
            total = datos.Rows.Count;
            CboInv.Items.Clear();
            int c1;
            if (total > 0)
            {
                BtnSearchInv.Enabled = true;
                CboInv.Enabled = true;
                CboInv.Items.Clear();
                for (c1 = 0; c1 <= total - 1; c1++)
                {
                    CboInv.Items.Add(datos.Rows[c1][0]);
                }
            }
            else
            {
                CboInv.Items.Clear();
                BtnSearchInv.Enabled = false;
                //   CboPresta.Enabled = false;
            }

        }

        private void MostrarDatosInv()
        {
            //Falta Estado, origen, incentivo, regalo, bveneficiario, porcentaje de interes, y asesor

            string inversi = CboInv.Text;
            DataTable datos = Inver.detalle_Inv(inversi);
            DataTable nombre = Inver.AsesoAndBenefByinv(inversi);
            decimal interespuesto = decimal.Parse(datos.Rows[0][3].ToString()) * 100;
            decimal montoregalo = Math.Round(decimal.Parse($"{datos.Rows[0][1]}") * decimal.Parse($"{datos.Rows[0][9]}"), 2);
            TxtMonto.Text = $"{datos.Rows[0][1]}";

            TxtPlazo.Text = $"{datos.Rows[0][2]} Meses";
            TxtInt.Text = $"{interespuesto}%";
            TxtFingre.Text = $"{datos.Rows[0][4]}";
            TxtFTerPer.Text = $"{datos.Rows[0][5]}";
            TxtTranscu.Text = $"{PeriodoCurrido(datos.Rows[0][4].ToString())} Mes(es)";
            TxtIncent.Text = $"Q.{datos.Rows[0][7]}";
            TxtOrigen.Text = $"{datos.Rows[0][8]}";
            TxtRegalo.Text = $"Q.{montoregalo}";

            //reparar consulta para recuperar nombre de beneficiario, no de cliente
            TxtAseso.Text = $"{nombre.Rows[0][0]}";
            TxtBenef.Text = $"{nombre.Rows[0][1]}";

        }




        #endregion

        private void Inversion_Load(object sender, EventArgs e)
        {
            listacli();
        }

        private void CboCliNom_SelectedValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(CboCliNom.SelectedValue.ToString(), out idinvUniver))
            {
                listaInv();
            }
            else
            {
                idinvUniver = 0;
            }
        }

        private void BtnSearchInv_Click(object sender, EventArgs e)
        {
            MostrarDatosInv();
        }
        private int PeriodoCurrido(string Dada)
        {
            DateTime FechaHoy = DateTime.Parse(DtpFecha1.Value.ToString());
            DateTime FechaIni = DateTime.Parse(Dada);
            FechaIni = FechaIni.AddMonths(1);
            int conteo = 0;
            while (FechaHoy >= FechaIni)
            {
                conteo++;
                FechaIni = FechaIni.AddMonths(1);
            }
            return conteo;
        }
    }
}
