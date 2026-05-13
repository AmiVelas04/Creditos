using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arcoiris.Clases
{
    class Inversion
    {
        private Clases.conexion conect = new Clases.conexion();
        CultureInfo provider = CultureInfo.InstalledUICulture;
        #region "General"
        private DataTable buscar(string consulta)
        {
            conect.iniciar();
            DataTable datos = new DataTable();
            try
            {

                MySqlDataAdapter adap = new MySqlDataAdapter(consulta, conect.conn);
                adap.Fill(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
            }
            return datos;


        }


        private bool consulta_gen(string consulta)
        {
            conect.iniciar();
            MySqlCommand com1 = new MySqlCommand();
            com1.Connection = conect.conn;
            com1.CommandText = consulta;
            com1.CommandType = CommandType.Text;
            try
            {
                conect.conn.Open();
                com1.ExecuteNonQuery();
                conect.conn.Close();
            }

            catch (Exception ex)
            {
                conect.conn.Close();
                MessageBox.Show(ex.ToString());
                MessageBox.Show(consulta);
                return false;
            }
            return true;
        }

        #endregion

        #region Datos Inversion
        public int id_Inv(string idsol)
        {
            string consulta;
            consulta = "SELECT cre.Cod_credito from credito cre " +
                "inner join asigna_credito ac on ac.COD_CREDITO = cre.COD_CREDITO " +
                "inner join solicitud sol on sol.ID_SOLICITUD = ac.ID_SOLICITUD " +
                "where sol.ID_SOLICITUD =" + idsol;
            DataTable datos = new DataTable();
            try
            {
                datos = buscar(consulta);
                return Convert.ToInt32(datos.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }

        }

        public int id_InvAct()
        {
            string consulta;
            consulta = "SELECT MAX(id_inv) FROM retiros";
            DataTable datos = new DataTable();
            try
            {
                datos = buscar(consulta);
                return Convert.ToInt32(datos.Rows[0][0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return 0;
            }

        }
        //retorna el detalle de los creditos
        public DataTable detalle_Inv(string Inv)
        {
            string consulta;
            consulta = $"Select Id_inv,Monto,Plazo, interes, Date_Format(FechaIn,'%d/%m/%Y') as Fi,Date_Format(FechaFin,'%d/%m/%Y') as FF,Estado,Incentivo,Origen,Regalo from Inversion where id_inv={Inv}";
            DataTable datos = new DataTable();
            return buscar(consulta);
        }

        public DataTable InverByCli(string Cli)
        {
            string consulta;
            consulta = "SELECT Inv.id_inv,Inv.Monto,Inv.Interes,Inv.Plazo,Inv.FechaIn,Inv.FechaFin,Inv.Estado,Inv.Incentivo,cli.dpi " +
                          "FROM Inversion Inv " +
                          "INNER JOIN asigna_Inversion AInv  ON AInv.Id_Inv = Inv.Id_Inv " +
                          "INNER JOIN cliente cli ON cli.CODIGO_CLI = AInv.codigo_cli " +
                           $"WHERE cli.CODIGO_CLI={Cli} and Inv.Estado='Activo' " +
                          "ORDER BY Inv.id_inv,Inv.Monto,Inv.Interes,Inv.Plazo,Inv.FechaIn,Inv.FechaFin,Inv.Estado,Inv.Incentivo,cli.dpi asc";
            DataTable datos = new DataTable();
            return buscar(consulta);
        }

        public DataTable InverByCliRet(string Cli)
        {
            string consulta;
            consulta = "SELECT Inv.id_inv,Inv.Monto,Inv.Interes,Inv.Plazo,Inv.FechaIn,Inv.FechaFin,Inv.Estado,Inv.Incentivo,cli.dpi " +
                          "FROM Inversion Inv " +
                          "INNER JOIN asigna_Inversion AInv  ON AInv.Id_Inv = Inv.Id_Inv " +
                          "INNER JOIN cliente cli ON cli.CODIGO_CLI = AInv.codigo_cli " +
                           $"WHERE cli.CODIGO_CLI={Cli} and Inv.Estado='Retirado' " +
                          "ORDER BY Inv.id_inv,Inv.Monto,Inv.Interes,Inv.Plazo,Inv.FechaIn,Inv.FechaFin,Inv.Estado,Inv.Incentivo,cli.dpi asc";
            DataTable datos = new DataTable();
            return buscar(consulta);
        }


        public DataTable InverByDPI(string DPI)
        {
            string consulta;
            consulta = "SELECT Inv.id_inv,Inv.Monto,Inv.Interes,Inv.Plazo,Inv.FechaIn,Inv.FechaFin,Inv.Estado,Inv.Incentivo,Concat(Cli.Nombres,' ',Cli.APELLIDOS) AS Nom " +
                          "FROM Inversion Inv " +
                          "INNER JOIN asigna_Inversion AInv  ON AInv.Id_Inv = Inv.Id_Inv " +
                          "INNER JOIN cliente cli ON cli.CODIGO_CLI = AInv.codigo_cli " +
                           $"WHERE cli.DPI={DPI} and Inv.Estado='Activo' " +
                          "ORDER BY Inv.id_inv,Inv.Monto,Inv.Interes,Inv.Plazo,Inv.FechaIn,Inv.FechaFin,Inv.Estado,Inv.Incentivo asc";
            DataTable datos = new DataTable();
            return buscar(consulta);
        }


        public DataTable InverByAseso(string Aseso)
        {
            string consulta;
            consulta = "SELECT Inv.id_inv,Inv.Monto,Inv.Interes,Inv.Plazo,Inv.FechaIn,Inv.FechaFin,Inv.Estado,Inv.Incentivo " +
                          "FROM Inversion Inv " +
                          "INNER JOIN asigna_Inversion AInv  ON AInv.Id_Inv = Inv.Id_Inv " +
                          "INNER JOIN Asesor ase  ON ase.COD_ASESOR = AInv.Cod_Asesor " +
                           $"WHERE ase.COD_ASESOR={Aseso} and Inv.Estado='Activo' " +
                          "ORDER BY Inv.id_inv,Inv.Monto,Inv.Interes,Inv.Plazo,Inv.FechaIn,Inv.FechaFin,Inv.Estado,Inv.Incentivo asc";
            DataTable datos = new DataTable();
            return buscar(consulta);
        }


        public DataTable verfechasInv(string Inv)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = $"Select FechaIn,FechaFin from Inversion where Id_Inv={Inv}";
            datos = buscar(consulta);
            return datos;

        }

        private decimal GanaciasGeneradas()
        {
            return 0M;
        }

        public DataTable AsesoAndBenefByinv(string Inv)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = $"SELECT Ase.Nombre,Concat(Cli.Nombres,' ',Cli.APELLIDOS) AS Identificacion " +
                    "FROM asesor Ase " +
                    "INNER JOIN asigna_inversion ainv ON ainv.Cod_Asesor = Ase.COD_ASESOR " +
                    "INNER JOIN benefiinver beni ON beni.Id_Inv = ainv.Id_Inv " +
                    "INNER JOIN cliente Cli ON Cli.CODIGO_CLI = beni.Id_Benef " +
                    $"WHERE ainv.Id_Inv = {Inv}";
            datos = buscar(consulta);
            return datos;
        }

        public DataTable ReferenciaInversion(string Inv)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = $"SELECT Id_inv,Codigo_cli,Cod_asesor,Cod_tutor from asigna_inversion where id_inv={Inv} ";
            datos = buscar(consulta);
            return datos;
        }



        public DataTable AllDatosBenefByInv(string Inv)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = $"SELECT Ase.Nombre,Concat(Cli.Nombres,' ',Cli.APELLIDOS) AS Identificacion, Telefono1, telefono2 " +
                    "FROM asesor Ase " +
                    "INNER JOIN asigna_inversion ainv ON ainv.Cod_Asesor = Ase.COD_ASESOR " +
                    "INNER JOIN benefiinver beni ON beni.Id_Inv = ainv.Id_Inv " +
                    "INNER JOIN cliente Cli ON Cli.CODIGO_CLI = beni.Id_Benef " +
                    $"WHERE ainv.Id_Inv = {Inv}";
            datos = buscar(consulta);
            return datos;
        }

        public DataTable DatosComprobante(string Inv)
        {
            DataTable datos = new DataTable();
            string consulta = "SELECT Inv.Id_Inv,CONCAT(cli.NOMBRES,' ', cli.APELLIDOS) AS cliente,cli.DOMICILIO,cli.TELEFONO1,CONCAT(benef.NOMBRES, ' ', benef.APELLIDOS) AS beneficiario, "+
                              "Inv.Plazo,Inv.Interes, Inv.Monto, date_format(Inv.FechaIn,'%Y/%m/%d') as fechai, date_format(Inv.FechaFin,'%Y/%m/%d') as fechav,cli.dpi FROM inversion Inv " +
                              "INNER JOIN benefiinver binv ON Inv.Id_Inv = binv.Id_Inv "+
                              "INNER JOIN cliente cli ON cli.CODIGO_CLI = binv.Codigo_Cli "+
                              "INNER JOIN cliente benef ON benef.CODIGO_CLI = binv.Id_Benef "+
                              $"WHERE Inv.Id_Inv ={Inv} ";
            datos = buscar(consulta);
            return datos;
        }


        private void imprimirCompro(string inv)
        {
            Reportes.InversionComDeta temp = new Reportes.InversionComDeta();
            DataTable recibe= DatosComprobante(inv);
            for (int i = 0; i < recibe.Rows.Count; i++)
            {
                temp.Agencia = "Arcoiris 1";
                temp.Inv =int.Parse($"{recibe.Rows[0][0]}");
                temp.Cliente = $"{recibe.Rows[0][1]}";
                temp.Direccion = $"{recibe.Rows[0][2]}";
                temp.Tel = $"{recibe.Rows[0][3]}";
                temp.Beneficiario = $"{recibe.Rows[0][4]}";
                temp.Plazo = int.Parse($"{recibe.Rows[0][5]}");
                temp.Tasa= decimal.Parse($"{recibe.Rows[0][6]}");
                temp.Capital = decimal.Parse($"{recibe.Rows[0][7]}");
                temp.Interes = temp.Capital * temp.Tasa / 12 * temp.Plazo;
                temp.Recibe = temp.Capital + temp.Interes;
                temp.Ingreso = DateTime.Parse($"{recibe.Rows[0][8]}");
                temp.Vencimiento = DateTime.Parse($"{recibe.Rows[0][9]}");
                temp.DPI = $"{recibe.Rows[0][10]}";
            }
            Reportes.InversionCompro nuevo = new Reportes.InversionCompro();
            nuevo.datos.Add(temp);
            nuevo.ShowDialog();

        }

        #endregion

        #region Generar
        public bool crear_Inv(string[] datos)
        {
            string consultaid;
            consultaid = "Select count(*) from Inversion";
            DataTable Inver = new DataTable();
            Inver = buscar(consultaid);
            int idInv = 0;
            if (Inver.Rows.Count > 0)
            { idInv = Convert.ToInt32(Inver.Rows[0][0]) + 1; }
            else { idInv = 1; }
            // posicion 8 es cliente, posicion 9 es asesor, posicion 10 es beneficiario
            string consultaingInv;
            consultaingInv = "insert into Inversion(id_inv,Monto,Interes,Plazo,FechaIn,FechaFin,Estado,Incentivo,Origen) " +
                $"values({idInv},{datos[0]},{datos[1]},{datos[2]},'{datos[3]}','{datos[4]}','{datos[5]}',{datos[6]},'{datos[7]}')";
            if (consulta_gen(consultaingInv))
            {
                if ((AsignaAsesoInv(idInv.ToString(), datos[8], datos[9], datos[10])) && (AsignaBenef(idInv.ToString(), datos[8], datos[10])))
                {
                    imprimirCompro($"{idInv}");
                    return true; }
                else
                {
                    return false;
                }

            }
            else
            { return false; }
        }

        private bool AsignaAsesoInv(string inv, string cli, string aseso, string tutor)
        {
            string consulAsesoInv = "insert into Asigna_Inversion(id_inv,Codigo_Cli,Cod_Asesor, cod_tutor) " +
    $"values({inv},{cli},{aseso},{tutor})";
            return consulta_gen(consulAsesoInv);
        }

        private bool AsignaBenef(string inv, string cli, string benef)
        {
            string consulAsesoInv = "insert into BenefiInver(id_inv,Codigo_Cli,Id_benef) " +
              $"values({inv},{cli},{benef})";
            return consulta_gen(consulAsesoInv);
        }





        #endregion

        #region Retiros
        public int idRetiro(string inv)
        {
            string consulta = "SELECT COUNT(*) " +
            "FROM retiros";
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return Convert.ToInt32(datos.Rows[0][0]);

        }

        public DataTable searchRetiro(string inv)
        {
            string consulta;
            consulta = "SELECT id_retiro,id_inv,date_format(fecha,'%d/%M/%Y %H:%m'),monto,estado,cod_usuario,interes,total FROM retiros "+
                       $"WHERE Id_Inv = {inv}";
            DataTable datos = new DataTable();
            return buscar(consulta);
        }

        public bool Hacer_Retiro(string[] datos)
        {
            string estado = "Retirado";
            //interes y capital  y pago para ingresar en cada pago;
            DataTable credit = new DataTable();
            int id = idRetiro(datos[0]) + 1;
            string consulReritro = "Insert into retiros(id_retiro,Id_inv,Fecha, Monto,Interes,Total, Estado,Cod_Usuario) values" +
                $"({id},{datos[0]} ,'{datos[1]}',{datos[2]},{datos[3]},{datos[4]}, '{estado}',{datos[5]})";

            if (consulta_gen(consulReritro))
            {
                string consulUpdInv = "Update Inversion set Estado='Retirado' where id_inv=" + datos[0];
                return (consulta_gen(consulUpdInv));
            }
            else
            {
                return false;
            }
         
           
        }

       
        #endregion


    }
}
