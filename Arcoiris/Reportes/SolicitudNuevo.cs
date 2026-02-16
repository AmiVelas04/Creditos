using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcoiris.Reportes
{
    partial class SolicitudNuevo : Form
    {
        public List<ClasesRepo.DatosSolicitud> DatosGen = new List<ClasesRepo.DatosSolicitud>();
        public List<ClasesRepo.ReferenciaSolicitud> Referi = new List<ClasesRepo.ReferenciaSolicitud>();
        public List<ClasesRepo.FiadorSolicitud> Fiado = new List<ClasesRepo.FiadorSolicitud>();
        public List<ClasesRepo.GarantiaSolicitud> Garant = new List<ClasesRepo.GarantiaSolicitud>();
        public List<ClasesRepo.IngresoRepo> Ingre = new List<ClasesRepo.IngresoRepo>();
        public List<ClasesRepo.EgresoRepo> Egres = new List<ClasesRepo.EgresoRepo>();
        public List<ClasesRepo.CuentaRepo> Cuenta = new List<ClasesRepo.CuentaRepo>();
        

        public SolicitudNuevo()
        {
            InitializeComponent();
        }

        private void SolicitudNuevo_Load(object sender, EventArgs e)
        {
            this.Rpv1.LocalReport.DataSources.Clear();
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("RepoSoli", DatosGen));

          
       
            this.Rpv1.SetDisplayMode(DisplayMode.PrintLayout);
            this.Rpv1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;
            this.Rpv1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.Rpv1.ZoomPercent =  115;
            this.Rpv1.Refresh();
            this.Rpv1.RefreshReport();
        }

        private void LocalReport_SubreportProcessing(object remitente, SubreportProcessingEventArgs e)
        {
            //  var ID = Convert.ToInt32(e.Parameters[0].Values[0]);
            //    var Referencias = Referi[0];
            if (e.ReportPath == "SoliFiador")
            {
                var Detalle_Fiador = new ReportDataSource() { Name = "FiadorData", Value = Fiado };
                e.DataSources.Add(Detalle_Fiador);
            }
            else if (e.ReportPath == "SoliGarant")
            {
                var Detalle_Garantia = new ReportDataSource() { Name = "GarantDato", Value = Garant };
                e.DataSources.Add(Detalle_Garantia);
            }
            else if (e.ReportPath == "SoliRefe")
            {
                var Detalle_Referencia = new ReportDataSource() { Name = "RefeDatos", Value = Referi };
                e.DataSources.Add(Detalle_Referencia);
            }
            else if (e.ReportPath== "Solicitud2daParte")
            {
                var Cuent = new ReportDataSource() { Name = "Cuenta", Value = Cuenta };
                var Ingreso = new ReportDataSource() { Name = "Ingreso", Value = Ingre };
                var Egreso = new ReportDataSource() { Name = "Egreso", Value = Egres };
                e.DataSources.Add(Cuent);
                e.DataSources.Add(Ingreso);
                e.DataSources.Add(Egreso);



            }


        }
    }
}
