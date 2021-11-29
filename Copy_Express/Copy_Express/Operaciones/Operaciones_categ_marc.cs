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
    class Operaciones_categ_marc
    {
        //OPERACIONES MARCA
        public static int AgregarMarca(marca mrca)
        {
            int retorno = 0;
            using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into marca(cod_marca,desc_marca) values('{0}', '{1}')",
                     mrca.Cod_marca, mrca.Descripcion), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;
        }
        public static int ModificarMarca(marca mrca)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Update marca set desc_marca='{0}' where cod_marca={1}",
                mrca.Descripcion, mrca.Cod_marca), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }

        public static int EliminarMarca(string cod)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("Delete from marca where cod_marca={0}", cod), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }
            return retorno;
        }
        public static int codigoMarca()
        {
            int cod = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("SELECT  MAX(cod_marca) FROM marca"), conexion);
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
        public static List<marca> BuscarMarca(String dato)//carga la tabla 
        {
            List<marca> Lista = new List<marca>();
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format(
                    "SELECT * FROM marca where CONCAT(cod_marca,desc_marca) LIKE '%" + dato + "%' order by cod_marca asc"), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    marca m = new marca();
                    m.Cod_marca = reader.GetInt32(0);
                    m.Descripcion = reader.GetString(1);
                    Lista.Add(m);
                }
                conexion.Close();
                return Lista;
            }
        }
        // OPERACIONES CATEGORIA
        public static int AgregarCateg(categoria cat)
        {
            int retorno = 0;
            using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into categoria(cod_cat,descripcion) values('{0}', '{1}')",
                     cat.Cod_cat, cat.Des_cat), Conn);

                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
               // MessageBox.Show("Guardo categoria");
            }
            return retorno;
        }
        public static int ModificarCateg(categoria cat)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Update categoria set descripcion='{0}' where cod_cat={1}",
                cat.Des_cat, cat.Cod_cat), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }

        public static int EliminarCateg(string cod)//Eliminar categoria
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("Delete from categoria where cod_cat={0}", cod), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }
            return retorno;
        }
        public static int codigoCat()
        {
            int cod = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("SELECT  MAX(cod_cat) FROM categoria"), conexion);
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
        public static List<categoria> BuscarCategoria(String dato)//carga la tabla 
        {
            List<categoria> Lista = new List<categoria>();
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format(
                    "SELECT * FROM categoria where CONCAT(cod_cat,descripcion) LIKE '%" + dato + "%' order by cod_cat asc"), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    categoria cat = new categoria();
                    cat.Cod_cat = reader.GetInt32(0);
                    cat.Des_cat = reader.GetString(1);
                    Lista.Add(cat);
                }
                conexion.Close();
                return Lista;
            }
        }

        public static String obtenerNomMarca(String cod)//obtengo el nombre de la ciudad
        {
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                String nom_marca = "";
                SqlCommand comando = new SqlCommand(string.Format("Select * from marca  where CONCAT(cod_marca,desc_marca) LIKE '%" + cod + "%'"), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        nom_marca = reader.GetString(1);
                    }
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
                conexion.Close();
                return nom_marca;
            }
        }
        public static String obtenerNomCateg(String cod)//obtengo el nombre de la ciudad
        {
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                String nom_cat = "";
                SqlCommand comando = new SqlCommand(string.Format("Select * from categoria  where CONCAT(cod_cat,descripcion) LIKE '%" + cod + "%'"), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        nom_cat = reader.GetString(1);
                    }
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
                conexion.Close();
                return nom_cat;
            }
        }
      
 
    }
}
