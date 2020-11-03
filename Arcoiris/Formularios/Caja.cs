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
    public partial class Caja : Form
    {
        Clases.CajaOpe caj = new Clases.CajaOpe();
        public Caja()
        {
            InitializeComponent();
        }

        private void Caja_Load(object sender, EventArgs e)
        {
            CboOpe.Items.Add("Ingreso");
            CboOpe.Items.Add("Egreso");
            CboOpe.SelectedIndex = 0;
            liquido_caja();
            if (Form1.Cod_U == "1" || Form1.Cod_U == "2")
            {
                DtpFechaOpe.Enabled = true;
            }
            }

        private void liquido_caja()
        {
            decimal ingre = caj.Ingreso(DtpFechaOpe.Value.ToString("yyyy/MM/dd"));
            decimal egre= caj.egreso (DtpFechaOpe.Value.ToString("yyyy/MM/dd"));
            decimal liquido;
            liquido = ingre - egre;
            TxtIng.Text = "Q. " + ingre.ToString();
            TxtEgr .Text = "Q. " + egre .ToString();
            TxtLiquido .Text = "Q. " + liquido ;
        }

               

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if(TxtMonto.Text !="")
            { 
            ingreso_Ope();
                liquido_caja();
            }
        }

        private void ingreso_Ope()
        {
            int id = caj.id_pago()+1;
            string IdS = id.ToString();
            string operacion = CboOpe.Text;
            decimal monto = Convert.ToDecimal(TxtMonto .Text );
            string Montos = monto.ToString();
            string desc = TxtDesc.Text;
            string fecha = DtpFechaOpe.Value.ToString ("yyyy/MM/dd");
            string estado = "Activo";
            string usu = Form1.Cod_U;
            string cliente = "N/E";
            string Credito ="N/E";
            string[] datos = {IdS,operacion ,Montos ,desc,fecha,estado,usu,Credito,cliente};
            if (caj.ingreope(datos))
            {
                MessageBox.Show("Operacion ingresada");

            }
            else
            {
                MessageBox.Show("Error al ingresar operacion ");
            }
        }

        private void BtnBusc_Click(object sender, EventArgs e)
        {
            buscar();
            liquido_caja();
        }

        private void buscar()
        {
            DataTable mov = new DataTable();
            mov = caj.verpagos(DtpFechaOpe.Value.ToString("yyyy/MM/dd"));
            int cont, tot = mov.Columns.Count;

            DgvMov.RowTemplate.Height = 60;
            DgvMov.DataSource = mov;

            for (cont = 1; cont <= tot; cont++)
            {
                this.DgvMov.Columns[cont - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            /*   DgvMov.Columns[0].Width = 20;
               DgvMov.Columns[1].Width = 100;
               DgvMov.Columns[2].Width =100;
               DgvMov.Columns[3].Width = 400;
             //  DgvMov.Columns[3].Width = 350;
               DgvMov.Columns[4].Width = 100;*/
            DgvMov.Columns[0].Visible = false;
            DgvMov.Refresh();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (DgvMov.Rows.Count > 0)
            {
                int cont,total=DgvMov .Rows .Count;
                DataTable datos = new DataTable();
                datos.Columns.Add("operacion").DataType = System.Type.GetType("System.String");
                datos.Columns.Add("credito").DataType = System.Type.GetType("System.String");
                datos.Columns.Add("cliente").DataType = System.Type.GetType("System.String");
                datos.Columns.Add("monto").DataType = System.Type.GetType("System.String");
                datos.Columns.Add("descripcion").DataType = System.Type.GetType("System.String");
                datos.Columns.Add("usuario").DataType = System.Type.GetType("System.String");
                for (cont = 1; cont <= total; cont++)
                {
                    DataRow fila = datos.NewRow();
                    fila["operacion"] = DgvMov.Rows[cont - 1].Cells[1].Value;
                    fila["credito"]= DgvMov.Rows[cont - 1].Cells[2].Value;
                    fila["cliente"]= DgvMov.Rows[cont - 1].Cells[3].Value;
                    fila["monto"]= DgvMov.Rows[cont - 1].Cells[4].Value;
                    fila["descripcion"]= DgvMov.Rows[cont - 1].Cells[5].Value;
                    fila["usuario"]= DgvMov.Rows[cont - 1].Cells[6].Value;
                    datos.Rows.Add(fila);
                   }
                caj.imprimir_caja(datos, DtpFechaOpe.Value.ToString());
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
           
                BtnEliminar.Enabled = false;
            if (DgvMov.RowCount > 0 && DgvMov.CurrentRow.Index>=0)
            {
                int indice;
                indice = DgvMov.CurrentRow.Index;
                string idope = DgvMov.Rows[indice].Cells[0].Value.ToString ();
                if (caj.eliminarpago(idope))
                {
                    MessageBox.Show("Operacion de caja eliminada","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    buscar();
                }
                else
                {
                    MessageBox.Show("Operacion de caja no se pudo eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
        public void activar(int nivel)
        {
            if (nivel == 1 || nivel == 2)
            {
                BtnEliminar.Enabled = true;
                ChkAct.CheckState =CheckState.Unchecked;
                DtpFechaOpe.Enabled = true;
                //TxtCapital.Enabled = true;
            }


        }

        private void Caja_KeyDown(object sender, KeyEventArgs e)
        {
         
           
        }

        private void llamar()
        {

            if (Form1.Cod_U == "1" || Form1.Cod_U == "2")
            {
                MessageBox.Show("Elementos activados", "Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnEliminar.Enabled = true;
                DtpFechaOpe.Enabled = true;
            }
            else
            {
                Autopass pru = new Autopass();
                pru.verificar += new Autopass.permiso(activar);
                pru.ShowDialog();


            }
        }

        private void ChkAct_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkAct.Checked)
            {
                llamar();
                ChkAct.CheckState = CheckState.Unchecked;
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {

        }
    }
}

