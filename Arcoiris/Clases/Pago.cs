using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace Arcoiris.Clases
{
    class Pago
    {
        Clases.conexion conect = new Clases.conexion();
        Clases.Credito cre = new Clases.Credito();

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

        public int idpago(string credito)
        {
            string consulta = "SELECT max(id_pago) FROM pagos p "+
            "INNER JOIN credito cre ON p.COD_CREDITO = cre.COD_CREDITO "+
            "WHERE cre.COD_CREDITO =" + credito;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return Convert.ToInt32(datos.Rows[0][0]);

        }

        public bool Hacer_Pago(string[] datos)
        {
            string estado="";
            //interes y capital  y pago para ingresar en cada pago;
            DataTable credit = new DataTable();
            string tCredit;
            tCredit = cre.tipoC (datos[0]);
            //string tipoC = credit.Rows[0][0].ToString();
            decimal interes = Convert.ToDecimal (datos[1]);
            decimal capital = Convert.ToDecimal(datos[2]);
            decimal pago = Convert.ToDecimal(datos[3]);
            string fecha = Convert.ToDateTime (datos[4]).ToString ("yyyy/MM/dd");
            decimal mora = Convert.ToDecimal(datos[5].ToString ());
            //string fecha = DateTime.Now.ToString("yyyy/MM/dd");
            DataTable credito = new DataTable();
            string consulta;
            consulta = "Select Saldo_int,Saldo_cap,plazo,monto,interes from credito where cod_credito =" + datos[0];
            credito = buscar(consulta);
            //interes y capital para actualizar el credito
            decimal Sinteres = Convert.ToDecimal (credito.Rows[0][0].ToString());
            decimal Scapital = Convert.ToDecimal(credito.Rows[0][1].ToString());
            decimal interesoriginal= Convert.ToDecimal(credito.Rows[0][4].ToString());
          
            if (tCredit == "1")
            {
                Sinteres -= interes;
                Scapital -= capital;
                if (Scapital <= 0)
                {
                    estado = "Terminado";
                }
                else
                {
                    estado = "Activo";
                }
            }
            else if (tCredit == "2")
            {
               
                Sinteres -= interes;
                Scapital -= capital;
                if (Scapital <= 0 /*&& Sinteres <= 0*/)
                {
                    estado = "Terminado";
                    Sinteres = 0;

                }
                else
                {
                    estado = "Activo";
                }
            }
            else if (tCredit == "3")
            {
                Sinteres -= interes;
                Scapital -= capital;
                if (Scapital <= 0 /*&& Sinteres <= 0*/)
                {

                    estado = "Terminado";

                }
                else
                {
                    estado = "Activo";
                }
            }
            else if (tCredit == "4")
            {
                Scapital -= capital;
                int plazo;
                plazo = Convert.ToInt32 (credito.Rows[0][2].ToString());
                int pagpend;
                int tpago;
                tpago = Tpagos(datos[0]);
                pagpend = (plazo - tpago)-1;
                int cont;
                decimal montoOriginal;
                montoOriginal = Convert.ToDecimal (credito.Rows[0][3].ToString());
                decimal tCapital;
                tCapital = capital;
                decimal pagomonet;
                pagomonet = montoOriginal  / plazo ;
                decimal CapCamb=Scapital ;
                decimal IntNuevo=0;
                for (cont = 1; cont <= pagpend; cont++)
                {

                    IntNuevo  += (CapCamb * interesoriginal / 100 / 12);
                    CapCamb -= pagomonet;
                }
                
                Sinteres = IntNuevo;
                if (Scapital <=0 && Sinteres <=0)
                {
                    estado = "Terminado";
                   
                }
                else
                {
                    estado = "Activo";
                }

            }
          

            
            int numpago=pagoorden (datos[0]);
            string consulPago = "Insert into pagos (id_pago,Cod_credito,Fecha, Capital, Interes,mora, Total,estado) values (" +
                numpago + "," + datos[0] + ",'" + fecha + "'," + capital + "," + interes + "," + mora + ","+ pago + ",'Hecho')";
            if (consulta_gen(consulPago))
                {


               // MessageBox.Show("Si se guardo el pago");
                string consulActual="Update Credito set Saldo_cap=" + Scapital + ", Saldo_int=" + Sinteres + ", estado='"+estado  +"' where cod_credito=" + datos[0];
                if (consulta_gen(consulActual))
                {
                    if (estado.Equals("Terminado")) { 
                    MessageBox.Show("El credito ha sido saldado", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return true;
                }
                else {
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No se guardo el pago");
                return false;
            }


           
            

        }

        private int Tpagos(string credito)
        {
            string consulta;
            consulta = "select Count(*) from pagos where cod_credito= " + credito;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return Convert.ToInt32(datos.Rows[0][0].ToString ());
        }

        private int pagoorden(string credito)
        {
            string consulta = "Select count(*) from pagos";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            int nPago;
            nPago = Convert.ToInt32 (datos.Rows[0][0].ToString());
            nPago += 1;
            return nPago;
        }

        public DataTable Pagoscre(string credito)
        {
            DataTable datos =new  DataTable();
            string consulta;
            consulta = "SELECT id_pago AS Documento,Date_format(Fecha,'%d/%M/%Y') as Fecha,Capital, Interes, Mora,Total from pagos WHERE Estado= 'Hecho' and cod_credito='" + credito + "'";
            datos = buscar(consulta);
            return datos;

        }

        public bool estadopago(string codigop,string cred, string cap, string inter)        {
            string consulta;
            consulta = "Update pagos set estado='Cancelado' where id_pago=" + codigop;
            if (regresarsaldo(cred, cap,inter))
            {
                if (consulta_gen(consulta))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private bool regresarsaldo(string credi, string cap, string inter)
        {
            string consulta;
            consulta = "Select saldo_cap,saldo_int from credito where cod_credito=" + credi;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            decimal capital=Convert.ToDecimal (datos.Rows [0][0]);
            decimal interes=Convert.ToDecimal(datos.Rows[0][1]);
            capital += Convert.ToDecimal(cap);
            interes += Convert.ToDecimal(inter);
            string consuupd;
            consuupd = "Update credito set saldo_cap=" + capital + ", saldo_int=" + interes + " where cod_credito=" + credi;
            if (consulta_gen(consuupd))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool cancelarPagoall(string credi)
        {
            string consulta;
            consulta = "Update pagos set estado='Cancelado' where cod_credito=" +credi ;
            if (consulta_gen(consulta))
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        public string FechUltPag(string credi)
        {
            string consulta = "SELECT Max(Date_format(fecha,'%d-%m-%y')) FROM pagos WHERE cod_credito=" + credi;
            DataTable datos = new DataTable();
                datos = buscar(consulta);
            if (datos.Rows[0][0]==DBNull.Value )
            {
                string fechcre = "Select date_format(fecha_conc,'%d-%m-%Y') from credito where cod_credito=" + credi;
                DataTable fech;
                fech = buscar(fechcre);
                DateTime rev;
                rev = Convert.ToDateTime(fech.Rows[0][0]);
                rev = rev.AddDays(1);
                return rev.ToString("dd/MM/yyyy"); ;
            }
            else
            {
                return datos.Rows[0][0].ToString();
            }
        }



    }
}
