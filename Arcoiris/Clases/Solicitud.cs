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

        #endregion
        #region "Datos Solicitud"

        public int id_solicitud()
        {
            string consulta;
            consulta = "Select count(*) from solicitud";
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
                diasp = 22;
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
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
                return false;

            }

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


            string consultaingcre;
            consultaingcre = "insert into Credito(cod_credito,id_tipo_credito, monto,plazo, interes, fecha_conc,fecha_venci, estado,dias_pago,saldo_cap,saldo_int,saldo_ant,gastos_admin) values(" + idcredito + "," + datos[6] + "," + datos[1] + ",'" +/*CAmbiar por datos 2 si es necesario*/ datos[9] + "'," + datos[3] + ",'" + datos[4] + "','" + datos[5] + "','Activo'," + diasp + "," + saldoC + "," + saldoI + "," + datos[8] + ","+datos[10]+")";
            if (consulta_gen(consultaingcre))
            {

                if (asigna_credito(datos[0], idcredito))
                {
                    return true;
                    //agregar a caja

                }
                else
                {
                    return false;
                }
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

}
    }

