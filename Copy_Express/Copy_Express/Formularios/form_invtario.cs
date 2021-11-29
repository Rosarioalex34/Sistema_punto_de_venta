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
    public partial class form_invtario : Form
    {
        public form_invtario()
        {
            InitializeComponent();
            colorRow();
        }
        List<Producto> list = new List<Producto>();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {//llamr a los productos

            dataProductos.DataSource= OperacionesProducto.BuscarProductos(textBox1.Text);
            colorRow();
        }

        private void form_invtario_Load(object sender, EventArgs e)
        {
            //cargar comboBox
            
            llenarCombo();
            dataProductos.DataSource = OperacionesProducto.BuscarProductos("");
            colorRow();
        }

        private void button2_Click(object sender, EventArgs e)
        {//aqui para buscar por categorias no sirve
            //el nombre debe comvertirse a codigo
            dataProductos.DataSource = OperacionesProducto.BuscarProductos(comCategoria.SelectedValue + "");
            colorRow();
        }
        public void llenarCombo()
        {//Llenar los combos con categorias y marcas del fabricante
           comCategoria.DisplayMember = "des_cat";
            comCategoria.ValueMember = "cod_cat";
            comCategoria.DataSource = Operaciones_categ_marc.BuscarCategoria("");

        }
        //public void colorear los productos que estan por terminarse

        public void colorRow()
        {
            for (int i = 0; i < dataProductos.RowCount; i++)
            {
                       
                Int32 cantP = Int32.Parse(dataProductos.Rows[i].Cells[6].Value.ToString());
                if (cantP < 4) {
  
                    dataProductos.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                if (cantP < 7 && cantP >= 4) {
                    dataProductos.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }
                if (cantP >= 7 )
                {
                    dataProductos.Rows[i].DefaultCellStyle.BackColor = Color.LawnGreen;
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {//llevara hacer una compra
            form_compra fc = new form_compra();
           // fc.MdiParent = this;
            fc.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {//llevara hacer una venta
            form_venta fv = new form_venta();
          //  fv.MdiParent = this;
            fv.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //llevara a los productos
            form_producto fp= new form_producto();
           // fp.MdiParent = this;
            fp.ShowDialog();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataProductos.DataSource = OperacionesProducto.BuscarProductos("");
            colorRow();
            llenarCombo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataProductos.DataSource = OperacionesProducto.BuscarProductos("");
            colorRow();

        }

        private void button3_Click(object sender, EventArgs e)
        {//IMPRIMIR INVENTARIO
            //formRepInventario form = new formRepInventario();
            //reporteProductos form = new reporteProductos();
           // form.StartPosition = FormStartPosition.CenterScreen;
            //form.MdiParent = this;
            /*
            ReportDocument oRep = new ReportDocument();
            ParameterField pf = new ParameterField();
            ParameterFields pfs = new ParameterFields();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pf.Name = "@codCatg"; // variable del store procedure
            pdv.Value = comCategoria.SelectedValue;/// comb textNumFac.Text; ; // variable donde se  guarda el numero de factura
            pf.CurrentValues.Add(pdv);
            pfs.Add(pf);
            form.reportInventario.ParameterFieldInfo = pfs;
            oRep.Load(@"C:\Users\alm\Documents\Visual Studio 2015\App-Almacen_Computadoras\App-Almacen_Computadoras\Formularios\Reportes\rprteInventario.rpt");

            // oRep.Load(@"C:\Users\Usuario\Documents\GitHub\ProyectoProgramacion5\ProyectoProgV\ProyectoProgV\Presentacion\reportePrueba.rpt");
            form.reportInventario.ReportSource = oRep;
            */
            //form.Show();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
