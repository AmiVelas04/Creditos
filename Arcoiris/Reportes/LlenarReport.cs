using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
namespace Arcoiris.Reportes
{
    class LlenarReport
    {
        Clases.conexion conect = new Clases.conexion();
        Clases.ClAsesor ase = new Clases.ClAsesor();
        Clases.Cliente cli = new Clases.Cliente();
        Clases.Credito cre = new Clases.Credito();
        Clases.Pago pag = new Clases.Pago();

        private DataTable buscar(string consulta)
        {
            conect.iniciar();
            MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
            DataTable datos = new DataTable();
            adap.Fill(datos);
            return datos;
        }

        public void llenar_rep(int credito, string tipo)
        {
            DataTable datosenc = new DataTable();
            DataTable datosdet = new DataTable();
            datosenc = cre.nombres_cre(credito);
            datosdet = cre.detalle_cre(credito, tipo);

            Reportes.TablaEnc enca = new Reportes.TablaEnc();
            if (tipo.Equals("1") || tipo.Equals("2"))
            {
                enca.CreditoP = "Diario";
            }
            else
            {
                enca.CreditoP = "Mensual";
            }
            enca.NoCredito = credito;
            enca.cliente = datosenc.Rows[0][1].ToString() + ", " + datosenc.Rows[0][0].ToString();
            enca.fechaV = datosenc.Rows[0][2].ToString();
            enca.total = Convert.ToDecimal(datosenc.Rows[0][3].ToString());
            enca.gastos = Convert.ToDecimal(datosenc.Rows[0][4]);
            int totalf;
            totalf = datosdet.Rows.Count;
            int cont;
            for (cont = 0; cont <= totalf - 1; cont++)
            {
                Reportes.TablaDet deta = new Reportes.TablaDet();
                DateTime fech = Convert.ToDateTime(datosdet.Rows[cont][1].ToString());
                string pfech = fech.ToString("dd/MM/yyyy");
                deta.orden = Convert.ToInt32(datosdet.Rows[cont][0]);
                deta.fecha = pfech;
                deta.pagodet = Convert.ToDecimal(datosdet.Rows[cont][2]);
                deta.pagoint = Convert.ToDecimal(datosdet.Rows[cont][3]);
                deta.saldo = Convert.ToDecimal(datosdet.Rows[cont][4]);

                enca.detalle.Add(deta);
            }

            Reportes.Tablapagos mostrar_pagos = new Reportes.Tablapagos();
            mostrar_pagos.Enca.Add(enca);
            mostrar_pagos.Deta = enca.detalle;
            mostrar_pagos.Show();

        }


        public void ResumenDesem(int credito, string tipo, string gasto, string dpi,string salante)
        {
            DataTable datosenc = new DataTable();
            DataTable datosdet = new DataTable();
            datosenc = cre.nombres_cre(credito);
            datosdet = cre.detalle_cre(credito, tipo);

            Reportes.TablaEnc enca = new Reportes.TablaEnc();
            if (tipo.Equals("1") || tipo.Equals("2"))
            {
                enca.CreditoP = "Diario";
            }
            else
            {
                enca.CreditoP = "Mensual";
            }
            enca.NoCredito = credito;
            enca.cliente = datosenc.Rows[0][0].ToString() + ", " + datosenc.Rows[0][1].ToString();
            enca.fechaV = datosenc.Rows[0][2].ToString();
            enca.total = Convert.ToDecimal(datosenc.Rows[0][3].ToString());
            enca.gastos = Convert.ToDecimal(salante);
            enca.gaper = Convert.ToDecimal(gasto);
            enca.dpi = dpi;
            int totalf;
            totalf = datosdet.Rows.Count;
            int cont;
            for (cont = 0; cont <= totalf - 1; cont++)
            {
                Reportes.TablaDet deta = new Reportes.TablaDet();
                DateTime fech = Convert.ToDateTime(datosdet.Rows[cont][1].ToString());
                string pfech = fech.ToString("dd/MM/yyyy");
                deta.orden = Convert.ToInt32(datosdet.Rows[cont][0]);
                deta.fecha = pfech;
                deta.pagodet = Convert.ToDecimal(datosdet.Rows[cont][2]);
                deta.pagoint = Convert.ToDecimal(datosdet.Rows[cont][3]);
                deta.saldo = Convert.ToDecimal(datosdet.Rows[cont][4]);
                enca.detalle.Add(deta);
            }

            Reportes.Resumen Resumen = new Reportes.Resumen();
            Resumen.Enca.Add(enca);
            Resumen.Deta = enca.detalle;
            Resumen.Show();
        }

        public DataTable Reporte_general(string Consulta)
        {
            DataTable datos = new DataTable();
            datos = buscar(Consulta);
            return datos;
        }

