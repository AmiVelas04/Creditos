using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace Arcoiris.Clases
{

    class Cliente
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
        private int buscarid(string consulta)
        {
            conect.iniciar();
            DataTable tabla = new DataTable();
            
            try
            {
                MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
                adap.Fill(tabla);
                if (tabla.Rows.Count >= 1)
                {
                    int val = Convert.ToInt32(tabla.Rows[0][0]);
                    return val++;
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

        public bool agregar_cliente(string[] datos)
        { 
        string consulta;
            string consultab;
            consultab = "select count(*) from cliente";

            int id=buscarid(consultab);
        consulta="Insert into cliente(codigo_cli,nombres,apellidos,domicilio,telefono,nombre_cony,apellido_cony,estado_civil,profesion,dpi,referencia,fecha_ing)" +
               " values("+ id +",'" + datos[0] + "','" + datos[1] + "','" + datos[2] + "','" + datos[3] + "','" + datos[4] + "','" + datos[5] + "','" + datos[6] + "','" + datos[7] + "','" + datos[8] + "','"+ datos[9 ] + "','" + datos[10] + "')";
            MySqlCommand com = new MySqlCommand();
            com.Connection = conect .conn ;
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

        //Buscar cliente

        public DataTable buscar_cli(string nombre)
        {
            conect.iniciar();
            string consulta;
            consulta = "Select Codigo_cli as Codigo,Nombres, Apellidos, Telefono, Domicilio,Estado_civil as Estado_Civil, Nombre_cony as Nombre_conyuge, DPI from cliente where nombres like '%" + nombre + "%'";
            MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
            DataTable datos = new DataTable();
            adap.Fill(datos);
            return (datos);
        }
        public DataTable Buscar_nom_cli()
        {
            DataTable datos = new DataTable();
            String consulta;
            consulta = "Select Nombres from Cliente";
            datos=buscar(consulta);
            return datos;

        }

        public int buscar_cod(string nom)
        {
            string consulta;
            consulta = "Select codigo_cli from cliente where nombres= '" + nom + "'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (!DBNull.Value.Equals(datos.Rows[0][0]))
            {
                return Convert.ToInt32(datos.Rows[0][0]);
            }
            else
            {
                return 0;
            }
        }
        


        
        

    }
}
