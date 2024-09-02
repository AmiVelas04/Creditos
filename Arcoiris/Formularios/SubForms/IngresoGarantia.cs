using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcoiris.Formularios.SubForms
{
    partial class IngresoGarantia : Form
    {
        public int garant { get; set; }
        public delegate void Garantia(Reportes.Contratos.ContratoDatos data);
        public event Garantia RegresarGarant;
        Reportes.Contratos.ContratoDatos datos = new Reportes.Contratos.ContratoDatos();
        
        public IngresoGarantia()
        {
            InitializeComponent();
        }

        private void guardar()
        {
            datos.GarantDeudor = TxtDetaGaranD.Text;
            datos.GarantFiador = TxtDetaGaranF.Text;
        }

        private void IngresoGarantia_Load(object sender, EventArgs e)
        {
            if (garant == 1)
            {
                GbxGaranDeu.Visible = true;
                GbxGaranFia.Visible = false;
            }
            else if (garant == 2)
            {
                GbxGaranDeu.Visible = false;
                GbxGaranFia.Visible = true;
            }
            else if (garant == 3)
            {
                GbxGaranDeu.Visible = true;
                GbxGaranFia.Visible = true;
            }
            else
            {
                GbxGaranDeu.Visible = false;
                GbxGaranFia.Visible = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            RegresarGarant(datos);
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            datos.GarantDeudor = TxtDetaGaranD.Text;
            datos.GarantFiador = TxtDetaGaranF.Text;
            RegresarGarant(datos);
            this.Close();
        }
    }
}
