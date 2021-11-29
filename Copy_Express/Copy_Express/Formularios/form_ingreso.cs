using Copy_Express.Clases;
using Copy_Express.Operaciones;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Copy_Express.Formularios
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//centro de la pantalla
           
        }
       public static form_cliente c = new form_cliente();
        List<permisos> listPer = new List<permisos>();//para cargar los permisos
        List<Usuario> listUs = new List<Usuario>();//para cargar los usuarios
        public static Principal p = new Principal();

        private void buttonIngresar_Click(object sender, EventArgs e)
        {
            ingresarSistema(); //ingresar al sistema
            textUser.Text = "";
            textPassward.Text = "";   
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           if (checkVerPasw.CheckState == CheckState.Checked)
            {
                textPassward.UseSystemPasswordChar = false;
            }
            else
            {
                textPassward.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }
        
        public void ingresarSistema()
        {
            String nom="", ape="";
            if (validaciones.autentificarUsuarios(textUser.Text, textPassward.Text))
            {
                listUs = OperacionesRolesPermisos.obtenerUsuario(textUser.Text);
                foreach (var dato in listUs)
                {
                    nom = dato.Nombres;
                    ape = dato.Apellidos;
                }
                this.Hide();
                Form1 pr = new Form1();
                pr.textCed.Text = textUser.Text;
                pr.textNomUser.Text = nom + "  " + ape;
                pr.Show();
            }
            else
            {
                MessageBox.Show("Contrasenia o Usuario son incorrectos");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
    
    
}
