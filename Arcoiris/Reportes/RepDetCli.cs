using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Reportes
{
    class RepDetCli
    {
        //detalle de reporte para reporte general y reporte de creditos cancelasod y activos
        public string Cliente { get; set; }
        public string Credito { get; set; }
        public string  pago { get; set; }
        public string Fecha { get; set; }
        public decimal Total { get; set; }
        public string FechaD { get; set; }
        public string FechaC { get; set; }
        public string tel { get; set; }
        public decimal Gadmin { get; set; }
        public string Garantia { get; set; }

    }
}
