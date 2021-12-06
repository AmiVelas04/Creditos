using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Arcoiris.Formularios
{
    public partial class Solicitud : Form
    {
        Clases.ClAsesor aseso = new Clases.ClAsesor();
        Clases.Solicitud sol = new Clases.Solicitud();
        Clases.Cliente cli = new Clases.Cliente();
        Clases.Credito cre = new Clases.Credito();
        Clases.CajaOpe caj = new Clases.CajaOpe();
        Clases.Logueo log = new Clases.Logueo();
        Reportes.LlenarReport repo = new Reportes.LlenarReport();
        private int cod_credi;
        private decimal salantes=0;
        public Solicitud()
        {
            InitializeComponent();

        }

        private void Solicitud_Load(object sender, EventArgs e)
        {

            Tab2.Hide();
            Tab1.Hide();
            if (Form1.Nivel == "1" || Form1.Nivel == "2")
            {
                Tab2.Parent = tabControl1;
            }
            else
            {
                Tab2.Parent = null;
                
            }
           
           
            /*  for (c1 = 0; c1 <= totalas - 1; c1++)
              {
                  CboAsesor.Items.Add (datosas.Rows[c1][0]);
              }
              for (c2=0; c2 <= totalcli - 1; c2++)
              {
                  CboCliente .Items.Add(datoscli.Rows[c2][0]);
              }*/

            //Agregar datos al combo box cliente
            DataTable datoscli = new DataTable();
datoscli = cli.Buscar_nom_cli();
            CboCliente.DataSource = datoscli ;
            CboCliente.DisplayMember = "Nombre";
            CboCliente.ValueMember = "Codigo_Cli";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in datoscli .Rows)
            {
                coleccion.Add(row["Nombre"].ToString());

            }
            CboCliente.AutoCompleteCustomSource = coleccion;
            CboCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;


            //Agregar datos de asesores
            DataTable datosas = new DataTable();
            datosas = aseso.busca_asesor_nom();
            CboAsesor.DataSource = datosas;
            CboAsesor.DisplayMember = "Nombre";
            CboAsesor.ValueMember = "Codigo";
            foreach (DataRow row in datosas.Rows)
            {
                coleccion.Add(row["Nombre"].ToString());

            }
            CboAsesor.AutoCompleteCustomSource = coleccion;
            CboAsesor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboAsesor.AutoCompleteSource = AutoCompleteSource.CustomSource;



            LblFecha.Text  = "Fecha de solicitud: " + DateTime.Now.ToString("yyyy/MM/dd");
            TxtNoSol.Text = sol.id_solicitud().ToString ();
            CboTipo.Items.Add("Diario");
            CboTipo.Items.Add("Diario - Intereses");
            CboTipo.Items.Add("Mensual - Cuota Fija");
            CboTipo.Items.Add("Mensual - Sobre Saldo");
            CboTipo.SelectedIndex = 0;


        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }
        private void limpiar()
        {
            CboCliente.SelectedIndex = 0;
            CboAsesor.SelectedIndex = 0;
            TxtNoSol.Clear();
            TxtConcept.Clear();
            TxtGaran.Clear();
            TxtMonto.Clear();
            TxtNoSol.Text = sol.id_solicitud().ToString();
               
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            añadir();
        }
        private void añadir()
        {

            string asesor="";
            string cliente="";
            string fecha = DateTime.Now.ToString("yyyy/MM/dd");
            string fechaf = fecha.Replace("Fecha de solicitud: ", "");
            VeriContGar();
            string TipoG = CboTipoGarant.Text, Valu = TxtValu.Text, TipoEsc = TxtTipEsc.Text, Fesc = DtpEsc.Value.ToString("dd/MM/yyyy"),Aut= TxtAut.Text,Ubi= TxtUbicacion.Text,Gdetall= TxtGaran.Text,Estado="En Posesion";
            if (CboAsesor.SelectedValue == null)
            {
                MessageBox.Show("No existe el asesor seleccionado", "no hay asesor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                asesor = CboAsesor.SelectedValue.ToString();
            }

            if (CboCliente.SelectedValue == null)
            {
                MessageBox.Show("No existe el cliente seleccionado", "no hay cliente", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else
            {
                cliente = CboCliente.SelectedValue.ToString();
            }
          
            string tipo = "";
            string plazo;
            if (CboTipo.Text == "Diario")
            {
                tipo = "1";
                plazo = "30";

            }
            else if (CboTipo.Text == "Diario - Intereses")
            {
                tipo = "2";
                plazo = "30";
            }
            else if (CboTipo.Text == "Mensual - Cuota Fija")
            {
                tipo = "3";
                plazo = Convert.ToString(NupPlazo.Value);


            }
            else if (CboTipo.Text == "Mensual - Sobre Saldo")
            {
                tipo = "4";
                plazo = Convert.ToString(NupPlazo.Value);
            }
            else
            {
                tipo = "0";
                plazo = "0";
            }


            string[] datos = { TxtNoSol.Text, TxtConcept.Text, TxtMonto.Text, fechaf, "Espera", plazo, Gdetall, asesor, cliente, tipo,TipoG,Valu,Gdetall,TipoEsc,Fesc,Aut,Valu,Ubi,Estado};
            if (sol.hayasesor(asesor))
            {
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
            else
            {
                MessageBox.Show("No existe el asesor seleccionado", "no hay asesor", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cambiar();
        }
        private void cambiar()
        {
            limpiar2();
            if (tabControl1.SelectedIndex == 1)
            {
                solicitudes();
                bloquear();
                CboEstado.Items.Clear();
                CboEstado.Items.Add("Autorizado");
                CboEstado.Items.Add("Denegado");
                CboEstado.SelectedIndex = 0;
                comboBox1.Items.Add("1");
                comboBox1.Items.Add("2");
                comboBox1.Items.Add("3");
                comboBox1.Items.Add("4");
                comboBox1.SelectedIndex = 0;
                
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
            cod_credi = 0;
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
                LblCodCli.Text = datos.Rows[0][8].ToString();
                TxtNomSoli.Text  = datos.Rows[0][0].ToString();
                TxtNomAseso.Text = datos.Rows[0][1].ToString();
                TxtConcepto.Text = datos.Rows[0][2].ToString();
                TxtMonto2.Text = datos.Rows[0][3].ToString();
                TxtGarantia.Text = datos.Rows[0][5].ToString();
                TxtPlazo.Text = datos.Rows[0][4].ToString();
                //   LblFechasol.Text = "Fecha de solicitud: " + Convert.ToDateTime(datos.Rows[0][6]).ToString("dd/MM/yyyy");

                CboTipo2.Items.Clear();
                CboTipo2.Items.Add("Diario");
                CboTipo2.Items.Add("Diario - Intereses");
                CboTipo2.Items.Add("Mensual - Cuota Fija");
                CboTipo2.Items.Add("Mensual - Sobre Saldo");

                int tipo = Convert.ToInt32(datos.Rows[0][7].ToString());
                if (tipo == 1)
                {
                    //TxtTipo.Text = "Diario";
                    CboTipo2.SelectedIndex = 0;
                    label14.Text = "Interes Diario";
                }
                else if(tipo==2)
                {
                    //TxtTipo.Text = "Diario - Intereses";
                    CboTipo2.SelectedIndex = 1;
                    label14.Text = "Interes Diario";
                }
               else if (tipo == 3)
                {
                    //TxtTipo.Text = "Mensual - Cuota Fija"
                    CboTipo2.SelectedIndex = 2;
                    label14.Text = "Interes Anual";
                }
                else if (tipo == 4)
                {
                    //TxtTipo.Text = "Mensual - Sobre Saldo";
                    CboTipo2.SelectedIndex = 3;
                    label14.Text = "Interes Anual";
                }

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
            CboTipo2.Enabled = false;
               

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
            CboTipo2.Enabled = true;
        }

        private void ingresocaja(string cred)
        {
            decimal saldotemp = 0, gasto= Convert.ToDecimal (TxtGastos .Text) ;
            
         
            decimal montotep= Convert.ToDecimal(TxtMonto2.Text);
            
            if (LblRef.Text.Equals("1"))
            {
                saldotemp = montotep+montotep-salantes;
            }

            montotep -= saldotemp;
            montotep -= gasto;
            int contid = 1;
            //Egreso del monto total
            string id=Convert.ToString  (caj.id_pago()+contid);
            string operacion = "Egreso";
            string monto = Convert.ToDecimal(TxtMonto2.Text).ToString();
            string descripcion = "Desembolso";
            string fecha = DtpConc.Value.ToString("yyyy/MM/dd");
            string estado = "Activo";
            string usuario = Form1.Cod_U;
            string credito=cred, cliente=TxtNomSoli .Text ;
            string[] datos = { id,operacion,monto,descripcion,fecha,estado,usuario,credito,cliente};

            if (salantes > 0) {
                contid++;
            }
            //ingreso de Saldo anterior
            id = Convert.ToString(caj.id_pago() + contid);
            operacion = "Ingreso";
            monto = salantes.ToString ();
            descripcion = "Cancelacion de credito anterior";
            fecha = DtpConc.Value.ToString("yyyy/MM/dd");
            estado = "Activo";
            usuario = Form1.Cod_U;
            credito = cod_credi.ToString ();
            cliente = TxtNomSoli.Text;
            string[] datos2 = { id, operacion, monto, descripcion, fecha, estado, usuario, credito, cliente };


            if (gasto > 0) {
                contid++;
                
            }
            //ingreso de Gastos admin
            id = Convert.ToString(caj.id_pago() + contid);
            operacion = "Ingreso";
            monto = gasto.ToString();
            descripcion = "Gastos admnistrativos";
            fecha = DtpConc.Value.ToString("yyyy/MM/dd");
            estado = "Activo";
            usuario = Form1.Cod_U;
            credito = cred;
            cliente = TxtNomSoli.Text;
            string[] datos3 = { id, operacion, monto, descripcion, fecha, estado, usuario, credito, cliente };
            

            if (caj.ingreope(datos))
            {
                if (LblRef.Text.Equals("1"))
                {
                    caj.ingreope(datos2);
                }
                if ( gasto>0)
                {
                    caj.ingreope(datos3);
                                     
                }

               
             MessageBox.Show("Desembolso Registrado", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
             }
            else
            {
                MessageBox.Show("No se realizo el registro del desembolso", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

                
        }
       private void BntCambiar_Click(object sender, EventArgs e)
        {
            cambiar_estado();
            limpiar2();
            bloquear();
            cambiar();
        }

      
        private int totdias(string fechac, int dias)
        {
            DateTime Fini = Convert.ToDateTime(fechac);
            DateTime Ffin = Convert.ToDateTime(fechac);//cambair esta fecha para el final
            int diasc = 0;
            while (diasc < dias)
            {
                Ffin = Ffin.AddDays(1);
                if (Ffin.DayOfWeek == DayOfWeek.Saturday || Ffin.DayOfWeek == DayOfWeek.Sunday)
                {

                }
                else
                {
                    diasc++;
                }
            }
            return diasc;
        }
        private string fechaf(string fechac,int dias)
        {
            DateTime Fini = Convert.ToDateTime (fechac);
            DateTime Ffin=Convert.ToDateTime(fechac);//cambiar esta fecha para el final
            int diasc = 0;
            while (diasc<dias)
            {
               Ffin = Ffin.AddDays(1);
                if (Ffin.DayOfWeek == DayOfWeek.Saturday || Ffin.DayOfWeek == DayOfWeek.Sunday)
                {
                  
                }
                else
                {
                    diasc++;
                }
            }
            return Ffin.ToString ("yyyy/MM/dd");
           
        }
        private void cambiar_estado()
        {
            string tipo="";
            string fecha_conc = DtpConc.Value.ToString ("yyyy/MM/dd");
            string fecha_fin="";
            int dias=0;
            string solicitud = CboSoli.Text;
            string monto = TxtMonto2.Text;
            string plazo = TxtPlazo.Text;
            string interes = TxtInteres.Text;
            string estado = CboEstado.Text;
            decimal cuotaint = 0, cuotacapital; ;
            if (CboTipo2.SelectedIndex  == 0)
            {
                tipo = "1";
              dias = Convert.ToInt32(TxtPlazo.Text);
                fecha_fin = fechaf(fecha_conc, dias);
               
            }
            else if (CboTipo2.SelectedIndex == 1)
            {
                tipo = "2";
                dias = Convert.ToInt32(TxtPlazo.Text);
                fecha_fin = fechaf(fecha_conc, dias);
            }
            else if (CboTipo2.SelectedIndex == 2)
            {
                tipo = "3";
              dias = Convert.ToInt32(TxtPlazo.Text);
               fecha_fin = Convert.ToDateTime(fecha_conc).AddMonths(dias).ToString("yyyy/MM/dd");
            }
            else if (CboTipo2.SelectedIndex == 3)
            {
                tipo = "4";
               dias = Convert.ToInt32(TxtPlazo.Text);
             fecha_fin = Convert.ToDateTime(fecha_conc).AddMonths(dias).ToString("yyyy/MM/dd");
            }
            
       
 
            DataTable Creact = new DataTable();
            int cod_cli = sol.cod_cliente(CboSoli.Text);
            Creact = cre.creditos_act(Convert.ToString (cod_cli));
            int totalcre;
            totalcre = Creact.Rows.Count;
            string[] datos= new string[11];
            //Comprueba si cancelas creditos anteriores o se crea solamente un nuevo credito
            if (totalcre >= 1 && CboEstado.Text == "Autorizado")
            {
                if (MessageBox.Show("Existe(n) creditos activos de cliente \n¿Desea generar un refinanciamiento? \nSi(Refinanciar Credito)\nNo(Generar credito nuevo)", "Creditos anteriores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ListCred Lista = new ListCred();
                    Lista.cod_cli = cod_cli.ToString();
                    Lista.nombre = TxtNomSoli .Text;
                    Lista.Mostrarcre += new ListCred.permiso(cod_cred);
                    Lista.ShowDialog();
                    if (cod_credi == 0) return;
                    LblRef.Text = "1";
                    DataTable datosint = new DataTable();
                    datosint = cre.datoscre(cod_credi.ToString(), DateTime.Now.ToString("yyyy/MM/dd"));
//                    datos = cre.cantcre(CboPresta.Text, DtpPago.Value.ToString());
                    string nTipo = cre.tipoC(cod_credi.ToString());
                    decimal SaldAnt = cre.saldoant(cod_cli.ToString(), cod_credi.ToString());
                    decimal IntAnt = cre.SaldoDeinteres(cod_credi.ToString(), DateTime.Now.ToString("yyyy/MM/dd"), nTipo, 0); 
                    if (IntAnt < 0) IntAnt = 0;
                    salantes = SaldAnt + IntAnt;
                    datos[0] = solicitud;
                    datos[1] = monto;
                    datos[2] = plazo;
                    datos[3] = interes;
                    datos[4] = fecha_conc;
                    datos[5] = fecha_fin;
                    datos[6] = tipo;
                    datos[7] = estado;
                    datos[8] = salantes.ToString();
                    datos[9] = totdias(fecha_conc, dias).ToString();
                    datos[10] = TxtGastos.Text;

                    DataTable datosfi = new DataTable();
                    //calculo de cuotas finales
                    cuotacapital = cre.saldoant(cod_cli.ToString(), cod_credi.ToString());
                    datosfi = cre.cantcre(cod_credi.ToString(), DateTime.Now.ToString("dd/MM/yyyy"));
                    // cuotaint = cre.SaldoDeinteres(cod_credi.ToString(), DateTime.Now.ToString("dd/MM/yyyy"),nTipo, 0);
                    cuotaint = decimal.Parse(datosfi.Rows[0][5].ToString());
                    string[] pago =new string[8];
                    pago[0] = cod_credi.ToString();
                    pago[1] = "0";
                    pago[2] = "0";
                    if (cuotaint >0) pago[1] = cuotaint.ToString();
                    if (cuotacapital>0) pago[2] = cuotacapital.ToString();
                    
                    pago[3] = (decimal.Parse(pago[1]) + decimal.Parse(pago[2])).ToString();
                    pago[4] = "";
                    pago[5] = "";
                    pago[6] = "";
                    pago[7] =cuotaint.ToString();


                    //Registrar pago
                    pagocancelacion(pago);

                    if (cre.cancelar_cre(cod_credi.ToString () ))
                        {
                        MessageBox.Show("Se canceló el credito anterior: ", " cancelado");
                    }
                        else
                        {
                            //  MessageBox.Show("Credito: " + Creact.Rows[cont][0].ToString() + " cancelado");
                        }
                }
                else
                {
                    LblRef.Text = "0";
                    datos[0] = solicitud;
                    datos[1] = monto;
                    datos[2] = plazo;
                    datos[3] = interes;
                    datos[4] = fecha_conc;
                    datos[5] = fecha_fin;
                    datos[6] = tipo;
                    datos[7] = estado;
                    datos[8] = "0";
                    datos[9] = totdias(fecha_conc, dias).ToString();
                    datos[10] = TxtGastos.Text;

                }
            }
            else if (totalcre >= 1 && CboEstado.Text == "Denegado")
            {
                if ((sol.denegarsol(solicitud)))
                {
                    MessageBox.Show("Se cancelo la solicitud de credito", " cancelado");
                }
                else
                {

                    //  MessageBox.Show("Credito: " + Creact.Rows[cont][0].ToString() + " cancelado");                }
                }
            }

            else
            {
                datos[0] = solicitud;
                datos[1] = monto;
                datos[2] = plazo;
                datos[3] = interes;
                datos[4] = fecha_conc;
                datos[5] = fecha_fin;
                datos[6] = tipo;
                datos[7] = estado;
                datos[8] = "0";
                datos[9] = totdias(fecha_conc, dias).ToString();
                datos[10] = TxtGastos.Text;

            } 
            
            if (sol.camb_estado(datos))
            {
                if (estado == "Autorizado")
                {
                    MessageBox.Show("El credito ha sido autorizado con exito");
                    int credit = cre.id_credit(solicitud);
                    ingresocaja(credit.ToString ());
                }
                else
                {
                    MessageBox.Show("El credito ha sido denegado");
                }

                    hoja_pagos(datos[0],datos[6],datos[8]);
            }
            else
            {
                MessageBox.Show("El credito no ha podido ser autorizado");
            }

        }
        //Listadop de pa0gos por dia
            public void hoja_pagos(string soli,string tipo,string SaldAnte)
        {
          
            Clases.Credito cre = new Clases.Credito();
            int credi;
            credi = cre.id_credit(soli);
            string dpi = cli.clidpi(soli);
            //int a=1;
            //ThreadStart resumen = new ThreadStart(LLenRep);

            //ThreadStart tabla = new ThreadStart(LLenRep);

            Thread hilo1 = new Thread(new ParameterizedThreadStart(LLenRep));
            string[] datos = { credi.ToString(), tipo };
            hilo1.Start(datos);
           repo.ResumenDesem(credi, tipo, TxtGastos.Text,dpi,SaldAnte);
            //repo.llenar_rep(credi,tipo);
        }

        private void pagocancelacion(string [] valores)
        {
            string credito = valores[0];
            string interes = valores[1];
            string capital = valores[2];
            string pago = valores[3];
            string fecha = DateTime.Now .ToString ("yyyy/MM/dd");
            string mora = "0";
            string capital2 ="0";
            string interes2 = valores[7];
            string[] datos = { credito, interes2, capital, pago, fecha, mora,capital2,interes2 };
            Clases.Pago pagar = new Clases.Pago();
            if (pagar.Hacer_Pago(datos))
            {
                MessageBox.Show("Pago Realizado con exito");

            }
            else
            {
                MessageBox.Show("Error en el pago");
            }
        }

        private void LLenRep(object parametros)
        {
           string[] datos = (string[])parametros;
            int credi = int.Parse(datos[0]);
          if (InvokeRequired)
               Invoke (new Action(()=>repo.llenar_rep(credi, datos [1])));
        }

        //listado de pagos por mes
        private void CboPlaz_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboTipo.SelectedIndex == 0 || CboTipo .SelectedIndex ==1)
            {
                LblPlazo.Visible = false;
                NupPlazo .Visible = false;
              
            }
            else
            {
                LblPlazo.Visible = true;
                NupPlazo .Visible = true;
      

            }
        }

           public void cod_cred(string credi)
        {
            cod_credi = Convert.ToInt32(credi);
        }
        private void limpiar2()
        {
            TxtNomSoli.Clear();
            TxtNomAseso.Clear();
            TxtMonto2.Clear();
            TxtConcepto.Clear();
            TxtGarantia.Clear();
            //TxtTipo.Clear();
            TxtPlazo.Clear();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sol.cambiodias();
           // sol.cambiofechas(comboBox1 .Text);
        }

        private void Solicitud_KeyDown(object sender, KeyEventArgs e)
        {
          //  MessageBox.Show("LOL");
           
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                if (log.nivel("admin") == 1)
                {
                  
                   comboBox1.Visible = true;
                 button1.Visible = true;
                }
            }
            if (e.KeyCode == Keys.F11)
            {
                comboBox1.Visible = false;
               button1.Visible = false;
            }
        }

        private void TxtMonto_TextChanged(object sender, EventArgs e)
        {
            if (TxtMonto.Text == "") TxtMonto.Text = "0";
            if (TxtMonto.Text == "-") TxtMonto.Text = "0";

        }

        private void TxtGastos_TextChanged(object sender, EventArgs e)
        {
            if (TxtGastos.Text == "")
            {
                TxtGastos.Text = "0";
            }
            if (TxtGastos.Text == "-")
            {
            }
            else
            {
                if (Convert.ToDecimal(TxtGastos.Text) < 0)
                {
                    TxtGastos.Text = "0";
                }
            }
            
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            if ((sol.denegarsol(CboSoli.Text )))
            {
                MessageBox.Show("Se cancelo la solicitud de credito", " cancelado");
                limpiar2();
                bloquear();
                cambiar();
            }

        }

        private void CboTipoGarant_SelectedIndexChanged(object sender, EventArgs e)
        {
            string TipG;
            TipG = CboTipoGarant.SelectedIndex.ToString();
            if (TipG.Equals("1"))
            {
                label21.Visible = true;
                label22.Visible = true;
                label23.Visible = true;
                TxtTipEsc.Visible = true;
                //CboTipEsc.Visible = true;
                DtpEsc.Visible = true;
                TxtUbicacion.Visible = true;
                TxtUbicacion.Clear();
            }
            else
            {
                label21.Visible = false;
                label22.Visible = false;
                label23.Visible = false;
                TxtTipEsc.Visible = false;
                DtpEsc.Visible = false;
                TxtUbicacion.Visible = false;
               

            }
        }

        private void VeriContGar()
        {
            if(TxtUbicacion.Text=="")TxtUbicacion.Text = "N/E";
            if (TxtAut.Text == "") TxtAut.Text = "N/E";
            if (TxtTipEsc.Text == "") TxtTipEsc.Text = "N/E";
        }
    }
}