        public void Cred_ver(string estado, string titulo)
        {
            Reportes.RepEnc Enca = new Reportes.RepEnc();
            string consulta,ConsulAdd = "";
            if (estado == "Diario")
            { ConsulAdd = "and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2) "; }
            else if (estado == "Mensual")
            { ConsulAdd = "and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4) "; }
            consulta = "SELECT CONCAT(cli.nombres,' ', cli.apellidos) AS Nombre, cre.monto, DATE_format(cre.FECHA_CONC,'%d/%m/%Y'),DATE_format(cre.FECHA_VENCI,'%d/%m/%Y'), CONCAT(cli.TELEFONO1,'\n',cli.Telefono2,'\n',cli.TelefonoCon) AS telefonos,cli.codigo_cli,cre.cod_credito, CONCAT(gar.Tipo,'\n',gar.Detalle,'\n',gar.Valuacion,'\n',gar.Estado) AS Garantias " +
            "FROM cliente cli " +
            "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI " +
            "INNER JOIN asigna_credito acre ON acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "LEFT JOIN sol_garant solg ON solg.Id_Solicitud = acre.ID_SOLICITUD "+
            "Left JOIN garantia gar ON gar.id_garant = solg.id_garant "+
            "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO " +
            "WHERE cre.ESTADO = 'Terminado' " +ConsulAdd  + 
            "Group by Nombre";
            DataTable credito = new DataTable();
            credito = buscar(consulta);
            int cont, total;
            total = credito.Rows.Count;
            Enca.Titulo = titulo;
            for (cont = 0; cont <= total - 1; cont++)
            {
                string ultpag = "Select date_format(Max(fecha),'%d/%m/%Y') from pagos where cod_credito= " + credito.Rows[cont][6].ToString();
                string Garantia = credito.Rows[cont][7] != DBNull.Value ? credito.Rows[cont][7].ToString() : "Sin Garantia";
                DataTable cance = new DataTable();
                cance = buscar(ultpag);

                if (!CredAct(credito.Rows[cont][5].ToString())) { 
                Reportes.RepDetCli detalle = new Reportes.RepDetCli();
                detalle.Cliente = credito.Rows[cont][0].ToString();
                detalle.Total = Convert.ToDecimal(credito.Rows[cont][1]);
                detalle.FechaD = credito.Rows[cont][2].ToString();
                //detalle.FechaC = credito.Rows[cont][3].ToString();
                    detalle.FechaC = cance.Rows[0][0].ToString();
                    detalle.pago = "N/E";
                detalle.tel = credito.Rows[cont][4].ToString();
                    detalle.Garantia = Garantia;
                Enca.detalleC.Add(detalle);
                }
            }
            Reportes.Cre_Cance_Vig creditos = new Reportes.Cre_Cance_Vig();
            creditos.Enc.Add(Enca);
            creditos.Det = Enca.detalleC;
            creditos.Show();
        }

        private bool CredAct(string idcli)
        {
            string consulta = "SELECT COUNT(*) FROM credito cre "+
                              "INNER JOIN asigna_credito acre ON acre.COD_CREDITO = cre.COD_CREDITO "+
                              "INNER JOIN asigna_solicitud asol ON asol.ID_SOLICITUD = acre.ID_SOLICITUD "+
                              "INNER JOIN cliente cli ON cli.CODIGO_CLI = asol.codigo_cli "+
                              "WHERE cre.ESTADO = 'Activo' AND cli.CODIGO_CLI ="+idcli;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            int cantidad = int.Parse(datos.Rows[0][0].ToString());
            if (cantidad > 0)
            { return true; }
            else
            { return false; }

        }
        public void Cred_venc(string tip)
        {
            Reportes.AtrasosE Encab = new Reportes.AtrasosE();
            Encab.titulo = "Creditos Atrasados";
            string consulta;
            decimal interes, capital;
            consulta = "SELECT cre.cod_credito,CONCAT(cli.nombres,' ', cli.apellidos) AS Nombre, cre.monto, DATE_format(cre.FECHA_CONC,'%d/-%m/%y'), cre.FECHA_VENCI, CONCAT(cli.TELEFONO1,'\n',cli.Telefono2,'\n',cli.TelefonoCon) AS telefonos, interes,cre.id_tipo_credito  " +
            "FROM cliente cli " +
            "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI " +
            "INNER JOIN asigna_credito acre ON acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO " +
            "WHERE cre.ESTADO = 'Activo' order by cli.nombres and cli.apellidos";
            DataTable credito = new DataTable();
            credito = buscar(consulta);
            int cont, total;
            total = credito.Rows.Count;


            for (cont = 0; cont < total; cont++)
            {
                Reportes.AtrasosD detalle = new Reportes.AtrasosD();
                string cod = credito.Rows[cont][0].ToString();
                string tipo= credito.Rows[cont][7].ToString();
                string etiqueta;
                if (tipo == "1" || tipo == "2") { etiqueta = "(D)"; }
                else { etiqueta = "(M)"; }
                int diasatras = 0;
                diasatras = cre.diasnopag(cod, DateTime.Now.Date.ToString("yyyyy/MM/dd"), credito.Rows[0][3].ToString());
                DataTable atras = new DataTable();
                atras = cre.saldosdias(cod, DateTime.Now.Date.ToString());
               
                if (diasatras > 0)
                {
                    decimal inte;
                    inte = Convert.ToDecimal(atras.Rows[0][1].ToString());
                    if (inte < 0) inte = 0;
                    interes = calcint(credito.Rows[cont][0].ToString(), diasatras);
                    capital = calcCap(credito.Rows[cont][0].ToString(), diasatras);
                    if (interes > 0 || capital >0){ 
                    detalle.Nombre = credito.Rows[cont][1].ToString() + " " + etiqueta;
                    detalle.Monto = Convert.ToDecimal(credito.Rows[cont][2]);
                    detalle.Lugar = "Total a cancelar";
                    detalle.Catraso = Convert.ToDecimal(atras .Rows[0][0].ToString ());//capital;
                    detalle.Iatraso = inte;//interes;
                    detalle.dias = diasatras;
                    detalle.Tel = credito.Rows[cont][5].ToString();
                    Encab.Detalle.Add(detalle);
                    }
                }
            }
            Reportes.Atrasos formu =new  Reportes.Atrasos();
            formu.Enca.Add(Encab);
            formu.Deta = Encab.Detalle;
            formu.Show();
        }

        public int diassinpag(string cre)
        {
            string consulpag;
            consulpag = "Select max(fecha) from pagos where cod_credito =" + cre;
            string consulcre;
            consulcre = "Select monto, interes, saldo_cap,Saldo_int,Date_format(Fecha_conc,'%d-%M-%Y') as fechaC,Date_format(Fecha_venci,'%d-%M-%Y') as FechaV from credito where cod_credito=" + cre;
            DataTable pagos = new DataTable();
            DataTable credito = new DataTable();
            pagos = buscar(consulpag);
            credito = buscar(consulcre);
            int totalpag = pagos.Rows.Count;
            DateTime hoy = DateTime.Now;
            DateTime conce = Convert.ToDateTime(credito.Rows[0][4]);
            int dias;
            TimeSpan atraso;
            if (totalpag <= 0 || pagos.Rows[0][0]==DBNull .Value )
            {
                conce = conce.AddMonths(1);
                atraso = hoy - conce;
                dias = atraso.Days;
            }
            else
            {
                DateTime pagoult = Convert.ToDateTime(pagos.Rows[0][0]);
                atraso = conce- pagoult;
                while (atraso .Days <0)
                {
                    conce = conce.AddMonths (1);
                    atraso = conce - pagoult;
                }
                atraso = hoy - conce;
                dias = atraso.Days;
                }
            return dias;
        }

