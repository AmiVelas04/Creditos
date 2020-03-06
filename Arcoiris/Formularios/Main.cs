using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcoiris.Formularios
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void BtnCliente_Click(object sender, EventArgs e)
        {
            PanelCentral.Controls.Clear();
            Formularios.Cliente formul = new Formularios.Cliente();
            formul.TopLevel = false;
            PanelCentral.Controls.Add(formul);
            PanelCentral.Tag = formul;
            formul.Show();

        }

        private void BtnAsesor_Click(object sender, EventArgs e)
        {
            PanelCentral.Controls.Clear();
            Formularios.Asesor asesor = new Formularios.Asesor();
            asesor.TopLevel = false;
            PanelCentral.Controls.Add(asesor);
            PanelCentral.Tag = asesor;
            asesor.Show();
        }

        private void BtnSolicitud_Click(object sender, EventArgs e)
        {
            PanelCentral.Controls.Clear();
            Formularios.Solicitud soli =new  Solicitud();
            soli.TopLevel = false;
            PanelCentral.Controls.Add(soli);
            PanelCentral.Tag = soli;
            soli.Show();
        }

        private void BtnCredito_Click(object sender, EventArgs e)
        {
            PanelCentral.Controls.Clear();
            Formularios.Prestamo  presta = new Prestamo();
            presta.TopLevel = false;
            PanelCentral.Controls.Add(presta);
            PanelCentral.Tag = presta;
            presta.Show();
        }
    }
}
