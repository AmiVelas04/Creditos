﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Arcoiris
{
    
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Clases .conexion  estado = new Clases.conexion ();
            // MessageBox.Show(estado .probar_conn ());
            Tmr1.Enabled = true;

        }

        private void Tmr1_Tick(object sender, EventArgs e)
        {
            Tmr1.Enabled = false;
            Formularios.Main principal = new Formularios.Main();
            principal.Show();
            this.Hide();
        }
    }
}
