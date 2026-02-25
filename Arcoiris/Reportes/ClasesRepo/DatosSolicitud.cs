using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Arcoiris.Reportes.ClasesRepo
{
    class DatosSolicitud
    {
        [Key]
      public int IdSol { get; set; }
        public string Asesor { get; set; }
        public DateTime FechaSol { get; set; }
        public DateTime Naci { get; set; }
        public int Edad { get; set; }
        public string Cliente { get; set; }
        public string DpiImg64 { get; set; }
        [MaxLength(13)]
        public string DPI { get; set; }
        public string Domicilio{ get; set; }
        public string Referencia { get; set; }
        [MaxLength(8)]
        public string Tel1 { get; set; }
        public string Prof1 { get; set; }
        public string EstadoCivil { get; set; }
        [MaxLength(8)]
        public string Tel2 { get; set; }
        public string Prof2 { get; set; }
        public string CagaF { get; set; }
        public string NomCony  { get; set; }
        public string ProfCony { get; set; }
        [MaxLength(8)]
        public string TelCony { get; set; }
        [MaxLength(13)]
        public string DPICony { get; set; }
        public string TipoNeg { get; set; }
        public string NomNeg { get; set; }
        public string TelNeg { get; set; }
        public string DirNeg { get; set; }
        public string AntiqNeg { get; set; }
        public string RefNeg { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
        public decimal MontoSug { get; set; }
        public string TipoCred { get; set; }
        public string MotivoCred { get; set; }
        public string PagoCred { get; set; }
        public int PlazoCred { get; set; }
        public int RazonCred { get; set; }
        public decimal interes { get; set; }
        public string FamConCredito { get; set; }





        //datos de fiador
        public List<FiadorSolicitud> Fiador { get; set; }

        //datos de referencias
      public  List<ReferenciaSolicitud> Refs { get; set; }

        //datos garantias
        public List<GarantiaSolicitud> Garan { get; set; }

    }
}
