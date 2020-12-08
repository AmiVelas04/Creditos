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
    partial class Comisiones : Form
    {
        public List<Reportes.ComisionEnc> Encabezado = new List<ComisionEnc>();
        public List<Reportes.ComisionDet> Detalle = new List<ComisionDet>();

        public Comisiones()
        {
            InitializeComponent();
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            Rpv1.LocalReport.DataSources.Clear();
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Detalle",Detalle));
            Rpv1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Encabezado));
            this.Rpv1.RefreshReport();
        }
    }
}
