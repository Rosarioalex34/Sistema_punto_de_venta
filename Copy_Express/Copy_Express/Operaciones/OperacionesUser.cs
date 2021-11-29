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
    class OperacionesUser
    {//Ingresar usuarios
        public static int AgregarUsuario(Usuario us)
        {
            try
            {
                int retorno = 0;
                using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())
                {
                    SqlCommand Comando = new SqlCommand(string.Format("Insert Into usuario(cod_usuario,cod_rol,ced_usua,nom_usua,ape_usua,email_usua,telf_usua,dir_usua,cod_ciu,passward,aux) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}','{8}','{9}','{10}')",
                    us.Cod_usua, us.Rol, us.Ced_usua, us.Nombres, us.Apellidos, us.Email, us.Telefono, us.Direccion, us.Ciudad, us.Passward, us.Aux), Conn);
                    retorno = Comando.ExecuteNonQuery();
                    Conn.Close();
                }
                return retorno;
            }
            catch (Exception err) { MessageBox.Show("Datos incorrectos"); }
            return 0;
        }
        //EDITAR USUARIO
        public static int ModificarUser(Usuario us)
        {
            try
            {
                int retorno = 0;
                using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
                {
                    SqlCommand comando = new SqlCommand(string.Format("Update usuario set cod_rol='{0}',ced_usua='{1}',nom_usua='{2}',ape_usua='{3}',email_usua='{4}',telf_usua='{5}',dir_usua='{6}',cod_ciu = '{7}',passward='{8}',aux='{9}' where cod_usuario={10}",
                     us.Rol, us.Ced_usua, us.Nombres, us.Apellidos, us.Email, us.Telefono, us.Direccion, us.Ciudad, us.Passward, us.Aux, us.Cod_usua), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                return retorno;
            }
            catch (Exception err) { MessageBox.Show("Ocurrio error"); }
            return 0;
        }
        //Eliminar usuario
        public static int EliminarUser(string cod)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("Delete from usuario where cod_usuario={0}", cod), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }
            return retorno;
        }


        //CODIGO DEL USUAIO
        public static int numUser()
        {
            
            int num = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("SELECT  MAX(cod_usuario) FROM usuario"), conexion);
                try
                {
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        num = reader.GetInt32(0);
                    }
                    conexion.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                return num;
            }
        }
        //Obtener usuarios
        public static Usuario ObtenerUser(String dato)
        {//llena los campos de los usuarios
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                Usuario us = new Usuario();
                SqlCommand comando = new SqlCommand(string.Format("Select * from usuario where ced_usua='{0}'", dato), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        us.Cod_usua = reader.GetInt32(0);
                        us.Rol =  OperacionesRolesPermisos.obtenerRol(reader.GetInt32(1)+"");
                        us.Ced_usua = reader.GetString(2);
                        us.Nombres = reader.GetString(3);
                        us.Apellidos = reader.GetString(4);
                        us.Email = reader.GetString(5);
                        us.Telefono = reader.GetString(6);
                        us.Direccion = reader.GetString(7);                     
                        us.Ciudad = OperacionCiudad.obtenerNomCiu(reader.GetInt32(8)+"");
                        us.Passward = reader.GetString(9);
                        us.Aux = reader.GetInt32(10);
                    }
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
                conexion.Close();
                return us;

            }
        }
        //CARGAR COMBO CON EMPLEADOS
        public static List<Usuario> obtenerUsuarios(String cod)
        {
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
                {
                    List<Usuario> lisUs = new List<Usuario>();
                   // SqlCommand comando = new SqlCommand(string.Format("Select * from usuario  where CONCAT(ced_usua,nom_usua,' ',ape_usua) LIKE '%" + cod + "%'"), conexion);
                    SqlCommand comando = new SqlCommand(string.Format("Select * from usuario  where CONCAT(ced_usua,ape_usua) LIKE '%" + cod + "%'"), conexion);

                    SqlDataReader reader = comando.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            Usuario us = new Usuario();
                            us.Cod_usua = reader.GetInt32(0);
                            us.Rol = reader.GetInt32(1) + "";
                            us.Ced_usua = reader.GetString(2);
                            us.Nombres = reader.GetString(3);
                            us.Apellidos = reader.GetString(4);
                            us.Email = reader.GetString(5);
                            us.Telefono = reader.GetString(6);
                            us.Direccion = reader.GetString(7);
                            us.Ciudad = reader.GetInt32(8) + "";
                            us.Passward = reader.GetString(9);
                            us.Aux = reader.GetInt32(10);//para verificar la cedula
                            lisUs.Add(us);
                        }
                    }
                    catch (Exception err) { MessageBox.Show(err.Message); }
                    conexion.Close();
                    return lisUs;
                }
            }
            catch (Exception err) { MessageBox.Show("Ingrese datos correctos"); }
            return null;
        }
        //Cambiar solo la contrasenia
        public static int EditarPassward(String  ced, String  passw)
        {
            int retorno;
            int aux = 2;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("UPDATE usuario SET passward='" + passw + "',aux='"+aux+"'    WHERE ced_usua = '" + ced + "'"), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;

        }
    }
}
