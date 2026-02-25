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
    partial class InversionesProntas : Form
    {
        public List<Reportes.InvDet> Detalle = new List<InvDet>();
        public InversionesProntas()
        {
            InitializeComponent();
        }

        private void InversionesProntas_Load(object sender, EventArgs e)
        {
            Rpv1.LocalReport.DataSources.Clear();
         //   Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Encabezado));
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Datos", Detalle));
            this.Rpv1.SetDisplayMode(DisplayMode.PrintLayout);
            this.Rpv1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.Rpv1.ZoomPercent = 100;

            this.Rpv1.RefreshReport();
        }
    }
}
