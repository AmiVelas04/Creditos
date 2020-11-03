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
    public partial class BoletaPag : Form
    {
       public List <Reportes.PagoDesc> descripcion = new List <Reportes.PagoDesc>();
        public BoletaPag()
        {
            InitializeComponent();
        }

        private void BoletaPag_Load(object sender, EventArgs e)
        {
            this.BoletaRep.LocalReport.DataSources.Clear();
          //  ReportParameter[] parametro = new ReportParameter[1];
            this.BoletaRep.LocalReport.DataSources.Add(new ReportDataSource("Pago",descripcion ));
           // this.BoletaRep.SetDisplayMode(DisplayMode.PrintLayout);
           // this.BoletaRep.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
           // this.BoletaRep.ZoomPercent = 100;
            this.BoletaRep.RefreshReport();
        }
    }
}
