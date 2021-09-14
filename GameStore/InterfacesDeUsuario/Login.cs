using System;
using System.Collections;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //Defino los usuarios y pass aceptadas
            ArrayList usernames = new ArrayList() { "agustin", "tomas", "abril", "gaston", "a"};
            ArrayList passwords = new ArrayList() { "123", "345", "admin", "a"};

            if (usernames.Contains(TxtUser.Text) && passwords.Contains(TxtPass.Text))
            {
               string nombre = TxtUser.Text;
               Form frmBienvenida = new Bienvenida(nombre);
               frmBienvenida.ShowDialog();
               Form frmInicio = new Inicio();
               frmInicio.Show();
            }
            else
            {
                MessageBox.Show("Usuario y/o contrasenña invalidos", "Error Login", MessageBoxButtons.OK);
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
