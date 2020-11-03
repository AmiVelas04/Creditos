using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace Arcoiris.Clases
{
    class Usuario
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
        private bool Consulgeneral(string consulta)
        {
            MySqlCommand com = new MySqlCommand();
            com.Connection = conect.conn;
            com.CommandText = consulta;
            com.CommandType = System.Data.CommandType.Text;

            try
            {
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

        public DataTable bucarusu()
        {
            DataTable datos = new DataTable();
            string consulta;
            consulta = "SELECT cod_usuario, nombre,usuario,contrasenia, nivel " +
                       "FROM usuario " +
                       "WHERE cod_usuario != 1";
            datos = buscar(consulta);
            return datos;
        }


        public DataTable bucarusucod(string cod)
        {
            DataTable datos = new DataTable();
            string consulta;
            consulta = "SELECT cod_usuario, nombre,usuario,contrasenia, nivel " +
                       "FROM usuario " +
                       "WHERE cod_usuario =" + cod;
            datos = buscar(consulta);
            return datos;
        }

        public bool existe(string cod)
        {
            DataTable datos = new DataTable();
            string consulta;
            consulta = "SELECT cod_usuario, nombre,usuario,contrasenia, nivel " +
                       "FROM usuario " +
                       "WHERE cod_usuario =" + cod;
            datos = buscar(consulta);
            if (datos.Rows.Count > 0)
            { return true; }
            else
            { return false; }
            
        }

        public bool ingre(string[] datos)
        {
            string consulta;
            int cod=codigo();
            consulta = "insert into usuario(cod_usuario,nombre,usuario,contrasenia,nivel) " +
                       "values("+cod+",'" +datos[1] + "','" +datos [2] + "','" +datos [3] + "','" +datos [4] +"')";
            return Consulgeneral(consulta);
        }

        public bool updat(string[] datos)
        {
            string consulta;
            consulta = " update usuario set nombre='" + datos[1] + "', usuario='" + datos[2] + "', contrasenia='" + datos[3] +
                "', nivel=" + datos[4] + " where cod_usuario=" +datos [0];
                return Consulgeneral(consulta);
        }
        

        private int codigo()
         {
            DataTable datos = new DataTable();
            int cod=0;
            string consulta;
            consulta = "SELECT MAX(cod_usuario) FROM usuario";
            datos = buscar(consulta);
            if (datos.Rows[0][0]!=DBNull .Value )
            cod = Int32.Parse(datos .Rows [0][0].ToString());
            cod++;
            return cod;
        }

    }
}
