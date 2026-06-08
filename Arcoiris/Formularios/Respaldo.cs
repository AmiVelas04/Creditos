using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Arcoiris.Formularios
{
    public partial class Respaldo : Form
    {
        FolderBrowserDialog carpeta = new FolderBrowserDialog();
        Clases.conexion conect = new Clases.conexion();
        string MiFecha =DateTime .Now.ToString("dd-MM-yyyy");
        string rutaDump = "C:\\xampp\\mysql\bin\\mysqldump";
        string destino;
        public Respaldo()
        {
            InitializeComponent();
        }

        private void BtnCarpeta_Click(object sender, EventArgs e)
        {

            carpeta.RootFolder = Environment.SpecialFolder.Desktop;
            carpeta.Description = "Seleccione la ruta para realizar el respaldo";
            carpeta.ShowNewFolderButton = false;

            string miCarpeta;
            if (carpeta.ShowDialog()==DialogResult.OK){
                TxtRuta.Text = carpeta.SelectedPath;
            miCarpeta =  carpeta.SelectedPath;
              //miCarpeta =  miCarpeta .Replace("'\'","\\");

            destino = miCarpeta.Trim() +"\\RespaldoBd_" + MiFecha + ".sql";
        }
        }
        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TxtRuta.Text != "")
            {
                // Deshabilitar el botón y mostrar loader
                BtnGuardar.Enabled = false;
                BtnGuardar.Text = "Respaldo en progreso...";
                ShowLoader(true);

                // Esperar a que termine el respaldo
                await respaldo(); // Asegúrate de esperar aquí

                // Habilitar el botón y ocultar loader
                ShowLoader(false);
                BtnGuardar.Enabled = true;
                BtnGuardar.Text = "Guardar";
            }
            else
            {
                MessageBox.Show("Ruta no encontrada");
            }
        }

        // Cambiar de async void a async Task
        private async Task respaldo()
        {
            try
            {
                // Ejecutar toda la operación de respaldo en un Task
                await Task.Run(() =>
                {
                    MySqlCommand com = new MySqlCommand();
                    conect.iniciar();
                    com.Connection = conect.conn;
                    MySqlBackup respaldo = new MySqlBackup(com);

                    conect.conn.Open();
                    respaldo.ExportToFile(destino);
                    conect.conn.Close();
                });

                // Mostrar mensaje de éxito (esto ya está en el hilo UI)
                MessageBox.Show("El respaldo se ha realizado con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TxtRuta.Clear();
            }
            catch (Exception ex)
            {
                conect.conn.Close();
                MessageBox.Show(ex.ToString());
                TxtRuta.Clear();
            }
        }

        private void ShowLoader(bool mostrar)
        {
            // Si tienes un ProgressBar o un Panel con un GIF
            if (PgbSave != null)
            {
                PgbSave.Visible = mostrar;
                if (mostrar)
                    PgbSave.Style = ProgressBarStyle.Marquee;
            }

          
        }
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Respaldo_Load(object sender, EventArgs e)
        {
            //Clases.Estilos.StyleForm(this);
            Clases.Estilos.StyleDangerButton(BtnCerrar);
            Clases.Estilos.StylePrimaryButton(BtnGuardar);
            Clases.Estilos.StyleSecondaryButton(BtnCarpeta);
        }
    }
}

