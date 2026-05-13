using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Reportes
{
    class InversionComDeta
    {
        public string Agencia { set; get; }
        public string Cliente { get; set; }
        public string Direccion { get; set; }
        public string Beneficiario { get; set; }
        public DateTime Ingreso { get; set; }
        public DateTime Vencimiento { get; set; }
        public string Tel { get; set; }
        public int Plazo { get; set; }
        public int Inv { get; set; }
        public decimal Tasa { get; set; }
        public decimal Capital { get; set; }
        public decimal Interes { get; set; }
        public decimal Recibe { get; set; }

        public string DPI { get; set; }


    }
}
