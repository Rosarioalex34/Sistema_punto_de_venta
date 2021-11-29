using Copy_Express.Clases;
using Copy_Express.Operaciones;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Copy_Express.Formularios
{
    public  partial class form_cliente : Form
    {  
        public   form_cliente()
        {
            InitializeComponent();
        }
        public Cliente clienteActual { get; set; }

        public   void button1_Click(object sender, EventArgs e)
        {//Guardar Cliente  
            try
            {
                if (validarCampos() )
                {
                    Cliente cl = new Cliente();
                    cl.Cod_client = Int32.Parse(textcod_cli.Text);
                    cl.Ced_cliente = textced_cli.Text;
                    cl.Nombres = textnom_cli.Text;
                    cl.Apellidos = textape_cli.Text;
                    cl.Email = textemail_cli.Text;
                    cl.Telefono = texttelf_cli.Text;
                    cl.Direccion = textdir_cli.Text;
                    cl.Ciudad = comboCiudad.SelectedValue+"";//guarda el codigo de la ciudad
                    OperacionesCliente.AgregarCliente(cl);
    
                    limpiarCampos();
                    bloquearCampos(false);
                    quitarErrores();
                    labelMensaje.ForeColor = Color.Green;
                    labelMensaje.Text = "Cliente Registrado !";
                                     
                }
           }
            catch (Exception err) {
                labelMensaje.Text = "Cliente ya esta Registrado";
            }
        }
        public void quitarErrores() {

            validaciones.quitarError(errorCed, textced_cli);
            validaciones.quitarError(errorNom, textnom_cli);
            validaciones.quitarError(errorApe, textape_cli);
            validaciones.quitarError(errorEmail, textemail_cli);
            validaciones.quitarError(errorTelf, texttelf_cli);
            validaciones.quitarError(errorDirec, textdir_cli);
            labelMensaje.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {//Nuevo registro de registro
            limpiarCampos();//limpiar todos los campos
            textcod_cli.Text= OperacionesCliente.numCliente()+1+"";  
            cargarCombos();
            bloquearCampos(true);
            quitarErrores();

        }

        private void button4_Click(object sender, EventArgs e)
        {//conectar a la ventana
         
            form_datos_clientes pBuscar = new form_datos_clientes();
            
            pBuscar.ShowDialog();
            if (pBuscar.clienteSeleccionado != null)
            {
                cargarCombos();
                clienteActual = pBuscar.clienteSeleccionado;
                textcod_cli.Text = pBuscar.clienteSeleccionado.Cod_client+"";
                textced_cli.Text = pBuscar.clienteSeleccionado.Ced_cliente;
                textnom_cli.Text = pBuscar.clienteSeleccionado.Nombres;
                textape_cli.Text = pBuscar.clienteSeleccionado.Apellidos;
                textemail_cli.Text = pBuscar.clienteSeleccionado.Email;
                texttelf_cli.Text = pBuscar.clienteSeleccionado.Telefono;
                textdir_cli.Text = pBuscar.clienteSeleccionado.Direccion;
                comboCiudad.Text = pBuscar.clienteSeleccionado.Ciudad + "";
                labelMensaje.Text = "";
               
                bloquearCampos(true);
                textced_cli.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Actualizar cliente
            try
            {
                if (validarCampos()/* && validaciones.validarCed(textced_cli.Text)*/)
                {
                    Cliente cl = new Cliente();

                    cl.Ced_cliente = textced_cli.Text;
                    cl.Nombres = textnom_cli.Text;
                    cl.Apellidos = textape_cli.Text;
                    cl.Email = textemail_cli.Text;
                    cl.Telefono = texttelf_cli.Text;
                    cl.Direccion = textdir_cli.Text;
                    cl.Ciudad = comboCiudad.SelectedValue+""; 
                    cl.Cod_client = Int32.Parse(textcod_cli.Text);
                    OperacionesCliente.ModificarClient(cl);
                    //limpiar todos los campos incluyendo el combo de ciudades
                   
                    limpiarCampos();
                    bloquearCampos(false);
                    quitarErrores();
                    labelMensaje.ForeColor = Color.Green;
                    labelMensaje.Text = "Modificado con exito !";//cambiar el color
                }
            }
            catch (Exception err)
            {
                labelMensaje.ForeColor = Color.Red;
                labelMensaje.Text = "Cliente ya existe !";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {//eliminar clientes
            if (validarCampos())
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el cliente??", "Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    int resultado = OperacionesCliente.EliminarClient(textcod_cli.Text);

                    if (resultado > 0)
                    {

                        //  MessageBox.Show("Alumnos Eliminado Correctamente", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarCampos();
                        bloquearCampos(false);
                        textcod_cli.Text = "";
                        quitarErrores();
                        labelMensaje.ForeColor = Color.Green;
                        labelMensaje.Text = "Cliente Eliminado Correctamente !";
                    }

                    else
                    {
                        MessageBox.Show("No se pudo Eliminar el cliente", "Ocurrio un error!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                    MessageBox.Show("Se cancelo la eliminacion", "Cancelado");
            }
        }

        public void cargarCombos() {

            comboCiudad.DataSource = OperacionCiudad.obtenerCiudad("");
            comboCiudad.DisplayMember = "nom_ciu";
            comboCiudad.ValueMember = "cod_ciu";

        }

        List<permisos> list = new List<permisos>();//lista para cargar los permisos
                
        private void form_cliente_Load(object sender, EventArgs e)
        {
            bloquearBotones(false);
            list = validaciones.ObtenerPermisosUser(Form1.ced_usuario);
             //validaciones.returnCedUser()
              foreach (var num in list)
              {
                  if (num.Insert == 1 && num.Update == 1 && num.Delete == 1 )//todos los permisos
                  {
                      bloquearBotones(true); //todos los permisos
                  }
                  if (num.Update == 1)//editar
                  {
                      btnActualizar.Enabled = true;
                      // MessageBox.Show("ingreso aki ");
                  }
                  if (num.Delete == 1)//eliminar
                  {
                      btnEliminar.Enabled = true;
                      /// MessageBox.Show("aki no ingreso");
                  }
                  if (num.Insert == 1)//Registrar
                  {
                      btnNuevo.Enabled = true;
                      btnRegistrar.Enabled = true;
                  }
                  bloquearCampos(false);
              }
        }
        private void textced_cli_TextChanged(object sender, EventArgs e)
        {
            
        }
        public Boolean validarCampos() {
            Boolean ok = true;
            String mens = "Campos requeridos :";
           // validarCed(textced_cli.Text)

           if ( !validaciones.soloNumeros(errorCed,textced_cli) || !validaciones.validarCed(textced_cli.Text)){
                ok = true;
                mens += "cedula incorrecta";
                
            }
            if (!validaciones.esRequerido(textnom_cli))
            {
                mens += ", Nombre";
                errorNom.SetError(textnom_cli, "Error en el nombre");
                ok = false;

            }
            if (!validaciones.esRequerido(textape_cli))
            {
               mens += ", Apellido";
                errorApe.SetError(textape_cli, "Error en el apelldio");
                ok = false;

            }
            if (!validaciones.ComprobarFormatoEmail(errorEmail, textemail_cli))
            {
                mens += ", Email";
                ok = false;

            }
            if (!validaciones.soloNumeros(errorTelf ,texttelf_cli))
            {
                mens += ", Telefono";
                ok = true;

            }
            if (!validaciones.esRequerido(textdir_cli))
            {
                mens += ", Direccion";
                errorDirec.SetError(textdir_cli, "dir");
                ok = false;

            }
            labelMensaje.ForeColor = Color.Red;
            labelMensaje.Text = mens;
            return ok;
        }

        private void textnom_cli_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorNom, textnom_cli);
        }

        private void textape_cli_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorApe, textape_cli);
        }

        private void textemail_cli_TextChanged(object sender, EventArgs e)
        {
            if(validaciones.ComprobarFormatoEmail(errorEmail, textemail_cli)){
                validaciones.quitarError(errorEmail, textemail_cli);
            }
        }

        private void texttelf_cli_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textdir_cli_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorDirec, textdir_cli);
        }
        public void limpiarCampos() {//Limpiar campos

            textcod_cli.Text="";//limpiar campos codigo
            textced_cli.Text="";
            textnom_cli.Text="";
            textape_cli.Text="";
            textemail_cli.Text="";
            texttelf_cli.Text="";
            textdir_cli.Text="";
            comboCiudad.Text = null;
          
        }
        public void bloquearCampos(Boolean ok)
        {//true se activan
            textced_cli.Enabled=ok;
            textnom_cli.Enabled = ok;
            textape_cli.Enabled = ok;
            textemail_cli.Enabled = ok;
            texttelf_cli.Enabled = ok;
            textdir_cli.Enabled= ok;
            comboCiudad.Enabled = ok;
        }
        public void bloquearBotones(Boolean ok)//bloquear botones
        {
            btnNuevo.Enabled = ok;
            btnRegistrar.Enabled = ok;
            btnActualizar.Enabled = ok;
            btnEliminar.Enabled = ok;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {//Conectar con la ventana ciudad
            form_ciudad fc = new form_ciudad();
            fc.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            textcod_cli.Text = OperacionesCliente.numCliente() + 1 + "";
            limpiarCampos();
            bloquearCampos(true);
            quitarErrores();
            btnRegistrar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        int cont = 0;
        private void button2_Click_1(object sender, EventArgs e)
        {//llenar campos de los clientes  solo es por codigo se debe validar para cedula
            try
            {
                cargarCombos();
                clienteActual = OperacionesCliente.CargarClienteCombo(textBusCed.Text);
                if (clienteActual.Cod_client != 0)
                {
                    textcod_cli.Text = clienteActual.Cod_client + "";
                    textced_cli.Text = clienteActual.Ced_cliente;
                    textnom_cli.Text = clienteActual.Nombres;
                    textape_cli.Text = clienteActual.Apellidos;
                    textemail_cli.Text = clienteActual.Email;
                    texttelf_cli.Text = clienteActual.Telefono;
                    textdir_cli.Text = clienteActual.Direccion;
                    comboCiudad.Text= clienteActual.Ciudad + "";
                     textBusCed.Text = "";
                    bloquearCampos(true);
                    textced_cli.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No existe");
                    textBusCed.Text = "";
                }
            }
            catch (Exception err) { }

        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {//Refrescar datos
            cargarCombos();
            quitarErrores();

        }

        private void texttelf_cli_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {//limpiar todo
            limpiarCampos();//limpiar todos los campos
            quitarErrores();
            comboCiudad.Text = "";
        }

        private void textBusCed_KeyPress(object sender, KeyPressEventArgs e)
        {
            validaciones.isCaracterValido(e.KeyChar);

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBusCed_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
