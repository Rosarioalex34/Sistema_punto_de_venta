using Copy_Express.Clases;
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
    public partial class form_categorias : Form
    {
        public form_categorias()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            textcodCatg.Text =  Operaciones.Operaciones_categ_marc.codigoCat() + 1+"";
            quitarErrores();
            bloquearCampos(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try {
                if (validarCampos())
                {
                    categoria catg = new categoria();
                    catg.Cod_cat = Convert.ToInt32(textcodCatg.Text);
                    catg.Des_cat = textDesCatg.Text;
                    Operaciones.Operaciones_categ_marc.AgregarCateg(catg);
                    llenarTablaCat();
                    quitarErrores();
                    mensLabel.ForeColor = Color.Green;
                    mensLabel.Text = "Se guardo Registro";
                    limpiarCampos();
                    bloquearCampos(false);
                }
            } catch (Exception err) { MessageBox.Show(err.Message); }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (validarCampos())
                {
                    categoria catg = new categoria();
                    catg.Cod_cat = Convert.ToInt32(textcodCatg.Text);
                    catg.Des_cat = textDesCatg.Text;
                    Operaciones.Operaciones_categ_marc.ModificarCateg(catg);
                    llenarTablaCat();
                    quitarErrores();
                    mensLabel.ForeColor = Color.Green;
                    mensLabel.Text = "Se Actualizo Registro";
                    limpiarCampos();
                    bloquearCampos(false);
                }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataCategorias.DataSource = Operaciones.Operaciones_categ_marc.BuscarCategoria(textBox3.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataCategorias.DataSource = Operaciones.Operaciones_categ_marc.BuscarCategoria("");

        }
        
        private void dataCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {//elegir el dato
            Int32 Id = Convert.ToInt32(dataCategorias.CurrentRow.Cells[0].Value);
            String nomCat = Convert.ToString(dataCategorias.CurrentRow.Cells[1].Value);
            textcodCatg.Text = Id+"";
            textDesCatg.Text = nomCat;
            bloquearCampos(true);
            quitarErrores();
        }
        public void bloquearCampos(Boolean ok)
        {
           
            textDesCatg.Enabled = ok;


        }
        public void limpiarCampos()
        {
            textcodCatg.Text = "";
            textDesCatg.Text = "";


        }
        public void quitarErrores()
        {

            validaciones.quitarError(errorDesc, textDesCatg);
            mensLabel.Text = "";
        }
        public void bloquearBoton(Boolean ok)
        {
            btnActualizar.Enabled = ok;
            btnGuardar.Enabled = ok;
            btnDelete.Enabled = ok;
            btnNuevo.Enabled = ok;
        }
        public Boolean validarCampos()
        {
            Boolean ok = true;
            String mens = "";
            if (!validaciones.esRequerido(textDesCatg))
            {
                ok = false;
                mens += "Nombre de Categoria";
                errorDesc.SetError(textDesCatg, "Requiere este campo");
            }
            mensLabel.ForeColor = Color.Red;
            mensLabel.Text = mens;
            return ok;
        }
        List<permisos> list = new List<permisos>();
        private void form_categorias_Load(object sender, EventArgs e)
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
                }
                if (num.Delete == 1)//eliminar
                {
                    btnDelete.Enabled = true;
                }
                if (num.Insert == 1)//Registrar
                {
                    btnNuevo.Enabled = true;
                    btnGuardar.Enabled = true;
                }
                bloquearCampos(false);
            }
        }
        public void llenarTablaCat() {
            dataCategorias.DataSource = Operaciones.Operaciones_categ_marc.BuscarCategoria("");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                if (MessageBox.Show("Esta seguro que desea eliminar Categoria?", "Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int resultado = Operaciones.Operaciones_categ_marc.EliminarCateg(textcodCatg.Text);
                    llenarTablaCat();
                    if (resultado > 0)
                    {
                        MessageBox.Show(" Eliminado Correctamente", "Categoria Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         llenarTablaCat();
                        quitarErrores();
                        limpiarCampos();
                        bloquearCampos(false);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo Eliminar el cliente", "Ocurrio un error!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                    MessageBox.Show("Se cancelo la eliminacion", "Cancelado");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarCampos();
            quitarErrores();
        }

        private void dataCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 Id = Convert.ToInt32(dataCategorias.CurrentRow.Cells[0].Value);
            String nomCat = Convert.ToString(dataCategorias.CurrentRow.Cells[1].Value);
            textcodCatg.Text = Id + "";
            textDesCatg.Text = nomCat;
            bloquearCampos(true);
            quitarErrores();
        }
    }
}
