using System;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.Servicios;

namespace GameStore.InterfacesDeUsuario.PresentacionUsuarios
{
    public partial class BajaUsuario : Form
    {
        private IServicioUsuario _servicioUsuario;
        private Usuario _usuarioAEliminar;

        public BajaUsuario(IServicioUsuario servicioUsuario, int id)
        {
            InitializeComponent();
            _servicioUsuario = servicioUsuario;
            _usuarioAEliminar = _servicioUsuario.GetPorId(id);
        }

        private void BajaUsuario_Load(object sender, EventArgs e)
        {
            CargarNombreUsuario();
        }

        private void CargarNombreUsuario()
        {
            txtNombreUsuario.Text = _usuarioAEliminar.NombreUsuario;
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaUsuario();
                this.Dispose();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DarBajaUsuario()
        {
            _servicioUsuario.BorrarUsuario(_usuarioAEliminar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }
    }
}
