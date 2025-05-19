using System;
using System.Collections.Generic;

using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Arcoiris.Reportes
{
     partial class Inversiones : Form
    {
        public List<Reportes.InvEnc> Encabezado = new List<InvEnc>();
       public  List<Reportes.InvDet> Detalle = new List<InvDet>();
        public Inversiones()
        {
            InitializeComponent();
        }

        private void Inversiones_Load(object sender, EventArgs e)
        {
            Rpv1.LocalReport.DataSources.Clear();
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Encabezado));
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Detalle));
            this.Rpv1.SetDisplayMode(DisplayMode.PrintLayout);
            this.Rpv1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.Rpv1.ZoomPercent = 100;

            this.Rpv1.RefreshReport();
        }
    }
}
