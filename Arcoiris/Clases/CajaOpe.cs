using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms ;
namespace Arcoiris.Clases
{
    class CajaOpe
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

        public bool ingreope(string [] datos)
        {
            string consulta;
            consulta = "Insert into caja(id_ope,operacion,monto,descripcion,fecha,estado,cod_usuario,credito,cliente) values(" +
                datos[0]+ ",'" + datos[1] + "'," + datos [2] + ",'" + datos [3] + "','" + datos[4] + "','" + datos[5] + "'," + datos[6] +",'" +datos[7] +"','" + datos[8]+ "')" ;
            if (consulta_gen(consulta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int id_pago()
        {
            string consulta = "Select Max(id_ope) from caja";
            DataTable id = new DataTable();
            id = buscar(consulta);
            return Convert.ToInt32(id.Rows [0][0].ToString ());
        }
        public decimal liquido(string fecha)
        {
            string consulta;
            consulta = "SELECT((SELECT SUM(monto) FROM caja WHERE operacion = 'Ingreso' AND fecha = '"+fecha +"') - " +
            "(SELECT SUM(monto)FROM caja WHERE operacion = 'Egreso' and fecha = '"+fecha +"')) " +
            "AS Liquido FROM caja LIMIT 1";

            return 0;
        }


        public decimal Ingreso(string fecha)
        {
            string consulta;
            consulta = "SELECT SUM(monto) AS ingreso FROM caja "+
            "WHERE estado= 'Activo' AND operacion='Ingreso' and fecha='"+fecha+"'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows.Count >= 1 && datos.Rows[0][0]!=DBNull.Value)
            {
                return Convert.ToDecimal(datos.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }

        public decimal egreso(string fecha)
        {
            string consulta;
            consulta = "SELECT SUM(monto) AS ingreso FROM caja " +
             "WHERE estado= 'Activo' AND operacion='Egreso' and fecha='" + fecha + "'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            if (datos.Rows.Count >= 1 && datos.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToDecimal(datos.Rows[0][0].ToString());
            }
            else
            {
                return 0;
            }
        }
        public DataTable verpagos(string fecha)
        {
            string consulta;
            consulta = "SELECT caj.id_ope,caj.Operacion,caj.Credito,Caj.Cliente,caj.monto,caj.Descripcion,usu.nombre AS Opero "+ 
            "FROM caja caj JOIN usuario usu ON caj.Cod_usuario = usu.COD_USUARIO "+
            "WHERE caj.Estado = 'Activo' AND caj.fecha = '" + fecha +"'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
        }
        public bool eliminarpago(string idcaja)
        {
            string consulta;
            consulta = "Update caja set Estado='Cancelado' where id_ope=" + idcaja;
            return consulta_gen(consulta);
            
        }
        public void imprimir_caja(DataTable datos, string Fecha)
        {
            Reportes.RepEnc enca = new Reportes.RepEnc();
            int total = datos.Rows.Count;
            decimal Todo = 0;
            int cont;
            enca.Titulo="Reporte de caja de fecha: " + Fecha ;

            for (cont = 1; cont <= total; cont++)
            {
                Reportes.RepDetCli detalle = new Reportes.RepDetCli();
                //Operacion
                detalle.pago=(datos .Rows [cont-1][0].ToString ());
                detalle.Credito=(datos.Rows[cont - 1][1].ToString());
                detalle.Cliente= (datos.Rows[cont - 1][2].ToString());
                //monto
                detalle.Total= Convert .ToDecimal (datos.Rows[cont - 1][3].ToString());
                //Descripcion
                detalle.FechaD= datos.Rows[cont - 1][4].ToString();
                //Usuario
                detalle.FechaC = datos.Rows[cont - 1][5].ToString();

                enca.detalleC.Add(detalle);
                if (datos.Rows[cont - 1][0].ToString() == "Ingreso")
                {
                    Todo += Convert.ToDecimal(datos.Rows[cont - 1][3].ToString());
                }
                else
                {
                    Todo -= Convert.ToDecimal(datos.Rows[cont - 1][3].ToString());
                }
            }
            enca.periodo = Todo.ToString ();
            Reportes.CajaRep caja = new Reportes.CajaRep();
            caja.Enc.Clear();
            caja.Enc.Add(enca);
            caja.Det = enca.detalleC;
            caja.Show();

        


        }
    }
}
