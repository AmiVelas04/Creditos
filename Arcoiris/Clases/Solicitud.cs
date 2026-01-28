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
        


        #region "General"
        private DataTable buscar(string consulta)
        {
            conect.iniciar();
            DataTable datos = new DataTable();
            try
            {

                MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
                adap.Fill(datos);
                return datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
                return datos;

            }
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

        private bool Consulta_tipo2(MySqlCommand comando)
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
                MessageBox.Show($"Ocurrio un error al intentar realizar la operacion {ex.Message}");
                
                return false;
            }
            return true;
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
                MessageBox.Show($"Ocurrio un error al intentar realizar la operacion /n{ex.Message}/n{ex.InnerException.Message}");

                return false;
            }
            return true;
        }

        #endregion
        #region "Datos Solicitud"

        public int id_solicitud()
        {
            string consulta;
            consulta = "Select max(id_solicitud) from solicitud";
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

        public bool hayasesor(string nombre)
        {
            string consulta;
            consulta = "Select cod_asesor from asesor where cod_asesor=" + nombre;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public int cod_cliente(string soli)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "SELECT cli.Codigo_cli FROM cliente cli " +
            "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI " +
            "INNER JOIN solicitud sol ON sol.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "WHERE sol.ID_SOLICITUD =" + soli;
            datos = buscar(consulta);
            return Convert.ToInt32(datos.Rows[0][0].ToString());

        }
        private int diaspagos(String fechai, String fechaf)
        {

            DateTime fechap = Convert.ToDateTime(fechai);
            TimeSpan diasdif = Convert.ToDateTime(fechaf) - Convert.ToDateTime(fechai);
            int c = diasdif.Days;

            int diasp = 0;
            int j;
            fechap = fechap.AddDays(1);
            for (j = 1; j <= c; j++)
            {
                if (fechap.DayOfWeek == DayOfWeek.Saturday || fechap.DayOfWeek == DayOfWeek.Sunday)
                {

                }
                else
                {
                    diasp++;
                }
                fechap = fechap.AddDays(1);

            }
            //MessageBox.Show("dias totales: "+ c + "\nFines de semana:" +fines  );
            if (diasp > 22)
            {
               // diasp = 22;
            }
            return diasp;
        }
        public string fecha_fin(string fechaing, string tipo, int pagos)
        {
            DateTime fechai = Convert.ToDateTime(fechaing);
            fechai = fechai.AddDays(1);
            if (fechai.DayOfWeek == DayOfWeek.Saturday || fechai.DayOfWeek == DayOfWeek.Sunday)
            {
                fechai = fechai.AddDays(1);
                if ((fechai.DayOfWeek == DayOfWeek.Sunday) && (tipo.Equals("1") || tipo.Equals("2")))
                {
                    fechai = fechai.AddDays(1);
                }
            }

            return "";
        }
        #endregion

     
        public bool agregar_soli(string[] datos)
        {
            conect.iniciar();
            string consulta;
            string[] data = { datos[7], datos[0], datos[8] };
            string fecha = datos[3].ToString();
            fecha = DateTime.Now.ToString("yyyy/MM/dd");
            consulta = "insert into solicitud (id_solicitud,concepto,monto,fecha, estado, plazo,garantia,tipo) values(" + datos[0] + ",'" + datos[1] + "'," + datos[2] + ",'" + fecha + "','" + datos[4] + "','" + datos[5] + "','" + datos[6] + "'," + datos[9] + ")";
            //MessageBox.Show(consulta);
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
                    string[] Dgaran = new string[16];
                    Dgaran[0] = datos[10]; //contrato
                    Dgaran[1] = datos[12];//valuacion
                    if (datos[13] != null)
                    { Dgaran[2] = datos[13];//Garantia 
                    }
                    else
                    {
                        Dgaran[2] ="Sn garantia";//Garantia 
                    }
                    Dgaran[3] = datos[14];//Nom fiador
                    Dgaran[4] = datos[15];//Municipio fiador
                    Dgaran[5] = datos[16];//Departamento Fiador
                    Dgaran[6] = datos[17];//ProfFiador
                    Dgaran[7] = datos[18];//Edad Fiador
                    Dgaran[8] = datos[19];//Estado civil fiador
                    if (datos[20] != null)
                    { Dgaran[9] = datos[20]; }
                    else
                    { Dgaran[9] = "Sin Garantia F"; }
                    //Garant Fiador
                    Dgaran[10] = datos[0];
                    Dgaran[11] = datos[21]; //cui fiador
                    Dgaran[12] = datos[22];// dir fiador
                    Dgaran[13] = "sin genero"; //genero
                    Dgaran[14] = "0";//valuacion garant fiador
                    Dgaran[15] = "00000000";//Telefono fiador
                    return true;//ingre_garant(Dgaran);
                    //return true;
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

        public bool addFiad(string[] datos)
        {
            string consulta = $"insert into sol_fiad(id_sol,id_fia) values({datos[0]},{ datos[1]})";
            return consulta_gen(consulta);
        }


        public DataTable busca_soli_pend()
        {
            string consulta;
            consulta = "Select id_solicitud from solicitud where estado ='Espera'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
        }
        public DataTable busca_datos(string soli)
        {
            string consulta;
            consulta = "Select Concat(cli.Nombres,' ',cli.apellidos) as Nombre, ase.nombre as Asesor, sol.Concepto , Monto,plazo,garantia,Fecha,tipo,cli.Codigo_cli " +
                       "from Cliente cli inner join asigna_solicitud asol on asol.codigo_cli = cli.codigo_cli inner join Asesor ase on ase.cod_asesor = asol.cod_asesor inner join solicitud sol on sol.id_solicitud = asol.id_solicitud " +
                       "where sol.id_solicitud =" + soli;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
        }
        private bool asinga_soli(string[] datos)
        {
            string consulta;
            consulta = "insert into asigna_solicitud (cod_asesor,id_solicitud,codigo_cli) values(" + datos[0] + "," + datos[1] + "," + datos[2] + ")";
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

        public bool ingre_garant(string[] val)
        {
            int idgarant;
            idgarant = id_garant();
            idgarant++;

            string consulta = "Insert into garantia(id_garant,ContratoTip,valuacion,detalle,FiadorNom1,FiadorCui,FiadorGene,FiadorMuni,FiadorDepa,FiadorDire,FiadorTel,FiadorEdad,FiadorEstCiv,Fdetalle,FValuacion) values(" +
                              $"{idgarant},'{val[0]}',{val[1]},'{val[2]}','{val[3]}','{val[11]}','{val[13]}','{val[4]}','{val[5]}','{val[12]}','{val[15]}','{val[7]}','{val[8]}','{val[8]}','{val[14]}')";
            MySqlCommand com = new MySqlCommand();
            com.Connection = conect.conn;
            com.CommandText = consulta;
            com.CommandType = CommandType.Text;
            try
            {
                string[] valo = new string[2];
                conect.conn.Open();
                com.ExecuteNonQuery();
                conect.conn.Close();
                valo[0] = idgarant.ToString();
                valo[1] = val[10];
                if (asigna_garant(valo))
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
                MessageBox.Show("Error al ingresar garantia\n" + ex.ToString());
                MessageBox.Show(consulta);
                return false;

            }

        }

        private bool asigna_garant(string[] val)
        {
            int idgarant;
            idgarant = id_garant();
            idgarant++;

            string consulta = "Insert into sol_garant(id_solicitud,id_garant) values(" +
                              "" + val[1] + "," + val[0] + ")";
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
                conect.conn.Close();
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
                return false;

            }
        }

        //Cambiar estado
        public bool camb_estado(string[] datos)
        {
            string consulta;
            consulta = "Update solicitud set estado='" + datos[7] + "' where id_solicitud=" + datos[0];
            if (consulta_gen(consulta))
            {
                if (crear_credi(datos))
                {
                    return true;
                }
                else
                {
                    consulta = "Update solicitud set estado='Espera' where id_solicitud=" + datos[0];
                    consulta_gen(consulta);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Error al actualizar estado dela solicitud");
                return false;
            }
        }

        private bool crear_credi(string[] datos)
        {
            string consultaid;
            consultaid = "Select count(*) from credito";
            DataTable credi = new DataTable();
            credi = buscar(consultaid);
            int idcredito = Convert.ToInt32(credi.Rows[0][0]) + 1;
            int diasp = diaspagos(datos[4], datos[5]);
            if (datos[6] == "1" || datos[6] == "2")
            {
                diasp = Convert.ToInt32(datos[2]);
            }
            else
            {
                diasp = Convert.ToInt32(datos[2]);
            }
            decimal saldoC = Convert.ToDecimal(datos[1]);
            decimal interes = Convert.ToDecimal(datos[3]);
            decimal saldoI = 0;
            //MessageBox.Show("Tipo de credito: " + datos[6].ToString ());
            if (datos[6] == "1" || datos[6] == "2")
            {
                saldoI = Math.Round((saldoC * interes / 100 * diasp), 2);
            }
            else if (datos[6] == "3")
            {
                int plaz;
                plaz = Convert.ToInt32(datos[2].ToString());
                saldoI = Math.Round((saldoC * interes / 100 * plaz / 12), 2);
            }
            else if (datos[6] == "4")
            {
                int plaz;
                plaz = Convert.ToInt32(datos[2].ToString());
                int cont;
                decimal total = saldoC;
                decimal pago;
                pago = saldoC / plaz;
                decimal SumI = 0;
                for (cont = 1; cont <= plaz; cont++) {
                    saldoI = Math.Round((total * interes / 100 / 12), 2);
                    SumI += saldoI;
                    total -= pago;
                }
                saldoI = SumI;
            }
            else if (datos[6] == "5")
            {
                int plaz;
                plaz = Convert.ToInt32(datos[2].ToString());
                diasp = plaz;
                saldoI = Math.Round((saldoC * interes / 100 * diasp), 2);
            }
            else if (datos[6] == "6")
            {
                int plaz;
                plaz = Convert.ToInt32(datos[2].ToString());
                diasp = plaz;
                saldoI = Math.Round((saldoC * interes / 100 * diasp), 2);
            }


            string consultaingcre;
            consultaingcre = "insert into Credito(cod_credito,id_tipo_credito, monto,plazo, interes, fecha_conc,fecha_venci, estado,dias_pago,saldo_cap,saldo_int,saldo_ant,gastos_admin) " +
                $"values({idcredito},{datos[6]},{datos[1]},'{datos[9]}',{datos[3]},'{datos[4]}','{datos[5]}','Activo',{diasp},{saldoC},{saldoI},{datos[8]},+{datos[10]})";
            if (consulta_gen(consultaingcre))
            {
                return asigna_credito(datos[0], idcredito);
            }
            else {
                return false;
            }
        }

        private bool asigna_credito(string soli, int credito)
        {
            string consulta_asignacre;
            consulta_asignacre = "insert into asigna_credito(id_solicitud,cod_credito) values(" + soli + "," + credito + ")";
            if (consulta_gen(consulta_asignacre))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool denegarsol(string sol)
        {
            string consulta;
            consulta = "update solicitud set estado='Denegado' where id_solicitud=" + sol;
            if (consulta_gen(consulta))
            {
                return true;
            }
            else
                return false;
        }

        public void cambiofechas(string tipo)
        {
            DataTable datos = new DataTable();
            string consulta;
            int total = 0;
            consulta = "Select fecha_conc, dias_pago,cod_credito from credito where id_tipo_credito=" + tipo;
            MessageBox.Show(consulta);
            datos = buscar(consulta);
            DateTime fecha;
            total = datos.Rows.Count;
            int cont;
            if (tipo == "1" || tipo == "2")
            {
                string updfech;
                for (cont = 0; cont <= total - 1; cont++)
                {
                    fecha = Convert.ToDateTime(datos.Rows[cont][0]);
                    fecha = fecha.AddMonths(1);
                    string fech;
                    fech = fecha.ToString("yyyy/MM/dd");

                    updfech = "Update credito set fecha_venci='" + fech + "' where cod_credito=" + datos.Rows[cont][2].ToString();
                    // MessageBox.Show(updfech);
                    consulta_gen(updfech);

                }
            }
            else if (tipo == "3" || tipo == "4")
            {
                string updfech;
                int num;
                for (cont = 0; cont <= total - 1; cont++)
                {
                    num = Convert.ToInt32(datos.Rows[cont][1]);
                    fecha = Convert.ToDateTime(datos.Rows[cont][0]);
                    fecha = fecha.AddMonths(num);
                    string fech;
                    fech = fecha.ToString("yyyy/MM/dd");

                    updfech = "Update credito set fecha_venci='" + fech + "' where cod_credito=" + datos.Rows[cont][2].ToString();
                    // MessageBox.Show(updfech);
                    consulta_gen(updfech);


                }
                MessageBox.Show("Fechas Actualizadas!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        public bool cambiodias()
        {
            string consulta;
            consulta = "Select Cod_credito, Date_format(Fecha_conc,'%d/%m/%y'),Date_format(Fecha_Venci,'%d/%m/%y') from credito where (id_tipo_credito= 1 or id_tipo_credito=2) and estado= 'Activo'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            int cont, total;
            total = datos.Rows.Count;
           //  DateTime Fini, Ffin;
            for (cont = 0; cont < total; cont++)
            {
                int dias;
                dias = diaspagos(datos.Rows[cont][1].ToString (), datos.Rows[cont ][2].ToString ());
                MessageBox.Show("Credito: " + (datos.Rows[cont ][0].ToString()) + "\nDias de Pago: " + dias);
            }
            return true;

        }


        #region Id's
        private int id_garant()
        {
            string consulta;
            consulta = "SELECT max(gan.id_garant)FROM garantia gan";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value)
            {
                return int.Parse(datos.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }

        }


        public string idsolXcred(string cre)
        {
            string consulta;
            consulta = "Select id_solicitud from asigna_credito where cod_credito="+cre;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return (datos.Rows[0][0].ToString());

        }
        #endregion

        #region Garantias

       
       public DataTable garantia(string idcre)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "SELECT gar.id_garant,gar.Tipo,gar.Valuacion,gar.Detalle,gar.Tipo_Esc,gar.Fecha_Esc,gar.Autorizo,gar.ubicacion,gar.Estado, gar.contratotip, gar.FiadorNom1,gar.FiadorCui,gar.FiadorGene,gar.FiadorMuni,gar.FiadorDepa,gar.FiadorDire,gar.FiadorTel,gar.FiadorEdad,gar.FiadorEstCiv  from  garantia gar " +
"INNER JOIN sol_garant sga ON sga.id_garant = gar.id_garant "+
"INNER JOIN solicitud sol ON sol.ID_SOLICITUD = sga.Id_Solicitud "+
"INNER JOIN asigna_solicitud asol ON asol.ID_SOLICITUD = sol.ID_SOLICITUD "+
"INNER JOIN asigna_credito acre ON acre.ID_SOLICITUD = sol.ID_SOLICITUD "+
"INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO "+
"WHERE cre.COD_CREDITO ="+idcre;
            datos = buscar(consulta);
            return datos;
        }

        public DataTable Clibycred(string idcre)
        {
            string consulta;
            consulta = "Select c.Nombres,C.apellidos,c.Departamento,c.municipio,c.Domicilio,c.Edad,c.Genero,c.dpi,c.Estado_civil,c.profesion,c.Nacionalidad from cliente c " +
            "inner join asigna_solicitud asol on asol.codigo_cli = c.CODIGO_CLI " +
            "inner join solicitud sol on sol.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "inner join asigna_credito ac on ac.ID_SOLICITUD = sol.ID_SOLICITUD " +
            "inner join credito cre on cre.COD_CREDITO = ac.COD_CREDITO " +
            "where cre.COD_CREDITO=" + idcre;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
        }

        public DataTable CreditoOne(string idcre)
        {
            string consulta;
            consulta = "Select * from credito " +
            "where COD_CREDITO=" + idcre;
           return buscar(consulta);
        }

        public DataTable SolibyCredi(string idcre)
        {
            string consulta;
            consulta = "SELECT* FROM solicitud sol " +
                       "JOIN asigna_credito ac ON sol.ID_SOLICITUD = ac.ID_SOLICITUD AND ac.COD_CREDITO =" + idcre;
            return buscar(consulta);
           
        }


        public bool updgarantia(string[] datos)
        {
            string consulta;
            consulta = "Update  garantia set tipo='"+datos[1]+"', valuacion=" + datos[2] +", detalle='"+datos[3] + "', Tipo_esc='"+ datos[4]+"', Fecha_esc='"+datos[5]+ "', Autorizo='" +datos[6] +"', ubicacion='"+datos[7]+"', Estado='"+datos[8]+"' where id_garant=" + datos[0];
            return (consulta_gen(consulta));
        }
        #endregion

        public DataTable solicitud(string cred)
        {
           
            string consulta = "SELECT sol.ID_SOLICITUD, cre.COD_CREDITO " +
                             "from solicitud sol " +
                            "INNER JOIN asigna_solicitud asol ON asol.ID_SOLICITUD = sol.ID_SOLICITUD " +
                            "inner JOIN asigna_credito acre ON asol.ID_SOLICITUD = sol.ID_SOLICITUD " +
                            "INNER JOIN credito cre ON acre.COD_CREDITO = cre.COD_CREDITO " +
                            $"WHERE acre.COD_CREDITO = {cred} AND sol.ID_SOLICITUD = acre.ID_SOLICITUD";
           return buscar(consulta);
        }

        public DataTable BuscaFiadPorSol(string sol)
        {
            string consulta = "SELECT cli.nombres,cli.apellidos,cli.municipio,cli.departamento, cli.domicilio,cli.estado_civil,cli.profesion,cli.telefono1,cli.telefono2,cli.genero "+
                              "FROM cliente cli "+
                              "INNER JOIN sol_fiad sfia ON sfia.Id_Fia = cli.CODIGO_CLI "+
                              $"WHERE sfia.Id_sol ={sol}";
            return buscar(consulta);
        }


        #region Solicitud etapa2
        private int id_EstadoFin()
        {
            string consulta;
            consulta = "SELECT max(id_estfin) FROM estadofin";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value)
            {
                return int.Parse(datos.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }

        private int id_IngresoMensual()
        {
            string consulta;
            consulta = "SELECT max(id_ingmen) FROM ingresocli";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value)
            {
                return int.Parse(datos.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }

        private int id_EgresoMensual()
        {
            string consulta;
            consulta = "SELECT max(id_egrmen) FROM egresocli";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value)
            {
                return int.Parse(datos.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }

        public bool IngresoEstadoFinan(List<Formularios.SubClases.Cuenta> datos,string sol)
        {
            if (datos == null || !datos.Any()) return false;
            bool respuesta = false;
            int id = id_EstadoFin();
            string consulta = $"Insert into estadofin(Id_estfin,cuenta,valor,tipo) values(?id_estfin,?cuenta,?valor,?tipo)";
            MySqlCommand com1 = new MySqlCommand();
            com1.CommandText = consulta;
            com1.CommandType = CommandType.Text;

            com1.Parameters.Add("?id_estfin", MySqlDbType.Int32);
            com1.Parameters.Add("?cuenta", MySqlDbType.VarChar);
            com1.Parameters.Add("?valor", MySqlDbType.VarChar);
            com1.Parameters.Add("?tipo", MySqlDbType.Bit);

            foreach (var item in datos)
            {
                id++;
                com1.Parameters["?id_estfin"].Value = id;
                com1.Parameters["?cuenta"].Value = item.NomCuenta;
                com1.Parameters["?valor"].Value = item.Valor;
                com1.Parameters["?tipo"].Value = item.tipo;
                List<string> ValorAsoc = new List<string> {id.ToString() ,sol};
                respuesta= (Consulta_tipo2(com1) && AsocEstadoSoli(ValorAsoc));
                if (!respuesta) return false;
            }
            return respuesta;
        }

        public bool AsocEstadoSoli(List<string> datos)
        {
            string consulta = $"Insert into estfin_sol(Id_estfin,id_sol) values(?id_estfin,?id_sol)";
            MySqlCommand com1 = new MySqlCommand();
            com1.CommandText = consulta;
            com1.Parameters.Add("?id_estfin", MySqlDbType.Int32).Value =int.Parse(datos[0]);
            com1.Parameters.Add("?id_Sol", MySqlDbType.Int32).Value = datos[1];
            com1.CommandType = CommandType.Text;
            return Consulta_tipo2(com1);
        }

        public bool IngresoMen(List<Formularios.SubClases.Ingreso> datos,string sol)
        {
            bool respuesta = false;
            string consulta = $"Insert into ingresocli(Id_ingmen,cantidad,producto,costo,venta,ganancia) values(?id_ingmen,?cantidad,?producto,?costo,?venta,?ganancia)";
            int id = id_IngresoMensual();
            MySqlCommand com1 = new MySqlCommand();
            com1.CommandText = consulta;
            com1.CommandType = CommandType.Text;

            com1.Parameters.Add("?id_ingmen", MySqlDbType.Int32);
            com1.Parameters.Add("?cantidad", MySqlDbType.Int32);
            com1.Parameters.Add("?producto", MySqlDbType.VarChar);
            com1.Parameters.Add("?costo", MySqlDbType.Decimal);
            com1.Parameters.Add("?venta", MySqlDbType.Decimal);
            com1.Parameters.Add("?ganancia", MySqlDbType.Decimal);


            foreach (var item in datos)
            {
                id++;
                com1.Parameters["?id_ingmen"].Value = id;
                com1.Parameters["?cantidad"].Value = item.Cantidad;
                com1.Parameters["?producto"].Value = item.Producto;
                com1.Parameters["?costo"].Value = item.Costo;
                com1.Parameters["?venta"].Value = item.Venta;
                com1.Parameters["?ganancia"].Value = item.Ganacia;
               
                List<string> ValorAsoc = new List<string> { id.ToString(), sol };
                respuesta =(Consulta_tipo2(com1) && IngresoSoli(ValorAsoc));
                if (respuesta == false)
                {
                    return false;
                }
            }
            return respuesta;
        }
        public bool IngresoSoli(List<string> datos)
        {
            string consulta = $"Insert into ingreso_sol(Id_ingmen,id_sol) values(?id_ingmen,?id_sol)";
            MySqlCommand com1 = new MySqlCommand();
            com1.CommandText = consulta;
            com1.Parameters.Add("?id_ingmen", MySqlDbType.Int32).Value = (datos[0]);
            com1.Parameters.Add("?id_Sol", MySqlDbType.Int32).Value = datos[1];
            com1.CommandType = CommandType.Text;
            return Consulta_tipo2(com1);
        }

        public bool EgresoMen(List<Formularios.SubClases.Egreso> datos, string sol)
        {
            bool respuesta = false;
            string consulta = $"Insert into egresocli(Id_egrMen,cantidad,detalle,empresa,cuota_men) values(?id_egrmen,?cantidad,?detalle,?empresa,?cuota_men)";
            int id = id_EgresoMensual();
            MySqlCommand com1 = new MySqlCommand();
            com1.CommandText = consulta;
            com1.CommandType = CommandType.Text;

            com1.Parameters.Add("?id_egrmen", MySqlDbType.Int32);
            com1.Parameters.Add("?cantidad", MySqlDbType.Int32);
            com1.Parameters.Add("?detalle", MySqlDbType.VarChar);
            com1.Parameters.Add("?empresa", MySqlDbType.VarChar);
            com1.Parameters.Add("?cuota_men", MySqlDbType.Decimal);

            foreach (var item in datos)
            {
               
                id++;
                com1.Parameters["?id_egrmen"].Value = id;
                com1.Parameters["?cantidad"].Value = item.Cantidad;
                com1.Parameters["?detalle"].Value = item.Detalle;
                com1.Parameters["?empresa"].Value = item.Empresa;
                com1.Parameters["?cuota_men"].Value = item.Cuota_men;
                
                List<string> ValorAsoc = new List<string> { id.ToString(), sol };
                respuesta = (Consulta_tipo2(com1) && EgresoSoli(ValorAsoc));
                if (respuesta == false) return false;
            }
            return respuesta;
        }


        public bool EgresoSoli(List<string> datos)
        {
            string consulta = $"Insert into egreso_sol(id_egrmen,id_sol) values(?id_egrmen,?id_sol)";
            MySqlCommand com1 = new MySqlCommand();
            com1.CommandText = consulta;
            com1.Parameters.Add("?id_egrmen", MySqlDbType.Int32).Value = int.Parse(datos[0]);
            com1.Parameters.Add("?id_sol", MySqlDbType.Int32).Value = int.Parse(datos[1]);
            com1.CommandType = CommandType.Text;
            return Consulta_tipo2(com1);
        }



        #endregion


        #region Solicitud Garantia



        public bool ingresoGarantia(List<Formularios.SubClases.Garantia> datos, string sol)
        {
            string consulta;
            int id = id_garant() + 1;
            int soli = int.Parse(sol);
            consulta = $"Insert into Garantia(Id_garant,tipo,id_prop,Valuacion,detalle,info,estado,recepcion,entrega) " +
               $"values(?Id_garant,?Tipo,?Valuacion,?detalle,?info,?estado,?recepcion,?entrega)";
            // MessageBox.Show(consulta);
            MySqlCommand com = new MySqlCommand();

            com.CommandText = consulta;
            com.CommandType = CommandType.Text;

            com.Parameters.Add("?Id_garant", MySqlDbType.Int32);
            com.Parameters.Add("?Id_prop", MySqlDbType.Int32);
            com.Parameters.Add("?tipo", MySqlDbType.VarChar);
            com.Parameters.Add("?Valuacion", MySqlDbType.Decimal);
            com.Parameters.Add("?detalle", MySqlDbType.VarChar);
            com.Parameters.Add("?info", MySqlDbType.VarChar);
            com.Parameters.Add("?Estado", MySqlDbType.VarChar);
            com.Parameters.Add("?recepcion", MySqlDbType.DateTime);
            com.Parameters.Add("?entrega", MySqlDbType.DateTime);
            bool respo = false;
            foreach (Formularios.SubClases.Garantia item in datos)
            {
                com.Parameters["?Id_garant"].Value = id;
                com.Parameters["?id_prop"].Value = item.Propietario;
                com.Parameters["?tipo"].Value = item.Tipo;
                com.Parameters["?Valuacion"].Value = item.Valor;
                com.Parameters["?detalle"].Value =  item.Detalle;
                com.Parameters["?info"].Value = item.Informacion;
                com.Parameters["?Estado"].Value = "En posesion";
                com.Parameters["?recepcion"].Value = DateTime.Now;
                com.Parameters["?entrega"].Value = DateTime.Now;
                respo = Consulta_General_tipo2(com) && asignaGarant(id,soli);
                if (respo == false) return false;
            }
            return respo;
        }

        public bool asignaGarant(int gar, int sol)
        {
            string consulta;
            consulta = $"insert into sol_garant(id_solicitud,id_gartant) "+
                "values (?sol,?gar)";

            // MessageBox.Show(consulta);
            MySqlCommand com = new MySqlCommand();

            com.CommandText = consulta;
            com.CommandType = CommandType.Text;
            com.Parameters.Add("?sol", MySqlDbType.Int32);
            com.Parameters.Add("?gar", MySqlDbType.Int32);

            com.Parameters["?sol"].Value = sol;
            com.Parameters["?gar"].Value = gar;

            return Consulta_General_tipo2(com);
        }
        #endregion

        #region Solicitud Fiador

        public bool ingresoFiador(List<Formularios.SubClases.Fiador> datos)
        {
            string consulta;
            consulta = $"Insert into sol_fiad(id_sol,id_fia,Othering) " +
               $"values(?sol,?Tipo,?fiad,?other)";
            // MessageBox.Show(consulta);
            MySqlCommand com = new MySqlCommand();

            com.CommandText = consulta;
            com.CommandType = CommandType.Text;

            com.Parameters.Add("?Id_garant", MySqlDbType.Int32);
            com.Parameters.Add("?Id_prop", MySqlDbType.Int32);
            com.Parameters.Add("?Valuacion", MySqlDbType.VarChar);
      
            bool respo = false;
            foreach (Formularios.SubClases.Fiador item in datos)
            {

                com.Parameters["?sol"].Value = item.idSol;
                com.Parameters["?fiad"].Value = item.IdFiad;
                com.Parameters["?other"].Value = item.OtherIng;
              respo=  Consulta_General_tipo2(com);
                    if (respo == false) return false;
            }
            return respo;
        }

        #endregion
    }
}

