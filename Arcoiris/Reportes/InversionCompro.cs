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
     partial class InversionCompro : Form
    {
        public List<InversionComDeta> datos = new List<InversionComDeta>();
        public InversionCompro()
        {
            InitializeComponent();
        }

        private void InversionCompro_Load(object sender, EventArgs e)
        {
            this.RpvInvComp.LocalReport.DataSources.Clear();
            this.RpvInvComp.LocalReport.DataSources.Add(new ReportDataSource("InvComp", datos));
            this.RpvInvComp.SetDisplayMode(DisplayMode.PrintLayout);
            this.RpvInvComp.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.RpvInvComp.ZoomPercent = 100;
            this.RpvInvComp.RefreshReport();
        }
    }
}
