using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Reportes
{
    public class TablaEnc
    {
        public int NoCredito { get; set; }
        public string cliente { get; set; }
        public decimal total { get; set; }

        public string fechaV { get; set; }
        public string CreditoP { get; set; }
        public decimal gastos { get; set; }
        public string dpi { get; set; }
        public decimal gaper { get; set; }

        public List<TablaDet> detalle = new List<TablaDet>();

        
    }
}