        private decimal calcint(string cred, int diasatras)
        {
            string consulcre;
            DateTime hoy = DateTime.Now, FechaI, FechaV, FechaC; 
           decimal res=0; 
           
            FechaI = hoy.AddDays(-diasatras);
            consulcre = "Select id_tipo_credito,Monto,interes,plazo,Date_format(fecha_conc,'%d-%M-%Y') as FechaC, Date_format(fecha_venci,'%d-%M-%Y') as FechaV,Saldo_int from credito where cod_credito=" + cred;
            DataTable cre = new DataTable();
            cre = buscar(consulcre);
            string tipo=cre.Rows [0][0].ToString ();
            decimal monto= Convert.ToDecimal (cre.Rows[0][1]);
            decimal interes= Convert.ToDecimal(cre.Rows[0][2]);
            FechaC = Convert.ToDateTime(cre.Rows[0][4]);
            FechaV = Convert.ToDateTime(cre.Rows[0][5]);
            decimal saldoI = Convert.ToDecimal(cre.Rows [0][6]);

            TimeSpan diferencia;
            
            int dias;
            bool pasado=false ;

            if (hoy >= FechaV)
            {
                pasado = true;
            }

            if (tipo == "1")
            {
                diferencia = hoy - FechaI;
                dias = diferencia.Days;
                dias = DiasSinFin(dias,FechaI);
                if (pasado)
                { res = saldoI; }
                else
                { res = monto * interes / 100*dias ; }
           
            }
            else if (tipo == "2")
            {
                diferencia = hoy - FechaI;
                dias = diferencia.Days;
                dias = DiasSinFin(dias, FechaI);
                if (pasado)
                { res = saldoI; }
                else
                { res = monto * interes / 100 * dias; }

            }
            else if (tipo == "3")
            {
                int retraso = 0;
               // retraso++;
                diferencia = hoy - FechaI;
                FechaI = FechaI.AddMonths(retraso);
                while (FechaI .AddMonths (retraso)<hoy)
                {
                    retraso++;
                }
                if (pasado)
                { res = saldoI; }
                else
                {
                    res = monto * interes / 100/12 * retraso;
                }

            }
            else if (tipo == "4")
            {

                int retraso = 0;
                retraso++;
                diferencia = hoy - FechaI;
                FechaI = FechaI.AddMonths(retraso);
                while (FechaI.AddMonths(retraso)<hoy)
                {
                    retraso++;
                }
                if (pasado)
                { res = saldoI; }
                else
                {
                    res = monto * interes / 100 * retraso;
                }
            }

            return res;
        }

        private decimal calcCap(string cred, int diasatras)
        {
            string consulcre;
            DateTime hoy = DateTime.Now, FechaI, FechaV, FechaC;
            decimal res = 0;

            FechaI = hoy.AddDays(-diasatras);
            consulcre = "Select id_tipo_credito,Monto,interes,plazo,Date_format(fecha_conc,'%d-%M-%Y') as FechaC, Date_format(fecha_venci,'%d-%M-%Y') as FechaV,Saldo_cap from credito where cod_credito=" + cred;
            DataTable cre = new DataTable();
            cre = buscar(consulcre);
            string tipo = cre.Rows[0][0].ToString();
            decimal monto = Convert.ToDecimal(cre.Rows[0][1]);
            decimal interes = Convert.ToDecimal(cre.Rows[0][2]);
            int plazo = Convert.ToInt32(cre.Rows[0][3]);
            FechaC = Convert.ToDateTime(cre.Rows[0][4]);
            FechaV = Convert.ToDateTime(cre.Rows[0][5]);
            decimal saldoC = Convert.ToDecimal(cre.Rows[0][6]);

            TimeSpan diferencia;

            int dias;
            bool pasado = false;

            if (hoy >= FechaV)
            {
                pasado = true;
            }

            if (tipo == "1")
            {
                diferencia = hoy - FechaI;
                dias = diferencia.Days;
                dias = DiasSinFin(dias, FechaI);
                if (pasado)
                { res = saldoC; }
                else
                { res = monto  /plazo  * dias; }


            }
            else if (tipo == "2")
            {
                diferencia = hoy - FechaI;
                dias = diferencia.Days;
                dias = DiasSinFin(dias, FechaI);
                if (pasado)
                { res = saldoC; }
                else
                { res = 0; }
            }
            else if (tipo == "3")
            {
                int retraso = 0;
              // retraso++;
                diferencia = hoy - FechaI;
                FechaI = FechaI.AddMonths(retraso);
                while (FechaI.AddMonths(retraso)<hoy)
                {
                    retraso++;
                }
                if (pasado)
                { res = saldoC; }
                else
                {
                    res = monto  /plazo* retraso;
                }

            }
            else if (tipo == "4")
            {

                int retraso = 0;
                retraso++;
                diferencia = hoy - FechaI;
                FechaI = FechaI.AddMonths(retraso);
                while (FechaI.AddMonths(retraso)<hoy)
                {
                    retraso++;
                }
                if (pasado)
                { res = saldoC; }
                else
                {
                    res = monto / plazo/12 * retraso;
                }

            }

            return res;
        }

        private int DiasSinFin(int dias,DateTime inicio)
        {
            //int diasreal=0;
            int cont;
            int diasmenos=dias;
            for (cont = 1; cont <= dias; cont++)
            {
                inicio = inicio.AddDays(1);
                if (inicio.DayOfWeek == DayOfWeek.Saturday || inicio.DayOfWeek ==DayOfWeek.Sunday )
                {
                    diasmenos--;
                }
            }
            return diasmenos;


        }

