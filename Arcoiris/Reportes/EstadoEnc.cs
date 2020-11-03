using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Reportes
{
    class EstadoEnc
    {
       public int NoCredi { set; get; }
        public string cliente { set; get; }
        public string direccion { set; get; }
        public string vence { set; get; }
        public string conc { set; get; }
        public string tasa { set; get; }
        public string plazo { set; get; }
        public decimal saldocap { set; get; }
        public decimal saldoint { set; get; }
        public decimal monto { set; get; }
        public decimal saldocance { set; get; }
        public List<EstadoDet> Detalle = new List<EstadoDet>();
        public List<DatosCre> Datos = new List<DatosCre>();
    }
}
