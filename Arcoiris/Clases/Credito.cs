using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace Arcoiris.Clases
{
    class Credito
    {
        private Clases.conexion conect = new Clases.conexion();
        CultureInfo provider = CultureInfo.InstalledUICulture;
        #region "General"
        private DataTable buscar(string consulta)
        {
            conect.iniciar();
            DataTable datos = new DataTable();
            try
            {

                MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
                adap.Fill(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
            }
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

        #endregion

        #region "Datos Credito"

        public int id_credit(string idsol)
        {
            string consulta;
            consulta = "SELECT cre.Cod_credito from credito cre " +
                "inner join asigna_credito ac on ac.COD_CREDITO = cre.COD_CREDITO " +
                "inner join solicitud sol on sol.ID_SOLICITUD = ac.ID_SOLICITUD " +
                "where sol.ID_SOLICITUD =" + idsol;
            DataTable datos = new DataTable();
            try
            {
                datos = buscar(consulta);
                return Convert.ToInt32(datos.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }

        }
        //retorna el detalle de los creditos
        public DataTable detalle_cre(int credito, string tipo)
        {
            string consulta;
            consulta = "Select Monto,interes,dias_pago,date_format(Fecha_conc,'%Y/%m/%d'),plazo from credito where cod_credito=" + credito;
            DataTable datos = new DataTable();
            DataTable pagos = new DataTable();
            datos = buscar(consulta);
            pagos = calc_pagos(datos, tipo);
            return pagos;
        }

        public DataTable verfecha(string cre)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "Select plazo,interes,Date_format(fecha_conc,'%d-%m-%Y'),Date_format(fecha_venci,'%d-%m-%Y'),monto from credito where cod_credito=" + cre;
            datos = buscar(consulta);
            return datos;


        }

        public DataTable cancel(string usu)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "Select cre.cod_credito FROM credito cre " +
            "INNER JOIN asigna_credito acre ON acre.COD_CREDITO = cre.COD_CREDITO " +
            "INNER JOIN asigna_solicitud asol ON asol.ID_SOLICITUD = acre.ID_SOLICITUD " +
            "INNER JOIN cliente cli ON cli.CODIGO_CLI = asol.codigo_cli " +
            "WHERE cli.CODIGO_CLI =" + usu + " AND cre.ESTADO = 'Terminado'";
            datos = buscar(consulta);
            return datos;

        }


        public DataTable nombres_cre(int credito)
        {
            string consulta;
            consulta = "Select c.Nombres,C.apellidos,Date_Format(cre.Fecha_venci,'%d-%m-%Y') AS Fecha,cre.monto,cre.Gastos_admin AS ante,cre.plazo,C.Domicilio from cliente c " +
            "inner join asigna_solicitud asol on asol.codigo_cli = c.CODIGO_CLI " +
            "inner join solicitud sol on sol.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "inner join asigna_credito ac on ac.ID_SOLICITUD = sol.ID_SOLICITUD " +
            "inner join credito cre on cre.COD_CREDITO = ac.COD_CREDITO " +
            "where cre.COD_CREDITO=" + credito;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;
        }

        //buscar credito activos

        public DataTable creditos_act(String cod)
        {
            string consulta = "select CAST(Cre.COD_CREDITO as int) as Cod from credito Cre " +
            "INNER JOIN asigna_credito acr ON acr.COD_CREDITO = Cre.COD_CREDITO " +
            "INNER JOIN asigna_solicitud asol ON asol.ID_SOLICITUD = acr.ID_SOLICITUD " +
            "INNER JOIN cliente cli ON cli.CODIGO_CLI = asol.codigo_cli " +
            "where cre.estado = 'Activo' AND asol.codigo_cli =" + cod + "  order by Cod";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return datos;

        }

        public string tipoC(string cre)
        {
            string consulta = "Select id_tipo_credito from credito where cod_credito=" + cre;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            string tipo;
            tipo = datos.Rows[0][0].ToString();
            return tipo;
        }
        public DateTime convertirfecha(string fecha)
        {

            string anio = fecha.Substring(0, 4);
            string mes = fecha.Substring(5, 2);
            string dia = fecha.Substring(8, 2);
            /*  int aniot = Convert.ToInt32(anio);
              int mest = Convert.ToInt32(mes);
              int diat = Convert.ToInt32(dia);
              DateTime nfecha = new DateTime(aniot,mest,diat);*/
            DateTime nfecha = Convert.ToDateTime(fecha);
            return nfecha;
        }

        public string dias_atraso(string credito, string fechas)
        {
            string consulta;
            DateTime fechap;
            consulta = "Select Max(fecha), count(*) as cuantos from pagos where cod_credito=" + credito;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            int NumPagos = Convert.ToInt32(datos.Rows[0][1]);

            DataTable Dcre = new DataTable();
            string consultaT = "Select id_tipo_credito,dias_pago, date_format(Fecha_conc,'%Y-%M-%d') as conce from credito where cod_credito=" + credito;
            Dcre = buscar(consultaT);
            string tipoc = Dcre.Rows[0][0].ToString();
            string valor = "";
            int dmaxatraso = Convert.ToInt32(Dcre.Rows[0][1]);

            //calculo si no existe un pago previo
            if ((datos.Rows[0][0] == DBNull.Value) && NumPagos == 0)
            {
                string fech = Dcre.Rows[0][2].ToString();
                DateTime fechav = Convert.ToDateTime(fech);
                DateTime fechaact = Convert.ToDateTime(fechas);
                // fechaact = Convert.ToDateTime(fechaact.ToString("dd/MM/yyyy"));
                TimeSpan dias = fechaact - fechav;
                int tdias = dias.Days;
                int cont, atra = 0, datraso = 0;
                if (tipoc.Equals("1") || tipoc.Equals("2"))
                {
                    dias = fechaact - fechav.AddDays(1);
                    tdias = dias.Days;
                    for (cont = 1; cont <= tdias; cont++)
                    {

                        if (fechav.DayOfWeek == DayOfWeek.Saturday || fechav.DayOfWeek == DayOfWeek.Sunday)
                        {

                        }
                        else
                        {
                            atra++;
                        }
                        fechav = fechav.AddDays(1);

                    }
                    datraso = atra;
                }
                else if (tipoc.Equals("3") || tipoc.Equals("4"))
                {
                    int mesatras = 0;
                    fechav = fechav.AddDays(1);
                    while (fechav.AddMonths(mesatras) < fechaact)
                    { mesatras++; }
                    datraso = Convert.ToInt32(mesatras);
                }
                if (datraso >= dmaxatraso)
                {
                    datraso = dmaxatraso;
                }
                if (datraso < 0)
                {
                    datraso = 0;
                }
                valor = datraso.ToString();
            }
            else
            {
                DateTime fechav = Convert.ToDateTime(Dcre.Rows[0][2].ToString());
                DateTime fechaact = Convert.ToDateTime(fechas);
                fechap = Convert.ToDateTime(Dcre.Rows[0][2]);
                fechap = fechap.AddMonths(NumPagos);
                DateTime sigfecha = fechav;
                while (fechap > sigfecha)
                { sigfecha = sigfecha.AddMonths(1); }

                TimeSpan dif = fechaact - sigfecha;
                int diastraso = dif.Days;

                int cont, atra = 0, datraso = 0;

                if (tipoc.Equals("1") || tipoc.Equals("2"))
                {
                    for (cont = 1; cont <= diastraso; cont++)
                    {
                        if (fechap.AddDays(cont - 1).DayOfWeek == DayOfWeek.Saturday || fechap.AddDays(cont - 1).DayOfWeek == DayOfWeek.Sunday)
                        {
                        }
                        else
                        {
                            atra++;
                        }
                    }
                    datraso = atra;
                }

                else if (tipoc.Equals("3") || tipoc.Equals("4"))
                {
                    int atram = 0;
                    sigfecha = sigfecha.AddDays(1);
                    while (fechaact >= sigfecha)
                    {
                        atram++;
                        sigfecha = sigfecha.AddMonths(1);
                    }
                    datraso = atram;

                }
                if (datraso > dmaxatraso)
                {
                    datraso = dmaxatraso;
                }
                if (datraso < 0)
                {
                    datraso = 0;
                }
                valor = datraso.ToString();
            }
            return valor;
        }

        public DataTable datoscre(string credito, string fecha)
        {
            string tipo;
            string consulta = "Select id_tipo_credito from credito where cod_credito='" + credito + "'";
            DataTable tipoc = new DataTable();
            DataTable datos = new DataTable();
            tipoc = buscar(consulta);
            tipo = tipoc.Rows[0][0].ToString();
            datos = escoge_calculo(credito, tipo, fecha);
            return datos;
        }

        private DataTable escoge_calculo(string credito, string tipo, string fecha)
        {
            DataTable datos = new DataTable();
            if (tipo.Equals("1"))
            {
                datos = calculo_norm(credito, fecha, "1");
            }
            else if (tipo.Equals("2"))
            {
                datos = interesPrim(credito, fecha, "2");
            }
            else if (tipo.Equals("3"))
            {
                datos = calculo_mes(credito, fecha, "3");
            }
            else if (tipo.Equals("4"))
            {

                datos = calculo_saldo(credito, fecha, "4");
            }

            return datos;
        }

        public DataTable cantcre(string credito, string fecha)
        {
            string consulpago;
            string consulta1;
            DataTable datos = new DataTable();
            consulpago = "Select count(*) from pagos where cod_credito=" + credito + " and estado = 'Hecho'";
            DataTable pag = new DataTable();
            pag = buscar(consulpago);
            int tpagos = Convert.ToInt32(pag.Rows[0][0]);
            decimal pagoint = 0, saldoint = 0;
            if (tpagos > 0)
            {
                int diasatras;
                diasatras = Convert.ToInt32(dias_atraso(credito, fecha));
                DataTable credidat = new DataTable();
                consulta1 = "Select Monto,Saldo_cap,Date_Format(Fecha_venci,'%d-%m-%Y'),id_tipo_credito,interes,dias_pago,saldo_int,Date_format(Fecha_conc,'%d-%m-%Y') as Conc, plazo  from credito where cod_credito='" + credito + "'";
                credidat = buscar(consulta1);
                decimal monto = Convert.ToDecimal(credidat.Rows[0][0]);
                decimal interes = Convert.ToDecimal(credidat.Rows[0][4]);
                int diasmax = Convert.ToInt32(credidat.Rows[0][5]);
                decimal intpag = Math.Round(monto * interes / 100 * (diasatras), 2);
                pagoint = Math.Round(monto * interes / 100 / diasmax, 2);
                saldoint = Saldointe(credito, fecha, credidat.Rows[0][3].ToString(), pagoint);
                DataTable DatosR = new DataTable();
                DatosR.Columns.Add("Monto").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("Saldo").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("Fecha").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("Tipo").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("atraso").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("Saldoint").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("Concesion").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("interes").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("plazo").DataType = System.Type.GetType("System.String");


                DataRow fila = DatosR.NewRow();
                fila["Monto"] = monto;
                fila["Saldo"] = credidat.Rows[0][1];/*monto + intpag;*/
                fila["Fecha"] = credidat.Rows[0][2].ToString();
                fila["Tipo"] = credidat.Rows[0][3];
                fila["atraso"] = diasatras;
                fila["Saldoint"] = saldoint;
                fila["Concesion"] = credidat.Rows[0][7].ToString();
                fila["Interes"] = interes.ToString();
                fila["plazo"] = credidat.Rows[0][8].ToString();

                DatosR.Rows.Add(fila);
                datos = DatosR;
            }
            else
            {
                int diasatras;
                diasatras = Convert.ToInt32(dias_atraso(credito, fecha));

                DataTable credidat = new DataTable();
                consulta1 = "Select Monto,Saldo_cap,Date_Format(Fecha_venci,'%d-%m-%Y'),id_tipo_credito,interes,dias_pago,saldo_int,Date_format(Fecha_conc,'%d-%m-%Y') ,plazo  from credito where cod_credito='" + credito + "'";
                credidat = buscar(consulta1);

                decimal monto = Convert.ToDecimal(credidat.Rows[0][0]);
                decimal interes = Convert.ToDecimal(credidat.Rows[0][4]);
                int diasmax = Convert.ToInt32(credidat.Rows[0][5]);
                pagoint = Math.Round(monto * interes / 100, 2);
                saldoint = Saldointe(credito, fecha, credidat.Rows[0][3].ToString(), pagoint);
                DataTable DatosR = new DataTable();
                DatosR.Columns.Add("Monto").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("Saldo").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("Fecha").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("Tipo").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("atraso").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("Saldoint").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("Concesion").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("interes").DataType = System.Type.GetType("System.String");
                DatosR.Columns.Add("plazo").DataType = System.Type.GetType("System.String");

                DataRow fila = DatosR.NewRow();
                fila["Monto"] = monto;
                fila["Saldo"] = monto;
                fila["Fecha"] = credidat.Rows[0][2];
                fila["Tipo"] = credidat.Rows[0][3];
                fila["atraso"] = diasatras;
                fila["Saldoint"] = saldoint;
                fila["Concesion"] = credidat.Rows[0][7].ToString();
                fila["Interes"] = interes.ToString();
                fila["plazo"] = credidat.Rows[0][8].ToString();
                DatosR.Rows.Add(fila);
                datos = DatosR;

            }

            return datos;
        }

        public decimal saldoant(string usu, string cre)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "select SUM(cre.saldo_cap) AS saldo " +
            "FROM credito cre " +
            "INNER JOIN asigna_credito ascre ON ascre.COD_CREDITO = cre.COD_CREDITO " +
            "INNER JOIN asigna_solicitud asol ON asol.ID_SOLICITUD = ascre.ID_SOLICITUD " +
            "INNER JOIN cliente cli ON cli.CODIGO_CLI = asol.codigo_cli " +
            "WHERE cli.CODIGO_CLI =" + usu + " and Cre.Cod_credito=" + cre;
            datos = buscar(consulta);
            return Convert.ToDecimal(datos.Rows[0][0].ToString());
        }

        public bool cancelar_cre(string credito)
        {
            string consulta;
            consulta = "update credito set estado= 'Terminado' where cod_credito=" + credito;
            if (consulta_gen(consulta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool cancelar_cre2(string credi)
        {
            string consulta;
            consulta = "update credito set estado= 'Cancelado' where cod_credito=" + credi;
            if (consulta_gen(consulta))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal gasadmin(string codcred, string fechain, string fechaf)
        {
            string consulta = "SELECT cre.Gastos_admin from credito cre " +
                              "WHERE cre.COD_CREDITO='" + codcred + "' AND cre.FECHA_CONC >= '" + fechain + "' AND cre.FECHA_CONC <= '" + fechaf + "'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            decimal gasto;
            if (datos.Rows.Count > 0) { return gasto = decimal.Parse(datos.Rows[0][0].ToString()); }
            else
            { return gasto = decimal.Parse("0.00"); }


        }
        #endregion

        #region "Pagos"
        private DataTable calc_pagos(DataTable datos, string tipo)
        {
            DataTable pagos = new DataTable();
            decimal total;
            decimal monto = Convert.ToDecimal(datos.Rows[0][0]);
            decimal interes = Convert.ToDecimal(datos.Rows[0][1]);
            int dias = Convert.ToInt32(datos.Rows[0][2]);
            DateTime fechai = Convert.ToDateTime(datos.Rows[0][3].ToString());
            int diasp = Convert.ToInt32(datos.Rows[0][4]);

            total = Math.Round((monto /*+ (monto * interes / 100)*/), 2);
            decimal pago = total;
            int cont;
            pagos.Columns.Add("orden").DataType = System.Type.GetType("System.String");
            pagos.Columns.Add("fechap").DataType = System.Type.GetType("System.String");
            pagos.Columns.Add("capital").DataType = System.Type.GetType("System.String");
            pagos.Columns.Add("interes").DataType = System.Type.GetType("System.String");
            pagos.Columns.Add("saldo").DataType = System.Type.GetType("System.String");
            int sumfech;
            if (tipo.Equals("1") || tipo.Equals("2"))
            {
                sumfech = 1;
            }
            else
            {
                sumfech = 1;
                //sumfech = 30;
            }

            for (cont = 1; cont <= dias; cont++)
            {
                DataRow fila = pagos.NewRow();
                //agregar datos a fila para despues llenar el reporte
                decimal pagoint = Math.Round((total * interes / 100), 2);
                decimal pagocap = Math.Round((total / dias), 2);
                decimal cuota = Math.Round((pagocap + pagoint), 2);

                switch (tipo)
                {
                    case "1":
                        #region "Calculo 1"
                        if (pago < pagocap || cont >= dias)
                        {
                            //pagoint = Math.Round((pago * interes / 100), 2);
                            // pagocap = Math.Round((pago), 2);
                            cuota = pagocap + pagoint;
                            pago = /*pagoint +pagocap*/0;

                            //  MessageBox.Show("Pago : " + cont + "\n" + "Pago interes: " + pagoint + "\nPago capital: " + pagocap + "\n pago:" + cuota + "\n saldo: " + pago);
                        }
                        else
                        {
                            pago -= pagocap;
                            //  MessageBox.Show("Pago : " + cont + "\n" + "Pago interes: " + pagoint + "\nPago capital: " + pagocap + "\n pago:" + cuota + "\n saldo: " + pago);
                        }
                        fechai = fechai.AddDays(sumfech);


                        #endregion
                        break;

                    case "2":
                        #region "Calculo 2"

                        pagoint = Math.Round((total * interes / 100), 2);
                        pagocap = 0;
                        cuota = Math.Round((pagocap + pagoint), 2);

                        if (cont >= dias)
                        {
                            pagocap = total;
                            pago = 0;

                        }

                        fechai = fechai.AddDays(sumfech);
                        #endregion
                        break;

                    case "3":
                        #region "Calculo 3"
                        pagoint = Math.Round((monto * interes / 100 / 12), 2);
                        pagocap = Math.Round((monto / dias), 2);
                        cuota = pagoint + pagocap;
                        pago -= pagocap;
                        if (cont >= dias)
                        {
                            pago = 0;
                        }
                        /* if ( fechai.Month == 4 || fechai.Month == 6 || fechai.Month == 9 || fechai.Month == 11)
                         {
                             sumfech = 30;
                         }
                         else if (fechai.Month == 2)
                         {
                             sumfech = 28;
                         }
                         else
                         {
                             sumfech = 31;
                         }*/
                        fechai = fechai.AddMonths(sumfech);
                        #endregion
                        break;


                    case "4":
                        #region "Calculo 4"
                        pagoint = Math.Round((pago * interes / 100 / 12), 2);
                        pagocap = Math.Round((monto / dias), 2);
                        cuota = pagoint + pagocap;
                        pago -= pagocap;
                        if (cont >= dias)
                        {
                            pago = 0;
                        }
                        /* if (fechai.Month == 4 || fechai.Month == 6 || fechai.Month == 9 || fechai.Month == 11)
                         {
                             sumfech = 30;
                         }
                         else if (fechai.Month == 2)
                         {
                             sumfech = 28;
                         }
                         else
                         {
                             sumfech = 31;
                         }*/
                        fechai = fechai.AddMonths(sumfech);
                        #endregion
                        break;
                }


                //   fechai = fechai.AddDays(sumfech);
                // MessageBox.Show("Dia revisado: " + fechai.DayOfWeek.ToString());
                if ((fechai.DayOfWeek == DayOfWeek.Saturday || fechai.DayOfWeek == DayOfWeek.Sunday) && (tipo.Equals("1") || tipo.Equals("2")))
                {
                    fechai = fechai.AddDays(1);
                    if ((fechai.DayOfWeek == DayOfWeek.Sunday) && (tipo.Equals("1") || tipo.Equals("2")))
                    {
                        fechai = fechai.AddDays(1);

                    }
                }

                fila["orden"] = cont;
                fila["fechap"] = fechai;
                fila["capital"] = pagocap;
                fila["interes"] = pagoint;
                fila["saldo"] = pago;
                pagos.Rows.Add(fila);

            }
            return pagos;




        }

        private decimal totalpagcap(string credi)
        {
            string consulta = "select SUM(capital) AS totalcap " +
            "FROM pagos " +
            "WHERE cod_credito =" + credi;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            decimal totalcap = 0;
            if (datos.Rows[0][0] != DBNull.Value)
            {
                totalcap = Convert.ToDecimal(datos.Rows[0][0]);
            }

            return totalcap;

        }
        private decimal totalpagint(string credi)
        {
            string consulta = "select SUM(interes) AS totañint " +
           "FROM pagos " +
           "WHERE cod_credito =" + credi;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            decimal totalint = 0;
            if (datos.Rows[0][0] != DBNull.Value)
            {
                totalint = Convert.ToDecimal(datos.Rows[0][0]);
            }

            return totalint;

        }

        private decimal difcapital(string credit, decimal cuotacap, int pagosh)
        {
            decimal totalesp;
            decimal totalh;
            decimal dif;

            totalesp = (pagosh * cuotacap);
            totalh = totalpagcap(credit);
            dif = totalesp - totalh;


            return dif;

        }

        private decimal difint(string credit, decimal cuotaint, int pagosh)
        {
            decimal totalesp;
            decimal totalh;
            decimal dif;
            totalesp = (pagosh * cuotaint);
            totalh = totalpagint(credit);
            dif = totalesp - totalh;

            return dif;

        }
        #endregion

        #region "Calculos"
        //calculo de tipo 1
        private DataTable calculo_norm(string credito, string fecha, string tipo)
        {
            string consulta = "Select Saldo_cap,saldo_int, monto,plazo, interes,dias_pago, id_tipo_credito,Date_Format(Fecha_venci,'%Y-%M-%d'),Date_format(Fecha_conc,'%Y-%M-%d') from credito where COD_CREDITO =" + credito;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            decimal saldoc = Convert.ToDecimal(datos.Rows[0][0]);
            decimal saldoi = Convert.ToDecimal(datos.Rows[0][1]);
            decimal monto = Convert.ToDecimal(datos.Rows[0][2]);
            int dias = Convert.ToInt32(datos.Rows[0][3]);
            int diasp = Convert.ToInt32(datos.Rows[0][5]);
            decimal interes = Convert.ToDecimal(datos.Rows[0][4]);
            DateTime fechavenc = convertirfecha(datos.Rows[0][7].ToString());
            DateTime fechaact = Convert.ToDateTime(fecha);
            //  interes *= dias;
            decimal pagoint = 0;
            decimal pagocap = 0;
            decimal cuota;
            int atraso = Convert.ToInt32(dias_atraso(credito, fecha));
            int pagar = num_pagos(credito);
            int pagarfutu = pagproy(datos.Rows[0][8].ToString(), fechaact.ToString("yyyy/MM/dd"), tipo);

            //Revisar si se hizo el pago de hoy
            string consulp;
            int pagoshoy;
            consulp = "Select count(*), sum(interes), sum(capital) from pagos where cod_credito=" + credito + " and fecha= '" + fecha + "'";
            DataTable datosp = new DataTable();
            datosp = buscar(consulp);
           // decimal intpaga = 0;
            // MessageBox.Show("Numeo de pagos: " + datosp .Rows [0][0].ToString ());
            pagoshoy = Convert.ToInt32(datosp.Rows[0][0].ToString());
            string consultultp;
            consultultp = "SELECT MAX(id_pago), capital, interes FROM pagos WHERE Cod_credito=" + credito;
            DataTable UltPag = new DataTable();
            UltPag = buscar(consultultp);
            string[] saldosante = saldos(credito, "1");
            decimal PagoN = Math.Round((((monto / diasp))), 2);
            decimal intN = Math.Round(((monto * interes / 100)), 2);
            decimal DifCap = difcapital(credito, PagoN, pagarfutu);
            decimal DifInt = difint(credito, intN, pagarfutu);

            // 1) si no se ha hecho ningun pago sin atrasos
            if (pagoshoy == 0 && pagar == 0 && atraso == 0)
            {
                //intpaga = 1;
                pagoint = Math.Round(((monto * interes / 100)), 2);
                pagocap = Math.Round((((monto / diasp))), 2);
                //  MessageBox.Show("1");
            }
            //2) si no se ha hecho ningun pago con atrasos
            else if (pagoshoy == 0 && pagar == 0 && atraso > 0)
            {
                pagoint = Math.Round(((monto * interes / 100) * (atraso)), 2);
                pagocap = Math.Round((((monto / diasp)) * (atraso)), 2);
                //  MessageBox.Show("2");
            }
            //3) hay pagos hoy,  es igual a mayor a la fecha y  no hay atraso
            else if (pagoshoy > 0 && fechaact >= fechavenc && atraso == 0)
            {
                pagoint = 0;
                pagocap = Math.Round((((monto / diasp))), 2);
                pagoint += DifInt;
                pagocap += DifCap;
                //  MessageBox.Show("3");
            }
            //4) no se ha hecho un pago hoy , si existen anteriores, no se ha pasado de la fehca y  hay atraso
            else if (pagoshoy == 0 && pagar > 0 && fechaact < fechavenc && atraso > 0)
            {
                decimal capant = Convert.ToDecimal(UltPag.Rows[0][1]);
                decimal intant = Convert.ToDecimal(UltPag.Rows[0][1]);
                pagoint = Math.Round(((monto * interes / 100) * (atraso)), 2);
                pagocap = Math.Round((((monto / diasp)) * (atraso)), 2);
                if (saldoc <= PagoN && DifCap == saldoc)
                {
                    pagocap = saldoc;
                }
                else
                {
                    pagocap += DifCap;
                }
                if (saldoi <= intN && saldoi == DifInt)
                {
                    pagoint = saldoi;
                }
                else
                {
                    pagoint += DifInt;
                }

                //  MessageBox.Show("4");
            }

            //5) hay pago hoy, no se ha pasado de la fecha no hay atrasos
            else if (pagoshoy > 0 && fechaact < fechavenc && atraso == 0)
            {

                pagocap += DifCap;
                pagoint += DifInt;
                //  MessageBox.Show("5");
            }

            //6)hay pagos hoy, no se ha pasado de la fecha y si hay atraso
            else if (pagoshoy > 0 && fechaact < fechavenc && atraso > 0)
            {
                decimal capant = Convert.ToDecimal(UltPag.Rows[0][1]);
                decimal intant = Convert.ToDecimal(UltPag.Rows[0][1]);

                pagoint = Math.Round(((monto * interes / 100) * (atraso + 1)), 2);
                pagocap = Math.Round((((monto / diasp)) * (atraso + 1)), 2);

                pagocap += DifCap;
                pagoint += DifInt;
                // MessageBox.Show("6");
            }


            //7) no hay pagos hoy, hay pago anteriores, es igual a mayor a la fecha y  no hay atraso
            else if (pagoshoy == 0 && pagar > 0 && fechaact >= fechavenc && atraso == 0)
            {

                pagoint = Math.Round((saldoi), 2);
                pagocap = Math.Round((saldoc), 2);
                //  MessageBox.Show("7");
            }
            //8) hay pagos hoy, hay pagos anteriores, es igual o mayor de la fecha, hay atrasos 
            else if (pagoshoy > 0 && fechaact >= fechavenc && atraso > 0)
            {
                pagoint = Math.Round((saldoi), 2);
                pagocap = Math.Round((saldoc), 2);
                // MessageBox.Show("8");
            }
            //9
            else if (pagoshoy == 0 && fechaact >= fechavenc && atraso > 0)
            {
                pagoint = Math.Round((saldoi), 2);
                pagocap = Math.Round((saldoc), 2);
                // MessageBox.Show("8");
            }
            else
            {
                // MessageBox.Show("Pagos de hoy: " + pagoshoy + "\n Pagos hechos: " + pagar + "\nAtrasos: " + atraso + "\nDias de pago: " + diasp);
            }

            //Fin de revision de pago hoy
            if (pagocap < 0)
            {
                pagocap = 0;
            }
            if (pagoint < 0)
            {
                pagocap = 0;
            }


            cuota = Math.Round((pagocap + pagoint), 2);
            DataTable resp = new DataTable();

            resp.Columns.Add("pagoint").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("pagocap").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("cuota").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("estado").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("capnormal").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("intnormal").DataType = System.Type.GetType("System.String");

            DataRow fila = resp.NewRow();
            fila["pagoint"] = pagoint;
            fila["pagocap"] = pagocap;
            fila["cuota"] = cuota;
            fila["estado"] = datos.Rows[0][6].ToString();
            fila["capnormal"] = PagoN;
            fila["intnormal"] = intN;


            resp.Rows.Add(fila);

            return resp;
        }


        //calculo 2
        private DataTable interesPrim(string credito, string fecha, string tipo)
        {
            string consulta = "Select Saldo_cap,saldo_int, monto,plazo, interes,dias_pago, id_tipo_credito,Date_Format(Fecha_venci,'%d-%M-%Y') from credito where COD_CREDITO =" + credito;
            DataTable datos = new DataTable();
            datos = buscar(consulta);

            decimal saldoc = Convert.ToDecimal(datos.Rows[0][0]);
            decimal saldoi = Convert.ToDecimal(datos.Rows[0][1]);
            decimal monto = Convert.ToDecimal(datos.Rows[0][2]);
            int dias = Convert.ToInt32(datos.Rows[0][3]);
            int diasp = Convert.ToInt32(datos.Rows[0][5]);
            decimal interes = Convert.ToDecimal(datos.Rows[0][4]);
            DateTime fechavenc = convertirfecha(datos.Rows[0][7].ToString());
            DateTime fechaact = convertirfecha(fecha);
            //  interes *= dias;
            decimal pagoint = 0;
            decimal pagocap = 0;
            decimal cuota;
            int atraso = Convert.ToInt32(dias_atraso(credito, fecha));
            int pagar = num_pagos(credito);
            //Revisar si se hizo el pago de hoy
            string consulp;
            int pagoshoy;
            consulp = "Select count(*), sum(interes), sum(capital) from pagos where cod_credito=" + credito + " and fecha= '" + fecha + "'";
            DataTable datosp = new DataTable();
            datosp = buscar(consulp);
            decimal intpaga = 0;
            // MessageBox.Show("Numeo de pagos: " + datosp .Rows [0][0].ToString ());
            pagoshoy = Convert.ToInt32(datosp.Rows[0][0].ToString());
            string consultultp;
            consultultp = "SELECT MAX(id_pago), capital, interes FROM pagos WHERE Cod_credito=" + credito;
            DataTable UltPag = new DataTable();
            UltPag = buscar(consultultp);
            string[] saldosante = saldos(credito, "1");
            decimal PagoN = 0;
            decimal intN = Math.Round(((monto * interes / 100)), 2);

            // 1) si no se ha hecho ningun pago sin atrasos
            if (pagoshoy == 0 && pagar == 0 && atraso == 0)
            {
                intpaga = 1;
                pagoint = Math.Round(((monto * interes / 100)), 2);
                pagocap = 0;
                //   MessageBox.Show("1");
            }
            // 2) si no se ha hecho ningun pago con atrasos
            else if (pagoshoy == 0 && pagar == 0 && fechaact < fechavenc && atraso > 0)
            {
                pagoint = Math.Round(((monto * interes / 100) * (atraso + 1)), 2);
                pagocap = 0;
                //   MessageBox.Show("2");
            }
            //3) hay pagos hoy,  es igual a mayor a la fecha y  no hay atraso
            else if (pagoshoy > 0 && fechaact >= fechavenc && atraso == 0)
            {
                pagoint = 0;
                pagocap = saldoc;
                //  MessageBox.Show("3");
            }
            //4) no se ha hecho un pago hoy , si existen anteriores, no se ha pasado de la fecha y  hay atraso
            else if (pagoshoy == 0 && fechaact >= fechavenc && atraso > 0)
            {

                decimal capant = 0;
                decimal intant = 0;
                if (UltPag.Rows[0][0] != DBNull.Value)
                {
                    capant = Convert.ToDecimal(UltPag.Rows[0][0]);
                }
                if (UltPag.Rows[0][0] != DBNull.Value)
                {
                    intant = Convert.ToDecimal(UltPag.Rows[0][1]);
                }

                pagoint = saldoi;
                pagocap = saldoc;
                //MessageBox.Show("4");
            }

            //5) hay pago hoy, no se ha pasado de la fecha no hay atrasos
            else if (pagoshoy > 0 && fechaact < fechavenc && atraso == 0)
            {
                pagoint = Math.Round(((monto * interes / 100) * (atraso)), 2);
                pagocap = 0;
                //  MessageBox.Show("5");
            }


            //6)hay pagos hoy, no se ha pasado de la fecha y si hay atraso
            else if (pagoshoy > 0 && fechaact < fechavenc && atraso > 0)
            {
                decimal capant = Convert.ToDecimal(UltPag.Rows[0][1]);
                decimal intant = Convert.ToDecimal(UltPag.Rows[0][1]);
                decimal intermedio;
                pagoint = Math.Round(((monto * interes / 100) * (atraso)), 2);
                pagocap = 0;


                if (intant < pagoint)
                {
                    pagoint = Math.Round(((monto * interes / 100)), 2);
                    intermedio = pagoint - intant;
                    intant = Math.Round(((monto * interes / 100) * (atraso + 1)), 2) + intermedio;
                }
                pagocap += Convert.ToDecimal(saldosante[0]);
                pagoint += Convert.ToDecimal(saldosante[1]);
                // MessageBox.Show("6");
            }

            //7) no hay pagos hoy, hay pago anteriores, es igual a mayor a la fecha y  no hay atraso
            else if (pagoshoy == 0 && pagar > 0 && fechaact >= fechavenc && atraso == 0)
            {

                pagoint = Math.Round((saldoi), 2);
                pagocap = Math.Round((saldoc), 2);
                // MessageBox.Show("7");
            }
            //8) hay pagos hoy, hay pagos anteriores, es igual o mayor de la fecha, hay atrasos 
            else if (pagoshoy > 0 && fechaact >= fechavenc && atraso > 0)
            {
                pagoint = Math.Round((saldoi), 2);
                pagocap = Math.Round((saldoc), 2);
                //MessageBox.Show("8");
            }
            //9) hay pagos hoy, hay pagos anteriores, es igual o mayor de la fecha, hay atrasos 
            else if (pagoshoy == 0 && fechaact < fechavenc && atraso > 0)
            {

                decimal capant = Convert.ToDecimal(UltPag.Rows[0][1]);
                decimal intant = Convert.ToDecimal(UltPag.Rows[0][1]);

                pagoint = Math.Round(((monto * interes / 100) * (atraso)), 2);
                pagocap = 0;
                // MessageBox.Show("9");
            }
            else
            {
                // MessageBox.Show("Pagos de hoy: " + pagoshoy + "\n Pagos hechos: " + pagar + "\nAtrasos: " + atraso + "\nDias de pago: " + diasp);
            }

            //Fin de revisin de pago hoy
            cuota = Math.Round((pagocap + pagoint), 2);
            DataTable resp = new DataTable();
            resp.Columns.Add("pagoint").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("pagocap").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("cuota").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("estado").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("capnormal").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("intnormal").DataType = System.Type.GetType("System.String");
            DataRow fila = resp.NewRow();
            fila["pagoint"] = pagoint;
            fila["pagocap"] = pagocap;
            fila["cuota"] = cuota;
            fila["estado"] = datos.Rows[0][6].ToString();
            fila["capnormal"] = PagoN;
            fila["intnormal"] = intN;
            resp.Rows.Add(fila);

            return resp;
        }

        //calculo de tipo 3
        private DataTable calculo_mes(string credito, string fecha, string tipo)
        {
            string consulta = "Select Saldo_cap,saldo_int, monto,plazo, interes,dias_pago, id_tipo_credito,date_format(Fecha_venci,'%Y/%M/%d'),date_format(Fecha_conc,'%Y/%M/%d') from credito where COD_CREDITO =" + credito;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            decimal saldoc = Convert.ToDecimal(datos.Rows[0][0]);
            decimal saldoi = Convert.ToDecimal(datos.Rows[0][1]);
            decimal monto = Convert.ToDecimal(datos.Rows[0][2]);
            int dias = Convert.ToInt32(datos.Rows[0][3]);
            int diasp = Convert.ToInt32(datos.Rows[0][5]);
            decimal interes = Convert.ToDecimal(datos.Rows[0][4]);
            DateTime fechavenc = convertirfecha(datos.Rows[0][7].ToString());
            DateTime fechaact = Convert.ToDateTime(fecha);
            //  interes *= dias;
            decimal pagoint = 0;
            decimal pagocap = 0;
            decimal cuota;
            int atraso = Convert.ToInt32(dias_atraso(credito, fecha));
            int pagar = num_pagos(credito);
            int pagarfutu = 0;


            //Revisar si se hizo el pago de hoy
            string consulp;
            int pagoshoy;
            consulp = "Select count(*), sum(interes), sum(capital) from pagos where cod_credito=" + credito + " and fecha= '" + fecha + "'";
            DataTable datosp = new DataTable();
            datosp = buscar(consulp);
            decimal intpaga = 0;
            pagoshoy = Convert.ToInt32(datosp.Rows[0][0].ToString());
            string consultultp;
            consultultp = "SELECT MAX(id_pago), capital, interes,Date_format(fecha,'%Y-%M-%d') FROM pagos WHERE Cod_credito=" + credito;
            DataTable UltPag = new DataTable();
            UltPag = buscar(consultultp);
            decimal PagoN = Math.Round((((monto / diasp))), 2);
            decimal intN = Math.Round(((monto * interes / 100 / 12)), 2);
            decimal IntAct = Saldointe(credito, fecha, tipo, intN);
            decimal DifCap = 0;
            decimal DifInt = 0;
            // MessageBox.Show("atraso: " + atraso);
            //1) si no se ha hecho ningun pago sin atrasos
            if (pagoshoy == 0 && pagar == 0 && atraso == 0)
            {
                intpaga = 1;
                pagoint = Math.Round(((monto * interes / 100 / 12)), 2);
                pagocap = Math.Round((((monto / diasp))), 2);
                //MessageBox.Show("1");
            }
            // 2) si no se ha hecho ningun pago con atrasos
            else if (pagoshoy == 0 && pagar == 0 && atraso > 0)
            {
                pagoint = Math.Round(((monto * interes / 100 / 12) * (atraso + 1)), 2);
                pagocap = Math.Round((((monto / diasp)) * (atraso + 1)), 2);
                // MessageBox.Show("2");
            }
            //  3) hay pagos hoy,  es igual a mayor a la fecha y  no hay atraso
            else if (pagoshoy > 0 && fechaact >= fechavenc && atraso == 0)
            {
                pagarfutu = pagproy(UltPag.Rows[0][3].ToString(), fechaact.ToString(), tipo);
                DifCap = difcapital(credito, PagoN, pagarfutu);
                DifInt = difint(credito, intN, pagarfutu);


                pagoint = 0;
                pagocap = Math.Round((((monto / diasp))), 2);
                pagoint += DifInt;
                pagocap += DifCap;
                // MessageBox.Show("3");
            }
            //4) no se ha hecho un pago hoy , si existen anteriores, no se ha pasado de la fehca y  hay atraso
            else if (pagoshoy == 0 && pagar > 0 && fechaact < fechavenc && atraso > 0)
            {
                pagarfutu = pagproy(UltPag.Rows[0][3].ToString(), fechaact.ToString(), tipo);
                DifCap = difcapital(credito, PagoN, pagarfutu);
                DifInt = difint(credito, intN, pagarfutu);

                decimal capant = Convert.ToDecimal(UltPag.Rows[0][1]);
                decimal intant = Convert.ToDecimal(UltPag.Rows[0][2]);
                pagoint = Math.Round(((monto * interes / 100 / 12) * (atraso)), 2);
                pagocap = Math.Round((((monto / diasp)) * (atraso)), 2);

                if (saldoc <= pagocap)
                {
                    pagocap = saldoc;
                }
                else
                {
                    //pagocap += DifCap;
                }
                if (saldoi <= pagoint)
                {
                    pagoint = saldoi;
                }
                else
                {
                    //  pagoint += DifInt;
                }
                // MessageBox.Show("4");
            }

            //5) hay pago hoy, no se ha pasado de la fecha no hay atrasos
            else if (pagoshoy > 0 && fechaact < fechavenc && atraso == 0)
            {
                pagocap += DifCap;
                pagoint += DifInt;
                //MessageBox.Show("5");
            }

            //6)hay pagos hoy, no se ha pasado de la fecha y si hay atraso
            else if (pagoshoy > 0 && fechaact < fechavenc && atraso > 0)
            {
                decimal capant = Convert.ToDecimal(UltPag.Rows[0][1]);
                decimal intant = Convert.ToDecimal(UltPag.Rows[0][2]);

                pagoint = Math.Round(((monto * interes / 100 / 12) * (atraso + 1)), 2);
                pagocap = Math.Round((((monto / diasp)) * (atraso + 1)), 2);

                if (saldoc <= PagoN && DifCap == saldoc)
                {
                    pagocap = saldoc;
                }
                else
                {
                    pagocap += DifCap;
                }
                if (saldoi <= intN && saldoi == DifInt)
                {
                    pagoint = saldoi;
                }
                else
                {
                    pagoint += DifInt;
                }
                /// MessageBox.Show("6");
            }


            //7) no hay pagos hoy, hay pago anteriores, es igual a mayor a la fecha y  no hay atraso
            else if (pagoshoy == 0 && pagar > 0 && fechaact >= fechavenc && atraso == 0)
            {

                pagoint = Math.Round((saldoi), 2);
                pagocap = Math.Round((saldoc), 2);
                // MessageBox.Show("7");
            }
            //8) hay pagos hoy, hay pagos anteriores, es igual o mayor de la fecha, hay atrasos 
            else if ((pagoshoy > 0 || pagoshoy == 0) && fechaact >= fechavenc && atraso > 0)
            {
                pagoint = Math.Round((saldoi), 2);
                pagocap = Math.Round((saldoc), 2);
                //MessageBox.Show("8");
            }
            //9) hay pagos hoy, hay pagos anteriores, es igual o mayor de la fecha, hay atrasos 
            else if (pagoshoy == 0 && fechaact <= fechavenc && atraso == 0)
            {
                pagoint = Math.Round(((monto * interes / 100 / 12)), 2);
                pagocap = Math.Round((((monto / diasp))), 2);
                if (saldoc <= PagoN && DifCap == saldoc)
                {
                    pagocap = saldoc;
                }
                else
                {
                    pagocap += DifCap;
                }
                if (saldoi <= intN && saldoi == DifInt)
                {
                    pagoint = saldoi;
                }
                else
                {
                    pagoint += DifInt;
                }

                //MessageBox.Show("9");
            }
            else
            {
                //  MessageBox.Show("Pagos de hoy: " + pagoshoy + "\n Pagos hechos: " + pagar + "\nAtrasos: " + atraso + "\nDias de pago: " + diasp);
            }

            //Fin de revision de pago hoy
            if (pagocap < 0)
            {
                pagocap = 0;
            }
            if (pagoint < 0)
            {
                pagocap = 0;
            }

            cuota = Math.Round((pagocap + pagoint), 2);
            DataTable resp = new DataTable();

            resp.Columns.Add("pagoint").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("pagocap").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("cuota").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("estado").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("capnormal").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("intnormal").DataType = System.Type.GetType("System.String");

            DataRow fila = resp.NewRow();
            fila["pagoint"] = pagoint;
            fila["pagocap"] = pagocap;
            fila["cuota"] = cuota;
            fila["estado"] = datos.Rows[0][2].ToString();
            fila["capnormal"] = PagoN;
            fila["intnormal"] = intN;
            resp.Rows.Add(fila);
            return resp;
        }

        //calculo de tipo 4
        private DataTable calculo_saldo(string credito, string fecha, string tipo)
        {
            string consulta = "Select Saldo_cap,saldo_int, monto,plazo, interes,dias_pago, id_tipo_credito,Date_Format(Fecha_venci,'%Y-%M-%d') from credito where COD_CREDITO =" + credito;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            decimal saldoc = Convert.ToDecimal(datos.Rows[0][0]);
            decimal saldoi = Convert.ToDecimal(datos.Rows[0][1]);
            decimal monto = Convert.ToDecimal(datos.Rows[0][2]);
            int dias = Convert.ToInt32(datos.Rows[0][3]);
            int diasp = Convert.ToInt32(datos.Rows[0][5]);
            decimal interes = Convert.ToDecimal(datos.Rows[0][4]);
            DateTime fechavenc = Convert.ToDateTime(datos.Rows[0][7]);
            DateTime fechaact = Convert.ToDateTime(fecha);
            //  interes *= dias;
            decimal pagoint = 0;
            decimal pagocap = 0;
            decimal cuota;
            int atraso = Convert.ToInt32(dias_atraso(credito, fecha));
            int pagar = num_pagos(credito);
            //Revisar si se hizo el pago de hoy
            string consulp;
            int pagoshoy;
            consulp = "Select count(*), sum(interes), sum(capital) from pagos where cod_credito=" + credito + " and Estado='Hecho'";
            DataTable datosp = new DataTable();
            datosp = buscar(consulp);
            // MessageBox.Show("Numeo de pagos: " + datosp .Rows [0][0].ToString ());
            pagoshoy = Convert.ToInt32(datosp.Rows[0][0].ToString());
            string consultultp;
            consultultp = "SELECT MAX(id_pago), capital, interes FROM pagos WHERE Cod_credito=" + credito;
            DataTable UltPag = new DataTable();
            UltPag = buscar(consultultp);
            decimal PagoN = Math.Round((((monto / diasp))), 2);
            decimal intN = Math.Round(((saldoc * interes / 100 / 12)), 2);
            // 1) si no se ha hecho ningun pago sin atrasos
            if (pagoshoy == 0 && pagar == 0 && atraso == 0)
            {
                pagoint = Math.Round(((saldoc * interes / 100 / 12)), 2);
                pagocap = Math.Round((((monto / diasp))), 2);
                //    MessageBox.Show("1");
            }
            // 2) si no se ha hecho ningun pago con atrasos
            else if (pagoshoy == 0 && pagar == 0 && atraso > 0)
            {
                decimal CuotaBase = 0;
                CuotaBase = Math.Round((monto / diasp), 2);
                Decimal SaldoTemp = saldoc;
                int cont;
                for (cont = 1; cont <= atraso; cont++)
                {
                    pagoint += SaldoTemp * interes / 100 / 12;
                    SaldoTemp -= CuotaBase;
                }
                pagocap = CuotaBase * (atraso);
                // MessageBox.Show("2");
            }
            //3) hay pagos hoy,  es igual a mayor a la fecha y  no hay atraso
            else if (pagoshoy > 0 && fechaact < fechavenc && atraso == 0)
            {
                pagoint = Math.Round(((saldoc * interes / 100 / 12)), 2);
                pagocap = Math.Round((((monto / diasp))), 2);
                //  MessageBox.Show("3");
            }
            //4) no se ha hecho un pago hoy , si existen anteriores, no se ha pasado de la fehca y  hay atraso
            else if (pagoshoy == 0 && pagar > 0 && fechaact < fechavenc && atraso > 0)
            {
                string consulpag = "select capital, interes from pagos p where p.cod_credito =" + credito + " and p.Estado='Hecho'";
                DataTable datapag = new DataTable();
                decimal CuotaBase = 0, SaldoTemp = saldoc, TpagCap = 0, TpagInt = 0, IntProye = 0;
                int cont, Cpag, Total;
                CuotaBase = Math.Round((monto / diasp), 2);
                TpagInt = 0;//saldoc * interes / 100 / 12;
                datapag = buscar(consulpag);
                Total = datapag.Rows.Count;

                //calculo de pagos hechos por el cliente
                for (Cpag = 0; Cpag < Total; Cpag++)
                {
                    TpagInt += SaldoTemp * interes / 100 / 12;
                    TpagCap = decimal.Parse(datapag.Rows[Cpag][0].ToString());
                    SaldoTemp -= TpagCap;
                }
                IntProye = TpagInt;
                for (cont = 1; cont <= atraso; cont++)
                {
                    TpagInt += SaldoTemp * interes / 100 / 12;
                }

                pagoint = TpagInt;
                pagocap = CuotaBase * (diasp);
                //  MessageBox.Show("4");
            }

            //5) hay pago hoy, no se ha pasado de la fecha no hay atrasos
            else if (pagoshoy > 0 && fechaact < fechavenc && atraso == 0)
            {
                pagoint = 0;
                pagocap = Math.Round((((monto / diasp))), 2);
                //   MessageBox.Show("5");
            }

            //6)hay pagos hoy, no se ha pasado de la fecha y si hay atraso
            else if (pagoshoy > 0 && fechaact < fechavenc && atraso > 0)
            {
                string consulpag = "select capital, interes from pagos p where p.cod_credito =" + credito + " and p.Estado='Hecho'";
                DataTable datapag = new DataTable();
                decimal CuotaBase = 0, SaldoTemp = monto, TpagCap = 0, TpagInt = 0, IntProye = 0;
                int cont, Cpag, Total;
                CuotaBase = Math.Round((monto / diasp), 2);
                TpagInt = 0;//saldoc * interes / 100 / 12;
                datapag = buscar(consulpag);
                Total = datapag.Rows.Count;

                //calculo de pagos hechos por el cliente
                for (Cpag = 0; Cpag < Total; Cpag++)
                {
                    TpagInt += SaldoTemp * interes / 100 / 12;
                    TpagCap = decimal.Parse(datapag.Rows[Cpag][0].ToString());
                    SaldoTemp -= TpagCap;
                }
                IntProye = TpagInt;
                for (cont = 1; cont <= atraso; cont++)
                {
                    TpagInt += SaldoTemp * interes / 100 / 12;
                }

                pagoint = TpagInt;
                pagocap = CuotaBase * (diasp);

                //  MessageBox.Show("6");
            }

            //7) no hay pagos hoy, hay pago anteriores, es igual a mayor a la fecha y  no hay atraso
            else if (pagoshoy == 0 && pagar > 0 && fechaact >= fechavenc)
            {
                decimal CuotaBase = 0;
                Decimal SaldoTemp = saldoc;
                int cont;
                for (cont = 1; cont <= diasp; cont++)
                {
                    pagoint += SaldoTemp * interes / 100 / 12;
                    SaldoTemp -= CuotaBase;
                }
                pagocap = saldoc;
                // MessageBox.Show("7");
            }
            //8) hay pagos hoy, hay pagos anteriores, es igual o mayor de la fecha, hay atrasos 
            else if ((pagoshoy > 0 || pagoshoy == 0) && fechaact >= fechavenc)
            {
                decimal CuotaBase = 0;
                Decimal SaldoTemp = saldoc;
                int cont;
                for (cont = 1; cont <= diasp; cont++)
                {
                    pagoint += SaldoTemp * interes / 100 / 12;
                    SaldoTemp -= CuotaBase;
                }
                pagocap = saldoc;
                //   MessageBox.Show("8");
            }
            else if ((pagoshoy == 0) && pagar > 0 && fechaact < fechavenc && atraso == 0)
            {
                pagoint = Math.Round(((saldoc * interes / 100 / 12)), 2);
                pagocap = Math.Round(((monto / diasp)), 2);
            }
            else
            {
                //  MessageBox.Show("Pagos de hoy: " + pagoshoy + "\n Pagos hechos: " + pagar + "\nAtrasos: " + atraso + "\nDias de pago: " + diasp);
            }


            cuota = Math.Round((pagocap + pagoint), 2);
            pagocap = Math.Round(pagocap, 2);
            pagoint = Math.Round(pagoint, 2);

            DataTable resp = new DataTable();

            resp.Columns.Add("pagoint").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("pagocap").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("cuota").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("estado").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("capnormal").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("intnormal").DataType = System.Type.GetType("System.String");
            DataRow fila = resp.NewRow();
            fila["pagoint"] = pagoint;
            fila["pagocap"] = pagocap;
            fila["cuota"] = cuota;
            fila["estado"] = datos.Rows[0][5].ToString();
            fila["capnormal"] = PagoN;
            fila["intnormal"] = intN;
            resp.Rows.Add(fila);


            return resp;

        }
        #endregion

        #region "Revisar cantidades finales"

        private string[] saldos(string credito, string tipo)
        {
            int pagos = num_pagos(credito);
            string consulSalpag;
            decimal totalScapital;
            decimal totalSinteres;
            int diaspago;
            decimal interes;
            decimal capital;
            decimal pint;
            decimal pcap;

            decimal totalPcapital;
            decimal totalPinteres;
            DataTable Salpago = new DataTable();
            consulSalpag = "Select Sum(capital) as capital, sum(interes) as interes from pagos where cod_credito=" + credito;
            if (pagos > 0)
            {
                Salpago = buscar(consulSalpag);
                totalPcapital = Convert.ToDecimal(Salpago.Rows[0][0]);
                totalPinteres = Convert.ToDecimal(Salpago.Rows[0][1]);
            }
            else
            {
                totalPcapital = 0;
                totalPinteres = 0;
            }

            DataTable credi = new DataTable();
            string consul = "Select Monto,dias_pago,interes from credito where cod_credito=" + credito;
            credi = buscar(consul);
            capital = Convert.ToDecimal(credi.Rows[0][0]);
            interes = Convert.ToDecimal(credi.Rows[0][2]);
            diaspago = Convert.ToInt32(credi.Rows[0][1]);

            pcap = Math.Round(capital / diaspago * pagos, 2);
            pint = Math.Round(capital * interes / 100 * pagos, 2);

            if (totalPinteres < pint)
            {
                totalSinteres = pint - totalPinteres;
            }
            else
            {
                totalSinteres = 0;
            }
            if (totalPcapital < pcap)
            {
                totalScapital = pcap - totalPcapital;

            }
            else
            {
                totalScapital = 0;

            }
            string[] saldo = { totalScapital.ToString(), totalSinteres.ToString() };

            return saldo;
        }

        //Encontrar el numero de pagos
        private int num_pagos(string credito)
        {
            string consulta = "Select count(*) from pagos where cod_credito=" + credito + " and estado= 'Hecho'";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return Convert.ToInt32(datos.Rows[0][0].ToString());
        }
        private int pagproy(string fechaini, string fechaAct, string tipo)
        {
            //limitar pagos a num de pagso maximos
            DateTime fechai = Convert.ToDateTime(fechaini);
            DateTime fechaa = Convert.ToDateTime(fechaAct);
            DateTime fechap;

            TimeSpan dias = fechaa - fechai;
            int totdia = dias.Days;
            int cont;
            int diashab = 0;
            if (totdia >= 30) totdia = totdia;
            for (cont = 1; cont <= totdia; cont++)
            {
                if (fechai.AddDays(cont).DayOfWeek == DayOfWeek.Sunday || fechai.AddDays(cont).DayOfWeek == DayOfWeek.Saturday)
                {

                }
                else
                {
                    diashab++;
                }
            }
            if (tipo.Equals("3") || tipo.Equals("4"))
            {
                diashab = 0;
                int conteo = 1;
                fechap = fechai.AddMonths(conteo);
                while (fechaa > fechap)
                {
                    conteo++;
                    fechap = fechai.AddMonths(conteo);
                    diashab++;
                }
            }


            return diashab;
        }

        public int diasnopag(string cre, string fecha, string fechai)
        {
            int numpag = num_pagos(cre), Totd = 0;
            DataTable tipo = new DataTable();
            DataTable Pagos = new DataTable();
            string tipoc;
            string constipo = "Select id_tipo_credito,date_format(Fecha_conc,'%Y/%M/%d'),monto,interes,dias_pago,Fecha_venci as fechaf from credito where cod_credito =" + cre;
            string Consulpagos = "Select SUM(capital) AS capital,SUM(interes) AS interes FROM pagos WHERE cod_credito=" + cre + " AND estado ='Hecho'";
            tipo = buscar(constipo);
            Pagos = buscar(Consulpagos);
            decimal TotCap = 0;
            if (Pagos.Rows[0][0] != DBNull.Value) TotCap = Convert.ToDecimal(Pagos.Rows[0][0]);
            decimal TotInt = 0;
            if (Pagos.Rows[0][1] != DBNull.Value) TotInt = Convert.ToDecimal(Pagos.Rows[0][1]);
            decimal monto = Convert.ToDecimal(tipo.Rows[0][2]), interes = Convert.ToDecimal(tipo.Rows[0][3]);

            int diasP = Convert.ToInt32(tipo.Rows[0][4]);
            if (tipo.Rows[0][0] == DBNull.Value)
            {
                tipoc = "0";
                return 0;
            }
            else
            {
                tipoc = tipo.Rows[0][0].ToString();
            }

            DateTime Fini = Convert.ToDateTime(tipo.Rows[0][1].ToString());
            DateTime Ffin = Convert.ToDateTime(fecha);
            TimeSpan dif;
            decimal TotG = TotCap + TotInt;
            if (tipoc == "1")
            {
                decimal Pcap = Math.Round((monto / diasP), 2), Pint = Math.Round((monto * interes / 100), 2);
                int dias = 0, cont, Dfin = 0;
                DateTime Inicio = Fini;
                dif = Ffin - Inicio;
                dias = dif.Days;
                for (cont = 1; cont <= dias; cont++)
                {

                    Fini = Fini.AddDays(1);
                    TotG -= (Pcap + Pint);
                    if (TotG >= 0) Dfin++;
                    if (Fini.DayOfWeek == DayOfWeek.Saturday || Fini.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Dfin++;
                    }
                }
                dias -= Dfin;
                if (dias < 0) dias = 0;
                Totd = dias;
            }
            else if (tipoc == "2")
            {
                DateTime final = Convert.ToDateTime(tipo.Rows[0][5]);
                decimal Pcap = 0;
                if (Ffin >= final) Pcap = 0;//Math.Round((monto / diasP), 2); 
                decimal Pint = Math.Round((monto * interes / 100), 2);
                int dias = 0, cont, Dfin = 0;
                DateTime Inicio = Fini;
                dif = Ffin - Inicio;
                dias = dif.Days;
                for (cont = 1; cont <= dias; cont++)
                {
                    Fini = Fini.AddDays(1);
                    TotG -= (Pcap + Pint);
                    if (TotG >= 0) Dfin++;
                    if (Fini.DayOfWeek == DayOfWeek.Saturday || Fini.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Dfin++;
                    }
                }
                dias -= Dfin;
                if (dias < 0) dias = 0;
                Totd = dias;
            }
            else if (tipoc == "3")
            {

                /* ---------------------------------mal funcionamiento de dias no pagados
                 //Fini = Fini.AddMonths(1);
                 // Fini = Fini.AddMonths(numpag);
                 string credi = cre;
                 decimal Pcap = Math.Round((monto / diasP), 2), Pint = Math.Round((monto * interes / 100 / 12), 2);
                 int contdi = 0, cont = 0, Dfin = 0;
                 DateTime fcamb = Fini.AddMonths(1);

                 while (Ffin > fcamb)
                 {
                     fcamb = fcamb.AddMonths(1);
                     TotG -= (Pcap + Pint);
                     if (TotG > 0) Dfin++;
                 }
                // Dfin++;

                 dif = Ffin - Fini.AddMonths(Dfin);
                 contdi = dif.Days;
                 if (contdi < 0) contdi = 0;
                 Totd = contdi;*/
                //---------------------------------------mal funcionamiento de dias no pagados

                 decimal sint, scap, cuotac;
                 DataTable saldos = new DataTable();
                 saldos = saldosdias(cre, fecha);
                 cuotac = Math.Round((monto / diasP),2);
                 scap = decimal.Parse(saldos.Rows[0][0].ToString());
                 sint = decimal.Parse(saldos.Rows[0][1].ToString());
                 int atraso = 0;
                 if (scap <= 0 && sint <= 0)
                 {

                     atraso = 0;
                 }
                 else if (scap > 0 && sint <= 0)
                 {

                     while (scap > 0)
                     {
                         atraso++;
                         scap -= cuotac;
                     }
                 }
                 else if (scap <= 0 && sint > 0)
                 {

                     decimal pagoint;
                     pagoint = Math.Round((monto * interes / 100 / 12),2);
                     while (sint > 0)
                     {
                         atraso++;
                         sint -= pagoint;
                     }
                 }
                 else
                 {
                     decimal pagoint;
                     pagoint = Math.Round((monto *interes/100/12));
                     while (scap > 0 || sint > 0)
                     {
                         atraso++;
                         sint -= pagoint;
                         scap -= cuotac;
                     }
                 }
                 int conteo = 1;
                 DateTime fechaavanz = Fini;
                 while (Ffin > fechaavanz)
                 {
                     fechaavanz = Fini.AddMonths(conteo);
                     conteo++;
                 }
                 fechaavanz = fechaavanz.AddMonths(-atraso);
                 dif = Ffin - fechaavanz;
                 Totd = dif.Days;
                
            }
            else if (tipoc == "4")
            {



                /*inicio de calculo oimitido temporalmente para atraso de dias ---------------------------------------------------------------------------------------------
                               //Calculo de atraso...
                                decimal montoprov = monto;
                                decimal Pcap = Math.Round((monto / diasP), 2), Pint = Math.Round((monto * interes / 100 / 12), 2); 
                                DataTable datosp = new DataTable();
                                string consulpag = "select capital, interes from pagos p where p.cod_credito = " + cre + " and p.Estado = 'Hecho'";
                                datosp = buscar(consulpag);
                                int contdi = 0, cont = 0, Dfin = 0, cant = datosp.Rows.Count;
                                DateTime fcamb = Fini.AddMonths(0);
                                while (Ffin > fcamb)
                                {
                                    if (cont < cant)
                                    {
                                        if (datosp.Rows[cont][0] != DBNull.Value)
                                        {
                                            Pcap = decimal.Parse(datosp.Rows[cont][0].ToString());
                                           Pint= Math.Round(((monto-Pcap) * interes / 100 / 12), 2);
                                        }
                                        else
                                        {
                                            Pcap = 0;
                                        }
                                    }
                                    else
                                    {
                                        Pcap = 0;
                                        Pint = 0;
                                    }
                                    fcamb = fcamb.AddMonths(1);

                                    TotG -= (Pcap + Pint);
                                    if (TotG > 0) Dfin++;
                                    montoprov -= Pcap;
                                    Pint = Math.Round((montoprov * interes / 100 / 12), 2);
                                    cont++;
                                }
                                Dfin++;
                                if (TotG > 0) Dfin=cant-1;
                                //if (datosp.Rows.Count == 0) Dfin = 0;
                                dif = Ffin - Fini.AddMonths(Dfin);
                                contdi = dif.Days;
                                if (contdi < 0) contdi = 0;
                                Totd = contdi;
                                /*  Fini = Fini.AddMonths(1);
                                  Fini = Fini.AddMonths(numpag);
                                  dif = Ffin - Fini;
                                  Totd = dif.Days;//
                                  final de  parte omitida para registro de nuevo calculo de dias atrasados en creditos mensulaes sobre saldo-------------------------------------------------*/

                decimal sint, scap,cuotac;
                DataTable saldos = new DataTable();
                saldos = saldosdias(cre, fecha);
                cuotac = monto / diasP;
                scap = decimal.Parse(saldos.Rows[0][0].ToString());
                sint = decimal.Parse(saldos.Rows[0][1].ToString());
                int atraso=0;
                if (scap <= 0 && sint <= 0)
                {
                 
                    atraso= 0;
                }
                else if (scap > 0 && sint <= 0)
                {
                    
                    while (scap > 0)
                    {
                        atraso++;
                        scap -= cuotac;
                    }
                }
                else if (scap <= 0 && sint > 0)
                {
                   
                    decimal montonew, pagoint;
                    montonew = monto - scap;
                    pagoint = Math.Round((montonew * interes / 100 / 12));
                    while (sint > 0)
                    {
                        atraso++;
                        sint -= pagoint;
                    }
                }
                else
                {
                    decimal montonew, pagoint;
                    montonew = monto - scap;
                    pagoint = Math.Round((montonew * interes / 100 / 12),2);
                    while (scap>0 || sint>0)
                    {
                        atraso++;
                        sint -= pagoint;
                        scap -= cuotac;
                    }
                }
                int conteo = 1;
                DateTime fechaavanz= Fini;
                while (Ffin > fechaavanz)
                {
                    fechaavanz = Fini.AddMonths(conteo);
                    conteo++;
                }
                fechaavanz = fechaavanz.AddMonths(-atraso);
                dif = Ffin - fechaavanz;
                Totd = dif.Days;
            }
            if (Totd < 0) Totd = 0;
            return Totd;
        }


        // calculo del interes para poner al dia
        public DataTable saldosdias(string cre, string fecha)
        {
            //parte 1 datos originales
            string consulCre = "Select Monto,interes,dias_pago,id_tipo_credito,date_format(Fecha_conc,'%Y-%M-%d') as fecha,date_format(Fecha_conc,'%d-%M-%Y') as fecha1 from credito where cod_credito=" + cre + " and estado='Activo'";
            string tipo = "";
            DataTable datcre = new DataTable();
            datcre = buscar(consulCre);
            decimal monto = 0, inte = 0;
            int dias = 0; DateTime fechaC = DateTime.Now;
            if (datcre.Rows.Count > 0)
            {
                monto = Convert.ToDecimal(datcre.Rows[0][0]);
                inte = Convert.ToDecimal(datcre.Rows[0][1]);
                dias = Convert.ToInt32(datcre.Rows[0][2]);
                fechaC = Convert.ToDateTime(datcre.Rows[0][4]);
                tipo = datcre.Rows[0][3].ToString();
            }




            //parte 2 calculo de valores 

            int pagos = pagproy(fechaC.ToString("yyyy/MM/dd"), fecha, tipo);//revisar numero de pagos que deberia haberse hecho
            int atraso = Convert.ToInt32(dias_atraso(cre, fecha));
            decimal pint = 0, pcap = 0, ptot = 0, PcapO = 0;
            if (pagos > dias) pagos = dias;
            if (tipo == "1")
            {
                pcap = Math.Round((monto / dias), 2);
                pint = Math.Round((monto * inte / 100), 2);

                //   MessageBox.Show("Capital atrasado: " + capatra + "\nInteres Atrasado: "+intatra );
                pcap *= pagos;
                pint *= pagos;
                //    MessageBox.Show("Capital proyectado: " + capatra + "\nInteres proyectado: " + intatra);
                pcap = Math.Round(pcap, 2);
                pint = Math.Round(pint, 2);
                ptot = pcap + pint;
            }
            else if (tipo == "2")
            {
                pcap = 0;
                if (pagos >= dias) pcap = monto;
                pint = Math.Round((monto * inte / 100), 2);
                //   MessageBox.Show("Capital atrasado: " + capatra + "\nInteres Atrasado: "+intatra );
                pcap *= 1;
                pint *= pagos;
                //    MessageBox.Show("Capital proyectado: " + capatra + "\nInteres proyectado: " + intatra);
                pcap = Math.Round(pcap, 2);
                pint = Math.Round(pint, 2);
                ptot = pcap + pint;
            }
            else if (tipo == "3")
            {
               // pagos--;
                pcap = Math.Round((monto / dias), 2);
                pint = Math.Round((monto * inte / 100 / 12), 2);
                //   MessageBox.Show("Capital atrasado: " + capatra + "\nInteres Atrasado: "+intatra );
                pcap *= pagos;
                pint *= pagos;
                //    MessageBox.Show("Capital proyectado: " + capatra + "\nInteres proyectado: " + intatra);
                pcap = Math.Round(pcap, 2);
                pint = Math.Round(pint, 2);
                ptot = pcap + pint;
            }
            else if (tipo == "4")
            {
                int conteo;
                fechaC = Convert.ToDateTime(datcre.Rows[0][5].ToString());
                string ConPagosH;
                ConPagosH = "Select capital,interes,date_format(fecha,'%Y-%M-%d'),date_format(fecha,'%d-%M-%Y') from pagos p where p.cod_credito=" + cre + " and p.estado='Hecho'";
                DataTable datosph = new DataTable();
                datosph = buscar(ConPagosH);
                pcap = Math.Round((monto / dias), 2);
                // pint= monto * inte / 100 / 12; 
                PcapO = pcap;
                //------------------------------------------- si los pagos hechos son iguales a los pagos requeridos
                if (pagos == datosph.Rows.Count)
                {
                    //  pagos--;
                    DateTime fechap = new DateTime();
                    DateTime fechaph = new DateTime();
                    Boolean pasarpago = false;
                    decimal cint =  monto * inte / 100 / 12M;
                    int ordenpag = 0, pagostot = datosph.Rows.Count, sigpago = 0;
                    fechap = fechap.AddDays(1);
                    // pint += Math.Round(cint,2);
                    for (conteo = 0; conteo < pagos; conteo++)
                    {
                        pint += Math.Round(cint, 2);
                        // cint = monto * inte / 100 / 12;
                        fechap = fechaC.AddMonths(sigpago);
                        int pagado = 0;
                        fechaph = DateTime.Parse(datosph.Rows[ordenpag][3].ToString());
                        if (fechaph > fechap && fechaph <= fechap.AddMonths(2))
                        {
                            monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                            cint = Math.Round((monto * inte / 100 / 12),2);
                            pagado++;
                            ordenpag++;
                            sigpago++;
                        }
                        else if (fechaph > fechap.AddMonths(2))
                        {
                            cint = Math.Round((monto * inte / 100 / 12), 2);
                            monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                            ordenpag++;
                            pagado++;
                            sigpago++;
                        }
                        else if (fechaph < fechap.AddMonths(2))
                        {
                            monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                            cint = Math.Round((monto * inte / 100 / 12), 2);
                            ordenpag++;
                            pagado++;
                            sigpago++;
                        }
                        else
                        {
                            sigpago++;
                            monto -= 0;
                            cint = monto * inte / 100 / 12;
                        }
                    }
                }
                // -------------------------------------------si el numero de pagos requeridos es mayor a los efectuados
                else if (pagos > datosph.Rows.Count)
                {
                    //pagos--;
                    DateTime fechap = new DateTime();
                    DateTime fechaph = new DateTime();
                    Boolean pasarpago = false;
                    decimal cint = Math.Round((monto * inte / 100 / 12), 2);
                    int ordenpag = 0, pagostot = datosph.Rows.Count, sigpago = 0;
                    fechap = fechap.AddDays(1);
                    for (conteo = 0; conteo < pagos; conteo++)
                    {
                        pint += Math.Round(cint, 2);
                        // cint = monto * inte / 100 / 12;
                        fechap = fechaC.AddMonths(sigpago);
                        int pagado = 0;
                        if (ordenpag < pagostot)
                        {
                            cint = 0;
                            pasarpago = false;
                            fechaph = DateTime.Parse(datosph.Rows[ordenpag][3].ToString());
                            if (fechaph >= fechap && fechaph <= fechap.AddMonths(2))
                            {
                                monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                                cint += Math.Round((monto * inte / 100 / 12),2);
                                pagado++;
                                ordenpag++;
                                sigpago++;
                            }
                            else if (fechaph > fechap.AddMonths(1))
                            {
                                cint = Math.Round((monto * inte / 100 / 12), 2);
                                if (fechaph >= fechap && fechaph <= fechap.AddMonths(2))
                                {
                                    monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                                    ordenpag++;
                                }
                                pagado++;
                                sigpago++;
                            }
                            else if (fechaph < fechap.AddMonths(1))
                            {
                                monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                                cint = Math.Round((monto * inte / 100 / 12), 2);
                                ordenpag++;
                                pagado++;
                                sigpago++;
                            }
                            else
                            {
                                sigpago++;
                                pasarpago = true;
                                monto -= 0;
                                cint += monto * inte / 100 / 12;
                            }
                        }
                        else
                        {
                            sigpago++;
                            monto -= 0;
                            cint = monto * inte / 100 / 12;
                        }
                    }
                }
                else
                {
                    // si los pagos hechos son mayores a los pagos esperados
                    // pagos--;
                    DateTime fechap = new DateTime();
                    DateTime fechaph = new DateTime();
                    Boolean pasarpago = false;
                    decimal cint = monto * inte / 100 / 12;
                    int ordenpag = 0, pagostot = datosph.Rows.Count, sigpago = 0;
                    for (conteo = 0; conteo < pagos; conteo++)
                    {
                        pint += Math.Round(cint, 2);
                        // cint = monto * inte / 100 / 12;
                        fechap = fechaC.AddMonths(sigpago);
                        fechap = fechap.AddDays(1);
                        int pagado = 0;
                        if (ordenpag < pagostot)
                        {
                            cint = 0;
                            pasarpago = false;
                            while (!pasarpago)
                            {
                                fechaph = DateTime.Parse(datosph.Rows[ordenpag][3].ToString());
                                if (fechaph > fechap && fechaph < fechap.AddMonths(2))
                                {
                                    monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                                    cint = Math.Round((monto * inte / 100 / 12),2);
                                    pagado++;
                                    ordenpag++;
                                    if (ordenpag == pagostot)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    sigpago++;
                                    pasarpago = true;
                                    if (cint <= 0)
                                    {
                                        monto -= 0;
                                        cint =Math.Round((monto * inte / 100 / 12),2);
                                    }
                                }
                            }
                        }
                        else
                        {
                            sigpago++;
                            monto -= 0;
                            cint = Math.Round((monto * inte / 100 / 12),2);
                        }
                    }

                }
                //pcap = 0;//
                pcap = (decimal.Parse(datcre.Rows[0][0].ToString()) / dias) * pagos;
                pcap = Math.Round(pcap, 2);
                pint = Math.Round(pint, 2);
                ptot = pcap + pint;
            }

            //Paso 3 obtener total de pagos hechos
            string consulpagoH = "Select sum(capital) as capital, sum(interes) as interes from pagos where cod_credito=" + cre + " and estado='Hecho'";
            DataTable datsal = new DataTable();
            datsal = buscar(consulpagoH);
            decimal Scap, Sint;
            if (datsal.Rows[0][0] == DBNull.Value)
            { Scap = 0; }
            else
            { Scap = Convert.ToDecimal(datsal.Rows[0][0]); }

            if (datsal.Rows[0][1] == DBNull.Value)
            { Sint = 0; }
            else
            { Sint = Convert.ToDecimal(datsal.Rows[0][1]); }

            //paso 4 sumar todos los valores y retornarlos en un datatable
            decimal Rint, Rcap, Rtot;
            Rcap = Math.Round((pcap - Scap), 2);
            Rint = Math.Round((pint - Sint), 2);
           // if (Rint < 0) Rint = 0;

            Rtot = Rcap + Rint;
            DataTable resp = new DataTable();
            resp.Columns.Add("Capital").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("Interes").DataType = System.Type.GetType("System.String");
            resp.Columns.Add("Total").DataType = System.Type.GetType("System.String");
            DataRow fila = resp.NewRow();
            fila["Capital"] = Rcap;
            fila["Interes"] = Rint;
            fila["Total"] = Rtot;
            resp.Rows.Add(fila);

            return resp;
        }
        //Crear pago de interes periodo
        public decimal SaldoDeinteres(string cre, string fecha, string tipo, decimal cuotaint)
        {
            return Saldointe(cre, fecha, tipo, cuotaint);
        }
        //Crear pago de interes periodo
        private decimal Saldointe(string cre, string fecha, string tipo, decimal cuota)
        {
            decimal saldop, CapPag, total;
            DateTime fechaf = Convert.ToDateTime(fecha);
            string consultad = "Select date_format(fecha_conc,'%d-%M-%y') as fecha, monto,interes,dias_pago, Date_format(Fecha_venci,'%Y-%M-%d') from credito where cod_credito=" + cre;

            DataTable datosc = new DataTable();
            datosc = buscar(consultad);
            DateTime fechaT = Convert.ToDateTime(datosc.Rows[0][4]);
            decimal inter = Convert.ToDecimal(datosc.Rows[0][2]);
            decimal monto = Convert.ToDecimal(datosc.Rows[0][1]);
            if (fechaf > fechaT.AddDays(1))
            {
                fechaf = fechaT.AddDays(1);
            }
            DateTime fechacon = Convert.ToDateTime(datosc.Rows[0][0]);
            int contarpag = 0;
            string consulpag;
            int dias = Convert.ToInt32(datosc.Rows[0][3].ToString());
            consulpag = "Select sum(interes) as interes, sum(capital) as capital from pagos where cod_credito=" + cre + " and estado= 'Hecho'";
            DataTable datosp = new DataTable();
            datosp = buscar(consulpag);

            if (datosp.Rows[0][0] == DBNull.Value)
            {
                saldop = 0;
            }
            else
            {
                saldop = Convert.ToDecimal(datosp.Rows[0][0]);
            }
            if (datosp.Rows[0][1] == DBNull.Value)
            {
                CapPag = 0;
            }
            else
            {
                CapPag = Convert.ToDecimal(datosp.Rows[0][1]);
            }
            //tipo 1 de credito
            if (tipo == "1")
            {
                cuota = Math.Round((monto * inter / 100), 2);
                fechacon = fechacon.AddDays(1);
                while (fechaf > fechacon)
                {
                    fechacon = fechacon.AddDays(1);
                    if (fechacon.DayOfWeek == DayOfWeek.Monday || fechacon.DayOfWeek == DayOfWeek.Sunday)
                    {
                        //    MessageBox.Show(fechacon.DayOfWeek.ToString());
                    }
                    else
                    {
                        contarpag++;
                    }
                }
                if (contarpag > dias) contarpag = dias;
                cuota = cuota * contarpag;
            }
            //tipo 2 de credito
            else if (tipo == "2")
            {
                cuota = Math.Round((monto * inter / 100), 2);
                fechacon = fechacon.AddDays(1);
                while (fechaf >= fechacon)
                {
                    fechacon = fechacon.AddDays(1);
                    if (fechacon.DayOfWeek == DayOfWeek.Monday || fechacon.DayOfWeek == DayOfWeek.Sunday)
                    {
                        //  MessageBox.Show(fechacon.DayOfWeek.ToString());
                    }
                    else
                    {
                        contarpag++;
                    }
                }
                if (contarpag > dias) contarpag = dias;
                cuota = cuota * contarpag;
            }
            //tipo 3 de credito
            else if (tipo == "3")
            {
                cuota = Math.Round((monto * inter / 100 / 12), 2);
                fechacon = fechacon.AddDays(1);
                while (fechaf >= fechacon)
                {
                    fechacon = fechacon.AddMonths(1);
                    contarpag++;
                }
               // contarpag--;
                if (contarpag > dias) contarpag = dias;
                cuota = cuota * contarpag;
            }
            //tipo 4 de credito
            else if (tipo == "4")
            {
                DateTime fechaC = new DateTime();
                decimal pcap = 0, PcapO, inte, pint = 0;
                int conteo, pagos;
                fechaC = Convert.ToDateTime(datosc.Rows[0][0].ToString());
                fechaC = fechaC.AddDays(1);
                string ConPagosH;
                ConPagosH = "Select capital,interes,date_format(fecha,'%Y-%M-%d'),date_format(fecha,'%d-%M-%Y') from pagos p where p.cod_credito=" + cre + " and p.estado='Hecho'";
                DataTable datosph = new DataTable();
                datosph = buscar(ConPagosH);
                pcap = Math.Round((monto / dias), 2);
                // pint= monto * inte / 100 / 12; 
                PcapO = pcap;
                pagos = pagproy(fechaC.ToString("yyyy/MM/dd"), fecha, tipo);
               pagos++;
                //pagos = datosph.Rows.Count;
                //------------------------------------------- si los pagos hechos son iguales a los pagos requeridos
                if (pagos == datosph.Rows.Count)
                {
                    pagos--;
                    DateTime fechap = new DateTime();
                    DateTime fechaph = new DateTime();
                    decimal cint = Math.Round((monto * inter / 100 / 12), 2);
                    int ordenpag = 0, pagostot = datosph.Rows.Count, sigpago = 0;
                   // fechap = fechap.AddDays(sigpago);
                    fechap = fechap.AddDays(1);
                    pint += Math.Round(cint, 2);
                    for (conteo = 0; conteo < pagos; conteo++)
                    {
                        cint = 0;
                        // cint = monto * inte / 100 / 12;
                        fechap = fechaC.AddMonths(sigpago);
                        fechap = fechap.AddDays(1);
                        int pagado = 0;
                        fechaph = DateTime.Parse(datosph.Rows[ordenpag][3].ToString());
                        if (fechaph >= fechap && fechaph < fechap.AddMonths(2))
                        {
                            monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                            cint = Math.Round((monto * inter / 100 / 12), 2);
                            ordenpag++;
                            pagado++;
                            sigpago++;
                        }
                        else if (fechaph > fechap.AddMonths(2))
                        {
                            cint = Math.Round((monto * inter / 100 / 12), 2);
                            monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                            ordenpag++;
                            pagado++;
                            sigpago++;
                        }
                        else if (fechaph < fechap.AddMonths(2))
                        {
                            monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                            cint = Math.Round((monto * inter / 100 / 12), 2);
                            ordenpag++;
                            pagado++;
                            sigpago++;
                        }
                        else
                        {
                            /*sigpago++;
                            monto -= 0;
                            cint = Math.Round((monto * inter / 100 / 12), 2);
                            if (ordenpag < pagos - 1) monto -= decimal.Parse(datosph.Rows[ordenpag + 1][0].ToString());*/
                            cint = 0;
                        }
                        pint += cint;
                    }
                    cuota = pint;
                }
                // -------------------------------------------si el numero de pagos requeridos es mayor a los efectuados
                else if (pagos > datosph.Rows.Count)
                {
                    //pagos--;
                    DateTime fechap = new DateTime();
                    DateTime fechaph = new DateTime();
                    Boolean pasarpago = false;
                    decimal cint = Math.Round((monto * inter / 100 / 12), 2);
                    int ordenpag = 0, pagostot = datosph.Rows.Count, sigpago = 0;
                    fechap = fechap.AddDays(1);
                    for (conteo = 0; conteo < pagos; conteo++)
                    {
                        pint += Math.Round(cint, 2);
                        // cint = monto * inte / 100 / 12;
                        fechap = fechaC.AddMonths(sigpago);
                       fechap = fechap.AddDays(1);
                        int pagado = 0;
                        if (ordenpag < pagostot)
                        {
                            cint = 0;
                            fechaph = DateTime.Parse(datosph.Rows[ordenpag][3].ToString());
                            if (fechaph >= fechap && fechaph < fechap.AddMonths(2))
                            {
                                monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                                cint = Math.Round((monto * inter / 100 / 12), 2);
                                pagado++;
                                ordenpag++;
                                sigpago++;
                            }
                            else if (fechaph > fechap.AddMonths(1))
                            {
                                cint = Math.Round((monto * inter / 100 / 12), 2);
                                if (fechaph >= fechap.AddMonths(1) && fechaph <= fechap.AddMonths(2))
                                {
                                    monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                                    ordenpag++;
                                }
                                pagado++;
                                sigpago++;
                            }
                            else if (fechaph < fechap.AddMonths(1))
                            {
                                monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                                cint = Math.Round((monto * inter / 100 / 12), 2);
                                ordenpag++;
                                pagado++;
                                sigpago++;
                            }
                            else
                            {
                                sigpago++;
                                monto -= 0;
                                cint = Math.Round((monto * inter / 100 / 12), 2);
                            }
                        }
                        else
                        {
                            sigpago++;
                            monto -= 0;
                            cint = Math.Round((monto * inter / 100 / 12), 2);
                        }
                    }
                    cuota = pint;
                }
                else
                {
                    // si los pagos hechos son mayores a los pagos esperados
                    // pagos--;
                    DateTime fechap = new DateTime();
                    DateTime fechaph = new DateTime();
                    Boolean pasarpago = false;
                    decimal cint = monto * inter / 100 / 12;
                    int ordenpag = 0, pagostot = datosph.Rows.Count, sigpago = 0;
                    for (conteo = 0; conteo < pagos; conteo++)
                    {
                        pint += Math.Round(cint, 2);
                        // cint = monto * inte / 100 / 12;
                        fechap = fechaC.AddMonths(sigpago);
                    fechap = fechap.AddDays(1);
                        int pagado = 0;
                        if (ordenpag < pagostot)
                        {
                            cint = 0;
                            pasarpago = false;
                            while (!pasarpago)
                            {
                                fechaph = DateTime.Parse(datosph.Rows[ordenpag][3].ToString());
                                if (fechaph > fechap && fechaph < fechap.AddMonths(2))
                                {
                                    monto -= decimal.Parse(datosph.Rows[ordenpag][0].ToString());
                                    cint = monto * inter / 100 / 12;
                                    pagado++;
                                    ordenpag++;
                                    if (ordenpag == pagostot)
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    sigpago++;
                                    pasarpago = true;
                                    if (cint <= 0)
                                    {
                                        monto -= 0;
                                        cint = monto * inter / 100 / 12;
                                    }
                                }
                            }
                        }
                        else
                        {
                            sigpago++;
                            monto -= 0;
                            cint = monto * inter / 100 / 12;
                        }
                    }
                    cuota = pint;
                }
            }
            total = cuota - saldop;
            if (total < 0) total = 0;
            total = Math.Round(total, 2);
            return total;
        }
        #endregion

        #region "Calculo comisiones"
        public DataTable creditos(string aseso)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = "SELECT c.COD_CREDITO,c.MONTO, c.INTERES,c.PLAZO,c.Dias_pago,Date_format(c.FECHA_CONC,'%Y/%m/%d'),date_format(c.FECHA_VENCI,'%Y/%m/%d'),c.id_tipo_credito, cli.NOMBRES, cli.APELLIDOS,c.Estado " +
                      "FROM credito c " +
                      "INNER JOIN asigna_credito ac ON ac.COD_CREDITO = c.COD_CREDITO " +
                      "INNER JOIN solicitud sol ON sol.ID_SOLICITUD = ac.ID_SOLICITUD " +
                      "INNER JOIN asigna_credito acre ON acre.ID_SOLICITUD = sol.ID_SOLICITUD " +
                      "INNER JOIN asigna_solicitud asol ON asol.ID_SOLICITUD = sol.ID_SOLICITUD " +
                      "INNER JOIN cliente cli ON cli.CODIGO_CLI = asol.codigo_cli " +
                      "WHERE asol.COD_ASESOR = " + aseso + " and c.Estado!='Cancelado' " +
                      "ORDER BY cli.nombres,c.FECHA_CONC, c.COD_CREDITO asc";
            return buscar(consulta);

        }

        public decimal totalpagAct(string credito, string fechai, string fechaf)
        {
            string consulta;
            decimal valor;
            DataTable datos = new DataTable();
            consulta = "SELECT SUM(p.interes) FROM pagos p " +
                       "INNER JOIN credito c ON c.COD_CREDITO = p.COD_CREDITO " +
                       "WHERE p.Estado = 'Hecho' AND c.COD_CREDITO = " + credito + " and p.fecha>='" + fechai + "' and p.fecha<='" + fechaf + "'";
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value)
            {
                valor = decimal.Parse(datos.Rows[0][0].ToString());
            }
            else
            {
                valor = 0;
            }
            return valor;
        }

        public decimal totalpagAnt(string credito, string fechai, string fechaf)
        {
            string consulta;
            decimal valor;
            DataTable datos = new DataTable();
            consulta = "SELECT SUM(p.Interes) FROM pagos p " +
                       "INNER JOIN credito c ON c.COD_CREDITO = p.COD_CREDITO " +
                       "WHERE p.Estado = 'Hecho' AND c.COD_CREDITO = " + credito + " and p.fecha<='" + fechaf + "' and p.fecha>='" + fechai + "'";
            datos = buscar(consulta);
            if (datos.Rows[0][0] != DBNull.Value)
            {
                valor = decimal.Parse(datos.Rows[0][0].ToString());
            }
            else
            {
                valor = 0;
            }
            return valor;
        }

        public decimal totalGenAnt(string credito, string fechai, string fechaf)
        {
            if (UltpCredi(credito, fechai, fechaf))
            {
                string consulta;
                DataTable datos = new DataTable();
                decimal total;
                consulta = "SELECT SUM(p.Interes), Sum(p.Capital) FROM pagos p " +
                       "INNER JOIN credito c ON c.COD_CREDITO = p.COD_CREDITO " +
                       "WHERE p.Estado = 'Hecho' AND c.COD_CREDITO = " + credito;
                datos = buscar(consulta);
                total = decimal.Parse(datos.Rows[0][0].ToString()) + decimal.Parse(datos.Rows[0][1].ToString());
                return total;
            }
            else
            {
                return 0;
            }
        }

        public int pagosfutu(string fechai, string fechaAct, string tipo)
        {
            return pagproy(fechai, fechaAct, tipo);
        }


        public bool UltpCredi(string credito, string fechai, string fechaf)
        {
            string consulta;
            decimal interes, capital, total;
            DataTable datos = new DataTable();
            consulta = "Select Sum(p.capital), sum(p.interes) " +
                "From pagos p " +
                "where p.cod_credito = " + credito + " and  p.fecha>= '" + fechai + "' and p.fecha<='" + fechaf + "' and estado = 'Hecho'";
            datos = buscar(consulta);
            if (datos.Rows[0][0] == DBNull.Value)
            {
                capital = 0;
            }
            else
            {
                capital = decimal.Parse(datos.Rows[0][0].ToString());
            }

            if (datos.Rows[0][1] == DBNull.Value)
            { interes = 0; }
            else
            {
                interes = decimal.Parse(datos.Rows[0][1].ToString());
            }

            total = capital + interes;
            if (total > 0)
            { return true; }
            else
            { return false; }

        }

        public DataTable PagosSobresaldo(string idcod)
        {
            DataTable datos = new DataTable();
            string consulta;
            consulta = "SELECT c.monto,c.interes,c.Dias_pago,p.FECHA, p.capital, p.interes " +
                       "FROM credito c " +
                       "INNER JOIN pagos p ON p.COD_CREDITO = c.COD_CREDITO " +
                       "WHERE c.COD_CREDITO = " + idcod + " AND p.Estado = 'Hecho'";
            datos = buscar(consulta);
            return datos;
        }


        public bool PagosCredCance(string credito, string fechai, string fechaf)
        {
            DataTable datos = new DataTable();
            int pagos;
            string consulta;
            consulta = "SELECT COUNT(*) FROM pagos p " +
                      "INNER JOIN credito c ON c.COD_CREDITO = p.COD_CREDITO " +
                      "WHERE(SELECT MAX(p.FECHA) FROM pagos p " +
                      "INNER JOIN credito c ON c.COD_CREDITO = p.COD_CREDITO " +
                      "WHERE c.COD_CREDITO = " + credito + " AND p.Estado = 'Hecho' AND c.ESTADO = 'Terminado') >= '" + fechai + "' AND(SELECT MAX(p.FECHA) FROM pagos p " +
                      "INNER JOIN credito c ON c.COD_CREDITO = p.COD_CREDITO " +
                      "WHERE c.COD_CREDITO = " + credito + " AND p.Estado = 'Hecho' AND c.ESTADO = 'Terminado') <= '" + fechaf + "' AND c.COD_CREDITO = " + credito + " AND c.ESTADO = 'Terminado' AND p.Estado = 'Hecho' ";
            datos = buscar(consulta);
            pagos = Int32.Parse(datos.Rows[0][0].ToString());
            if (pagos > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int PagosTot(string cre, string fechai, string fechaf)
        {
            string consulta, consultapgos;
            int pagosh, totalp, totalpagmes;
            DataTable datos = new DataTable();
            DataTable pagoscre = new DataTable();
            consulta = "SELECT p.ID_PAGO,p.FECHA,p.capital,p.interes,p.Mora,p.Total,c.PLAZO " +
                       "FROM pagos p " +
                       "INNER JOIN credito c ON c.COD_CREDITO = p.COD_CREDITO " +
                       "WHERE c.COD_CREDITO = " + cre + " AND p.Estado = 'Hecho' and p.interes>0 " +
                       "GROUP BY p.ID_PAGO";
            datos = buscar(consulta);
            consultapgos = "SELECT COUNT(*) " +
                           "from pagos p " +
                           "INNER JOIN credito c ON c.COD_CREDITO = p.COD_CREDITO " +
                           "WHERE p.FECHA >= '" + fechai + "' AND p.FECHA <= '" + fechaf + "'  and p.Estado = 'Hecho' AND c.COD_CREDITO =" + cre + " AND p.interes>0";
            pagoscre = buscar(consultapgos);
            totalpagmes = Int32.Parse(pagoscre.Rows[0][0].ToString());
            totalp = Int32.Parse(datos.Rows[0][6].ToString());
            pagosh = datos.Rows.Count;
            if (pagosh > totalp)
            {
                return 0;
            }
            else
            {
                return totalpagmes;
            }
        }

        #endregion
    }
}

