using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Reportes.ClasesRepo
{
    class IngresoRepo
    {
        public int Id { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Venta { get; set; }
        public decimal Ganacia { get; set; }
    }
}
