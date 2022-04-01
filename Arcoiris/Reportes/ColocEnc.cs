using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Reportes
{
    class ColocEnc
    {
        public string Titulo { get; set; }
        public string Fecha { get; set; }
        public string Ejecutivo { get; set; }
        public List<ColocDeta> detalle = new List<ColocDeta>();


    }
}
