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
    public partial class GarantVer : Form
    {

        public string cliente { get; set; }
        public string idcre { get; set; }
        public string nivel { get; set; }


        private Clases.Solicitud soli = new Clases.Solicitud();
       

        public GarantVer()
        {
            InitializeComponent();
        }

        private void GarantVer_Load(object sender, EventArgs e)
        {
            TxtCli.Text = cliente;
            TxtCre.Text = idcre;
            buscarGarant();
            if (nivel == "4" ) {
                BtnDesbloq.Visible = false;
                BtnGuardar.Visible = false;
            }
            else if (nivel == "3")
            {
                BtnGuardar.Visible = true;
                BtnDesbloq.Visible = false;
            }
            else
            {
                BtnDesbloq.Visible = true;
                BtnGuardar.Visible = true;
            }

            

        }

        private void buscarGarant()
        {
                    DataTable datos= soli.garantia(idcre);
            if (datos.Rows.Count > 0)
            {
                var tipo = datos.Rows[0][1].ToString();
                if (tipo.Equals("Prendaria"))
                {
                    CboTipGar.SelectedIndex = 0;
                }
                else if (tipo.Equals("Hipotecária"))
                {
                    CboTipGar.SelectedIndex = 1;
                }
                else if (tipo.Equals("Vehiculos"))

                {
                    CboTipGar.SelectedIndex = 2;
                }
                else if (tipo.Equals("Fiduciaria"))
                {
                    CboTipGar.SelectedIndex = 3;
                }
                else
                {
                    CboTipGar.Visible = false;
                    label3.Visible = false;
                }
                TxtValu.Text = datos.Rows[0][2].ToString();
                TxtGarDet.Text = datos.Rows[0][3].ToString();
                TxtTipEsc.Text = datos.Rows[0][4].ToString();
                TxtFEsc.Text = datos.Rows[0][5].ToString();
                TxtAut.Text = datos.Rows[0][6].ToString();
                TxtUbi.Text = datos.Rows[0][7].ToString();
                TxtEstado.Text = datos.Rows[0][8].ToString();
                LblGarant.Text = datos.Rows[0][0].ToString();
                mostrar();
            }
            else
            {
                BtnGuardar.Visible = false;
            }
        }

        private void limpiar()
        { }

        private void Bloquear()
        {
            label6.Enabled = false;
            label7.Enabled = false;
            label8.Enabled = false;
            TxtTipEsc.Enabled = false;
            TxtUbi.Enabled = false;
            TxtFEsc.Enabled = false;
            BtnGuardar.Enabled = false;
            label9.Enabled = false;
            TxtAut.Enabled = false;
            CboTipGar.Enabled = false;
            TxtGarDet.Enabled = false;
            TxtValu.Enabled = false;
        }

        private void Desbloq()
        {
            label6.Enabled = true;
            label7.Enabled = true;
            label8.Enabled = true;
            TxtTipEsc.Enabled = true;
            TxtUbi.Enabled = true;
            TxtFEsc.Enabled = true;
            BtnGuardar.Enabled = true;
            label9.Enabled = true;
            TxtAut.Enabled = true;
            CboTipGar.Enabled = true;
            TxtGarDet.Enabled = true;
            TxtValu.Enabled = true;
           
            
            
        }

        private void mostrar()
        {
            if (CboTipGar.SelectedIndex == 1)
            {
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                TxtTipEsc.Visible = true;
                TxtUbi.Visible = true;
                TxtFEsc.Visible = true;
                BtnGuardar.Visible = true;
                label9.Visible = true;
                TxtAut.Visible = true;
                DtpFecha.Visible = true;
                ChkChanFecha.Visible = true;
              //  BtnGuardar.Visible = true;
            }
            else
            {
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                TxtTipEsc.Visible = false;
                TxtUbi.Visible = false;
                TxtFEsc.Visible = false;
                label9.Visible = false;
                TxtAut.Visible = false;
                DtpFecha.Visible = false;
                ChkChanFecha.Visible = false;
              //  BtnGuardar.Visible = false;
                TxtAut.Text = "N/E";
                TxtFEsc.Text = DateTime.Now.ToString("dd/MM/yyyy");
                TxtTipEsc.Text = "N/E";
            }
        }

        private void ocultar()
        {
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible =  false;
            TxtTipEsc.Visible = false;
            TxtUbi.Visible = false;
            TxtFEsc.Visible = false;
            BtnGuardar.Visible = false;
            label9.Visible = false;
            TxtAut.Visible = false;
            DtpFecha.Visible = false;
        }

        private void GarantVer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                if (Form1.Cod_U == "1" || Form1.Cod_U == "2")
                {
                    MessageBox.Show("Elementos activados", "Administrador", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Desbloq();
                }
                else
                {
                    Bloquear();

                }
            }
        }

        private void BtnDesbloq_Click(object sender, EventArgs e)
        {
            Desbloq();
            mostrar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (LblGarant.Text == "0")
            {
                guardar();
            }
            else
            {
                actuaizar();
            }
        }

        private void guardar()
        {
            string tipo = CboTipGar.Text, valu = TxtValu.Text, deta = TxtGarDet.Text, TipEsc = TxtTipEsc.Text, FecEsc = TxtFEsc.Text, Aut = TxtAut.Text, Ubi = TxtUbi.Text;
            string solici= soli.idsolXcred(TxtCre.Text), Estado= CboEstado.Text;
            if (Estado.Equals("Entregado"))
                Estado = Estado + " " + DateTime.Now.ToString("dd/MM/yyyy");
            string[] valo = new string[10];
            valo[0] = tipo;
            valo[1] = valu;
            valo[2] = deta;
            valo[3] = TipEsc;
            valo[4] = FecEsc;
            valo[5] = Aut;
            valo[6] = valu;
            valo[7] = Ubi;
            valo[8] = Estado;
            valo[9] = solici;
            
            if (soli.ingre_garant(valo))
            {
                MessageBox.Show("Garantia ingresada correctamente","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo ingresar garantia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void actuaizar()
        {
            string tipo = CboTipGar.Text, valu = TxtValu.Text, deta = TxtGarDet.Text, TipEsc = TxtTipEsc.Text, FecEsc = TxtFEsc.Text, Aut = TxtAut.Text, Ubi = TxtUbi.Text;
            string solici = soli.idsolXcred(TxtCre.Text);
            string Estado=CboEstado.Text;
            string[] valo = new string[9];
            if (CboEstado.Text=="Entregado") Estado = Estado + " " + DateTime.Now.ToString("dd/MM/yyyy");
            valo[0] = LblGarant.Text;
            valo[1] = tipo;
            valo[2] = valu;
            valo[3] = deta;
            valo[4] = TipEsc;
            valo[5] = FecEsc;
            valo[6] = Aut;
            valo[7] = Ubi;
            valo[8] = Estado;
            if (soli.updgarantia(valo))
            {
                MessageBox.Show("Garantia actualizada correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo actualizar garantia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void CboTipGar_SelectedIndexChanged(object sender, EventArgs e)
        {
                            mostrar();
            
                    }

        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (ChkChanFecha.Checked)            TxtFEsc.Text = DtpFecha.Value.ToString("dd/MM/yyyy");
        }
    }
}
