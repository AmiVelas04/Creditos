using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Reportes
{
   public class PagoDesc
    {
        /*
         boleta
         credito
         cliente
         direccion
         capital
         interes 
         mora
         total
         saldo

         */
        public int boleta { set; get;}
        public int credito { set; get; }
        public string cliente { set; get; }
        public string direccion { get; set; }
        public decimal capital { get; set; }
        public decimal interes { get; set; }
        public decimal mora { get; set; }
         public decimal total { set; get; }
        public decimal saldo { set; get; }
        public decimal saldoi { set; get; }
        public decimal totalD { set; get; }
        public string letras { get; set; }
        public string usuario { get; set; }
        public DateTime Fecha { get; set; }


    }
}
