using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcoiris.Clases
{
    class Bitacora
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

        private int codigo()
        {
            DataTable datos = new DataTable();
            int cod = 0;
            string consulta;
            consulta = "SELECT MAX(id_bita) FROM Bitacora";
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value)
                cod = Int32.Parse(datos.Rows[0][0].ToString());
            cod++;
            return cod;
        }

        public DataTable BucarBitaCred(string credito)
        {
            DataTable datos = new DataTable();
            string consulta;
            consulta = "SELECT id_bita,Fecha,Cod_credito,Ingreso,Detalle " +
                       "FROM bitacora " +
                       $"WHERE cod_credito ={credito}";
            datos = buscar(consulta);
            return datos;
        }

        public bool ingre(string[] datos)
        {
            string consulta;
            int cod = codigo();
            consulta = "insert into bitacora(id_bita,fecha,Cod_credito,ingreso,detalle) " +
                       $"values({cod},'{datos[0]}','{datos[1]}','{datos[2]}','{datos[3]}')";
            return Consulgeneral(consulta);
        }

        public bool updat(string[] datos)
        {
            string consulta;
            consulta = $"update bitacora set fecha='{datos[1]}', cod_credito='{datos[2]}', Ingreso={datos[3]}, detalle={datos[4]} "+
                $"where id_Bita={datos[0]}";
            return Consulgeneral(consulta);
        }
    }
}
