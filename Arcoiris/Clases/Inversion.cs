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
            consulta = "SELECT Inv.id_inv,Inv.Monto,Inv.Interes,Inv.Plazo,Inv.FechaIn,Inv.FechaFin,Inv.Estado,Inv.Incentivo " +
                          "FROM Inversion Inv " +
                          "INNER JOIN asigna_Inversion AInv  ON AInv.Id_Inv = Inv.Id_Inv " +
                          "INNER JOIN cliente cli ON cli.CODIGO_CLI = AInv.codigo_cli " +
                           $"WHERE cli.CODIGO_CLI={Cli} and Inv.Estado!='Retirado' " +
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
                           $"WHERE ase.COD_ASESOR={Aseso} and Inv.Estado!='Retirado' " +
                          "ORDER BY Inv.id_inv,Inv.Monto,Inv.Interes,Inv.Plazo,Inv.FechaIn,Inv.FechaFin,Inv.Estado,Inv.Incentivo asc";
            DataTable datos = new DataTable();
            return buscar(consulta);
        }


        public DataTable verfechasInv(string Inv)
        {
            string consulta;
            DataTable datos = new DataTable();
            consulta = $"Select FechaIn,FechaFin from Inversion where Id_Inv={Inv}" ;
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
                return ((AsignaAsesoInv(idInv.ToString(),datos[8],datos[9])) && (AsignaBenef(idInv.ToString(),datos[8],datos[10])));
            }
            else
            { return false; }
        }

        private bool AsignaAsesoInv(string inv,string cli, string aseso)
        {
            
                        string consulAsesoInv = "insert into Asigna_Inversion(id_inv,Codigo_Cli,Cod_Asesor) " +
                $"values({inv},{cli},{aseso})";
            return consulta_gen(consulAsesoInv);
        }

        private bool AsignaBenef(string inv,string cli, string benef)
        {
            string consulAsesoInv = "insert into BenefiInver(id_inv,Codigo_Cli,Id_benef) " +
              $"values({inv},{cli},{benef})";
            return consulta_gen(consulAsesoInv);
        }





        #endregion

        #region Retiros
        public int idRetiro(string inv)
        {
            string consulta = "SELECT COUNT(*) "+
            "FROM retiros re "+
            "WHERE re.Id_Inv = " + inv;
            DataTable datos = new DataTable();
            datos = buscar(consulta);
            return Convert.ToInt32(datos.Rows[0][0]);

        }

        public bool Hacer_Retiro(string[] datos)
        {
            string estado = "Retirado";
            //interes y capital  y pago para ingresar en cada pago;
            DataTable credit = new DataTable();
            int id = idRetiro(datos[0]) + 1;
            string consulReritro = "Insert into retiros (id_retiro,Id_inv,Fecha, Monto, Estado,Cod_Usuario) values" +
                $"({id},{datos[0]} ,'{datos[1]}',{datos[2]},'{estado}',{datos[3]})";

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
