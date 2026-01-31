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

        private DataTable Buscar_Tipo2(MySqlCommand coma)
        {
            conect.iniciar();
            DataTable datos = new DataTable();
            coma.Connection = conect.conn;
            using (MySqlDataReader read = coma.ExecuteReader())
            {
                foreach (var item in read)
                {
                    datos.Rows.Add(item);
                }
                
            }

                // MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
                // adap.Fill(datos);
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

        private bool Consulta_General_tipo2(MySqlCommand comando)
        {
            conect.iniciar();
            comando.Connection = conect.conn;
            try
            {
                conect.conn.Open();
                comando.ExecuteNonQuery();
                conect.conn.Close();
            }
            catch (Exception ex)
            {
                conect.conn.Close();
                MessageBox.Show($"Ocurrio un error al intentar realizar la operacion /n{ex.InnerException}");

                return false;
            }
            return true;
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

        public int idDepaByName(string nom)
        {
            string consulta =$"Select id from departamento where nombre='{nom}'";
            int valor = -1;
            DataTable resp = buscar(consulta);
            valor = int.Parse($"{resp.Rows[0][0]}");
            return valor;
        }

        public int idMuniByName(string nom)
        {
            string consulta = $"Select id from municipio where nombre='{nom}'";
            int valor = -1;
            DataTable resp = buscar(consulta);
            valor = int.Parse($"{resp.Rows[0][0]}");
            return valor;
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
            consultab = "select max(codigo_cli) from cliente";
            string[] fiddatos = { datos[12], datos[13], datos[14] };
           // int idfid;
          //  idfid=agregarfiador(fiddatos);
            int id=buscarid(consultab)+1;
             consulta= $"Insert into cliente(codigo_cli,nombres,apellidos,domicilio,dpi,telefono1,telefono2,profesion,estado_civil,nombre_cony,apellido_cony,telefonocon,referencia,fecha_ing,departamento,municipio,edad,genero,nacionalidad) " +
                $"values(?codigo_cli,?nombres,?apellidos,?domicilio,?dpi,?telefono1,?telefono2,?profesion,?estado_civil,?nombre_cony,?apellido_cony,?telefonocon,?referencia,?fecha_ing,?departamento,?municipio,?edad,?genero,?nacionalidad)";
           // MessageBox.Show(consulta);
            MySqlCommand com = new MySqlCommand();
         
            com.CommandText = consulta;
            com.CommandType = CommandType.Text;

            com.Parameters.Add("?codigo_cli", MySqlDbType.Int32);
            com.Parameters.Add("?nombres", MySqlDbType.VarChar);
            com.Parameters.Add("?apellidos",MySqlDbType.VarChar);
            com.Parameters.Add("?domicilio", MySqlDbType.VarChar);
            com.Parameters.Add("?dpi", MySqlDbType.VarChar);
            com.Parameters.Add("?telefono1", MySqlDbType.VarChar);
            com.Parameters.Add("?telefono2", MySqlDbType.VarChar);
            com.Parameters.Add("?profesion", MySqlDbType.VarChar);
            com.Parameters.Add("?estado_civil", MySqlDbType.VarChar);
            com.Parameters.Add("?nombre_cony", MySqlDbType.VarChar);
            com.Parameters.Add("?apellido_cony", MySqlDbType.VarChar);
            com.Parameters.Add("?telefonocon", MySqlDbType.VarChar);
            com.Parameters.Add("?referencia", MySqlDbType.VarChar);
            com.Parameters.Add("?fecha_ing", MySqlDbType.Date);
            com.Parameters.Add("?departamento", MySqlDbType.VarChar);
            com.Parameters.Add("?municipio", MySqlDbType.VarChar);
            com.Parameters.Add("?edad", MySqlDbType.Int32);
            com.Parameters.Add("?genero", MySqlDbType.VarString);
            com.Parameters.Add("?nacionalidad", MySqlDbType.VarChar);



            com.Parameters["?codigo_cli"].Value = id;
            com.Parameters["?nombres"].Value = datos[0];
            com.Parameters["?apellidos"].Value = datos[1];
            com.Parameters["?domicilio"].Value = datos[2];
            com.Parameters["?dpi"].Value = datos[3];
            com.Parameters["?telefono1"].Value = datos[4];
            com.Parameters["?telefono2"].Value = datos[5];
            com.Parameters["?profesion"].Value = datos[6];
            com.Parameters["?estado_civil"].Value = datos[7];
            com.Parameters["?nombre_cony"].Value = datos[8];
            com.Parameters["?apellido_cony"].Value = datos[9];
            com.Parameters["??telefonocon"].Value = datos[10];
            com.Parameters["?referencia"].Value = datos[11];
            com.Parameters["?fecha_ing"].Value = datos[15];
            com.Parameters["?departamento"].Value = datos[16];
            com.Parameters["?municipio"].Value = datos[17];
            com.Parameters["?edad"].Value = datos[18];
            com.Parameters["?genero"].Value = datos[19];
            com.Parameters["?nacionalidad"].Value = datos[20];

            return Consulta_General_tipo2(com);

        }

        //Buscar cliente

        public DataTable buscar_cli(string nombre)
        {
            conect.iniciar();
            string consulta;
            consulta = "SELECT codigo_cli,CONCAT(cli.Nombres, ' ', cli.Apellidos) AS Nombre, cli.edad,cli.estado_civil,cli.Telefono1,cli.Telefono2,cli.Departamento,cli.Municipio, cli.Domicilio ,referencia, concat(cli.Nombre_cony, ' ', cli.Apellido_cony)AS Conyuge, cli.TelefonoCon AS Conyuge_Telefono " +
            "FROM cliente cli " +
            $"WHERE Cli.nombres LIKE '%{nombre}%' or cli.apellidos like '%{nombre}%' " +
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

        public DataTable AllCli()
        {
            DataTable datos = new DataTable();
            String consulta;
            consulta = "Select Codigo_cli,Concat(Nombres,' ',apellidos) as Nombre ,Domicilio, Telefono1, ESTADO_CIVIL, PROFESION, DPI, EDAD, DEPARTAMENTO, MUNICIPIO, GENERO, NACIONALIDAD from Cliente ORDER BY nombres,apellidos";
            datos = buscar(consulta);
            return datos;
        }



        public DataTable clientebusca(string idcli)
        {
            string consulta;
            consulta = "SELECT Nombres,apellidos,domicilio,dpi,telefono1,telefono2,profesion,nombre_cony,apellido_cony,telefonocon,referencia,estado_civil,edad, " +
                "Departamento,Municipio,Genero,Nacionalidad,profe2,cargafam,profcony,dpicony, DPIBASE64,fechanaci,negnom,negtel,negdir,negref,tiponeg,negantiq " +
                        $"FROM cliente WHERE codigo_cli ={idcli}";
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
            consulta = $"update cliente set nombres='{datos[0]}', apellidos='{datos[1]}', domicilio='{datos[2]}', dpi='{datos[3]}', telefono1='{datos[4]}', telefono2='{datos[5]}', profesion='{datos[6]}', nombre_cony='{datos[8]}', apellido_cony='{datos[9]}', telefonocon='{datos[10]}', referencia='{datos[11]}', estado_civil='{datos[7]}',edad='{datos[12]}',genero='{datos[13]}'" +
                $" where codigo_cli={id}";
            if (Consulgeneral(consulta))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool updateclienteNuevo(string id, string[] datos)
        {


            string consulta;
            consulta = $"update cliente set nombres=?nombres, apellidos=?apellidos, domicilio=?domi, dpi=?dpi, telefono1=?tel1, telefono2=?tel2, profesion=?prof, " +
                $"nombre_cony=?nomCon, telefonocon=?telcon, referencia=?ref, estado_civil=?estC,fechanaci=?fnaci,genero=?gene,departamento=?depa,municipio=?muni, " +
                $"negnom=?nomn,negdir=?dirn,negtel=?teln,tiponeg=?tipn,negref=?refn,negantiq=?antiqn,cargafam=?cargaf, profe2=?profOt,profcony=?profcon,dpicony=?dpicon " +
                $"where codigo_cli={id}";
            MySqlCommand com = new MySqlCommand();

            com.CommandText = consulta;
            com.CommandType = CommandType.Text;

            com.Parameters.Add("?nombres", MySqlDbType.VarChar);
            com.Parameters.Add("?apellidos", MySqlDbType.VarChar);
            com.Parameters.Add("?domi", MySqlDbType.VarChar);
            com.Parameters.Add("?dpi", MySqlDbType.VarChar);
            com.Parameters.Add("?tel1", MySqlDbType.VarChar);
            com.Parameters.Add("?tel2", MySqlDbType.VarChar);
            com.Parameters.Add("?prof", MySqlDbType.VarChar);
            com.Parameters.Add("?profOt", MySqlDbType.VarChar);
            com.Parameters.Add("?estC", MySqlDbType.VarChar);
            com.Parameters.Add("?nomCon", MySqlDbType.VarChar);
            com.Parameters.Add("?telcon", MySqlDbType.VarChar);
            com.Parameters.Add("?ref", MySqlDbType.VarChar);
            com.Parameters.Add("?fnaci", MySqlDbType.DateTime);
            com.Parameters.Add("?gene", MySqlDbType.VarChar);
            com.Parameters.Add("?profcon", MySqlDbType.VarChar);
            com.Parameters.Add("?dpicon", MySqlDbType.VarChar);
            com.Parameters.Add("?depa", MySqlDbType.VarChar);
            com.Parameters.Add("?muni", MySqlDbType.VarChar);
           // com.Parameters.Add("?nacio", MySqlDbType.VarChar);
            com.Parameters.Add("?tipn", MySqlDbType.VarChar);
            com.Parameters.Add("?teln", MySqlDbType.VarChar);
            com.Parameters.Add("?nomn", MySqlDbType.VarChar);
            com.Parameters.Add("?dirn", MySqlDbType.VarChar);
            com.Parameters.Add("?antiqn", MySqlDbType.VarChar);
            com.Parameters.Add("?refn", MySqlDbType.VarChar);
            com.Parameters.Add("?cargaf", MySqlDbType.VarChar);





            com.Parameters["?nombres"].Value = datos[0];
            com.Parameters["?apellidos"].Value = datos[1];
            com.Parameters["?domi"].Value = datos[2];
            com.Parameters["?dpi"].Value = datos[3];
            com.Parameters["?tel1"].Value = datos[4];
            com.Parameters["?tel2"].Value = datos[5];
            com.Parameters["?prof"].Value = datos[6];
            com.Parameters["?profOt"].Value = datos[9];
            com.Parameters["?estC"].Value = datos[7];
            com.Parameters["?nomCon"].Value = datos[8];
            com.Parameters["?telcon"].Value = datos[10];
            com.Parameters["?fnaci"].Value = DateTime.Now;
            com.Parameters["?gene"].Value = datos[13];
            com.Parameters["?profcon"].Value = datos[16];
            com.Parameters["?dpicon"].Value = datos[17];
            com.Parameters["?depa"].Value = datos[14];
            com.Parameters["?muni"].Value = datos[15];
            //com.Parameters["?nacio"].Value = datos[00];
            com.Parameters["?nomn"].Value = datos[18];
            com.Parameters["?dirn"].Value = datos[19];
            com.Parameters["?teln"].Value = datos[20];
            com.Parameters["?tipn"].Value = datos[21];
            com.Parameters["?refn"].Value = datos[22];
            com.Parameters["?antiqn"].Value = datos[23];
            com.Parameters["?cargaf"].Value = datos[24];


            return Consulta_General_tipo2(com);
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

        public DataTable IdByDpi(string dpi)
        {
            string consulta;
            consulta = "SELECT Codigo_cli, nombres, apellidos " +
                        "FROM cliente " +
                        $"WHERE dpi='{dpi}'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
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