        public void Venc_ord(string titulo,string tip)
        {
            Reportes.AtrasosE Encab = new Reportes.AtrasosE();
            Encab.titulo = titulo;
            string consulta,ConsulAdd="";
            decimal capital;
            if (tip == "Diario")
            { ConsulAdd = "and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2) "; }
            else if (tip == "Mensual")
            { ConsulAdd = "and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4) "; }
            consulta = "SELECT cre.cod_credito,CONCAT(cli.nombres,' ', cli.apellidos) AS Nombre, cre.monto, DATE_format(cre.FECHA_CONC,'%d/%m/%y'), cre.FECHA_VENCI, CONCAT(cli.TELEFONO1,'\n',cli.Telefono2,'\n',cli.TelefonoCon) AS telefonos, interes,cre.id_tipo_credito,CONCAT(gar.Tipo,'\n',gar.Detalle,'\n',gar.Valuacion,'\n',gar.Estado) AS Garantias  " +
            "FROM cliente cli " +
            "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI " +
            "INNER JOIN asigna_credito acre ON acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "LEFT JOIN sol_garant solg ON solg.Id_Solicitud=acre.ID_SOLICITUD "+
            "Left JOIN garantia gar ON gar.id_garant = solg.id_garant "+ 
            "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO " +
            "WHERE cre.ESTADO = 'Activo' "+ ConsulAdd +
            "Group by cre.cod_credito "+
            "order by cli.nombres and cli.apellidos";
            DataTable credito = new DataTable();
            credito = buscar(consulta);
            int cont, total;
            total = credito.Rows.Count;
            for (cont = 0; cont < total; cont++)
            {
                Reportes.AtrasosD detalle = new Reportes.AtrasosD();
                string cod = credito.Rows[cont][0].ToString();
                string tipo = credito.Rows[cont][7].ToString();
                /*string etiqueta="";
                if (tipo == "1" || tipo == "2") { etiqueta = "(D)"; }
                else { etiqueta = "(M)"; }*/
                int diasatras = 0;
                diasatras = cre.diasnopag(cod, DateTime.Now.Date.ToString("yyyy/MM/dd"), credito.Rows[0][3].ToString());
                DataTable atras = new DataTable();
                atras = cre.saldosdias(cod, DateTime.Now.Date.ToString());

                if (diasatras > 0)
                {
                   // interes = calcint(credito.Rows[cont][0].ToString(), diasatras);
                    capital = calcCap(credito.Rows[cont][0].ToString(), diasatras);
                    decimal inte;
                    inte = Convert.ToDecimal(atras.Rows[0][1].ToString());
                    if (inte < 0) inte = 0;

                    if (inte > 0 || capital > 0)
                    {
                        string Garantia = credito.Rows[cont][8] != DBNull.Value ? credito.Rows[cont][8].ToString() : "Sin Garantia";
                        detalle.Nombre = credito.Rows[cont][1].ToString();
                        detalle.Monto = Convert.ToDecimal(credito.Rows[cont][2]);
                        detalle.Lugar = "Total a cancelar";
                        detalle.Catraso = Convert.ToDecimal(atras.Rows[0][0].ToString()); //capital;
                        detalle.Iatraso =inte;//interes;
                        detalle.dias = diasatras;
                        detalle.Tel = credito.Rows[cont][5].ToString();
                        detalle.Garant = Garantia;
                        Encab.Detalle.Add(detalle);
                    }
                }
            }
            Reportes.AtrasOrd formu = new Reportes.AtrasOrd();
            formu.Enca.Add(Encab);
            formu.Deta = Encab.Detalle;
            formu.Show();
        }

