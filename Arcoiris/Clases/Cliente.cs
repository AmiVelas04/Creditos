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
                MessageBox.Show($"Ocurrio un error al intentar realizar la operacion \n{ex.Message}");

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
        public bool  agregar_cliente(string[] datos,List<string> refes)
            { 
        string consulta;
            string consultab;
            consultab = "select max(codigo_cli) from cliente";
            string[] fiddatos = { datos[12], datos[13], datos[14] };
         
           // int idfid;
          //  idfid=agregarfiador(fiddatos);
            int id=buscarid(consultab);
            id++;
             consulta= $"Insert into cliente(codigo_cli,nombres,apellidos,domicilio,dpi,telefono1,telefono2,profesion,estado_civil,nombre_cony,apellido_cony,telefonocon,referencia,fecha_ing,departamento,municipio,edad,genero,nacionalidad," +
                $"fechanaci,profe2,dpicony,profcony,cargafam,negnom,negdir,negtel,negref,tiponeg,negantiq,dpibase64) " +
                $"values(?codigo_cli,?nombres,?apellidos,?domicilio,?dpi,?telefono1,?telefono2,?profesion,?estado_civil,?nombre_cony,?apellido_cony,?telefonocon,?referencia,?fecha_ing,?departamento,?municipio,?edad,?genero,?nacionalidad," +
                $"?fnaci,?oprof,?dpicon,?profcon,?cargaf,?nomneg,?dirneg,?telneg,?refneg,?tneg,?aneg,?imag)";
            // MessageBox.Show(consulta);

            //revisar dpi
            string consuldpi = $"select count(codigo_cli) from cliente where dpi={datos[4]}";
            DataTable dpiexist = buscar(consuldpi);
            int dpiReg = int.Parse($"{dpiexist.Rows[0][0]}");
            if (dpiReg> 0)
            {
                MessageBox.Show("El DPI ingresado ya existe, profavor revise el valor e intentelo de nuevo","DPI ya ingresado",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return false;
            }

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
            com.Parameters.Add("?fnaci", MySqlDbType.Date);
            com.Parameters.Add("?oprof", MySqlDbType.VarChar);
            com.Parameters.Add("?dpicon", MySqlDbType.VarChar);
            com.Parameters.Add("?profcon", MySqlDbType.VarChar);
            com.Parameters.Add("?cargaf", MySqlDbType.VarChar);
            com.Parameters.Add("?nomneg", MySqlDbType.VarChar);
            com.Parameters.Add("?dirneg", MySqlDbType.VarChar);
            com.Parameters.Add("?telneg", MySqlDbType.VarChar);
            com.Parameters.Add("?refneg", MySqlDbType.VarChar);
            com.Parameters.Add("?aneg", MySqlDbType.VarChar);
            com.Parameters.Add("?tneg", MySqlDbType.VarChar);
            com.Parameters.Add("?imag", MySqlDbType.VarChar);

            com.Parameters["?codigo_cli"].Value = id;
            com.Parameters["?nombres"].Value = datos[0];
            com.Parameters["?apellidos"].Value = datos[1];
            com.Parameters["?domicilio"].Value = datos[2];
            com.Parameters["?referencia"].Value = datos[3];
            com.Parameters["?dpi"].Value = datos[4];
            com.Parameters["?telefono1"].Value = datos[5];
            com.Parameters["?telefono2"].Value = datos[6];
            com.Parameters["?profesion"].Value = datos[7];
            com.Parameters["?oprof"].Value = datos[8];
            com.Parameters["?estado_civil"].Value = datos[9];
            com.Parameters["?nombre_cony"].Value = datos[10];
            com.Parameters["?apellido_cony"].Value = datos[10];// revisa como ira apellido
            com.Parameters["??telefonocon"].Value = datos[11];
            com.Parameters["?dpicon"].Value = datos[12];
            com.Parameters["?profcon"].Value = datos[13];
            com.Parameters["?fecha_ing"].Value = datos[14];
            com.Parameters["?fnaci"].Value = datos[15];

            com.Parameters["?departamento"].Value = datos[16];
            com.Parameters["?municipio"].Value = datos[17];
            com.Parameters["?edad"].Value = datos[18];
            com.Parameters["?genero"].Value = datos[19];
            com.Parameters["?nacionalidad"].Value = datos[20];
            com.Parameters["?cargaf"].Value = datos[21];
            com.Parameters["?nomneg"].Value = datos[22];
            com.Parameters["?dirneg"].Value = datos[23];
            com.Parameters["?telneg"].Value = datos[24];
            com.Parameters["?refneg"].Value = datos[25];
            com.Parameters["?tneg"].Value = datos[26];
            com.Parameters["?aneg"].Value = datos[27];
            com.Parameters["?imag"].Value = datos[28];

            return (Consulta_General_tipo2(com) && asignarefes(refes,id));

        }

        private bool asignarefes(List<string> refes, int id)
        {
            if (refes.Count<= 0) return true;
            string consulid = "select max(id_ref) from referencia";
            int idR = buscarid(consulid);
            idR++;
            string consulta1 = $"insert into referencia(id_ref,nombre,direccion,telefono) " +
                $"values(?id,?nom,?dir,?tel)";
            string consulta2 = $"insert into asigna_ref(id_ref,codigo_cli) " +
                $"values(?id,?cli)";
            MySqlCommand com1 = new MySqlCommand();
            MySqlCommand com2 = new MySqlCommand();
            com1.CommandText = consulta1;
            com1.CommandType = CommandType.Text;
            com2.CommandText = consulta2;
            com2.CommandType = CommandType.Text;
            com1.Parameters.Add("?id", MySqlDbType.Int32);
            com1.Parameters.Add("?nom", MySqlDbType.VarChar);
            com1.Parameters.Add("?dir", MySqlDbType.VarChar);
            com1.Parameters.Add("?tel", MySqlDbType.VarChar);
com2.Parameters.Add("?id", MySqlDbType.Int32);
            com2.Parameters.Add("?cli", MySqlDbType.Int32);


            int conteo = 0;
            bool respo = false;
            if (refes.Count <= 3)
            { conteo = 1; }
            else if (refes.Count <= 6)
            {
                conteo = 2;
            }
            else 
            { conteo = 3; }
            int recorr = 0;
            for (int i =0; i <conteo; i++)
            {
                com1.Parameters["?id"].Value = idR;
                com1.Parameters["?nom"].Value = refes[recorr];
                recorr++;
                com1.Parameters["?dir"].Value = refes[recorr];
                recorr++;
                com1.Parameters["?tel"].Value = refes[recorr];
                recorr++;
                com2.Parameters["?id"].Value = idR;
                com2.Parameters["?cli"].Value = id;
                respo = (Consulta_General_tipo2(com1) && Consulta_General_tipo2(com2));
                if (respo == false) return false;
                idR++;
            }
            return respo;
        }

        private  bool updSinglerefes(List <string>datos)
        {
            if (datos.Count <= 0) return true;
            int contrefes = datos.Count;
            int conteo = 0;
            bool respo = false;

            string consulta1 = $"update referencia set nombre=?nom,direccion=?dir,telefono=?tel " +
                $"where id_ref=?id";
        
            MySqlCommand com1 = new MySqlCommand();
          
            com1.CommandText = consulta1;
            com1.CommandType = CommandType.Text;
         
            com1.Parameters.Add("?id", MySqlDbType.Int32);
            com1.Parameters.Add("?nom", MySqlDbType.VarChar);
            com1.Parameters.Add("?dir", MySqlDbType.VarChar);
            com1.Parameters.Add("?tel", MySqlDbType.VarChar);


            if (contrefes <= 12) conteo = 3;
            if (contrefes <= 8) conteo = 2;
            if (contrefes <= 4) conteo = 1;


            int recorr = 0;
            for (int i = 0; i < conteo; i++)
            {
                com1.Parameters["?id"].Value = datos[recorr];
                com1.Parameters["?nom"].Value = datos[recorr+1];
                com1.Parameters["?dir"].Value = datos[recorr+2];
                com1.Parameters["?tel"].Value = datos[recorr+3];
                recorr=+4;
                respo = (Consulta_General_tipo2(com1));
                if (respo == false) return false;
            }
            return respo;
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
            consulta = "Select Concat(Nombres,' ',apellidos,'-',DPI) as Nombre , Codigo_Cli,DPI from Cliente ORDER BY nombres,apellidos";
            datos=buscar(consulta);
            return datos;

        }

        public DataTable BuscarCliDpi(string dpi)
        {
            string consulta = $"Select * from cliente where dpi='{dpi}'";
            return buscar(consulta); ;
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
                "Departamento,Municipio,Genero,Nacionalidad,profe2,cargafam,profcony,dpicony, DPIBASE64,Date_format(fechanaci,'%Y-%M-%d'),negnom,negtel,negdir,negref,tiponeg,negantiq,dpibase64 " +
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
                $"negnom=?nomn,negdir=?dirn,negtel=?teln,tiponeg=?tipn,negref=?refn,negantiq=?antiqn,cargafam=?cargaf, profe2=?profOt,profcony=?profcon,dpicony=?dpicon, " +
                $"dpibase64=?imag, edad=?edad, referencia=?ref " +
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
            com.Parameters.Add("?edad", MySqlDbType.VarChar);
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
            com.Parameters.Add("?imag", MySqlDbType.LongBlob);





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
            com.Parameters["?fnaci"].Value = datos[26];
            com.Parameters["?ref"].Value = datos[11];
            com.Parameters["?edad"].Value = datos[12];
            com.Parameters["?gene"].Value = datos[13];
            com.Parameters["?profcon"].Value = datos[16];
            com.Parameters["?dpicon"].Value = datos[17];
            com.Parameters["?depa"].Value = datos[14];
            com.Parameters["?muni"].Value = datos[15];
            //com.Parameters["?nacio"].Value = datos[00];
            com.Parameters["?nomn"].Value = datos[18];
            com.Parameters["?dirn"].Value = datos[19];
            com.Parameters["?teln"].Value = datos[20];
            com.Parameters["?tipn"].Value = datos[22];
            com.Parameters["?refn"].Value = datos[21];
            com.Parameters["?antiqn"].Value = datos[23];
            com.Parameters["?cargaf"].Value = datos[24];
            com.Parameters["?imag"].Value = datos[25];


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



        public DataTable refscli(string cli)
        {
            string consulta = $"Select R.id_ref, R.nombre,R.Direccion,R.Telefono from referencia R " +
                $" inner join asigna_ref Af on R.id_ref=AF.id_ref " +
                $"where AF.codigo_cli={cli}";
            return buscar(consulta);
        }

        public bool UpdRefes(List<string> datos, string cli)
        {
            int idCliente = int.Parse(cli);
            List<string> refesNew = new List<string>();
            List<string> refesupdate = new List<string>();
            int refes = datos.Count;
            int filas = 0;
            if (refes <= 0) return true;
            if (refes <= 12) filas = 3;
            if (refes <= 8) filas = 2;
            if (refes <= 4) filas = 1;
            int columTemp = 0;
            for (int i = 0; i < filas; i++)
            {
                if (datos[columTemp].Equals("0"))
                {
                    refesNew.Add(datos[columTemp + 1]);
                    refesNew.Add(datos[columTemp + 2]);
                    refesNew.Add(datos[columTemp + 3]);
                    columTemp += 4;
                }
                else
                {
                    refesupdate.Add(datos[columTemp]);
                    refesupdate.Add(datos[columTemp + 1]);
                    refesupdate.Add(datos[columTemp + 2]);
                    refesupdate.Add(datos[columTemp + 3]);
                    columTemp += 4;
                }
            }
            return (asignarefes(refesNew, idCliente) && updSinglerefes(refesupdate));

        }


    }
}
