using GameStore.Entidades;
using GameStore.Servicios;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionSocios
{
    public partial class BajaSocio : Form
    {
        private IServicioSocio _servicioSocio;
        private Socio _socioABorrar;
        public BajaSocio(IServicioSocio servicioSocio, int id)
        {
            InitializeComponent();
            _servicioSocio = servicioSocio;
            _socioABorrar = _servicioSocio.GetPorId(id);
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaSocio();
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

        private void DarBajaSocio()
        {
            _servicioSocio.DarDeBaja(_socioABorrar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }

        private void BajaSocio_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _socioABorrar.Nombre;
            txtApellido.Text = _socioABorrar.Apellido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