        public void ColAct(string titulo, string tip)
        {
            EstadoEnc Encab = new EstadoEnc();
            DataTable credito = new DataTable();
            Encab.cliente  = titulo;
            string consulta,ConsulAdd="";
            if (tip == "Diario")
            { ConsulAdd = "and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2) "; }
            else if (tip == "Mensual")
            { ConsulAdd = "and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4) "; }
            consulta = "SELECT cre.COD_CREDITO, concat(cli.NOMBRES,' ' ,cli.apellidos) AS nombre, cre.monto,cre.plazo,cre.interes,date_format(cre.fecha_conc,'%d-%M-%Y'),date_format(cre.Fecha_venci,'%d-%M-%Y'),cre.saldo_cap, cli.codigo_cli,cre.id_tipo_credito,CONCAT(gar.Tipo,'\n',gar.Detalle,'\n',gar.Valuacion,'\n',gar.Estado) AS Garantias  " +
                       "FROM credito cre " +
                       "INNER JOIN asigna_credito ac ON ac.COD_CREDITO = cre.COD_CREDITO " +
                       "INNER JOIN asigna_solicitud aso ON aso.ID_SOLICITUD = ac.ID_SOLICITUD " +
                       "LEFT JOIN sol_garant solg ON solg.Id_Solicitud = ac.ID_SOLICITUD "+
                       "Left JOIN garantia gar ON gar.id_garant = solg.id_garant "+
                       "INNER JOIN cliente cli ON cli.CODIGO_CLI = aso.codigo_cli " +
                       "WHERE cre.ESTADO = 'Activo' " + ConsulAdd +
                       "GROUP BY cre.COD_CREDITO " +
                       "ORDER BY cre.FECHA_CONC";
            credito = buscar(consulta);
            int cont, total;
            total = credito.Rows.Count;
            for (cont = 0; cont < total; cont++)
            {
                int diasatras;
                decimal cuotac, cuotai, cuota,Ccancelar;
                DatosCre detalle = new DatosCre();
                DataTable datoscli = new DataTable();
                DataTable datcred = new DataTable();
                DataTable saldos = new DataTable();
                DataTable canti = new DataTable();
                DataTable fechas = new DataTable();
                string codigocli = credito.Rows[cont][8].ToString();
                string tipo = credito.Rows[cont][9].ToString();
                string Conscli = "select telefono1,telefono2,telefonocon as telefono from cliente where codigo_cli=" + codigocli;
                datoscli = buscar(Conscli);
                string codigocre = credito.Rows[cont][0].ToString();
                string consfech = "SELECT date_format(Max(fecha),'%d-%M-%Y'), COUNT(*) FROM pagos WHERE cod_credito=" + codigocre +" and estado='Hecho'";
                fechas = buscar(consfech);
                saldos = cre.saldosdias(codigocre, DateTime.Now.Date.ToString("yyyy/MM/dd"));
                datcred = cre.datoscre(codigocre, DateTime.Now.Date.ToString("yyyy/MM/dd"));
                canti = cre.cantcre(codigocre, DateTime.Now.Date.ToString());
                diasatras = cre.diasnopag(codigocre, DateTime.Now.Date.ToString("yyyy/MM/dd"), credito.Rows[cont][5].ToString());
                cuotac= decimal.Parse(datcred.Rows[0][4].ToString());
                cuotai= decimal.Parse(datcred.Rows[0][5].ToString());
                if (cuotac < 0) cuotac = 0;
                if (cuotai < 0) cuotai = 0;
                cuota = cuotac + cuotai;
                string tipoc="";
                if (tipo.Equals("1")) { tipoc = "Diario"; }
                else if (tipo.Equals("2")) { tipoc = "Diario-Interes"; }
                else if (tipo.Equals("3")) { tipoc = "Mensual"; }
                else if (tipo.Equals("4")) { tipoc = "Mensua-Sobresaldo"; }
                decimal catras, iatras;
                catras = decimal.Parse(saldos.Rows[0][0].ToString());
                if (catras < 0) catras = 0;
                iatras = decimal.Parse(saldos.Rows[0][1].ToString());
                if (iatras < 0) iatras = 0;
                detalle.intatras = iatras;
                if (catras > 0 || iatras>0)
                {
                    decimal capatras, intatras;
                    string Garantia = credito.Rows[cont][10] != DBNull.Value ? credito.Rows[cont][10].ToString() : "Sin Garantia";
                    Ccancelar = decimal.Parse(canti.Rows[0][5].ToString()) + decimal.Parse(credito.Rows[cont][7].ToString());
                    //No credito
                    detalle.cre = int.Parse(credito.Rows[cont][0].ToString());
                    //nombre del cliente
                    detalle.cliente = credito.Rows[cont][1].ToString();
                    //tipo de credito
                    detalle.tipo = tipoc;
                    //Numero de cuotas pagadas
                    detalle.cuotap = int.Parse(fechas.Rows[0][1].ToString());
                    //Dias de atraso
                    detalle.diatras = diasatras;
                    //Fecha de concesion
                    detalle.fechaconc = DateTime.Parse(credito.Rows[cont][5].ToString());
                    //Fecha de Vencimiento
                    detalle.fechavenc = DateTime.Parse(credito.Rows[cont][6].ToString());
                    //Tasa del credito
                    detalle.tasa = credito.Rows[cont][4].ToString();
                    //Monto
                    detalle.monto = decimal.Parse(credito.Rows[cont][2].ToString());
                    //capatras
                    capatras = decimal.Parse(saldos.Rows[0][0].ToString());
                    if (capatras < 0) capatras = 0;
                    detalle.capatras = capatras;
                    //intatras
                    intatras= decimal.Parse(saldos.Rows[0][1].ToString());
                    if (intatras < 0) intatras = 0;
                    detalle.intatras = intatras;
                    //cancelar
                    detalle.cancelar = Ccancelar;
                    //cuota
                    detalle.cuota = cuota;
                    //utlimpag
                    if (fechas.Rows[0][0] != DBNull.Value)
                    {
                        detalle.utlimpag = DateTime.Parse(fechas.Rows[0][0].ToString() + " 00:00:00"); }
                    else
                    {
                        detalle.utlimpag = DateTime.Parse(credito.Rows[cont][5].ToString());
                    }
                     
                    //telefono
                    detalle.telefono = datoscli.Rows[0][0].ToString() + "\n" + datoscli.Rows[0][1].ToString() + "\n" + datoscli.Rows[0][2].ToString();
                    detalle.Garantia = Garantia;
                    Encab.Datos.Add(detalle);
                }

            }
    Reportes.CreCartera formu = new Reportes.CreCartera();
            formu.Enca.Add(Encab);
            formu.Deta = Encab.Datos;
            formu.Show();
        }

