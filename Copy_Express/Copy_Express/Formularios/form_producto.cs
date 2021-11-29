using Copy_Express.Clases;
using Copy_Express.Operaciones;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Copy_Express.Formularios
{
    public partial class form_producto : Form
    {
        public form_producto()
        {
            InitializeComponent();
        }
        public Producto productoActual { get; set; }


        private void reg_prod_Click(object sender, EventArgs e)//Registrar productos
        {
            try
            {
                if (validarCampos()) { 
                Producto pr = new Producto();
                pr.Cod_prod = Convert.ToInt32(textcod_prod.Text);
                pr.Nom_prod = textnom_prod.Text;
                pr.Marca = comboMarca.SelectedValue + "";
                pr.Prec_com = Decimal.Parse(textprec_prod.Text/*.Replace(",", ".")*/);
                pr.Prec_vnta = Decimal.Parse(textPrecVenta.Text/*.Replace(",", ".")*/);
                pr.Iva_prod = prodIva();
                pr.Cant_prod = Int32.Parse(textcant_prod.Text);
                pr.Cod_categ = comboCategoria.SelectedValue + "";
                OperacionesProducto.AgregarProducto(pr);
                    limpiarCampos();
                    bloquearCampos(false);
                    quitarErrores();
                    menLabel.ForeColor = Color.Green;
                    menLabel.Text = "Producto Registrado !";
                }
            }
            catch (Exception err)
            {
                //bloquearCampos(false);
                menLabel.ForeColor = Color.Red;
                menLabel.Text = "Error al ingresar datos !";}
        }

        private void button3_Click(object sender, EventArgs e)//actualizar
        {
            try
            {
                if (validarCampos())
                {
                    Producto pr = new Producto();
                    pr.Cod_prod = Convert.ToInt32(textcod_prod.Text);
                    pr.Nom_prod = textnom_prod.Text;
                    pr.Marca = comboMarca.SelectedValue + "";
                    pr.Prec_com = Decimal.Parse(textprec_prod.Text);
                    pr.Prec_vnta = Decimal.Parse(textPrecVenta.Text);
                    pr.Iva_prod = prodIva();
                    pr.Cant_prod = Int32.Parse(textcant_prod.Text);
                    pr.Cod_categ = comboCategoria.SelectedValue + "";
                    OperacionesProducto.ModificarProducto(pr);
                    limpiarCampos();
                    bloquearCampos(false);
                    quitarErrores();
                    menLabel.ForeColor = Color.Green;
                    menLabel.Text = "Producto Modificado con éxito !";
                }
            }
            catch (Exception err)
            {
                bloquearCampos(false);
                //MessageBox.Show(err.Message + "ocurrio un error");
            }
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {//Eliminar
            if (validarCampos())
            {
                if (MessageBox.Show("Esta seguro que desea eliminar el Producto??", "Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    int resultado = OperacionesProducto.EliminarProducto(textcod_prod.Text);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Producto Eliminado Correctamente", "Producto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarCampos();
                        quitarErrores();
                        bloquearCampos(false);
                        menLabel.ForeColor = Color.Green;
                        menLabel.Text = "Producto Eliminado !";
                    }

                    else
                    {
                        MessageBox.Show("No se pudo Eliminar el Producto", "Ocurrio un error!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                    MessageBox.Show("Se cancelo la eliminacion", "Cancelado");
            }
            else {
                menLabel.ForeColor = Color.Red;
                menLabel.Text = "No existe elemento a eliminar"; }
        }

        private void button1_Click(object sender, EventArgs e)
        {//codigo producto
            limpiarCampos();
            textcod_prod.Text = OperacionesProducto.numProducto() + 1 +"";
            llenarCombo();
            quitarErrores();
            bloquearCampos(true);
        }

        private void button5_Click(object sender, EventArgs e)//llamar clientes desde la tabla
        {
            form_datos_producto pBuscar = new form_datos_producto();
            pBuscar.ShowDialog();

            if (pBuscar.productoSeleccionado != null)
            { //cargar combos
                bloquearCampos(true);
                llenarCombo();
                productoActual = pBuscar.productoSeleccionado;
                textcod_prod.Text = pBuscar.productoSeleccionado.Cod_prod+"";
                textnom_prod.Text = pBuscar.productoSeleccionado.Nom_prod;
                comboMarca.Text = pBuscar.productoSeleccionado.Marca + "";
                textprec_prod.Text = pBuscar.productoSeleccionado.Prec_com + "";
                textPrecVenta.Text = pBuscar.productoSeleccionado.Prec_com + "";
                checkIva.Text = pBuscar.productoSeleccionado.Iva_prod + "";
                textcant_prod.Text = pBuscar.productoSeleccionado.Cant_prod + "";
                comboCategoria.Text = pBuscar.productoSeleccionado.Cod_categ + "";              
                quitarErrores();

            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void checkIva_CheckedChanged(object sender, EventArgs e)
        {//aparecer el iva
           /* if (checkIva.Checked == true)
            { textIva.Text = "0,12"; }
            else { textIva.Text = ""; }*/
        }

        private void textprec_prod_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorPrecCom, textprec_prod);
        }
        public  Decimal prodIva() {
            Decimal mIva = 0;
            if (checkIva.Checked == true)
            {   mIva = 0.12m;
                mIva.ToString().Replace(",", ".");
             }
            return mIva;
        }
        public void llenarCombo() {//Llenar los combos con categorias y marcas del fabricante
            comboCategoria.DisplayMember = "des_cat";
            comboCategoria.ValueMember = "cod_cat";
            comboCategoria.DataSource = Operaciones_categ_marc.BuscarCategoria("");

            comboMarca.DisplayMember = "descripcion";
            comboMarca.ValueMember = "cod_marca";
            comboMarca.DataSource = Operaciones_categ_marc.BuscarMarca("");

        }

        private void button3_Click_1(object sender, EventArgs e)
        {//Conectar con marca del producto
            form_marca fm = new form_marca();
            fm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_categorias fcg = new form_categorias();
            fcg.Show();

        }
        List<permisos> list = new List<permisos>();//lista para cargar los permisos
        private void form_producto_Load(object sender, EventArgs e)
        {//aqui debo bloquear todo los botones
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
                    btnActualizar_produc.Enabled = true;
                    // MessageBox.Show("ingreso aki ");
                }
                if (num.Delete == 1)//eliminar
                {
                    button_eliminar.Enabled = true;
                    /// MessageBox.Show("aki no ingreso");
                }
                if (num.Insert == 1)//Registrar
                {
                    btnNuevo.Enabled = true;
                    btnreg_prod.Enabled = true;
                }
                bloquearCampos(false);
            }
        }
        public void bloquearBotones(Boolean ok) {
            btnNuevo.Enabled = ok;
            btnreg_prod.Enabled =ok;
            button_eliminar.Enabled = ok;
            btnActualizar_produc.Enabled = ok;

        }
        public void bloquearCampos(Boolean ok)
        {
           // textcod_prod.Enabled = ok;
            textnom_prod.Enabled  = ok;
            textprec_prod.Enabled = ok;
            textPrecVenta.Enabled = ok;
            textcant_prod.Enabled = ok;
            comboCategoria.Enabled = ok;
            comboMarca.Enabled = ok;


        }
        public void limpiarCampos() {
            textcod_prod.Text="";
            textnom_prod.Text="";
           textprec_prod.Text="";
            textPrecVenta.Text = "";/*.Replace(",", ".")*/
           textcant_prod.Text="";

        }
        //validar los datos

        public Boolean validarCampos()
        {
            Boolean ok = true;
            String mens = "Campos requeridos :";
            if (!validaciones.esRequerido(textnom_prod))
            {
                mens += ", Nombre";
                errorProd.SetError(textnom_prod, "Error en el nombre producto");
                ok = false;
            }
                   
            if (!validaciones.soloNumeros(errorCant, textcant_prod))
            {
                mens += ", Cantidad";
                ok = false;
            }
            if (!validaciones.esRequerido(textprec_prod))
            {
                mens += ", Precio compra ";
                errorPrecCom.SetError(textprec_prod,"Debe ingresar números con la coma decimal");
                ok = false;
            }
            if (!validaciones.esRequerido(textPrecVenta))
            {
                mens += ", Precio compra ";
                errorPrecVnta.SetError(textPrecVenta,"Debe ingresar números con la coma decimal");
                ok = false;
            }
            menLabel.ForeColor = Color.Red;
            menLabel.Text = mens;
            return ok;
        }
        public void quitarErrores()
        {
            validaciones.quitarError(errorProd, textnom_prod);
            validaciones.quitarError(errorCant, textcant_prod);
           validaciones.quitarError(errorPrecCom, textprec_prod);
            validaciones.quitarError(errorPrecVnta, textPrecVenta);
            menLabel.Text = "";
        }

 
        private void textprec_prod_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permite ingresar solo numeros
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            int codigo = Convert.ToInt32( e.KeyChar);
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || codigo == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
           
        }

        private void textPrecVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            //permite ingresar solo numeros
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;
            int codigo = Convert.ToInt32( e.KeyChar);
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator || codigo == 8)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }

        private void textnom_prod_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorProd, textnom_prod);
        }

        private void textPrecVenta_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorPrecVnta, textPrecVenta);
        }

        private void textcant_prod_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorCant, textcant_prod);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {//Refrescar datos
            llenarCombo();
            quitarErrores();
        }

        private void button4_Click(object sender, EventArgs e)
        {//Limpiar

            limpiarCampos();
            quitarErrores();
            comboCategoria.Text = null;
            comboMarca.Text = null;
        }

        private void textcant_prod_KeyPress(object sender, KeyPressEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            form_venta vnta = new form_venta();
            vnta.StartPosition = FormStartPosition.CenterScreen;
            vnta.ShowDialog();
            //vnta.MdiParent = this;
            //vnta.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            form_invtario inv = new form_invtario();
            // inv.MdiParent = this;
            inv.StartPosition = FormStartPosition.CenterScreen;
            inv.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            //COnectar a la ventana registro de marcas
            form_marca fm = new form_marca();
            //fm.MdiParent = this;
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            form_categorias fcat = new form_categorias();
            // fcat.MdiParent = this;
            fcat.StartPosition = FormStartPosition.CenterScreen;
            fcat.Show();
        }
    }
}
