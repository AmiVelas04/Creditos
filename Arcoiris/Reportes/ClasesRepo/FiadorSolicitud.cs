using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Reportes.ClasesRepo
{
    class FiadorSolicitud
    {
        
        public string Nombre { get; set; }
        [MaxLength(13)]
        public string Dpi { get; set; }
        
        public string Domicilio { get; set; }
        [MaxLength(8)]
        public string Tel1 { get; set; }
        [MaxLength(8)]
        public string Tel2 { get; set; }
        public DateTime Fecha { get; set; }
        public int Edad { get; set; }
        
        public string Profes { get; set; }
        public string RefUbi { get; set; }
        public string OhterIncome { get; set; }
        
    }
}
