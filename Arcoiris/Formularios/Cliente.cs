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
    public partial class Cliente : Form
    {

        Clases.Cliente clien = new Clases.Cliente();
        string idcli;
        string idfiad;
        public Cliente()
        {
            InitializeComponent();
        }




        private void cargarDepas()
        {
            List<Clases.Modelos.DeparamentoModel> todos = clien.Depar();
            CboDepa.DataSource = todos;
            CboDepa.DisplayMember = "Nombre";
            CboDepa.ValueMember = "Id";
            CboDepaEdit.DataSource = todos;
            CboDepaEdit.ValueMember = "Id";
            CboDepaEdit.DisplayMember = "Nombre";
        }

        private void guardar()
        {
            string Nacionalidad = "";
            string genero = "";

            if (CboGene.SelectedIndex == 0)
            { Nacionalidad = "Guatemalteco";
                genero = "M";
            }
            else
            { Nacionalidad = "Guatemalteca";
                genero = "F";
            }
            string nom = TxtNom.Text;
            string ape = TxtApe.Text;
            string dir = TxtDir.Text;
            string dpi = TxtDpi.Text;
            string tel1 = TxtCTel1.Text;
            string tel2 = TxtCTel2.Text;
            string prof = TxtProf.Text;
            string Est_civil = CboScivil.Text;
            string Nom_cony = TxtNomcony.Text;
            string Ape_cony = TxtApecony.Text;
            string telcon = TxtConTel.Text;
            string refe = TxtRef.Text;
         string fiad = "";// TxtFiador.Text;
            string tfiad = "";// TxtFtel.Text;
            string dfiad = "";// TxtFdir.Text;
            string depa = CboDepa.Text;
            string muni = CboMuni.Text;
            string edad = NudEdad.Value.ToString();
           
            
            string fecha = DateTime.Today.ToString("yyyy/MM/dd");
            string[] datos = { nom, ape, dir, dpi, tel1, tel2, prof, Est_civil, Nom_cony, Ape_cony, telcon, refe, fiad, tfiad, dfiad, fecha,depa,muni,edad,genero, Nacionalidad };
            //   int idcli;
            //   idcli = clien.agregar_cliente(datos);
            if (clien.agregar_cliente(datos))
            {
                MessageBox.Show("Datos del cliente guardados", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
            }
            else
            {
                MessageBox.Show("Existe un error en el guardado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                limpiar();
            }
        }


        private void buscar_cli()
        {
            DGVCliente.DataSource = clien.buscar_cli(TxtNomBus.Text);
            DGVCliente.Columns[0].Visible = false;
            DGVCliente.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            DGVCliente.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            DGVCliente.Refresh();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            buscar_cli();
        }
        private void limpiar()
        {
            TxtNom.Clear();
            TxtDpi.Clear();
            TxtApe.Clear();
            TxtApecony.Clear();
            TxtDir.Clear();
            TxtNomBus.Clear();
            TxtNomcony.Clear();
            TxtProf.Clear();
            TxtRef.Clear();
            TxtCTel1.Clear();
            CboScivil.SelectedIndex = 0;
        }



        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarIng();
        }
        private void LimpiarIng()
        {
            TxtNom.Clear();
            TxtApe.Clear();
            TxtDir.Clear();
            TxtDpi.Clear();
            TxtCTel1.Clear();
            TxtCTel2.Clear();
            TxtProf.Clear();
            TxtNomcony.Clear();
            TxtApecony.Clear();
            TxtConTel.Clear();
            TxtRef.Clear();
           // TxtFiador.Clear();
            //TxtFdir.Clear();
            //TxtFtel.Clear();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            CboScivil.Items.Add("Soltero");
            CboCivil2.Items.Add("Soltero");
            CboScivil.Items.Add("Casado");
            CboCivil2.Items.Add("Casado");
            CboScivil.Items.Add("Viudo");
           CboCivil2.Items.Add("Viudo");
            CboScivil.Sorted = true;
            CboGene.SelectedIndex = 0;
            CboScivil.SelectedIndex = 0;
            TabC3.Parent = null;
            if (Form1.Nivel == "4")
            {
                BtnGuardar.Visible = false;
                BtnUpd.Visible = false;
            }
            cargarDepas();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            cargarparaeditar();
        }
        private void limpiargrid()
        {

            while (DGVCliente.RowCount > 1)
            {

                DGVCliente.Rows.Remove(DGVCliente.CurrentRow);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0 || tabControl1.SelectedIndex == 1)
            {
                TabC3.Parent = null;
            }
        }

        private void BtnUpd_Click(object sender, EventArgs e)
        {
            guardar2();
        }

        private void guardar2()
        {
            string gene = "";
            if (CboGeneEdit.SelectedIndex == 0)
            { gene = "M"; }
            else
            { gene = "F"; }

            string nom = TxtNom2.Text;
            string ape = TxtApe2.Text;
            string dir = TxtDir2.Text;
            string dpi = TxtDpi2.Text;
            string tel1 = TxtTel1Edit.Text;
          string tel2 = TxtTel2Edit.Text;
            string prof = TxtProf2.Text;
            string Est_civil = CboCivil2.Text;
            string Nom_cony = TxtNomCony2.Text;
            string Ape_cony = TxtApeCony2.Text;
            string telcon = TxtTelCony2.Text;
            string refe = TxtRef2.Text;
            // string fiad = TxtFiadNom2.Text;
            //   string tfiad = TxtFiadTel2.Text;
            //    string dfiad = TxtFiadDir2.Text;
            string depa = CboDepa.Text;
            string muni = CboMuni.Text;
            string edad = NudEdad.Value.ToString();
      
            string[] cliente = {nom, ape, dir, dpi, tel1,tel2, prof, Est_civil, Nom_cony, Ape_cony, telcon, refe,edad,gene };
          //  string[] fiador = { fiad, dfiad, tfiad };

            if (clien.updatecliente(idcli, cliente))
            {
                MessageBox.Show("Datos Actualizados");
                TabC3.Parent = null;
                /*if (clien.updatefiad(idfiad, fiador))
                {                                 }
                else
                {                    MessageBox.Show("Error al actualizar datos del fiador");                }*/
            }
            else
            {
                MessageBox.Show("Error al actualizar datos del cliente");
            }


        }

        private void CboDepa_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboDepa.SelectedValue != null && !CboDepa.SelectedValue.ToString().Equals("Arcoiris.Clases.Modelos.DeparamentoModel"))
            {
                string id = CboDepa.SelectedValue.ToString();
                CboMuni.DataSource = clien.Munis(id);
                CboMuni.DisplayMember = "Nombre";
                CboMuni.ValueMember = "Id";
            }
        }

        private void DGVCliente_DoubleClick(object sender, EventArgs e)
        {
            cargarparaeditar();
        }

        private void cargarparaeditar()
        {
            if (DGVCliente.Rows.Count > 0)
            {
                try
                {
                    if (DGVCliente.CurrentRow.Index == -1)
                    {

                    }
                    else
                    {
                        DataTable fiad = new DataTable();
                        idcli = Convert.ToString(DGVCliente.CurrentRow.Cells[0].Value);
                       // fiad = clien.idfiad(idcli);
                       // idfiad = fiad.Rows[0][0].ToString();
                        //  TxtFiadNom2.Text = fiad.Rows[0][1].ToString();
                        //   TxtFiadDir2.Text = fiad.Rows[0][2].ToString();
                        //     TxtFiadTel2.Text = fiad.Rows[0][3].ToString();
                        DataTable cliedit = new DataTable();
                        cliedit = clien.clientebusca(idcli);
                        TabC3.Parent = tabControl1;
                        tabControl1.SelectedIndex = 2;
                        TxtNom2.Text = cliedit.Rows[0][0].ToString();
                        TxtApe2.Text = cliedit.Rows[0][1].ToString();
                        TxtDir2.Text = cliedit.Rows[0][2].ToString();
                        TxtDpi2.Text = cliedit.Rows[0][3].ToString();
                        TxtTel1Edit.Text = cliedit.Rows[0][4].ToString();
                        TxtTel2Edit.Text = cliedit.Rows[0][5].ToString();
                        TxtProf2.Text = cliedit.Rows[0][6].ToString();
                        TxtNomCony2.Text = cliedit.Rows[0][7].ToString();
                        TxtApeCony2.Text = cliedit.Rows[0][8].ToString();
                        TxtTelCony2.Text = cliedit.Rows[0][9].ToString();
                        TxtRef2.Text = cliedit.Rows[0][10].ToString();

                        if (cliedit.Rows[0][11].ToString() == "Soltero")
                        {
                            CboCivil2.SelectedIndex = 0;
                        }
                        else if (cliedit.Rows[0][11].ToString() == "Casado")
                        {
                            CboCivil2.SelectedIndex = 1;
                        }
                        else if (cliedit.Rows[0][11].ToString() == "Viudo")
                        {
                            CboCivil2.SelectedIndex = 2;
                        }
                        //12 edad
                        NudEdadEdit.Value = decimal.Parse(cliedit.Rows[0][12].ToString());
                        //13 departamento
                        //14 municipio
                        //15 genero
                        if (cliedit.Rows[0][15].ToString().Equals("M"))
                        {
                            CboGeneEdit.SelectedIndex = 0; }
                        else
                        {
                            CboGeneEdit.SelectedIndex = 1;
                        }
                        //16 nacionalidad
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Seleccione un elemento de la lista\n {ex}","Se presento un problema",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

            }
        }

        private void CboDepaEdit_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CboDepaEdit.SelectedValue != null && !CboDepaEdit.SelectedValue.ToString().Equals("Arcoiris.Clases.Modelos.DeparamentoModel"))
            {
                string id = CboDepaEdit.SelectedValue.ToString();
                CboMunEdit.DataSource = clien.Munis(id);
                CboMunEdit.DisplayMember = "Nombre";
                CboMunEdit.ValueMember = "Id";
            }
        }

        private void TxtNomBus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscar_cli();
            }
        }

        private void BtnClean_Click(object sender, EventArgs e)
        {

        }
    }
}


