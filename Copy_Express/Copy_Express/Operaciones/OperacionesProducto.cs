using Copy_Express.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Copy_Express.Operaciones
{
    class OperacionesProducto
    {
        // try{
        //Guardar producto
        public static int AgregarProducto(Producto pr)
        {
            int retorno = 0;
            using (SqlConnection Conn = ConexionBD.ObtnerCOnexion()) {
                SqlCommand Comando = new SqlCommand(string.Format("Insert Into producto(cod_prod,nom_prod,cod_marca,prec_compra,prec_vnta,iva_prod,cant_prod,cod_cat) values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}','{6}','{7}')",
                pr.Cod_prod, pr.Nom_prod, pr.Marca, pr.Prec_com.ToString().Replace(",", "."), pr.Prec_vnta.ToString().Replace(",", "."), pr.Iva_prod.ToString().Replace(",", "."), pr.Cant_prod, pr.Cod_categ), Conn);
                retorno = Comando.ExecuteNonQuery();
                Conn.Close();
           }
        //}
            return retorno;
        
    //} catch(Exception err){MessageBox.Show("");}
        }
        public static int ModificarProducto(Producto pr)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Update producto set nom_prod='{0}',cod_marca='{1}',prec_compra='{2}',prec_vnta='{3}',iva_prod='{4}',cant_prod='{5}',cod_cat='{6}' where cod_prod={7}",
                 pr.Nom_prod, pr.Marca, pr.Prec_com.ToString().Replace(",", "."), pr.Prec_vnta.ToString().Replace(",", "."), pr.Iva_prod.ToString().Replace(",", "."), pr.Cant_prod, pr.Cod_categ, pr.Cod_prod), conexion);
                 retorno = comando.ExecuteNonQuery();
                conexion.Close();
               // MessageBox.Show("Producto Actualizado");
            }
            return retorno;
        }

        public static int EliminarProducto(string cod)
        {
            int retorno = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                try
                {
                    SqlCommand comando = new SqlCommand(string.Format("Delete from producto where cod_prod={0}", cod), conexion);
                    retorno = comando.ExecuteNonQuery();
                    conexion.Close();
                }
                catch (Exception err) {  }
            }
            return retorno;
        }
     
        public static int numProducto()//CODIGO DEL PRODUCTO
        {
            int num = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("SELECT  MAX(cod_prod) FROM producto"), conexion);
                try
                {
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        num = reader.GetInt32(0);//columna donde elijo el código
                    }
                    conexion.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                return num;
            }
        }//FIN
  
        public static List<Producto> BuscarProductos(String dato)//Buscar productos
        {
            try
            {
                List<Producto> Lista = new List<Producto>();
                using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
                {
                    SqlCommand comando = new SqlCommand(string.Format(
                        "SELECT * FROM producto where CONCAT(nom_prod,cod_cat) LIKE '%" + dato + "%' order by cod_prod asc"), conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        Producto pr = new Producto();
                        pr.Cod_prod = reader.GetInt32(0);
                        pr.Nom_prod = reader.GetString(1);
                        pr.Marca = Operaciones_categ_marc.obtenerNomMarca(reader.GetInt32(2) + "");//convertir a dato
                        pr.Prec_com = reader.GetDecimal(3);
                        pr.Prec_vnta = reader.GetDecimal(4);
                        pr.Iva_prod = reader.GetDecimal(5);
                        pr.Cant_prod = reader.GetInt32(6);
                        pr.Cod_categ = Operaciones_categ_marc.obtenerNomCateg(reader.GetInt32(7) + "");//convertir a dato
                        Lista.Add(pr);
                    }
                    conexion.Close();
                    return Lista;
                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
            return null;
        }
        public static Producto ObtenerProducto(Int32 codpro)//llena los campos de los clientes
        {try
            {
                using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
                {

                    Producto pr = new Producto();
                    SqlCommand comando = new SqlCommand(string.Format("Select * from producto where cod_prod={0}", codpro), conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                    try
                    {
                        while (reader.Read())
                        {
                            pr.Cod_prod = reader.GetInt32(0);
                            pr.Nom_prod = reader.GetString(1);
                            pr.Marca = Operaciones_categ_marc.obtenerNomMarca(reader.GetInt32(2) + "");//convertir a dato
                            pr.Prec_com = reader.GetDecimal(3); //reader.GetDecimal()//corregir 
                            pr.Prec_vnta = reader.GetDecimal(4);
                            pr.Iva_prod = reader.GetDecimal(5);
                            pr.Cant_prod = reader.GetInt32(6);
                            pr.Cod_categ = Operaciones_categ_marc.obtenerNomCateg(reader.GetInt32(7) + ""); ;//convertir a dato
                        }

                    }
                    catch (Exception err) { MessageBox.Show(err.Message+"ESTO MARCA ERROR"); }
                    conexion.Close();
                    return pr;

                }
            }
            catch (Exception err) { MessageBox.Show(err.Message+ "ESTO MARCA ERROR"); }
            return null;
        }
       
        //Disminuir stok de productos
       
        public static int cantStok(Int32 cod)
        {
            Int32 cantActual = 0;
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {            
                SqlCommand comando = new SqlCommand(string.Format("Select * from producto   where cod_prod={0}",cod), conexion);
                SqlDataReader reader = comando.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                         cantActual = reader.GetInt32(6);
                        
                    }
                }
                catch (Exception err) { MessageBox.Show(err.Message); }
                conexion.Close();
                return cantActual;
            }

        }
        public static int aumentarStok(Int32 cod, Int32 cant) {
            int retorno;
            int desfinal = cant + cantStok(cod);
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("UPDATE producto SET cant_prod='" + desfinal + "' WHERE cod_prod = '" + cod + "'"), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
               // MessageBox.Show("Stok aumento");
            }
            return retorno;

        }


        public static int disminuirStok(Int32 cod, Int32 cant)
        {
            int retorno;
            int desfinal =  cantStok(cod) - cant; 
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("UPDATE producto SET cant_prod='" + desfinal + "' WHERE cod_prod = '" + cod + "'"), conexion);
                retorno = comando.ExecuteNonQuery();
                conexion.Close();
               // MessageBox.Show("Stok disminuyo");               
            }
            return retorno;

        }

    }

}

