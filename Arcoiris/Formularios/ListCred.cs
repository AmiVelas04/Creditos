using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Arcoiris.Formularios
{
    public partial class ListCred : Form
    {
       public string cod_cli;
        public string nombre="";
        public delegate void permiso(string cli);
        public event permiso Mostrarcre;
        Clases.conexion conect = new Clases.conexion();
        public ListCred()
        {
            InitializeComponent();
        }

        private DataTable buscar(string consulta)
        {
            conect.iniciar();
            DataTable datos = new DataTable();
            try
            {

                MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
                adap.Fill(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
            }
            return datos;


        }
        private void ListCred_Load(object sender, EventArgs e)
        {
            string consulta;
            consulta = "SELECT Cre.Cod_credito AS Credito, cre.monto,cre.Fecha_conc , cre.Fecha_venci, cre.id_tipo_credito " +
                        "FROM credito cre " +
                        "INNER JOIN asigna_credito acre ON acre.COD_CREDITO = cre.COD_CREDITO " +
                        "INNER JOIN asigna_solicitud asol ON asol.ID_SOLICITUD = acre.ID_SOLICITUD " +
                        "INNER JOIN cliente cli ON cli.CODIGO_CLI = asol.codigo_cli " +
                        "WHERE cre.ESTADO = 'Activo' AND cli.CODIGO_CLI =" + cod_cli;
            DataTable datos =new  DataTable();
            DataTable resp = new DataTable();
            datos = buscar(consulta);

            resp.Columns.Add("Credito").DataType = Type.GetType("System.String");
            resp.Columns.Add("Monto").DataType = Type.GetType("System.String");
            resp.Columns.Add("Concesion").DataType = Type.GetType("System.String");
            resp.Columns.Add("Vencimiento").DataType = Type.GetType("System.String");
            resp.Columns.Add("Tipo").DataType = Type.GetType("System.String");
            int cont = 0,total= datos .Rows.Count;

            for (cont = 1; cont <= total; cont++)
            {
                string t = datos.Rows[cont - 1][4].ToString(), tipo="";
                if (t == "1")
                {tipo = "Diario"; }
                else if (t == "2")
                { tipo = "Diario Interes";   }
                else if(t == "3")
                    { tipo = "Mensual"; }
                else if(t == "4")
                { tipo = "Mensual Sobre saldo"; }



                DataRow fila = resp.NewRow();
                fila["Credito"] = datos.Rows[cont - 1][0].ToString();
                fila["Monto"] = "Q." + datos.Rows[cont - 1][1].ToString();
                fila["Concesion"] = Convert.ToDateTime (datos.Rows[cont - 1][2]).ToString ("dd/MM/yyyy");
                fila["Vencimiento"] = Convert.ToDateTime(datos.Rows[cont - 1][3]).ToString("dd/MM/yyyy");
                fila["Tipo"] = tipo;
                resp.Rows.Add(fila);
               

            }






            DgvCre.DataSource = resp ;
            DgvCre.Refresh();
            LblCant.Text = "Total de creditos: " + datos.Rows.Count;
            LblNom.Text = "Nombre del cliente: " + nombre;


        }

        private void BtnRef_Click(object sender, EventArgs e)
        {
            int indice = DgvCre.CurrentRow.Index;
            Mostrarcre(DgvCre.Rows[indice].Cells[0].Value.ToString ());
            this.Close();
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

