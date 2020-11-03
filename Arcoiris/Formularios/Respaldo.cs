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

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (TxtRuta.Text != "")
            {
                respaldo();
            }
            else
            {
                MessageBox.Show("Ruta no encontrada");
            }
          
        }

        private void respaldo()
        {
            try
            {
                string cadena;
                cadena = "cmd.exe /k " + rutaDump + " -h 192.168.1.103 -u prueba -p1532  prod > " + destino;

                MySqlCommand com = new MySqlCommand();
                conect.iniciar();
                com.Connection = conect.conn;
                MySqlBackup respaldo = new MySqlBackup(com);
                // MessageBox.Show(cadena)
                //   Shell(cadena, 0);
                conect.conn.Open();
                respaldo.ExportToFile(destino);
                conect.conn.Close();

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

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

