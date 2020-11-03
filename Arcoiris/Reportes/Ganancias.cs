﻿using System;
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
    partial class Ganancias : Form
    {
       public List<Reportes.RepDetCli> Deta = new List<Reportes.RepDetCli>();
        public List<Reportes.RepEnc> Enc = new List<Reportes.RepEnc>();
        public Ganancias()
        {
            InitializeComponent();
        }

        private void Ganancias_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport .DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Detalle", Deta));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("Encabezado", Enc));
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.Percent;
            //Seleccionamos el zoom que deseamos utilizar. En este caso un 100%
            this.reportViewer1.ZoomPercent = 100;
            this.reportViewer1.RefreshReport();
        }
    }
}
