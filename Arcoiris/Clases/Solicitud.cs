using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
namespace Arcoiris.Clases
{

    class Solicitud
    {
        conexion conect = new conexion();
        private DataTable buscar(string consulta)
        {
            conect.iniciar();
            DataTable datos = new DataTable();
            MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
            adap.Fill(datos);
            return datos;
        }
        private bool consulta_gen(string consulta)
        {
            conect.iniciar();
            MySqlCommand com1 = new MySqlCommand();
            com1.Connection = conect.conn;
            com1.CommandText = consulta;
            com1.CommandType = CommandType.Text;
            try
            {
                conect.conn.Open();
                com1.ExecuteNonQuery();
                conect.conn.Close();
            }

            catch (Exception ex)
            {
                conect.conn.Close();
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
                return false;
            }
            return true;
        }

        public int id_solicitud()
        {
            string consulta;
            consulta = "Select count(*) from solicitud";
            DataTable datos = new DataTable();

            datos = buscar(consulta);
            if (!DBNull.Value.Equals(datos.Rows[0][0]))
            {
                int id = Convert.ToInt32(datos.Rows[0][0]);
                id = ++id;
                return id;
            }
            else
            {
                return 0;
            }
        }

     

        public bool agregar_soli(string[] datos)
        {
            conect.iniciar();
            string consulta;
            string[] data = { datos[7],datos[0], datos[8] };
            string fecha = datos[3].ToString();
            fecha = DateTime.Now.ToString ("yyyy/MM/dd");
            consulta = "insert into solicitud (id_solicitud, concepto,monto,fecha, estado, plazo,garantia) values(" + datos[0] + ",'" + datos[1] + "'," + datos[2] + ",'" + fecha + "','" + datos[4] + "','" + datos[5] + "','" + datos[6] + "')";
            MessageBox.Show(consulta);
            MySqlCommand com = new MySqlCommand();
            com.Connection = conect.conn;
            com.CommandText = consulta;
            com.CommandType = CommandType.Text;


            try
            {
                conect.conn.Open();
                com.ExecuteNonQuery();

                conect.conn.Close();
                if (asinga_soli(data))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                conect.conn.Close();
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
                return false;

            }

        }
        public DataTable busca_soli_pend()
        {
            string consulta;
            consulta = "Select id_solicitud from solicitud where estado ='Espera'";
            DataTable datos = new DataTable();
            datos=buscar(consulta);
            return datos;
        }
        public DataTable busca_datos(string soli)
        {
            string consulta;
            consulta = "Select cli.Nombres as Nombre, ase.nombre as Asesor, sol.Concepto , Monto,plazo,garantia,Fecha " +  
"from Cliente cli inner join asigna_solicitud asol on asol.codigo_cli = cli.codigo_cli inner join Asesor ase on ase.cod_asesor = asol.cod_asesor inner join solicitud sol on sol.id_solicitud = asol.id_solicitud " +
"where sol.id_solicitud =" + soli;
            DataTable datos = new DataTable();
            datos=buscar(consulta);
            return datos;
        }


        private bool asinga_soli(string[] datos)
    {
        string consulta;
        consulta = "insert into asigna_solicitud (cod_asesor,id_solicitud,codigo_cli) values(" + datos[0] + "," + datos[1] + "," + datos [2] + ")" ;
            MySqlCommand com = new MySqlCommand();
            com.Connection = conect.conn;
            com.CommandText = consulta;
            com.CommandType = CommandType.Text;
            try
            {
                conect.conn.Open();
                com.ExecuteNonQuery();
                conect.conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en asignacion de solicitud");
                MessageBox.Show(ex.ToString());
                return false;
            }
    }

        //Cambiar estado

        public bool camb_estado(string[] datos)
        {
            string consulta;
            consulta = "Update solicitud set estado='Aprobado' where id_solicitud="+datos[0] ;
            if (consulta_gen(consulta))
            {
                if (crear_credi(datos))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Error a lactualizar estado dela solicitud");
                return false;
            }
        }

        private bool crear_credi(string[] datos)
        {
            string consultaid;
            consultaid = "Select count(*) from credito";
            DataTable credi = new DataTable();
            credi  = buscar(consultaid);
           int idcredito = Convert.ToInt32(credi.Rows[0][0]) +1;


            string consultaingcre;
            consultaingcre = "insert into Credito(cod_credito,id_tipo_credi, monto,plazo, interes, fecha_conc,fecha_venci, estado) values(" + idcredito +",0," + datos[1] + ",'" + datos[2] + "'," +  datos[3] + ",'" + datos[4] + "','" + datos[5] + "','Activo')";
           
            if (consulta_gen(consultaingcre))
            {
                if (asigna_credito(datos[0],idcredito ))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else {
                return false;
            }

        }

        private bool asigna_credito(string soli, int credito)
        {
            string consulta_asignacre;
            consulta_asignacre = "insert into asigna_credito(id_solicitud,cod_credito) values("+soli +"," +credito + ")" ;
            if (consulta_gen(consulta_asignacre))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

}
    }

