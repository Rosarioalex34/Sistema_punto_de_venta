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
    public partial class form_datos_producto : Form
    {
        public form_datos_producto()
        {
            InitializeComponent();
        }

        public Producto productoSeleccionado { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {//Buscar producto
            tabla_prod.DataSource = null;
            tabla_prod.AllowUserToAddRows = false;//evita aparecer filas vacias
            tabla_prod.DataSource = OperacionesProducto.BuscarProductos(textbus_prod.Text);   
            tabla_prod.MultiSelect = false; //seleccionar una sola fila
            tabla_prod.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //elegir una fila de la columna
                   
            if (tabla_prod.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32(tabla_prod.CurrentRow.Cells[0].Value);
                productoSeleccionado = OperacionesProducto.ObtenerProducto(Id);
                this.Close();
            }
            else
            {
                MessageBox.Show("Aun no ha seleccionado Ningun Producto");
            }

        }

        private void tabla_prod_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {//aqui se debe seleccionar 
            Int32 Id = Convert.ToInt32(tabla_prod.CurrentRow.Cells[0].Value);
            productoSeleccionado = OperacionesProducto.ObtenerProducto(Id);
            this.Close();

        }

        private void textbus_prod_TextChanged(object sender, EventArgs e)
        {
            tabla_prod.DataSource = OperacionesProducto.BuscarProductos(textbus_prod.Text);
        }

        private void tabla_prod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void form_datos_producto_Load(object sender, EventArgs e)
        {
            tabla_prod.DataSource = null;
            tabla_prod.AllowUserToAddRows = false;//evita aparecer filas vacias
            tabla_prod.DataSource = OperacionesProducto.BuscarProductos(textbus_prod.Text);
            tabla_prod.MultiSelect = false; //seleccionar una sola fila
            tabla_prod.ReadOnly = true;
        }
    }
}
