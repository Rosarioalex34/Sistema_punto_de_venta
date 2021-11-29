using Copy_Express.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copy_Express.Operaciones
{
    class OperacionesCompra
    {
        public static int AgregarCompra(Compra com)//GUARDAR FACTURA DE COMPRA
        {
            int retorno = 0;
            using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into compras(cod_cmpra,ced_ruc_prov,ced_empl,fecha_pedido,fecha_entrega,estado_cmpra,subtotal,iva_cmpra,desc_cmpra,total_cmpra) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                com.Cod_compr, com.Ced_ruc_prov, com.Ced_empl, com.Fecha_pedido, com.Fecha_entrega, com.Est_compr, com.Subtotal.ToString().Replace(",", "."), com.Iva.ToString().Replace(",", "."), com.Desc.ToString().Replace(",", "."), com.Total.ToString().Replace(",", ".")), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;
        }//fin método guardar factura compra


        public static int EliminarCompra(int cod)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("Delete from venta where cod_cmpra={0}", cod), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }
            return retorno;
        }
        //GUARDAR DETALLES DE FACTURA DE COMPRA
        public static int AgregarDetalleCompra(Detalle_compra det)
        {
            int retorno = 0;
            using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into det_compra(cod_cmpra,cant_prod,cod_prod,prec_cmpra,iva_cmpra,desc_cmpra,total_cmpra) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                det.Cod_compra,det.Cant_comp,det.Cod_prod,det.Prec_compra.ToString().Replace(",", "."), det.Iva.ToString().Replace(",", "."), det.Descuento.ToString().Replace(",", "."), det.Total.ToString().Replace(",", ".")), Conn);

                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
                //  MessageBox.Show("Guardo");
            }
            return retorno;
        }
        //ELIMINAR DETALLE DE COMPRA
        public static int elimiarDetalleCompra(String cod)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("Delete from det_compra where cod_cmpra={0}", cod), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }

            return retorno;

        }
        public static String codFacturaCompra()
        {
            try
            {
                String num = "";
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("SELECT  MAX(cod_cmpra) FROM compras "), conexion); 
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        num = reader.GetString(0);
                        
                    }
                    conexion.Close();
                }
                return num;

            }
             catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            return "";

        }
    
        //cargar las ventas por rango de fechas
        public static List<Compra> cargarCompras(String fecInicio, String fechaFin)
        {        
           // try
            {
                List<Compra> lis = new List<Compra>();
                using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
                {
                    SqlCommand comando = new SqlCommand(string.Format(
                        "Select * from compras where fecha_pedido between '" + fecInicio + "' and '" + fechaFin + "'"), conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Compra com = new Compra();
                        com.Cod_compr = Int32.Parse(reader.GetString(0));
                        com.Ced_ruc_prov = reader.GetString(1);
                        com.Fecha_pedido = reader.GetDateTime(3) + "";
                        com.Fecha_entrega = reader.GetDateTime(4) + "";
                        com.Subtotal =reader.GetDecimal(6);
                        com.Iva = reader.GetDecimal(7);
                        com.Total = reader.GetDecimal(9);
                        lis.Add(com);
                    }
                    conexion.Close();
                    return lis;
                }
            }
            return null;
        }
    }
  }
