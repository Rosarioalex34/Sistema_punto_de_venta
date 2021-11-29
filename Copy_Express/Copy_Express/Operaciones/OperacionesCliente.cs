using Copy_Express.Clases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Copy_Express.Operaciones
{
    class OperacionesCliente
    {
        public static int AgregarCliente(Cliente cl)
        {
            int retorno = 0;
            using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into cliente(cod_client,ced_client,nom_client,ape_client,email_client,telf_client,dir_client,cod_ciu) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                     cl.Cod_client, cl.Ced_cliente, cl.Nombres, cl.Apellidos, cl.Email, cl.Telefono, cl.Direccion, cl.Ciudad), Conn);

                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;
        }
        public static int ModificarClient(Cliente cl)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {

                SqlCommand comando = new SqlCommand(string.Format("Update cliente set ced_client='{0}',nom_client='{1}',ape_client='{2}',email_client='{3}',telf_client='{4}',dir_client='{5}',cod_ciu='{6}' where cod_client={7}",
                      cl.Ced_cliente, cl.Nombres, cl.Apellidos, cl.Email, cl.Telefono, cl.Direccion, cl.Ciudad, cl.Cod_client), conexion);

                retorno = comando.ExecuteNonQuery();
                conexion.Close();
            }
            return retorno;
        }

        public static int EliminarClient(string cod)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("Delete from cliente where cod_client={0}", cod), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }
            return retorno;
        }
        public static int numCliente()
        {
            int num = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("SELECT  MAX(cod_client) FROM cliente"), conexion);
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

                  
        public static List<Cliente> BuscarCliente(String dato)//carga la tabla
        {
            List<Cliente> Lista = new List<Cliente>();
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format(
                    "SELECT * FROM cliente where CONCAT(ced_client,nom_client,ape_client) LIKE '%" + dato + "%' order by cod_client asc"), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    Cliente cl = new Cliente();
                    cl.Cod_client = reader.GetInt32(0);
                    cl.Ced_cliente = reader.GetString(1);
                    cl.Nombres = reader.GetString(2);
                    cl.Apellidos = reader.GetString(3);
                    cl.Email = reader.GetString(4);
                    cl.Telefono = reader.GetString(5);
                    cl.Direccion = reader.GetString(6);
                    cl.Ciudad = OperacionCiudad.obtenerNomCiu(reader.GetInt32(7) + "");
                    Lista.Add(cl);
                }
                conexion.Close();
                return Lista;
            }
        }
        
        public static Cliente ObtenerCliente(String dato)
        {//llena los campos de los clientes
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                //SqlCommand comando;
                Cliente cl = new Cliente();
                SqlCommand comando = new SqlCommand(string.Format("Select * from cliente where cod_client={0}", dato), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        cl.Cod_client = reader.GetInt32(0);
                        cl.Ced_cliente = reader.GetString(1);
                        cl.Nombres = reader.GetString(2);
                        cl.Apellidos = reader.GetString(3);
                        cl.Email = reader.GetString(4);
                        cl.Telefono = reader.GetString(5);
                        cl.Direccion = reader.GetString(6);
                        cl.Ciudad = OperacionCiudad.obtenerNomCiu(reader.GetInt32(7) + "");
                    }
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
                conexion.Close();
                return cl;

            }
        }
        public static Cliente CargarClienteCombo(String dato)
        {//llena los campos de los clientes
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
                {
                    Cliente cl = new Cliente();
                    SqlCommand comando = new SqlCommand(string.Format("Select * from cliente where ced_client={0}", dato), conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            cl.Cod_client = reader.GetInt32(0);
                            cl.Ced_cliente = reader.GetString(1);
                            cl.Nombres = reader.GetString(2);
                            cl.Apellidos = reader.GetString(3);
                            cl.Email = reader.GetString(4);
                            cl.Telefono = reader.GetString(5);
                            cl.Direccion = reader.GetString(6);
                            cl.Ciudad = OperacionCiudad.obtenerNomCiu(reader.GetInt32(7) + "");
                        }
                    }
                    catch (Exception err) { MessageBox.Show(err.Message); }
                    conexion.Close();
                    return cl;

                }
            }
            catch (Exception err) {

                MessageBox.Show("Ingresar datos correctos");
            }
            return null;
        }
        //Regresar nombre de cliente
        public static String requiereNomCliente(String ced)
        {
            String nomCom = "";
            try
            {
                using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
                {
                    Cliente cl = new Cliente();
                    
                     SqlCommand comando = new SqlCommand(string.Format("Select * from cliente where ced_client={0}", ced), conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                  
                        while (reader.Read())
                        {                      
                            nomCom = reader.GetString(2)+"  "+ reader.GetString(3);
                        }
                    
                    conexion.Close();
                    return nomCom;
                }
            }
            catch (Exception err)
            { MessageBox.Show("Ingresar datos correctos"); }
            return null;
        }
    }
}
