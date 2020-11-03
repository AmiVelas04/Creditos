using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Arcoiris.Clases
{
    class Logueo
    {
        Clases.conexion conect = new Clases.conexion();
        private DataTable buscar(string consulta)
        {
            DataTable datos = new DataTable();
            try
            {
                conect.iniciar();
                MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
              
                adap.Fill(datos);
                return datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
               MessageBox.Show("Error de conexion, consulte con su administrador de sistemas" );   
               return datos;
            }
          
        }

        public bool loguearse(string user,string pass)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "Select Cod_usuario as Codigo,Nombre,Nivel from usuario where usuario='" + user + "' and Contrasenia='" + pass + "'";
            datos = buscar(consulta );
            int total;
            total = datos.Rows.Count;
            
            if (total >= 1)
            {
                Form1.Cod_U = datos.Rows[0][0].ToString();
                Form1.Nombre = datos.Rows[0][1].ToString();
                Form1 .Nivel = datos.Rows[0][2].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }
        public int nivel( string pass)
        {
            string consulta = "Select nivel from usuario where usuario='admin' and contrasenia= '" +pass +"'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows.Count >= 1)
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
