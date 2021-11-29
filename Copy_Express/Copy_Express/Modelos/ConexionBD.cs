using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copy_Express.Clases
{
    class ConexionBD
    {
        //static String cadenaConexion = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\Leonel\\Documents\\Visual Studio 2015\\App-Almacen_Computadoras\\App-Almacen_Computadoras\\Operaciones\\bd-computadoras.mdf';Integrated Security = True";
        // static String cadenaConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\alm\\documents\\visual studio 2015\\Projects\\App-Almacen_Computadoras\\App-Almacen_Computadoras\\bd-computadoras.mdf';Integrated Security=True";
        // static String cadenaConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\alm\\documents\\visual studio 2015\\Projects\\App-Almacen_Computadoras\\App-Almacen_Computadoras\\Operaciones\\bd-computadoras.mdf';Integrated Security=True";
        /*  public static String conectar()
          {
              String cadenaConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename='C:\\Users\\alm\\documents\\visual studio 2015\\Projects\\App-Almacen_Computadoras\\App-Almacen_Computadoras\\bd-computadoras.mdf';Integrated Security=True";
              return cadenaConexion;


          }*/
      

        // static String cadenaConexion = "Data Source=BELDUMA\\SQLEXPRESS; Integrated Security=true;Initial Catalog=bd-Computadoras; ";
        static String cadenaConexion = "Data Source=DESKTOP-C3F089B; Integrated Security=true;Initial Catalog=Ventas; ";

        public static SqlConnection ObtnerCOnexion()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(cadenaConexion);
                Conn.Open();
                return Conn;
            }
            catch (Exception err) { MessageBox.Show("Este es el error:"+err.Message); }
            return null;
        }
    }
}
