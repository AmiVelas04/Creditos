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
    public partial class ListaBitacora : Form
    {

        Clases.Bitacora Bita = new Clases.Bitacora();
        public string cred { get; set; }
        public ListaBitacora()
        {
            InitializeComponent();
        }

        private void buscar()
        {
            DataTable datos = Bita.BucarBitaCred(cred);
            int filas = datos.Rows.Count;
            for (int i = 0; i < filas; i++)
            {
                Dgv1.Rows.Add(datos.Rows[i][0].ToString(), datos.Rows[i][1].ToString(), datos.Rows[i][2].ToString(), datos.Rows[i][3].ToString(), datos.Rows[i][4].ToString());
            }
        }

        private void ListaBitacora_Load(object sender, EventArgs e)
        {
            buscar();
        }
    }
}
