using System;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario
{
    public partial class Login : Form
    {
        private readonly IServicioUsuario _servicioUsuario;

        public Login(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioUsuario = new ServicioUsuario(unidadDeTrabajo.RepositorioUsuario);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string nombreUsuario = TxtNombreUsuario.Text;
            string contrasenia = TxtContrasenia.Text;
            Usuario usuarioLogueado = _servicioUsuario.Login(nombreUsuario, contrasenia);

            if (usuarioLogueado != null) {
                Form frmBienvenida = new Bienvenida(nombreUsuario);
                frmBienvenida.ShowDialog();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña inválidos", "Error Login", MessageBoxButtons.OK);
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
