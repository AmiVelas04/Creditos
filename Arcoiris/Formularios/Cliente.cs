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


      
 

       
        private void guardar()
        {
            string nom = TxtNom .Text;
            string ape = TxtApe .Text;
            string dir = TxtDir .Text;
            string dpi = TxtDpi.Text;
            string tel1 = TxtCTel1 .Text;
            string tel2 = TxtCTel2.Text;
            string prof = TxtProf.Text;
            string Est_civil = CboScivil .Text ;
            string Nom_cony = TxtNomcony.Text ;
            string Ape_cony = TxtApecony.Text;
            string telcon = TxtConTel.Text;
            string refe = TxtRef.Text;
            string fiad = TxtFiador.Text;
            string tfiad = TxtFtel.Text;
            string dfiad = TxtFdir.Text;
            string fecha = DateTime.Today.ToString("yyyy/MM/dd");
            string[] datos = {nom,ape,dir,dpi,tel1,tel2,prof,Est_civil,Nom_cony,Ape_cony,telcon,refe,fiad,tfiad,dfiad,fecha};
         //   int idcli;
         //   idcli = clien.agregar_cliente(datos);
            if (clien.agregar_cliente(datos))
            {
                MessageBox.Show("Datos del cliente guardados","Guardar",MessageBoxButtons.OK,MessageBoxIcon.Information );
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
            DGVCliente.DataSource = clien.buscar_cli(TxtNomBus .Text  );
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
            TxtFiador.Clear();
            TxtFdir.Clear();
            TxtFtel.Clear();
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
            CboScivil.SelectedIndex = 0;
            TabC3.Parent = null;
            verifUsu();
        }

        private void verifUsu()
        {
            if (Form1.Cod_U == "4")
            {
                BtnEditar.Text = "Ver";
                BtnGuardar.Visible = false;
                BtnLimpiar.Visible = false;
                tabControl1.SelectedIndex = 1;
                TabC1.Hide();


                    
                    BtnUpd.Visible = false;
                BtnClean.Visible = false;

            }
            
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
       
            if (DGVCliente .Rows .Count > 0) { 
            if (DGVCliente.CurrentRow.Index ==-1)
            {
         
            }
            else
            {
                DataTable fiad = new DataTable();
                idcli = Convert.ToString(DGVCliente.CurrentRow.Cells[0].Value);
                fiad = clien.idfiad(idcli);
                idfiad = fiad.Rows[0][0].ToString();
                TxtFiadNom2.Text = fiad.Rows[0][1].ToString();
                TxtFiadDir2.Text = fiad.Rows[0][2].ToString();
                TxtFiadTel2.Text = fiad.Rows[0][3].ToString();
                DataTable cliedit = new DataTable();
                cliedit=clien.clientebusca (idcli);
                TabC3.Parent = tabControl1;
                tabControl1.SelectedIndex = 2;
                TxtNom2.Text = cliedit.Rows[0][0].ToString();
                TxtApe2 .Text = cliedit.Rows[0][1].ToString();
                TxtDir2 .Text = cliedit.Rows[0][2].ToString();
                TxtDpi2 .Text = cliedit.Rows[0][3].ToString();
                TxtTel2_1 .Text = cliedit.Rows[0][4].ToString();
                TxtTel2_2.Text = cliedit.Rows[0][5].ToString();
                TxtProf2 .Text = cliedit.Rows[0][6].ToString();
                TxtNomCony2 .Text = cliedit.Rows[0][7].ToString();
                TxtApeCony2 .Text = cliedit.Rows[0][8].ToString();
               TxtTelCony2 .Text = cliedit.Rows[0][9].ToString();
                TxtRef2 .Text = cliedit.Rows[0][10].ToString();
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

            }
            }
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
            
            string nom = TxtNom2.Text;
            string ape = TxtApe2.Text;
            string dir = TxtDir2.Text;
            string dpi = TxtDpi2.Text;
            string tel1 = TxtTel2_1.Text;
            string tel2 = TxtTel2_2.Text;
            string prof = TxtProf2.Text;
            string Est_civil = CboCivil2.Text;
            string Nom_cony = TxtNomCony2.Text;
            string Ape_cony = TxtApeCony2.Text;
            string telcon = TxtTelCony2.Text;
            string refe = TxtRef2.Text;
            string fiad = TxtFiadNom2.Text;
            string tfiad = TxtFiadTel2.Text;
            string dfiad = TxtFiadDir2.Text;
            string[] cliente = {nom,ape,dir,dpi,tel1,tel2,prof,Est_civil ,Nom_cony ,Ape_cony ,telcon ,refe };
            string[] fiador = { fiad ,dfiad, tfiad };

            if (clien.updatecliente(idcli , cliente))
            {
                if (clien.updatefiad(idfiad , fiador))
                {
                    MessageBox.Show("Datos Actualizados");
                }
                else
                {
                    MessageBox.Show("Error al actualizar datos del fiador");
                }
            }
            else
            {
                MessageBox.Show("Error al actualizar datos del cliente");
            }
            
            
        }
    }
}


