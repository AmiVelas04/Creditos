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
    partial class Atrasos : Form
    {
        public List<Reportes.AtrasosD> Deta = new List<Reportes.AtrasosD>();
        public List<Reportes.AtrasosE> Enca = new List<Reportes.AtrasosE>();
        public Atrasos()
        {
            InitializeComponent();
        }

        private void Atrasos_Load(object sender, EventArgs e)
        {
        
            this.Rep1.LocalReport.DataSources.Clear();
            this.Rep1.LocalReport.DataSources.Add(new ReportDataSource ("Detalle",Deta));
            this.Rep1.LocalReport.DataSources.Add(new ReportDataSource("Titulo",Enca));
            this.Rep1.SetDisplayMode(DisplayMode.PrintLayout);
            this.Rep1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.Rep1.ZoomPercent = 100;
            this.Rep1.RefreshReport();
        }
    }
}
