using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Arcoiris.Clases
{

    class conexion
    {
     string cadena_conn= "server=192.168.0.8;  database=arcoiris; user id=Creditos; password=Cre-2020-Sis; port=3306; allow zero Datetime= true";
    //string cadena_conn = "server=localhost;  database=arcoiris; user id=Creditos; password=Cre-2020-Sis; allow zero Datetime= true";


        public MySqlConnection  conn = new MySqlConnection();

        public void iniciar()
        {
            conn.ConnectionString = cadena_conn;

        }

        public string  probar_conn()  {
            string mensaje;
            conn.ConnectionString = cadena_conn;
            try

            {
                conn.Open();
                conn.Close();
               
                mensaje = "Conexion exitosa";
                return mensaje;
                    
            }
            catch (Exception ex)
            {
                conn.Close();
                mensaje = "Error: " + ex.ToString() + "\n" + cadena_conn  ;
                return mensaje;
              
            }
                
        }


    }
}
