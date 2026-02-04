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
            DataTable datosSol = Soli.datosGen2Soli($"{IdSol}");
            TxtNoSol.Text = $"{IdSol}";
            CboCliente.SelectedValue = int.Parse($"{datosSol.Rows[0][1]}");
            CboAsesor.SelectedValue= int.Parse($"{datosSol.Rows[0][2]}");
            TxtMonto.Text = $"{datosSol.Rows[0][3]}";
            TxtConcept.Text = $"{datosSol.Rows[0][4]}";
            CboTipo.SelectedValue= int.Parse($"{datosSol.Rows[0][5]}");
        }

        private void cargaCuenta()
        {
            DataTable datosCuent = Soli.CuentaSol($"{IdSol}");
            int filas = datosCuent.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                agregarCuentaEdita($"{datosCuent.Rows[i][0]}",decimal.Parse($"{datosCuent.Rows[i][1]}"),bool.Parse($"{datosCuent.Rows[i][2]}"));
            }
        }

        private void cargaIngreso()
        { DataTable datosIngre = Soli.IngresoSol($"{IdSol}");
            int filas = datosIngre.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                DgvIngMen.Rows.Add($"{datosIngre.Rows[i][0]}", $"{datosIngre.Rows[i][1]}", $"{datosIngre.Rows[i][2]}", $"{datosIngre.Rows[i][3]}", $"{datosIngre.Rows[i][4]}");//falta meter codigo para actualizar
            }
        }

        private void cargaEgreso()
        { DataTable datosEgre = Soli.EgresoSol($"{IdSol}");
            int filas =  datosEgre.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                DgvEngMen.Rows.Add($"{datosEgre.Rows[i][0]}", $"{datosEgre.Rows[i][1]}", $"{datosEgre.Rows[i][2]}", $"{datosEgre.Rows[i][3]}"); //falta meter codigo para actualizar
            }
        }

        private void cargaFiador()
        {
            DataTable datosFia = Soli.FiadAllSol($"{IdSol}");
            int filas =datosFia.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
              DgvFiadorLst.Rows.Add($"{datosFia.Rows[i][1]}", $"{datosFia.Rows[i][1]}", $"{datosFia.Rows[i][2]}"); // falta meter codigo de cliente para futuros datos actualizados
            }
        }

        private void cargarGarantia()
        { DataTable datosGarant = Soli.GaratanbyCliSol($"{IdSol}", $"{IdCli}"); }
        #endregion

        #region Actualizacion General
        private void updateSoli()
        { }

        private void updateCuenta()
        { }

        private void updateIngreso()
        { }

        private void updateEgreso()
        { }

        private void updateFiador()
        { }

        private void updaterGarantia()
        { }



        #endregion

        private void EditSolicitud_Load(object sender, EventArgs e)
        {
            cargaClientes();
            //Clases.Estilos.StyleForm(this);
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



        private void agregarCuentaEdita(string Nombre,decimal valore, bool tipo)
        {
       
        

            // Crear nueva cuenta
            string NombreC = "";

            SubClases.Cuenta nuevaCuenta = new Formularios.SubClases.Cuenta
            {
                NomCuenta = Nombre,
                Valor = valore,
                tipo = tipo// Convierte a int
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
    }
}
