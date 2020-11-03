using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Arcoiris.Reportes
{
    public partial class Resumen : Form
    {
        public List<Reportes.TablaDet> Deta = new List<Reportes.TablaDet>();
        public List<Reportes.TablaEnc> Enca = new List<Reportes.TablaEnc>();

        public Resumen()
        {
            InitializeComponent();
        }

        private void Resumen_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter[] parametros = new ReportParameter[2];
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Deta));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Enca));
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.reportViewer1.ZoomPercent = 100;

            this.reportViewer1.RefreshReport();
        }
    }
}
