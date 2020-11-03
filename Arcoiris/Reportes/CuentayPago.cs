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
    partial class CuentayPago : Form
    {
      public List<Reportes.EstadoEnc> portada = new List<Reportes.EstadoEnc>();
      public List<Reportes.EstadoDet> detall = new List<Reportes.EstadoDet>();

        public CuentayPago()
        {
            InitializeComponent();
        }

        private void CuentayPago_Load(object sender, EventArgs e)
        {
            this.RvCuenta.LocalReport.DataSources.Clear();
            this.RvCuenta.LocalReport.DataSources.Add(new ReportDataSource("DetalleEst",detall));
            this.RvCuenta.LocalReport.DataSources.Add(new ReportDataSource("EncabezadoEst", portada));
            this.RvCuenta.SetDisplayMode(DisplayMode.PrintLayout);
            this.RvCuenta.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.RvCuenta.ZoomPercent = 100;
            this.RvCuenta.RefreshReport();
        }
    }
}
