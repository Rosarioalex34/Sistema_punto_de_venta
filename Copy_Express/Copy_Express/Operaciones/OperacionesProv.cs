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
    class OperacionesProv
    {   //MÉTODO AGREGAR
        public static int AgregarProveedor(proveedores prov)
        {
                int retorno = 0;
                using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())//conectando la base de datos
                {
                    SqlCommand Comando = new SqlCommand(string.Format("Insert Into proveedor(cod_prov,ruc_ced,nom_prov,direccion,id_ciudad,telf,email) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                     prov.Cod_prov, prov.Ruc_ced, prov.Nom_prv, prov.Direcc, prov.Ciudad1, prov.Telf, prov.Email1), Conn);
                    retorno = Comando.ExecuteNonQuery();
                    Conn.Close();//Cerrar la conexión
                }
                return retorno;
         
        }
        //MÉTODO MODIFICAR
        public static int ModificarProveedor(proveedores prov)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Update proveedor set ruc_ced='{0}',nom_prov='{1}',direccion='{2}',id_ciudad='{3}',telf='{4}',email='{5}' where cod_prov={6}",
                prov.Ruc_ced, prov.Nom_prv, prov.Direcc, prov.Ciudad1, prov.Telf, prov.Email1, prov.Cod_prov), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }
        //ELIMINAR PROVEEDOR
        public static int EliminarProveedor(string cod)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("Delete from proveedor where cod_prov={0}", cod), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }
            return retorno;
        }
        //CÓDIGO PROVEEDOR
        public static int numProvedor()
        {
            int num = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("SELECT  MAX(cod_prov) FROM proveedor"), conexion);
                try
                {
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        num = reader.GetInt32(0);
                    }
                    conexion.Close();//Cerrar la conexión
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
                return num;
            }
        }
        //llena los campos de los proveedores
        public static proveedores ObtenerProveedor(String dato)
        {
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                proveedores prov = new proveedores();
                SqlCommand comando = new SqlCommand(string.Format("Select * from proveedor where cod_prov={0}", dato), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        prov.Cod_prov = reader.GetInt32(0);
                        prov.Ruc_ced = reader.GetString(1);
                        prov.Nom_prv = reader.GetString(2);
                        prov.Direcc = reader.GetString(3);
                        prov.Ciudad1 = OperacionCiudad.obtenerNomCiu(reader.GetInt32(4)+""); //cambiar esto
                        prov.Telf = reader.GetString(5);
                        prov.Email1 = reader.GetString(6);                 
                    }
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
                conexion.Close();
                return prov;
            }
        }

       public static List<proveedores> BuscarProveedor(String dato)//carga la tabla
        {
            List<proveedores> Lista = new List<proveedores>();
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format(
                    "SELECT * FROM proveedor where CONCAT(cod_prov,ruc_ced,nom_prov) LIKE '%" + dato + "%' order by cod_prov asc"), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    proveedores prov = new proveedores();
                    prov.Cod_prov = reader.GetInt32(0);
                    prov.Ruc_ced = reader.GetString(1);
                    prov.Nom_prv = reader.GetString(2);
                    prov.Direcc = reader.GetString(3);
                    prov.Ciudad1 = OperacionCiudad.obtenerNomCiu(reader.GetInt32(4) + ""); ;// reader.GetInt32(4) + "";//ciudad nombre
                    prov.Telf = reader.GetString(5);
                    prov.Email1 = reader.GetString(6);
                    Lista.Add(prov);
                }
                conexion.Close();
                return Lista;
            }
        }
        public static proveedores cargarProveedor(String dato)
        {
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
                {
                    proveedores prov = new proveedores();
                    SqlCommand comando = new SqlCommand(string.Format("Select * from proveedor where ruc_ced={0}", dato), conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            prov.Cod_prov = reader.GetInt32(0);
                            prov.Ruc_ced = reader.GetString(1);
                            prov.Nom_prv = reader.GetString(2);
                            prov.Direcc = reader.GetString(3);
                            prov.Ciudad1 = OperacionCiudad.obtenerNomCiu(reader.GetInt32(4) + ""); //cambiar esto
                            prov.Telf = reader.GetString(5);
                            prov.Email1 = reader.GetString(6);
                        }
                    }
                    catch (Exception err) { /*MessageBox.Show(err.Message);*/ }
                    conexion.Close();
                    return prov;
                }
            }
            catch (Exception err) { }
            return null;
        }
        //Requiere proveedor
        public static String requiProveedor(String ced)
        {
            String nomProv = "";
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                proveedores prov = new proveedores();
                SqlCommand comando = new SqlCommand(string.Format("Select * from proveedor where ruc_ced={0}", ced), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {                      
                        nomProv = reader.GetString(2);                      
                    }
                }
                catch (Exception err) {  }
                conexion.Close();
                return nomProv;
            }
        }
    }
}
