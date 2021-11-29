using Copy_Express.Clases;
using Copy_Express.Formularios.Reportes;
using Copy_Express.Operaciones;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }
        List<venta> lis = new List<venta>();
        
       // List<Cliente> lclnte = new List<Cliente>();

        private void btnAceptar_Click(object sender, EventArgs e)
        {//Cargar data gredviw
            dataVentas.Rows.Clear();
            Decimal totalVntas = 0;

            lis = OperacionVenta.cargarVentas(dateInicio.Text, dateFin.Text);

            foreach (var n in lis) {
                dataVentas.Rows.Add(n.Cod_vnta,n.Ced_client, OperacionesCliente.requiereNomCliente(n.Ced_client), n.Fecha,n.Subtotal,n.Iva,n.Total);
                totalVntas += n.Total;
            }
            textTotal.Text = totalVntas+"";
        }

        private void dataVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {//elegir el numero para imprimir de la factura

            Int32 Id = Convert.ToInt32(dataVentas.CurrentRow.Cells[0].Value);
            labelNumFac.Text = Id + "";

        }
    }
}
