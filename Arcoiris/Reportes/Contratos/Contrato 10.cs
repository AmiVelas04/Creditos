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

namespace Arcoiris.Reportes.Contratos
{
     partial class Contrato_10 : Form
    {
        public List<ContratoDatos> datos = new List<ContratoDatos>();
        public Contrato_10()
        {
            InitializeComponent();
        }

        private void Contrato_10_Load(object sender, EventArgs e)
        {
            this.Rep1.RefreshReport();
            this.Rep1.LocalReport.DataSources.Clear();
            this.Rep1.LocalReport.DataSources.Add(new ReportDataSource("Datos", datos));
            this.Rep1.SetDisplayMode(DisplayMode.PrintLayout);
            this.Rep1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.Rep1.ZoomPercent = 100;
            this.Rep1.RefreshReport();
        }
    }
}