        public void RepCreActi(string titulo,string t)
        {
            DataTable datos = new DataTable();
            string ConsulAdd="";
            if (t == "Diario")
            { ConsulAdd = "and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2) "; }
            else if (t == "Mensual")
            { ConsulAdd = "and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4) "; }

            string consulta = "SELECT  cre.COD_CREDITO,cli.NOMBRES,cli.APELLIDOS,cre.Saldo_cap, date_format(cre.FECHA_CONC,'%d/%m/%Y'), date_format(cre.FECHA_venci,'%d/%m/%Y'),cre.id_tipo_credito ,CONCAT(gar.Tipo,'\n',gar.Detalle,'\n',gar.Valuacion,'\n',gar.Estado) AS Garantias " +
                             "FROM credito cre " +
                             "INNER JOIN asigna_credito acre ON acre.COD_CREDITO = cre.COD_CREDITO " +
                             "INNER JOIN asigna_solicitud asol ON asol.ID_SOLICITUD = acre.ID_SOLICITUD " +
                             "LEFT JOIN sol_garant solg ON solg.Id_Solicitud = acre.ID_SOLICITUD "+
                             "Left JOIN garantia gar ON gar.id_garant = solg.id_garant "+
                             "INNER JOIN cliente cli ON cli.CODIGO_CLI = asol.codigo_cli " +
                             "WHERE cre.ESTADO='Activo'"+ConsulAdd +
                             "GROUP BY cre.COD_CREDITO";
            int cont, cant;
            datos = buscar(consulta);
            cant = datos.Rows.Count;
            string fechahoy = DateTime.Now.Date.ToString("yyyy/MM/dd");
            RepEnc enca = new RepEnc();
            enca.Titulo = titulo;
            for (cont = 0; cont < cant; cont++)
            {
                Credi_Activity detalle = new Credi_Activity();
                string tipo = datos.Rows[cont][6].ToString();
                string codcre= datos.Rows[cont][0].ToString();
                decimal interes = cre.SaldoDeinteres(codcre,fechahoy,tipo,0);
                string Garantia = datos.Rows[cont][7] != DBNull.Value ? datos.Rows[cont][7].ToString() : "Sin Garantia";
                if (interes < 0) interes = 0;
                detalle.Credito = int.Parse(datos.Rows[cont][0].ToString());
                detalle.Nombre = datos.Rows[cont][1].ToString() + " " + datos.Rows[cont][2].ToString();
                detalle.Scapital = decimal.Parse(datos.Rows[cont][3].ToString());
                detalle.Sinteres = interes;
                detalle.Fcons = datos.Rows[cont][4].ToString();
                detalle.Fvenc = datos.Rows[cont][5].ToString();
                detalle.Garantia = Garantia;
                enca.DetalleActi.Add(detalle);
            }
            Credi_Activ Activos = new Credi_Activ();
            Activos.detalle = enca.DetalleActi;
            Activos.encabezado.Add(enca);
            Activos.Show();

        }

 
        public void RepDiaPago(string titulo, string tip, string fech)
        {
            EstadoEnc Encab = new EstadoEnc();
            DataTable credito = new DataTable();
            Encab.cliente = titulo;
            string consulta, ConsulAdd = "";
            if (tip == "Diario")
            { ConsulAdd = "and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2) "; }
            else if (tip == "Mensual")
            { ConsulAdd = "and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4) "; }
            consulta = "SELECT cre.COD_CREDITO, concat(cli.NOMBRES,' ' ,cli.apellidos) AS nombre, cre.monto,cre.plazo,cre.interes,date_format(cre.fecha_conc,'%d-%M-%Y'),date_format(cre.Fecha_venci,'%d-%M-%Y'),cre.saldo_cap, cli.codigo_cli,cre.id_tipo_credito, CONCAT(gar.Tipo,'\n',gar.Detalle,'\n',gar.Valuacion,'\n',gar.Estado) AS Garantias  " +
                       "FROM credito cre " +
                       "INNER JOIN asigna_credito ac ON ac.COD_CREDITO = cre.COD_CREDITO " +
                       "INNER JOIN asigna_solicitud aso ON aso.ID_SOLICITUD = ac.ID_SOLICITUD " +
                       "LEFT JOIN sol_garant solg ON solg.Id_Solicitud = ac.ID_SOLICITUD "+
                       "Left JOIN garantia gar ON gar.id_garant = solg.id_garant "+
                       "INNER JOIN cliente cli ON cli.CODIGO_CLI = aso.codigo_cli " +
                       "WHERE cre.ESTADO = 'Activo' " + ConsulAdd +
                       "GROUP BY cre.COD_CREDITO " +
                       "ORDER BY cre.FECHA_CONC";
            credito = buscar(consulta);
            int cont, total;
            total = credito.Rows.Count;
            for (cont = 0; cont < total; cont++)
            {
                int diasatras;
                decimal cuotac, cuotai, cuota, Ccancelar;
                DatosCre detalle = new DatosCre();
                DataTable datoscli = new DataTable();
                DataTable datcred = new DataTable();
                DataTable saldos = new DataTable();
                DataTable canti = new DataTable();
                DataTable fechas = new DataTable();
                string Garantia = credito.Rows[cont][10] != DBNull.Value ? credito.Rows[cont][10].ToString() : "Sin Garantia";
                string codigocli = credito.Rows[cont][8].ToString();
                string tipo = credito.Rows[cont][9].ToString();
                string Conscli = "select telefono1,telefono2,telefonocon as telefono from cliente where codigo_cli=" + codigocli;
                datoscli = buscar(Conscli);
                string codigocre = credito.Rows[cont][0].ToString();
                string consfech = "SELECT date_format(Max(fecha),'%d-%M-%Y'), COUNT(*) FROM pagos WHERE cod_credito=" + codigocre + " and estado='Hecho'";
                fechas = buscar(consfech);
                saldos = cre.saldosdias(codigocre, DateTime.Now.Date.ToString("yyyy/MM/dd"));
                datcred = cre.datoscre(codigocre, DateTime.Now.Date.ToString("yyyy/MM/dd"));
                canti = cre.cantcre(codigocre, DateTime.Now.Date.ToString());
                diasatras = cre.diasnopag(codigocre, DateTime.Now.Date.ToString("yyyy/MM/dd"), credito.Rows[cont][5].ToString());
                cuotac = decimal.Parse(datcred.Rows[0][4].ToString());
                cuotai = decimal.Parse(datcred.Rows[0][5].ToString());
                if (cuotac < 0) cuotac = 0;
                if (cuotai < 0) cuotai = 0;
                cuota = cuotac + cuotai;
                string tipoc = "";
                if (tipo.Equals("1")) { tipoc = "Diario"; }
                else if (tipo.Equals("2")) { tipoc = "Diario-Interes"; }
                else if (tipo.Equals("3")) { tipoc = "Mensual"; }
                else if (tipo.Equals("4")) { tipoc = "Mensua-Sobresaldo"; }
                decimal catras, iatras;
                catras = decimal.Parse(saldos.Rows[0][0].ToString());
                if (catras < 0) catras = 0;
                iatras = decimal.Parse(saldos.Rows[0][1].ToString());
                if (iatras < 0) iatras = 0;
                detalle.intatras = iatras;
                bool fechap=true;
               int contendi=0, plaz= int.Parse(credito.Rows[cont][3].ToString());
                DateTime fechaeval = new DateTime();
                fechaeval= DateTime.Parse(credito.Rows[cont][5].ToString());
                DateTime fechapag = new DateTime();
                fechapag = DateTime.Parse(fech);
                    bool sihayp= false;

                // revisar fecga para los creditos mensuales
                if (tip.Equals("Diario"))

                {
                    while (fechapag >= fechaeval.AddDays(contendi))
                    {
                        contendi++;
                        if (fechaeval.AddDays(contendi) ==fechapag)
                        {
                            fechap = false;
                            sihayp = true;
                        }
                        else
                        {
                            fechap = true;
                        }
                    }
                }
                // revisar fecga para los creditos mensuales
                else if(tip.Equals("Mensual"))
                    {
                    while (fechapag >= fechaeval.AddMonths(contendi))
                    {
                        contendi++;
                        if (fechaeval.AddMonths(contendi) == fechapag)
                        {
                            fechap = false;
                            sihayp = true;
                            break;
                        }
                        else
                        {
                            fechap = true;
                        }
                    }
                }

                    if (sihayp)
                    { 
                    decimal capatras, intatras;
                    Ccancelar = decimal.Parse(canti.Rows[0][5].ToString()) + decimal.Parse(credito.Rows[cont][7].ToString());
                    //No credito
                    detalle.cre = int.Parse(credito.Rows[cont][0].ToString());
                    //nombre del cliente
                    detalle.cliente = credito.Rows[cont][1].ToString();
                    //tipo de credito
                    detalle.tipo = tipoc;
                    //Numero de cuotas pagadas
                    detalle.cuotap = int.Parse(fechas.Rows[0][1].ToString());
                    //Dias de atraso
                    detalle.diatras = diasatras;
                    //Fecha de concesion
                    detalle.fechaconc = DateTime.Parse(credito.Rows[cont][5].ToString());
                    //Fecha de Vencimiento
                    detalle.fechavenc = DateTime.Parse(credito.Rows[cont][6].ToString());
                    //Tasa del credito
                    detalle.tasa = credito.Rows[cont][4].ToString();
                    //Monto
                    detalle.monto = decimal.Parse(credito.Rows[cont][2].ToString());
                    //capatras
                    capatras = decimal.Parse(saldos.Rows[0][0].ToString());
                    if (capatras < 0) capatras = 0;
                    detalle.capatras = capatras;
                    //intatras
                    intatras = decimal.Parse(saldos.Rows[0][1].ToString());
                    if (intatras < 0) intatras = 0;
                    detalle.intatras = intatras;
                    //cancelar
                    detalle.cancelar = Ccancelar;
                    //cuota
                    detalle.cuota = cuota;
                    //utlimpag

                    if (fechas.Rows[0][0] != DBNull.Value)
                    {
                        detalle.utlimpag = DateTime.Parse(fechas.Rows[0][0].ToString() + " 00:00:00");
                    }
                    else
                    {
                        detalle.utlimpag = DateTime.Parse(credito.Rows[cont][5].ToString());
                    }
                    //telefono
                    detalle.telefono = datoscli.Rows[0][0].ToString() + "\n" + datoscli.Rows[0][1].ToString() + "\n" + datoscli.Rows[0][2].ToString();
                    //Garantia 
                    detalle.Garantia = Garantia;
                    Encab.Datos.Add(detalle);
                    
                }
            }
            Reportes.Pagohoy formu = new Reportes.Pagohoy();
            formu.Enca.Add(Encab);
            formu.Deta = Encab.Datos;
            formu.Show();
        }

