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
using System.Text.RegularExpressions;
using System.Drawing;

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
        Clases.Inversion Inver = new Clases.Inversion();
     
        Reportes.LlenarReport repo = new Reportes.LlenarReport();
        DataTable AllCli = new DataTable();
        List<Clases.Modelos.DeparamentoModel> AllDepas;
        List<Clases.Modelos.MunicipioModel> AllMunis;
        private List<Formularios.SubClases.Cuenta> listaCuentas = new List<Formularios.SubClases.Cuenta>();
        DataTable AllCliInv = new DataTable();
        Reportes.Contratos.ContratoDatos datosgaran = new Reportes.Contratos.ContratoDatos();
        int cantigarant = 0;
        int Contratotip = 0;
        List<string> DetaGaran = new List<string>();
        private int cod_credi;
        private int codiAsesor;
        private decimal salantes = 0;
        string contrato = "0";
        decimal interescalc = 1;


        public Solicitud()
        {
            InitializeComponent();

        }

        private void listCliFia()
        {
            DataTable listadocli = new DataTable();
            listadocli = cli.AllCli();
            CboFiadNom.DataSource = listadocli;
            AllCli = listadocli;
            CboFiadNom.DisplayMember = "Nombre";
            CboFiadNom.ValueMember = "Codigo_Cli";
            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in listadocli.Rows)
            {
                coleccion.Add(row["Nombre"].ToString());
            }
            CboFiadNom.AutoCompleteCustomSource = coleccion;
            CboFiadNom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboFiadNom.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void Solicitud_Load(object sender, EventArgs e)
        {

            Tab2.Hide();
            Tab1.Hide();
            Clases.Estilos.StyleForm(this);
            // Configurar el DrawMode
            TCTSoli.DrawMode = TabDrawMode.OwnerDrawFixed;
            TCTSoli.DrawItem += TCTSoli_DrawItem;
            // Ajustar el tamaño de las pestañas
            AjustarTamanioPestaniasSegunTexto();
            if (Form1.Nivel.Equals("1") || Form1.Nivel.Equals("2") || Form1.Nivel.Equals("5"))
            {
                Tab2.Parent = tabControl1;
                Tab3.Parent = tabControl1;
            }
            else if (Form1.Nivel.Equals("4"))
            {
               codiAsesor = aseso.UsuAseso(Form1.Cod_U);
                Tab2.Parent = tabControl1;
                Tab3.Parent = null;
                BtnCancelar.Enabled = false;
                BntCambiar.Enabled = false;
             
                CboAsesor.Enabled = false;
            }
            else
            {
                Tab2.Parent = null;
                Tab3.Parent = null;
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
            AllCliInv = cli.AllCli();
            DataTable datos2 = datoscli.Copy();
            DataTable Propis = datoscli.Copy();
            CboCliente.DataSource = datoscli;
            CboCliente.DisplayMember = "Nombre";
            CboCliente.ValueMember = "Codigo_Cli";
            CboCliInv.DataSource = datoscli;
            CboCliInv.DisplayMember = "Nombre";
            CboCliInv.ValueMember = "Codigo_Cli";
            CboBenef.DataSource = datos2;
            CboBenef.DisplayMember = "Nombre";
            CboBenef.ValueMember = "Codigo_Cli";
            CboPropi.DataSource = Propis;
            CboPropi.DisplayMember = "Nombre";
            CboPropi.ValueMember = "Codigo_Cli";

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            AutoCompleteStringCollection coleccion2 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection colecTutor = new AutoCompleteStringCollection();
            AutoCompleteStringCollection colecpropi = new AutoCompleteStringCollection();
            

            foreach (DataRow row in datoscli.Rows)
            {
                coleccion.Add(row["Nombre"].ToString());
                coleccion2.Add(row["Nombre"].ToString());
                colecTutor.Add(row["Nombre"].ToString());
                colecpropi.Add(row["Nombre"].ToString());

            }
            CboCliente.AutoCompleteCustomSource = coleccion;
            CboCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboCliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CboCliInv.AutoCompleteCustomSource = coleccion;
            CboCliInv.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboCliInv.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CboBenef.AutoCompleteCustomSource = coleccion2;
            CboBenef.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboBenef.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CboTutor.AutoCompleteCustomSource = colecTutor;
            CboTutor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboTutor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CboPropi.AutoCompleteCustomSource = colecpropi;
            CboPropi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboPropi.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CboTutor.DataSource = AllCliInv;
            CboTutor.DisplayMember = "Nombre";
            CboTutor.ValueMember = "Codigo_cli";
            


            //Agregar cliente a inversiones



            //Agregar datos de asesores
            DataTable datosas = new DataTable();
            datosas = aseso.busca_asesor_nom();
            CboAsesor.DataSource = datosas;
            CboAsesor.DisplayMember = "Nombre";
            CboAsesor.ValueMember = "Codigo";
            CboAsesorInv.DataSource = datosas;
            CboAsesorInv.DisplayMember = "Nombre";
            CboAsesorInv.ValueMember = "Codigo";
            foreach (DataRow row in datosas.Rows)
            {
                coleccion.Add(row["Nombre"].ToString());

            }
            CboAsesor.AutoCompleteCustomSource = coleccion;
            CboAsesor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboAsesor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            

            //Lista de fiadores
            listCliFia();
            if (Form1.Nivel.Equals("4"))
            {
                CboAsesor.SelectedValue = codiAsesor;
            }

            LblFecha.Text = "Fecha de solicitud: " + DateTime.Now.ToString("yyyy/MM/dd");
            TxtNoSol.Text = $"{sol.id_solicitud()}";
            CboTipo.Items.Add("Diario");
            CboTipo.Items.Add("Diario - Intereses");
            CboTipo.Items.Add("Semanal");
            CboTipo.Items.Add("Quincenal");
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
            //  TxtGaran.Clear();
            TxtMonto.Clear();
            TxtNoSol.Text = sol.id_solicitud().ToString();

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            añadir();

        }
        private void añadir()
        {
            int soligen = sol.id_solicitud();
            TxtNoSol.Text = $"{soligen}";
            datosgaran.NomFiador = CboFiadNom.Text;
            string asesor = "";
            string cliente = "";
            string fecha = DateTime.Now.ToString("yyyy/MM/dd");
            string fechaf = fecha.Replace("Fecha de solicitud: ", "");
            string creditoaca = Txtfam.Text;
            // VeriContGar();
            int FilasFiad = DgvFiadorLst.RowCount;
            int FilasGara = DgvGaranLSt.RowCount;
            string interesIng;

            // Validamos si el contenido de TxtInt se puede tratar como un número
            if (double.TryParse(TxtInt.Text, out _))
            {
                // Si es numérico, procedemos con la asignación
                interesIng = TxtInt.Text;
            }
            else
            {
                // Si no es numérico, podrías asignar un valor por defecto o avisar al usuario
                MessageBox.Show("Por favor, ingrese un valor numérico válido en el interés.");
                return;
            }

            string Valu = "0", DetaGarantD = datosgaran.GarantDeudor;
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
            else if (CboTipo.Text == "Semanal")
            {
                tipo = "5";
                plazo = Convert.ToString(NupPlazo.Value);
            }
            else if (CboTipo.Text == "Quincenal")
            {
                tipo = "6";
                plazo = Convert.ToString(NupPlazo.Value);
            }
            else
            {
                tipo = "0";
                plazo = "0";
            }
            string razon = CboRazon.Text;
            string sugerido = TxtMontoSug.Text;

            string[] datos = { TxtNoSol.Text, TxtConcept.Text, TxtMonto.Text, fechaf, "Espera", plazo, TxtMontoSug.Text, asesor, cliente, tipo, Contratotip.ToString(), Valu, Txtfam.Text, datosgaran.GarantDeudor, datosgaran.NomFiador, datosgaran.MuniFiador, datosgaran.DeparFiador, datosgaran.ProfFiador, datosgaran.EdadFiador, datosgaran.EstCivFiador, datosgaran.GarantFiador, datosgaran.CuiFiador, datosgaran.FiadorDomi,creditoaca,razon,sugerido,interesIng };
            string[] datos2 = { TxtNoSol.Text, CboFiadNom.SelectedValue.ToString() };
            if (sol.hayasesor(asesor))
            {
                //int FilIngM = DgvIngMen.RowCount;
                //int FilEgrM = DgvEngMen.RowCount;
                //int ListaAct = LstCuentas.Items.Count;
                //int ListaPas = LstPasiv.Items.Count;
                //int CantIngre = DgvIngMen.RowCount;
                //int CantEgre = DgvIngMen.RowCount;


                if (FilasGara <= 0 && !ConfirmarContinuar("No se ingresara ninguna garantia\n¿Desea continuar?"))
                {
                    return;
                }

                if (FilasFiad <= 0 && !ConfirmarContinuar("No se ingresara ningun fiador\n¿Desea continuar?"))
                {
                    return;
                }
                if (verificarEstCuenta() != true)
                {
                    DialogResult resp = MessageBox.Show("No se ha ingresado valores en ingresos o egresos mensuales, desea continuar sin estos valores?","sin ingresos o egresos",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(resp==DialogResult.No)
                    return;
                }

                if (sol.agregar_soli(datos))
                {
                    //bool addfiad = false;
                    //if (CboTipPresta.SelectedIndex == 1)
                    bool respo1 = IngresoFiador(), respo2 =  IngresoGarant(), respo3=soliPt2();
                    // Escenario 1: TODO EXITOSO
                    if (respo1 == true && respo2 == true && respo3 == true)
                    {
                        MessageBox.Show("Solicitud ingresada correctamente", "Ingresada",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar();
                    }

                    // Escenario 2: Solo falla soliPt2
                    else if (respo1 == true && respo2 == true && respo3 == false)
                    {
                        MessageBox.Show("Se registro la solicitud pero no fue posible agregar el estado financiero",
                                        "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    // Escenario 3: Solo falla IngresoGarant
                    else if (respo1 == true && respo2 == false && respo3 == true)
                    {
                        MessageBox.Show("Se registro la solicitud pero no fue posible agregar la garantia",
                                       "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    // Escenario 4: Solo falla IngresoFiador
                    else if (respo1 == false && respo2 == true && respo3 == true)
                    {
                        MessageBox.Show("Se registro la solicitud pero no fue posible agregar los datos del fiador",
                                      "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    // Escenario 5: Solo IngresoFiador es exitoso
                    else if (respo1 == true && respo2 == false && respo3 == false)
                    {
                        MessageBox.Show("Se registro la solicitud pero no fue posible agregar garantia y el estado financiero",
                                     "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    // Escenario 6: Solo IngresoGarant es exitoso
                    else if (respo1 == false && respo2 == true && respo3 == false)
                    {
                        MessageBox.Show("Se registro la solicitud pero no fue posible agregar datos del fiador y el estado financiero",
                                        "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    // Escenario 7: Solo soliPt2 es exitoso
                    else if (respo1 == false && respo2 == false && respo3 == true)
                    {
                        MessageBox.Show("Se registro la solicitud pero no fue posible agregar garantia y datos del fiador",
                                         "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    // Escenario 8: TODO FALLA
                    else if (respo1 == false && respo2 == false && respo3 == false)
                    {
                        MessageBox.Show("Se registro la solicitud pero no hubo un inconveniente con los datos de garantia, fiador y estado financiero",
                                           "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Error al ingresar solicitud","Algo salio mal!",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            if (Form1.Nivel.Equals("4"))
            {
                datos = sol.busca_soli_pend_asesor(codiAsesor);
            }
            else
            { datos = sol.busca_soli_pend(); }
            
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
                TxtNomSoli.Text = datos.Rows[0][0].ToString();
                TxtNomAseso.Text = datos.Rows[0][1].ToString();
                TxtConcepto.Text = datos.Rows[0][2].ToString();
                TxtMonto2.Text = datos.Rows[0][3].ToString();
                TxtMontoSug2.Text = datos.Rows[0][5].ToString();
                TxtPlazo.Text = datos.Rows[0][4].ToString();
                TxtGarantia.Text = $"{datos.Rows[0][9]}";
                TxtInteres.Text = $"{datos.Rows[0][10]}";
                LblFechasol.Text = $"{Convert.ToDateTime(datos.Rows[0][6]).ToString("dd/MM/yyyy")}";
                CboTipo2.Items.Clear();
                CboTipo2.Items.Add("Diario");
                CboTipo2.Items.Add("Diario - Intereses");
                CboTipo2.Items.Add("Semanal");
                CboTipo2.Items.Add("Quincenal");
                CboTipo2.Items.Add("Mensual - Cuota Fija");
                CboTipo2.Items.Add("Mensual - Sobre Saldo");

                int tipo = Convert.ToInt32(datos.Rows[0][7].ToString());
                if (tipo == 1)
                {
                    //TxtTipo.Text = "Diario";
                    CboTipo2.SelectedIndex = 0;
                    label14.Text = "Interes";
                }
                else if (tipo == 2)
                {
                    //TxtTipo.Text = "Diario - Intereses";
                    CboTipo2.SelectedIndex = 1;
                    label14.Text = "Interes";
                }
                else if (tipo == 3)
                {
                    //TxtTipo.Text = "Mensual - Cuota Fija"
                    CboTipo2.SelectedIndex = 4;
                    label14.Text = "Interes";
                }
                else if (tipo == 4)
                {
                    //TxtTipo.Text = "Mensual - Sobre Saldo";
                    CboTipo2.SelectedIndex = 5;
                    label14.Text = "Interes";
                }
                else if (tipo == 5)
                {
                    //TxtTipo.Text = "Mensual - Sobre Saldo";
                    CboTipo2.SelectedIndex = 2;
                    label14.Text = "Interes";
                }
                else if (tipo == 6)
                {
                    //TxtTipo.Text = "Mensual - Sobre Saldo";
                    CboTipo2.SelectedIndex = 3;
                    label14.Text = "Interes";
                }
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            SubForms.EditSolicitud Edita = new SubForms.EditSolicitud();
            Edita.IdCli = int.Parse($"{LblCodCli.Text}");
            Edita.IdSol = int.Parse($"{CboSoli.Text}");
            Edita.isDoing += new SubForms.EditSolicitud.edicion(EdicionEnCurso);
            Edita.ShowDialog();
            //desbloquear();
        }



        private void bloquear()
        {
            TxtMonto2.Enabled = false;
            TxtConcepto.Enabled = false;
            TxtGarantia.Enabled = false;
           // TxtPlazo.Enabled = false;
            CboEstado.Enabled = false;
            //TxtInteres.Enabled = false;
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
            decimal saldotemp = 0, gasto = Convert.ToDecimal(TxtGastos.Text);


            decimal montotep = Convert.ToDecimal(TxtMonto2.Text);

            if (LblRef.Text.Equals("1"))
            {
                saldotemp = montotep + montotep - salantes;
            }

            montotep -= saldotemp;
            montotep -= gasto;
            int contid = 1;
            string[] chrRem = new string[] { ")", "(", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-" };
            string cli = TxtNomSoli.Text;
            foreach (var c in chrRem)
            {
                cli = cli.Replace(c, string.Empty);
            }

            //Egreso del monto total
            string id = Convert.ToString(caj.id_pago() + contid);
            string operacion = "Egreso";
            string monto = Convert.ToDecimal(TxtMonto2.Text).ToString();
            string descripcion = "Desembolso";
            string fecha = DtpConc.Value.ToString("yyyy/MM/dd");
            string estado = "Activo";
            string usuario = Form1.Cod_U;
            string credito = cred, cliente = cli;
            string[] datos = { id, operacion, monto, descripcion, fecha, estado, usuario, credito, cliente };

            if (salantes > 0)
            {
                contid++;
            }
            //ingreso de Saldo anterior
            id = Convert.ToString(caj.id_pago() + contid);
            operacion = "Ingreso";
            monto = salantes.ToString();
            descripcion = "Cancelacion de credito anterior";
            fecha = DtpConc.Value.ToString("yyyy/MM/dd");
            estado = "Activo";
            usuario = Form1.Cod_U;
            credito = cod_credi.ToString();
            cliente = TxtNomSoli.Text;
            string[] datos2 = { id, operacion, monto, descripcion, fecha, estado, usuario, credito, cliente };


            if (gasto > 0)
            {
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
                if (gasto > 0)
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
        private string fechaf(string fechac, int dias)
        {
            DateTime Fini = Convert.ToDateTime(fechac);
            DateTime Ffin = Convert.ToDateTime(fechac);//cambiar esta fecha para el final
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
            return Ffin.ToString("yyyy/MM/dd");

        }
        private void cambiar_estado()
        {
            string tipo = "";
            string fecha_conc = DtpConc.Value.ToString("yyyy/MM/dd");
            string fecha_fin = "";
            int dias = 0;
            string solicitud = CboSoli.Text;
            string monto = TxtMonto2.Text;
            string plazo = TxtPlazo.Text;
            string interes = TxtInteres.Text;
            string estado = CboEstado.Text;
            decimal cuotaint = 0, cuotacapital; ;
            if (CboTipo2.SelectedIndex == 0)
            {
                tipo = "1";
                dias = Convert.ToInt32(TxtPlazo.Text);
                fecha_fin = fechaf(fecha_conc, dias);
                label9.Text = "Plazo (Dias)";
            }
            else if (CboTipo2.SelectedIndex == 1)
            {
                tipo = "2";
                dias = Convert.ToInt32(TxtPlazo.Text);
                fecha_fin = fechaf(fecha_conc, dias);
                label9.Text = "Plazo (Dias)";
            }
            else if (CboTipo2.SelectedIndex == 2)
            {
                tipo = "5";
                dias = Convert.ToInt32(TxtPlazo.Text);
                fecha_fin = Convert.ToDateTime(fecha_conc).AddDays(dias * 7).ToString("yyyy/MM/dd");
                label9.Text = "Plazo(Semanas)";
            }
            else if (CboTipo2.SelectedIndex == 3)
            {
                tipo = "6";
                dias = Convert.ToInt32(TxtPlazo.Text);
                fecha_fin = Convert.ToDateTime(fecha_conc).AddDays(dias * 14).ToString("yyyy/MM/dd");
                label9.Text = "Plazo (Quincenas)";
            }
            else if (CboTipo2.SelectedIndex == 4)
            {
                tipo = "3";
                dias = Convert.ToInt32(TxtPlazo.Text);
                fecha_fin = Convert.ToDateTime(fecha_conc).AddMonths(dias).ToString("yyyy/MM/dd");
                label9.Text = "Plazo (Meses)";
            }
            else if (CboTipo2.SelectedIndex == 5)
            {
                tipo = "4";
                dias = Convert.ToInt32(TxtPlazo.Text);
                fecha_fin = Convert.ToDateTime(fecha_conc).AddMonths(dias).ToString("yyyy/MM/dd");
                label9.Text = "Plazo (Meses)";
            }


            DataTable Creact = new DataTable();
            int cod_cli = sol.cod_cliente(CboSoli.Text);
            Creact = cre.creditos_act(Convert.ToString(cod_cli));
            int totalcre;
            totalcre = Creact.Rows.Count;
            string[] datos = new string[11];
            //Comprueba si cancelas creditos anteriores o se crea solamente un nuevo credito
            if (totalcre >= 1 && CboEstado.Text == "Autorizado")
            {
                if (MessageBox.Show("Existe(n) creditos activos de cliente \n¿Desea generar un refinanciamiento? \nSi(Refinanciar Credito)\nNo(Generar credito nuevo)", "Creditos anteriores", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ListCred Lista = new ListCred();
                    Lista.cod_cli = cod_cli.ToString();
                    Lista.nombre = TxtNomSoli.Text;
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
                    string[] pago = new string[8];
                    pago[0] = cod_credi.ToString();
                    pago[1] = "0";
                    pago[2] = "0";
                    if (cuotaint > 0) pago[1] = cuotaint.ToString();
                    if (cuotacapital > 0) pago[2] = cuotacapital.ToString();
                    pago[3] = (decimal.Parse(pago[1]) + decimal.Parse(pago[2])).ToString();
                    pago[4] = "";
                    pago[5] = "";
                    pago[6] = "";
                    pago[7] = cuotaint.ToString();
                    //Registrar pago
                    pagocancelacion(pago);
                    if (cre.cancelar_cre(cod_credi.ToString()))
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
                    ingresocaja(credit.ToString());
                }
                else
                {
                    MessageBox.Show("El credito ha sido denegado");
                }
                hoja_pagos(datos[0], datos[6], datos[8]);
            }
            else
            {
                MessageBox.Show("El credito no ha podido ser autorizado");
            }

        }
        //Listadop de pa0gos por dia
        public void hoja_pagos(string soli, string tipo, string SaldAnte)
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
            repo.ResumenDesem(credi, tipo, TxtGastos.Text, dpi, SaldAnte);
            //repo.llenar_rep(credi,tipo);
        }

        private void pagocancelacion(string[] valores)
        {
            string credito = valores[0];
            string interes = valores[1];
            string capital = valores[2];
            string pago = valores[3];
            string fecha = DateTime.Now.ToString("yyyy/MM/dd");
            string mora = "0";
            string capital2 = "0";
            string interes2 = valores[7];
            string[] datos = { credito, interes2, capital, pago, fecha, mora, capital2, interes2 };
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
                Invoke(new Action(() => repo.llenar_rep(credi, datos[1])));
        }

        //listado de pagos por mes
        private void CboPlaz_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboTipo.SelectedIndex == 0 || CboTipo.SelectedIndex == 1)
            {
                LblPlazo.Visible = false;
                NupPlazo.Visible = false;
            }
            else if (CboTipo.SelectedIndex == 2 || CboTipo.SelectedIndex == 3)
            {
                LblPlazo.Visible = true;
                NupPlazo.Visible = true;

                if (CboTipo.SelectedIndex == 2)
                {
                    LblPlazo.Text = "Plazo(Semanas)";
                }
                else
                {
                    LblPlazo.Text = "Plazo(Quincenas)";
                }
            }
            else
            {
                LblPlazo.Text = "Plazo(Meses)";
                LblPlazo.Visible = true;
                NupPlazo.Visible = true;
            }
        }

        public void cod_cred(string credi)
        {
            cod_credi = Convert.ToInt32(credi);
        }
        public void EdicionEnCurso(bool sehizo)
        {
            if (sehizo)
            {
                llenado_datos();
            }
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
            if ((sol.denegarsol(CboSoli.Text)))
            {
                MessageBox.Show("Se cancelo la solicitud de credito", " cancelado");
                limpiar2();
                bloquear();
                cambiar();
            }
        }

        private void CboTipoGarant_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string TipPresta;
            //TipPresta = CboTipPresta.SelectedIndex.ToString();
            //if (TipPresta.Equals("1"))
            //{

            //}
            //else
            //{
            //    label21.Visible = false;
            //    label22.Visible = false;
            //    label23.Visible = false;
            //    //  TxtTipEsc.Visible = false;
            //    //  DtpEsc.Visible = false;
            //    //  TxtUbicacion.Visible = false;
            //    // GbxGarantias.Visible = false;
            //}
        }

    

        private void RdbSnGaran_CheckedChanged(object sender, EventArgs e)
        {
            EstabContrato();
        }

        void mostrarGarant()
        {

        }

        private void CboTipPresta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (CboTipPresta.SelectedIndex == 0)
            //{
            //    MostrarPrestaIndi();
            //    GbxDataFiad.Visible = false;
            //    llenarCajasSin();
            //    EstabContrato();
            //}
            //else
            //{
            //    MostrarPrestaFiad();
            //    GbxDataFiad.Visible = true;
            //    EstabContrato();


            //}
        }

        

    

       


     

        private void BtnAddGarant_Click(object sender, EventArgs e)
        {
            SubForms.IngresoGarantia esta = new SubForms.IngresoGarantia();
            esta.garant = cantigarant;
            esta.RegresarGarant += new SubForms.IngresoGarantia.Garantia(cargarGarant);
            // lol.RegresarGarant += new lol.RegresarGarant(datosgaran);
            esta.ShowDialog();
        }



        private void RdbGarant1_CheckedChanged(object sender, EventArgs e)
        {
            //if (RdbGarant1.Checked)
            //{
            //    cantigarant = 1;
            //    EstabContrato();
            //}
        }

        private void RdbGarant2_CheckedChanged(object sender, EventArgs e)
        {
            //if (RdbGarant2.Checked)
            //{
            //    cantigarant = 2;
            //    EstabContrato();
            //}
        }

        private void RdbGarant3_CheckedChanged(object sender, EventArgs e)
        {
            //if (RdbGarant3.Checked)
            //{
            //    cantigarant = 3;
            //    EstabContrato();
            //}
        }

        private void cargarGarant(Reportes.Contratos.ContratoDatos garantis)
        {
            datosgaran = garantis;
        }

        private void EstabContrato()
        {
            //if (CboTipPresta.SelectedIndex == 0)
            //{
            //    if (RdbSnGaran.Checked && ChkFirma1.Checked == false)
            //    {
            //        Contratotip = 1;
            //    }
            //    else if (RdbGarant1.Checked && ChkFirma1.Checked == true)
            //    { Contratotip = 2; }
            //    else if (RdbGarant1.Checked && ChkFirma1.Checked == false)
            //    { Contratotip = 3; }
            //}
            //else if (CboTipPresta.SelectedIndex == 1)
            //{
            //    if (RdbSnGaran.Checked && ChkFirma1.Checked && ChkFirma2.Checked)
            //    {
            //        Contratotip = 4;
            //    }
            //    else if (RdbGarant1.Checked && ChkFirma1.Checked && ChkFirma2.Checked)
            //    { Contratotip = 5; }
            //    else if (RdbGarant2.Checked && ChkFirma1.Checked && ChkFirma2.Checked)
            //    { Contratotip = 6; }
            //    else if (RdbSnGaran.Checked && ChkFirma1.Checked && ChkFirma2.Checked == false)
            //    { Contratotip = 7; }
            //    else if (RdbGarant1.Checked && ChkFirma1.Checked && ChkFirma2.Checked == false)
            //    { Contratotip = 8; }
            //    else if (RdbGarant2.Checked && ChkFirma1.Checked && ChkFirma2.Checked == false)
            //    { Contratotip = 9; }
            //    else if (RdbSnGaran.Checked && ChkFirma1.Checked == false && ChkFirma2.Checked == false)
            //    { Contratotip = 10; }
            //    else if (RdbGarant1.Checked && ChkFirma1.Checked == false && ChkFirma2.Checked)
            //    { Contratotip = 11; }
            //    else if (RdbGarant1.Checked && ChkFirma1.Checked == false && ChkFirma2.Checked == false)
            //    { Contratotip = 12; }
            //    else if (RdbGarant2.Checked && ChkFirma1.Checked == false && ChkFirma2.Checked == false)
            //    { Contratotip = 13; }

            //}
        }

    

        private void CboTipo2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboTipo2.SelectedIndex == 0)
            {
                label9.Text = "Plazo (Dias)";
                label14.Text = "Interes % diario";
            }
            else if (CboTipo2.SelectedIndex == 1)
            {
                label9.Text = "Plazo (Dias)";
                label14.Text = "Interes % diario";
            }
            else if (CboTipo2.SelectedIndex == 2)
            { label9.Text = "Plazo (Semanas)";
                label14.Text = "Interes % semanal";
            }
            else if (CboTipo2.SelectedIndex == 3)
            { label9.Text = "Plazo (Quincenas)";
                label14.Text = "Interes % quincenal";
            }
            else if (CboTipo2.SelectedIndex == 4)
            { label9.Text = "Plazo (Meses)";
                label14.Text = "Interes % anual";
            }
            else if (CboTipo2.SelectedIndex == 5)
            { label9.Text = "Plazo (Meses)";
                label14.Text = "Interes % anual";
            }

        }

        private void CboCliNom_SelectedValueChanged(object sender, EventArgs e)
        {
            SelUnNom();
        }

        private void SelUnNom()
        {
            if (AllCli.Rows.Count <= 0) return;

            string id = CboFiadNom.SelectedValue.ToString();
            int idCod = 0;
            try
            {
                idCod = int.Parse(id);
                var ToList = (from emp in AllCli.AsEnumerable()
                              where emp.Field<int>("Codigo_Cli") == idCod
                              select new
                              {
                                  Domicilio = emp.ItemArray[2].ToString(),
                                  Telefono = emp.ItemArray[3].ToString(),
                                  EstadoCiv = emp.ItemArray[4].ToString(),
                                  Profesion = emp.ItemArray[5].ToString(),
                                  Dpi = emp.ItemArray[6].ToString(),
                                  Edad = emp.ItemArray[7],
                                  Municipio = emp.ItemArray[9].ToString(),
                                  Departamento = emp.ItemArray[8].ToString(),
                                  Genero = emp.ItemArray[10].ToString(),
                                  Nacionalidad = emp.ItemArray[11].ToString(),

                              }).ToList();

                int filas = ToList.Count;
                //TxtDpiF.Text = ToList[0].Dpi.ToString();
                //TxtProfFiad.Text = ToList[0].Profesion;
                //NudEdadF.Value = int.Parse(ToList[0].Edad.ToString());
                //TxtEstCivilF.Text = ToList[0].EstadoCiv;
                //TxtDirF.Text = ToList[0].Domicilio;
                var Depauni = AllDepas.Where(o => o.Nombre.Equals(ToList[0].Departamento.ToString())).ToList();
                int idDepa = Depauni[0].Id;
              //  CboDepaF.SelectedValue = idDepa;
                var MuniUni = AllMunis.Where(l => l.Nombre.Equals(ToList[0].Municipio.ToString())).ToList();
                int idMuni = MuniUni[0].Id;
                //CboMuniF.SelectedValue = idMuni;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return;
            }



        }

        private void BtnIngInv_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMontoInv.Text))
            {
                MessageBox.Show("No se ha definido el monto de la inversion", "Vacio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (!Comprobanumero(TxtMontoInv.Text))
            {
                MessageBox.Show("No se ha Ingresado un monto valido, intentelo de nuevo", "Montor incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if ((int.Parse(NudPlazoInv.Value.ToString()))<3)
                {
                MessageBox.Show("Se necesita un plazo minimo de 3 meses para ingresar la inversiono, intentelo de nuevo", "Plazo incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);            }
            else if (string.IsNullOrEmpty(TxtOrigenMonto.Text))
            {
                MessageBox.Show("No se ha definido el origen del monto de la inversion", "Origen Vacio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (CboCliInv.SelectedValue == CboBenef.SelectedValue)
            {
                MessageBox.Show("El cliente y el beneficiario no pueden ser la misma persona", "Beneficiario incorrector", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ingresarInv();
            }

        }

        private void ingresarInv()
        {
            List<string> cajaop=new List<string>();
            string plazo = NudPlazoInv.Value.ToString();
            decimal Interes = Math.Round((NudInt.Value/100),2);
            DateTime Ffin = DateTime.Now.AddMonths(int.Parse(plazo));
            decimal incent = Incentiv(TxtMonto.Text,plazo);
            string idcli = CboCliInv.SelectedValue.ToString();
           string asesor=CboAsesorInv.SelectedValue.ToString();
            string bene = CboBenef.SelectedValue.ToString();
            string tutor = CboTutor.SelectedValue.ToString();
            int idp = caj.id_pago() + 1;
            cajaop.Add($"{idp}");
            cajaop.Add("Ingreso");
            cajaop.Add(TxtMontoInv.Text);
            cajaop.Add($"Ingreso de inversion a nombre de {CboCliente.Text}");
            cajaop.Add(DateTime.Now.ToString("yyyy/MM/dd"));
            cajaop.Add("Activo");
            cajaop.Add(Form1.Cod_U.ToString());
            cajaop.Add("0");
            cajaop.Add(CboCliente.Text);
            

            string[] valor = {cajaop[0],cajaop[1], cajaop[2], cajaop[3], cajaop[4], cajaop[5], cajaop[6], cajaop[7], cajaop[8] };


            
            string[] datos = { TxtMontoInv.Text, Interes.ToString(), plazo, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), Ffin.ToString("yyyy/MM/dd HH:mm:ss"), "Activo",incent.ToString(),TxtOrigenMonto.Text,idcli,asesor,bene, tutor};
            if (Inver.crear_Inv(datos) && caj.ingreope(valor))
            {

                MessageBox.Show("La inversion fue ingresada correctamente!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            { MessageBox.Show("No se pudo ingresar la inversion", "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

        }

        private bool Comprobanumero(string input)
        {
            return Regex.IsMatch(input, @"^\d+(\.\d+)?$");

        }

        private decimal InteInv(string cadena,string plazo)
            {
            decimal total = decimal.Parse(cadena);
            int tiempo = int.Parse(plazo);
            if (Form1.Nivel != "1" || Form1.Nivel != "2")
            {
                if (tiempo < 12)
                { return 0.12M * 100; }
                else if (tiempo < 24)
                {
                    return 0.14M * 100;
                }
                else
                {
                    return 0.15M * 100;
                }
            }
            else
            {
                return total;
            }
           
        }

        private decimal Incentiv(string monto,string plazo)
        {
            int meses = int.Parse(plazo);
            decimal total = decimal.Parse(monto);
            if ( meses< 24)
            {
                return total * 0.25M;
            }
            else
            {
                return total * 0.5M;
            }
        }

        private void TxtMontoInv_TextChanged(object sender, EventArgs e)
        {
            decimal monto;
            int plazo;
            bool montoT = (decimal.TryParse(TxtMonto.Text, out monto) && int.TryParse(NudPlazoInv.Value.ToString() , out plazo));
            if (montoT)
            {
                NudInt.Value = InteInv(TxtMonto.Text, NudPlazoInv.Value.ToString());
            }
        }

        private void NudPlazoInv_ValueChanged(object sender, EventArgs e)
        {
            decimal monto;
            int plazo;
            bool montoT = (decimal.TryParse(TxtMonto.Text, out monto) && int.TryParse(NudPlazoInv.Value.ToString(), out plazo));
            if (montoT)
            {
                NudInt.Value = InteInv(TxtMonto.Text, NudPlazoInv.Value.ToString());
            }
        }

        private void CboCliInv_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboCliInv.SelectedValue != null && CboCliInv.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                CboTutor.SelectedValue = CboCliInv.SelectedValue;
                string id = CboCliInv.SelectedValue.ToString();
                DataRow[] valor = AllCliInv.Select($"codigo_cli={id}");
                int edad = int.Parse(valor[0][7].ToString());
                if (edad < 18)
                {
                    MessageBox.Show("El cliente es menor de edad por lo que es necesario un tutor para aceptar la inversion");
                    label32.Visible = true;
                    CboTutor.Visible = true;

                }
                else
                {
                   // MessageBox.Show("El cliente es menor de edad por lo que es necesario un tutor para aceptar la inversion");
                    label32.Visible = false;
                    CboTutor.Visible = false;

                }

            }
        }

        private void NudInt_ValueChanged(object sender, EventArgs e)
        {
            if (Form1.Nivel == "1" || Form1.Nivel == "2")
            { }

            if (string.IsNullOrEmpty(TxtMontoInv.Text))
            {
                MessageBox.Show("No se ha definido el monto de la inversion", "Vacio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if (!Comprobanumero(TxtMontoInv.Text))
            {
                MessageBox.Show("No se ha Ingresado un monto valido, intentelo de nuevo", "Montor incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {

            }
          
          
           
        }

        private void BtnAddCuenta_Click(object sender, EventArgs e)
        {
            agregarCuenta();
            calcEstadoFin();
        }

        private void agregarCuenta()
        {
            // Validar que se seleccionó algo en el ComboBox
            if (CboCuenta.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un nombre del ComboBox",
                               "Advertencia",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            // Validar que el valor numérico sea válido
            // Si usas NumericUpDown:
            if (NudMontoCuenta.Value <= 0)  // Ajusta según tus necesidades
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido",
                               "Advertencia",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            // Crear nueva cuenta
            string NombreC = "";
       
            SubClases.Cuenta nuevaCuenta = new Formularios.SubClases.Cuenta
            {
                NomCuenta = CboCuenta.SelectedItem.ToString(),
                Valor = Math.Round(NudMontoCuenta.Value, 2),
                tipo=!(CboCuenta.SelectedItem.ToString().Equals("Prestamos"))// Convierte a int
            };

            // Verificar si ya existe en la lista
            bool existe = false;
            foreach (SubClases.Cuenta cuenta in LstCuentas.Items)
            {
                if (cuenta.Equals(nuevaCuenta))
                {
                    existe = true;
                    break;
                }
            }

            foreach (SubClases.Cuenta cuenta in LstPasiv.Items)
            {
                if (cuenta.Equals(nuevaCuenta))
                {
                    existe = true;
                    break;
                }
            }

            // Otra forma más corta con LINQ:
            // bool existe = listBox1.Items.Cast<Cuenta>().Any(c => c.Equals(nuevaCuenta));

            if (!existe)
            {
                // Opcional: También agregar a la lista auxiliar
                listaCuentas.Add(nuevaCuenta);
                if (nuevaCuenta.tipo)
                {  // Agregar al ListBox
                    LstCuentas.Items.Add(nuevaCuenta);

                  
                }
                else
                {
                    LstPasiv.Items.Add(nuevaCuenta);
                }

                // Opcional: Limpiar campos después de agregar
                CboCuenta.SelectedIndex = -1;
                NudMontoCuenta.Value = NudMontoCuenta.Minimum;
            }
            else
            {
                MessageBox.Show("Esta cuenta ya existe en la lista",
                               "Elemento duplicado",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
        }

        private void EliminarCuenta()
        {
            // Verificar si hay algún elemento seleccionado en el ListBox
            if (LstCuentas.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un elemento para eliminar",
                               "Advertencia",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            // Confirmar eliminación
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro de eliminar el elemento seleccionado?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Obtener el elemento seleccionado
                SubClases.Cuenta cuentaSeleccionada = (SubClases.Cuenta)LstCuentas.SelectedItem;

                // Eliminar del ListBox
               LstCuentas.Items.RemoveAt(LstCuentas.SelectedIndex);

                // Opcional: También eliminar de la lista auxiliar
                listaCuentas.Remove(cuentaSeleccionada);

                // Opcional: Mostrar mensaje de confirmación
                // MessageBox.Show("Elemento eliminado correctamente", 
                //                "Éxito", 
                //                MessageBoxButtons.OK, 
                //                MessageBoxIcon.Information);
            }
        }

        private void BtnElimCuenta_Click(object sender, EventArgs e)
        {
            EliminarCuenta();
            calcEstadoFin();
        }

        private void calcEstadoFin()
        {
            decimal total=0.00M;
            foreach (SubClases.Cuenta cuenta in listaCuentas)
            {
                if (cuenta.tipo)
                { total += cuenta.Valor; }
                else
                {
                    total -= cuenta.Valor;
                }
            }
            if (total > 0)
            {
                TxtPatri.BackColor = Color.Green;
                //TxtPatri.ForeColor = Color.White;
            }
            else
            {
                TxtPatri.BackColor = Color.DarkRed;
              //  TxtPatri.ForeColor = Color.White;
            }
            TxtPatri.Text = $"Q.{total}";
        }

        private void DgvIngMen_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int fila = e.RowIndex;
            DgvIngMen.Rows[fila-1].Cells[1].Value = "0";
            DgvIngMen.Rows[fila - 1].Cells[2].Value = "0.00";
            DgvIngMen.Rows[fila - 1].Cells[3].Value = "0.00";
            DgvIngMen.Rows[fila - 1].Cells[4].Value = "0.00";
        }

        private void DgvEngMen_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int fila = e.RowIndex;
            DgvEngMen.Rows[fila - 1].Cells[1].Value = "0";
            DgvEngMen.Rows[fila - 1].Cells[2].Value = "Empresa";
            DgvEngMen.Rows[fila - 1].Cells[3].Value = "0.00";
        }

        private void BtnElimIng_Click(object sender, EventArgs e)
        {
            //MessageBox.Show($"{DgvIngMen.Rows.Count}");
            EliminarIngreso();
        }

        private void EliminarIngreso()
        {
            try
            {
                int indice = DgvIngMen.CurrentRow.Index;
                DgvIngMen.Rows.RemoveAt(indice);
                MessageBox.Show("La fila fue eliminada correctamente","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo eliminar el ingreso de la lista \n{ex.Message}", "Algo salio mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarEgreso()
        {
            try
            {
                int indice = DgvEngMen.CurrentRow.Index;
                DgvEngMen.Rows.RemoveAt(indice);
                MessageBox.Show("La fila fue eliminada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo eliminar el egreso de la lista \n{ex.Message}", "Algo salio mal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrueba_Click(object sender, EventArgs e)
        {
          
        }


        private bool soliPt2()
        {
            List<string> datos = new List<string>();
            List<SubClases.Egreso> egresos = new List<SubClases.Egreso>();
            List<SubClases.Ingreso> ingresos = new List<SubClases.Ingreso>();
          
            foreach (var item in listaCuentas)
            {
                datos.Add(item.NomCuenta);
                datos.Add(item.Valor.ToString());
                datos.Add(item.tipo.ToString());
            }
            //comprobacion de valores para ingresos

            
            foreach (DataGridViewRow item in DgvIngMen.Rows)
{
    // 1. Evitar la fila nueva (la de ingreso)
    if (item.IsNewRow) continue;
    
    // 2. Verificar si la fila está completamente vacía (todas las celdas sin valor)
    bool filaCompletamenteVacia = true;
    for (int i = 0; i <= 4; i++) // Verificar columnas 0-4 (obligatorias)
    {
        var valor = item.Cells[i].Value?.ToString();
        if (!string.IsNullOrWhiteSpace(valor))
        {
            filaCompletamenteVacia = false;
            break;
        }
    }
    
    // Si la fila está completamente vacía, la saltamos (no es error)
    if (filaCompletamenteVacia) continue;
    
    // 3. Obtener valores de las celdas (manejando posibles nulos)
    var val0 = item.Cells[0].Value?.ToString();
    var val1 = item.Cells[1].Value?.ToString();
    var val2 = item.Cells[2].Value?.ToString();
    var val3 = item.Cells[3].Value?.ToString();
    var val4 = item.Cells[4].Value?.ToString();
    var val5 = item.Cells[5].Value?.ToString();
    
    // 4. Verificar que los campos obligatorios (0-4) no estén vacíos
    bool camposObligatoriosLlenos = !string.IsNullOrWhiteSpace(val0) &&
                                     !string.IsNullOrWhiteSpace(val1) &&
                                     !string.IsNullOrWhiteSpace(val2) &&
                                     !string.IsNullOrWhiteSpace(val3) &&
                                     !string.IsNullOrWhiteSpace(val4);
    
    if (!camposObligatoriosLlenos)
    {
        MessageBox.Show($"La fila {item.Index} tiene campos obligatorios vacíos. Complete todos los campos (Producto, Cantidad, Costo, Venta, Ganancia)", 
                        "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
    }
    
    // 5. Validaciones de tipo de datos
    bool esInt1Valido = int.TryParse(val1, out int cantidad);
    bool esDecimal1Valido = decimal.TryParse(val2, out decimal costo);
    bool esDecimal2Valido = decimal.TryParse(val3, out decimal venta);
    bool esDecimal3Valido = decimal.TryParse(val4, out decimal ganancia);
    
    // 6. Solo si todo es válido, se agregan a la lista
    if (esInt1Valido && esDecimal1Valido && esDecimal2Valido && esDecimal3Valido)
    {
        SubClases.Ingreso temp = new SubClases.Ingreso();
        temp.Producto = val0;
        temp.Cantidad = cantidad;
        temp.Costo = costo;
        temp.Venta = venta;
        temp.Ganacia = ganancia;
        temp.Id = string.IsNullOrWhiteSpace(val5) ? 0 : int.Parse(val5);
        ingresos.Add(temp);
    }
    else
    {
        MessageBox.Show($"La fila {item.Index} posee un valor inválido (formato numérico incorrecto en Cantidad, Costo, Venta o Ganancia), verifique por favor", 
                        "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        return false;
    }
}

            // Comprobacion de valores para egresos
            foreach (DataGridViewRow item in DgvEngMen.Rows)
            {
                // 1. Evitar la fila nueva (la de ingreso)
                if (item.IsNewRow) continue;

                // 2. Verificar si la fila está completamente vacía (todas las celdas sin valor)
                bool filaCompletamenteVacia = true;
                for (int i = 0; i <= 3; i++) // Verificar columnas 0-3 (obligatorias)
                {
                    var valor = item.Cells[i].Value?.ToString();
                    if (!string.IsNullOrWhiteSpace(valor))
                    {
                        filaCompletamenteVacia = false;
                        break;
                    }
                }

                // Si la fila está completamente vacía, la saltamos (no es error)
                if (filaCompletamenteVacia) continue;

                // 3. Obtener valores de las celdas (manejando posibles nulos)
                var valE0 = item.Cells[0].Value?.ToString(); // Detalle
                var valE1 = item.Cells[1].Value?.ToString(); // Cantidad
                var valE2 = item.Cells[2].Value?.ToString(); // Empresa
                var valE3 = item.Cells[3].Value?.ToString(); // Cuota mensual
                var valE4 = item.Cells[4].Value?.ToString(); // ID (opcional)

                // 4. Verificar que los campos obligatorios (0-3) no estén vacíos
                bool camposObligatoriosLlenos = !string.IsNullOrWhiteSpace(valE0) &&
                                                 !string.IsNullOrWhiteSpace(valE1) &&
                                                 !string.IsNullOrWhiteSpace(valE2) &&
                                                 !string.IsNullOrWhiteSpace(valE3);

                if (!camposObligatoriosLlenos)
                {
                    MessageBox.Show($"La fila {item.Index} de egresos tiene campos obligatorios vacíos. Complete todos los campos (Detalle, Cantidad, Empresa, Cuota mensual)",
                                    "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                // 5. Validaciones de tipo de datos
                bool esIntValido = int.TryParse(valE1, out int cantidad);
                bool esDecimalValido = decimal.TryParse(valE3, out decimal cuotaMensual);

                // 6. Solo si todo es válido, se agregan a la lista
                if (esIntValido && esDecimalValido)
                {
                    SubClases.Egreso TempE = new SubClases.Egreso();
                    TempE.Detalle = valE0;
                    TempE.Cantidad = cantidad;
                    TempE.Empresa = valE2;
                    TempE.Cuota_men = cuotaMensual;
                    TempE.Id = string.IsNullOrWhiteSpace(valE4) ? 0 : int.Parse(valE4);
                    egresos.Add(TempE);
                }
                else
                {
                    string mensajeError = "La fila " + item.Index + " de egresos posee un valor inválido: ";
                    if (!esIntValido) mensajeError += "\n- Cantidad debe ser un número entero";
                    if (!esDecimalValido) mensajeError += "\n- Cuota mensual debe ser un número decimal";

                    MessageBox.Show(mensajeError, "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            int CantIngre = ingresos.Count;
            int CantEgre = egresos.Count;
            bool IngreResp = CantIngre > 0 ? sol.IngresoMen(ingresos, TxtNoSol.Text) : true;
            bool EgreResp = CantEgre > 0 ? sol.EgresoMen(egresos, TxtNoSol.Text) : true;

            return ((sol.IngresoEstadoFinan(listaCuentas,TxtNoSol.Text) && IngreResp && EgreResp ));
           
        }

        private void BtnSoliVer_Click(object sender, EventArgs e)
        {
            if (CboSoli.SelectedIndex == -1)
            {
                MessageBox.Show($"Aun no se ha seleccionado el numero de solicitud", "No seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            CargarRepoSoli();
        }

        #region  Solicitud Reporte

        private void CargarRepoSoli()
        {
            List<Reportes.ClasesRepo.ReferenciaSolicitud> refes = new List<Reportes.ClasesRepo.ReferenciaSolicitud>();
           List<Reportes.ClasesRepo.FiadorSolicitud> Fiad = new List<Reportes.ClasesRepo.FiadorSolicitud>();
           List< Reportes.ClasesRepo.GarantiaSolicitud> Gara = new List<Reportes.ClasesRepo.GarantiaSolicitud>();
            List<Reportes.ClasesRepo.CuentaRepo> Cue = new List<Reportes.ClasesRepo.CuentaRepo>();
            List<Reportes.ClasesRepo.IngresoRepo> Ingre = new List<Reportes.ClasesRepo.IngresoRepo>();
            List<Reportes.ClasesRepo.EgresoRepo> Egre = new List<Reportes.ClasesRepo.EgresoRepo>();

            string idcli = LblCodCli.Text;
            string idsol = CboSoli.Text;
            string Tipocredi = "";
            string Pcred="";

            DataTable datosCli = cli.clientebusca(idcli);
            DataTable datosRefes = cli.refscli(idcli);
            DataTable datosGarant = sol.GarantbyCliSol(idsol, idcli);
            DataTable datosIngre = sol.IngresoSol(idsol);
            DataTable datosEgre = sol.EgresoSol(idsol);
            DataTable datosCuent = sol.CuentaSol(idsol);
            DataTable datosFiad = sol.FiadAllSol(idsol);
          DataTable datosSoli = sol.busca_datos(CboSoli.Text);
            int edad = CalcularEdadSegura(datosCli.Rows[0][22]);
            DateTime fechaNac = DateTime.Now;
            if (edad != -1)
            {
                fechaNac = Convert.ToDateTime(datosCli.Rows[0][22]);
            }
            else
            {
                edad = 0;
                MessageBox.Show($"La fecha de nacimiento del cliente no tiene un valor correcto", "No seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
    
            if ($"{datosSoli.Rows[0][7]}" == "1")
            { Tipocredi = "Diario";
                Pcred = "Diario";
            }
            else if ($"{datosSoli.Rows[0][7]}" == "2")
            {
                Tipocredi = "Diario al vencimiento";
                Pcred = "Diario";
            }
            else if ($"{datosSoli.Rows[0][7]}" == "3")
            {
                Tipocredi = "Mensual fijo";
                Pcred = "Mensual";
            }
            else if ($"{datosSoli.Rows[0][7]}" == "4")
            {
                Tipocredi = "Mensual sobre saldo";
                Pcred = "Mensual";
            }
            else if ($"{datosSoli.Rows[0][7]}" == "5")
            {
                Tipocredi = "Semanal";
                Pcred = "Semanal";
            }
            else if ($"{datosSoli.Rows[0][7]}" == "6")
            {
                Tipocredi = "Quincenal";
                Pcred = "Quincenal";
            }
            Reportes.ClasesRepo.DatosSolicitud DatoSol = new Reportes.ClasesRepo.DatosSolicitud();
            DatoSol.IdSol = int.Parse(CboSoli.Text);
            DatoSol.FechaSol = DateTime.Parse(LblFechasol.Text);
            DatoSol.Cliente =$"{datosCli.Rows[0][0]} {datosCli.Rows[0][1]}";
            DatoSol.Edad = edad;
            DatoSol.Naci = fechaNac;
            DatoSol.Domicilio=$"{datosCli.Rows[0][2]}";
            DatoSol.DPI = $"{datosCli.Rows[0][3]}";
            DatoSol.Tel1 = $"{datosCli.Rows[0][4]}";
            DatoSol.Tel2= $"{datosCli.Rows[0][5]}";
            DatoSol.Prof1 = $"{datosCli.Rows[0][6]}";
            DatoSol.NomCony= $"{datosCli.Rows[0][7]} {datosCli.Rows[0][8]}";
            DatoSol.TelCony = $"{datosCli.Rows[0][9]}";
            DatoSol.Referencia=$"{datosCli.Rows[0][10]}";
            DatoSol.EstadoCivil= $"{datosCli.Rows[0][11]}";
            DatoSol.Prof2= $"{datosCli.Rows[0][17]}";
            DatoSol.CagaF = $"{datosCli.Rows[0][18]}";
            DatoSol.ProfCony = $"{datosCli.Rows[0][19]}";
            DatoSol.DPICony= $"{datosCli.Rows[0][20]}";
            DatoSol.Asesor = TxtNomAseso.Text;
            DatoSol.MotivoCred = TxtConcept.Text;
            //falta buscar
            DatoSol.TelNeg= $"{datosCli.Rows[0][24]}";
            DatoSol.RefNeg= $"{datosCli.Rows[0][26]}";
            DatoSol.AntiqNeg = $"{datosCli.Rows[0][28]}";
            DatoSol.DirNeg = $"{datosCli.Rows[0][25]}";
            DatoSol.NomNeg = $"{datosCli.Rows[0][23]}";
            DatoSol.TipoNeg= $"{datosCli.Rows[0][27]}";
            DatoSol.PlazoCred =int.Parse($"{datosSoli.Rows[0][4]}");
            DatoSol.PagoCred =Pcred;
            DatoSol.TipoCred = Tipocredi;
            DatoSol.interes=decimal.Parse($"{datosSoli.Rows[0][10]}");
            DatoSol.Monto = decimal.Parse($"{datosSoli.Rows[0][3]}");
            DatoSol.MontoSug= decimal.Parse($"{datosSoli.Rows[0][5]}");
            DatoSol.MotivoCred = $"{datosSoli.Rows[0][2]}";
            DatoSol.FamConCredito = TxtGarantia.Text;
            DatoSol.interes = decimal.Parse(TxtInteres.Text);
           
            for (int i = 0; i < datosRefes.Rows.Count; i++)
            {
                Reportes.ClasesRepo.ReferenciaSolicitud TempRefe = new Reportes.ClasesRepo.ReferenciaSolicitud();
                TempRefe.Nombre = $"{datosRefes.Rows[i][1]}";
                TempRefe.Parentezco = $"{datosRefes.Rows[i][2]}";
                TempRefe.Telefono = $"{datosRefes.Rows[i][3]}";
                refes.Add(TempRefe);
            }
            for (int i = 0; i < datosGarant.Rows.Count; i++)
            {
                Reportes.ClasesRepo.GarantiaSolicitud temp = new Reportes.ClasesRepo.GarantiaSolicitud();
                temp.Propietario = $"{datosGarant.Rows[i][1]}";
               // temp.Detalle = $"{datosGarant.Rows[i][1]}";
                temp.Tipo = $"{datosGarant.Rows[i][2]}";
                temp.Detalle = $"{datosGarant.Rows[i][3]}";
                temp.Valor = decimal.Parse($"{datosGarant.Rows[i][4]}");
                temp.Informacion = $"{datosGarant.Rows[i][5]}";
                temp.Observaciones = $"{datosGarant.Rows[i][6]}";
                Gara.Add(temp);
            }

            for (int i = 0; i < datosCuent.Rows.Count; i++)
            {
                Reportes.ClasesRepo.CuentaRepo temp = new Reportes.ClasesRepo.CuentaRepo();
                temp.NomCuenta = $"{datosCuent.Rows[i][0]}";
                temp.Valor = decimal.Parse( $"{datosCuent.Rows[i][1]}");
                temp.tipo = bool.Parse( $"{datosCuent.Rows[i][2]}");
                Cue.Add(temp);
            }

            for (int i = 0; i < datosIngre.Rows.Count; i++)
            {
                Reportes.ClasesRepo.IngresoRepo temp = new Reportes.ClasesRepo.IngresoRepo();
                temp.Cantidad= int.Parse( $"{datosIngre.Rows[i][0]}");
                temp.Producto= ( $"{datosIngre.Rows[i][1]}");
                temp.Costo= decimal.Parse( $"{datosIngre.Rows[i][2]}");
                temp.Venta= decimal.Parse( $"{datosIngre.Rows[i][3]}");
                temp.Ganacia= decimal.Parse( $"{datosIngre.Rows[i][4]}");
                Ingre.Add(temp);
            }
            for (int i = 0; i < datosEgre.Rows.Count; i++)
            {
                Reportes.ClasesRepo.EgresoRepo temp = new Reportes.ClasesRepo.EgresoRepo();
                temp.Cantidad = int.Parse($"{datosEgre.Rows[i][0]}");
                temp.Detalle = ($"{datosEgre.Rows[i][1]}");
                temp.Empresa = ($"{datosEgre.Rows[i][2]}");
                temp.Cuota_men = decimal.Parse($"{datosEgre.Rows[i][3]}");
                Egre.Add(temp);
            }

            for (int i = 0; i < datosFiad.Rows.Count; i++)
            {
                Reportes.ClasesRepo.FiadorSolicitud temp = new Reportes.ClasesRepo.FiadorSolicitud();
                //temp = int.Parse($"{datosEgre.Rows[i][0]}");
                temp.Nombre = ($"{datosFiad.Rows[i][1]}");
                temp.Dpi = ($"{datosFiad.Rows[i][2]}");
                temp.Domicilio = ($"{datosFiad.Rows[i][3]}");
                temp.Tel1 =($"{datosFiad.Rows[i][4]}");
                temp.Tel2 =($"{datosFiad.Rows[i][4]}");
                temp.Profes = ($"{datosFiad.Rows[i][6]}");
                temp.RefUbi = ($"{datosFiad.Rows[i][7]}");
                temp.Fecha = DateTime.Parse($"{datosFiad.Rows[i][9]}");
                temp.Edad = CalcularEdadSegura($"{datosFiad.Rows[i][9]}");
                
               Fiad.Add(temp);
            }
            //DatoSol.Refs.Add(refes);
            //DatoSol.cre
            Reportes.SolicitudNuevo soli = new Reportes.SolicitudNuevo();
            soli.DatosGen.Add(DatoSol);
            soli.Referi = refes;
            soli.Fiado=(Fiad);
            soli.Garant=(Gara);
            soli.Cuenta = Cue;
            soli.Ingre = Ingre;
            soli.Egres = Egre;
            soli.Show();


        }



        #endregion

        #region Ingreso de Garantia renovada

        private bool IngresoGarant()
        {
            List<SubClases.Garantia> IngGar = new List<SubClases.Garantia>();
            foreach (DataGridViewRow fila in DgvGaranLSt.Rows)
            {
                SubClases.Garantia temp = new SubClases.Garantia();
                temp.Id = 0;
                temp.Propietario =int.Parse($"{fila.Cells[0].Value}");
                temp.Tipo=$"{fila.Cells[2].Value}";
                temp.Detalle = ($"{fila.Cells[3].Value}");
                temp.Valor = decimal.Parse($"{fila.Cells[4].Value}");
                temp.Informacion = ($"{fila.Cells[5].Value}");
                temp.Observaciones = ($"{fila.Cells[6].Value}");
                IngGar.Add(temp);
            }

            return (sol.ingresoGarantia(IngGar, TxtNoSol.Text));
        }

       

        #endregion

        #region Ingreso del fiador renovada

        private bool IngresoFiador()
        {
            List<SubClases.Fiador> IngFiad = new List<SubClases.Fiador>();
            
            foreach (DataGridViewRow fila in DgvFiadorLst.Rows)
            {
                SubClases.Fiador temp = new SubClases.Fiador();
                temp.idSol = int.Parse($"{TxtNoSol.Text}");
                temp.IdFiad = int.Parse($"{fila.Cells[0].Value}");
                temp.OtherIng = $"{fila.Cells[3].Value}";
                IngFiad.Add(temp);
            }
            return (sol.ingresoFiador(IngFiad));
        }


        #endregion


        #region Manejo Lista fiador y garantias
        private void BtnAddLstGarant_Click(object sender, EventArgs e)
        {
            //primera parte: comprovacion de datos
            // 1. Limpieza de espacios para evitar entradas de solo espacios
            string IdProp = CboPropi.SelectedValue.ToString().Trim();
            string Tipo = CboTipoGarant.Text;
            string prop = CboPropi.Text;
            string valor = TxtValGara.Text.Trim();
            string detalle = TxtDetaGara.Text.Trim();
            string observacion = TxtObsGara.Text.Trim();
            string Info = TxtInfoGara.Text.Trim();



            // 2. Validaciones de campos obligatorios
            if (string.IsNullOrEmpty(Tipo) || string.IsNullOrEmpty(prop) || string.IsNullOrEmpty(valor) || string.IsNullOrEmpty(detalle) || string.IsNullOrEmpty(observacion) || string.IsNullOrEmpty(Info) || string.IsNullOrEmpty(IdProp))
            {
                MessageBox.Show("Todos los campos de garantia son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene la ejecución
            }
            bool numerosi = false;
            decimal numtemp;
            numerosi = decimal.TryParse(valor, out numtemp);
            if (!numerosi)
            {
                MessageBox.Show("El dato ingresado en valor es invalido, porfavor intentelo de nuevo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene la ejecución }
            }
            DgvGaranLSt.Rows.Add(IdProp, prop, Tipo, detalle, String.Format("{0:0,000.00}", numtemp), Info, observacion);


        }

        private void BtnAddLstFiad_Click(object sender, EventArgs e)
        {
            //primera parte: comprovacion de datos
            // 1. Limpieza de espacios para evitar entradas de solo espacios
            string IdFiad = CboFiadNom.SelectedValue.ToString().Trim();
            string Nombre = CboFiadNom.Text.ToString().Trim();
            string Otros = TxtOtherIng.Text.Trim();

            // 2. Validaciones de campos obligatorios
            if (string.IsNullOrEmpty(IdFiad) || string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Otros))
            {
                MessageBox.Show("Todos los campos de fiador son obligatorios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene la ejecución
            }
            DataTable DatosF = cli.clientebusca(IdFiad);
            string Domi = $"{DatosF.Rows[0][2]}";

            DgvFiadorLst.Rows.Add(IdFiad, Nombre, Domi, Otros);
        }

        private void BtnDelLstGarant_Click(object sender, EventArgs e)
        {
            if (DgvGaranLSt.Rows.Count > 0)
            {
                int indice = DgvGaranLSt.CurrentRow.Index;
                DgvGaranLSt.Rows.RemoveAt(indice);
            }
            else
            {
                MessageBox.Show("No existen datos para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return; // Detiene la ejecución }
            }
        }

        private void BtnDelLstFiad_Click(object sender, EventArgs e)
        {
            if (DgvFiadorLst.Rows.Count > 0)
            {
                int indice = DgvFiadorLst.CurrentRow.Index;
                DgvFiadorLst.Rows.RemoveAt(indice);
            }
            else
            {
                MessageBox.Show("No existen datos para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return; // Detiene la ejecución }
            }
        }
        #endregion

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Identificar cuál TabPage está seleccionada
            TabPage SelectedTab = tabControl1.TabPages[e.Index];

            // Obtener el área del encabezado del TabPage
            Rectangle HeaderRect = tabControl1.GetTabRect(e.Index);
            Color amria = Color.FromArgb(250, 204, 21);
            // Crear Brushes para texto y fondo
            using (SolidBrush BlackTextBrush = new SolidBrush(Color.Black))
            using (SolidBrush RedTextBrush = new SolidBrush(Color.Black))
            using (SolidBrush SelectedBackBrush = new SolidBrush(amria))   // Fondo cuando está seleccionada
            using (SolidBrush NormalBackBrush = new SolidBrush(Color.White))         // Fondo normal
            {
                // Configurar la alineación del texto
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                // Pintar el fondo primero
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    e.Graphics.FillRectangle(SelectedBackBrush, HeaderRect);

                    using (Font BoldFont = new Font(tabControl1.Font.Name, tabControl1.Font.Size, FontStyle.Bold))
                    {
                        e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, BoldFont, RedTextBrush, HeaderRect, sf);
                    }
                }
                else
                {
                    e.Graphics.FillRectangle(NormalBackBrush, HeaderRect);
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, e.Font, BlackTextBrush, HeaderRect, sf);
                }
            }
        }

        private void TCTSoli_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            TabPage currentTab = tabControl.TabPages[e.Index];

            // Obtener el área del encabezado
            Rectangle headerRect = tabControl.GetTabRect(e.Index);

            // Definir colores usando tu clase Estilos
            Color amarillo = Clases.Estilos.Accent;  // Usando tu color definido
            Color fondoNormal = Clases.Estilos.Panel;
            Color textoNormal = Clases.Estilos.TitleText;
            Color textoSel = Clases.Estilos.MenuActive;  // O usar otro color para seleccionado

            // Crear brushes
            using (SolidBrush selectedBackBrush = new SolidBrush(amarillo))
            using (SolidBrush normalBackBrush = new SolidBrush(fondoNormal))
            using (SolidBrush selectedTextBrush = new SolidBrush(textoSel))
            using (SolidBrush normalTextBrush = new SolidBrush(textoNormal))
            {
                // Configurar alineación
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                // Determinar si está seleccionada
                bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

                // Dibujar fondo
                if (isSelected)
                {
                    e.Graphics.FillRectangle(selectedBackBrush, headerRect);
                }
                else
                {
                    e.Graphics.FillRectangle(normalBackBrush, headerRect);
                }

                // Dibujar texto
                Font fontToUse;
                Brush textBrush;

                if (isSelected)
                {
                    // Usar fuente en negrita para seleccionado
                    fontToUse = new Font(tabControl.Font, FontStyle.Bold);
                    textBrush = selectedTextBrush;
                }
                else
                {
                    fontToUse = tabControl.Font;
                    textBrush = normalTextBrush;
                }

                // Dibujar el texto centrado
                e.Graphics.DrawString(currentTab.Text, fontToUse, textBrush, headerRect, sf);

                // Limpiar recursos si creamos una nueva fuente
                if (isSelected)
                {
                    fontToUse.Dispose();
                }
            }
        }

        // MÉTODO PARA AJUSTAR EL TAMAÑO DE LAS PESTAÑAS SEGÚN EL TEXTO
        private void AjustarTamanioPestaniasSegunTexto()
        {
            // Configurar para calcular tamaño automático
            TCTSoli.SizeMode = TabSizeMode.Fixed;
            tabControl1.SizeMode = TabSizeMode.Fixed;

            //tab superior
            using (Graphics g = tabControl1.CreateGraphics())
            {
                int maxWidth = 0;
                // Calcular el ancho necesario para cada pestaña
                foreach (TabPage tab in tabControl1.TabPages)
                {
                    // Medir el texto con fuente normal
                    SizeF textSizeNormal = g.MeasureString(tab.Text, tabControl1.Font);
                    // Medir el texto con fuente en negrita (para cuando está seleccionada)
                    using (Font boldFont = new Font(tabControl1.Font, FontStyle.Bold))
                    {
                        SizeF textSizeBold = g.MeasureString(tab.Text, boldFont);
                        // Usar el mayor tamaño entre normal y negrita
                        float textWidth = Math.Max(textSizeNormal.Width, textSizeBold.Width);
                        // Agregar padding (izquierda y derecha)
                        int requiredWidth = (int)textWidth + 30; // 15px de padding a cada lado
                        if (requiredWidth > maxWidth)
                        {
                            maxWidth = requiredWidth;
                        }
                    }
                }
                // Limitar el tamaño máximo si es necesario
                int maxPermitido = 200; // Ajusta este valor según tus necesidades
                if (maxWidth > maxPermitido)
                {
                    maxWidth = maxPermitido;
                }
                // Asegurar un tamaño mínimo
                int minWidth = 80;
                if (maxWidth < minWidth)
                {
                    maxWidth = minWidth;
                }
                // Aplicar el tamaño calculado a todas las pestañas
                tabControl1.ItemSize = new Size(maxWidth, tabControl1.ItemSize.Height);
            }

            using (Graphics g = TCTSoli.CreateGraphics())
            {
                int maxWidth = 0;
                // Calcular el ancho necesario para cada pestaña
                foreach (TabPage tab in TCTSoli.TabPages)
                {
                    // Medir el texto con fuente normal
                    SizeF textSizeNormal = g.MeasureString(tab.Text, TCTSoli.Font);
                    // Medir el texto con fuente en negrita (para cuando está seleccionada)
                    using (Font boldFont = new Font(TCTSoli.Font, FontStyle.Bold))
                    {
                        SizeF textSizeBold = g.MeasureString(tab.Text, boldFont);
                        // Usar el mayor tamaño entre normal y negrita
                        float textWidth = Math.Max(textSizeNormal.Width, textSizeBold.Width);
                        // Agregar padding (izquierda y derecha)
                        int requiredWidth = (int)textWidth + 30; // 15px de padding a cada lado
                        if (requiredWidth > maxWidth)
                        {
                            maxWidth = requiredWidth;
                        }
                    }
                }
                // Limitar el tamaño máximo si es necesario
                int maxPermitido = 200; // Ajusta este valor según tus necesidades
                if (maxWidth > maxPermitido)
                {
                    maxWidth = maxPermitido;
                }
                // Asegurar un tamaño mínimo
                int minWidth = 80;
                if (maxWidth < minWidth)
                {
                    maxWidth = minWidth;
                }
                // Aplicar el tamaño calculado a todas las pestañas
                TCTSoli.ItemSize = new Size(maxWidth, TCTSoli.ItemSize.Height);
            }


        }

             //validaciones
        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "¡Sin datos!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private bool ConfirmarContinuar(string mensaje)
        {
            return MessageBox.Show(mensaje, "¿Continuar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private bool verificarEstCuenta()
        {
           bool  respo = false;
            foreach (DataGridViewRow item in DgvIngMen.Rows)
            {
                // 1. Evitar errores si la fila está vacía (común al final de un DataGridView)
                if (item.IsNewRow) continue;

                // 2. Obtener valores de las celdas (manejando posibles nulos)
                var val0 = item.Cells[0].Value?.ToString();
                var val1 = item.Cells[1].Value?.ToString();
                var val2 = item.Cells[2].Value?.ToString();
                var val3 = item.Cells[3].Value?.ToString();
                var val4 = item.Cells[4].Value?.ToString();


                // 3. Comprobaciones de validación
                bool esInt1Valido = int.TryParse(val1, out _);
                bool esString1Valido = !string.IsNullOrWhiteSpace(val0);
                bool esDecimal1Valido = decimal.TryParse(val2, out _);
                bool esDecimal2Valido = decimal.TryParse(val3, out _);
                bool esDecimal3Valido = decimal.TryParse(val4, out _);

                // 4. Solo si todo es válido, se agregan a la lista
                if (esInt1Valido && esString1Valido && esDecimal1Valido && esDecimal2Valido && esDecimal3Valido)
                {

                    respo = true;
                }
                else
                {
                    MessageBox.Show($"La fila {item.Index} de ingresos posee un valor invalido, verifique porfavor", "Valor invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false; //omitir este return para revision 
                }
                
            }

            //Comprobacion de valores para egresos

            foreach (DataGridViewRow item in DgvEngMen.Rows)
            {
                // 1. Evitar errores si la fila está vacía (común al final de un DataGridView)
                if (item.IsNewRow) continue;

                // 2. Obtener valores de las celdas (manejando posibles nulos)
                var valE0 = item.Cells[0].Value?.ToString();
                var valE1 = item.Cells[1].Value?.ToString();
                var valE2 = item.Cells[2].Value?.ToString();
                var valE3 = item.Cells[3].Value?.ToString();


                // 3. Comprobaciones de validación
                bool esIntValido = int.TryParse(valE1, out _);
                bool esString1Valido = !string.IsNullOrWhiteSpace(valE0);
                bool esString2Valido = !string.IsNullOrWhiteSpace(valE2);
                bool esDecimalValido = decimal.TryParse(valE3, out _);

                // 4. Solo si todo es válido, se agregan a la lista
                if (esIntValido && esString1Valido && esString2Valido && esDecimalValido)
                {
                    respo = true;
                }
                else
                {
                    MessageBox.Show($"La fila {item.Index} de egresos posee un valor invalido, verifique porfavor", "Valor invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return respo;
        }

        public int CalcularEdadSegura(object valorCelda)
        {
            // 1. Verificar si el valor es nulo o DBNull
            if (valorCelda == null || valorCelda == DBNull.Value)
            {
                return -1; // O manejar el error como prefieras
            }

            // 2. Intentar convertir a DateTime de forma segura
            if (DateTime.TryParse(valorCelda.ToString(), out DateTime fechaNac))
            {
                DateTime fechaActual = DateTime.Today;
                int edad = fechaActual.Year - fechaNac.Year;

                // Ajuste por si no ha cumplido años aún
                if (fechaNac.Date > fechaActual.AddYears(-edad)) edad--;

                return edad;
            }

            return -1; // Retorna -1 si el formato de fecha no era válido
        }

        private void CboAsesor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void GBXPrestamo_Enter(object sender, EventArgs e)
        {

        }

        private void CboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboTipo.SelectedIndex == 0)
            { LblPlazo.Text = "Plazo(Dias)"; }
            else if (CboTipo.SelectedIndex == 1)
            { LblPlazo.Text = "Plazo(Dias)"; }
            else if (CboTipo.SelectedIndex == 2)
            { LblPlazo.Text = "Plazo(Semana)"; }
            else if (CboTipo.SelectedIndex == 3)
            { LblPlazo.Text = "Plazo(Quincena)"; }
            else if (CboTipo.SelectedIndex == 4)
            { LblPlazo.Text = "Plazo(Mes)"; }
            else if (CboTipo.SelectedIndex == 5)
            { LblPlazo.Text = "Plazo(Mes)"; }
        }
    }
}


