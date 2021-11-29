using Copy_Express.Clases;
using Copy_Express.Operaciones;
using System;
using System.Data;
using System.Windows.Forms;

namespace Copy_Express.Formularios
{
    public partial class form_datos_clientes : Form
    {
        public form_datos_clientes()
        {
            InitializeComponent();
        }
       
         public Cliente clienteSeleccionado { get; set; }
       // OperacionesCliente p = new OperacionesCliente();
        private void button1_Click(object sender, EventArgs e)
        {//cargar los datos de la data grviw
            tbl_clientes.DataSource = null;
            tbl_clientes.AllowUserToAddRows = false;//evita aparecer filas vacias
            tbl_clientes.DataSource = OperacionesCliente.BuscarCliente(textBus_client.Text);
            tbl_clientes.MultiSelect = false; //seleccionar una sola fila
            tbl_clientes.ReadOnly = true;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tbl_clientes.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32(tbl_clientes.CurrentRow.Cells[0].Value);
                clienteSeleccionado = OperacionesCliente.ObtenerCliente(Id+"");
                tbl_clientes.ClearSelection();
                this.Close();
            }
            else
            {
                MessageBox.Show("Aun no ha seleccionado Ningun cliente");
            }
        }

        private void tbl_clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void form_datos_clientes_Load(object sender, EventArgs e)
        {
            tbl_clientes.DataSource = OperacionesCliente.BuscarCliente(textBus_client.Text);
        }

        private void textBus_client_TextChanged(object sender, EventArgs e)
        {//haber que pasa
            tbl_clientes.DataSource = OperacionesCliente.BuscarCliente(textBus_client.Text);

        }

        private void tbl_clientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {//doble clic
            if (tbl_clientes.SelectedRows.Count == 1)
            {
                Int32 Id = Convert.ToInt32(tbl_clientes.CurrentRow.Cells[0].Value);
                clienteSeleccionado = OperacionesCliente.ObtenerCliente(Id+"");
                this.Close();
            }
            else
            {
                MessageBox.Show("Aun no ha seleccionado Ningun cliente");
            }

        }
    }
}
