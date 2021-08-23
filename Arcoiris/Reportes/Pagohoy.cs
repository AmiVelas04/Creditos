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
     partial class Pagohoy : Form
    {
        public List<DatosCre> Deta = new List<DatosCre>();
        public List<EstadoEnc> Enca = new List<EstadoEnc>();
        public Pagohoy()
        {
            InitializeComponent();
        }

        private void Pagohoy_Load(object sender, EventArgs e)
        {
            List<DatosCre> NvoDeta = Deta.OrderBy(o => o.diatras).ToList();
            this.Rp1.LocalReport.DataSources.Clear();
            this.Rp1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", NvoDeta));
            this.Rp1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Enca));
       
            this.Rp1.RefreshReport();
        }
    }
}
