using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Arcoiris.Formularios
{
    public partial class Cliente : Form
    {

        Clases.Cliente clien = new Clases.Cliente();
        DataTable cliedit = new DataTable();
        DataTable clirefs = new DataTable();
        string DPISin = @"C:\Users\AMKDEV\Documents\Sistemas\Creditos\Recursos\lol.jpg";
       
        string idcli;
        //string idfiad;
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
            List<string> refes= new List<string>();
            foreach (DataGridViewRow fila in DgvRefs.Rows)
            {
                refes.Add($"{fila.Cells[1].Value}");
                refes.Add($"{fila.Cells[2].Value}");
                refes.Add($"{fila.Cells[3].Value}");
            }

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
          
            byte[] imagenbytes=File.ReadAllBytes(OfdDPI.FileName);
          
            string nom = TxtNom.Text;
            string ape = TxtApe.Text;
            string dir = TxtDir.Text;
            string dpi = TxtDpi.Text;
            string tel1 = TxtCTel1.Text;
            string tel2 = "";//TxtCTel2.Text;
            string prof = TxtProf.Text;
            string Est_civil = CboScivil.Text;
            string Nom_cony = TxtNomcony.Text;
            string Ape_cony = "";//TxtApecony.Text;
            string telcon = TxtConTel.Text;
            string refe = TxtRef.Text;
            string fiad = "";// TxtFiador.Text;
            string tfiad = "";// TxtFtel.Text;
            string dfiad = "";// TxtFdir.Text;
            string depa = CboDepa.Text;
            string muni = CboMuni.Text;
            string edad = NudEdad.Value.ToString();
            string oProf = TxtProf2In.Text;
            string DpiCon = TxtDpiCony.Text;
            string profCon = TxtProfCony.Text;
            string cargaf = TxtCargaF.Text;
            string NomNeg = TxtNomNeg.Text;
            string DirNeg = TxtDirNeg.Text;
            string TelNeg = TxtTelNeg.Text;
            string RefNeg = TxtRefNeg.Text;
            string TipNeg = TxtTipNeg.Text;
            string AntiqNeg=TxtAtiqNeg.Text;
            string fechanaci = DtpNac.Value.ToString("yyyy/MM/dd");
            string fecha = DateTime.Today.ToString("yyyy/MM/dd");
            string imagen = Convert.ToBase64String(imagenbytes);
            string[] datos = { nom, ape, dir,refe, dpi, tel1, tel2, prof, oProf, Est_civil, Nom_cony, telcon,  DpiCon, profCon, fecha,fechanaci, depa,muni,edad,genero, Nacionalidad,cargaf,NomNeg,DirNeg,TelNeg,RefNeg,TipNeg,AntiqNeg,imagen };
            //   int idcli;
            //   idcli = clien.agregar_cliente(datos);
            if (clien.agregar_cliente(datos,refes))
            {
                MessageBox.Show("Datos del cliente guardados correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo registrar el nuevo cliente", "Algo salio mal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               // limpiar();
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
           // TxtApecony.Clear();
            TxtDir.Clear();
            TxtNomBus.Clear();
            TxtNomcony.Clear();
            TxtProf.Clear();
            //TxtRef.Clear();
            TxtCTel1.Clear();
            CboScivil.SelectedIndex = 0;
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
          //  TxtCTel2.Clear();
            TxtProf.Clear();
            TxtNomcony.Clear();
           // TxtApecony.Clear();
            TxtConTel.Clear();
           // TxtRef.Clear();
           // TxtFiador.Clear();
            //TxtFdir.Clear();
            //TxtFtel.Clear();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            CboScivil.Items.Add("Soltero");
            CboCivEdit.Items.Add("Soltero");
            CboScivil.Items.Add("Casado");
            CboCivEdit.Items.Add("Casado");
            CboScivil.Items.Add("Viudo");
           CboCivEdit.Items.Add("Viudo");
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
            // Clases.Estilos.StyleForm(this);
            Colores();

        }

        private void Colores()
        {
           label1.ForeColor= Clases.Estilos.LabelText;
            GBXCliente.ForeColor = Clases.Estilos.TitleText;
            
            Clases.Estilos.StylePrimaryButton(BtnGuardar);
            Clases.Estilos.StylePrimaryButton(BtnUpd);
            Clases.Estilos.StyleSecondaryButton(BtnLimpiar);
            Clases.Estilos.StyleSecondaryButton(BtnClean);
            byte[] imageBytes = File.ReadAllBytes(DPISin);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
              PicDPI.Image = Image.FromStream(ms);
            }


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
            byte[] imagenbytes = File.ReadAllBytes(OfdDpiEdit.FileName);
            string nom = TxtNom2.Text;
            string ape = TxtApe2.Text;
            string dir = TxtDir2.Text;
            string dpi = TxtDpi2.Text;
            string tel1 = TxtTel1Edit.Text;
          string tel2 = TxtTel2Edit.Text;
            string prof = TxtProfEdit.Text;
            string Est_civil = CboCivEdit.Text;
            string Nom_cony = TxtNomCony2.Text;
            string profOt = TxtOProfEdit.Text;
            string telcon = TxtTelCony2.Text;
            string refe = TxtDpiConEdit.Text;
            string depa = CboDepaEdit.Text;
            string muni = CboMunEdit.Text;
            string edad = NudEdad.Value.ToString();
            string profcon = TxtProfConyEdit.Text;
            string dpicon = TxtDpiConEdit.Text;
            string nomneg = TxtNomNegEdit.Text;
            string dirneg = TxtDirNegEdit.Text;
            string telneg = TxtTelNegEdit.Text;
            string refneg = TxtRefNegEdit.Text;
            string tipneg = TxtTelNegEdit.Text;
            string antiqneg = TxtAntiqNegEdit.Text;
            string carga = TxtCargaFamEdit.Text;
            string imagen = Convert.ToBase64String(imagenbytes);
            string[] cliente = {nom, ape, dir, dpi, tel1,tel2, prof, Est_civil, Nom_cony, profOt, telcon, refe,edad,gene,depa,muni,profcon,dpicon,nomneg,dirneg,telneg,refneg,tipneg,antiqneg,carga,imagen };
          //  string[] fiador = { fiad, dfiad, tfiad };

          //  if (clien.updatecliente(idcli, cliente))
          if(clien.updateclienteNuevo(idcli,cliente))
            {
                MessageBox.Show("Datos actualizados correctamente", "Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
                TabC3.Parent = null;
            }
            else
            {
                MessageBox.Show("Error al actualizar datos del cliente","Algo salio mal",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
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
                        cliedit = clien.clientebusca(idcli);
                        clirefs = clien.refscli(idcli);
                        TabC3.Parent = tabControl1;
                        tabControl1.SelectedIndex = 2;
                        TxtNom2.Text = cliedit.Rows[0][0].ToString();
                        TxtApe2.Text = cliedit.Rows[0][1].ToString();
                        TxtDir2.Text = cliedit.Rows[0][2].ToString();
                        TxtDpi2.Text = cliedit.Rows[0][3].ToString();
                        TxtTel1Edit.Text = cliedit.Rows[0][4].ToString();
                        TxtTel2Edit.Text = cliedit.Rows[0][5].ToString();
                        TxtProfEdit.Text = cliedit.Rows[0][6].ToString();
                        TxtNomCony2.Text = cliedit.Rows[0][7].ToString();
                     //   TxtApeCony2.Text = cliedit.Rows[0][8].ToString();
                        TxtTelCony2.Text = cliedit.Rows[0][9].ToString();
                        TxtDpiConEdit.Text = cliedit.Rows[0][20].ToString();
                       TxtOProfEdit.Text= cliedit.Rows[0][10].ToString();
                    TxtCargaF.Text= cliedit.Rows[0][17].ToString();
                        TxtProfConyEdit.Text= $"{cliedit.Rows[0][19]}";
                         CboDepaEdit.SelectedValue = clien.idDepaByName($"{cliedit.Rows[0][13]}");
                        CboMunEdit.SelectedValue = clien.idMuniByName($"{cliedit.Rows[0][14]}");
                        TxtCargaFamEdit.Text= $"{cliedit.Rows[0][18]}";
                        TxtNomNegEdit.Text = $"{cliedit.Rows[0][23]}";
                        TxtTelNegEdit.Text = $"{cliedit.Rows[0][24]}";
                        TxtDirNegEdit.Text = $"{cliedit.Rows[0][25]}";
                        TxtRefNegEdit.Text = $"{cliedit.Rows[0][26]}";
                        TxtTipNegEdit.Text= $"{cliedit.Rows[0][27]}";
                        TxtAntiqNegEdit.Text= $"{cliedit.Rows[0][28]}";
                        //  TxtCargaFamEdit.Text=(cliedit.Rows[0][21].ToString());
                        try
                        {
                            byte[] imadpi = (byte[])cliedit.Rows[0][21];

                            // Intentemos convertir los bytes a texto y luego de Base64 a Bytes
                            // Solo si el programador anterior guardó el Base64 puro en el BLOB
                            string base64String =Encoding.UTF8.GetString(imadpi);
                            byte[] realBytes = Convert.FromBase64String(base64String);

                            using (MemoryStream ms = new MemoryStream(realBytes))
                            {
                                PicDpiEdit.Image = new Bitmap(ms);
                            }
                        }
                        catch
                        {
                            // Si lo de arriba falla, es que los bytes originales estaban bien 
                            // pero quizás tienen un encabezado corrupto.
                        }



                        DgvRefEditData.Rows.Clear();
                        for (int i = 0; i < clirefs.Rows.Count; i++)
                        {
                           DgvRefEditData.Rows.Add($"{clirefs.Rows[i][0]}", $"{clirefs.Rows[i][1]}", $"{clirefs.Rows[i][2]}", $"{clirefs.Rows[i][3]}");
                        }

                       // DgvRefsEdit.EditMode = DataGridViewEditMode.EditOnF2;
                        DateTime zeroTime = new DateTime(1, 1, 1);
                        //DateTime fNac = DateTime.Parse($"{cliedit.Rows[0][22]}");
                        //TimeSpan interm= (DateTime.Now - fNac);
                        //NudEdadEdit.Value = (zeroTime - interm).Year-1;

                        if (cliedit.Rows[0][15].ToString().Equals("M"))
                        {
                            CboGeneEdit.SelectedIndex = 0;
                        }
                        else
                        {
                            CboGeneEdit.SelectedIndex = 1;
                        }


                        if (cliedit.Rows[0][11].ToString() == "Soltero")
                        {
                            CboCivEdit.SelectedIndex = 0;
                        }
                        else if (cliedit.Rows[0][11].ToString() == "Casado")
                        {
                            CboCivEdit.SelectedIndex = 1;
                        }
                        else if (cliedit.Rows[0][11].ToString() == "Viudo")
                        {
                            CboCivEdit.SelectedIndex = 2;
                        }
                        //12 edad
                        NudEdadEdit.Value = decimal.Parse(cliedit.Rows[0][12].ToString());
                        //13 departamento
                        //14 municipio
                        //15 genero
                       
                        //16 nacionalidad
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Seleccione un elemento de la lista\n {ex}","Se presento un problema",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                }

            }
        }

        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
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

        private void CboGene_SelectedIndexChanged(object sender, EventArgs e)
        {

            CboScivil.Items.Clear();

            if (CboGene.SelectedIndex == 0)
            {
                CboScivil.Items.Add("Soltero");
                               CboScivil.Items.Add("Casado");
                               CboScivil.Items.Add("Viudo");
                               CboScivil.Sorted = true;
            }
            else
            {
                CboScivil.Items.Add("Soltera");
                               CboScivil.Items.Add("Casada");
                               CboScivil.Items.Add("Viuda");
                               CboScivil.Sorted = true;
            }
           
        }

        private void CboGeneEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            CboCivEdit.Items.Clear();
           

            if (CboGeneEdit.SelectedIndex == 0)
            {
               
                CboCivEdit.Items.Add("Soltero");
                CboCivEdit.Items.Add("Casado");
                CboCivEdit.Items.Add("Viudo");
            //    CboCivEdit.Sorted = true;
            }
            else
            {
                CboCivEdit.Items.Add("Soltera");
                CboCivEdit.Items.Add("Casada");
                CboCivEdit.Items.Add("Viuda");
              //  CboCivEdit.Sorted = true;
            }
        }

        private void BtnAddRef_Click(object sender, EventArgs e)
        {
            // 1. Limpieza de espacios para evitar entradas de solo espacios
            string nombre = TxtNomRef.Text.Trim();
            string parentesco = TxtParentRef.Text.Trim();
            string telefono = TxtTelRef.Text.Trim();

            // 2. Validaciones de campos obligatorios
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(parentesco) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene la ejecución
            }

            // 3. Validación específica para el teléfono (Exactamente 8 caracteres)
            // Nota: Puedes agregar '&& telefono.All(char.IsDigit)' si solo quieres números
            if (telefono.Length != 8)
            {
                MessageBox.Show("El teléfono debe tener exactamente 8 caracteres.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Validación de límite de filas
            if (DgvRefs.Rows.Count < 3)
            {
                DgvRefs.Rows.Add("0", nombre, parentesco, telefono);

                // Opcional: Limpiar los campos después de agregar
                TxtNomRef.Clear();
                TxtParentRef.Clear();
                TxtTelRef.Clear();
                TxtNomRef.Focus();
            }
            else
            {
                MessageBox.Show("No es posible agregar más de 3 referencias", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnDelRef_Click(object sender, EventArgs e)
        {
            if (DgvRefs.CurrentRow != null && !DgvRefs.CurrentRow.IsNewRow)
            {
                // Confirmación opcional para evitar borrados accidentales
                DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar esta referencia?",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    DgvRefs.Rows.RemoveAt(DgvRefs.CurrentRow.Index);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila válida para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cargamunis1()

        {
            if (CboDepaEdit.SelectedValue != null && !CboDepaEdit.SelectedValue.ToString().Equals("Arcoiris.Clases.Modelos.DeparamentoModel"))
            {
                string id = CboDepaEdit.SelectedValue.ToString();
                CboMunEdit.DataSource = clien.Munis(id);
                CboMunEdit.DisplayMember = "Nombre";
                CboMunEdit.ValueMember = "Id";
            }
        }

        private void cargamunis()

        {
            if (CboDepa.SelectedValue != null && !CboDepa.SelectedValue.ToString().Equals("Arcoiris.Clases.Modelos.DeparamentoModel"))
            {
                string id = CboDepa.SelectedValue.ToString();
                CboMuni.DataSource = clien.Munis(id);
                CboMuni.DisplayMember = "Nombre";
                CboMuni.ValueMember = "Id";
            }
        }

        private void CboDepaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargamunis1();
        }

        private void CboDepa_SelectedValueChanged_1(object sender, EventArgs e)
        {
            cargamunis();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private bool updrefes()
        {

            List<string> refes = new List<string>();
            foreach (DataGridViewRow fila in DgvRefEditData.Rows)
            {
                refes.Add($"{fila.Cells[0].Value}");
                refes.Add($"{fila.Cells[1].Value}");
                refes.Add($"{fila.Cells[2].Value}");
                refes.Add($"{fila.Cells[3].Value}");
            }

            return (clien.UpdRefes(refes, idcli));


        }

        private void BtnUpdRefes_Click(object sender, EventArgs e)
        {

            if (updrefes())
            {
                MessageBox.Show("Referencias actualizadas ccorrectamente","Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar los datos de las referencias", "Algo salio mal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void BtnAddRefEdit_Click(object sender, EventArgs e)
        {
            // 1. Limpieza de espacios para evitar entradas de solo espacios
            string nombre = TxtNomRefEdit.Text.Trim();
            string parentesco = TxtParenEdit.Text.Trim();
            string telefono = TxtTelRefEdit.Text.Trim();

            // 2. Validaciones de campos obligatorios
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(parentesco) || string.IsNullOrEmpty(telefono))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Detiene la ejecución
            }

            // 3. Validación específica para el teléfono (Exactamente 8 caracteres)
            // Nota: Puedes agregar '&& telefono.All(char.IsDigit)' si solo quieres números
            if (telefono.Length != 8)
            {
                MessageBox.Show("El teléfono debe tener exactamente 8 caracteres.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Validación de límite de filas
            if (DgvRefEditData.Rows.Count < 3)
            {
               DgvRefEditData.Rows.Add("0", nombre, parentesco, telefono);

                // Opcional: Limpiar los campos después de agregar
                TxtNomRefEdit.Clear();
                TxtParenEdit.Clear();
                TxtTelRefEdit.Clear();
                TxtNomRef.Focus();
            }
            else
            {
                MessageBox.Show("No es posible agregar más de 3 referencias", "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnUpdDpi_Click(object sender, EventArgs e)
        {
            OfdDPI.InitialDirectory = "c:\\";
            OfdDPI.Filter = "JPG|*.jpg;*.jpeg";
            if (OfdDPI.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // MessageBox.Show("Ruta Guardada: " + OFD1.FileName);
                    //PbxProd.Image = Image.FromFile(@"C:\Users\Insane\Pictures\7z6vh4.jpg");
                    PicDPI.Image = Image.FromFile(@"" + OfdDPI.FileName);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            }
        }

        private void BtnDpiImgEdit_Click(object sender, EventArgs e)
        {
            OfdDpiEdit.InitialDirectory = "c:\\";
            OfdDpiEdit.Filter = "JPG|*.jpg;*.jpeg";
            if (OfdDpiEdit.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // MessageBox.Show("Ruta Guardada: " + OFD1.FileName);
                    //PbxProd.Image = Image.FromFile(@"C:\Users\Insane\Pictures\7z6vh4.jpg");
                    PicDpiEdit.Image = Image.FromFile(@"" + OfdDpiEdit.FileName);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.ToString());
                }
            }
        }
    }
}


