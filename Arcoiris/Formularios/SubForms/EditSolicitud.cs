using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcoiris.Formularios.SubForms
{
    partial class EditSolicitud : Form
    {
        private List<Formularios.SubClases.Cuenta> listaCuentas = new List<Formularios.SubClases.Cuenta>();
        public delegate void edicion(bool Doing);
        private bool Doing = false;
        public event edicion isDoing;
        Clases.Solicitud Soli = new Clases.Solicitud();
        Clases.Cliente Cli = new Clases.Cliente();
        Clases.ClAsesor Aseso = new Clases.ClAsesor();
        public Clases.Solicitud DatosSol { get; set; }
        public List<SubClases.Cuenta> DatosCue { get; set; }
        public List<SubClases.Ingreso> DatosIng { get; set; }
        public List<SubClases.Egreso> DatosEgr { get; set; }
        public List<SubClases.Fiador> DatosFia { get; set; }
        public List<SubClases.Garantia> DatosGar { get; set; }
        public int IdCli { get; set; }
        public int IdSol { get; set; }
        public int Nivel { get; set; }
        public int Credito { get; set; }



        public EditSolicitud()
        {
            InitializeComponent();
        }

        #region Cargas Individuales

        #endregion

        #region Carga general

        private void cargaClientes()
        {
            DataTable datoscli = new DataTable();

            datoscli = Cli.Buscar_nom_cli();

            DataTable datos2 = datoscli.Copy();
            DataTable Propis = datoscli.Copy();
            CboCliente.DataSource = datoscli;
            CboCliente.DisplayMember = "Nombre";
            CboCliente.ValueMember = "Codigo_Cli";
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
            CboPropi.AutoCompleteCustomSource = colecpropi;
            CboPropi.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboPropi.AutoCompleteSource = AutoCompleteSource.CustomSource;




            //Agregar cliente a inversiones



            //Agregar datos de asesores
            DataTable datosas = new DataTable();
            datosas = Aseso.busca_asesor_nom();
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


            //Lista de fiadores
            listCliFia();


            LblFecha.Text = "Fecha de solicitud: " + DateTime.Now.ToString("yyyy/MM/dd");
            TxtNoSol.Text = Soli.id_solicitud().ToString();
            CboTipo.Items.Add("Diario");
            CboTipo.Items.Add("Diario - Intereses");
            CboTipo.Items.Add("Semanal");
            CboTipo.Items.Add("Quincenal");
            CboTipo.Items.Add("Mensual - Cuota Fija");
            CboTipo.Items.Add("Mensual - Sobre Saldo");
            CboTipo.SelectedIndex = 0;
        }

        private void listCliFia()
        {
            DataTable listadocli = new DataTable();
            listadocli = Cli.AllCli();
            CboFiadNom.DataSource = listadocli;
            //  AllCli = listadocli;
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

        private void cargaSoli()
        {
            DataTable datosSol = Soli.datosGen2SoliAlter($"{IdSol}");
            TxtNoSol.Text = $"{IdSol}";
            CboCliente.SelectedValue = int.Parse($"{datosSol.Rows[0][10]}");
            CboAsesor.SelectedValue = int.Parse($"{datosSol.Rows[0][11]}");
            TxtConcept.Text = $"{datosSol.Rows[0][1]}";
            TxtMonto.Text = $"{datosSol.Rows[0][3]}";
            TxtMontoAprov.Text = $"{datosSol.Rows[0][3]}";

            LblFecha.Text = $"{datosSol.Rows[0][4]}";
            LblEstado.Text = $"{datosSol.Rows[0][5]}";
            NupPlazo.Value = decimal.Parse($"{datosSol.Rows[0][6]}");
            TxtInteresEdit.Text = $"{datosSol.Rows[0][6]}";

            TxtMontoSug.Text = $"{datosSol.Rows[0][7]}";
            TxtCredAqui.Text = $"{datosSol.Rows[0][8]}";


            CboTipo.SelectedValue = int.Parse($"{datosSol.Rows[0][9]}");

            if (datosSol.Rows[0][2].ToString().Equals("Emergencia"))
            {
                CboRazon.SelectedIndex = 0;
            }
            else if (datosSol.Rows[0][2].ToString().Equals("Mensual"))
            {
                CboRazon.SelectedIndex = 1;
            }
            else
            {
                CboRazon.SelectedIndex = 2;
            }

            if ($"{datosSol.Rows[0][5]}".Equals("Espera"))
            {
                // TxtMonto.Enabled = true;

            }
            else if ($"{datosSol.Rows[0][5]}".Equals("Autorizado"))
            {
                TxtMonto.Enabled = false;
                CboAsesor.Enabled = false;
                CboTipo.Enabled = false;
                TxtConcept.Enabled = false;
                GbxGarantia.Enabled = false;
                GbxFiadorIn.Enabled = false;
                TxtInteresEdit.Enabled = false;
            }
            else { }

            if ($"{datosSol.Rows[0][9]}" == "1")
            {
                CboTipo.SelectedIndex = 0;
            }
            else if ($"{datosSol.Rows[0][9]}" == "2")
            {
                CboTipo.SelectedIndex = 1;
            }
            else if ($"{datosSol.Rows[0][9]}" == "3")
            {
                CboTipo.SelectedIndex = 4;
            }
            else if ($"{datosSol.Rows[0][9]}" == "4")
            {
                CboTipo.SelectedIndex = 5;
            }
            else if ($"{datosSol.Rows[0][9]}" == "5")
            {
                CboTipo.SelectedIndex = 2;
            }
            else if ($"{datosSol.Rows[0][9]}" == "6")
            {
                CboTipo.SelectedIndex = 3;
            }

        }

        private void cargaCuenta()
        {
               listaCuentas.Clear();
             LstCuentas.Items.Clear();
            LstPasiv.Items.Clear();
            DataTable datosCuent = Soli.CuentaSol($"{IdSol}");
            int filas = datosCuent.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                agregarCuentaEdita($"{datosCuent.Rows[i][0]}", decimal.Parse($"{datosCuent.Rows[i][1]}"), bool.Parse($"{datosCuent.Rows[i][2]}"), int.Parse($"{datosCuent.Rows[i][3]}"));
            }
        }

        private void cargaCuentaModif()
        {
            List<Formularios.SubClases.Cuenta> Tempo = new List<SubClases.Cuenta>();
            Tempo = listaCuentas.ToList();
            listaCuentas.Clear();
            LstCuentas.Items.Clear();
            LstPasiv.Items.Clear();
            for (int i = 0; i < Tempo.Count; i++)
            {
                agregarCuentaEdita(Tempo[i].NomCuenta, Tempo[i].Valor, Tempo[i].tipo, Tempo[i].Id);
            }
        }



        private void cargaIngreso()
        {
            DgvIngMen.Rows.Clear();
            DataTable datosIngre = Soli.IngresoSol($"{IdSol}");
            int filas = datosIngre.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                DgvIngMen.Rows.Add($"{datosIngre.Rows[i][1]}", $"{datosIngre.Rows[i][0]}", $"{datosIngre.Rows[i][2]}", $"{datosIngre.Rows[i][3]}", $"{datosIngre.Rows[i][4]}", $"{datosIngre.Rows[i][5]}");//falta meter codigo para actualizar
            }
        }

        private void cargaEgreso()
        {
            DgvEngMen.Rows.Clear();
            DataTable datosEgre = Soli.EgresoSol($"{IdSol}");
            int filas = datosEgre.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                DgvEngMen.Rows.Add($"{datosEgre.Rows[i][1]}", $"{datosEgre.Rows[i][0]}", $"{datosEgre.Rows[i][2]}", $"{datosEgre.Rows[i][3]}", $"{datosEgre.Rows[i][4]}"); //falta meter codigo para actualizar
            }
        }

        private void cargaFiador()
        {
            DataTable datosFia = Soli.FiadAllSol($"{IdSol}");
            int filas = datosFia.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                DgvFiadorLst.Rows.Add($"{datosFia.Rows[i][0]}", $"{datosFia.Rows[i][1]}", $"{datosFia.Rows[i][3]}", $"{datosFia.Rows[i][8]}", 1); // falta meter codigo de cliente para futuros datos actualizados
            }
        }

        private void cargarGarantia()
        {
            DataTable datosGarant = Soli.GarantbyCliSol($"{IdSol}", $"{IdCli}");
            int filas = datosGarant.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                DgvGaranLSt.Rows.Add($"{datosGarant.Rows[i][0]}", $"{datosGarant.Rows[i][1]}", $"{datosGarant.Rows[i][2]}", $"{datosGarant.Rows[i][3]}", $"{datosGarant.Rows[i][4]}", $"{datosGarant.Rows[i][5]}", $"{datosGarant.Rows[i][6]}", $"{datosGarant.Rows[i][7]}"); // falta meter codigo de cliente para futuros datos actualizados
            }
        }
        #endregion

        #region Actualizacion General
        private void updateSoli()
        {
            // 1. Variables para almacenar los valores convertidos
            decimal montoValidado;
            int plazoValidado;
            string tipo;
            string IdSol;
            string IdClie;
            string IdAse;


            // 2. Validación en cascada
            if (string.IsNullOrWhiteSpace(TxtConcept.Text))
            {
                MessageBox.Show("El concepto no puede estar vacío.");
                return;
            }
            else if (!decimal.TryParse(TxtMonto.Text, out montoValidado))
            {
                MessageBox.Show("El monto debe ser un número válido (ej: 1500.50).");
                return;
            }

            else if (!int.TryParse(NupPlazo.Value.ToString(), out plazoValidado))
            {
                MessageBox.Show("El plazo debe ser un número entero.");
                return;
            }
            IdSol = $"{TxtNoSol.Text}";
            IdAse = $"{CboAsesor.SelectedValue}";
            IdClie = $"{CboCliente.SelectedValue}";

            var mapaTipos = new Dictionary<int, string>
{
    { 2, "5" }, { 3, "6" }, { 4, "3" }, { 5, "4" }
};
            // Lógica de asignación
            if (CboTipo.SelectedIndex == 0) tipo = "1";
            else if (CboTipo.SelectedIndex == 1) tipo = "2";
            else if (mapaTipos.TryGetValue(CboTipo.SelectedIndex, out string valor))
            {
                tipo = valor;
            }
            else
            {
                tipo = "0"; // Fallback
            }
            string[] soli = { TxtConcept.Text.Trim(), montoValidado.ToString("F2"), plazoValidado.ToString(), tipo, IdSol, IdAse, IdClie };

            Doing = true;
        }

        private void EstadoFinanciero()
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
                // 1. Evitar errores si la fila está vacía (común al final de un DataGridView)
                if (item.IsNewRow) continue;

                // 2. Obtener valores de las celdas (manejando posibles nulos)
                var val0 = item.Cells[0].Value?.ToString();
                var val1 = item.Cells[1].Value?.ToString();
                var val2 = item.Cells[2].Value?.ToString();
                var val3 = item.Cells[3].Value?.ToString();
                var val4 = item.Cells[4].Value?.ToString();
                var val5 = item.Cells[5].Value?.ToString();


                // 3. Comprobaciones de validación
                bool esInt1Valido = int.TryParse(val1, out _);
                bool esInt2Valido = int.TryParse(val5, out _);
                bool esString1Valido = !string.IsNullOrWhiteSpace(val0);
                bool esDecimal1Valido = decimal.TryParse(val2, out _);
                bool esDecimal2Valido = decimal.TryParse(val3, out _);
                bool esDecimal3Valido = decimal.TryParse(val4, out _);

                // 4. Solo si todo es válido, se agregan a la lista
                if (esInt1Valido && esString1Valido && esDecimal1Valido && esDecimal2Valido && esDecimal3Valido && esInt2Valido)
                {
                    SubClases.Ingreso temp = new SubClases.Ingreso();
                    temp.Producto = val0;
                    temp.Cantidad = int.Parse(val1);
                    temp.Costo = decimal.Parse(val2);
                    temp.Venta = decimal.Parse(val3);
                    temp.Ganacia = decimal.Parse(val4);
                    temp.Id = int.Parse(val5);
                    ingresos.Add(temp);

                }
                else
                {
                    MessageBox.Show($"La fila {item.Index} de ingresos posee un valor invalido, verifique porfavor", "Valor invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Doing = false; //omitir este return para revision 
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
                var valE4 = string.IsNullOrWhiteSpace(item.Cells[4].Value?.ToString())
         ? "0"
         : item.Cells[4].Value.ToString();


                // 3. Comprobaciones de validación
                bool esIntValido = int.TryParse(valE1, out _);
                bool esInt2Valido = int.TryParse(valE4, out _);
                bool esString1Valido = !string.IsNullOrWhiteSpace(valE0);
                bool esString2Valido = !string.IsNullOrWhiteSpace(valE2);
                bool esDecimalValido = decimal.TryParse(valE3, out _);

                // 4. Solo si todo es válido, se agregan a la lista
                if (esIntValido && esString1Valido && esString2Valido && esDecimalValido && esInt2Valido)
                {
                    SubClases.Egreso TempE = new SubClases.Egreso();
                    TempE.Detalle = valE0;
                    TempE.Cantidad = int.Parse(valE1);
                    TempE.Empresa = valE2;
                    TempE.Cuota_men = decimal.Parse(valE3);
                    TempE.Id = int.Parse(valE4);
                    egresos.Add(TempE);
                }
                else
                {
                    MessageBox.Show($"La fila {item.Index + 1} de egresos posee un valor invalido, verifique porfavor", "Valor invalida", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Doing = false;
                }
            }
            int CantIngre = ingresos.Count;
            int CantEgre = egresos.Count;
            bool cuentasingre = (LstCuentas.Items.Count > 0 || LstPasiv.Items.Count > 0) ? Soli.IngresoEstadoFinan(listaCuentas, TxtNoSol.Text) : true;
            bool IngreResp = CantIngre > 0 ? Soli.IngresoMen(ingresos, TxtNoSol.Text) : true;
            bool EgreResp = CantEgre > 0 ? Soli.EgresoMen(egresos, TxtNoSol.Text) : true;

            Doing = (( cuentasingre && IngreResp && EgreResp));
            if (Doing)
            {
               
                MessageBox.Show("El estado financiero ha sido actualizado",
                               "Exito",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
            cargaCuenta();
            cargaIngreso();
            cargaEgreso();
        }

        private void updateFiador()
        {
            List<SubClases.Fiador> IngFiad = new List<SubClases.Fiador>();
            foreach (DataGridViewRow fila in DgvFiadorLst.Rows)
            {
                SubClases.Fiador temp = new SubClases.Fiador();
                temp.idSol = int.Parse($"{TxtNoSol.Text}");
                temp.IdFiad = int.Parse($"{fila.Cells[0].Value}");
                temp.OtherIng = $"{fila.Cells[3].Value}";
                temp.procc = $"{fila.Cells[4].Value}" != "0";
                IngFiad.Add(temp);
            }
            Doing = (Soli.ingresoFiador(IngFiad));// enviar un identificador de que es para actualizar o para ingresar
            if (Doing)
            {
                MessageBox.Show("Los datos de fiador han sido actualizados",
                               "Exito",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information);
            }
        }

        private void updaterGarantia()
        {
            List<SubClases.Garantia> IngGar = new List<SubClases.Garantia>();
            foreach (DataGridViewRow fila in DgvGaranLSt.Rows)
            {
                SubClases.Garantia temp = new SubClases.Garantia();
                temp.Id = int.Parse($"{fila.Cells[7].Value}"); // debeser id de garantia o 0 para que se ingrese como nuevo
                temp.Propietario = int.Parse($"{fila.Cells[0].Value}");
                temp.Tipo = $"{fila.Cells[2].Value}";
                temp.Detalle = ($"{fila.Cells[3].Value}");
                temp.Valor = decimal.Parse($"{fila.Cells[4].Value}");
                temp.Informacion = ($"{fila.Cells[5].Value}");
                temp.Observaciones = ($"{fila.Cells[6].Value}");
                IngGar.Add(temp);
            }
            Doing = ((Soli.ingresoGarantia(IngGar, TxtNoSol.Text)));
            if (Doing)
            { MessageBox.Show("Garantias actualizadas", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information); }
            else
            { MessageBox.Show("Garantias no actualizadas", "revisar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }

        }

        private void DeleteGarantia()
        {
            int indice = DgvGaranLSt.CurrentRow.Index;
            if (indice > -1)
            {
                string id = $"{DgvGaranLSt.Rows[indice].Cells[7]}";
                if (id.Equals("0"))
                {
                    DgvGaranLSt.Rows.RemoveAt((indice));
                }
                else
                {
                    int idsol = int.Parse(TxtNoSol.Text);
                    if (Soli.deleteGarant(idsol))
                    {
                        MessageBox.Show("El fiador fue eliminiado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DgvGaranLSt.Rows.RemoveAt(indice);
                    }
                    else
                    { MessageBox.Show("No fue posible eliminar el fiador", "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
            }
        }

        private void DeleteFiador ()
        {
            int indice = DgvFiadorLst.CurrentRow.Index;
            if (indice > -1)
            {
                string idestado = $"{DgvFiadorLst.Rows[indice].Cells[4].Value}";
                int idfiad = int.Parse($"{DgvFiadorLst.Rows[indice].Cells[0].Value}");
                if (idestado.Equals("0"))
                {
                    DgvFiadorLst.Rows.RemoveAt((indice));
                }
                else
                {
                    int idsol = int.Parse(TxtNoSol.Text);
                    if (Soli.deleteFiadSol(idsol, idfiad))
                    { MessageBox.Show("El fiador fue eliminiado", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DgvFiadorLst.Rows.RemoveAt(indice);
                    }
                    else
                    { MessageBox.Show("No fue posible eliminar el fiador", "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); }
                }
            }
        }



        #endregion

        private void EditSolicitud_Load(object sender, EventArgs e)
        {
            cargaClientes();
            //Clases.Estilos.StyleForm(this);
            Clases.Estilos.StylePrimaryButton(BtnUpdEstFin);
            // Configurar el DrawMode
            TCTSoli.DrawMode = TabDrawMode.OwnerDrawFixed;
            TCTSoli.DrawItem += TCTSoli_DrawItem;

            // Ajustar el tamaño de las pestañas
            AjustarTamanioPestaniasSegunTexto();
            cargaSoli();
            cargaCuenta();
            cargaIngreso();
            cargaEgreso();
            cargarGarantia();
            cargaFiador();

        }


        private void agregarCuentaEdita(string Nombre, decimal valore, bool tipo, int idc)
        {

            // Crear nueva cuenta
            string NombreC = "";

            SubClases.Cuenta nuevaCuenta = new Formularios.SubClases.Cuenta
            {
                NomCuenta = Nombre,
                Valor = valore,
                tipo = tipo,// Convierte a int
                Id = idc
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

        #region Estilos
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
        #endregion



        private void BtnEditar_Click(object sender, EventArgs e)
        {
            EdtiarDatosSoli();
        }

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
            DgvGaranLSt.Rows.Add(IdProp, prop, Tipo, detalle, String.Format("{0:0,000.00}", numtemp), Info, observacion, "0");
        }

        private void BtnAddLstFiad_Click(object sender, EventArgs e)
        {
            //primera parte: comprovacion de datos
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
            DataTable DatosF = Cli.clientebusca(IdFiad);
            string Domi = $"{DatosF.Rows[0][2]}";

            DgvFiadorLst.Rows.Add(IdFiad, Nombre, Domi, Otros, "0");
        }

        private void BtnUpGarantEdit_Click(object sender, EventArgs e)
        {
            updaterGarantia();
        }

        private void UpdFiadEdit_Click(object sender, EventArgs e)
        {
            updateFiador();
        }

        private void BtnUpdEstFin_Click(object sender, EventArgs e)
        {
            EstadoFinanciero();
        }

        private void CboPropi_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboPropi.SelectedValue != null && !CboPropi.SelectedValue.ToString().Equals("System.Data.DataRowView") && DgvGaranLSt.Rows.Count > 0)
            {
                string esta = CboPropi.SelectedValue.ToString();
                int indice = DgvGaranLSt.CurrentRow.Index;

                DialogResult resp = MessageBox.Show("Desea modificar el propietario de esta garantia", "Cambiar propietario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    DgvGaranLSt.Rows[indice].Cells[0].Value = CboPropi.SelectedValue.ToString();
                    DgvGaranLSt.Rows[indice].Cells[1].Value = CboPropi.Text;
                }


            }


        }

        private void EditSolicitud_FormClosing(object sender, FormClosingEventArgs e)
        {
            isDoing(Doing);
        }

        private void EdtiarDatosSoli()
        {
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

            string monto = TxtMontoAprov.Text;
            string aseso = $"{CboAsesor.SelectedValue}";
            string clien = $"{CboCliente.SelectedValue}";
            string concep = $"{TxtConcept.Text}";
            string razon = CboRazon.Text;
            string sugerido = TxtMontoSug.Text;
            string credaqui = TxtCredAqui.Text;
            string Fecha = "";//DateTime.Parse(LblFecha.Text).ToString("yyyy/MM/dd");
            string solicitudNum = TxtNoSol.Text;
            string inte = TxtInteresEdit.Text;

            //string garant=


            string[] datos = { solicitudNum, concep, razon, monto, Fecha, LblEstado.Text, plazo, sugerido, credaqui, tipo, inte };
            if (Soli.editarSolPre(datos))
            {
                MessageBox.Show("Se actualizaron los datos de la soliciud", "Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Doing = true;
            }
            else
            {
                MessageBox.Show("No se pudo actualizar los datos de la soliciud", "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Doing = false;
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
                tipo = !(CboCuenta.SelectedItem.ToString().Equals("Prestamos"))// Convierte a int
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
            if (LstCuentas.SelectedIndex == -1 && LstPasiv.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un elemento para eliminar",
                               "Advertencia",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            // Confirmar eliminación
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea modificar el valor de esta cuenta seleccionada?",
                "Confirmar cambio",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                SubClases.Cuenta cuentaSeleccionada;

                if (LstCuentas.SelectedIndex == -1)
                {
                    cuentaSeleccionada = (SubClases.Cuenta)LstPasiv.SelectedItem;
                }
                else
                {
                    cuentaSeleccionada = (SubClases.Cuenta)LstCuentas.SelectedItem;
                }

                // Actualizar el valor
                cuentaSeleccionada.Valor = NudMontoCuenta.Value;

                // Buscar y reemplazar en la lista (si es necesario)
                int index = listaCuentas.FindIndex(c => c.Id == cuentaSeleccionada.Id); // Asumiendo que Cuenta tiene un Id
                if (index >= 0)
                {
                    listaCuentas[index] = cuentaSeleccionada;
                }


                // Eliminar del ListBox
                //LstCuentas.Items.RemoveAt(LstCuentas.SelectedIndex);

                // Opcional: También eliminar de la lista auxiliar
                //  listaCuentas.Remove(cuentaSeleccionada);

                MessageBox.Show("La cuenta fue modificada correctamente",
                                "Éxito",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void calcEstadoFin()
        {
            decimal total = 0.00M;
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

        private void BtnElimCuenta_Click(object sender, EventArgs e)
        {
            EliminarCuenta();
            cargaCuentaModif();
            calcEstadoFin();

        }

        private void LstCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            LstPasiv.SelectedIndex = -1;
        }

        private void LstPasiv_SelectedIndexChanged(object sender, EventArgs e)
        {
            LstCuentas.SelectedIndex = -1;
        }

        private void BtnDelLstGarant_Click(object sender, EventArgs e)
        {
            DeleteGarantia();
        }

        private void BtnDelLstFiad_Click(object sender, EventArgs e)
        {
            DeleteFiador();
        }
    }
}
