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
    partial class Retiro : Form
    {
        public List<RetDet> Deta = new List<RetDet>();
        public Retiro()
        {
            InitializeComponent();
        }

        private void Retiro_Load(object sender, EventArgs e)
        {
            this.Rpv1.LocalReport.DataSources.Clear();
            this.Rpv1.LocalReport.DataSources.Add(new ReportDataSource("RetiroDet", Deta));
       
            this.Rpv1.RefreshReport();
        }
    }
}
