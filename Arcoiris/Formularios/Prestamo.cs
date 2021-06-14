using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Humanizer;

namespace Arcoiris.Formularios
{
    public partial class Prestamo : Form
    {
        
        decimal pagof =0;
        Clases.Solicitud soli = new Clases.Solicitud();
        Clases.Credito cre = new Clases.Credito();
        Clases.Cliente cli = new Clases.Cliente();
        Clases.Pago pag = new Clases.Pago();
        Clases.CajaOpe caj = new Clases.CajaOpe();
        Reportes.LlenarReport repo = new Reportes.LlenarReport();
     
        
        public Prestamo()
        {
            InitializeComponent();
        }

        private void CboCliNom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboCliNom.Items.Count > 0)
            {
                //  listacre();
            }
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            DtpPago.Value = DateTime.Now;
            if (ChkCancelado.Checked == false)
            { listacre(); }
            else
            {cancel();
               }
            
        }


        #region "Listar Creditos"
        //Listar crditos pagina 1
        private void Prestamo_Load(object sender, EventArgs e)
        {
            if (Form1.Nivel =="1" || Form1.Nivel=="2")
            {
                BtnEliminar.Enabled = true;
                BtnEliminarCre.Visible = true;
            }
            else {
                BtnEliminar.Enabled = false;
                BtnEliminarCre.Visible = false;
            }
            Tab2.Parent = null;
            listacli();
        }
        private void listacre()
        {
            int total;
            DataTable datos = new DataTable();
            string valor;
            if (CboCliNom.Text  =="")
            { 
                valor = "-1";
            }
            else
            {
                valor = CboCliNom.SelectedValue.ToString();
            }
            datos = cre.creditos_act(valor);
            total = datos.Rows.Count;
            CboPresta.Items.Clear();
            int c1;
            if (total > 0)
            {
                CboPresta.Enabled = true;
                CboPresta.Items.Clear();
                for (c1 = 0; c1 <= total - 1; c1++)
                {
                    CboPresta.Items.Add(datos.Rows[c1][0]);
                }
            }
            else
            {
                CboPresta.Items.Clear();
             //   CboPresta.Enabled = false;
            }
        }

        private void cancel()
        {
            DataTable dat = new DataTable();
            dat=cre.cancel(CboCliNom.SelectedValue.ToString ());
            int cont, total = dat.Rows.Count;
            CboPresta.Items.Clear();
            for (cont = 1; cont <= total; cont++)
            {
                CboPresta.Items.Add(dat.Rows[cont - 1][0]);

            }
        }

        //listar creditos pagina 2, registro de pagos
        private void DatosCre()
        {
            DataTable datos = new DataTable();
            int atras = Convert.ToInt32(cre.dias_atraso(CboPresta.Text, DtpPago.Value.ToString("yyyy/MM/dd")));
         
           //TxtInteres.Text = inteori.ToString();
            datos = cre.cantcre(CboPresta.Text,DtpPago.Value.ToString ());
            TxtMonto.Text = datos.Rows[0][0].ToString();
            decimal saldocap = Convert.ToDecimal(datos.Rows[0][1].ToString());
            decimal inte = Convert.ToDecimal(TxtInteres.Text );
            decimal monto = Convert.ToDecimal (TxtMonto.Text);
            decimal interes = Convert.ToDecimal (TxtInteres.Text);
            decimal interestemp=0;
            TxtMonto.Text = TxtMonto.Text;
            TxtSaldo.Text = Convert.ToString (saldocap);
            TxtSaldInt.Text = datos.Rows[0][5].ToString();
            TxtVenc.Text = datos.Rows[0][2].ToString();
            TxtTipo.Text = datos.Rows[0][3].ToString();
           // TxtAtraso.Text = cre.dias_atraso(CboPresta.Text,DtpPago .Value.ToString ("yyyy/MM/dd"));
           if(Convert.ToDecimal (TxtSaldInt.Text )>0)
            { interestemp = Convert.ToDecimal(TxtSaldInt.Text) ; 
            }
            TxtTotalTod.Text = Convert.ToString (Convert.ToDecimal (TxtSaldo .Text ) + interestemp);
            TxtFechConc .Text = datos.Rows[0][6].ToString();
            TxtTasa.Text = datos.Rows[0][7].ToString() + "%";
            TxtPlazo.Text = (datos.Rows[0][8].ToString());
            if (TxtTipo.Text == "1")
            {
                TxtTipo.Text  = "Diario";
                int total = cre.diasnopag(CboPresta.Text, DtpPago.Value.ToString("yyyy/MM/dd"), datos.Rows[0][6].ToString());
                TxtAtraso.Text = total .ToString () + " Día(s)";
            }
            else if(TxtTipo.Text == "2")
                    {
                TxtTipo.Text = "Diario-Interes";
                int total = cre.diasnopag(CboPresta.Text, DtpPago.Value.ToString("yyyy/MM/dd"), datos.Rows[0][6].ToString());
                TxtAtraso.Text = total.ToString() + " Día(s)";
            }
            else if (TxtTipo.Text == "3")
            {
                TxtTipo.Text = "Mesual-Fijo";
                int total=cre.diasnopag(CboPresta.Text, DtpPago.Value.ToString("yyyy/MM/dd"), datos.Rows[0][6].ToString());
                TxtAtraso.Text = total+" Día(s)";
            }
            else if (TxtTipo.Text == "4")
            {
                TxtTipo.Text = "Mesual-SobreSaldo";
                int total = cre.diasnopag(CboPresta.Text, DtpPago.Value.ToString("yyyy/MM/dd"), datos.Rows[0][6].ToString());
                TxtAtraso.Text = total + " Día(s)";
            }

            DataTable aldia = new DataTable();
            aldia = cre.saldosdias(CboPresta.Text, DtpPago.Value.ToString("yyyy/MM/dd"));
            TxtCapital.Text = aldia.Rows[0][0].ToString();
           TxtInteres.Text = aldia.Rows[0][1].ToString();
            decimal intere=0;
            if (Convert.ToDecimal(aldia.Rows[0][1]) > 0) intere = Convert.ToDecimal(aldia.Rows[0][1]);
            decimal capi=0;
            if (Convert.ToDecimal(aldia.Rows[0][0]) > 0) capi = Convert.ToDecimal(aldia.Rows[0][0]);

            TxtCuotaD.Text = (capi+intere).ToString ();
            }

        private void Dcre()
        {
            DataTable datos = new DataTable();
            datos = cre.verfecha(CboPresta.Text);
            TxtMonto.Text = datos.Rows[0][4].ToString(); 
            TxtSaldo.Text = "0";
            TxtSaldInt.Text = "0";
            TxtSaldo.Text = "0";
            TxtTotalTod.Text = "0";
            TxtAtraso.Text = "Cancelado";
           
            TxtPlazo.Text = datos.Rows[0][0].ToString();
            TxtTasa.Text = datos.Rows[0][1].ToString() + "%";
            TxtFechConc.Text = datos.Rows[0][2].ToString();
            TxtVenc.Text = datos.Rows[0][3].ToString();
            
            

        }
        #endregion
        #region "Listado y llenado de cajas"
        //Lista clientes para pago de credito
        private void listacli()
        {
            DataTable listadocli = new DataTable();
            listadocli = cli.Buscar_nom_cli();
            CboCliNom.DataSource = listadocli;
            CboCliNom.DisplayMember = "Nombre";
            CboCliNom.ValueMember = "Codigo_Cli";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach(DataRow row in listadocli.Rows)
           {
                coleccion.Add(row["Nombre"].ToString ());

            }
            CboCliNom.AutoCompleteCustomSource  = coleccion;
            CboCliNom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboCliNom.AutoCompleteSource = AutoCompleteSource.CustomSource;



        }
        private void CboPresta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboPresta.Text != "" && ChkCancelado.Checked == false)
            {
                BtnPago.Enabled = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                TxtEfectivo.Enabled = true;
                llenadocajas();
                DatosCre();
                activaDia();
                //  calculo();
            }
            else if (CboPresta.Text != "" && ChkCancelado.Checked == true)
            {
                limpiar();
                BtnPago.Enabled = false;
                TxtEfectivo.Enabled = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                Dcre();

            }



        }

        private void activaDia()
        {
            decimal interesc, interesd;
            interesc = decimal.Parse(TxtIntD.Text);
            interesd = decimal.Parse(TxtInteres.Text);
            if (interesc >= interesd)
            {
                BtnAldia.Enabled = false;
            }
            else
            {
                BtnAldia.Enabled = true;
            }


        }
        private void llenadocajas()
        {
            DataTable datos = new DataTable();
            datos = cre.datoscre(CboPresta.Text,DtpPago .Value.ToString ("yyyy/MM/dd") );
            TxtInteres.Text = datos.Rows[0][0].ToString();
            TxtCuotaD.Text = datos.Rows[0][2].ToString();
            pagof = Convert.ToDecimal(datos.Rows[0][2].ToString());

            TxtMora.Text = "0";
            TxtCapD .Text = datos.Rows[0][4].ToString();
           TxtIntD .Text = datos.Rows[0][5].ToString();
            TxtEfectivo.Text = "";
            decimal cuotaN;
            decimal CapN = Convert.ToDecimal(datos.Rows[0][4].ToString());
            decimal IntM = Convert.ToDecimal(datos.Rows[0][5].ToString());
            cuotaN = CapN + IntM;
            TxtCuota.Text  = cuotaN.ToString();

            if (datos.Rows[0][3].ToString().Equals("Terminado"))
            {
               
                if (CboPresta.Items.Count <= 1)
                {
                    CboPresta.Enabled = false;
                }
                else
                {
                    CboPresta.Items.Remove(CboPresta.SelectedIndex);
                }
                MessageBox.Show("Limpiando...");
                TxtInteres.Clear();
                TxtCapital.Clear();
                TxtCuota.Clear();
            }
            else
            {
                //TxtInteres.Text = datos.Rows[0][0].ToString();
                TxtCapital.Text = datos.Rows[0][1].ToString();
            }

        }

        private void llenarGrid()
        {
            DataTable datos = new DataTable();
            datos = pag.Pagoscre(CboPresta.Text);
            DGVPpago.DataSource = datos;
            DGVPpago.Refresh();
        }

        private void calculo()
        {
            decimal Pago;
            decimal efectivo;
            decimal cambio;
            Pago = Convert.ToDecimal(TxtCuota.Text);
            if (TxtEfectivo.Text == "")
            {
                efectivo = 0;
            }
            else
            {
                efectivo = Convert.ToDecimal(TxtEfectivo.Text);
            }
           // TxtTotal.Text = "Q. " + Pago;
            cambio = efectivo - Pago;
            if (cambio < 0)
            {
                cambio = 0;
            }
            TxtCambio.Text = "Q. "+cambio.ToString();

        }

        #endregion
        #region "Manejo cantidades"
       

        private void TxtMora_TextChanged(object sender, EventArgs e)
        {
            if (TxtInteres.Text != "" && TxtCapital.Text != "" && TxtMora.Text != "")
            {
                decimal valor1;
                decimal valor2;
                decimal valor3;
                bool numero1 = decimal.TryParse(TxtInteres.Text, out valor1);
                bool numero2 = decimal.TryParse(TxtCapital.Text, out valor2);
                bool numero3 = decimal.TryParse(TxtMora.Text, out valor3);
                if (numero1 && numero2 && numero3)
                {
                    //  TxtInteres.Text = Convert.ToString(pagof - valor2);
                    TxtCuota.Text = Convert.ToString(valor1 + valor2 + valor3);

                }
            }
        }
        #endregion
        #region "Pagos"
        private void ingresocaja()
        {
            string deposito = "";
            if (ChkDepo.Checked) deposito = ", según deposito " + TxtDepo .Text ;

            string id = Convert.ToString(caj.id_pago() + 1);
            string operacion = "Ingreso";
            string monto = TxtCuota.Text;
            string descripcion = "Pago de credito" + deposito;
            string fecha = DtpPago.Value.ToString("yyyy/MM/dd");
            string estado = "Activo";
            string usuario = Form1.Cod_U;
            string credito= CboPresta.Text, cliente= CboCliNom.Text;

            String[] datos = { id, operacion, monto, descripcion, fecha, estado, usuario,credito,cliente };
            if (caj.ingreope(datos))
            {
                MessageBox.Show("Pago registrado");
            }
            else
            {
                MessageBox.Show("Error de pago");
            }

        }
        private void BtnPago_Click(object sender, EventArgs e)
        {
            if (TxtEfectivo.Text == "") TxtEfectivo.Text = TxtCuota.Text;
            decimal interes= decimal.Parse(TxtIntD.Text);
            decimal efectivo=decimal .Parse(TxtEfectivo.Text);
            decimal Mora = decimal.Parse (TxtMora.Text);

            if (efectivo < interes)
            { TxtIntD.Text = efectivo.ToString();
                TxtEfectivo.Text = efectivo.ToString ();
            }
            TxtIntD.Enabled = false;
            TxtCapD.Enabled = false;
            string intpag, cappag,morapag, totpag;
            intpag =TxtIntD.Text;
            cappag = TxtCapD.Text;
            if (TxtMora.Text != "")
            { morapag = TxtMora.Text; }
            else
            {
                morapag = "0";
            }
            if (decimal.Parse(TxtEfectivo.Text)<(decimal.Parse(morapag)+decimal.Parse(intpag)))
            {
                intpag= (decimal.Parse(TxtEfectivo.Text) - decimal.Parse(morapag)).ToString();
                TxtIntD.Text = intpag;
            }
            totpag = (decimal.Parse(cappag)+decimal.Parse(intpag)+decimal.Parse(morapag)).ToString();
            if (MessageBox.Show("Se realizará el siguiente pago: \n"+"Capital: Q." + cappag + "\nInteres: Q." + intpag + "\nMora: Q." + morapag + "\nTotal: Q."+totpag + "\n¿Desea proceder con el pago?","¿Realizar pago?",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                Pago();
                ingresocaja();
                imprimir_bol();
                TxtCapD.Enabled = false;
                TxtIntD.Enabled = false;
                TxtEfectivo.Text = "0";
                limpiar();
                CboPresta.Items.Clear();
            }
            
            /*
            if (CboPresta.Text != "")
            {
                llenadocajas();
            }*/
        }

        private void Pago()
        {
            string credito = CboPresta.Text;
            string interes = TxtIntD.Text;
            string capital = (TxtCapD .Text);
            string pago = TxtCuota .Text;
            string fecha = DtpPago.Value.ToString ();
            string mora = TxtMora.Text;
            string saldocap = TxtSaldo.Text;
            string saldoint = TxtSaldInt.Text;
            string[] datos = {credito,interes,capital,pago,fecha,mora,saldocap,saldoint };
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
        private void imprimir_bol()
        {
            Reportes.PagoDesc datosP = new Reportes.PagoDesc();
            datosP.boleta = pag .idpago (CboPresta .Text );
            string dir = cli.Dir_cli(pag.idpago(CboPresta.Text).ToString ());
            datosP.credito = Convert.ToInt32(CboPresta .Text );
            datosP.cliente = CboCliNom.Text;
            datosP.Fecha = DateTime.Now;
            datosP.direccion = dir;
            datosP.capital = Convert.ToDecimal(TxtCapD .Text );
            datosP.interes= Convert.ToDecimal(TxtIntD.Text);
            datosP.mora= Convert.ToDecimal(TxtMora.Text);
            datosP.total = Convert.ToDecimal(TxtCuota.Text);
            decimal Saldor, valor, saldoint=0,saldot,restacent;
            Saldor = Convert.ToDecimal(TxtSaldo.Text) - Convert.ToDecimal(TxtCapD.Text);
            datosP.saldo =Saldor ;
            valor = Convert.ToDecimal(TxtCuota.Text);
            if (decimal.Parse(TxtSaldInt.Text) - decimal.Parse(TxtIntD.Text) > 0) saldoint = decimal.Parse(TxtSaldInt.Text) - decimal.Parse(TxtIntD.Text);
            datosP.saldoi = saldoint;
            saldot = Saldor + saldoint;
            datosP.totalD = saldot;
            int total, cents;
            cents = Convert.ToInt32((valor % 1) * 100);
            total= int.Parse(Math.Truncate(valor).ToString());
           // total = Convert.ToInt32(valor - (cents / 100));
            string letras;
            letras = total.ToWords() + " con " + cents.ToWords();
            if (cents <= 0) letras = total.ToWords() + " exactos";
            datosP.letras = letras;
            Reportes.BoletaPag boleta = new Reportes.BoletaPag();
            boleta.descripcion.Add(datosP);
            boleta.Show();
        }

        private void Re_imprimir()
        {
            
            Reportes.PagoDesc datosP = new Reportes.PagoDesc();
            int indice;
            indice = DGVPpago.CurrentRow.Index;
            string dir = cli.Dir_cli(DGVPpago.Rows[indice].Cells[0].Value.ToString ());
            datosP.boleta = Convert.ToInt32 (DGVPpago.Rows[indice].Cells[0].Value);
            datosP.credito = Convert.ToInt32(CboPresta.Text);
            datosP.cliente = CboCliNom.Text;
            datosP.direccion = dir;
            datosP.Fecha = Convert.ToDateTime(DGVPpago.Rows[indice].Cells[1].Value);
            datosP.capital = Convert.ToDecimal(DGVPpago.Rows[indice].Cells[2].Value);
            datosP.interes = Convert.ToDecimal(DGVPpago.Rows[indice].Cells[3].Value);
            datosP.mora = Convert.ToDecimal(DGVPpago.Rows[indice].Cells[4].Value);
            datosP.total = Convert.ToDecimal(DGVPpago.Rows[indice].Cells[5].Value);
            decimal Saldor, valor, saldoint = 0, saldot;
            Saldor = Convert.ToDecimal(TxtSaldo.Text);
            datosP.saldo = Saldor;
            valor = Convert.ToDecimal(DGVPpago.Rows[indice].Cells[5].Value);

            if (decimal.Parse(TxtSaldInt.Text)>0) saldoint = decimal.Parse (TxtSaldInt.Text);
            datosP.saldoi = saldoint;
            saldot = Saldor + saldoint;
            datosP.totalD = saldot;
            int total, cents;
            cents = Convert.ToInt32((valor % 1)*100);
            total = int.Parse(Math.Truncate(valor).ToString());
           // total = Convert.ToInt32(valor - (cents / 100));
            string letras;
            letras = total.ToWords() + " con " + cents.ToWords();
            if (cents<=0) letras = total.ToWords() + " exactos";
            datosP.letras = letras;
            Reportes.BoletaPag boleta = new Reportes.BoletaPag();
            boleta.descripcion.Add(datosP);
            boleta.Show();
        }

        private void limpiar()
        {
            TxtInteres.Clear();
            TxtCapital.Clear();
            TxtMora.Clear();
            TxtCuota.Clear();
            TxtMonto.Clear();
            TxtSaldo.Clear();
            TxtVenc.Clear();
            TxtTipo.Clear();
            TxtAtraso.Clear();
            TxtEfectivo.Clear();
            TxtTotal.Clear();
            TxtCambio.Clear();
            TxtCapD.Clear();
            TxtIntD.Clear();
            TxtCuotaD.Clear();
            TxtMonto.Enabled = false;
            TxtInteres.Enabled = false;

        }
        #endregion

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            BtnEliminar.Enabled = false;
            if (DGVPpago.RowCount >= 1)
            {
                int indice;
                indice = DGVPpago.CurrentRow.Index;
                string codigoP;
                codigoP = DGVPpago.Rows[indice].Cells[0].Value .ToString();
                string cap;
                string inter;
                cap = DGVPpago.Rows[indice].Cells[2].Value .ToString();
                inter = DGVPpago.Rows[indice].Cells[3].Value .ToString();

                if (pag.estadopago(codigoP,CboPresta .Text,cap,inter))
                {
                    MessageBox.Show("El pago ha sido cancelado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenarGrid();
                }
                else
                {
                    MessageBox.Show("El pago no ha podido ser cancelado", "Problema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                }
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if ( e.KeyCode ==Keys.F12 )
            {
                if (Form1.Cod_U == "1" || Form1.Cod_U == "2")
                {
                    MessageBox.Show("Elementos activados", "Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnEliminar.Enabled = true;
                    //TxtInteres.Enabled = true;
                    //TxtCapital.Enabled = true;
                    TxtIntD.Enabled = true;
                    //TxtCapD.Enabled = true;
                    DtpPago.Enabled = true;
                }
                else
                {
                    Autopass pru = new Autopass();
                    pru.verificar += new Autopass.permiso(activar);
                    pru.ShowDialog();
                 
                }
            }
        }

        public void activar(int nivel)
        {
            if (nivel == 1 || nivel == 2)
            {
                BtnEliminar.Enabled = true;
                TxtIntD.Enabled = true;
                DtpPago.Enabled = true;
                //TxtCapital.Enabled = true;
            }
          

        }
     
        private void TxtEfectivo_TextChanged(object sender, EventArgs e)
        {
            if (TxtEfectivo.Text != "" && TxtCapD .Text!="" )
            {
                if (decimal.Parse(TxtIntD.Text) < 0) TxtIntD.Text = "0";


                decimal efectivo=Convert.ToDecimal(TxtEfectivo.Text) ;
                decimal Capital=Convert.ToDecimal(TxtCapD.Text);
                decimal interes=Convert.ToDecimal(TxtIntD.Text);
                decimal interesDeu = Convert.ToDecimal(TxtInteres.Text);
                if (interesDeu >= interes)
                {
                    interes = interesDeu;
                    TxtIntD.Text = interes.ToString();
                }
                decimal mora= Convert.ToDecimal(TxtMora.Text);
                decimal residuo= efectivo -interes;
                decimal cuota = Convert.ToDecimal(TxtCuota.Text);
                
                residuo -= mora;
                if (residuo < 0)
                {
                    residuo = 0;
                }
                TxtCapD.Text  = residuo.ToString() ;
                TxtCuota.Text = TxtEfectivo.Text;
                if (Convert.ToDecimal(TxtCapD.Text) > Convert.ToDecimal(TxtSaldo.Text))
                {
                    MessageBox.Show("El monto de capital es mayor a la deuda, porfavor ingrese de nuevo");
                    TxtCapD.Text ="0";
                    TxtIntD.Text = "0";
                    TxtCuota.Text = "0";
                }
            }
      
            //calculo();
        }

        private void DtpPago_ValueChanged(object sender, EventArgs e)
        {
            if (CboPresta.SelectedIndex >=0)
            {
                llenadocajas();
                DatosCre();
             //   calculo();
            }
        }

        private void DtpPago_Enter(object sender, EventArgs e)
        {
           if (CboPresta.SelectedIndex >= 0)
            {
                llenadocajas();
                DatosCre();
                calculo();
            }
        }

        private void BtnAldia_Click(object sender, EventArgs e)
        {
            if (TxtInteres.Text != "")
            {
                TxtIntD.Text = TxtInteres.Text;
            }
            else
            {
                TxtIntD.Text = "0";            }
            if (TxtCuotaD.Text != "")
            {
                TxtCuota.Text = TxtCuotaD.Text;
                TxtEfectivo.Text= TxtCuotaD.Text;
            }
            else

            {
                TxtCuota.Text = "0";
            }

            if (TxtCapital.Text != "")
            {
                TxtCapD.Text = TxtCapital.Text;
            }
            else
            {
                TxtCapD.Text = "0";
            }
        }

        private void TxtTotal_TextChanged(object sender, EventArgs e)
        {
            if (TxtTotal.Text != "")
            {
                if (TxtEfectivo.Text == "")
                {
                    TxtEfectivo.Text = "0";
                }
                decimal pago = Convert.ToDecimal(TxtEfectivo.Text);
                decimal Dinero = Convert.ToDecimal(TxtTotal .Text);
                decimal vuelto = 0;
                vuelto = Dinero - pago;
                TxtCambio.Text = "Q. " + vuelto.ToString();
            }
            if (TxtTotal.Text == "")
            {
                TxtCambio.Text = "Q. 0.00";
            }
        }

        private void BtnEliminarCre_Click(object sender, EventArgs e)
        {
            if (CboPresta.Text != "")
            {
                DialogResult resp;
                resp = MessageBox.Show("¿Desea eliminar el credito definitivamente?","¿Eliminar?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (resp==DialogResult.Yes)
                {
                    eliminar_credito(CboPresta.Text);
                }
            }
        }

        private void eliminar_credito(string credi)
        {
            if (pag.cancelarPagoall(credi))
            {
                if (cre.cancelar_cre2(credi))
                {
                    MessageBox.Show("Credito cancelado","Cancelado",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error al cancelar credito", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Error al cancelar pagos", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnListPago_Click(object sender, EventArgs e)
        {
            if (CboPresta.Text != "")
            {
                Tab2.Parent = tabControl1;
                tabControl1.SelectedIndex = 1;
                //listacre2(CboPresta.Text);
                llenarGrid();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                Tab2.Parent = null;
            }
        }

        private void BtnImpPago_Click(object sender, EventArgs e)
        {
            imprimir();
        }
        private void imprimir()
        {
            Reportes.EstadoEnc encabe = new Reportes.EstadoEnc();
            string nombre;
            string direccion;
            string tasa;
            string plazo;
            string conce;
            string venci;
            string monto;
            string saldocap;
            string saldoint;
            string saldoT;
            DataTable datos = new DataTable();
            datos = cre.nombres_cre(Convert.ToInt32(CboPresta.Text));

            nombre = CboCliNom.Text;
            direccion = datos.Rows[0][6].ToString ();
            tasa = TxtTasa.Text;
            plazo = datos.Rows[0][5].ToString();
            conce = TxtFechConc.Text;
            venci = TxtVenc.Text;
            monto = TxtMonto.Text;
            saldocap = TxtSaldo.Text;
            saldoint = TxtSaldInt.Text;
            saldoT = TxtTotalTod.Text;
            encabe.cliente = nombre;
            encabe.direccion = direccion;
            encabe.tasa = tasa;
            encabe.plazo = plazo;
            encabe.conc = conce;
            encabe.vence = venci;
            encabe.monto = Convert.ToDecimal(monto);
            encabe.saldocap = Convert.ToDecimal (saldocap);
            encabe.saldoint = Convert.ToDecimal(saldoint);
            encabe.saldocance = Convert.ToDecimal(saldoT);

            int totalp = DGVPpago.Rows.Count;
            int cont;
           

            for (cont=0;cont<=totalp-1;cont++)
            {
                Reportes.EstadoDet detalle = new Reportes.EstadoDet();
                detalle.fechap = Convert.ToDateTime(DGVPpago.Rows[cont].Cells[1].Value);
                detalle.capital = Convert.ToDecimal(DGVPpago.Rows[cont].Cells[2].Value); ;
                detalle.interes = Convert.ToDecimal(DGVPpago.Rows[cont].Cells[3].Value);
                detalle.mora = Convert.ToDecimal(DGVPpago.Rows[cont].Cells[4].Value);
                detalle.total = Convert.ToDecimal(DGVPpago.Rows[cont].Cells[5].Value);
                encabe.Detalle.Add(detalle);
            }

            Reportes.CuentayPago cuenta = new Reportes.CuentayPago();
            cuenta.portada.Add(encabe);
            cuenta.detall=encabe .Detalle;
            cuenta.Show();

            
            

        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            DataTable datostipo = new DataTable();
            datostipo = cre.cantcre(CboPresta.Text, DateTime.Now.ToString());
            imprimir_tabla(CboPresta.Text, datostipo.Rows[0][3].ToString());
        }

        private void imprimir_tabla(string credi, string tipo)
        {
            int cred;
            cred = Convert.ToInt32(credi);
            repo.llenar_rep(cred, tipo);

        }

        private void TxtMora_TextChanged_1(object sender, EventArgs e)
        {
            if (TxtMora.Text == "") TxtMora.Text = "0";
            TxtEfectivo.Clear();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            TxtIntD.Text ="0";
            if (Convert.ToDecimal(TxtSaldInt.Text)>0) TxtIntD.Text = TxtSaldInt.Text;
            TxtCapD.Text = TxtSaldo.Text;
            TxtCuota.Text = TxtTotalTod.Text;
            TxtEfectivo.Text= TxtTotalTod.Text;

        }

        private void BtnBoleta_Click(object sender, EventArgs e)
        {
            Re_imprimir();
        }

        private void ChkDepo_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkDepo.Checked)
            {
                TxtDepo.Enabled = true;
                TxtDepo.Focus();
            }
            else
            { TxtDepo.Enabled = false;
                TxtDepo.Text = "";
            }
        }
    }
}
