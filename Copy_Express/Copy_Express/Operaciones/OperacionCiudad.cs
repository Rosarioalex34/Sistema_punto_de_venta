using Copy_Express.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copy_Express.Operaciones
{
    class OperacionCiudad
    {

        public static int AgregarCiudad(ciudad ciu)
        {
            int retorno;
            using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into ciudad(cod_ciu,nom_ciu) values('{0}', '{1}')",
                     ciu.cod_ciu,ciu.nom_ciu), Conn);

                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
               // MessageBox.Show("Guardo Ciudad");
            }
            return retorno;
        }
        public static int ModificarCiudad(ciudad ciu)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Update ciudad set nom_ciu='{0}' where cod_ciu={1}",
                ciu.nom_ciu,ciu.cod_ciu), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }

        public static int EliminarCiudad(string cod)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("Delete from ciudad where cod_ciu={0}", cod), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }
            return retorno;
        }
        public static int codigoCiudad()
        {
            int cod = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("SELECT  MAX(cod_ciu) FROM ciudad"), conexion);
                try
                {
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        cod = reader.GetInt32(0);
                    }
                    conexion.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                return cod;
            }
        }
        public static ciudad BuscarCiudad(String dato)//carga la tabla 
        {
            // List<ciudad> Lista = new List<ciudad>();
            ciudad ciu = new ciudad();
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format(
                    "SELECT * FROM ciudad where CONCAT(cod_ciu,nom_ciu) LIKE '%" + dato + "%' order by cod_ciu asc"), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                   
                    ciu.cod_ciu = reader.GetInt32(0);
                    ciu.nom_ciu = reader.GetString(1);
                  //  Lista.Add(ciu);
                }
                conexion.Close();
                return ciu;
            }
        }
        //LLenar ciudad con combo box
        public static List<ciudad> obtenerCiudad(String cod)
        {
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                List<ciudad> lisCiu = new List<ciudad>();
                SqlCommand comando = new SqlCommand(string.Format("Select * from ciudad  where CONCAT(cod_ciu,nom_ciu) LIKE '%" + cod + "%'"), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        ciudad ciud = new ciudad();
                        ciud.cod_ciu = reader.GetInt32(0);
                        ciud.nom_ciu = reader.GetString(1);
                        lisCiu.Add(ciud);
                    }
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
                conexion.Close();
                return lisCiu;
            }
        }
        public static String obtenerNomCiu(String cod)//obtengo el nombre de la ciudad
        {
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                String nom_ciu = "";
                SqlCommand comando = new SqlCommand(string.Format("Select * from ciudad  where CONCAT(cod_ciu,nom_ciu) LIKE '%" + cod + "%'"), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        nom_ciu = reader.GetString(1);
                    }
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
                conexion.Close();
                return nom_ciu;
            }
        }






    }
}
