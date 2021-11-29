using Copy_Express.Clases;
using Copy_Express.Formularios;
using Copy_Express.Formularios.ImgAplicacion;
using Copy_Express.Formularios.Reportes;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copy_Express
{
    public partial class Form1 : Form
    {
      
        public Form1()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmusuario.MdiParent = this;
            form_cliente fcli = new form_cliente();  
            fcli.StartPosition = FormStartPosition.CenterScreen;//centro de la pantalla
            //fcli.MdiParent = this;
            fcli.ShowDialog();
            fcli.WindowState = FormWindowState.Normal;
            // fcli.ShowDialog();
            //fcli.MdiParent = this;
        }

        private void registroProuctosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_producto fpr = new form_producto();
            fpr.StartPosition = FormStartPosition.CenterScreen;
            //fpr.StartPosition = FormStartPosition.CenterScreen;
            //fpr.MdiParent = this;
            fpr.ShowDialog();

           /* fpr.Definstance.MdiParent = this;
            parent.Definstance.Show();*/

        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            form_venta vnta= new form_venta();
            vnta.StartPosition = FormStartPosition.CenterScreen;
             vnta.ShowDialog();
            //vnta.MdiParent = this;
            //vnta.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_proveedor vnprov = new form_proveedor();
            vnprov.StartPosition = FormStartPosition.CenterScreen;
            vnprov.ShowDialog();
           // vnprov.MdiParent = this;
            //vnprov.Show();
        }

        private void comprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_compra fcom = new form_compra();
            fcom.StartPosition = FormStartPosition.CenterScreen;
           // fcom.ShowDialog();
          //  fcom.MdiParent = this;
            fcom.Show();
        }

        private void kardexToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void reporteDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //repClientes
          reporteClientes rc = new reporteClientes();
            rc.StartPosition = FormStartPosition.CenterScreen;
          //  rc.MdiParent = this;


           // ReportDocument crystalReport = new ReportDocument();
           // crystalReport.Load(@"C:\Users\alm\Documents\Visual Studio 2015\App-Almacen_Computadoras\App-Almacen_Computadoras\Formularios\Reportes\reportClientes.rpt");      
           // rc.repClientes.Refresh();
           // rc.repClientes.ReportSource = crystalReport;
            rc.Show();
          /*  form_repVentas rpVentas = new form_repVentas();
            ReportDocument oRep = new ReportDocument();
            ParameterField pf = new ParameterField();
            ParameterFields pfs = new ParameterFields();
            ParameterDiscreteValue pdv = new ParameterDiscreteValue();
            pf.Name = "@fecIni"; // variable del store procedure
            pf.Name = "@fecFin";
            pdv.Value = dateInicio.Value; ; // variable donde se  guarda el numero de factura
            pdv.Value = dateFin.Value;
            pf.CurrentValues.Add(pdv);
            pfs.Add(pf);
            rpVentas.reportVentasFac.ParameterFieldInfo = pfs;
            oRep.Load(@"C:\Users\alm\Documents\Visual Studio 2015\App-Almacen_Computadoras\App-Almacen_Computadoras\Formularios\Reportes\reportVentas.rpt");

            // oRep.Load(@"C:\Users\Usuario\Documents\GitHub\ProyectoProgramacion5\ProyectoProgV\ProyectoProgV\Presentacion\reportePrueba.rpt");
            rpVentas.reportVentasFac.ReportSource = oRep;
            rpVentas.Show();*/


        }

        private void personalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_usua f2 = new form_usua();
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.ShowDialog();
        }
        public static String ced_usuario="";
        private void Form1_Load(object sender, EventArgs e)
        {
            //SE EJECUTA AL COMIENZO


              ced_usuario = textCed.Text;
 }

        private void picture1_Click(object sender, EventArgs e)
        {
 }

        private void registroCiudadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_ciudad fc = new form_ciudad();
            fc.StartPosition = FormStartPosition.CenterScreen;
           // fc.MdiParent = this;
            fc.Show();
        }

        private void ventasRealizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form hv = new form();
           // hv.MdiParent = this;
            hv.StartPosition = FormStartPosition.CenterScreen;
            hv.Show();
           
        }

        private void cerraInicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void registroMarcasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //COnectar a la ventana registro de marcas
            form_marca fm = new form_marca();
            //fm.MdiParent = this;
            fm.StartPosition = FormStartPosition.CenterScreen;
            fm.Show();

        }

        private void registroCategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_categorias fcat = new form_categorias();
           // fcat.MdiParent = this;
            fcat.StartPosition = FormStartPosition.CenterScreen;
            fcat.Show();
        }

        private void inventarioProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {//COnectarse con la ventana inventario de productos

            form_invtario inv = new form_invtario();
           // inv.MdiParent = this;
            inv.StartPosition = FormStartPosition.CenterScreen;
            inv.Show();

        }

        private void desarrolladoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void comprasRealizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form_his_compras fhc = new form_his_compras();
           // fhc.MdiParent = this;
            fhc.StartPosition = FormStartPosition.CenterScreen;
            fhc.Show();
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void calendarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            form_calendar fhc = new form_calendar();
           // fhc.MdiParent = this;
            fhc.StartPosition = FormStartPosition.CenterScreen;
            fhc.Show();

        }

        private void cerrarSecionToolStripMenuItem_Click(object sender, EventArgs e)
        {//Cerrar cesion
            
           this.Hide();
          Principal p = new Principal();
           p.Show();
           // this.C;

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void reporteComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {//Ver las compras

            form_his_compras fhc = new form_his_compras();
            fhc.StartPosition = FormStartPosition.CenterScreen;
            fhc.ShowDialog();


        }

        private void reportesVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form fhv = new form();
            fhv.StartPosition = FormStartPosition.CenterScreen;
            fhv.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textCed_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
