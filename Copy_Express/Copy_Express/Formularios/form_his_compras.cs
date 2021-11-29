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

namespace Copy_Express.Formularios.ImgAplicacion
{
    public partial class form_his_compras : Form
    {
        public form_his_compras()
        {
            InitializeComponent();
        }
        List<Compra> list = new List<Compra>();
        
        private void button1_Click(object sender, EventArgs e)
        {
            dataCompra.Rows.Clear();
            Decimal totalVntas = 0;
           // try
            {
                list = OperacionesCompra.cargarCompras(dateTimeInicio.Text, dateTimeFin.Text);
               
                foreach (var n in list)
                {
                    dataCompra.Rows.Add(n.Cod_compr, n.Ced_ruc_prov,OperacionesProv.requiProveedor(n.Ced_ruc_prov),
                        n.Fecha_pedido, n.Fecha_entrega, n.Subtotal,n.Iva,n.Total);
                    totalVntas += n.Total;
                }
                textTotal.Text = totalVntas + "";
            }
        }


        private void dataCompra_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //elegir el dato de la tabla
                Int32 Id = Convert.ToInt32(dataCompra.CurrentRow.Cells[0].Value);
                labelNumFac.Text = Id + "";
            }
            catch (Exception err) { }

        }
    }
}
