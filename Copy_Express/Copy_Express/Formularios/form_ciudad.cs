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
    public partial class form_ciudad : Form
    {
        ciudad ciu = new ciudad();
        public form_ciudad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {//Guardar Ciudad
            try {
                if (validarCampos())
                {
                    ciu.cod_ciu = Int32.Parse(textcod_ciu.Text);
                    ciu.nom_ciu = textNom_ciu.Text;
                    OperacionCiudad.AgregarCiudad(ciu);
                    llenarTablaCiudad();
                    limpiarCampos();
                    quitarErrores();
                    bloquearCampos(false);
                    mensLabel.ForeColor = Color.Green;
                    mensLabel.Text = "Ciudad Registrada !";

                }
            } catch (Exception err) {
                mensLabel.ForeColor = Color.Red;
                mensLabel.Text = "Ciudad ya esta Registrada !";
            }
        }

            private void button2_Click(object sender, EventArgs e)
        {//Editar
            try
            {
                if (validarCampos())
                {
                    ciu.cod_ciu = Int32.Parse(textcod_ciu.Text);
                    ciu.nom_ciu = textNom_ciu.Text;
                    OperacionCiudad.ModificarCiudad(ciu);
                    llenarTablaCiudad();
                    limpiarCampos();
                    quitarErrores();
                    bloquearCampos(false);
                    mensLabel.ForeColor = Color.Green;
                    mensLabel.Text = "Ciudad Actualizada !";
                }
            }
            catch (Exception err)
            {
               
                mensLabel.ForeColor = Color.Red;
                mensLabel.Text = "Existe un error !";
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                if (MessageBox.Show("Esta seguro que desea eliminar ciudad??", "Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int resultado = OperacionCiudad.EliminarCiudad(textcod_ciu.Text);
                    llenarTablaCiudad();
                    if (resultado > 0)
                    {
                        
                        MessageBox.Show("Alumnos Eliminado Correctamente", "Ciudad Eliminada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        quitarErrores();
                        bloquearCampos(false);
                        limpiarCampos();
                        //  bloquearCampos(false);

                    }

                    else
                    {
                        MessageBox.Show("No se pudo Eliminar la ciudad", "Ocurrio un error!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
                else
                    MessageBox.Show("Se cancelo la eliminacion", "Cancelado");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {//Mostrar todo
            try {

                dataCiudad.DataSource = OperacionCiudad.obtenerCiudad("");
            } catch (Exception err) { MessageBox.Show(err.Message); }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataCiudad.DataSource = OperacionCiudad.obtenerCiudad(textBuscar.Text);
        }
        public void llenarTablaCiudad()
        {
            dataCiudad.DataSource = OperacionCiudad.obtenerCiudad("");

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {//Nuevo
            quitarErrores();
            limpiarCampos();
            textcod_ciu.Text = OperacionCiudad.codigoCiudad() + 1+"";
            bloquearCampos(true);

        }
        public void bloquearBoton(Boolean ok)
        {
            btnEdit.Enabled = ok;
            btnEliminar.Enabled = ok;
            btnGuardar.Enabled = ok;
        }
        List<permisos> list = new List<permisos>();
        private void form_ciudad_Load(object sender, EventArgs e)
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
                    btnEdit.Enabled = true;
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
        public ciudad ciudadSelec  { get; set; }
        private void dataCiudad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {//elegir dato
            if (e.ColumnIndex ==1) {
                Int32 Id = Convert.ToInt32(dataCiudad.CurrentRow.Cells[0].Value);
                String nom = Convert.ToString(dataCiudad.CurrentRow.Cells[1].Value);
                textcod_ciu.Text = Id + "";
                textNom_ciu.Text = nom;
                bloquearCampos(true);
            }
        }
        public Boolean validarCampos()
        {
            Boolean ok = true;
            String mens = "";
            // validarCed(textced_cli.Text)

            if (!validaciones.esRequerido(textNom_ciu))
            {
                ok = false;
                mens += "Nombre de ciudad";
                 errorCiu.SetError(textNom_ciu, "Requiere ciudad");

            }
            mensLabel.ForeColor = Color.Red;
            mensLabel.Text = mens;
            return ok;
        }

        private void textNom_ciu_TextChanged(object sender, EventArgs e)
        {//error
            
             validaciones.quitarError(errorCiu, textNom_ciu);

        }
        public void quitarErrores()
        {

            validaciones.quitarError(errorCiu, textNom_ciu);        
            mensLabel.Text = "";
        }
        public void bloquearCampos(Boolean ok) {
            textNom_ciu.Enabled = ok;

        }
        public void limpiarCampos()
        {
            textNom_ciu.Text="";
            textcod_ciu.Text = "";

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {//Limpiar
            quitarErrores();
            limpiarCampos();
        }

        private void dataCiudad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Int32 Id = Convert.ToInt32(dataCiudad.CurrentRow.Cells[0].Value);
            String nom = Convert.ToString(dataCiudad.CurrentRow.Cells[1].Value);
            textcod_ciu.Text = Id + "";
            textNom_ciu.Text = nom;
            bloquearCampos(true);
        }
    }
}
