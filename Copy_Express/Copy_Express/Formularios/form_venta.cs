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
using System.Globalization;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Copy_Express.Formularios.Reportes;

namespace Copy_Express.Formularios
{
    public partial class form_venta : Form
    {
        public form_venta()
        {
            InitializeComponent();
        }
        public Cliente ClienteActual { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {//Nuevo producto
            textNumFac.Text = OperacionVenta.codFactura();//(Convert.ToInt32(OperacionVenta.codFactura()) + 1)+"";
            cargarCombos();
            quitarErrores();
            limpiarCampos();
        }
        public void cargarCombos()
        {
            comboEmpleado.DataSource = OperacionesUser.obtenerUsuarios(Form1.ced_usuario);
            comboEmpleado.DisplayMember = "apellidos";
            comboEmpleado.ValueMember = "ced_usua";
        }


        private void button3_Click(object sender, EventArgs e)
        {//Cargar cliente
            form_datos_clientes pBuscar = new form_datos_clientes();
            pBuscar.ShowDialog();

            if (pBuscar.clienteSeleccionado != null)
            {
                ClienteActual = pBuscar.clienteSeleccionado;
                textCedCl.Text = pBuscar.clienteSeleccionado.Ced_cliente;
                textNomClie.Text = pBuscar.clienteSeleccionado.Nombres +"  "+ pBuscar.clienteSeleccionado.Apellidos;
                textTelfClie.Text = pBuscar.clienteSeleccionado.Telefono;
                textDirClie.Text = pBuscar.clienteSeleccionado.Direccion;

            }

        }
        DateTime Hoy = DateTime.Now;

        private void form_venta_Load(object sender, EventArgs e)
        {//
            try
            {
                
               // textFecha.Text = Hoy.ToShortDateString();
               string fecha_actual = Hoy.ToString("yyyy/MM/dd");
                //string fecha_actual = Hoy.ToString("yyyy/mm/dd");
               textFecha.Text = fecha_actual;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        form_datos_producto pBuscar = new form_datos_producto();

        private void button4_Click(object sender, EventArgs e)
        {//Agregar productos a la tabla boton seleccionar
            llenarTablaCompras();


    }
        public Producto productoActual { get; set; }

        public void llenarTablaCompras()
        {//llenar la tabla
            try
            {
                pBuscar.ShowDialog();//abrir ventana de productos
                int cantidad;
                if (pBuscar.productoSeleccionado != null)
                {
                    productoActual = pBuscar.productoSeleccionado;
                    do
                    {
                       cantidad = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Ingrese cantidad:", "Ingreso de cantidades", "1", 100, 150));
                        
                        if (cantidad > pBuscar.productoSeleccionado.Cant_prod )
                        {
                            MessageBox.Show("La cantidad esta exedida ingrese una cantidad menor");
                       }
                        if (cantidad <=0)
                        {
                            MessageBox.Show("Ingrese datos correctos");
                        }

                    } while (cantidad> pBuscar.productoSeleccionado.Cant_prod || cantidad <=0);

                    try
                    {                      
                        dataVntas.Rows.Add(pBuscar.productoSeleccionado.Cod_prod,
                           cantidad,
                           pBuscar.productoSeleccionado.Nom_prod,
                           pBuscar.productoSeleccionado.Prec_vnta,
                           pBuscar.productoSeleccionado.Iva_prod,
                           0, pBuscar.productoSeleccionado.Prec_vnta * cantidad);
                            calcularVenta();//calcula los valores
                    }
                    catch (Exception err)
                    {

                      MessageBox.Show( "Ingresar números");
                    }
                }
            }
            catch (Exception err) {
                MessageBox.Show("Producto no se agrego");
            }

        }
        public void calcularVenta()
        {
            Decimal Sumtotal = 0;
            Decimal ivaTotal = 0;
            int cant = 0;
            Decimal total = 0;
            try
            {
                for (int i = 0; i < dataVntas.RowCount; i++)
                {
                    cant = Int32.Parse(dataVntas.Rows[i].Cells[1].Value.ToString());
                    total = Convert.ToDecimal(dataVntas.Rows[i].Cells[3].Value.ToString()) * cant;
                    ivaTotal += Convert.ToDecimal(dataVntas.Rows[i].Cells[4].Value.ToString());
                    Sumtotal += Convert.ToDecimal(dataVntas.Rows[i].Cells[6].Value.ToString());
                }
                textSubtotal.Text = Sumtotal + "";
                textIva.Text = ivaTotal + "";
                textDesc.Text = "0";
                textTotal.Text = (Sumtotal + ivaTotal) + "";
            }
            catch (Exception err) { MessageBox.Show(err.Message+"aqui el error"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {//Guardar Factura
            if (validarCampos())
            if (dataVntas.RowCount!=0) 
            //  if (textCedCl.Text != "" && comboEmpleado.Text !="" )
            {
                try {
                     guardarFactVenta();
                        limpiarCampos();
                        MessageBox.Show("Venta Realizada con exito");

                      
                    }
                catch (Exception err) { MessageBox.Show(err.Message); }
            }else{ MessageBox.Show("Debe ingresar por lo menos un producto"); }
        }
        //Guardar Factura
        public void guardarFactVenta()
        {
            try {
                venta vn = new venta();
                vn.Cod_vnta = Convert.ToInt32(textNumFac.Text);
                vn.Ced_client = textCedCl.Text;
                vn.Ced_empl = comboEmpleado.SelectedValue+"";
                vn.Fecha = textFecha.Text;            
                vn.Forma_pago = "contado";
                vn.Est_vnta = "pagado";
                vn.Subtotal = Convert.ToDecimal(textSubtotal.Text);
                vn.Iva = Convert.ToDecimal(textIva.Text);
                vn.Desc = Convert.ToDecimal(textDesc.Text);
                vn.Total = Convert.ToDecimal(textTotal.Text);
                OperacionVenta.AgregarVenta(vn);
                guardarDetalle();
                quitarErrores();
            } catch (Exception err){
                MessageBox.Show("Existe un error");
            }
        }
        public void guardarDetalle() {
            try
            {
                for (int i = 0; i < dataVntas.RowCount; i++)
                {
                    detalle_venta dtv = new detalle_venta();
                    dtv.Cod_vnta = textNumFac.Text;
                    Int32 codigoP = Int32.Parse(dataVntas.Rows[i].Cells[0].Value.ToString()); ;
                    dtv.Cod_prod = codigoP;//Asignando codigo de la tabla 
                    Int32 cantP = Int32.Parse(dataVntas.Rows[i].Cells[1].Value.ToString());
                    dtv.Cant = cantP;
                    dtv.Prec_unit = Convert.ToDecimal(dataVntas.Rows[i].Cells[3].Value.ToString());
                    dtv.Iva = Convert.ToDecimal(dataVntas.Rows[i].Cells[4].Value.ToString());
                    dtv.Descuento = Convert.ToDecimal(dataVntas.Rows[i].Cells[5].Value.ToString());
                    dtv.Total = Convert.ToDecimal(dataVntas.Rows[i].Cells[6].Value.ToString());
                    OperacionVenta.AgregarDetalle(dtv);
                    //Disminuir stok
                    OperacionesProducto.disminuirStok(codigoP,cantP);//Disminuir el stok de productos
                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }

            }
        public void limpiarCampos() {//cancelar venta
           // textNumFac.Text = "";
            textSubtotal.Text =  "";
            textIva.Text =  "";
            textDesc.Text = "";
            textDirClie.Text = "";
            textNomClie.Text = "";
            textTelfClie.Text = "";
            textTotal.Text = "";
            textCedCl.Text="";
            comboEmpleado.Text="";
            textSubtotal.Text="";
            //limpiar tambien la tabla
            dataVntas.Rows.Clear();
        }
        private void bottonQuitar_Click(object sender, EventArgs e)
        {//QUITAR FILAS DE LA TABLA
            try
            {
                dataVntas.Rows.RemoveAt(dataVntas.CurrentRow.Index);
                calcularVenta();
            }
            catch (Exception err) { }

        }

        private void button5_Click(object sender, EventArgs e)
        {//cancelar la venta
            limpiarCampos();
            quitarErrores();
        }
        //aqui  las validaciones
        public Boolean validarCampos()
        {
            Boolean ok = true;
            String mens = "Campos requeridos :";
            if (!validaciones.esRequerido(textCedCl))
            {
               // mens += ",Ingresar cliente";
                errorCed.SetError(textCedCl, "Debe ingresar un cliente");
                ok = false;
            }
            if (!validaciones.esRequerido(textNumFac))
            {
               // mens += ",Num Fac";
                errorNumFac.SetError(textNumFac, "Debe ingresar numero de factura clic en nuevo");
                ok = false;
            }
            if (!validaciones.esRequerido(textTotal))
            {
                mens += ",Debe ingresar por lo menos un producto";
                errorTotal.SetError(textTotal, "Debe ingresar numero de factura clic en nuevo");
                ok = false;
            }



            menLabel.ForeColor = Color.Red;
             menLabel.Text = mens;
            return ok;
        }

        private void comboEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //validaciones.quitarErrorCombo(errorCombo, comboEmpleado);
        }

        private void textCedCl_TextChanged(object sender, EventArgs e)
        {

            validaciones.quitarError(errorCed,textCedCl);
        }

        private void textFecha_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textNumFac_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorNumFac, textNumFac);
        }

        private void textTotal_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorTotal, textTotal);
        }
        public void quitarErrores()
        {
            validaciones.quitarError(errorTotal, textTotal);
            validaciones.quitarError(errorNumFac, textNumFac);
            validaciones.quitarError(errorCed, textCedCl);
            menLabel.Text = "";
            
        }

        private void button6_Click(object sender, EventArgs e)
        {//mostrar las ventas
            form p = new form();
            p.Show();

        }
    }
}
