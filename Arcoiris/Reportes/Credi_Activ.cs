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
     partial class Credi_Activ : Form
    {
        public List<Reportes.RepEnc> encabezado = new List<RepEnc>();
        public List<Reportes.Credi_Activity> detalle = new List<Credi_Activity>();

        public Credi_Activ()
        {
            InitializeComponent();
        }

        private void Credi_Activ_Load(object sender, EventArgs e)
        {
            this.Rpv1.LocalReport.DataSources.Clear();
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", encabezado));
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", detalle));
            this.Rpv1.SetDisplayMode(DisplayMode.PrintLayout);
            this.Rpv1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.Rpv1.ZoomPercent = 100;
            this.Rpv1.RefreshReport();
        }
    }
}
