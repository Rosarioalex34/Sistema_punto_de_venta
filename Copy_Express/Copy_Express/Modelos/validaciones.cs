using Copy_Express.Formularios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copy_Express.Clases
{
    class validaciones
    {
        public static bool isCaracterValido(Char c)
        {
            if ((c >= '0' && c <= '9'))
            {
                return true;
            }
            return false;
        }
        public static Boolean esRequeridoCombo(ComboBox txt)
        {
            Boolean ok = true;
            if (txt.Text == "")
            {
                ok = false;
            }
            return ok;
        }
        public static Boolean esRequerido(TextBox txt)
        {
            Boolean ok = true;
            if (txt.TextLength == 0)
            {
                ok = false;
            }
            return ok;
        }
        public static void quitarErrorCombo(ErrorProvider err, ComboBox txt)
        {
            err.SetError(txt, "");
        }
        public static void quitarError(ErrorProvider err, TextBox txt)
        {
            err.SetError(txt, "");
        }
        public static void apareceError(ErrorProvider err, TextBox txt)
        {
            err.SetError(txt, "Error en los datos");
        }

        public static Boolean soloNumeros(ErrorProvider err, TextBox txt)
        {
            Boolean ok = true;
            int num;
            if (!int.TryParse(txt.Text, out num))
            {
                apareceError(err, txt);
                ok = false;
            }
            return ok;
        }


        public static Boolean ComprobarFormatoEmail(ErrorProvider err, TextBox sEmailAComprobar)
        {
            Boolean ok = true;
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar.Text, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar.Text, sFormato, String.Empty).Length == 0)
                {
                    ok = true;
                }
                else
                {
                    ok = false;
                    apareceError(err, sEmailAComprobar);
                }
            }
            else
            {
                ok = false;
                apareceError(err, sEmailAComprobar);
            }
            return ok;
        }

        public static Boolean soloLetras(TextBox txt)
        {
            Boolean ok = true;
            return true;
        }

        public void soloLetras(KeyPressEventArgs e)
        {
            Boolean ok = true;
            try
            {
                if (char.IsLetter(e.KeyChar))
                {
                    e.Handled = false;

                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;

                }
                else
                    e.Handled = true;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        public void soloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar))
                {
                    e.Handled = false;

                }
                else if (char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;

                }
                else
                    e.Handled = true;

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        public static Boolean validarCedu(String cedula)
        {
            Boolean ok = false;
            char[] vector = cedula.ToArray();
            int sumatotal = 0;
            int validor = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                validor = Convert.ToInt32(vector[i].ToString());
            }
            if (vector.Length == 10)
            {
                for (int i = 0; i < vector.Length - 1; i++)
                {
                    int numero = Convert.ToInt32(vector[i].ToString());
                    if ((i + 1) % 2 == 1)
                    {
                        numero = Convert.ToInt32(vector[i].ToString()) * 2;
                        if (numero > 9)
                        {
                            numero = numero - 9;
                        }
                    }
                    sumatotal += numero;
                }
                sumatotal = 10 - (sumatotal % 10);
                if (sumatotal > 9)
                {
                    //cedula incorrecta
                    // Console.Write("El numero de cedula final es 0");
                    ok = false;
                }
                else
                {
                    if (sumatotal == validor)
                    {
                        // Console.Write("Cedula correcta" );
                        ok = true;
                    }
                    
                }
            }
            else
            {
                ok = false;
            }
            return ok;
        }
        //login
        public static Boolean autentificarUsuarios(String usu, String contrasenia)
        {
            Boolean ok = false;
            try
            {
                int resultado = -1;
                using (SqlConnection Conn = ConexionBD.ObtnerCOnexion())
                {
                    SqlCommand comando = new SqlCommand("Select  cod_rol,ced_usua from usuario  where ced_usua =@usuario and passward = @passward ", Conn);
                    comando.Parameters.AddWithValue("usuario", usu);
                    comando.Parameters.AddWithValue("passward", contrasenia);
                    DataTable dt = new DataTable();
                    SqlDataAdapter reader = new SqlDataAdapter(comando);
                    reader.Fill(dt);
                    if (dt.Rows.Count == 1)
                    {
                        ok = true;
                    }            
                }

            }
            catch (Exception err) { MessageBox.Show(err.Message+" Error se marca aki"); }

            return ok;
        }
      
       public static List<permisos> ObtenerPermisosUser(String ced)//obtener los permisos
        {
            try
            {
                int num = 0;
                using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
                {
                    List<permisos> per = new List<permisos>();
                    SqlCommand comando = new SqlCommand(string.Format("Select * from permisos where ced_usu={0}", ced), conexion);
                    SqlDataReader reader = comando.ExecuteReader();
                    while (reader.Read())
                    {
                        permisos p = new permisos();
                        p.Ced_usua = reader.GetString(1);
                        p.Insert = reader.GetInt32(2);
                        p.Update = reader.GetInt32(3);
                        p.Delete = reader.GetInt32(4);
                        per.Add(p);
                    }
                    return per;
                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
            return null;
        }


        //valira cedula 2
        public static bool validarCed(String cedula)
        {
            if (cedula.Length == 13 && cedula.Substring(10, 3) == "001")
                cedula = cedula.Substring(0, 10);

            bool mistmatch = false;
            for (int i = 0; i < cedula.Length; i++)
            {
                if (i > 0 && cedula[i] != cedula[i - 1])
                    mistmatch = true;
            }
            if (mistmatch == false)
                return mistmatch;

            //verifica que tenga 10 dígitos 
            if (!(cedula.Length == 10))
            {
                return false;
            }
            //verifica que los dos primeros dígitos correspondan a un valor entre 1 y NUMERO_DE_PROVINCIAS
            int prov = int.Parse(cedula.Substring(0, 2));
            if (!((prov > 0) && (prov <= 24)))
            {
                return false;
            }
            //verifica que el último dígito de la cédula sea válido
            int[] d = new int[10];
            //Asignamos el string a un array
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = int.Parse(cedula.Substring(i, 1) + "");
            }
            int imp = 0;
            int par = 0;
            //sumamos los duplos de posición impar
            for (int i = 0; i < d.Length; i += 2)
            {
                d[i] = ((d[i] * 2) > 9) ? ((d[i] * 2) - 9) : (d[i] * 2);
                imp += d[i];
            }
            //sumamos los digitos de posición par
            for (int i = 1; i < (d.Length - 1); i += 2)
            {
                par += d[i];
            }
            //Sumamos los dos resultados
            int suma = imp + par;
            //Restamos de la decena superior
            int d10 = int.Parse(Convert.ToString(suma + 10).Substring(0, 1) + "0") - suma;
            //Si es diez el décimo dígito es cero        
            d10 = (d10 == 10) ? 0 : d10;
            //si el décimo dígito calculado es igual al digitado la cédula es correcta
            return d10 == d[9];
        }
    }
}

 
 