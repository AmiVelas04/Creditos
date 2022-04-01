
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
     partial class Colocacion : Form
    {
        public List<ColocEnc> Enca = new List<ColocEnc>();
        public List<ColocDeta> Deta = new List<ColocDeta>();
        public Colocacion()
        {
            InitializeComponent();
        }

        private void Colocacion_Load(object sender, EventArgs e)
        {
            this.Rpv1.LocalReport.DataSources.Clear();
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Deta));
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Enca", Enca));
            this.Rpv1.SetDisplayMode(DisplayMode.PrintLayout);
            this.Rpv1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.Rpv1.ZoomPercent = 100;
            this.Rpv1.RefreshReport();
            this.Rpv1.RefreshReport();
        }
    }
}
