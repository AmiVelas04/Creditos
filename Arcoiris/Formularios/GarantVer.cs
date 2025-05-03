using Humanizer;
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
        private string sol { get; set; }
        private DataTable CliGaranDatos = new DataTable();
        DataTable solicitaCre = new DataTable();


        private Clases.Solicitud soli = new Clases.Solicitud();
       

        public GarantVer()
        {
            InitializeComponent();
        }

        private void GarantVer_Load(object sender, EventArgs e)
        {
            TxtCre.Text = idcre;
            buscarGarant();
            if (nivel == "4") {
                BtnDesbloq.Visible = false;
                BtnGuardar.Visible = false;
            }
            else if (nivel == "3")
            {
                BtnGuardar.Visible = true;
                //BtnDesbloq.Visible = false;
            }
            else
            {
                BtnDesbloq.Visible = true;
                BtnGuardar.Visible = true;
            }
            TxtClinom.Text = cliente;
            solicitaCre = soli.solicitud(idcre);
            if (solicitaCre.Rows.Count > 0)
            {
                sol = solicitaCre.Rows[0][0].ToString();
                BtnDataFiad.Enabled = true;
            }
            else
            {
                MessageBox.Show("El Credito no tiene asignado Fiador","Sin fiador",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                sol = "0";
                BtnDataFiad.Enabled = false;
            }

            
        }

        private void buscarGarant()
        {
                CliGaranDatos= soli.garantia(idcre);
           
        }

        private void limpiar()
        {
            TxtCivil.Clear();
            TxtNom.Clear();
            TxtMun.Clear();
            TxtProf.Clear();
            TxtDepa.Clear();
            TxtDir.Clear();
            TxtGen.Clear();
            TxtTel1.Clear();
            TxtTel2.Clear();
        }

        private void Bloquear()
        {
           
        }

        private void Desbloq()
        {
           
            
            
        }

        private void mostrar()
        {
            
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
           
        }

        private void guardar()
        {
           
        }

        private void actuaizar()
        {
            
        }

        private void CboTipGar_SelectedIndexChanged(object sender, EventArgs e)
        {
                            mostrar();
            
                    }

        private void DtpFecha_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void CmdContra_Click(object sender, EventArgs e)
        {
            selectContrato();
        }

        private string LetrasCui(string Cui)
        {
            string Parte1 = int.Parse(Cui.Substring(0,4)).ToWords();
            string Parte2 = int.Parse(Cui.Substring(4, 5)).ToWords();
            string Parte3 = int.Parse(Cui.Substring(9, 4)).ToWords();
            return $"{Parte1} espacio {Parte2} espacio {Parte3}";
        }
        private string separacionCui(string Cui)
        {
            string Parte1 = (Cui.Substring(0, 4));
            string Parte2 = (Cui.Substring(4, 5));
            string Parte3 = (Cui.Substring(9, 4));
            return $"{Parte1} {Parte2} {Parte3}";
        }

        private void selectContrato()
        {
            DataTable datoscli = soli.Clibycred(idcre);
            DataTable datoscred = soli.CreditoOne(idcre);
            DataTable datosSoli = soli.SolibyCredi(idcre);
            List<Reportes.Contratos.ContratoDatos> Valores = new List<Reportes.Contratos.ContratoDatos>();
            //Solo Deudor, Si firma, sin Garantia
            if (datoscred.Rows.Count <= 0) {
                this.Close();
            }
            int ente=0, deci=0;
            decimal intere = decimal.Parse(datoscred.Rows[0][4].ToString());
            deci = Convert.ToInt32((intere % 1) * 100);
            ente = int.Parse( Math.Truncate(intere).ToString());
            DateTime fech = DateTime.Now; // DateTime.Parse(datoscred.Rows[0][10].ToString());
            if (CliGaranDatos.Rows[0][9].ToString().Equals("1"))
            {
                string Plazo = "";
                Reportes.Contratos.Contrato_1 Contrato = new Reportes.Contratos.Contrato_1();
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(separacionCui(datoscli.Rows[0][7].ToString()))}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                Temp.FechaContrato = fech;
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                //Temp.PlazoLet = ;
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                if (deci > 0)
                {
                    Temp.PorcentLet = $"{ente.ToWords()} punto {deci.ToWords()}";
                }
                else
                {
                    Temp.PorcentLet = $"{ente.ToWords()}" ;
                }
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Valores.Add(Temp);
                Contrato.datos = Valores;
                Contrato.Show();
            }
            //Solo Deudor, Si firma, con Garantia
            if (CliGaranDatos.Rows[0][9].ToString().Equals("2"))
            {
                string Plazo = "";
                Reportes.Contratos.Contrato_2 Contrato = new Reportes.Contratos.Contrato_2();
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.FechaContrato = fech;
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(separacionCui(datoscli.Rows[0][7].ToString()))}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                if (deci > 0)
                {
                    Temp.PorcentLet = $"{ente.ToWords()} punto {deci.ToWords()}";
                }
                else
                {
                    Temp.PorcentLet = $"{ente.ToWords()}";
                }
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Valores.Add(Temp);
                Contrato.datos = Valores;
                Contrato.Show();
            }
            //Solo Deudor, No firma, con Garantia
            if (CliGaranDatos.Rows[0][9].ToString().Equals("3"))
            {
                string Plazo = "";
                Reportes.Contratos.Contrato_3 Contrato = new Reportes.Contratos.Contrato_3();
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.FechaContrato = fech;
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(datoscli.Rows[0][7].ToString())}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                if (deci > 0)
                {
                    Temp.PorcentLet = $"{ente.ToWords()} punto {deci.ToWords()}";
                }
                else
                {
                    Temp.PorcentLet = $"{ente.ToWords()}";
                }
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Valores.Add(Temp);
                Contrato.datos = Valores;
                Contrato.Show();
            }
            //Deudor y Fiador, Si firma, sin Garantia
            if (CliGaranDatos.Rows[0][9].ToString().Equals("4"))
            {
                string Plazo = "";
                Reportes.Contratos.Contrato_4 Contrato = new Reportes.Contratos.Contrato_4();
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                Temp.FechaContrato = fech;
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(datoscli.Rows[0][7].ToString())}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                if (deci > 0)
                {
                    Temp.PorcentLet = $"{ente.ToWords()} punto {deci.ToWords()}";
                }
                else
                {
                    Temp.PorcentLet = $"{ente.ToWords()}";
                }
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Temp.NomFiador = $"{CliGaranDatos.Rows[0][9]}";
                Temp.CuiFiador = $"{CliGaranDatos.Rows[0][10]}";
                Temp.CuiLFiador = LetrasCui($"{CliGaranDatos.Rows[0][10]}");
                Temp.MuniFiador = $"{CliGaranDatos.Rows[0][12]}";
                Temp.DeparFiador = $"{CliGaranDatos.Rows[0][13]}";
                Temp.FiadorDomi = $"{CliGaranDatos.Rows[0][14]}";
                int edadFiad = int.Parse($"{CliGaranDatos.Rows[0][10]}");
                Temp.EdadFiador = $"{CliGaranDatos.Rows[0][16]}";
                Temp.EstCivFiador = $"{CliGaranDatos.Rows[0][17]}";
                Temp.EdadLFiador = edadFiad.ToWords();

                Valores.Add(Temp);
                Contrato.datos = Valores;
                Contrato.Show();
            }
            //Deudor y Fiador, Si firma, Garantia del deudor
            if (CliGaranDatos.Rows[0][9].ToString().Equals("5"))
            {
                string Plazo = "";
                Reportes.Contratos.Contrato_4 Contrato = new Reportes.Contratos.Contrato_4();
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.FechaContrato = fech;
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(datoscli.Rows[0][7].ToString())}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                if (deci > 0)
                {
                    Temp.PorcentLet = $"{ente.ToWords()} punto {deci.ToWords()}";
                }
                else
                {
                    Temp.PorcentLet = $"{ente.ToWords()}";
                }
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Valores.Add(Temp);
                Contrato.datos = Valores;
                Contrato.Show();
            }
            //Deudor y Fiador, Si firma, Garantia del fiador
            if (CliGaranDatos.Rows[0][9].ToString().Equals("6"))
            {
                string Plazo = "";
                Reportes.Contratos.Contrato_6 Contrato = new Reportes.Contratos.Contrato_6();
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.FechaContrato = fech;
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(datoscli.Rows[0][7].ToString())}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                if (deci > 0)
                {
                    Temp.PorcentLet = $"{ente.ToWords()} punto {deci.ToWords()}";
                }
                else
                {
                    Temp.PorcentLet = $"{ente.ToWords()}";
                }
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Valores.Add(Temp);
                Contrato.datos = Valores;
                Contrato.Show();
            }
            //Deudor y Fiador, Fiador no firma, sin Garantia
            if (CliGaranDatos.Rows[0][9].ToString().Equals("7"))
            {
                string Plazo = "";
                Reportes.Contratos.Contrato_4 Contrato = new Reportes.Contratos.Contrato_4();
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                Temp.FechaContrato = fech;
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(datoscli.Rows[0][7].ToString())}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                if (deci > 0)
                {
                    Temp.PorcentLet = $"{ente.ToWords()} punto {deci.ToWords()}";
                }
                else
                {
                    Temp.PorcentLet = $"{ente.ToWords()}";
                }
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Temp.NomFiador = $"{CliGaranDatos.Rows[0][10]}";
                Temp.CuiFiador = $"{CliGaranDatos.Rows[0][11]}";
                Temp.CuiLFiador = LetrasCui($"{CliGaranDatos.Rows[0][11]}");
                Temp.MuniFiador = $"{CliGaranDatos.Rows[0][13]}";
                Temp.DeparFiador = $"{CliGaranDatos.Rows[0][14]}";
                Temp.FiadorDomi = $"{CliGaranDatos.Rows[0][15]}";
                int edadFiad = int.Parse($"{CliGaranDatos.Rows[0][17]}");
                Temp.EdadFiador = $"{CliGaranDatos.Rows[0][17]}";
                Temp.EstCivFiador = $"{CliGaranDatos.Rows[0][18]}";
                Temp.EdadLFiador = edadFiad.ToWords();
                Temp.NacioFiador = "Guatemalteco";
                Temp.ProfFiador = "Trabajador";
                Valores.Add(Temp);
                Contrato.datos = Valores;
                Contrato.Show();
            }
            //Deudor y Fiador, Fiador no firma, Garantia del Fiador
            if (CliGaranDatos.Rows[0][9].ToString().Equals("8"))
            {
                string Plazo = "";
                Reportes.Contratos.Contrato_8 Contrato = new Reportes.Contratos.Contrato_8();
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.FechaContrato = fech;
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(datoscli.Rows[0][7].ToString())}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                if (deci > 0)
                {
                    Temp.PorcentLet = $"{ente.ToWords()} punto {deci.ToWords()}";
                }
                else
                {
                    Temp.PorcentLet = $"{ente.ToWords()}";
                }
                // Temp.PorcentLet= int.Parse().ToWords();
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Valores.Add(Temp);
                Contrato.datos = Valores;
                Contrato.Show();
            }
            //Deudor y Fiador, Fiador no firma, Garantia del Deudor
            if (CliGaranDatos.Rows[0][9].ToString().Equals("9"))
            {
                string Plazo = "";
                Reportes.Contratos.Contrato_9 Contrato = new Reportes.Contratos.Contrato_9();
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.FechaContrato = fech;
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(datoscli.Rows[0][7].ToString())}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                // Temp.PorcentLet= int.Parse().ToWords();
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Valores.Add(Temp);
                Contrato.datos = Valores;
                Contrato.Show();
            }
            //Deudor y Fiador,Deudor y Fiador no firman, Sin garantia
            if (CliGaranDatos.Rows[0][9].ToString().Equals("10"))
            {
                string Plazo = "";
                Reportes.Contratos.Contrato_10 Contrato = new Reportes.Contratos.Contrato_10();
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                Temp.FechaContrato = fech;
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(datoscli.Rows[0][7].ToString())}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                // Temp.PorcentLet= int.Parse().ToWords();
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Valores.Add(Temp);
                Contrato.datos = Valores;
                Contrato.Show();
            }
            //Deudor y Fiador,Deudor y Fiador no firman, Garantia Deudor
            if (CliGaranDatos.Rows[0][9].ToString().Equals("11"))
            {
                string Plazo = "";
                Reportes.Contratos.Contrato_11 Contrato = new Reportes.Contratos.Contrato_11();
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.FechaContrato = fech;
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(datoscli.Rows[0][7].ToString())}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                // Temp.PorcentLet= int.Parse().ToWords();
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Valores.Add(Temp);
                Contrato.datos = Valores;
                Contrato.Show();
            }
            //Deudor y Fiador,Deudor y Fiador no firman, Sin garantia(Pendiente)
            if (CliGaranDatos.Rows[0][9].ToString().Equals("12"))
            {
                string Plazo = "";
                Reportes.Contratos.Contrato_12 Contrato = new Reportes.Contratos.Contrato_12();
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                Temp.FechaContrato = fech;
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(datoscli.Rows[0][7].ToString())}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                // Temp.PorcentLet= int.Parse().ToWords();
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Valores.Add(Temp);
                Contrato.datos = Valores;
                Contrato.Show();
            }
            //Deudor y Fiador,Deudor y Fiador no firman, Sin garantia(Pendiente)
            if (CliGaranDatos.Rows[0][9].ToString().Equals("13"))
            {
                string Plazo = "";
                if (datoscred.Rows[0][2].ToString().Equals("1") || datoscred.Rows[0][2].ToString().Equals("2"))
                { Plazo = "diario"; }
                else
                { Plazo = "mensual"; }
                decimal porcent = decimal.Parse($"{datoscred.Rows[0][4]}");
                Reportes.Contratos.ContratoDatos Temp = new Reportes.Contratos.ContratoDatos();
                string canti = datoscred.Rows[0][2].ToString();
                Temp.FechaContrato = fech;
                canti = canti.Remove(canti.Length - 3, 3);
                Temp.Deudor = $"{datoscli.Rows[0][0]} {datoscli.Rows[0][1]}";
                Temp.Departamento = $"{datoscli.Rows[0][2]}";
                Temp.Municipio = $"{datoscli.Rows[0][3]}";
                Temp.Direccion = $"{datoscli.Rows[0][4]}";
                Temp.EdadDeudor = $"{datoscli.Rows[0][5]}";
                Temp.EdadLDeudor = int.Parse(datoscli.Rows[0][5].ToString()).ToWords();
                Temp.Cantidad = $"{datoscred.Rows[0][2]}";
                Temp.CantidadLet = int.Parse(canti).ToWords();
                Temp.CuiLDeudor = LetrasCui($"{datoscli.Rows[0][7]}");
                Temp.CuiDeudor = $"{separacionCui(datoscli.Rows[0][7].ToString())}";
                Temp.Acreedor = "Diego Salomón Brito Pérez";
                Temp.PagosLet = int.Parse(datoscred.Rows[0][3].ToString()).ToWords();
                if (Plazo.Equals("diario"))
                { Temp.PlazoLet = $"{Temp.PagosLet} dias"; }
                else
                {
                    Temp.PlazoLet = $"{Temp.PagosLet} meses";
                }
                Temp.Periodo = Plazo;
                Temp.Porcent = $"{datoscred.Rows[0][4]}";
                // Temp.PorcentLet= int.Parse().ToWords();
                Temp.EstCivil = $"{datoscli.Rows[0][8]}";
                Temp.Profesion = $"{datoscli.Rows[0][9]}";
                Temp.Nacionalidad = $"{datoscli.Rows[0][10]}";
                Valores.Add(Temp);
            }
            else
            { }
        }

        private void BtnDataFiad_Click(object sender, EventArgs e)
        {
            PanDatos.Visible = true;
            limpiar();
            DataTable datos = soli.BuscaFiadPorSol(sol);
            TxtNom.Text = $"{datos.Rows[0][0]} {datos.Rows[0][1]}";
            TxtMun.Text = $"{datos.Rows[0][2]}";
            TxtDepa.Text= $"{datos.Rows[0][3]}";
            TxtDir.Text = $"{datos.Rows[0][4]}"; 
            TxtCivil.Text= $"{datos.Rows[0][5]}";
            TxtProf.Text = $"{datos.Rows[0][6]}";
            TxtTel1.Text = $"{datos.Rows[0][7]}";
            TxtTel2.Text = $"{datos.Rows[0][8]}";
            
            if (datos.Rows[0][9].ToString().Equals("M"))
            { TxtGen.Text = "Masculino"; }
            else
            { TxtGen.Text = "Femenino"; }
        }


        

    }
}
