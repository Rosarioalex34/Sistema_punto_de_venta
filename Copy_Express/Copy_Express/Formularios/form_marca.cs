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
    public partial class form_marca : Form
    {
        public form_marca()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//Codigo de la marca
            limpiarCampos();
            textcod_mar.Text = Operaciones_categ_marc.codigoMarca() + 1+"";
            quitarErrores();
            bloquearCampos(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {//Registro marca
            try
            {
                if (validarCampos()) {
                    marca mar = new marca();
                    mar.Cod_marca = Convert.ToInt32(textcod_mar.Text);
                    mar.Descripcion = textDesc_m.Text;
                    Operaciones_categ_marc.AgregarMarca(mar);
                    llenarTablaMarca();
                    quitarErrores();
                    mensLabel.ForeColor = Color.Green;
                    mensLabel.Text = "Se guardo Registro";
                    limpiarCampos();
                    bloquearCampos(false);
            }
            } catch (Exception err){
                MessageBox.Show("Dato ya registrado");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {//Editar marca
            try
            {
                if (validarCampos())
                {
                    marca mar = new marca();
                    mar.Cod_marca = Convert.ToInt32(textcod_mar.Text);
                    mar.Descripcion = textDesc_m.Text;
                    Operaciones_categ_marc.ModificarMarca(mar);
                    llenarTablaMarca();
                    quitarErrores();
                    limpiarCampos();
                    mensLabel.ForeColor = Color.Green;
                    mensLabel.Text = "Se Actualizo Registro";
                    bloquearCampos(false);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("Error al actualizar");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {//Eliminar marca
            if (validarCampos())
            {
                if (MessageBox.Show("Esta seguro que desea eliminar Marca??", "Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int resultado = Operaciones_categ_marc.EliminarCateg(textcod_mar.Text);
                    llenarTablaMarca();
                    if (resultado > 0)
                    {
                        MessageBox.Show("Marca Eliminado Correctamente", "Marca Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        quitarErrores();
                        limpiarCampos();
                        bloquearCampos(false);
                    }

                    else
                    {
                        MessageBox.Show("No se pudo Eliminar la marca", "Ocurrio un error!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                    MessageBox.Show("Se cancelo la eliminacion", "Cancelado");
            }
        }
        public void llenarTablaMarca() {
            try
            {
                dataMarca.DataSource = Operaciones_categ_marc.BuscarMarca(textBuscar.Text);
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataMarca.DataSource = Operaciones_categ_marc.BuscarMarca(textBuscar.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            llenarTablaMarca();
        }

        private void dataMarca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

                textcod_mar.Text = dataMarca.CurrentRow.Cells[0].Value+"";
                textDesc_m.Text = dataMarca.CurrentRow.Cells[1].Value+"";
        }
        List<permisos> list = new List<permisos>();
        private void form_marca_Load(object sender, EventArgs e)
        {
            bloquearBoton(false);
            list = validaciones.ObtenerPermisosUser(Form1.ced_usuario);
            foreach (var num in list)
            {
                if (num.Insert == 1 && num.Update == 1 && num.Delete == 1)//todos los permisos
                {
                    bloquearBoton(true); //todos los permisos
                }
                if (num.Update == 1)//editar
                {
                    btnActualizar.Enabled = true;
                    // MessageBox.Show("ingreso aki ");
                }
                if (num.Delete == 1)//eliminar
                {
                    btnEliminar.Enabled = true;
                    /// MessageBox.Show("aki no ingreso");
                }
                if (num.Insert == 1)//Registrar
                {
                    btnNuevo.Enabled = true;
                    btnGuardar.Enabled = true;
                }
                bloquearCampos(false);
            }
        }
        public void bloquearCampos(Boolean ok)
        {
            textDesc_m.Enabled = ok;
        }
        public void limpiarCampos()
        {
            textcod_mar.Text = "";
            textDesc_m.Text = "";
        }
        public void quitarErrores()
        {
            validaciones.quitarError(errorDecMar, textDesc_m);
            mensLabel.Text = "";
        }
        public void bloquearBoton(Boolean ok) {
            btnActualizar.Enabled = ok;
            btnGuardar.Enabled = ok;
            btnEliminar.Enabled = ok;
            btnNuevo.Enabled = ok;
        }
        public Boolean validarCampos()
        {
            Boolean ok = true;
            String mens = "";

            if (!validaciones.esRequerido(textDesc_m))
            {
                ok = false;
                mens += "Nombre de Marca";
                errorDecMar.SetError(textDesc_m, "Requiere este campo");

            }
            mensLabel.ForeColor = Color.Red;
            mensLabel.Text = mens;
            return ok;
        }

        private void textDesc_m_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorDecMar, textDesc_m);
        }

        private void dataMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textcod_mar.Text = dataMarca.CurrentRow.Cells[0].Value + "";
            textDesc_m.Text = dataMarca.CurrentRow.Cells[1].Value + "";
            quitarErrores();
            bloquearCampos(true);
        }
    }
}
