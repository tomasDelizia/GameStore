using System;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario.PresentacionEmpleados
{
    public partial class AltaEmpleado : Form
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioCargo _servicioCargo;
        private readonly IServicioBarrio _servicioBarrio;
        private readonly IServicioEmpleado _servicioEmpleado;
        private Empleado _empleadoARegistrar;

        public AltaEmpleado(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioCargo = new ServicioCargo(unidadDeTrabajo.RepositorioCargo);
            _servicioBarrio = new ServicioBarrio(unidadDeTrabajo.RepositorioBarrio);
            _servicioEmpleado = new ServicioEmpleado(unidadDeTrabajo.RepositorioEmpleado);
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        private void AltaEmpleado_Load(object sender, System.EventArgs e)
        {
            CargarBarrios(cboBarrios);
            CargarCargos(cboCargos);
        }

        private void CargarBarrios(ComboBox combo)
        {
            var barrios = _servicioBarrio.ListarBarrios();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = barrios;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdBarrio";
            combo.Text = "Selección";
        }

        private void CargarCargos(ComboBox combo)
        {
            var cargos = _servicioCargo.ListarCargos();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cargos;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdCargo";
            combo.Text = "Selección";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsEmpleadoValido())
                    return;
                RegistrarEmpleado();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                MessageBox.Show("Ha ocurrido un problema, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool EsOperacionConfirmada()
        {
            var respuesta = MessageBox.Show("Desea confirmar la operación", "Confirmación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                return true;
            return false;
        }

        private bool EsEmpleadoValido()
        {
            var empleadoNuevo = new Empleado();
            empleadoNuevo.Nombre = txtNombre.Text;
            empleadoNuevo.Apellido = txtApellido.Text;
            empleadoNuevo.Telefono = txtTelefono.Text;
            empleadoNuevo.CalleNombre = txtCalleNombre.Text;
            empleadoNuevo.Email = txtMail.Text;
            empleadoNuevo.CalleNumero = Convert.ToInt32(txtCalleNumero.Text);
            empleadoNuevo.NroDocumento = Convert.ToInt32(txtDocumento.Text);
            empleadoNuevo.FechaNacimiento = dtpFechaNacimiento.Value;
            empleadoNuevo.FechaAlta = DateTime.Now;
            empleadoNuevo.Barrio = (Barrio)cboBarrios.SelectedItem;
            empleadoNuevo.Cargo = (Cargo)cboCargos.SelectedItem;

            _servicioEmpleado.ValidarEmpleado(empleadoNuevo);
            _empleadoARegistrar = empleadoNuevo;
            return true;
        }

        private void RegistrarEmpleado()
        {
            if (!_servicioEmpleado.Insertar(_empleadoARegistrar))
            {
                MessageBox.Show("Ocurrió un problema al registrar el empleado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("El empleado se registró con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void btnAgregarCargo_Click(object sender, EventArgs e)
        {
            // new AltaCargo(_unidadDeTrabajo).ShowDialog();
            CargarCargos(cboCargos);
        }
    }
}
