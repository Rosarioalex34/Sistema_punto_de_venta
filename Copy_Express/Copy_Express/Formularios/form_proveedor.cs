using Copy_Express.Clases;
using Copy_Express.Operaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copy_Express.Formularios
{
    public partial class form_proveedor : Form
    {
        public form_proveedor()
        {
            InitializeComponent();
        }
        public proveedores proveedorActual { get; set; }
        List<permisos> list = new List<permisos>();//lista para cargar los permisos
        private void form_proveedor_Load(object sender, EventArgs e)
        {


            bloquearBotones(false);
            list = validaciones.ObtenerPermisosUser(Form1.ced_usuario);
            foreach (var num in list)
            {
                if (num.Insert == 1 && num.Update == 1 && num.Delete == 1)//todos los permisos
                {
                    bloquearBotones(true); //todos los permisos
                }
                if (num.Update == 1)//editar
                {
                    buttonActualizar.Enabled = true;
                    // MessageBox.Show("ingreso aki ");
                }
                if (num.Delete == 1)//eliminar
                {
                    buttonEliminar.Enabled = true;
                    /// MessageBox.Show("aki no ingreso");
                }
                if (num.Insert == 1)//Registrar
                {
                    buttonNuevo.Enabled = true;
                    buttonGuardar.Enabled = true;
                }
                bloquearCampos(false);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {//Nuevo
            limpiarCampos();//limpiar los campos
            textCod_prov.Text = (OperacionesProv.numProvedor() + 1)+"";//Código del proveedor
            cargarCombos();
            quitarErrores();
             bloquearCampos(true);
            // buttonGuardar.Enabled = true;

        }
        //bloquear botones
        public void bloquearBotones(Boolean ok)
        {
            buttonNuevo.Enabled = ok;
            buttonGuardar.Enabled = ok;
            buttonEliminar.Enabled = ok;
            buttonActualizar.Enabled = ok;

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {//Guardar proveedor
            try {
                if (validarCampos())
                {
                    Clases.proveedores prov = new Clases.proveedores();
                    prov.Cod_prov = Int32.Parse(textCod_prov.Text);
                    prov.Ruc_ced = textCedRuc.Text;
                    prov.Nom_prv = textNomEmpr.Text;
                    prov.Direcc = textDirec.Text;
                    prov.Ciudad1 = comboCiu.SelectedValue + "";
                    prov.Telf = textTelf.Text;
                    prov.Email1 = textEmail.Text;
                    OperacionesProv.AgregarProveedor(prov);
                    limpiarCampos();
                    bloquearCampos(false);
                    //  bloquearBotones();
                    quitarErrores();
                    labelMensaje.ForeColor = Color.Green;
                    labelMensaje.Text = "Proveedor guardado !";                  
                }
                
            } catch (Exception err) { 
                labelMensaje.Text = "Proveedor ya esta Registrado";
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {//Actualizar proveedor
            try
            {
                if (validarCampos() )
                {
                    Clases.proveedores prov = new Clases.proveedores();
                    prov.Cod_prov = Int32.Parse(textCod_prov.Text);
                    prov.Ruc_ced = textCedRuc.Text;
                    prov.Nom_prv = textNomEmpr.Text;
                    prov.Direcc = textDirec.Text;
                    prov.Ciudad1 = comboCiu.SelectedValue + "";
                    prov.Telf = textTelf.Text;
                    prov.Email1 = textEmail.Text;
                    OperacionesProv.ModificarProveedor(prov);
                    limpiarCampos();//limpiar los comboBox                
                          bloquearCampos(false);
                                    // bloquearBotones();
                    quitarErrores();
                    labelMensaje.ForeColor = Color.Green;
                    labelMensaje.Text = "Proveedor Actualizado";
                }
               
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el Proveedor??", "Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int resultado = OperacionesProv.EliminarProveedor(textCod_prov.Text);
                    if (resultado > 0)
                    { //MessageBox.Show("Proveedor Eliminado Correctamente", "Proveedro Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarCampos();
                        buttonEliminar.Enabled = false;
                        buttonActualizar.Enabled = false;
                        buttonGuardar.Enabled = true;
                        labelMensaje.ForeColor = Color.Green;
                        labelMensaje.Text = "Proveedor Eliminado correctamente";
                        bloquearCampos(false);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Eliminar el Proveedor", "Ocurrio un error!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else MessageBox.Show("Se cancelo la eliminacion", "Cancelado");
            }
        }
        public void cargarCombos()
        {
            comboCiu.DataSource = OperacionCiudad.obtenerCiudad("");//llenar con ciudades
            comboCiu.DisplayMember = "nom_ciu";
            comboCiu.ValueMember = "cod_ciu";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Conectar con la ventana ciudad
            form_ciudad vnciu = new form_ciudad();
            vnciu.Show();
        }

        public proveedores proveedorSeleccionado { get; set; }

        public void cargarCombox() {
            try
            {
                cargarCombos();
                proveedorSeleccionado = OperacionesProv.cargarProveedor(textBuscar.Text); // OperacionesProv.ObtenerProveedor();
                if (proveedorSeleccionado.Cod_prov != 0)
                {
                    textCod_prov.Text = proveedorSeleccionado.Cod_prov + "";
                    textCedRuc.Text = proveedorSeleccionado.Ruc_ced;
                    textNomEmpr.Text = proveedorSeleccionado.Nom_prv;
                    textDirec.Text = proveedorSeleccionado.Direcc;
                    comboCiu.Text = proveedorSeleccionado.Ciudad1;
                    textTelf.Text = proveedorSeleccionado.Telf;
                    textEmail.Text = proveedorSeleccionado.Email1;

                    quitarErrores();
                    textBuscar.Text = "";
                    bloquearCampos(true);
                    textCedRuc.Enabled = false;
                }
                else
                {
                    MessageBox.Show("No existe Proveedor");
                    textBuscar.Text = "";
                }
            }
            catch (Exception err) { MessageBox.Show("Error"); }  
        }

        private void button1_Click(object sender, EventArgs e)
        {//Cargar cuadrado de textos
            cargarCombox();
            bloquearCampos(true);
            textCedRuc.Enabled = false;
        }
       
        private void button5_Click(object sender, EventArgs e)
        {//conectar con proveedores
            cargarCombos();//carga marca y categorias
            Proveedores pBuscar = new Proveedores();
            pBuscar.ShowDialog();
            
            if (pBuscar.proveedorSeleccionado != null)
            {
                
                bloquearCampos(true);
                proveedorActual = pBuscar.proveedorSeleccionado;
                textCod_prov.Text = pBuscar.proveedorSeleccionado.Cod_prov+"";
                textCedRuc.Text = pBuscar.proveedorSeleccionado.Ruc_ced;
                textNomEmpr.Text = pBuscar.proveedorSeleccionado.Nom_prv;
                textDirec.Text = pBuscar.proveedorSeleccionado.Direcc;
                comboCiu.Text = pBuscar.proveedorSeleccionado.Ciudad1;
                textTelf.Text = pBuscar.proveedorSeleccionado.Telf;
                textEmail.Text = pBuscar.proveedorSeleccionado.Email1;
                quitarErrores();
                /* buttonGuardar.Enabled = false;
                 buttonEliminar.Enabled = true;
                 buttonActualizar.Enabled = true;*/

                // textCedRuc.Enabled = false;

            }

        }
        public Boolean validarCampos()//Validar los campos
        {
            Boolean ok = true;
            String mens = "Campos requeridos o con errores :";
            if (!validaciones.soloNumeros(errorCed, textCedRuc) || !validaciones.validarCed(textCedRuc.Text))
            {
                ok = true;
                mens += "cedula o ruc incorrecto";

            }
            if (!validaciones.esRequerido(textNomEmpr))
            {
                mens += ", Empresa";
                errorEmpresa.SetError(textNomEmpr, "Error en el nombre");
                ok = false;

            }
         
            if (!validaciones.ComprobarFormatoEmail(errorEmail, textEmail))
            {
                mens += ", Email";
                ok = false;

            }
            if (!validaciones.soloNumeros(errorTelf, textTelf))
            {
                mens += ", Telefono";
                ok = false;

            }
            if (!validaciones.esRequerido(textDirec))
            {
                mens += ", Direccion";
                errorDirec.SetError(textDirec, "error direcion ");
                ok = false;

            }
            labelMensaje.ForeColor = Color.Red;
            labelMensaje.Text = mens;
            return ok;
        }

        private void textCedRuc_TextChanged(object sender, EventArgs e)
        {
            if (validaciones.soloNumeros(errorCed, textCedRuc))
            {
                validaciones.quitarError(errorCed, textCedRuc);
            }
        }

        private void textNomEmpr_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorEmpresa, textNomEmpr);
        }

        private void textEmail_TextChanged(object sender, EventArgs e)
        {
            if (validaciones.ComprobarFormatoEmail(errorEmail, textEmail))
            {
                validaciones.quitarError(errorEmail, textEmail);
            }
        }

        private void textTelf_TextChanged(object sender, EventArgs e)
        {
            if (validaciones.soloNumeros(errorTelf, textTelf))
            {
                validaciones.quitarError(errorTelf, textTelf);
            }
        }

        private void textDirec_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorDirec, textDirec);
        }
        public void limpiarCampos() {
            textCod_prov.Text = "";
            textCedRuc.Text = "";
            textNomEmpr.Text = "";
            textTelf.Text = "";
            textEmail.Text = "";
            textDirec.Text = "";
            comboCiu.Text = null;
            quitarErrores();
        }
        public void BloquearBotones(Boolean ok) {
            buttonGuardar.Enabled = ok;
            buttonEliminar.Enabled = ok;
            buttonActualizar.Enabled = ok;
        }
        public void quitarErrores() {
            validaciones.quitarError(errorCed, textCedRuc);
            validaciones.quitarError(errorEmpresa, textNomEmpr);
            validaciones.quitarError(errorEmail, textEmail);
            validaciones.quitarError(errorTelf, textTelf);
            validaciones.quitarError(errorDirec, textDirec);
            labelMensaje.Text = "";
        }
        public void bloquearCampos(Boolean ok) {
            textCedRuc.Enabled = ok;
            textNomEmpr.Enabled = ok;
            textTelf.Enabled = ok;
            textEmail.Enabled = ok;
            textDirec.Enabled = ok;
            comboCiu.Enabled = ok;
        }

        private void button2_Click(object sender, EventArgs e)
        {//Limpiar campos
            limpiarCampos();
            // bloquearBotones();
            

        }

        private void textBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {//Refrescar
            cargarCombos();
            //quitar errores
            quitarErrores();
        }

        private void textBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void textTelf_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void textCedRuc_KeyPress(object sender, KeyPressEventArgs e)
        {
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
    } 
}
