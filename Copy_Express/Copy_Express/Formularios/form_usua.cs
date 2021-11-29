using Copy_Express.Clases;
using Copy_Express.Operaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Copy_Express.Formularios
{
    public partial class form_usua : Form
    {
        public form_usua()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {//Guardar usuario
            try {
                if (validarCampos())
                {
                    int codigo = Int32.Parse(txtCodUsua.Text);
                    Usuario us = new Usuario();
                    us.Cod_usua = Int32.Parse(txtCodUsua.Text);
                    us.Rol = comboRol.SelectedValue + "";
                    us.Ced_usua = textCedUsau.Text;
                    us.Nombres = textNomUsua.Text;
                    us.Apellidos = textApeUsua.Text;
                    us.Email = textEmailUsua.Text;
                    us.Telefono = textTelfUsua.Text;
                    us.Direccion = textDirUsua.Text;
                    us.Ciudad = comboCiudad.SelectedValue + "";
                    us.Passward = textPassword.Text;
                    Operaciones.OperacionesUser.AgregarUsuario(us);
                    //Guardar Permisos                   
                    guardarPermisos(codigo ,textCedUsau.Text);
                    limpiarCamposUser();
                    quitarErrores();
                    menLabe.ForeColor = Color.Green;
                    menLabe.Text = "Usuario Registrado !";
                    bloquearCampos(false);
                }

            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }

        }
        public void guardarPermisos(int cod,String ced_user) {
            String nom_per = "";
            int reg=0, update=0, delete=0;
            //String  = "";
            int estado = 0;
            if (checTodo.CheckState == CheckState.Checked) {
                nom_per = "Todo los permisos";
                reg = 1;update = 1;delete = 1;
            }
            if (checkEditar.CheckState == CheckState.Checked) {

                nom_per = "Puede editar";
                update = 1;         
            }
            if (checkEliminar.CheckState == CheckState.Checked) {
                nom_per = "Puede eliminar";
                delete = 1;
            }
            if (checkRegistar.CheckState == CheckState.Checked) {
                nom_per = "Puede Registar";
                reg = 1;
            }
            //Registrar
            OperacionesRolesPermisos.AgregarPermisos(cod,ced_user,reg,update,delete);
        }

        private void button1_Click(object sender, EventArgs e)
        {//NUEVO
            
            txtCodUsua.Text = OperacionesUser.numUser() + 1 + "";
            cargaCombos();
            limpiarCamposUser();
            quitarErrores();
            bloquearCampos(true);

        }
        public void cargaCombos() {

            comboCiudad.DataSource = OperacionCiudad.obtenerCiudad("");
            comboCiudad.DisplayMember = "nom_ciu";
            comboCiudad.ValueMember = "cod_ciu";
            comboRol.DataSource = OperacionesRolesPermisos.obtenerRoles("");
            comboRol.DisplayMember = "nom_rol";
            comboRol.ValueMember = "cod_rol";
        }

        private void button2_Click(object sender, EventArgs e)
        {//Editar datos
            try
            {
                if (validarCampos())
                {
                    Usuario us = new Usuario();
                    us.Cod_usua = Int32.Parse(txtCodUsua.Text);
                    us.Rol = comboRol.SelectedValue + "";
                    us.Ced_usua = textCedUsau.Text;
                    us.Nombres = textNomUsua.Text;
                    us.Apellidos = textApeUsua.Text;
                    us.Email = textEmailUsua.Text;
                    us.Telefono = textTelfUsua.Text;
                    us.Direccion = textDirUsua.Text;
                    us.Ciudad = comboCiudad.SelectedValue + "";
                    us.Passward = textPassword.Text;
                    OperacionesUser.ModificarUser(us);
                    editarPermisos(Int32.Parse(txtCodUsua.Text), textCedUsau.Text);
                    //editar permisos
                    limpiarCamposUser();
                    quitarErrores();
                    menLabe.ForeColor = Color.Green;
                    menLabe.Text = "Usuario Modificado !";
                    bloquearCampos(false);
                }
            }
            catch (Exception err) { }
        }
        public void editarPermisos(int cod, String ced_user)
        {
            String nom_per = "";
            int reg = 0, update = 0, delete = 0;
            //String  = "";
            int estado = 0;
            if (checTodo.CheckState == CheckState.Checked)
            {
                nom_per = "Todo los permisos";
                reg = 1; update = 1; delete = 1;
            }
            if (checkEditar.CheckState == CheckState.Checked)
            {

                nom_per = "Puede editar";
                update = 1;
            }
            if (checkEliminar.CheckState == CheckState.Checked)
            {
                nom_per = "Puede eliminar";
                delete = 1;
            }
            if (checkRegistar.CheckState == CheckState.Checked)
            {
                nom_per = "Puede Registar";
                reg = 1;
            }
            //Registrar
            OperacionesRolesPermisos.editarPermisos(cod, ced_user, reg, update, delete);
        }

        private void button3_Click(object sender, EventArgs e)
        {//Eliminar
            if (validarCampos()){
                if (MessageBox.Show("Esta seguro que desea eliminar el Usuario??", "Esta seguro?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int resultado = OperacionesRolesPermisos.EliminarPermisos(Int32.Parse(txtCodUsua.Text));

                    if (resultado > 0)
                    {
                        OperacionesUser.EliminarUser(txtCodUsua.Text);

                        MessageBox.Show("Usuario Eliminado Correctamente", "Usuario Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        quitarErrores();
                        limpiarCamposUser();
                        bloquearCampos(false);
                    } else
                    { MessageBox.Show("No se pudo Eliminar el cliente", "Ocurrio un error!!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                    MessageBox.Show("Se cancelo la eliminacion", "Cancelado");
            }
        }
        public Usuario usuarioSeleccionado { get; set; }
        
        public Boolean cargarComboxUser(String ced)
        {
            Boolean ok = true;
            limpiarChek();
            usuarioSeleccionado = OperacionesUser.ObtenerUser(ced);
            if (usuarioSeleccionado.Cod_usua != 0)
            {
                cargaCombos();
                txtCodUsua.Text = usuarioSeleccionado.Cod_usua+"";
                comboRol.Text = usuarioSeleccionado.Rol+"";
                textCedUsau.Text= usuarioSeleccionado.Ced_usua;
                textNomUsua.Text =usuarioSeleccionado.Nombres;
                textApeUsua.Text = usuarioSeleccionado.Apellidos;
                textEmailUsua.Text = usuarioSeleccionado.Email;
                textTelfUsua.Text= usuarioSeleccionado.Telefono;
                textDirUsua.Text= usuarioSeleccionado.Direccion;
                comboCiudad.Text = usuarioSeleccionado.Ciudad+"";
                textPassword.Text = usuarioSeleccionado.Passward;
                cargarCheckBox(usuarioSeleccionado.Ced_usua);//cargar chekbox
                //if(usuarioSeleccionado.Cod_usua == 0) { ok = false; }
            }else { MessageBox.Show("No existe"); }
            return ok;
        }

        List<permisos> list = new List<permisos>();//para cargar los permiso

      
       public void limpiarChek() {

            checTodo.Checked = false;
            checkEditar.Checked = false;
            checkEliminar.Checked = false;
            checkRegistar.Checked = false;
        }
        
        public void cargarCheckBox(String ced)
        {
            //   List<permisos> lisPermisos = new List<permisos>();
            try { 
            using (SqlConnection conexion = ConexionBD.ObtnerCOnexion())
            {
                SqlCommand comando = new SqlCommand(string.Format("Select * from permisos  where CONCAT(ced_usu,id_permiso) LIKE '%" + ced + "%'"), conexion);
                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())//carga los datos con roles
                {
                    if ((reader.GetInt32(2) == 1) && (reader.GetInt32(3) == 1) && (reader.GetInt32(4) == 1))
                    {
                        checTodo.Checked = true;
                     }
                    else
                    {
                        if (reader.GetInt32(2) == 1) { checkRegistar.Checked = true; }
                        if (reader.GetInt32(3) == 1) { checkEditar.Checked = true; }
                        if (reader.GetInt32(4) == 1) { checkEliminar.Checked = true; }
                    }
                }
                conexion.Close();             
            }
            }
            catch (Exception err) { MessageBox.Show(err.Message); }
        }

        List<permisos> lis= new List<permisos>();
        private void form_usua_Load(object sender, EventArgs e)
        {
            bloquearBotones(false);

            lis = validaciones.ObtenerPermisosUser(Form1.ced_usuario);

            foreach (var num in lis)
            {
                if (num.Insert == 1 && num.Update == 1 && num.Delete == 1)//todos los permisos
                {
                    bloquearBotones(true); //todos los permisos
                }
                if (num.Update == 1)//editar
                {
                    btnEdit.Enabled = true;
                }
                if (num.Delete == 1)//eliminar
                {
                    btnDelete.Enabled = true;
                }
                if (num.Insert == 1)//Registrar
                {
                    btnNuevo.Enabled = true;
                    buttonGuardar.Enabled = true;
                }
                bloquearCampos(false);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {//Buscar pro cedula
         // textBuscar 
           // dataUser.DataSource = OperacionesUser.obtenerUsuarios(textBuscar.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (cargarComboxUser(textBuscar.Text))
            {
                //limpiarChek();
                textBuscar.Text="";
                bloquearCampos(true);
                textCedUsau.Enabled = false;
            }

        }
        //validaciones
        public void bloquearCampos(Boolean ok) {
            comboRol.Enabled = ok;
            textCedUsau.Enabled = ok;
            textNomUsua.Enabled = ok;
            textApeUsua.Enabled = ok;
            textEmailUsua.Enabled = ok;
            textTelfUsua.Enabled = ok;
            textDirUsua.Enabled = ok;
            comboCiudad.Enabled = ok;
            textPassword.Enabled = ok;
        }
        public void limpiarCamposUser() {
            //txtCodUsua.Text = "";
            comboRol.Text =  "";
            textCedUsau.Text = "";
            textNomUsua.Text = "";
            textApeUsua.Text = "";
            textEmailUsua.Text = "";
            textTelfUsua.Text = "";
            textDirUsua.Text = "";
            comboCiudad.Text = "";
            textPassword.Text = "";
            limpiarChek();
            menLabe.Text = "";

        }

        public Boolean validarCampos()
        {
            Boolean ok = true;
            String mens = "Campos requeridos :";
            if (!validaciones.soloNumeros(errorProvideCed, textCedUsau) || !validaciones.validarCed(textCedUsau.Text))
            {
                ok = true;
                mens += "cedula incorrecta";

            }
            if (!validaciones.esRequerido(textNomUsua))
            {
                mens += ", Nombre";
                errorNom.SetError(textNomUsua, "Error en el nombre");
                ok = false;

            }
            if (!validaciones.esRequerido(textApeUsua))
            {
                mens += ", Apellido";
                errorApe.SetError(textApeUsua, "Error en el apelldio");
                ok = false;

            }
            if (!validaciones.ComprobarFormatoEmail(errorEmail, textEmailUsua))
            {
                mens += ", Email";
                ok = false;

            }
            if (!validaciones.soloNumeros(errorTelf,textTelfUsua))
            {
                mens += ", Teléfono";
                ok = false;

            }
            if (!validaciones.esRequerido(textDirUsua))
            {
                mens += ", Dirección";
                errorDir.SetError(textDirUsua, "dir");
                ok = false;

            }
            if (!validaciones.esRequerido(textPassword))
            {
                mens += ", Password";
                errorPasword.SetError(textPassword, "Campo requerido");
                ok = false;

            }
            menLabe.ForeColor = Color.Red;
            menLabe.Text = mens;
            return ok;
        }

        private void textCedUsau_TextChanged(object sender, EventArgs e)
        {
            if (validaciones.soloNumeros(errorProvideCed, textCedUsau))
            {
                validaciones.quitarError(errorProvideCed, textCedUsau);
            }
        }

        private void textEmailUsua_TextChanged(object sender, EventArgs e)
        {
            if (validaciones.ComprobarFormatoEmail(errorEmail, textEmailUsua))
            {
                validaciones.quitarError(errorEmail, textEmailUsua);
            }
        }

        private void textTelfUsua_TextChanged(object sender, EventArgs e)
        {
            if (validaciones.soloNumeros(errorTelf, textTelfUsua))
            {
                validaciones.quitarError(errorTelf, textTelfUsua);
            }
        }

        private void textApeUsua_TextChanged(object sender, EventArgs e)
        {
         
            validaciones.quitarError(errorApe, textApeUsua);
            
        }

        private void textNomUsua_TextChanged(object sender, EventArgs e)
        {
            
                validaciones.quitarError(errorNom, textNomUsua);
            
        }
        public void quitarErrores()
        {

            validaciones.quitarError(errorProvideCed, textCedUsau);
            validaciones.quitarError(errorNom, textNomUsua);
            validaciones.quitarError(errorApe, textApeUsua);
            validaciones.quitarError(errorEmail, textEmailUsua);
            validaciones.quitarError(errorTelf, textTelfUsua);
            validaciones.quitarError(errorDir, textDirUsua);
            validaciones.quitarError(errorPasword, textPassword);
            menLabel.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {//Refrescar los datos
            quitarErrores();
            cargaCombos();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            form_ciudad fc = new form_ciudad();
            fc.Show();
        }

        private void panelUsu_Paint(object sender, PaintEventArgs e)
        {

        }
        public void bloquearBotones(Boolean ok)//bloquear botones
        {
          
           btnNuevo.Enabled = ok;
            buttonGuardar.Enabled = ok;
            btnEdit.Enabled = ok;
            btnDelete.Enabled = ok;
        }

        private void textPassword_TextChanged(object sender, EventArgs e)
        {     
            validaciones.quitarError(errorPasword,textPassword);
        }

        private void comboCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textDirUsua_TextChanged(object sender, EventArgs e)
        {
            validaciones.quitarError(errorDir, textDirUsua);
        }
    }
}
