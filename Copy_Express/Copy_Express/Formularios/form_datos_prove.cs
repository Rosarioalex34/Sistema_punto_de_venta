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
    public partial class Proveedores : Form
    {
        public proveedores proveedorSeleccionado { get; set; }
        public Proveedores()
        {
            InitializeComponent();
        }

        private void form_datos_prove_Load(object sender, EventArgs e)
        {//CARGAR DATOS AUTOMATICAMENTE
            tablaProveedor.DataSource = OperacionesProv.BuscarProveedor(textBuscarProv.Text);


        }

        private void textBuscarProv_TextChanged(object sender, EventArgs e)
        {
            tablaProveedor.DataSource = OperacionesProv.BuscarProveedor(textBuscarProv.Text);

        }

        private void tablaProveedor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {//doble clic para obtener el dato de la tabla
            if (tablaProveedor.SelectedRows.Count == 1)
            {
                Int32 Id =Convert.ToInt32(tablaProveedor.CurrentRow.Cells[0].Value);
                proveedorSeleccionado = OperacionesProv.ObtenerProveedor(Id+"");
                this.Close();
            }
            else
            {
                MessageBox.Show("Aun no ha seleccionado Ningun cliente");
            }

        }



        private void button1_Click(object sender, EventArgs e)
        {
            tablaProveedor.DataSource = OperacionesProv.BuscarProveedor("");
        }

        private void tablaProveedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
