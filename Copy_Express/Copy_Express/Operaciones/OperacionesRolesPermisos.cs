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
    class OperacionesRolesPermisos
    {


        //Ingresar permisos de usuario

        public static int AgregarPermisos(int id_per, String ced_usu, int reg, int update,int delete)
        {
            int retorno = 0;
            using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into permisos(id_permiso,ced_usu,registrar,upadate,delet) values('{0}', '{1}', '{2}','{3}', '{4}')",
               id_per, ced_usu, reg, update,delete), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;
        }
        //Editar permisos
        public static int editarPermisos(int id_per, String ced_usu, int reg, int update, int delete)
        {
            
            int retorno = 0;
            using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Update permisos set ced_usu='{0}',registrar='{1}',upadate='{2}',delet='{3}' where id_permiso='{4}'",
                ced_usu, reg, update,delete,id_per), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;
        }
        //eliminar todo
        public static int EliminarPermisos(int cod)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("Delete from permisos where id_permiso={0}", cod), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }
            return retorno;
        }

        //Cargar combos Roles
        public static List<Rol> obtenerRoles(String cod)
        {
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                List<Rol> lisROL = new List<Rol>();
                SqlCommand comando = new SqlCommand(string.Format("Select * from rol  where CONCAT(cod_rol,nom_rol) LIKE '%" + cod + "%'"), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                try
                {
                    while (reader.Read())//carga los datos con roles
                    {
                        Rol rol = new Rol();
                        rol.cod_rol = reader.GetInt32(0);
                        rol.nom_rol = reader.GetString(1);
                        lisROL.Add(rol);
                    }
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
                conexion.Close();
                return lisROL;
            }
        }
        public static String obtenerRol(String cod)//para convertir de codigo a nombre el rol
        {
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                String nom_rol = "";
                SqlCommand comando = new SqlCommand(string.Format("Select * from rol  where CONCAT(cod_rol,nom_rol) LIKE '%" + cod + "%'"), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        nom_rol = reader.GetString(1);
                    }
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
                conexion.Close();
                return nom_rol;
            }
        }
        public static List<permisos> obtenerPermisos(String ced)//para cargar los check box
        {
            permisos per = new permisos();
            List<permisos> lisPermisos = new List<permisos>();
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {          
                SqlCommand comando = new SqlCommand(string.Format("Select * from permisos  where CONCAT(ced_usua) LIKE '%" + ced + "%'"), conexion);
                SqlDataReader reader = comando.ExecuteReader();
            
                    while (reader.Read())//carga los datos con roles
                    {
                    per.Ced_usua = reader.GetString(1);
                    per.Insert = reader.GetInt32(2);
                    per.Update = reader.GetInt32(3);
                    per.Delete = reader.GetInt32(4);

                    lisPermisos.Add(per);
                    }
                conexion.Close();
                return lisPermisos;
            }
        }
        public static List<Usuario> obtenerUsuario(String ced)//para cargar los check box
        {
            Usuario us = new Usuario();
            List<Usuario> lisUser = new List<Usuario>();
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Select * from usuario  where CONCAT(ced_usua,cod_usuario) LIKE '%" + ced + "%'"), conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())//carga los datos con roles
                {
                    us.Ced_usua = reader.GetString(2);
                    us.Nombres = reader.GetString(3);
                    us.Apellidos = reader.GetString(4);
                    lisUser.Add(us);
                }
                conexion.Close();
                return lisUser;
            }
        }

    }
}
