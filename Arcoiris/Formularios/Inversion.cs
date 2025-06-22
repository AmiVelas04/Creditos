using Humanizer;
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
        Clases.CajaOpe caj = new Clases.CajaOpe();
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
            decimal monto = decimal.Parse($"{datos.Rows[0][1]}");
            decimal interespuesto = decimal.Parse(datos.Rows[0][3].ToString()) * 100;
            decimal montoregalo = Math.Round(decimal.Parse($"{datos.Rows[0][1]}") * decimal.Parse($"{datos.Rows[0][9]}"), 2);
            decimal IntGene = Math.Round( (interespuesto/100 * PeriodoCurrido(datos.Rows[0][4].ToString()) *monto/12),2);
            
            TxtMonto.Text = $"{datos.Rows[0][1]}";

            TxtPlazo.Text = $"{datos.Rows[0][2]} Meses";
            TxtInt.Text = $"{interespuesto}%";
            TxtFingre.Text = $"{datos.Rows[0][4]}";
            TxtFTerPer.Text = $"{datos.Rows[0][5]}";
            TxtTranscu.Text = $"{PeriodoCurrido(datos.Rows[0][4].ToString())} Mes(es)";
            TxtIncent.Text = $"Q.{datos.Rows[0][7]}";
            TxtOrigen.Text = $"{datos.Rows[0][8]}";
            TxtRegalo.Text = $"Q.{montoregalo}";
            TxtGanGen.Text = $"Q.{IntGene}";
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

            if (CboInv.SelectedIndex != -1)
            {
                MostrarDatosInv();
                BtnGanAct.Enabled = true;
                BtnRetiro.Enabled = true;
            }



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

        private void BtnGanAct_Click(object sender, EventArgs e)
        {
            if (CboInv.SelectedIndex != -1)
            {
                TxtMontoRetir.Text = "0";
                //Busqueda de los dato generales
                                string inversi = CboInv.Text;
                DataTable datos = Inver.detalle_Inv(inversi);

                //Condicion de cierre de calculo
                int plazo = int.Parse($"{datos.Rows[0][2]}");
                decimal capital = decimal.Parse($"{datos.Rows[0][1]}");
                int plazotrans = PeriodoCurrido($"{datos.Rows[0][4]}");
                decimal interespuesto = decimal.Parse(datos.Rows[0][3].ToString()) * 100;
                decimal IntGene = interespuesto * PeriodoCurrido(datos.Rows[0][4].ToString());
                if (plazotrans < plazo)
                {
                    if (plazo >= 12)
                    {
                        IntGene = Math.Round(((IntGene / 2) + capital), 2);
                    }
                    else
                    {
                        IntGene = Math.Round(capital, 2);
                    }
                }
                else
                {
                    IntGene = Math.Round((IntGene+capital));
                }

               
                TxtMontoRetir.Text = $"{IntGene}";
            }
        }

        private void CboInv_SelectedIndexChanged(object sender, EventArgs e)
        {
            BtnGanAct.Enabled = false;
        }

        private void DtpFecha1_ValueChanged(object sender, EventArgs e)
        {
            BtnGanAct.Enabled = false;
        }

        private void BtnRetiro_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes==MessageBox.Show("Desea realizar el retiro de la inversion?, Esto dara la inversion como terminada","Realizar retiro?",MessageBoxButtons.YesNo,MessageBoxIcon.Question)) retiro();
            
        }
        private void retiro()
        {
            //Condicion de cierre de calculo
            string inversi = CboInv.Text;
            DataTable datos = Inver.detalle_Inv(inversi);
            int plazo = int.Parse($"{datos.Rows[0][2]}");
            decimal capital = decimal.Parse($"{datos.Rows[0][1]}");
            int plazotrans = PeriodoCurrido($"{datos.Rows[0][4]}");
            decimal interespuesto = decimal.Parse(datos.Rows[0][3].ToString()) * 100;
            decimal IntGene = interespuesto * PeriodoCurrido(datos.Rows[0][4].ToString());
            if (plazotrans < plazo)
            {
                if (plazo >= 12)
                {
                    IntGene = Math.Round(((IntGene / 2)), 2);
                }
                else
                {
                    IntGene = Math.Round(0.000M, 2);
                }
            }
            else
            {
                IntGene = Math.Round((IntGene));
            }


            string[] valos = { CboInv.Text, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),TxtMonto.Text,IntGene.ToString(), TxtMontoRetir.Text, Form1.Cod_U };
            if (Inver.Hacer_Retiro(valos))
            {
                MessageBox.Show("Retiro realizado correctamente", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ingresocaja();
                imprimir(valos );
                TxtMontoRetir.Text = "0";

            }
            else
            {
                MessageBox.Show("El retiro no pudo realizarse", "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                TxtMontoRetir.Text = "0";
            }
        }

        private void ingresocaja()
        {
                                   string id = Convert.ToString(caj.id_pago() + 1);
            string operacion = "Egreso";
            string monto = TxtMontoRetir.Text;
            string descripcion = $"Retiro de Inversion No.{CboInv.Text}";
            //Solicitude de fehca 11/03.2025 de diego de que el pago sea registrado con la fecha actual y no la fehca de la ventana de prestamo
            string fecha = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"); //DtpPago.Value.ToString("yyyy/MM/dd");
            string estado = "Activo";
            string usuario = Form1.Cod_U;
            string credito = "N/E";
            string cliente = CboCliNom.Text;
            

            String[] datos = { id, operacion, monto, descripcion, fecha, estado, usuario, credito, cliente };
            if (caj.ingreope(datos))
            {
                MessageBox.Show("Retiro registrado con exito","Hecho",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El retiro no pudo realizarse", "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void imprimir(string[] datos)
        {
            List<Reportes.RetDet> detalle = new List<Reportes.RetDet>();
            Reportes.RetDet Temp = new Reportes.RetDet();
            int total, cents;
            decimal valor = decimal.Parse(datos[2]) + decimal.Parse(datos[3]);
            cents = Convert.ToInt32((valor % 1) * 100);
            total = int.Parse(Math.Truncate(valor).ToString());
            // total = Convert.ToInt32(valor - (cents / 100));
            string letras;
            letras = total.ToWords() + " con " + cents.ToWords();
            if (cents <= 0) letras = total.ToWords() + " exactos";
            Temp.Inversion = int.Parse(datos[0]);
            Temp.Fecha = DateTime.Parse(datos[1]);
            Temp.Monto = decimal.Parse(datos[2]);
            Temp.interes = decimal.Parse(datos[3]);
            Temp.Cliente = CboCliNom.Text;
            decimal tot=Temp.Monto + Temp.interes;
            Temp.Retiro = Inver.id_InvAct();
            Temp.TotalL = letras;
            Temp.Dir = "Sin";
            detalle.Add(Temp);
            Reportes.Retiro ret = new Reportes.Retiro();
            ret.Deta = detalle;
            ret.Show();




        }
    }
}
