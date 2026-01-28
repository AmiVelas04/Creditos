using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Formularios.SubClases
{
    class Garantia
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public int  Propietario {get ;set;}
        public string Detalle { get; set; }
        public decimal Valor { get; set; }
        public string Informacion { get; set; }
        public string Observaciones { get; set; }
        public string Estado { get; set; }
    }
}
