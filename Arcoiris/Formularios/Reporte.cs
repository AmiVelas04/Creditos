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
        Clases.ClAsesor aseso = new Clases.ClAsesor();
        Reportes.LlenarReport repor = new Reportes.LlenarReport();
        Clases.Credito cre = new Clases.Credito();

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
                CboCre.Items.Add("Reporte de pagos por dia (Diario)");
                CboCre.Items.Add("Reporte de pagos por dia (Mensual)");



                CboCre.SelectedIndex = 0;
                //BtnCartera.Visible = true;
                mes();
                anio();
                listarasesores();
                CboAsesor.SelectedIndex = 0;
                GbxD.Visible = true;
            }
            else
            {
                GbxAs.Visible = false;
                CboCre.Items.Add("Creditos Atrasados Diarios");
                CboCre.Items.Add("Creditos Atrasados Mensuales");
                CboCre.Items.Add("Creditos Cancelados Diarios");
                CboCre.Items.Add("Creditos Cancelados Mensuales");
                CboCre.Items.Add("Creditos Vigentes Diarios");
                CboCre.Items.Add("Creditos Vigentes Mensuales");
                CboCre.Items.Add("Reporte de Mora Creditos Diarios");
                CboCre.Items.Add("Reporte de Mora Creditos Mensuales");
                CboCre.Items.Add("Reporte de pagos por dia (Diario)");
                CboCre.Items.Add("Reporte de pagos por dia (Mensual)");
             

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
             5 Vigentes mensuales
             6 Dia de pago Diario
             7 Dia de pago Mensual
             */
            string tipo ="",titulo="";

            if (CboCre.SelectedIndex == 4)
            {
                if (Form1.Cod_U.Equals("3"))
                {
                    MessageBox.Show("No tiene autirización de visualizar este reporte","Autorización",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }
                else
                {
                    titulo = "Listado de creditos vigentes Diarios";
                    tipo = "Diario";
                    repor.RepCreActi(titulo, tipo);
                }
                }
            else if (CboCre.SelectedIndex == 5)
            {
                if (Form1.Cod_U.Equals("3"))
                {
                    MessageBox.Show("No tiene autirización de visualizar este reporte", "Autorización", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    titulo = "Listado de creditos vigentes Mensuales";
                    tipo = "Mensual";
                    repor.RepCreActi(titulo, tipo);
                }
            }
            else if (CboCre.SelectedIndex == 0)
            {
                titulo = "Listado Creditos Atrasados Diarios";
                tipo = "Diario";
                repor.Venc_ord(titulo, tipo);
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
                repor.ColAct(titulo, tipo);
            }
            else if (CboCre.SelectedIndex == 7)
            {
                titulo = "Reporte de mora creditos mensuales";
                tipo = "Mensual";
                repor.ColAct(titulo, tipo);
            }
            else if (CboCre.SelectedIndex ==8)
            {
                titulo = "Reporte de pagos del dia";
                tipo = "Diario";
                string fecha = DtpFechaR.Value.ToString("dd/MM/yyyy");
                repor.RepDiaPago(titulo, tipo,fecha);
            }
            else if (CboCre.SelectedIndex == 9)
            {
                titulo = "Reporte de pago del dia";
                tipo = "Mensual";
                string fecha = DtpFechaR.Value.ToString("dd/MM/yyyy");
                repor.RepDiaPago(titulo, tipo,fecha);
            }






        }
        private void BtnRepGan_Click(object sender, EventArgs e)
        {

            if (RdbTodos.Checked)
            {
                Rep_gan();
            }
            else if (RdbMes.Checked)
            {
                Rep_Gan_Mes();
            }
            else if (RdbDia.Checked)
            {
                Rep_Gan_Di();
            }
                        else
            {
                MessageBox.Show("No se ha selecionado ninguna categoría");
            }
            
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

        private void Rep_Gan_Di()
        {
            string Finicio = FechaI(CboMes.Text, CboAnio.Text);
            string Ffin = FechaF(CboMes.Text, CboAnio.Text);
            string nomfecha;
            nomfecha = "\nCreditos Diarios\n"+CboMes.Text + " de " + CboAnio.Text;
            repor.GanaciaDi(Finicio, Ffin, nomfecha);
        }

        private void Rep_Gan_Mes()
        {
            string Finicio = FechaI(CboMes.Text, CboAnio.Text);
            string Ffin = FechaF(CboMes.Text, CboAnio.Text);
            string nomfecha;
            nomfecha = "\nCreditos Mensuales\n"+CboMes.Text + " de " + CboAnio.Text;
            repor.GanaciaMes(Finicio, Ffin, nomfecha);
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

            int indice= CboCre.SelectedIndex;
            if (indice == 8 || indice == 9)
            {
                LblFechaR.Visible = true;
                DtpFechaR.Visible = true;
            }
            else
            {
                LblFechaR.Visible = false;
                DtpFechaR.Visible = false;
            }

        }

        private void BtnCartera_Click(object sender, EventArgs e)
        {
           // repor.ColAct();
        }

        private void listarasesores()
        {
            DataTable datosas = new DataTable();
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            datosas = aseso.busca_asesor_nom();
            CboAsesor.DataSource = datosas;
            CboAsesor.DisplayMember = "Nombre";
            CboAsesor.ValueMember = "Codigo";
           /* foreach (DataRow row in datosas.Rows)
            {
                coleccion.Add(row["Nombre"].ToString());

            }
            CboAsesor.AutoCompleteCustomSource = coleccion;
            CboAsesor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboAsesor.AutoCompleteSource = AutoCompleteSource.CustomSource;*/
        }

        private void BtnComi_Click(object sender, EventArgs e)
        {
            string codase = CboAsesor.SelectedValue.ToString();
            string fechai, fechaf,asesor;
            DataTable datos = new DataTable();
            datos = cre.creditos(codase);
            asesor = aseso.nom_aseso(codase);
            fechai = DtpComIni.Value.ToString("yyyy/MM/dd");
            fechaf = DtpComiFin.Value.ToString("yyyy/MM/dd");
            
        calculocomi(datos,asesor,fechai,fechaf);


        }

        private void calculocomi(DataTable datos,string asesor, string fechai,string fechaf)
        {
            int cant, cont=0;
            string fechahoy = DateTime.Now.ToString("yyyy/MM/dd");
            string codcre = "";
            decimal Totalcomi=0;
            decimal pago =0, cuota=0, pagoint=0, pagocap=0;
            cant = datos.Rows.Count;
            DataTable datoscomi = new DataTable();
            datoscomi.Columns.Add("Credito").DataType = Type.GetType("System.String");
            datoscomi.Columns.Add("Cliente").DataType = Type.GetType("System.String");
            datoscomi.Columns.Add("Tipo").DataType = Type.GetType("System.String");
            datoscomi.Columns.Add("PagosH").DataType = Type.GetType("System.String");
            datoscomi.Columns.Add("Comision").DataType = Type.GetType("System.String");
           

            for (cont = 0; cont < cant; cont++)
            {
                string fechaini = datos.Rows[cont][5].ToString();
                string cliente = datos.Rows[cont][8].ToString() + " " + datos.Rows[cont][9].ToString();
                string tipCre = "", estado = datos.Rows[cont][10].ToString();
                int totpagos, tipocre=0, pagoscre=0,comi=0;
                int pagos = int.Parse(datos.Rows[cont][4].ToString());
                codcre = datos.Rows[cont][0].ToString();
                decimal totalpagAct= cre.totalpagAct(codcre,fechai,fechaf);
                decimal totalpagAnt = cre.totalpagAnt(codcre, fechai,fechaf);
                decimal interes=0, capital=0,pagosope,Valint,Monto;
                Monto = decimal.Parse(datos.Rows[cont][1].ToString());
                Valint = decimal.Parse(datos.Rows[cont][2].ToString());
                pagoscre = 0;
                tipocre = int.Parse(datos.Rows[cont][7].ToString());
                totpagos = cre.pagosfutu(fechaini, fechahoy, tipocre.ToString());
               
                pagosope = totalpagAct;
                if (tipocre == 1)
                {
                    /*  capital = Math.Round((Monto / pagos), 2);
                      interes = Math.Round(((Monto * Valint) / 100), 2);
                      tipCre = "Diario";
                      if (totalpagAct == 0 && estado == "Terminado")
                      {
                          pagoscre=0;
                      }
                      else if (totalpagAct > 0 && estado == "Activo") {

                          bool bandera = true, Novacuota = true;
                          cuota = interes;

                          while (Novacuota)
                          {
                              if (totalpagAnt < cuota)
                              {
                                  Novacuota = false;
                              }
                              else
                              {
                                  totalpagAnt -= cuota;
                              }
                          }
                          pagosope += totalpagAnt;
                          while (bandera)
                          {
                              if (pagosope < cuota)
                              {
                                  bandera = false;
                              }
                              else
                              {
                                  pagosope -= (cuota);
                                  pagoscre++;
                              }
                          }
                      }
                      else if (totalpagAct > 0 && estado == "Terminado")
                      {
                          bool bandera = true, Novacuota = true;
                          cuota = interes;
                          while (Novacuota)
                          {
                              if (totalpagAnt < cuota)
                              {
                                  Novacuota = false;
                              }
                              else
                              {
                                  totalpagAnt -= cuota;
                              }
                          }
                          pagosope += totalpagAnt;
                          while (bandera)
                          {
                              if (pagosope < cuota)
                              {
                                  bandera = false;
                              }
                              else
                              {
                                  pagosope -= (cuota);
                                  pagoscre++;
                              }
                          }
                      }*/

                    capital = Monto;
                    interes = Math.Round(((Monto * Valint) / 100), 2);
                    cuota = capital + interes;
                    decimal saldado;
                    saldado = Monto + (interes * pagos);
                    //pagosope = totalpagAnt + totalpagAct;
                    pagosope = cre.totalGenAnt(codcre, fechai, fechaf);
                    tipCre = "Diario";

                    if (!/*cre.UltpCredi*/cre.PagosCredCance(codcre, fechai, fechaf) && estado != "Terminado")
                    {
                        pagoscre = 0;
                    }
                    else if (/*cre.UltpCredi*/cre.PagosCredCance(codcre, fechai, fechaf) && estado == "Terminado")
                    {
                        bool bandera = true;
                        pagosope -= capital;
                        while (bandera)
                        {
                            if (pagosope >= interes)
                            {
                                pagosope -= interes;
                                pagoscre++;
                            }
                            else
                            {
                                bandera = false;
                            }
                        }
                        if (pagoscre > pagos) pagoscre = pagos;
                    }
                    else
                    {
                        pagoscre = 0;
                    }
                }
                else if (tipocre == 2)
                {
                    capital =Monto ;
                    interes = Math.Round(((Monto * Valint) / 100), 2);
                    cuota = capital + interes;
                    decimal saldado;
                    saldado = Monto + (interes * pagos);
                    //pagosope = totalpagAnt + totalpagAct;
                    pagosope = cre.totalGenAnt(codcre, fechai, fechaf);
                    tipCre = "Diario - Interes";

                    if (!/*cre.UltpCredi*/cre.PagosCredCance(codcre, fechai, fechaf) && estado!="Terminado")
                    {
                        pagoscre = 0;
                    }
                    else if (/*cre.UltpCredi*/cre.PagosCredCance(codcre,fechai,fechaf) && estado == "Terminado") 
                    {
                        bool bandera = true;
                        pagosope -= capital;
                            while (bandera)
                        {
                            if (pagosope >= interes)
                            {
                                pagosope -= interes;
                                pagoscre++;
                            }
                            else
                            {
                                bandera = false;
                            }
                        }
                            if (pagoscre>pagos) pagoscre = pagos;
                    }
                    else
                    {
                        pagoscre = 0;
                    }
                }
                else if (tipocre == 3)
                {
                    capital = Math.Round((Monto / pagos), 2);
                    interes = Math.Round(((Monto * Valint) / 100/12), 2);
                    tipCre = "Mensual";
                    bool bandera = true, Novacuota = true;
                    cuota = interes;
                    if (cuota == 0)
                    {
                        Novacuota = false;
                        bandera = false ;
                    }
                    while (Novacuota)
                    {
                        if (totalpagAnt < cuota)
                        {
                            Novacuota = false;
                        }
                        else
                        {
                            totalpagAnt -= cuota;
                        }
                    }
                    pagosope += totalpagAnt;
                    while (bandera)
                    {
                        if (pagosope < cuota)
                        {
                            bandera = false;
                        }
                        else
                        {
                            pagosope -= (cuota);
                            pagoscre++;
                        }
                    }
                }
                else if (tipocre == 4)
                {
                    //calculo de interes creditos sobre saldo
                    tipCre = "Mensual-SobreSaldo";
                    DataTable datoscred = new DataTable();
                    decimal MontoTotCred = Monto,SaldoTotInt=0, CapitalGen,interGen=0;
                    datoscred = cre.PagosSobresaldo(codcre);
                    int conteo1, totaldecredi ;
                    totaldecredi = datoscred.Rows.Count;
                    for(conteo1 = 0;conteo1 < totaldecredi;conteo1++)
                    {
                        int pagoscred = 0;
                        decimal totaldecomi = 0, cuotacapital = 0, cuotainteres = 0, porcentin = 0, montocred = 0, CuotaIntEsp=0;
                        montocred = decimal.Parse(datoscred.Rows[conteo1][0].ToString());
                        porcentin= decimal.Parse(datoscred.Rows[conteo1][1].ToString());
                        pagoscred = int.Parse(datoscred.Rows[conteo1][2].ToString());
                        cuotacapital = decimal.Parse(datoscred.Rows[conteo1][4].ToString());
                        cuotainteres = decimal.Parse(datoscred.Rows[conteo1][5].ToString());
                        CuotaIntEsp = MontoTotCred * porcentin / 100 / pagoscred;
                        SaldoTotInt += CuotaIntEsp;
                        if (cuotainteres >= CuotaIntEsp)
                        {
                            SaldoTotInt -= cuotainteres;
                            if (CuotaIntEsp != 0)
                            {
                                pagoscre++;
                            }
                        }
                        MontoTotCred -= cuotacapital;
                    }
                    pagoscre = cre.PagosTot(codcre, fechai, fechaf);
                }

                if (pagoscre > pagos) pagoscre = pagos;                
                comi = pagoscre;
                DataRow fila = datoscomi.NewRow();
                fila["Credito"] = codcre;
                fila["Cliente"] = cliente;
                fila["Tipo"] =tipCre ;
                fila["PagosH"] = comi;
                fila["Comision"] = comi;
                datoscomi.Rows.Add(fila);
            }
            imprepcomi(datoscomi,asesor,fechai,fechaf);

        }

        private void imprepcomi(DataTable datos,string asesor, string fechai, string fechaf)
        {
            Reportes.ComisionEnc enca = new Reportes.ComisionEnc();
            enca.asesor = asesor;
            enca.fechai = fechai;
            enca.fechaf = fechaf;
            int cant, cont;
            cant = datos.Rows.Count;
            for (cont = 0; cont < cant; cont++)
            {
                if (datos.Rows[cont][3].ToString()!="0")
                {
                Reportes.ComisionDet deta = new Reportes.ComisionDet();
                deta.credito = datos.Rows[cont][0].ToString();
                deta.cliente = datos.Rows[cont][1].ToString();
                deta.tipo = datos.Rows[cont][2].ToString();
                deta.pago = int.Parse(datos.Rows[cont][3].ToString());
                deta.comision = int.Parse(datos.Rows[cont][4].ToString());
                enca.detalle.Add(deta);
            }
            }
            Reportes.Comisiones Comi = new Reportes.Comisiones();
            Comi.Encabezado.Add(enca);
            Comi.Detalle = enca.detalle;
            Comi.Show();
            

        }
    }
}
