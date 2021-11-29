using Copy_Express.Clases;
using Copy_Express.Formularios.ImgAplicacion;
using Copy_Express.Formularios.Reportes;
using Copy_Express.Operaciones;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copy_Express.Formularios
{
    public partial class form_compra : Form
    {
        public Producto productoActual { get; set; }
        static DataTable tabla = new DataTable();
        public proveedores proveedorActual { get; set; }

        form_datos_producto pBuscar = new form_datos_producto();

        public form_compra()
        {
            InitializeComponent();
        }

        private void form_compra_Load(object sender, EventArgs e)
        { try
            {
                DateTime Hoy = DateTime.Today;
                string fecha_actual = Hoy.ToString("yyyy/MM/dd");
                textFecha.Text = fecha_actual;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {//LLenar la tabla Compras
            llenarTablaCompras();


        }
          
        public void llenarTablaCompras() {//llenar la tabla
            int cantidad = 0;
            try
            {
                pBuscar.ShowDialog();//abrir ventana de productos

                if (pBuscar.productoSeleccionado != null)
                {try { 
                    do {
                        cantidad = Convert.ToInt32(Microsoft.VisualBasic.Interaction.InputBox("Ingrese cantidad:", "Ingreso de cantidades", "1", 100, 200));
                        if (cantidad <= 0) { MessageBox.Show("Ingrese una cantidad correcta"); }

                    } while (cantidad <= 0);
                    productoActual = pBuscar.productoSeleccionado;
                    try
                    {
                        dataCompra.Rows.Add(pBuscar.productoSeleccionado.Cod_prod,
                           cantidad,
                           pBuscar.productoSeleccionado.Nom_prod,
                           pBuscar.productoSeleccionado.Prec_vnta,
                           pBuscar.productoSeleccionado.Iva_prod,
                           0, pBuscar.productoSeleccionado.Prec_vnta * cantidad);
                        calcularCompra();//calcula los valores
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message + " aqui sale el error");
                    }
                }catch (Exception err) { MessageBox.Show("Producto no se agrego"); }
                }
            }
            catch (Exception err) { }
        }
        public void calcularCompra()
        {
            Decimal Sumtotal = 0;
            Decimal ivaTotal = 0;
            int cant = 0;
            Decimal total = 0;
            try
            {
                for (int i = 0; i < dataCompra.RowCount; i++)
                {                  
                    cant = Int32.Parse(dataCompra.Rows[i].Cells[1].Value.ToString());
                    total = Convert.ToDecimal(dataCompra.Rows[i].Cells[3].Value.ToString())* cant;
                    ivaTotal += Convert.ToDecimal(dataCompra.Rows[i].Cells[4].Value.ToString());
                    Sumtotal += Convert.ToDecimal(dataCompra.Rows[i].Cells[6].Value.ToString());
                }
                textSubtotal.Text = Sumtotal + "";
                textIva.Text = ivaTotal + "";
                textDesc.Text = "0";
                textTotal.Text = (Sumtotal + ivaTotal) + "";

            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }
       
        private void botonProv_Click(object sender, EventArgs e)
        {//Seleccionar proveedores
            Proveedores pBuscar = new Proveedores();
            pBuscar.ShowDialog();

            if (pBuscar.proveedorSeleccionado != null)
            {
                proveedorActual = pBuscar.proveedorSeleccionado;
                textRucProv.Text = pBuscar.proveedorSeleccionado.Ruc_ced;
                textProv.Text = pBuscar.proveedorSeleccionado.Nom_prv;
                textTelf.Text = pBuscar.proveedorSeleccionado.Telf;
                textDirec.Text = pBuscar.proveedorSeleccionado.Direcc;

            }
        }

        private void botonNuevo_Click(object sender, EventArgs e)
        {   //Codigo de la factura
            try
            {
                limpiarCampos();
                textNumFacCom.Text = Convert.ToInt32(OperacionesCompra.codFacturaCompra()) + 1 + "";
                cargarCombos();
            }
            catch (Exception err) { MessageBox.Show(err.Message); }

        }

        private void button6_Click(object sender, EventArgs e)
        {//quitar fila qeu no se utiliza
            try
            {
                dataCompra.Rows.RemoveAt(dataCompra.CurrentRow.Index);
                calcularCompra();
            }
            catch (Exception err) { MessageBox.Show("Elegir una fila"); }

        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {//Guardar Compara
            if (validarCampos()) {
               if (dataCompra.RowCount != 0) { 
                guardarCompra();
                limpiarCampos();


                    menLabel.ForeColor = Color.Green;
                    menLabel.Text = "Compra Realizada";

                }
                else { MessageBox.Show("Debe ingresar por lo menos un producto"); }

            }

        }
        public void guardarCompra() {
            try {
                Compra cm = new Compra();
                cm.Cod_compr = Convert.ToInt32(textNumFacCom.Text);
                cm.Ced_ruc_prov = textRucProv.Text;
                cm.Ced_empl = comboVendedor.SelectedValue+"";
                cm.Fecha_pedido = textFecha.Text;
                cm.Fecha_entrega = dateEntrega.Value.ToString("yyyy/MM/dd");// dateEntrega.Text;// Value.ToShortDateString("yyyy/MM/dd");
                cm.Est_compr = "";
                cm.Subtotal = Convert.ToDecimal(textSubtotal.Text);
                cm.Iva = Convert.ToDecimal(textIva.Text);
                cm.Desc = 0;
                cm.Total = Convert.ToDecimal(textTotal.Text);
                OperacionesCompra.AgregarCompra(cm);
                //Guardar detalle
                //aumentar productos
                guardarDetalleCompra();

            } catch (Exception err) { MessageBox.Show(err.Message); }

        }
        //Guardar detalle
        public void guardarDetalleCompra()
        {
            try
            {
                for (int i = 0; i < dataCompra.RowCount; i++)
                {
                    Detalle_compra dtv = new Detalle_compra();
                    dtv.Cod_compra = Convert.ToInt32(textNumFacCom.Text);
                    dtv.Cod_prod = Int32.Parse(dataCompra.Rows[i].Cells[0].Value.ToString()); ;
                    Int32 CodigoP = Int32.Parse(dataCompra.Rows[i].Cells[0].Value.ToString());
                    dtv.Cant_comp = Int32.Parse(dataCompra.Rows[i].Cells[1].Value.ToString());
                    Int32 cantP= Int32.Parse(dataCompra.Rows[i].Cells[1].Value.ToString());
                    dtv.Prec_compra = Convert.ToDecimal(dataCompra.Rows[i].Cells[3].Value.ToString());
                    dtv.Iva = Convert.ToDecimal(dataCompra.Rows[i].Cells[4].Value.ToString());
                    dtv.Descuento = Convert.ToDecimal(dataCompra.Rows[i].Cells[5].Value.ToString());
                    dtv.Total = Convert.ToDecimal(dataCompra.Rows[i].Cells[6].Value.ToString());
                    OperacionesCompra.AgregarDetalleCompra(dtv);
                    OperacionesProducto.aumentarStok(CodigoP, cantP);

                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }

        }
        public void cargarCombos()
        {

            comboVendedor.DataSource = OperacionesUser.obtenerUsuarios("");
            comboVendedor.DisplayMember = "apellidos";
            comboVendedor.ValueMember = "ced_usua";
            /* bloquearCampos(false);
             bloquearBotones(false);*/

        }
        //validar campos
        public Boolean validarCampos()
        {
            Boolean ok = true;
            String mens = "Campos requeridos :";
            if (!validaciones.esRequerido(textRucProv))
            {
                errorRucProv.SetError(textRucProv, "Debe ingresar un cliente");
                ok = false;
            }
            if (!validaciones.esRequerido(textNumFacCom))
            {
                errorNunFacC.SetError(textNumFacCom, "Debe ingresar numero de factura clic en nuevo");
                ok = false;
            }
            if (!validaciones.esRequerido(textTotal))
            {
                mens += ",Debe ingresar por lo menos un producto";
                errorTotalC.SetError(textTotal, "Debe ingresar por lo menos un producto");
                ok = false;
            }



            menLabel.ForeColor = Color.Red;
            menLabel.Text = mens;
            return ok;
        }
        public void quitarErrores()
        {
            validaciones.quitarError(errorTotalC, textTotal);
            validaciones.quitarError(errorNunFacC, textNumFacCom);
            validaciones.quitarError(errorRucProv, textRucProv);
            menLabel.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            quitarErrores();
            limpiarCampos();
        }

        private void textRucProv_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorRucProv, textRucProv);
        }

        private void textNumFacCom_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorNunFacC, textNumFacCom);
        }

        private void textTotal_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorTotalC, textTotal);
        }
        public void limpiarCampos()
        {//cancelar cmpra
            textSubtotal.Text = "";
            textIva.Text = "";
            textDesc.Text = "";
            textDirec.Text = "";
            textDesc.Text = "";
            textTotal.Text = "";
            textTelf.Text = "";
            textNumFacCom.Text = "";
            textSubtotal.Text = "";
            comboVendedor.Text = "";
            textRucProv.Text = "";
            textProv.Text = "";
            //limpiar tambien la tabla
            dataCompra.Rows.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            form_his_compras fcm = new form_his_compras();
            fcm.Show();
        }

    }
}
