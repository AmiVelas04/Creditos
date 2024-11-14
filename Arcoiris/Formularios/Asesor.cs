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
    public partial class Asesor : Form
    {
        Clases.ClAsesor ase =new  Clases.ClAsesor();
        Clases.Usuario Usu = new Clases.Usuario();
        public Asesor()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar() {
            string idusu = CboUsu.SelectedValue.ToString();
            string[] datos = {TxtNom.Text ,TxtTel .Text ,TxtDir.Text,idusu};
            if (ase.ingresar_asesor(datos))
            {
                MessageBox.Show("Asesor ingresado con exito","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
                limpiar();
            }
            else
            {
                MessageBox.Show("Error al ingredar asesor", "Algo salio salio mal!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiar();
            }
          }

        private void CargaUsu()
        {
            DataTable dt = new DataTable();
            dt = Usu.bucarusu();
            int total = dt.Rows.Count;
            //   int cont;
           CboUsu.DataSource = dt;
          CboUsu.DisplayMember = "Nombre";
           CboUsu.ValueMember = "cod_usuario";
           
        }

        private void Modificar()
        {
            string estado = "";
            if (RdbAct.Checked)
            {
                estado = "Activo";
            }
            else
            {
                estado = "Inactivo";
            }
            string[] datos = {LblId.Text,  TxtNom.Text, TxtTel.Text, TxtDir.Text,estado};
            if (ase.Modif_asesor(datos))
            {
                MessageBox.Show("Assesor ingresado con exito");
                limpiar();
            }
            else
            {
                MessageBox.Show("Error al ingredar asesor");
                limpiar();
            }
        }

        private void limpiar()
        {
            TxtDir.Clear();
            TxtNom.Clear();
            TxtTel.Clear();
            LblId.Text = "0";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            DGVAsesor .DataSource = ase.busca_asesor(TxtNom.Text);
            DGVAsesor.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            DGVAsesor.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            DGVAsesor.Columns[4].Visible = false;
            DGVAsesor.Refresh();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Modificar();
        }

        private void DGVAsesor_DoubleClick(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void cargarDatos()
        {
            int indice = DGVAsesor.CurrentRow.Index;
            LblId.Text = DGVAsesor.Rows[indice].Cells[0].Value.ToString();
            TxtNom.Text = DGVAsesor.Rows[indice].Cells[1].Value.ToString();
            TxtTel.Text = DGVAsesor.Rows[indice].Cells[2].Value.ToString();
            TxtDir.Text = DGVAsesor.Rows[indice].Cells[3].Value.ToString();
            if (DGVAsesor.Rows[indice].Cells[4].Value.ToString().Equals("1"))
            {
                RdbAct.Checked=true;
            }
            else
            {
                RdbDesact.Checked = true; ;
            }
        }

        private void Asesor_Load(object sender, EventArgs e)
        {
            CargaUsu();
        }
    }
}
