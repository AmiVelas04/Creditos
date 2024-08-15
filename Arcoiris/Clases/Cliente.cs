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

        string depas = "";
        #region "General"
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
        #endregion

        #region Depar-Munis
        public List<Modelos.DeparamentoModel> Depar()
        {
            List<Modelos.DeparamentoModel> depas= new List<Modelos.DeparamentoModel>();
            string consulta = "Select * from departamento";
            DataTable datos = buscar(consulta);
            int tot = datos.Rows.Count;
            for (int i = 0; i <tot; i++)            {
                Modelos.DeparamentoModel temp = new Modelos.DeparamentoModel();
                temp.Id = int.Parse(datos.Rows[i][0].ToString());
                temp.Nombre = datos.Rows[i][1].ToString();
                depas.Add(temp);
            }
            return depas;
        }

        public List<Modelos.MunicipioModel> Munis(string id)
        {
            List<Modelos.MunicipioModel> muni = new List<Modelos.MunicipioModel>();
            string consulta = $"Select * from municipio where Departamento_id={id}";
            DataTable datos = buscar(consulta);
            int tot = datos.Rows.Count;
            for (int i = 0; i < tot; i++)
            {
                Modelos.MunicipioModel temp = new Modelos.MunicipioModel();
                temp.Id = int.Parse(datos.Rows[i][0].ToString());
                temp.Nombre = datos.Rows[i][2].ToString();
                muni.Add(temp);
            }
            return muni;
        }
        #endregion

        #region "cliente"
        public int idCli(string nombre)
        {
            int id;
            string consulta;
            consulta = "Select codigo_cli from cliente where nombres='" + nombre + "'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            id = Convert.ToInt32(datos.Rows [0][0].ToString ());
            return id;
        }

        public string clidpi(string soli)
        {
            DataTable datos = new DataTable();
            string consulta = "SELECT cli.dpi fROM cliente cli "+
                              "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI "+
                              "WHERE asol.ID_SOLICITUD = "+soli;
            datos = buscar(consulta);
            string dpi="";
            if (datos.Rows[0][0] != DBNull.Value)
            {
                dpi = datos.Rows[0][0].ToString();
                string mod = dpi.Insert(9, "-");
                string mod2 = mod.Insert(4, "-");
                dpi = mod2;
                
            }
            return dpi;

        }
        #endregion
        public bool  agregar_cliente(string[] datos)
        { 
        string consulta;
            string consultab;
            consultab = "select count(*) from cliente";
            string[] fiddatos = { datos[12], datos[13], datos[14] };
           // int idfid;
          //  idfid=agregarfiador(fiddatos);
            int id=buscarid(consultab)+1;
             consulta= $"Insert into cliente(codigo_cli,nombres,apellidos,domicilio,dpi,telefono1,telefono2,profesion,estado_civil,nombre_cony,apellido_cony,telefonocon,referencia,fecha_ing,departamento,municipio,edad) values({id},'{datos[0]}','{datos[1]}','{datos[2]}','{datos[3]}','{datos[4]}','{datos[5]}','{datos[6]}','{datos[7]}','{datos[8]}','{datos[9]}','{datos[10]}','{datos[11]}','{datos[15]}','{datos[16]}','{datos[17]}',{datos[18]})";
           // MessageBox.Show(consulta);
            MySqlCommand com = new MySqlCommand();
            com.Connection = conect .conn ;
            com.CommandText = consulta;
            com.CommandType = System.Data.CommandType.Text;
            string[] datosf = { };
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
            consulta = "SELECT codigo_cli,CONCAT(cli.Nombres, ' ', cli.Apellidos) AS Nombre, cli.Telefono1,cli.Telefono2, cli.Domicilio ,referencia, concat(cli.Nombre_cony, ' ', cli.Apellido_cony)AS Conyuge, cli.TelefonoCon AS Conyuge_Telefono,F.Nombre AS Fiador, f.telefono AS Fiador_telefono, f.Direccion AS Direccion_fiador " +
            "FROM cliente cli " +
            "INNER JOIN fiador f ON cli.ID_fiador = f.id_fiador " +
            "WHERE Cli.nombres LIKE '%" + nombre + "%' or cli.apellidos like '%" + nombre + "%' " +
            "order by cli.Nombres";

            MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
            DataTable datos = new DataTable();
            adap.Fill(datos);
            return (datos);
        }
        public DataTable Buscar_nom_cli()
        {
            DataTable datos = new DataTable();
            String consulta;
            consulta = "Select Concat(Nombres,' ',apellidos) as Nombre , Codigo_Cli from Cliente ORDER BY nombres,apellidos";
            datos=buscar(consulta);
            return datos;

        }
        public DataTable clientebusca(string idcli)
        {
            string consulta;
            consulta = "SELECT Nombres,apellidos,domicilio,dpi,telefono1,telefono2,profesion,nombre_cony,apellido_cony,telefonocon,referencia,estado_civil " +
                        "FROM cliente " +
                        "WHERE codigo_cli ="+ idcli ;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
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

        public DataTable  idfiad(string fiador)
        {
            string consulta;
            consulta = "SELECT f.id_fiador, f.nombre,f.direccion,telefono "+
            "FROM fiador f "+
            "INNER JOIN cliente c ON c.ID_fiador=f.id_fiador "+
            "WHERE c.CODIGO_CLI = '" + fiador+ "'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
        }
        private int agregarfiador(string[] data)
        {
            string consultab;
            consultab = "select count(*) from fiador";
            int idfiad = buscarid(consultab )+1;

            string consulta = "insert into fiador(id_fiador,nombre,telefono,direccion) "+
                "values(" + idfiad + ",'" +data [0] + "','" + data[1] + "','" + data [2] +"')"  ;
          //  MessageBox.Show(consulta);
            if (Consulgeneral(consulta))
            {
                return idfiad;
            }
            else
            {
                return 0;
            }
        

        }
        public bool updatecliente(string id,string[] datos)
        {
            string consulta;
            consulta = "update cliente set nombres='" + datos[0] + "', apellidos='" + datos[1] + "', domicilio='" + datos[2] + "', dpi='" + datos[3] + "', telefono1='" + datos[4] + "', telefono2='" + datos[5] + "', profesion='" + datos[6] + "', nombre_cony='" + datos[8] + "', apellido_cony='" + datos[9] + "', telefonocon='" + datos[10] + "', referencia='" + datos[11] + "', estado_civil='" + datos[7] +
                "' where codigo_cli=" + id;
            if (Consulgeneral(consulta))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool updatefiad(string id,string[] datos)
        {
            string consulta;
            consulta = "update fiador set nombre='" + datos[0] + "', direccion='" + datos[1] + "', telefono='" + datos[2] + "'" +
                " where id_fiador=" + id;
            if (Consulgeneral(consulta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        public string Dir_cli(string pago)
        {
            string consulta;
            consulta = "SELECT cli.Domicilio FROM cliente cli " +
                      "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI " +
                      "INNER JOIN asigna_credito acre on acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
                      "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO " +
                      "INNER JOIN pagos pag ON pag.COD_CREDITO = cre.COD_CREDITO " +
                      "WHERE pag.ID_PAGO ="+pago;
            DataTable datos = new DataTable();
                datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value) return "";
            return datos.Rows[0][0].ToString();


        }



    }
}