        #region "Calculo de Ganacias"
        public void Ganancia(string Fechai, string Fechaf, string nomfecha)
        {
            Reportes.RepEnc Encab = new Reportes.RepEnc();
            Encab.Titulo = "Reporte de ganacia " + nomfecha;
            Encab.periodo = "LOL";
            string consulta;
            consulta = "SELECT CONCAT(cli.nombres, ' ', Apellidos) AS nombre, cre.monto, SUM(pag.capital) AS cap, SUM(pag.interes)AS inte, pag.mora AS mora, cre.cod_credito " +
                     "FROM cliente cli " +
                     "inner JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI " +
                     "inner JOIN asigna_credito acre ON acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
                     "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO  and cre.estado!='Cancelado' " +
                     "LEFT JOIN pagos pag on cre.COD_CREDITO = pag.COD_CREDITO  and pag.estado='Hecho' " +
                     "WHERE ((pag.FECHA >= '" + Fechai + "' AND pag.FECHA <= '" + Fechaf + "' ) OR (cre.FECHA_CONC>='" + Fechai + "' AND cre.FECHA_CONC<='" + Fechaf + "' AND cre.Gastos_admin>0)) " +
                     "GROUP BY cre.cod_credito " +
                     "Order by cli.nombres";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            int total, cont;
            total = datos.Rows.Count;
            for (cont = 1; cont <= total; cont++)
            {
                RepDetCli detall = new RepDetCli();
                string pago = datos.Rows[cont - 1][2] != DBNull.Value ? datos.Rows[cont - 1][2].ToString() : "0";
                string capi = datos.Rows[cont - 1][3] != DBNull.Value ? datos.Rows[cont - 1][3].ToString() : "0";
                string inte = datos.Rows[cont - 1][4] != DBNull.Value ? datos.Rows[cont - 1][4].ToString() : "0";
                string codigocre = datos.Rows[cont - 1][5].ToString();
                decimal capicalc, intecalc, moracalc;
                capicalc = pag.totalcapi(Fechai, Fechaf, codigocre);
                intecalc = pag.totalinte(Fechai, Fechaf, codigocre);
                moracalc = pag.totalmora(Fechai, Fechaf, codigocre);
                if (decimal.Parse(pago) != capicalc) pago = capicalc.ToString();
                if (decimal.Parse(capi) != intecalc) capi = intecalc.ToString();
                if (decimal.Parse(inte) != moracalc) inte = moracalc.ToString();



                detall.Cliente = datos.Rows[cont - 1][0].ToString() + "\nCredito: " + codigocre;
                detall.Credito = datos.Rows[cont - 1][1].ToString();
                detall.pago = pago;
                detall.Total = Convert.ToDecimal(capi);
                detall.tel = inte;
                detall.Gadmin = cre.gasadmin(codigocre, Fechai, Fechaf);
                Encab.detalleC.Add(detall);
            }
            Reportes.Ganancias Gan = new Reportes.Ganancias();
            Gan.Enc.Add(Encab);
            Gan.Deta = Encab.detalleC;
            Gan.Show();
            //faltaln datos en form ganacias
        }

