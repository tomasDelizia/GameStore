using System;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.Servicios;

namespace GameStore.InterfacesDeUsuario.PresentacionEmpleados
{
    public partial class BajaEmpleado : Form
    {
        private readonly IServicioEmpleado _servicioEmpleado;
        private Empleado _empleadoAEliminar;

        public BajaEmpleado(IServicioEmpleado servicioEmpleado, int id)
        {
            InitializeComponent();
            _servicioEmpleado = servicioEmpleado;
            _empleadoAEliminar = _servicioEmpleado.GetPorId(id);
        }

        private void BajaEmpleado_Load(object sender, System.EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _empleadoAEliminar.Nombre;
            txtApellido.Text = _empleadoAEliminar.Apellido;
        }

        private void btnEliminar_Click(object sender, System.EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaEmpleado();
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

        private void DarBajaEmpleado()
        {
            _servicioEmpleado.Borrar(_empleadoAEliminar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }

        private void btnCancelar_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }
    }
}
