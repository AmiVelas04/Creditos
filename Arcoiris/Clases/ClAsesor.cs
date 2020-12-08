using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Arcoiris.Clases
{
    class ClAsesor

    {
        conexion conect = new conexion();

        private DataTable buscar(string consulta)
        {
            conect.iniciar();
            MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
            DataTable datos = new DataTable();
            adap.Fill(datos);
            return datos;
        }
        private int buscarid(string consulta)
        {

            conect.iniciar();
            DataTable datos = new DataTable();
            try
            {
                MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
                adap.Fill(datos);
                if (datos.Rows.Count >= 1)
                {
                    int val = Convert.ToInt32(datos.Rows[0][0].ToString());
                    return ++val;

                }
                else
                {
                    return 1;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }
           
        }

        public bool ingresar_asesor(string [] datos)
        {
            string consulta;
            consulta = "Select count(*) from asesor";
            int id = buscarid(consulta);
            string consultaing;
            consultaing = "insert into asesor (cod_asesor,nombre,telefono,direccion) values("+id+ ",'"+datos[0] + "','" + datos[1] + "','" + datos[2] +"')";
            
            MySqlCommand com = new MySqlCommand();
            com.Connection = conect.conn;
            com.CommandText = consultaing;
            com.CommandType = CommandType.Text;
            try {
                conect.conn.Open();
                com.ExecuteNonQuery();
                conect.conn.Close();
             
                return true;

            }
            catch (Exception ex)
            {
                conect.conn.Close();
                MessageBox.Show(ex.ToString());

                return false;
            }

        }

        //Busqueda de asesor

        public DataTable busca_asesor(string nom)
       {
            conect.iniciar();
            string consulta;
            consulta = "Select cod_asesor as Codigo, Nombre, Telefono, Direccion from asesor where Nombre like '%" + nom + "%'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;

        }
        public DataTable busca_asesor_nom()
        {
            DataTable datos = new DataTable();
            string consulta;
            consulta = "Select Nombre,Cod_asesor as Codigo from asesor";
            datos = buscar(consulta);
            return datos;
        }

        public int id_asesor(string nom)
        {
            DataTable datos = new DataTable();
            string consulta;
            consulta = "Select cod_asesor from asesor where nombre ='" + nom + "'";
            datos=buscar(consulta);
            if (!DBNull.Value.Equals(datos.Rows[0][0]))

            {
                return Convert.ToInt32 (datos.Rows[0][0]);
            }
            else
            {
                return 0;
            }

        }

        public string nom_aseso(string id)
        {
            DataTable datos = new DataTable();
            string consulta;
            consulta = "Select nombre from asesor where cod_asesor =" +id ;
            datos = buscar(consulta);
            return datos.Rows[0][0].ToString();

        }




    }



}
