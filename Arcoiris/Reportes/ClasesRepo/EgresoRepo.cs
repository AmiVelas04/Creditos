using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Reportes.ClasesRepo
{
    class EgresoRepo
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public string Detalle { get; set; }
        public string Empresa { get; set; }
        public decimal Cuota_men { get; set; }
    }
}