        public void GanaciaDi(string Fechai, string Fechaf, string nomfecha)
        {
            Reportes.RepEnc Encab = new Reportes.RepEnc();
            Encab.Titulo = "Reporte de ganacia " + nomfecha;
            Encab.periodo = "LOL";
            string consulta;
            consulta = "SELECT CONCAT(cli.nombres, ' ', Apellidos) AS nombre, cre.monto, SUM(pag.capital) AS cap, SUM(pag.interes)AS inte, pag.mora AS mora, cre.cod_credito " +
                     "FROM cliente cli " +
                     "inner JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI " +
                     "inner JOIN asigna_credito acre ON acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
                     "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO  and cre.estado!='Cancelado' " +
                     "LEFT JOIN pagos pag on cre.COD_CREDITO = pag.COD_CREDITO  and pag.estado='Hecho' " +
                     "WHERE ((pag.FECHA >= '" + Fechai + "' AND pag.FECHA <= '" + Fechaf + "' and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2) ) OR (cre.FECHA_CONC>='" + Fechai + "' AND cre.FECHA_CONC<='" + Fechaf + "' AND cre.Gastos_admin>0 and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2))) " +
                     "GROUP BY cre.cod_credito " +
                     "Order by cli.nombres";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            int total, cont;
            total = datos.Rows.Count;
            for (cont = 1; cont <= total; cont++)
            {
                RepDetCli detall = new RepDetCli();
                string pago = datos.Rows[cont - 1][2] != DBNull.Value ? datos.Rows[cont - 1][2].ToString() : "0";
                string capi = datos.Rows[cont - 1][3] != DBNull.Value ? datos.Rows[cont - 1][3].ToString() : "0";
                string inte = datos.Rows[cont - 1][4] != DBNull.Value ? datos.Rows[cont - 1][4].ToString() : "0";
                string codigocre = datos.Rows[cont - 1][5].ToString();
                decimal capicalc, intecalc, moracalc;
                capicalc = pag.totalcapi(Fechai, Fechaf, codigocre);
                intecalc = pag.totalinte(Fechai, Fechaf, codigocre);
                moracalc = pag.totalmora(Fechai, Fechaf, codigocre);
                if (decimal.Parse(pago) != capicalc) pago = capicalc.ToString();
                if (decimal.Parse(capi) != intecalc) capi = intecalc.ToString();
                if (decimal.Parse(inte) != moracalc) inte = moracalc.ToString();



                detall.Cliente = datos.Rows[cont - 1][0].ToString() + "\nCredito: " + codigocre;
                detall.Credito = datos.Rows[cont - 1][1].ToString();
                detall.pago = pago;
                detall.Total = Convert.ToDecimal(capi);
                detall.tel = inte;
                detall.Gadmin = cre.gasadmin(codigocre, Fechai, Fechaf);
                Encab.detalleC.Add(detall);
            }
            Reportes.Ganancias Gan = new Reportes.Ganancias();
            Gan.Enc.Add(Encab);
            Gan.Deta = Encab.detalleC;
            Gan.Show();
            //faltaln datos en form ganacias

        }

        public void GanaciaMes(string Fechai, string Fechaf, string nomfecha)
        {
            Reportes.RepEnc Encab = new Reportes.RepEnc();
            Encab.Titulo = "Reporte de ganacia " + nomfecha;
            Encab.periodo = "LOL";
            string consulta;
            consulta = "SELECT CONCAT(cli.nombres, ' ', Apellidos) AS nombre, cre.monto, SUM(pag.capital) AS cap, SUM(pag.interes)AS inte, pag.mora AS mora, cre.cod_credito " +
                     "FROM cliente cli " +
                     "inner JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI " +
                     "inner JOIN asigna_credito acre ON acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
                     "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO  and cre.estado!='Cancelado' " +
                     "LEFT JOIN pagos pag on cre.COD_CREDITO = pag.COD_CREDITO  and pag.estado='Hecho' " +
                     "WHERE ((pag.FECHA >= '" + Fechai + "' AND pag.FECHA <= '" + Fechaf + "' and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4) ) OR (cre.FECHA_CONC>='" + Fechai + "' AND cre.FECHA_CONC<='" + Fechaf + "' AND cre.Gastos_admin>0 and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4))) " +
                     "GROUP BY cre.cod_credito " +
                     "Order by cli.nombres";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            int total, cont;
            total = datos.Rows.Count;
            for (cont = 1; cont <= total; cont++)
            {
                RepDetCli detall = new RepDetCli();
                string pago = datos.Rows[cont - 1][2] != DBNull.Value ? datos.Rows[cont - 1][2].ToString() : "0";
                string capi = datos.Rows[cont - 1][3] != DBNull.Value ? datos.Rows[cont - 1][3].ToString() : "0";
                string inte = datos.Rows[cont - 1][4] != DBNull.Value ? datos.Rows[cont - 1][4].ToString() : "0";
                string codigocre = datos.Rows[cont - 1][5].ToString();
                decimal capicalc, intecalc, moracalc;
                capicalc = pag.totalcapi(Fechai, Fechaf, codigocre);
                intecalc = pag.totalinte(Fechai, Fechaf, codigocre);
                moracalc = pag.totalmora(Fechai, Fechaf, codigocre);
                if (decimal.Parse(pago) != capicalc) pago = capicalc.ToString();
                if (decimal.Parse(capi) != intecalc) capi = intecalc.ToString();
                if (decimal.Parse(inte) != moracalc) inte = moracalc.ToString();



                detall.Cliente = datos.Rows[cont - 1][0].ToString() + "\nCredito: " + codigocre;
                detall.Credito = datos.Rows[cont - 1][1].ToString();
                detall.pago = pago;
                detall.Total = Convert.ToDecimal(capi);
                detall.tel = inte;
                detall.Gadmin = cre.gasadmin(codigocre, Fechai, Fechaf);
                Encab.detalleC.Add(detall);
            }
            Reportes.Ganancias Gan = new Reportes.Ganancias();
            Gan.Enc.Add(Encab);
            Gan.Deta = Encab.detalleC;
            Gan.Show();
            //faltaln datos en form ganacias

        }

        #endregion
    }
}

