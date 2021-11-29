using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copy_Express.Formularios.Reportes
{
    public partial class reporteClientes : Form
    {
        public reporteClientes()
        {
            InitializeComponent();
        }

        private void reporteClientes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DataSetClientes.DataTable1' Puede moverla o quitarla según sea necesario.
            this.DataTable1TableAdapter.Fill(this.DataSetClientes.DataTable1);

            this.reportViewer1.RefreshReport();
        }
    }
}
