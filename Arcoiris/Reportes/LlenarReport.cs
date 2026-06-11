using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace Arcoiris.Reportes
{
    class LlenarReport
    {
        Clases.conexion conect = new Clases.conexion();
        Clases.ClAsesor ase = new Clases.ClAsesor();
        Clases.Cliente cli = new Clases.Cliente();
        Clases.Credito cre = new Clases.Credito();
        Clases.Pago pag = new Clases.Pago();

        private class PagoInfo
        {
            public decimal Capital { get; set; }
            public decimal Interes { get; set; }
            public DateTime Fecha { get; set; }
        }

        private int PagProyMemoria(DateTime fechai, DateTime fechaa, string tipo, int diasp)
        {
            DateTime fechacambio = fechai;
            TimeSpan dias = fechaa - fechai;
            int totdia = dias.Days;
            int cont;
            int diashab = 0;

            for (cont = 1; cont <= totdia; cont++)
            {
                fechacambio = fechacambio.AddDays(1);
                if (fechacambio.DayOfWeek == DayOfWeek.Sunday || fechacambio.DayOfWeek == DayOfWeek.Monday)
                {
                }
                else
                {
                    diashab++;
                }
            }
            if (tipo.Equals("1"))
            {
            }
            else if (tipo.Equals("2"))
            {
                if (diashab > diasp)
                {
                    diashab = diasp;
                }
                else
                { diashab = 0; }
            }
            else if (tipo.Equals("3") || tipo.Equals("4"))
            {
                diashab = 0;
                int conteo = 1;
                DateTime fechap = fechai.AddMonths(conteo);
                while (fechaa > fechap)
                {
                    conteo++;
                    fechap = fechai.AddMonths(conteo);
                    diashab++;
                }
            }
            else if (tipo.Equals("5"))
            {
                diashab = 0;
                int conteo = 7;
                DateTime fechap = fechai.AddDays(conteo);
                while (fechaa > fechap)
                {
                    conteo += 7;
                    fechap = fechai.AddDays(conteo);
                    diashab++;
                }
            }
            else if (tipo.Equals("6"))
            {
                diashab = 0;
                int conteo = 14;
                DateTime fechap = fechai.AddDays(conteo);
                while (fechaa > fechap)
                {
                    conteo += 14;
                    fechap = fechai.AddDays(conteo);
                    diashab++;
                }
            }

            if (diashab > diasp) diashab = diasp;

            return diashab;
        }

        private Tuple<decimal, decimal, decimal> CalcularSaldosDiasMemoria(DataRow creRow, List<PagoInfo> pagosList, DateTime fechaEval)
        {
            decimal monto = Convert.ToDecimal(creRow["monto"]);
            decimal inte = Convert.ToDecimal(creRow["interes"]);
            int dias = Convert.ToInt32(creRow["dias_pago"]);
            DateTime fechaC = Convert.ToDateTime(creRow["fecha_conc"]);
            DateTime FechaVen = Convert.ToDateTime(creRow["Fecha_venci"]);
            string tipo = creRow["id_tipo_credito"].ToString();
            decimal SaldoC = Convert.ToDecimal(creRow["saldo_cap"]);

            int pagos = PagProyMemoria(fechaC, fechaEval, tipo, dias);
            decimal pint = 0, pcap = 0, ptot = 0;
            if (pagos > dias) pagos = dias;

            if (tipo == "1")
            {
                pcap = Math.Round((monto / dias), 2);
                pint = Math.Round((monto * inte / 100), 2);
                pcap *= pagos;
                pint *= pagos;
                pcap = Math.Round(pcap, 2);
                pint = Math.Round(pint, 2);
                ptot = pcap + pint;
            }
            else if (tipo == "2")
            {
                pcap = 0;
                pint = 0;
                if (pagos >= dias)
                {
                    pcap = monto;
                    pint = Math.Round((monto * inte / 100 * dias), 2);
                }
                pcap = Math.Round(pcap, 2);
                pint = Math.Round(pint, 2);
                ptot = pcap + pint;
            }
            else if (tipo == "3")
            {
                pcap = Math.Round((monto / dias), 2);
                pint = Math.Round((monto * inte / 100 / 12), 2);
                pcap *= pagos;
                pint *= pagos;
                pcap = Math.Round(pcap, 2);
                pint = Math.Round(pint, 2);
                ptot = pcap + pint;
            }
            else if (tipo == "4")
            {
                decimal pcaptemp = Math.Round((monto / dias), 2);
                pcap = Math.Round((monto / dias), 2);
                pcap *= pagos;

                int pagosmade = pagosList.Count;

                DateTime FechaA = fechaC.AddMonths(pagos);
                DateTime Fechamov = fechaC.AddMonths(1);
                if (FechaA > FechaVen)
                {
                    FechaA = FechaVen;
                }
                else if (FechaA <= Fechamov)
                {
                    Fechamov = fechaC;
                }

                if (FechaA < Fechamov)
                {
                    pint = 0;
                }
                else
                {
                    int conteop = 0;
                    DateTime DatePag;
                    if (pagosmade > 0)
                    {
                        DatePag = pagosList[conteop].Fecha;
                    }
                    else
                    {
                        DatePag = FechaA;
                    }
                    if (DatePag > FechaA)
                    {
                        DatePag = FechaA;
                    }
                    DateTime DatePrim = fechaC;

                    while (DatePag <= FechaA)
                    {
                        if (conteop < pagosmade)
                        {
                            if (DatePag <= Fechamov)
                            {
                                TimeSpan time = DatePag - DatePrim;
                                int diascobr = time.Days;
                                if (diascobr < 0) diascobr = 0;
                                decimal intante = Math.Round(((monto * inte / 100 / 12 / 30) * diascobr), 2);
                                decimal capante = pagosList[conteop].Capital;
                                monto -= capante;
                                pint += intante;
                                DatePrim = DatePag;
                                conteop++;
                                if (conteop < pagosmade)
                                {
                                    if (pagosList[conteop].Fecha > FechaA)
                                    {
                                        DateTime DateAnte = pagosList[conteop - 1].Fecha;
                                        TimeSpan diaz = FechaA - DateAnte;
                                        int diazc = diaz.Days;
                                        intante = Math.Round((((monto) * inte / 100 / 12 / 30) * diazc), 2);
                                        pint += intante;
                                    }
                                    DatePag = pagosList[conteop].Fecha;
                                }
                                else if (conteop == pagosmade)
                                {
                                    time = fechaC.AddMonths(pagos) - DatePrim;
                                    diascobr = time.Days;
                                    if (diascobr >= 0)
                                    {
                                        intante = Math.Round((((monto) * inte / 100 / 12 / 30) * diascobr), 2);
                                        pint += intante;
                                        DatePag = FechaA;
                                    }
                                    else
                                    {
                                        intante = Math.Round((((monto + capante) * inte / 100 / 12 / 30) * diascobr), 2);
                                        pint += intante;
                                        DatePag = FechaA;
                                    }
                                }
                                else
                                {
                                    DatePag = FechaA;
                                }
                            }
                            else
                            {
                                Fechamov = Fechamov.AddMonths(1);
                            }
                        }
                        else if (pagosmade == 0)
                        {
                            TimeSpan time = DatePag - Fechamov;
                            int diascobr = time.Days;
                            if (diascobr < 0) diascobr = 0;
                            pint += ((monto * inte / 100 / 12 / 30) * diascobr);
                            break;
                        }
                        else
                        {
                            TimeSpan time = FechaA - DatePag;
                            int diascobr = time.Days;
                            if (diascobr < 0) diascobr = 0;
                            pcap += pcaptemp / 30 * diascobr;
                            pint += ((monto * inte / 100 / 12 / 30) * diascobr);
                            break;
                        }
                    }
                }
                pcap = Math.Round(pcap, 2);
                pint = Math.Round(pint, 2);
                ptot = pcap + pint;
            }
            else if (tipo == "5")
            {
                pcap = Math.Round((monto / dias), 2);
                pint = Math.Round((monto * inte / 100 * 5), 2);
                pcap *= pagos;
                pint *= pagos;
                pcap = Math.Round(pcap, 2);
                pint = Math.Round(pint, 2);
                ptot = pcap + pint;
            }
            else if (tipo == "6")
            {
                pcap = Math.Round((monto / dias), 2);
                pint = Math.Round((monto * inte / 100 * 10), 2);
                pcap *= pagos;
                pint *= pagos;
                pcap = Math.Round(pcap, 2);
                pint = Math.Round(pint, 2);
                ptot = pcap + pint;
            }

            decimal Scap = 0;
            decimal Sint = 0;
            for (int i = 0; i < pagosList.Count; i++)
            {
                Scap += pagosList[i].Capital;
                Sint += pagosList[i].Interes;
            }

            decimal Rint = Math.Round((pint - Sint), 2);
            if (Rint < 0) Rint = 0;
            decimal Rcap = Math.Round((pcap - Scap), 2);
            decimal tempcap = Rcap > 0 ? Rcap : 0;
            decimal Rtot = tempcap + Rint;

            return Tuple.Create(Rcap, Rint, Rtot);
        }

        private Tuple<decimal, decimal, decimal> CalcularSaldosDiasMemoriaInterna(DataRow creRow, List<PagoInfo> pagosList, DateTime fechaEval)
        {
            return CalcularSaldosDiasMemoria(creRow, pagosList, fechaEval);
        }

        private int CalcularDiasNoPagMemoria(DataRow creRow, List<PagoInfo> pagosList, DateTime fechaEval)
        {
            int numpag = pagosList.Count;
            int Totd = 0;

            string tipoc = creRow["id_tipo_credito"].ToString();
            decimal monto = Convert.ToDecimal(creRow["monto"]);
            decimal interes = Convert.ToDecimal(creRow["interes"]);
            int diasP = Convert.ToInt32(creRow["dias_pago"]);
            DateTime Fini = Convert.ToDateTime(creRow["fecha_conc"]);
            DateTime FinCe = Convert.ToDateTime(creRow["Fecha_venci"]);
            DateTime Ffin = fechaEval;

            decimal TotCap = 0;
            decimal TotInt = 0;
            foreach (var p in pagosList)
            {
                TotCap += p.Capital;
                TotInt += p.Interes;
            }

            TimeSpan dif;
            if (tipoc == "1")
            {
                decimal Pcap = Math.Round((monto / diasP), 2);
                decimal Pint = Math.Round((monto * interes / 100), 2);
                int dias = 0, cont, Dfin = 0, pdia = 0, pagao = 0;
                DateTime fechaval;
                dif = Ffin - Fini;
                dias = dif.Days;
                for (cont = 1; cont <= dias; cont++)
                {
                    pdia++;
                    fechaval = Fini.AddDays(pdia);
                    if (fechaval.DayOfWeek == DayOfWeek.Saturday || fechaval.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Dfin++;
                    }
                }
                while (TotCap > 0 || TotInt > 0)
                {
                    TotCap -= Pcap;
                    TotInt -= Pint;
                    if (TotCap >= 0 && TotInt >= 0)
                        pagao++;
                }
                pagao++;
                dias -= (Dfin + pagao);
                if (dias < 0) dias = 0;
                Totd = dias;
            }
            else if (tipoc == "2")
            {
                decimal Pcap = Math.Round((monto / diasP), 2);
                decimal Pint = Math.Round((monto * interes / 100), 2);
                int dias = 0, cont, Dfin = 0, pdia = 0, pagao = 0;
                DateTime Inicio = FinCe, fechaval;
                dif = Ffin - Inicio;
                dias = dif.Days;
                if (dias <= 0) return 0;
                for (cont = 1; cont <= dias; cont++)
                {
                    fechaval = Fini.AddDays(pdia);
                    pdia++;
                    if (fechaval.DayOfWeek == DayOfWeek.Saturday || fechaval.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Dfin++;
                    }
                }
                if (TotCap <= 0 && TotInt > 0)
                {
                    while (TotInt > 0)
                    {
                        TotInt -= Pint;
                        if (TotInt >= Pint) pagao++;
                    }
                }
                else if (TotCap > 0 && TotInt <= 0)
                {
                    while (TotCap > 0)
                    {
                        TotCap -= Pcap;
                        if (TotCap >= Pcap) pagao++;
                    }
                }
                else if (TotCap > 0 && TotInt > 0)
                {
                    while (TotCap >= 0 || TotInt >= 0)
                    {
                        TotCap -= Pcap;
                        TotInt -= Pint;
                        if (TotCap >= 0 || TotInt >= 0)
                            pagao++;
                    }
                }
                dias -= (Dfin + pagao);
                if (dias < 0) dias = 0;
                Totd = dias;
            }
            else if (tipoc == "3")
            {
                decimal sint, scap, cuotac;
                var saldos = CalcularSaldosDiasMemoria(creRow, pagosList, Ffin);
                cuotac = Math.Round((monto / diasP), 2);
                scap = saldos.Item1;
                sint = saldos.Item2;

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
                    decimal pagoint = Math.Round((monto * interes / 100 / 12), 2);
                    while (sint > 0)
                    {
                        atraso++;
                        sint -= pagoint;
                    }
                }
                else
                {
                    decimal pagoint = Math.Round((monto * interes / 100 / 12), 2);
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
                var saldoActual = CalcularSaldosDiasMemoria(creRow, pagosList, Ffin);
                decimal capSaldo = saldoActual.Item1;
                decimal intSaldo = saldoActual.Item2;

                if (capSaldo <= 0 && intSaldo <= 0)
                {
                    Totd = 0;
                }
                else
                {
                    decimal totalCapPagado = 0;
                    foreach (var p in pagosList)
                    {
                        totalCapPagado += p.Capital;
                    }
                    decimal capitalVigente = monto - totalCapPagado;
                    if (capitalVigente < 0) capitalVigente = 0;

                    decimal cuotaCapDiaria = Math.Round((monto / diasP / 30), 4);
                    decimal intDiario = Math.Round((capitalVigente * interes / 100 / 30), 4);

                    decimal diasPorCap = (cuotaCapDiaria > 0) ? Math.Round(capSaldo / cuotaCapDiaria, 0) : 0;
                    decimal diasPorInt = (intDiario > 0) ? Math.Round(intSaldo / intDiario, 0) : 0;

                    Totd = (int)Math.Max(diasPorCap, diasPorInt);

                    DateTime fechaVencimiento = FinCe;
                    DateTime fechaActual = Ffin;
                    if (fechaActual > fechaVencimiento)
                    {
                        TimeSpan diasPostVenc = fechaActual - fechaVencimiento;
                        Totd += diasPostVenc.Days;
                    }

                    if (Totd < 0) Totd = 0;
                }
            }
            else if (tipoc == "5")
            {
                decimal Pcap = Math.Round((monto / diasP), 2);
                decimal Pint = Math.Round((monto * interes / 100 * 5), 2);
                int dias = 0, cont, Dfin = 0, pdia = 0, pagao = 0;
                dif = Ffin - Fini;
                dias = dif.Days;
                for (cont = 1; cont <= dias; cont++)
                {
                    pdia++;
                    DateTime fechaval = Fini.AddDays(pdia);
                    if (fechaval.DayOfWeek == DayOfWeek.Saturday || fechaval.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Dfin++;
                    }
                }
                while (TotCap > 0 || TotInt > 0)
                {
                    TotCap -= Pcap;
                    TotInt -= Pint;
                    if (TotCap >= 0 && TotInt >= 0)
                        pagao++;
                }
                pagao++;
                dias -= (Dfin + (pagao * 5));
                if (dias < 0) dias = 0;
                Totd = dias;
            }
            else if (tipoc == "6")
            {
                decimal Pcap = Math.Round((monto / diasP), 2);
                decimal Pint = Math.Round((monto * interes / 100 * 10), 2);
                int dias = 0, cont, Dfin = 0, pdia = 0, pagao = 0;
                dif = Ffin - Fini;
                dias = dif.Days / 14;
                for (cont = 1; cont <= dias; cont++)
                {
                    pdia++;
                    DateTime fechaval = Fini.AddDays(pdia * 14);
                    if (fechaval.DayOfWeek == DayOfWeek.Saturday || fechaval.DayOfWeek == DayOfWeek.Sunday)
                    {
                        Dfin++;
                    }
                }
                while ((TotCap > 0 || TotInt > 0))
                {
                    TotCap -= Pcap;
                    TotInt -= Pint;
                    if (TotCap >= 0 && TotInt >= 0)
                        pagao++;
                }
                dias -= (Dfin + pagao);
                dias *= 10;
                if (dias < 0) dias = 0;
                Totd = dias;
            }
            if (Totd < 0) Totd = 0;
            return Totd;
        }

        private int CalcularDiasAtrasoMemoria(DataRow creRow, List<PagoInfo> pagosList, DateTime fechaEval)
        {
            int numPagos = pagosList.Count;
            DateTime? maxFechaPago = numPagos > 0 ? (DateTime?)pagosList[numPagos - 1].Fecha : null;

            string tipoc = creRow["id_tipo_credito"].ToString();
            int dmaxatraso = Convert.ToInt32(creRow["dias_pago"]);
            int plazo = Convert.ToInt32(creRow["plazo"]);
            DateTime fechaconc = Convert.ToDateTime(creRow["fecha_conc"]);
            DateTime fechavenci = Convert.ToDateTime(creRow["Fecha_venci"]);
            decimal monto = Convert.ToDecimal(creRow["monto"]);
            decimal interes = Convert.ToDecimal(creRow["interes"]);

            int datraso = 0;

            if (maxFechaPago == null && numPagos == 0)
            {
                DateTime fechav = fechaconc;
                TimeSpan dias = fechaEval - fechav;
                int tdias = dias.Days;
                int cont, atra = 0;
                if (tipoc.Equals("1") || tipoc.Equals("2"))
                {
                    dias = fechaEval - fechav.AddDays(1);
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
                else if (tipoc.Equals("3"))
                {
                    int mesatras = 0;
                    fechav = fechav.AddDays(1);
                    while (fechav.AddMonths(mesatras) < fechaEval)
                    { mesatras++; }
                    datraso = mesatras;
                }
                else if (tipoc.Equals("4"))
                {
                    int mesesAtraso = 0;
                    DateTime fechaReferencia = fechaconc;

                    while (fechaReferencia.AddMonths(mesesAtraso + 1) <= fechaEval)
                    {
                        DateTime fechaPeriodo = fechaReferencia.AddMonths(mesesAtraso + 1);

                        var saldoPeriodo = CalcularSaldosDiasMemoriaInterna(creRow, pagosList, fechaPeriodo);
                        decimal capPendiente = saldoPeriodo.Item1;
                        decimal intPendiente = saldoPeriodo.Item2;

                        if (capPendiente > 0 || intPendiente > 0)
                        {
                            mesesAtraso++;
                        }
                        else
                        {
                            fechaReferencia = fechaPeriodo;
                        }
                    }

                    DateTime inicioMesActual = fechaReferencia.AddMonths(mesesAtraso);
                    if (fechaEval > inicioMesActual)
                    {
                        TimeSpan diasMesActual = fechaEval - inicioMesActual;
                        datraso = (mesesAtraso * 30) + diasMesActual.Days;
                    }
                    else
                    {
                        datraso = mesesAtraso * 30;
                    }
                }
                else if (tipoc.Equals("5"))
                {
                    dias = fechaEval - fechav.AddDays(1);
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
                        fechav = fechav.AddDays(7);
                        cont += 7;
                    }
                    datraso = atra;
                }
                else if (tipoc.Equals("6"))
                {
                    dias = fechaEval - fechav.AddDays(1);
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
                        fechav = fechav.AddDays(14);
                        cont += 7;
                    }
                    datraso = atra;
                }

                if (datraso >= dmaxatraso) datraso = dmaxatraso;
                if (datraso < 0) datraso = 0;
            }
            else
            {
                DateTime fechav = fechaconc;
                DateTime fechap = fechaconc.AddMonths(numPagos);
                DateTime sigfecha = fechav;
                while (fechap > sigfecha)
                { sigfecha = sigfecha.AddMonths(1); }

                TimeSpan dif = fechaEval - sigfecha;
                int diastraso = dif.Days;

                int cont, atra = 0;

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
                else if (tipoc.Equals("3"))
                {
                    int atram = 0;
                    sigfecha = sigfecha.AddDays(1);
                    while (fechaEval >= sigfecha)
                    {
                        atram++;
                        sigfecha = sigfecha.AddMonths(1);
                    }
                    datraso = atram;
                }
                else if (tipoc.Equals("5"))
                {
                    for (cont = 1; cont <= dif.Days; cont++)
                    {
                        if (fechap.AddDays(cont - 1).DayOfWeek == DayOfWeek.Saturday || fechap.AddDays(cont - 1).DayOfWeek == DayOfWeek.Sunday)
                        {
                        }
                        else
                        {
                            atra++;
                        }
                        diastraso += 7;
                    }
                    datraso = atra;
                }
                else if (tipoc.Equals("6"))
                {
                    for (cont = 1; cont <= dif.Days; cont++)
                    {
                        if (fechap.AddDays(cont - 1).DayOfWeek == DayOfWeek.Saturday || fechap.AddDays(cont - 1).DayOfWeek == DayOfWeek.Sunday)
                        {
                        }
                        else
                        {
                            atra++;
                        }
                        diastraso += 14;
                    }
                    datraso = atra;
                }

                if (datraso > dmaxatraso) datraso = dmaxatraso;
                if (datraso < 0) datraso = 0;
            }

            return datraso;
        }

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
           else if (tipo.Equals("3") || tipo.Equals("4"))
            {
                enca.CreditoP = "Mensual";  }
            else if (tipo.Equals("5"))
            {
                enca.CreditoP = "Semanal";
            }
            else if (tipo.Equals("6"))
            {
                enca.CreditoP = "Quincenal";
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
            else if (tipo.Equals("3") || tipo.Equals("4"))
            {
                enca.CreditoP = "Mensual";
            }
            else if (tipo.Equals("5"))
            {
                enca.CreditoP = "Semanal"; }
            else if (tipo.Equals("6"))
            {
                enca.CreditoP = "Quincenal"; }


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

        public void Cred_ver(string estado, string titulo, string asesor)
        {
            Reportes.RepEnc Enca = new Reportes.RepEnc();
            string consulta,ConsulAdd = "";
            if (estado == "Diario")
            { ConsulAdd = "and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2 or cre.id_tipo_credito=5 or cre.id_tipo_credito=6) "; }
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
        public void Cred_venc(string tip, string aseso)
        {
            Reportes.AtrasosE Encab = new Reportes.AtrasosE();
            Encab.titulo = "Creditos Atrasados";
            string ConsulAdd2 = "";
            if (aseso.Equals("0"))
            {
                ConsulAdd2 = "";
            }
            else
            {
                ConsulAdd2 = $"and asol.Cod_Asesor={aseso} ";
            }
            string consulta;
            decimal interes, capital;
            consulta = "SELECT cre.cod_credito,CONCAT(cli.nombres,' ', cli.apellidos) AS Nombre, cre.monto, DATE_format(cre.FECHA_CONC,'%d/-%m/%y'), cre.FECHA_VENCI, CONCAT(cli.TELEFONO1,'\n',cli.Telefono2,'\n',cli.TelefonoCon) AS telefonos, interes,cre.id_tipo_credito  " +
            "FROM cliente cli " +
            "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI " +
            "INNER JOIN asigna_credito acre ON acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO " +
            "WHERE cre.ESTADO = 'Activo' order by cli.nombres and cli.apellidos "+ConsulAdd2;
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
                if (tipo == "1" || tipo == "2" || tipo == "5" || tipo == "6" ) { etiqueta = "(D)"; }
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
            else if (tipo == "5")
            {
                diferencia = hoy - FechaI;
                dias = diferencia.Days;
                dias = DiasSinFin(dias, FechaI);
                if (pasado)
                { res = saldoI; }
                else
                { res = monto * interes / 100 * dias; }

            }
            else if (tipo == "6")
            {
                diferencia = hoy - FechaI;
                dias = diferencia.Days;
                dias = DiasSinFin(dias, FechaI);
                if (pasado)
                { res = saldoI; }
                else
                { res = monto * interes / 100 * dias; }
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
            else if (tipo == "5")
            {
                int retraso = 0;
                // retraso++;
                diferencia = hoy - FechaI;
                FechaI = FechaI.AddDays(retraso);
                while (FechaI.AddDays(retraso) < hoy)
                {
                    retraso+=7;
                }
                if (pasado)
                { res = saldoC; }
                else
                {
                    res = monto / plazo * (retraso/7);
                }
            }
            else if (tipo == "6")
            {

                int retraso = 0;
                retraso++;
                diferencia = hoy - FechaI;
                FechaI = FechaI.AddDays(retraso);
                while (FechaI.AddDays(retraso) < hoy)
                {
                    retraso+=14;
                }
                if (pasado)
                { res = saldoC; }
                else
                {
                    res = monto / plazo  * (retraso/14);
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

        public void Venc_ord(string titulo, string tip, string aseso)
        {
            Reportes.AtrasosE Encab = new Reportes.AtrasosE();
            Encab.titulo = titulo;
            string consulta, ConsulAdd = "";
            string ConsulAdd2 = "";
            if (tip == "Diario")
            { ConsulAdd = "and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2 or cre.id_tipo_credito=5 or cre.id_tipo_credito=6) "; }
            else if (tip == "Mensual")
            { ConsulAdd = "and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4) "; }
            if (aseso.Equals("0"))
            {
                ConsulAdd2 = "";
            }
            else
            {
                ConsulAdd2 = $"and asol.Cod_Asesor={aseso} ";
            }
            consulta = "SELECT cre.COD_CREDITO, CONCAT(cli.nombres,' ', cli.apellidos) AS Nombre, cre.monto, cre.fecha_conc, cre.FECHA_VENCI, CONCAT(cli.TELEFONO1,'\n',cli.Telefono2,'\n',cli.TelefonoCon) AS telefonos, cre.interes, cre.id_tipo_credito, CONCAT(gar.Tipo,'\n',gar.Detalle,'\n',gar.Valuacion,'\n',gar.Estado) AS Garantias, cre.saldo_cap, cre.dias_pago " +
            "FROM cliente cli " +
            "INNER JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI " +
            "INNER JOIN asigna_credito acre ON acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
            "LEFT JOIN sol_garant solg ON solg.Id_Solicitud=acre.ID_SOLICITUD " +
            "Left JOIN garantia gar ON gar.id_garant = solg.id_garant " +
            "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO " +
            "WHERE cre.ESTADO = 'Activo' " + ConsulAdd + ConsulAdd2 +
            "Group by cre.cod_credito " +
            "order by cli.nombres and cli.apellidos";
            DataTable credito = new DataTable();
            credito = buscar(consulta);

            // Pre-fetch all payments for active credits
            DataTable dtPagos = buscar("SELECT p.cod_credito, p.capital, p.interes, p.fecha FROM pagos p INNER JOIN credito c ON p.cod_credito = c.COD_CREDITO WHERE c.ESTADO = 'Activo' AND p.estado = 'Hecho' ORDER BY p.fecha ASC");
            Dictionary<string, List<PagoInfo>> pagosDict = new Dictionary<string, List<PagoInfo>>();
            foreach (DataRow row in dtPagos.Rows)
            {
                string cod = row["cod_credito"].ToString();
                if (!pagosDict.ContainsKey(cod))
                {
                    pagosDict[cod] = new List<PagoInfo>();
                }
                pagosDict[cod].Add(new PagoInfo
                {
                    Capital = row["capital"] == DBNull.Value ? 0m : Convert.ToDecimal(row["capital"]),
                    Interes = row["interes"] == DBNull.Value ? 0m : Convert.ToDecimal(row["interes"]),
                    Fecha = Convert.ToDateTime(row["fecha"])
                });
            }

            int cont, total;
            total = credito.Rows.Count;
            for (cont = 0; cont < total; cont++)
            {
                DataRow row = credito.Rows[cont];
                string cod = row["COD_CREDITO"].ToString();
                string tipo = row["id_tipo_credito"].ToString();
                List<PagoInfo> pagosList = pagosDict.ContainsKey(cod) ? pagosDict[cod] : new List<PagoInfo>();

                // 1) O(1) Memory Calculations instead of N+1 database queries
                int diasatras = CalcularDiasNoPagMemoria(row, pagosList, DateTime.Now.Date);

                if (diasatras > 0)
                {
                    var saldosRes = CalcularSaldosDiasMemoria(row, pagosList, DateTime.Now.Date);
                    decimal capitalAtras = saldosRes.Item1;
                    decimal inte = saldosRes.Item2;
                    if (inte < 0) inte = 0;

                    if (inte > 0 || capitalAtras > 0)
                    {
                        Reportes.AtrasosD detalle = new Reportes.AtrasosD();
                        string tipoc = "";
                        if (tipo.Equals("1")) { tipoc = "Diario"; }
                        else if (tipo.Equals("2")) { tipoc = "Diario-Interes"; }
                        else if (tipo.Equals("3")) { tipoc = "Mensual"; }
                        else if (tipo.Equals("4")) { tipoc = "Mensual-Sobresaldo"; }
                        else if (tipo.Equals("5")) { tipoc = "Semanal"; }
                        else if (tipo.Equals("6")) { tipoc = "Quincenal"; }
                        string Garantia = row["Garantias"] != DBNull.Value ? row["Garantias"].ToString() : "Sin Garantia";

                        detalle.Nombre = $"{row["Nombre"]}/{tipoc}";
                        detalle.Monto = Convert.ToDecimal(row["monto"]);
                        detalle.Lugar = "Total a cancelar";
                        detalle.Catraso = capitalAtras;
                        detalle.Iatraso = inte;
                        detalle.dias = diasatras;
                        detalle.Tel = row["telefonos"].ToString();
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

        public void ColAct(string titulo, string tip, string aseso)
        {
            EstadoEnc Encab = new EstadoEnc();
            DataTable credito = new DataTable();
            DataTable totalcart = new DataTable();
            string consultatotal = "SELECT SUM(c.MONTO) AS TotalCart "+
                                    "FROM credito c "+
                                    "JOIN asigna_credito acre ON c.COD_CREDITO = acre.COD_CREDITO "+
                                    $"JOIN asigna_solicitud asol ON acre.ID_SOLICITUD = asol.ID_SOLICITUD AND asol.COD_ASESOR = {aseso} "+
                                    "WHERE c.ESTADO = 'Activo'";
            totalcart = buscar(consultatotal);
           decimal totcart = totalcart.Rows[0][0]==DBNull.Value ? 0M : Convert.ToDecimal(totalcart.Rows[0][0]);
            Encab.cliente  = titulo;
            Encab.monto = totcart;
            string consulta,ConsulAdd="";
            string ConsulAdd2 = "";

            if (tip == "Diario")
            { ConsulAdd = "and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2 or cre.id_tipo_credito=5 or cre.id_tipo_credito=6)"; }
            else if (tip == "Mensual")
            { ConsulAdd = "and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4) "; }
            if (aseso.Equals("0"))
            {
                ConsulAdd2 = "";
            }
            else
            {
                ConsulAdd2 = $"and aso.Cod_Asesor={aseso}";
            }
            consulta = "SELECT cre.COD_CREDITO, concat(cli.NOMBRES,' ' ,cli.apellidos) AS nombre, cre.monto,cre.plazo,cre.interes,date_format(cre.fecha_conc,'%d-%M-%Y'),date_format(cre.Fecha_venci,'%d-%M-%Y'),cre.saldo_cap, cli.codigo_cli,cre.id_tipo_credito,CONCAT(gar.Tipo,'\n',gar.Detalle,'\n',gar.Valuacion,'\n',gar.Estado) AS Garantias, cli.telefono1, cli.telefono2, cli.telefonoCon, cre.fecha_conc, cre.Fecha_venci, cre.dias_pago  " +
                       "FROM credito cre " +
                       "INNER JOIN asigna_credito ac ON ac.COD_CREDITO = cre.COD_CREDITO " +
                       "INNER JOIN asigna_solicitud aso ON aso.ID_SOLICITUD = ac.ID_SOLICITUD " +
                       "LEFT JOIN sol_garant solg ON solg.Id_Solicitud = ac.ID_SOLICITUD "+
                       "Left JOIN garantia gar ON gar.id_garant = solg.id_garant "+
                       "INNER JOIN cliente cli ON cli.CODIGO_CLI = aso.codigo_cli " +
                       $"WHERE cre.ESTADO = 'Activo' {ConsulAdd} {ConsulAdd2} " +
                       "GROUP BY cre.COD_CREDITO " +
                       "ORDER BY cre.FECHA_CONC";
            credito = buscar(consulta);

            // Cargar todos los pagos activos en memoria en una sola consulta
            DataTable dtPagos = buscar("SELECT p.cod_credito, p.capital, p.interes, p.fecha FROM pagos p INNER JOIN credito c ON p.cod_credito = c.COD_CREDITO WHERE c.ESTADO = 'Activo' AND p.estado = 'Hecho' ORDER BY p.fecha ASC");
            Dictionary<string, List<PagoInfo>> pagosDict = new Dictionary<string, List<PagoInfo>>();
            foreach (DataRow row in dtPagos.Rows)
            {
                string cod = row["cod_credito"].ToString();
                if (!pagosDict.ContainsKey(cod))
                {
                    pagosDict[cod] = new List<PagoInfo>();
                }
                pagosDict[cod].Add(new PagoInfo
                {
                    Capital = row["capital"] == DBNull.Value ? 0m : Convert.ToDecimal(row["capital"]),
                    Interes = row["interes"] == DBNull.Value ? 0m : Convert.ToDecimal(row["interes"]),
                    Fecha = Convert.ToDateTime(row["fecha"])
                });
            }

            int cont, total;
            total = credito.Rows.Count;
            for (cont = 0; cont < total; cont++)
            {
                string codigocre = credito.Rows[cont][0].ToString();
                string tipo = credito.Rows[cont][9].ToString();
                List<PagoInfo> pagosList = pagosDict.ContainsKey(codigocre) ? pagosDict[codigocre] : new List<PagoInfo>();

                decimal monto = Convert.ToDecimal(credito.Rows[cont][2]);
                decimal interes = Convert.ToDecimal(credito.Rows[cont][4]);
                int plazo = Convert.ToInt32(credito.Rows[cont][3]);
                int diasp = Convert.ToInt32(credito.Rows[cont][16]); // index 16 is cre.dias_pago
                DateTime fechaConc = Convert.ToDateTime(credito.Rows[cont][14]); // index 14 is raw fecha_conc
                DateTime fechaVenci = Convert.ToDateTime(credito.Rows[cont][15]); // index 15 is raw Fecha_venci
                decimal saldoCap = Convert.ToDecimal(credito.Rows[cont][7]);

                // 1) Calcular diasatras en memoria
                int diasatras = CalcularDiasNoPagMemoria(credito.Rows[cont], pagosList, DateTime.Now.Date);

                // 2) Calcular saldos en memoria
                var saldosRes = CalcularSaldosDiasMemoria(credito.Rows[cont], pagosList, DateTime.Now.Date);
                decimal catras = saldosRes.Item1;
                decimal iatras = saldosRes.Item2;
                if (catras < 0) catras = 0;
                if (iatras < 0) iatras = 0;

                // Tipo 2 exception
                if (tipo.Equals("2"))
                {
                    catras = 0;
                    iatras = 0;
                    DateTime fechi = fechaVenci.AddHours(23).AddMinutes(59).AddSeconds(59);
                    if (DateTime.Now > fechi)
                    {
                        catras = saldosRes.Item1;
                        iatras = saldosRes.Item2;
                        if (catras < 0) catras = 0;
                        if (iatras < 0) iatras = 0;
                    }
                }

                if (catras > 0 || iatras > 0)
                {
                    // 3) Calcular cuota
                    decimal cuotac = 0;
                    decimal cuotai = 0;
                    if (tipo == "1" || tipo == "3" || tipo == "4" || tipo == "5" || tipo == "6")
                    {
                        cuotac = diasp > 0 ? Math.Round(monto / diasp, 2) : 0;
                    }
                    else if (tipo == "2")
                    {
                        int pagosProyFalso = PagProyMemoria(fechaConc.AddDays(1), DateTime.Now.Date.AddDays(1), "1", plazo);
                        cuotac = plazo > 0 ? (monto / plazo * pagosProyFalso) : 0;
                    }

                    if (tipo == "1")
                    {
                        cuotai = Math.Round(monto * interes / 100, 2);
                    }
                    else if (tipo == "2")
                    {
                        int pagosProyFalso = PagProyMemoria(fechaConc.AddDays(1), DateTime.Now.Date.AddDays(1), "1", plazo);
                        cuotai = Math.Round(monto * interes / 100 * pagosProyFalso, 2);
                    }
                    else if (tipo == "3")
                    {
                        cuotai = Math.Round(monto * interes / 100 / 12, 2);
                    }
                    else if (tipo == "4")
                    {
                        int difDias = 0;
                        if (pagosList.Count <= 0)
                        {
                            difDias = (DateTime.Now.Date - fechaConc.Date).Days;
                        }
                        else
                        {
                            difDias = (DateTime.Now.Date - pagosList[pagosList.Count - 1].Fecha.Date).Days;
                        }
                        decimal pagoint = ((saldoCap * interes / 100 / 12 / 30) * difDias);
                        cuotai = Math.Round(pagoint, 2);
                    }
                    else if (tipo == "5")
                    {
                        cuotai = Math.Round(monto * interes / 100 * 5, 2);
                    }
                    else if (tipo == "6")
                    {
                        cuotai = Math.Round(monto * interes / 100 * 10, 2);
                    }

                    if (cuotac < 0) cuotac = 0;
                    if (cuotai < 0) cuotai = 0;
                    decimal cuota = cuotac + cuotai;

                    string tipoc = "";
                    if (tipo.Equals("1")) { tipoc = "Diario"; }
                    else if (tipo.Equals("2")) { tipoc = "Diario-Interes"; }
                    else if (tipo.Equals("3")) { tipoc = "Mensual"; }
                    else if (tipo.Equals("4")) { tipoc = "Mensual-Sobresaldo"; }
                    else if (tipo.Equals("5")) { tipoc = "Semanal"; }
                    else if (tipo.Equals("6")) { tipoc = "Quincenal"; }

                    decimal capatras = catras;
                    decimal intatras = iatras;

                    string Garantia = credito.Rows[cont][10] != DBNull.Value ? credito.Rows[cont][10].ToString() : "Sin Garantia";
                    decimal Ccancelar = iatras + saldoCap;

                    DatosCre detalle = new DatosCre();
                    detalle.cre = int.Parse(codigocre);
                    detalle.cliente = credito.Rows[cont][1].ToString();
                    detalle.tipo = tipoc;
                    detalle.cuotap = pagosList.Count;
                    detalle.diatras = diasatras;
                    detalle.fechaconc = fechaConc;
                    detalle.fechavenc = fechaVenci;
                    detalle.tasa = credito.Rows[cont][4].ToString();
                    detalle.monto = monto;
                    detalle.capatras = capatras;
                    detalle.intatras = intatras;
                    detalle.cancelar = Ccancelar;
                    detalle.cuota = cuota;
                    detalle.utlimpag = pagosList.Count > 0 ? pagosList[pagosList.Count - 1].Fecha : fechaConc;

                    string tel1 = credito.Rows[cont][11] != DBNull.Value ? credito.Rows[cont][11].ToString() : "";
                    string tel2 = credito.Rows[cont][12] != DBNull.Value ? credito.Rows[cont][12].ToString() : "";
                    string telCon = credito.Rows[cont][13] != DBNull.Value ? credito.Rows[cont][13].ToString() : "";
                    detalle.telefono = tel1 + "\n" + tel2 + "\n" + telCon;

                    detalle.Garantia = Garantia;
                    Encab.Datos.Add(detalle);
                }
            }
            Reportes.CreCartera formu = new Reportes.CreCartera();
            formu.Enca.Add(Encab);
            formu.Deta = Encab.Datos;
            formu.Show();
        }

        public void RepCreActi(string titulo, string t, string aseso)
        {
            DataTable datos = new DataTable();
            string ConsulAdd1 = "";
            string ConsulAdd2 = "";
            if (t == "Diario")
            {
                ConsulAdd1 = "and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2 or cre.id_tipo_credito=5 or cre.id_tipo_credito=6) ";
            }
            else if (t == "Mensual")
            { ConsulAdd1 = "and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4) "; }

            if (aseso.Equals("0"))
            {
                ConsulAdd2 = "";
            }
            else
            {
                ConsulAdd2 = $"and asol.Cod_Asesor={aseso} ";
            }
            string consulta = "SELECT cre.COD_CREDITO, cli.NOMBRES, cli.APELLIDOS, cre.saldo_cap, date_format(cre.fecha_conc,'%d/%m/%Y') AS fechaconc_format, date_format(cre.Fecha_venci,'%d/%m/%Y') AS fechavenci_format, cre.id_tipo_credito, CONCAT(gar.Tipo,'\n',gar.Detalle,'\n',gar.Valuacion,'\n',gar.Estado) AS Garantias, Concat(cli.telefono1,'-',cli.telefono2) as Telefonos, cre.monto, cre.fecha_conc, cre.Fecha_venci, cre.interes, cre.dias_pago " +
                              "FROM credito cre " +
                              "INNER JOIN asigna_credito acre ON acre.COD_CREDITO = cre.COD_CREDITO " +
                              "INNER JOIN asigna_solicitud asol ON asol.ID_SOLICITUD = acre.ID_SOLICITUD " +
                              "LEFT JOIN sol_garant solg ON solg.Id_Solicitud = acre.ID_SOLICITUD " +
                              "Left JOIN garantia gar ON gar.id_garant = solg.id_garant " +
                              "INNER JOIN cliente cli ON cli.CODIGO_CLI = asol.codigo_cli " +
                              "WHERE cre.ESTADO='Activo'" + ConsulAdd1 + ConsulAdd2 +
                              "GROUP BY cre.COD_CREDITO";
            
            datos = buscar(consulta);
            int cant = datos.Rows.Count;

            // Pre-fetch all payments for active credits
            DataTable dtPagos = buscar("SELECT p.cod_credito, p.capital, p.interes, p.fecha FROM pagos p INNER JOIN credito c ON p.cod_credito = c.COD_CREDITO WHERE c.ESTADO = 'Activo' AND p.estado = 'Hecho' ORDER BY p.fecha ASC");
            Dictionary<string, List<PagoInfo>> pagosDict = new Dictionary<string, List<PagoInfo>>();
            foreach (DataRow row in dtPagos.Rows)
            {
                string cod = row["cod_credito"].ToString();
                if (!pagosDict.ContainsKey(cod))
                {
                    pagosDict[cod] = new List<PagoInfo>();
                }
                pagosDict[cod].Add(new PagoInfo
                {
                    Capital = row["capital"] == DBNull.Value ? 0m : Convert.ToDecimal(row["capital"]),
                    Interes = row["interes"] == DBNull.Value ? 0m : Convert.ToDecimal(row["interes"]),
                    Fecha = Convert.ToDateTime(row["fecha"])
                });
            }

            RepEnc enca = new RepEnc();
            enca.Titulo = titulo;
            for (int cont = 0; cont < cant; cont++)
            {
                DataRow row = datos.Rows[cont];
                string codcre = row["COD_CREDITO"].ToString();
                string tipo = row["id_tipo_credito"].ToString();
                List<PagoInfo> pagosList = pagosDict.ContainsKey(codcre) ? pagosDict[codcre] : new List<PagoInfo>();

                // Calculate interest balance in memory
                var saldosRes = CalcularSaldosDiasMemoria(row, pagosList, DateTime.Now.Date);
                decimal interes = Math.Max(0, saldosRes.Item2);

                string tipoc = "";
                if (tipo.Equals("1")) { tipoc = "(D)"; }
                else if (tipo.Equals("2")) { tipoc = "(DI)"; }
                else if (tipo.Equals("3")) { tipoc = "(M)"; }
                else if (tipo.Equals("4")) { tipoc = "(MS)"; }
                else if (tipo.Equals("5")) { tipoc = "(S)"; }
                else if (tipo.Equals("6")) { tipoc = "(Q)"; }

                string Garantia = row["Garantias"] != DBNull.Value ? row["Garantias"].ToString() : "Sin Garantia";
                
                Credi_Activity detalle = new Credi_Activity();
                detalle.Credito = int.Parse(codcre);
                detalle.Monto = Convert.ToDecimal(row["monto"]);
                detalle.Nombre = $"{row["NOMBRES"]}  {row["APELLIDOS"]} /{tipoc}";
                detalle.Scapital = Convert.ToDecimal(row["saldo_cap"]);
                detalle.Sinteres = interes;
                detalle.Fcons = row["fechaconc_format"].ToString();
                detalle.Fvenc = row["fechavenci_format"].ToString();
                detalle.Garantia = Garantia;
                detalle.Tel = row["Telefonos"].ToString();
                enca.DetalleActi.Add(detalle);
            }
            
            Credi_Activ Activos = new Credi_Activ();
            Activos.detalle = enca.DetalleActi;
            Activos.encabezado.Add(enca);
            Activos.Show();
        }

 
        public void RepDiaPago(string titulo, string tip, string fech, string aseso)
        {
            EstadoEnc Encab = new EstadoEnc();
            DataTable credito = new DataTable();
            Encab.cliente = titulo;
            string consulta, ConsulAdd = "", addAseso = "";
            if (!aseso.Equals("0")) addAseso = $"AND aso.COD_ASESOR={aseso}";
            if (tip == "Diario")
            { ConsulAdd = "and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2 or cre.id_tipo_credito=5 or cre.id_tipo_credito=6) "; }
            else if (tip == "Mensual")
            { ConsulAdd = "and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4) "; }

            // Optimized query: Select necessary client/credit columns to avoid sub-queries inside the loop
            consulta = "SELECT cre.COD_CREDITO, concat(cli.NOMBRES,' ' ,cli.apellidos) AS nombre, cre.monto, cre.plazo, cre.interes, cre.fecha_conc, cre.Fecha_venci, cre.saldo_cap, cli.codigo_cli, cre.id_tipo_credito, CONCAT(gar.Tipo,'\n',gar.Detalle,'\n',gar.Valuacion,'\n',gar.Estado) AS Garantias, cli.telefono1, cli.telefono2, cli.telefonoCon, cre.dias_pago " +
                       "FROM credito cre " +
                       "INNER JOIN asigna_credito ac ON ac.COD_CREDITO = cre.COD_CREDITO " +
                       "INNER JOIN asigna_solicitud aso ON aso.ID_SOLICITUD = ac.ID_SOLICITUD " +
                       "LEFT JOIN sol_garant solg ON solg.Id_Solicitud = ac.ID_SOLICITUD " +
                       "Left JOIN garantia gar ON gar.id_garant = solg.id_garant " +
                       "INNER JOIN cliente cli ON cli.CODIGO_CLI = aso.codigo_cli " +
                       $"WHERE cre.ESTADO = 'Activo' {addAseso} {ConsulAdd} " +
                       "GROUP BY cre.COD_CREDITO " +
                       "ORDER BY cre.FECHA_CONC";
            credito = buscar(consulta);

            // Pre-fetch all payments for active credits to perform calculations in memory
            DataTable dtPagos = buscar("SELECT p.cod_credito, p.capital, p.interes, p.fecha FROM pagos p INNER JOIN credito c ON p.cod_credito = c.COD_CREDITO WHERE c.ESTADO = 'Activo' AND p.estado = 'Hecho' ORDER BY p.fecha ASC");
            Dictionary<string, List<PagoInfo>> pagosDict = new Dictionary<string, List<PagoInfo>>();
            foreach (DataRow row in dtPagos.Rows)
            {
                string cod = row["cod_credito"].ToString();
                if (!pagosDict.ContainsKey(cod))
                {
                    pagosDict[cod] = new List<PagoInfo>();
                }
                pagosDict[cod].Add(new PagoInfo
                {
                    Capital = row["capital"] == DBNull.Value ? 0m : Convert.ToDecimal(row["capital"]),
                    Interes = row["interes"] == DBNull.Value ? 0m : Convert.ToDecimal(row["interes"]),
                    Fecha = Convert.ToDateTime(row["fecha"])
                });
            }

            DateTime fechapag = DateTime.Parse(fech);
            int total = credito.Rows.Count;

            for (int cont = 0; cont < total; cont++)
            {
                DataRow row = credito.Rows[cont];
                string codigocre = row["COD_CREDITO"].ToString();
                string tipo = row["id_tipo_credito"].ToString();
                DateTime fechaConc = Convert.ToDateTime(row["fecha_conc"]);

                // 1) O(1) in-memory check if the selected date matches the payment schedule before performing any calculations
                bool sihayp = false;
                if (tip.Equals("Diario"))
                {
                    sihayp = fechapag.Date >= fechaConc.Date;
                }
                else if (tip.Equals("Mensual"))
                {
                    int monthsDiff = (fechapag.Year - fechaConc.Year) * 12 + (fechapag.Month - fechaConc.Month);
                    sihayp = monthsDiff >= 1 && fechaConc.AddMonths(monthsDiff).Date == fechapag.Date;
                }

                if (!sihayp)
                {
                    continue; // Skip entirely, avoiding all calculations and overhead
                }

                // 2) Gather pre-fetched details and perform calculations in memory
                List<PagoInfo> pagosList = pagosDict.ContainsKey(codigocre) ? pagosDict[codigocre] : new List<PagoInfo>();
                decimal monto = Convert.ToDecimal(row["monto"]);
                int plazo = Convert.ToInt32(row["plazo"]);
                decimal interes = Convert.ToDecimal(row["interes"]);
                DateTime fechaVenci = Convert.ToDateTime(row["Fecha_venci"]);
                decimal saldoCap = Convert.ToDecimal(row["saldo_cap"]);
                int diasp = Convert.ToInt32(row["dias_pago"]);

                // In-memory calculations for diasatras and saldos
                int diasatras = CalcularDiasNoPagMemoria(row, pagosList, DateTime.Now.Date);
                var saldosRes = CalcularSaldosDiasMemoria(row, pagosList, DateTime.Now.Date);

                decimal catras = Math.Max(0, saldosRes.Item1);
                decimal iatras = Math.Max(0, saldosRes.Item2);

                // Compute cuotac and cuotai in memory
                decimal cuotac = diasp > 0 ? Math.Round(monto / diasp, 2) : 0;
                decimal cuotai = 0;

                if (tipo == "1" || tipo == "2")
                {
                    cuotai = Math.Round(monto * interes / 100, 2);
                }
                else if (tipo == "3")
                {
                    cuotai = Math.Round(monto * interes / 100 / 12, 2);
                }
                else if (tipo == "4")
                {
                    int difDias = (pagosList.Count <= 0)
                        ? (DateTime.Now.Date - fechaConc.Date).Days
                        : (DateTime.Now.Date - pagosList[pagosList.Count - 1].Fecha.Date).Days;
                    decimal pagoint = ((saldoCap * interes / 100 / 12 / 30) * difDias);
                    cuotai = Math.Round(pagoint, 2);
                }
                else if (tipo == "5")
                {
                    cuotai = Math.Round(monto * interes / 100 * 5, 2);
                }
                else if (tipo == "6")
                {
                    cuotai = Math.Round(monto * interes / 100 * 10, 2);
                }

                if (cuotac < 0) cuotac = 0;
                if (cuotai < 0) cuotai = 0;
                decimal cuota = cuotac + cuotai;

                string tipoc = "";
                if (tipo.Equals("1")) { tipoc = "Diario"; }
                else if (tipo.Equals("2")) { tipoc = "Diario-Interes"; }
                else if (tipo.Equals("3")) { tipoc = "Mensual"; }
                else if (tipo.Equals("4")) { tipoc = "Mensua-Sobresaldo"; }

                decimal Ccancelar = iatras + saldoCap;

                string tel1 = row["telefono1"] != DBNull.Value ? row["telefono1"].ToString() : "";
                string tel2 = row["telefono2"] != DBNull.Value ? row["telefono2"].ToString() : "";
                string telCon = row["telefonoCon"] != DBNull.Value ? row["telefonoCon"].ToString() : "";

                DatosCre detalle = new DatosCre();
                detalle.cre = int.Parse(codigocre);
                detalle.cliente = row["nombre"].ToString();
                detalle.tipo = tipoc;
                detalle.cuotap = pagosList.Count;
                detalle.diatras = diasatras;
                detalle.fechaconc = fechaConc;
                detalle.fechavenc = fechaVenci;
                detalle.tasa = interes.ToString();
                detalle.monto = monto;
                detalle.capatras = catras;
                detalle.intatras = iatras;
                detalle.cancelar = Ccancelar;
                detalle.cuota = cuota;
                detalle.utlimpag = pagosList.Count > 0 ? pagosList[pagosList.Count - 1].Fecha : fechaConc;
                detalle.telefono = tel1 + "\n" + tel2 + "\n" + telCon;
                detalle.Garantia = row["Garantias"] != DBNull.Value ? row["Garantias"].ToString() : "Sin Garantia";

                Encab.Datos.Add(detalle);
            }

            Reportes.Pagohoy formu = new Reportes.Pagohoy();
            formu.Enca.Add(Encab);
            formu.Deta = Encab.Datos;
            formu.Show();
        }

        #region "Calculo de Ganacias"
        public void Ganancia(string Fechai, string Fechaf, string nomfecha,string idA,string Asesor)
        {
            Reportes.RepEnc Encab = new Reportes.RepEnc();
            string consulextra = "";
            if (!idA.Equals("0")) consulextra = $"AND asol.COD_ASESOR={idA}";
            Encab.Titulo = "Reporte de ganacia " + nomfecha;
            Encab.periodo = $"{Asesor}";
            string consulta;
            consulta = "SELECT CONCAT(cli.nombres, ' ', Apellidos) AS nombre, cre.monto, SUM(pag.capital) AS cap, SUM(pag.interes)AS inte, pag.mora AS mora, cre.cod_credito " +
                     "FROM cliente cli " +
                     $"inner JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI {consulextra} " +
                     "inner JOIN asigna_credito acre ON acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
                     "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO  and cre.estado!='Cancelado' " +
                     "LEFT JOIN pagos pag on cre.COD_CREDITO = pag.COD_CREDITO  and pag.estado='Hecho' " +
                     $"WHERE ((pag.FECHA >= '{Fechai}' AND pag.FECHA <= '{Fechaf}') OR (cre.FECHA_CONC>='{Fechai}' AND cre.FECHA_CONC<='{Fechaf}' AND cre.Gastos_admin>0)) " +
                     "GROUP BY cre.cod_credito " +
                     "Order by cli.nombres";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            int total;
            total = datos.Rows.Count;
            List<GanaciaDet> TotalDetas = new List<GanaciaDet>();
            // Versión optimizada con menos conversiones y validaciones
            for (int i = 0; i < total; i++)
            {
                var row = datos.Rows[i];
                string codigocre = row[5].ToString() ?? string.Empty;

                // Convertir directamente a decimal evitando conversiones string intermedias
                decimal capi = row[2] == DBNull.Value ? 0m : Convert.ToDecimal(row[2]);
                decimal inte = row[3] == DBNull.Value ? 0m : Convert.ToDecimal(row[3]);
                decimal pago = row[4] == DBNull.Value ? 0m : Convert.ToDecimal(row[4]);

                // Cálculos una sola vez
                decimal capicalc = pag.totalcapi(Fechai, Fechaf, codigocre);
                decimal intecalc = pag.totalinte(Fechai, Fechaf, codigocre);
                decimal moracalc = pag.totalmora(Fechai, Fechaf, codigocre);

                // Usar los valores calculados si son diferentes
                capi = capi != capicalc ? capicalc : capi;
                inte = inte != intecalc ? intecalc : inte;
                pago = pago != moracalc ? moracalc : pago;

                // Calcular gastos solo si es necesario
                decimal gastos = cre.gasadmin(codigocre, Fechai, Fechaf);

                TotalDetas.Add(new GanaciaDet
                {
                    Cliente = $"{row[0]}\nCredito: {codigocre}",
                    Monto = Convert.ToDecimal(row[1]),
                    Mora = pago,
                    Capital = capi,
                    Interes = inte,
                    Gastos = gastos
                });
            }
            Reportes.Ganancias Gan = new Reportes.Ganancias();
            Gan.Enc.Add(Encab);
            Gan.Deta = TotalDetas;
            Gan.Show();
            //faltaln datos en form ganacias
        }

        public void GanaciaDi(string Fechai, string Fechaf, string nomfecha, string idA, string Asesor)
        {
            Reportes.RepEnc Encab = new Reportes.RepEnc();
            string consulextra = "";
            if (!idA.Equals("0")) consulextra = $"AND asol.COD_ASESOR={idA}";
            Encab.Titulo = $"Reporte de ganacia {nomfecha}";
            Encab.periodo = $"{Asesor}";
            string consulta;
            consulta = "SELECT CONCAT(cli.nombres, ' ', Apellidos) AS nombre, cre.monto, SUM(pag.capital) AS cap, SUM(pag.interes)AS inte, pag.mora AS mora, cre.cod_credito " +
                     "FROM cliente cli " +
                     $"inner JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI {consulextra} " +
                     "inner JOIN asigna_credito acre ON acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
                     "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO  and cre.estado!='Cancelado' " +
                     "LEFT JOIN pagos pag on cre.COD_CREDITO = pag.COD_CREDITO  and pag.estado='Hecho' " +
                     $"WHERE ((pag.FECHA >= '{Fechai}' AND pag.FECHA <= '{Fechaf}' and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2 or cre.id_tipo_credito=5 or cre.id_tipo_credito=6 ) ) OR (cre.FECHA_CONC>='{Fechai}' AND cre.FECHA_CONC<='{Fechaf}' AND cre.Gastos_admin>0 and (cre.id_tipo_credito=1 or cre.id_tipo_credito=2 or cre.id_tipo_credito=5 or cre.id_tipo_credito=6))) " +
                     "GROUP BY cre.cod_credito " +
                     "Order by cli.nombres";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            int total, cont;
            total = datos.Rows.Count;
            List<GanaciaDet> TotalDetas = new List<GanaciaDet>();
            // Pre-dimensionar la lista para mejor rendimiento si total es conocido
            if (TotalDetas.Capacity < total)
            {
                TotalDetas.Capacity = total;
            }

            for (int i = 0; i < total; i++)
            {
                var row = datos.Rows[i];

                // Obtener código de crédito una sola vez
                string codigocre = row[5].ToString() ?? string.Empty;

                // Convertir directamente a decimal con manejo de nulos
                decimal capi = row[2] == DBNull.Value ? 0m : Convert.ToDecimal(row[2]);
                decimal inte = row[3] == DBNull.Value ? 0m : Convert.ToDecimal(row[3]);
                decimal pago = row[4] == DBNull.Value ? 0m : Convert.ToDecimal(row[4]);

                // Cálculos (mantenerlos si son necesarios)
                decimal capicalc = pag.totalcapi(Fechai, Fechaf, codigocre);
                decimal intecalc = pag.totalinte(Fechai, Fechaf, codigocre);
                decimal moracalc = pag.totalmora(Fechai, Fechaf, codigocre);

                // Actualizar solo si son diferentes
                if (capi != capicalc) capi = capicalc;
                if (inte != intecalc) inte = intecalc;
                if (pago != moracalc) pago = moracalc;

                // Crear y configurar objeto
                var detall = new GanaciaDet
                {
                    Cliente = $"{row[0]}\nCredito: {codigocre}",
                    Monto = Convert.ToDecimal(row[1]),
                    Mora = pago,
                    Capital = capi,
                    Interes = inte,
                    Gastos = cre.gasadmin(codigocre, Fechai, Fechaf)
                };

                TotalDetas.Add(detall);
            }
            Reportes.Ganancias Gan = new Reportes.Ganancias();
            Gan.Enc.Add(Encab);
            Gan.Deta = TotalDetas;
            Gan.Show();
            //faltaln datos en form ganacias

        }

        public void GanaciaMes(string Fechai, string Fechaf, string nomfecha, string idA, string Asesor)
        {
            Reportes.RepEnc Encab = new Reportes.RepEnc();
            string consulextra = "";
            if (!idA.Equals("0")) consulextra = $"AND asol.COD_ASESOR={idA}";
            Encab.Titulo = $"Reporte de ganacia {nomfecha}";
            Encab.periodo = Asesor;
            string consulta;
            consulta = "SELECT CONCAT(cli.nombres, ' ', Apellidos) AS nombre, cre.monto, SUM(pag.capital) AS cap, SUM(pag.interes)AS inte, pag.mora AS mora, cre.cod_credito " +
                     "FROM cliente cli " +
                     $"inner JOIN asigna_solicitud asol ON asol.codigo_cli = cli.CODIGO_CLI {consulextra} " +
                     "inner JOIN asigna_credito acre ON acre.ID_SOLICITUD = asol.ID_SOLICITUD " +
                     "INNER JOIN credito cre ON cre.COD_CREDITO = acre.COD_CREDITO  and cre.estado!='Cancelado' " +
                     "LEFT JOIN pagos pag on cre.COD_CREDITO = pag.COD_CREDITO  and pag.estado='Hecho' " +
                     $"WHERE ((pag.FECHA >= '{Fechai}' AND pag.FECHA <= '{Fechaf}' and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4) ) OR (cre.FECHA_CONC>='{Fechai}' AND cre.FECHA_CONC<='{Fechaf}' AND cre.Gastos_admin>0 and (cre.id_tipo_credito=3 or cre.id_tipo_credito=4))) " +
                     "GROUP BY cre.cod_credito " +
                     "Order by cli.nombres";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            int total, cont;
            total = datos.Rows.Count;
            List<GanaciaDet> TotalDetas = new List<GanaciaDet>();
            // Pre-dimensionar la lista para mejor performance
            if (TotalDetas.Capacity < total)
            {
                TotalDetas.Capacity = total;
            }

            // Usar índice desde 0 para eliminar los "cont - 1"
            for (int i = 0; i < total; i++)
            {
                var row = datos.Rows[i];

                // Obtener valores de la fila una sola vez
                string codigocre = row[5].ToString() ?? string.Empty;

                // Convertir directamente a decimal con manejo de DBNull
                decimal pago = row[4] == DBNull.Value ? 0m : Convert.ToDecimal(row[4]);
                decimal capi = row[2] == DBNull.Value ? 0m : Convert.ToDecimal(row[2]);
                decimal inte = row[3] == DBNull.Value ? 0m : Convert.ToDecimal(row[3]);

                // Calcular valores
                decimal capicalc = pag.totalcapi(Fechai, Fechaf, codigocre);
                decimal intecalc = pag.totalinte(Fechai, Fechaf, codigocre);
                decimal moracalc = pag.totalmora(Fechai, Fechaf, codigocre);

                // Usar valores calculados si son diferentes (sin conversiones a string innecesarias)
                if (capi != capicalc) capi = capicalc;
                if (inte != intecalc) inte = intecalc;
                if (pago != moracalc) pago = moracalc;

                // Crear y poblar el objeto en una sola operación
                TotalDetas.Add(new GanaciaDet
                {
                    Cliente = $"{row[0]}\nCredito: {codigocre}",
                    Monto = Convert.ToDecimal(row[1]),
                    Mora = pago,
                    Capital = capi,
                    Interes = inte,
                    Gastos = cre.gasadmin(codigocre, Fechai, Fechaf)
                });
            }
            Reportes.Ganancias Gan = new Reportes.Ganancias();
            Gan.Enc.Add(Encab);
            Gan.Deta = TotalDetas;
            Gan.Show();
            //faltaln datos en form ganacias

        }

        #endregion

        #region Inversiones

        public void Inversiones()
        {
            Reportes.InvEnc Enca = new InvEnc();
            List<Reportes.InvDet> Deta = new List<InvDet>();
            DataTable datos = new DataTable();
            string consulta = "SELECT  inv.Id_Inv,cli.CODIGO_CLI,Concat(cli.NOMBRES,' ',cli.APELLIDOS),cli.DOMICILIO,cli.TELEFONO1 ,inv.Monto,inv.Plazo,Date_format(inv.FechaIn,'%Y/%m/%d'),Date_format(inv.FechaFin,'%Y/%m/%d'),inv.Interes " +
"FROM inversion inv "+
"inner JOIN asigna_inversion ainv ON inv.Id_Inv = ainv.Id_Inv "+
"INNER JOIN cliente cli ON ainv.Codigo_Cli = cli.CODIGO_CLI "+
"WHERE inv.Estado = 'Activo'";
            datos = buscar(consulta);
            int cont, cant;
            cant = datos.Rows.Count;
            Enca.Titulo = "Reporte de Inversiones";
            for (cont = 0; cont < cant; cont++)
            {
                Reportes.InvDet Temp = new InvDet();
                string ConsulBenef = "SELECT CONCAT(cli.nombres,' ' ,cli.apellidos) AS Nombre, cli.telefono1,cli.telefono2 " +
"FROM cliente cli " +
"INNER JOIN benefiinver binv ON cli.CODIGO_CLI = binv.Id_Benef " +
$"WHERE binv.Id_Inv = {datos.Rows[cont][0]}";

                DataTable benefi = buscar(ConsulBenef);
                Temp.Monto = decimal.Parse($"{datos.Rows[cont][5]}");
                Temp.Plazo = int.Parse($"{datos.Rows[cont][6]}");
                Temp.Precorr = 0;
                Temp.Por = decimal.Parse($"{datos.Rows[cont][9]}") * 100;
                Temp.FI = DateTime.Parse($"{datos.Rows[cont][7]}");
                Temp.FF = DateTime.Parse($"{datos.Rows[cont][8]}");
                Temp.Cliente = ($"{datos.Rows[cont][2]}");
                Temp.No_inv = int.Parse($"{datos.Rows[cont][0]}");
                Temp.Telefono = ($"{datos.Rows[cont][4]}");
                Temp.Direccion = ($"{datos.Rows[cont][3]}");
                Temp.BenefTel= $"{benefi.Rows[0][1]}";
                Temp.Benef = $"{benefi.Rows[0][0]}";

                Deta.Add(Temp);
                
                int lol = cont;
            }
            Reportes.Inversiones nuevo = new Inversiones();
            nuevo.Encabezado.Add(Enca);
            nuevo.Detalle = Deta;
            nuevo.Show();

            


        }

        public void InversionesAVencer(string ini, string fin)
        {
            Reportes.InvEnc Enca = new InvEnc();
            
            List<Reportes.InvDet> Deta = new List<InvDet>();
            DataTable datos = new DataTable();
            string consulta = "SELECT  inv.Id_Inv,cli.CODIGO_CLI,Concat(cli.NOMBRES,' ',cli.APELLIDOS),cli.DOMICILIO,cli.TELEFONO1 ,inv.Monto,inv.Plazo,Date_format(inv.FechaIn,'%Y/%m/%d'),Date_format(inv.FechaFin,'%Y/%m/%d'),inv.Interes " +
"FROM inversion inv " +
"inner JOIN asigna_inversion ainv ON inv.Id_Inv = ainv.Id_Inv " +
"INNER JOIN cliente cli ON ainv.Codigo_Cli = cli.CODIGO_CLI " +
"WHERE inv.Estado = 'Activo'";
            string cons = $"SELECT inv.Id_Inv,cli.CODIGO_CLI,CONCAT(cli.NOMBRES,' ', cli.APELLIDOS) AS Nombre_Completo,cli.DOMICILIO,cli.TELEFONO1,inv.Monto,inv.Plazo,DATE_FORMAT(inv.FechaIn, '%Y/%M/%d') AS Fecha_Inicio,DATE_FORMAT(inv.FechaFin, '%Y/%M/%d') AS Fecha_Fin,inv.Interes " +
                $"FROM inversion inv " +
                $"INNER JOIN asigna_inversion ainv ON inv.Id_Inv = ainv.Id_Inv " +
                $"INNER JOIN cliente cli ON ainv.Codigo_Cli = cli.CODIGO_CLI " +
                $"WHERE inv.Estado = 'Activo' " +
                $"AND inv.FechaFin>='{ini} 00:00:00' and Fechafin<='{fin} 23:59:59'; ";
            datos = buscar(cons);
            int cont, cant;
            cant = datos.Rows.Count;
            Enca.Titulo = "Reporte de Inversiones";
            for (cont = 0; cont < cant; cont++)
            {
                Reportes.InvDet Temp = new InvDet();
                string ConsulBenef = "SELECT CONCAT(cli.nombres,' ' ,cli.apellidos) AS Nombre, cli.telefono1,cli.telefono2 " +
"FROM cliente cli " +
"INNER JOIN benefiinver binv ON cli.CODIGO_CLI = binv.Id_Benef " +
$"WHERE binv.Id_Inv = {datos.Rows[cont][0]}";


                DataTable benefi = buscar(ConsulBenef);

                
                Temp.Monto = decimal.Parse($"{datos.Rows[cont][5]}");
                Temp.Plazo = int.Parse($"{datos.Rows[cont][6]}");
                Temp.Precorr = PeriodoCurrido($"{datos.Rows[cont][7]}",$"{datos.Rows[cont][8]}");
                Temp.Por = Math.Round((decimal.Parse($"{datos.Rows[cont][9]}")  * Temp.Precorr * Temp.Monto / 12), 2); 
                Temp.FI = DateTime.Parse($"{datos.Rows[cont][7]}");
                Temp.FF = DateTime.Parse($"{datos.Rows[cont][8]}");
                Temp.Cliente = ($"{datos.Rows[cont][2]}");
                Temp.No_inv = int.Parse($"{datos.Rows[cont][0]}");
                Temp.Telefono = ($"{datos.Rows[cont][4]}");
                Temp.Direccion = ($"{datos.Rows[cont][3]}");
                Temp.BenefTel = $"{benefi.Rows[0][1]}";
                Temp.Benef = $"{benefi.Rows[0][0]}";

                Deta.Add(Temp);

                int lol = cont;
            }
            Reportes.InversionesProntas nuevo = new InversionesProntas();
          //  nuevo.Encabezado.Add(Enca);
            nuevo.Detalle = Deta;
            nuevo.Show();
        }

        private int PeriodoCurrido(string Dada,string fecha)
        {
            DateTime FechaHoy = DateTime.Parse(fecha);
            DateTime FechaIni = DateTime.Parse(Dada);
            FechaIni = FechaIni.AddMonths(1);
            int conteo = 0;
            while (FechaHoy >= FechaIni)
            {
                conteo++;
                FechaIni = FechaIni.AddMonths(1);
            }
            return conteo;
        }

        #endregion
    }
}

