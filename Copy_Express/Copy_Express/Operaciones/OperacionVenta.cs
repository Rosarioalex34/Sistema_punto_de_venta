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
    class OperacionVenta
    {
        public static int AgregarVenta(venta vnt)
        {
            int retorno = 0;
            using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into ventas(cod_vnta,ced_client,ced_empl,fecha,form_pago,estado_vnta,subtotal,iva,descuento,total) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                     vnt.Cod_vnta,vnt.Ced_client,vnt.Ced_empl,vnt.Fecha,vnt.Forma_pago,vnt.Est_vnta,vnt.Subtotal.ToString().Replace(",", "."), vnt.Iva.ToString().Replace(",", "."), vnt.Desc.ToString().Replace(",", "."), vnt.Total.ToString().Replace(",", ".")), Conn);

                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;
        }
        public static int EliminarVenta(int cod)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("Delete from ventas where cod_vnta={0}", cod), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }
            return retorno;
        }
        //Guardar detalle
        public static int AgregarDetalle(detalle_venta det)
        {
            int retorno = 0;
            using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into detalle_vnta(cod_vnta,cant,cod_prod,prec_unit,det_iva,descuento,total) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')",
                     det.Cod_vnta,det.Cant,det.Cod_prod,det.Prec_unit.ToString().Replace(",", "."), det.Iva.ToString().Replace(",", "."), det.Descuento.ToString().Replace(",", "."), det.Total.ToString().Replace(",", ".")), Conn);

                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
            }
            return retorno;
        }
        public static int  elimiarDetalle(int cod)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion()) {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("Delete from detalle_vnta where cod_vnta={0}", cod), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }
            return retorno;
        }
        public static String codFactura() {
            try
            {
                int num = 0;
                using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
                {
                    SqlCommand comando = new SqlCommand(string.Format("SELECT  count(cod_vnta) FROM ventas"), conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        num = reader.GetInt32(0);
                    }
                    conexion.Close();
                }
                return (num + 1) +"";
            }
            catch (Exception err)
            {
              MessageBox.Show(err.Message);
            }
            return "";
        }
      
        //cargar las ventas por rango de fechas
        public static List<venta> cargarVentas(String fecInicio, String fechaFin)
        {         
            List<venta> lis = new List<venta>();
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format(
                    "Select * from ventas where fecha between '"+fecInicio+"' and '"+fechaFin+"'" ), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    venta vnta = new venta();
                    vnta.Cod_vnta = Int32.Parse(reader.GetString(0));
                    vnta.Ced_client = reader.GetString(1);
                    vnta.Fecha = reader.GetDateTime(3)+"";
                    vnta.Subtotal = reader.GetDecimal(6);
                    vnta.Iva = reader.GetDecimal(7);
                    vnta.Total = reader.GetDecimal(9);       
                    lis.Add(vnta);
                }
                conexion.Close();
                return lis;
            }

        }
     }
}
