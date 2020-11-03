using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Arcoiris.Formularios
{
    public partial class FormRep : Form
    {

        Clases.Cliente cli = new Clases. Cliente();
        Clases.ClAsesor ase = new Clases.ClAsesor();
        Reportes.LlenarReport Rep = new Reportes.LlenarReport();
        private List<Reportes.RepDetalle1 > detall = new List<Reportes.RepDetalle1>();
        private List<Reportes.RepEnc > encabezado = new List<Reportes.RepEnc >();
        private List<Reportes.RepDesem> detalle = new List<Reportes.RepDesem>();
        private List<Reportes.RepDetCli > detalleCli = new List<Reportes.RepDetCli>();

        public FormRep()
        {
            InitializeComponent();
        }
      

        private void FormRep_Load(object sender, EventArgs e)
        {

            Fechas();
            Verclientes();
            verasesores();
            this.ReportG.RefreshReport();
            this.ReportD.RefreshReport();
            this.ReporteC.RefreshReport();
        }

        #region "Mostrar"
        private void Verclientes()
        {
            int total;
            DataTable clientes = new DataTable();
            clientes = cli.Buscar_nom_cli();
            total = clientes.Rows.Count;



            CboClientes.DataSource = clientes;
            CboClientes.DisplayMember = "Nombre";
            CboClientes.ValueMember = "Codigo_cli";

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in clientes.Rows)
            {
                coleccion.Add(row["Nombre"].ToString());

            }
            CboClientes.AutoCompleteCustomSource = coleccion;
            CboClientes.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboClientes.AutoCompleteSource = AutoCompleteSource.CustomSource;


        }

        private void verasesores()
        {



            DataTable asesores = new DataTable();
            asesores = ase.busca_asesor_nom();

            CboAsesor.DataSource = asesores;
            CboAsesor.DisplayMember = "Nombre";
            CboAsesor.ValueMember = "Codigo";

            AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            foreach (DataRow row in asesores.Rows)
            {
                coleccion.Add(row["Nombre"].ToString());

            }
            CboAsesor.AutoCompleteCustomSource = coleccion;
            CboAsesor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            CboAsesor.AutoCompleteSource = AutoCompleteSource.CustomSource;

        }
        #endregion

        #region "Grafico"
        private void ChkClientes_CheckedChanged(object sender, EventArgs e)
        {
            /*if (ChkClientes.Checked)
            {
                TmrMostrar.Enabled = true;
            }
            else 
            {
                TmrOcultar.Enabled = true;
            }*/


        }

        private void TmrMostrar_Tick(object sender, EventArgs e)
        {
            int val;
            if (ChkClientes.Checked)
            {
                val = PanelCli.Height;
                if (PanelCli.Height >= 60)
                {
                 
                    
                    TmrMostrar.Enabled = false;
                }
                else
                {
                    val += 5;
                    PanelCli.Height = val;
                }
            }
            if (ChkAsesor.Checked)
            {
                val = PanelAseso .Height;
                if (PanelAseso.Height >= 60)
                {
                    PanelCli.Height = 30;
                    TmrMostrar.Enabled = false;
                }
                else
                {
                    val += 5;
                    PanelAseso.Height  = val;
                }
            }
        }

        private void TmrOcultar_Tick(object sender, EventArgs e)
        {
            int val;
            if (!ChkClientes.Checked)
            {
                val = PanelCli.Height;
                if (PanelCli.Height <= 30 )
                {

                    TmrOcultar.Enabled = false;
                }
                else
                {
                    val -= 5;
                    PanelCli.Height = val;
                }
            }
            if (!ChkAsesor.Checked)
            {
                val = PanelAseso.Height;
                if (PanelAseso.Height <= 30)
                {
                    TmrOcultar.Enabled = false;
                }
                else
                {
                    val -= 5;
                    PanelAseso.Height = val;
                }

            }
        }

        private void ChkAsesor_CheckedChanged(object sender, EventArgs e)
        {
            /*if (ChkAsesor.Checked)
            {
                TmrMostrar.Enabled = true;
            }
            else
            {
                TmrOcultar.Enabled = true;
            }*/
        }

        private void BtnVerRep_Click(object sender, EventArgs e)
        {
     
            
            if (ChkClientes.Checked && ChkAsesor.Checked)
            {
                RepAsesorCliente();
              
            }
            else if(ChkClientes.Checked)
                {
                RepCliente();
            }
            else if (ChkAsesor.Checked)
            {
                RepAsesor();
                
            }
        }
        private void BtnGanacia_Click(object sender, EventArgs e)
        {
            Ganancias();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnDesem_Click(object sender, EventArgs e)
        {
            desembolso();
        }

        private void BtnRep_Click(object sender, EventArgs e)
        {
            repGeneral();
        }

        #endregion


        #region "Fechas"
        private void Fechas()
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
            int cont;
            for (cont = 2020; cont <= 2030; cont++)
            {
                CboAnio.Items.Add(cont);
            }
            CboMes.SelectedIndex = 0;
            CboAnio.SelectedIndex = 0;
        }


        private string FechaI(string Mes,string anio)
        {
            string fecha;
         
            string Mmes="";
            

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
                    Ddia = "30";
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
            fecha = anio + "/" + Mmes + "/"+ Ddia ;
            return fecha;
        }
        #endregion
       

        #region "Reportes"
        private void repGeneral()
        {
            Reporte.Visible = true;
            ReporteC.Visible = false;
            ReportG.Visible = false;
            ReportD.Visible = false;
            string fechI = FechaI(CboMes.Text, CboAnio.Text);
            string fechF = FechaF(CboMes.Text, CboAnio.Text);
            Reportes.RepEnc enca = new Reportes.RepEnc();
            enca.Titulo = "Reporte General";
            enca.periodo = CboMes.Text + " de " + CboAnio.Text;
            string consulta = "SELECT C.Nombres,C.Apellidos,Cre.Cod_credito,Cre.monto,Cre.Fecha_conc,A.Nombre AS Asesoro FROM cliente C " +
            "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = C.CODIGO_CLI " +
            "INNER JOIN asesor A ON A.COD_ASESOR = asol.COD_ASESOR " +
            "INNER JOIN asigna_credito Acre ON Acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "INNER JOIN credito Cre ON Cre.COD_CREDITO = Acre.COD_CREDITO " +
            "WHERE Cre.FECHA_CONC>='" + fechI + "'AND Cre.FECHA_CONC<='" + fechF + "'";

            DataTable datos = new DataTable();
            datos = Rep.Reporte_general(consulta);
            int total;
            total = datos.Rows.Count;
            int cont;
            for (cont = 0; cont <= total - 1; cont++)
            {
                Reportes.RepDetalle1 deta = new Reportes.RepDetalle1();

                deta.ClienteN = datos.Rows[cont][0].ToString();
                deta.ClienteA = datos.Rows[cont][1].ToString();
                deta.Credito = datos.Rows[cont][2].ToString();
                deta.Monto = Convert.ToDecimal(datos.Rows[cont][3].ToString());


                deta.Fecha = datos.Rows[cont][4].ToString();
                deta.Asesor = datos.Rows[cont][5].ToString();
                enca.detalle.Add(deta);
            }
            encabezado.Add(enca);

            this.Reporte.LocalReport.DataSources.Clear();
            ReportParameter[] parametros = new ReportParameter[2];
            this.Reporte.LocalReport.DataSources.Add(new ReportDataSource("DetalleRep", enca.detalle));
            this.Reporte.LocalReport.DataSources.Add(new ReportDataSource("encabezado", encabezado));


            this.Reporte.RefreshReport();
        }

        private void RepAsesorCliente()
        {
            Reporte.Visible = true;
            ReporteC.Visible = false;
            ReportG.Visible = false;
            ReportD.Visible = false;
            string fechI = FechaI(CboMes.Text, CboAnio.Text);
            string fechF = FechaF(CboMes.Text, CboAnio.Text);
            Reportes.RepEnc enca = new Reportes.RepEnc();

            
            string consulta = "";
            consulta = "SELECT C.Nombres,C.Apellidos,Cast(Cre.Cod_credito as int) as codigo,Cre.monto,Cre.Fecha_conc as Fecha,A.Nombre AS Asesoro FROM cliente C " +
              "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = C.CODIGO_CLI " +
              "INNER JOIN asesor A ON A.COD_ASESOR = asol.COD_ASESOR " +
              "INNER JOIN asigna_credito Acre ON Acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
              "INNER JOIN credito Cre ON Cre.COD_CREDITO = Acre.COD_CREDITO " +
              "WHERE C.CODIGO_CLI =" + CboClientes.SelectedValue + " AND A.COD_ASESOR =" + CboAsesor.SelectedValue +
              " And Cre.FECHA_CONC >= '" + fechI + "'AND Cre.FECHA_CONC <= '" + fechF + "' order by codigo";


            DataTable datos = new DataTable();
            datos = Rep.Reporte_general(consulta);
            int total;
            total = datos.Rows.Count;
            int cont;
            for (cont = 0; cont <= total - 1; cont++)
            {
                Reportes.RepDetalle1 deta = new Reportes.RepDetalle1();

                deta.ClienteN = datos.Rows[cont][0].ToString();
                deta.ClienteA = datos.Rows[cont][1].ToString();
                deta.Credito = datos.Rows[cont][2].ToString();
                deta.Monto = Convert.ToDecimal(datos.Rows[cont][3].ToString());


                deta.Fecha = datos.Rows[cont][4].ToString();
                deta.Asesor = datos.Rows[cont][5].ToString();
                enca.detalle.Add(deta);
            }
            encabezado.Clear();
            enca.periodo = CboMes.Text + " de " + CboAnio.Text;
            enca.Titulo = "Reporte de Asesor: " + CboAsesor.Text + "\nY Cliente: " + CboClientes.Text;
            encabezado.Add(enca);
           
            this.Reporte.LocalReport.DataSources.Clear();
            this.Reporte.LocalReport.DataSources.Add(new ReportDataSource("DetalleRep", enca.detalle));
            this.Reporte.LocalReport.DataSources.Add(new ReportDataSource("encabezado", encabezado));
       
            this.Reporte.RefreshReport();

        }

        private void RepCliente()
        {
            Reporte.Visible = true;
            ReporteC.Visible = false;
            ReportG.Visible = false;
            ReportD.Visible = false;
            string fechI = FechaI(CboMes.Text, CboAnio.Text);
            string fechF = FechaF(CboMes.Text, CboAnio.Text);
            Reportes.RepEnc enca = new Reportes.RepEnc();

            enca.periodo = CboMes.Text + " de " + CboAnio.Text;
            string consulta = "";
            consulta = "SELECT C.Nombres,C.Apellidos,Cre.Cod_credito,Cre.monto,Cre.Fecha_conc as Fecha,A.Nombre AS Asesoro FROM cliente C " +
            "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = C.CODIGO_CLI " +
            "INNER JOIN asesor A ON A.COD_ASESOR = asol.COD_ASESOR " +
            "INNER JOIN asigna_credito Acre ON Acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "INNER JOIN credito Cre ON Cre.COD_CREDITO = Acre.COD_CREDITO " +
           " where C.CODIGO_CLI = " + CboClientes.SelectedValue + " and Cre.FECHA_CONC >= '" + fechI + "'AND Cre.FECHA_CONC <= '" + fechF + "'"; 


            DataTable datos = new DataTable();
            datos = Rep.Reporte_general(consulta);
            int total;
            total = datos.Rows.Count;
            int cont;
            for (cont = 0; cont <= total - 1; cont++)
            {
                Reportes.RepDetalle1 deta = new Reportes.RepDetalle1();

                deta.ClienteN = datos.Rows[cont][0].ToString();
                deta.ClienteA = datos.Rows[cont][1].ToString();
                deta.Credito = datos.Rows[cont][2].ToString();
                deta.Monto = Convert.ToDecimal(datos.Rows[cont][3].ToString());


                deta.Fecha = datos.Rows[cont][4].ToString();
                deta.Asesor = datos.Rows[cont][5].ToString();
                enca.detalle.Add(deta);
            }
            encabezado.Clear();
            encabezado.Add(enca);
            enca.Titulo = "Reporte por Cliente: " + CboClientes.Text;
            this.Reporte.LocalReport.DataSources.Clear();
            this.Reporte.LocalReport.DataSources.Add(new ReportDataSource("DetalleRep", enca.detalle));
            this.Reporte.LocalReport.DataSources.Add(new ReportDataSource("encabezado", encabezado));
            this.Reporte.RefreshReport();
        }
        private void RepAsesor()
        {
            Reporte.Visible = true;
            ReporteC.Visible = false;
            ReportG.Visible = false;
            ReportD.Visible = false;
            string fechI = FechaI(CboMes.Text, CboAnio.Text);
        string fechF = FechaF(CboMes.Text, CboAnio.Text);
        Reportes.RepEnc enca = new Reportes.RepEnc();
        enca.periodo = CboMes.Text + " de " + CboAnio.Text;
        string consulta = "";
            consulta = "SELECT C.Nombres,C.Apellidos,Cre.Cod_credito,Cre.monto,Cre.Fecha_conc as Fecha,A.Nombre AS Asesoro FROM cliente C " +
            "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = C.CODIGO_CLI " +
            "INNER JOIN asesor A ON A.COD_ASESOR = asol.COD_ASESOR " +
            "INNER JOIN asigna_credito Acre ON Acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "INNER JOIN credito Cre ON Cre.COD_CREDITO = Acre.COD_CREDITO " +
            "WHERE  A.COD_ASESOR =" + CboAsesor.SelectedValue + " and Cre.FECHA_CONC >= '" + fechI + "'AND Cre.FECHA_CONC <= '" + fechF + "'";


         DataTable datos = new DataTable();
          datos = Rep.Reporte_general(consulta);
            int total;
            total = datos.Rows.Count;
            int cont;
            for (cont = 0; cont <= total - 1; cont++)
            {
                Reportes.RepDetalle1 deta = new Reportes.RepDetalle1();

                deta.ClienteN = datos.Rows[cont][0].ToString();
                deta.ClienteA = datos.Rows[cont][1].ToString();
                deta.Credito = datos.Rows[cont][2].ToString();
                deta.Monto = Convert.ToDecimal(datos.Rows[cont][3].ToString());


                deta.Fecha = datos.Rows[cont][4].ToString();
                deta.Asesor = datos.Rows[cont][5].ToString();
                enca.detalle.Add(deta);
            }
            encabezado.Clear();
            enca.Titulo = "Reporte por Asesor: " + CboAsesor.Text;
            encabezado.Add(enca);

            this.Reporte.LocalReport.DataSources.Clear();
            this.Reporte.LocalReport.DataSources.Add(new ReportDataSource("DetalleRep", enca.detalle));
            this.Reporte.LocalReport.DataSources.Add(new ReportDataSource("encabezado", encabezado));
            this.Reporte.RefreshReport();
        }

        private void Ganancias()
        {
            Reporte.Visible = false;
            ReporteC.Visible = false;
            ReportG.Visible = true;
            ReportD.Visible = false;
            string fechI = FechaI(CboMes.Text, CboAnio.Text);
            string fechF = FechaF(CboMes.Text, CboAnio.Text);
            Reportes.RepEnc enca = new Reportes.RepEnc();
            enca.periodo = CboMes.Text + " de " + CboAnio.Text;
            string consulta = "";
            consulta = "SELECT Cre.Cod_credito AS Codigo,concat(Cli. Nombres, ' ' , Cli.Apellidos) AS Nombre ,p.total, p.FECHA, SUM(P.interes+p.mora) AS Ganacia  FROM  pagos p " +
            "INNER JOIN credito cre ON cre.COD_CREDITO = p.COD_CREDITO " +
            "INNER JOIN asigna_credito acre ON acre.COD_CREDITO = cre.COD_CREDITO " +
            "INNER JOIN asigna_solicitud asol ON asol.ID_SOLICITUD = acre.ID_SOLICITUD " +
            "INNER JOIN cliente cli on asol.codigo_cli = cli.CODIGO_CLI " +
            "WHERE cre.FECHA_CONC >= '"+fechI +"' AND cre.FECHA_CONC <= '"+fechF +"' GROUP BY Codigo";



            DataTable datos = new DataTable();
            datos = Rep.Reporte_general(consulta);
            int total;
            total = datos.Rows.Count;
            int cont;
            decimal ganan=0;
            for (cont = 0; cont <= total - 1; cont++)
            {
                Reportes.RepDetalle1 deta = new Reportes.RepDetalle1();
                deta.Credito = datos.Rows[cont][0].ToString();
                deta.ClienteN = datos.Rows[cont][1].ToString();
                deta.Monto = Convert.ToDecimal(datos.Rows[cont][2].ToString());
                /*falta*/
                deta.ClienteA = "";

                deta.Fecha = datos.Rows[cont][3].ToString();
                
                deta.Asesor = datos.Rows[cont][4].ToString();
                ganan += Convert.ToDecimal(datos.Rows[cont][4].ToString());
                enca.detalle.Add(deta);
            }
            encabezado.Clear();
            enca.Titulo = "Reporte por Asesor: " + CboAsesor.Text;
            enca.total = ganan;
            encabezado.Add(enca);

            this.ReportG .LocalReport.DataSources.Clear();
            this.ReportG.LocalReport.DataSources.Add(new ReportDataSource("DetalleRep", enca.detalle));
            this.ReportG.LocalReport.DataSources.Add(new ReportDataSource("encabezado", encabezado));
            this.ReportG.RefreshReport();
        }

        private void desembolso()
        {

            Reporte.Visible = false ;
            ReporteC.Visible = false;
            ReportG.Visible = false;
            ReportD.Visible = true;
            string fechI = FechaI(CboMes.Text, CboAnio.Text);
            string fechF = FechaF(CboMes.Text, CboAnio.Text);
            Reportes.RepEnc enca = new Reportes.RepEnc();
            enca.periodo = CboMes.Text + " de " + CboAnio.Text;
            string consulta = "";
            consulta = "SELECT cli.nombres AS cliente, cast(cre.cod_credito AS int) AS credito, cre.monto, cre.gastos_admin, SUM(cre.monto-cre.gastos_admin) AS Desembolso " +
            "FROM credito cre " +
            "INNER JOIN asigna_credito acre ON acre.COD_CREDITO = cre.COD_CREDITO " +
            "INNER JOIN asigna_solicitud asol on acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "INNER JOIN cliente cli on cli.CODIGO_CLI = asol.codigo_cli " +
            "WHERE cre.FECHA_CONC >= '"+fechI +"' AND cre.FECHA_CONC <= '"+fechF +"' " +
            "GROUP BY credito ORDER BY credito";
            
            DataTable datos = new DataTable();
            datos = Rep.Reporte_general(consulta);
            int total;
            total = datos.Rows.Count;
            int cont;
            decimal desemt = 0;
            for (cont = 0; cont <= total - 1; cont++)
            {
                Reportes.RepDesem deta = new Reportes.RepDesem();
                deta.Cliente = datos.Rows[cont][0].ToString();
                deta.Credito= datos.Rows[cont][1].ToString();
                deta.Monto = Convert.ToDecimal(datos.Rows[cont][2].ToString());
                deta.GastosA = Convert.ToDecimal(datos.Rows[cont][3].ToString());
                deta.Desem  = Convert.ToDecimal(datos.Rows[cont][4].ToString());
                desemt+= Convert.ToDecimal(datos.Rows[cont][4].ToString());
                enca.detalleD.Add(deta);
            }
            encabezado.Clear();
            enca.Titulo = "Reporte por Asesor: " + CboAsesor.Text;
            enca.total = desemt ;
            encabezado.Add(enca);

            this.ReportD.LocalReport.DataSources.Clear();
            this.ReportD.LocalReport.DataSources.Add(new ReportDataSource("DesemDet", enca.detalleD));
            this.ReportD.LocalReport.DataSources.Add(new ReportDataSource("encabezado", encabezado));
            this.ReportD.RefreshReport();

        }

        private void RepClienteGen()
        {
            Reporte.Visible = false;
            ReporteC.Visible = true;
            ReportG.Visible = false;
            ReportD.Visible = false;
            string fechI = FechaI(CboMes.Text, CboAnio.Text);
            string fechF = FechaF(CboMes.Text, CboAnio.Text);
            Reportes.RepEnc enca = new Reportes.RepEnc();

            enca.periodo = CboMes.Text + " de " + CboAnio.Text;
            string consulta = "";
            consulta = "SELECT CONCAT(cli.nombres, ' ', Cli.Apellidos) AS Nombre, CAST(cre.cod_credito AS  int) AS No_Credito, p.ID_PAGO AS Pago,p.fecha, p.total,SUM(cre.saldo_cap) AS Saldo_capital " +
            "FrOM cliente cli " +
            "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI " +
            "INNER JOIN asigna_credito acre ON acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO " +
            "INNER JOIN pagos p ON p.COD_CREDITO = cre.COD_CREDITO " +
            "WHERE cli.CODIGO_CLI = '" + CboClientes.SelectedValue + "' AND cre.ESTADO = 'Activo' " +
            " GROUP BY p.fecha,pago,p.Total " +
            "ORDER BY fecha ";

            DataTable datos = new DataTable();
            datos = Rep.Reporte_general(consulta);

            if (datos.Rows .Count <=0)
            {
                MessageBox.Show("No existen Estados para mostrar");
            }
            else { int total;
                decimal SaldoT = 0;

                SaldoT = Convert.ToDecimal(datos.Rows[0][5]);

                int cod_cred = Convert.ToInt32(datos.Rows[0][1].ToString());
                total = datos.Rows.Count;
                int cont;
                for (cont = 0; cont <= total - 1; cont++)
                {
                    Reportes.RepDetCli deta = new Reportes.RepDetCli();
                    deta.Cliente = datos.Rows[cont][0].ToString();
                    deta.Credito = datos.Rows[cont][1].ToString();
                    deta.pago = datos.Rows[cont][2].ToString();
                    deta.Fecha = datos.Rows[cont][3].ToString();
                    deta.Total = Convert.ToDecimal(datos.Rows[cont][4].ToString());

                    enca.detalleC.Add(deta);

                    if (cod_cred != Convert.ToInt32(datos.Rows[cont][1]))
                    {
                        cod_cred = Convert.ToInt32(datos.Rows[cont][1]);
                        if (datos.Rows[cont][5] != DBNull.Value)
                        {
                            SaldoT += Convert.ToDecimal(datos.Rows[cont][5]);
                        }
                        else
                        {
                            SaldoT += 0;
                        }
                    }
                }
                encabezado.Clear();
                encabezado.Add(enca);
                enca.Titulo = "Reporte por Cliente: " + CboClientes.Text;
                enca.total = SaldoT;
                this.ReporteC.LocalReport.DataSources.Clear();
                this.ReporteC.LocalReport.DataSources.Add(new ReportDataSource("DetalleCli", enca.detalleC));
                this.ReporteC.LocalReport.DataSources.Add(new ReportDataSource("encabezado", encabezado));
                this.ReporteC.RefreshReport();
            }
        }
        #endregion

     
        private void BtnCli_Click(object sender, EventArgs e)
        {
            RepClienteGen();
        }
    }
}

