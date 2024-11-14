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
    public partial class IngresoNota : Form
    {

        public string credi { get; set; }
        public string Asesor { get; set; }
        Clases.Bitacora Bita = new Clases.Bitacora();


        public IngresoNota()
        {
            InitializeComponent();
           
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            string[] datos = { DateTime.Now.ToString("yyyy/MM/dd HH:mm"), credi,Asesor,TxtNota.Text };
            if (Bita.ingre(datos))
            {
                MessageBox.Show("Nota de seguimiento ingresada correctamente", "Nota Ingresada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al ingresar nota de seguimiento", "Algo salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IngresoNota_Load(object sender, EventArgs e)
        {
            TxtCred.Text = credi;
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            ListaBitacora Lista = new ListaBitacora();
            Lista.cred = credi;
            Lista.ShowDialog();
        }
    }
}
