using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Reportes
{
    class InvDet
    {
        public int No_inv { get; set; }
        public string Cliente { get; set; }
        public int Plazo { get; set; }
        public int Precorr { get; set; }
        public decimal Monto { get; set; }
        public DateTime FI { get; set; }
        public DateTime FF { get; set; }
        public decimal Por { get; set; }
        public string Telefono {get;set;}
        public string Direccion { get; set; }
    public string Benef { get; set; }
        public string BenefTel { get; set; }
    }
}
