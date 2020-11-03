using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Reportes
{
    class RepEnc
    {
        public string Titulo { get; set; }
        public string periodo { get; set; }
        public decimal total { get; set; }
        public List<RepDetalle1> detalle = new List<RepDetalle1>();
        public List<RepDesem> detalleD = new List<RepDesem>();
        public List<RepDetCli > detalleC = new List <RepDetCli > ();
        public List<Credi_Activity> DetalleActi = new List<Credi_Activity>();

    }
}
