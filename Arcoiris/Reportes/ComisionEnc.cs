using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Reportes
{
    class ComisionEnc
    {
        public string asesor { get; set; }
        public string fechai { get; set; }
        public string fechaf { get; set; }

        public List<ComisionDet> detalle = new List<ComisionDet>();
    }
}
