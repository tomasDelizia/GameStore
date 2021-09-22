using System;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario.PresentacionEmpleados
{
    public partial class ModificacionEmpleado : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private Empleado _empleadoAModificar;
        private readonly IServicioEmpleado _servicioEmpleado;
        private readonly IServicioBarrio _servicioBarrio;
        private readonly IServicioCargo _servicioCargo;

        public ModificacionEmpleado(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            _servicioEmpleado = new ServicioEmpleado(unidadDeTrabajo.RepositorioEmpleado);
            _servicioCargo = new ServicioCargo(unidadDeTrabajo.RepositorioCargo);
            _servicioBarrio = new ServicioBarrio(unidadDeTrabajo.RepositorioBarrio);
            _empleadoAModificar = _servicioEmpleado.GetPorId(id);
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        private void ModificacionEmpleado_Load(object sender, System.EventArgs e)
        {
            CargarDatos();
            CargarBarrios(cboBarrios);
            CargarCargos(cboCargos);
        }

        private void CargarDatos()
        {
            txtNombre.Text = _empleadoAModificar.Nombre;
            txtApellido.Text = _empleadoAModificar.Apellido;
            txtCalleNombre.Text = _empleadoAModificar.CalleNombre;
            txtMail.Text = _empleadoAModificar.Email;
            txtCalleNumero.Text = _empleadoAModificar.CalleNumero.ToString();
            txtTelefono.Text = _empleadoAModificar.Telefono;
            txtDocumento.Text = _empleadoAModificar.NroDocumento.ToString();
            dtpFechaNacimiento.Value = _empleadoAModificar.FechaNacimiento;
        }

        private void CargarBarrios(ComboBox combo)
        {
            var barrios = _servicioBarrio.ListarBarrios();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = barrios;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdBarrio";
            combo.SelectedItem = _empleadoAModificar.Barrio.Nombre;
        }

        private void CargarCargos(ComboBox combo)
        {
            var cargos = _servicioCargo.ListarCargos();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = cargos;
            combo.DataSource = bindingSource;
            combo.DisplayMember = "Nombre";
            combo.ValueMember = "IdCargo";
            combo.SelectedItem = _empleadoAModificar.Cargo.Nombre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                ValidarEmpleado();
                ActualizarEmpleado();
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

        private void ValidarEmpleado()
        {
            _empleadoAModificar.Nombre = txtNombre.Text;
            _empleadoAModificar.Apellido = txtApellido.Text;
            _empleadoAModificar.Telefono = txtTelefono.Text;
            _empleadoAModificar.CalleNombre = txtCalleNombre.Text;
            _empleadoAModificar.Email = txtMail.Text;
            _empleadoAModificar.CalleNumero = Convert.ToInt32(txtCalleNumero.Text);
            _empleadoAModificar.NroDocumento = Convert.ToInt32(txtDocumento.Text);
            _empleadoAModificar.FechaNacimiento = dtpFechaNacimiento.Value;
            _empleadoAModificar.FechaAlta = DateTime.Now;
            _empleadoAModificar.Barrio = (Barrio)cboBarrios.SelectedItem;
            _empleadoAModificar.Cargo = (Cargo)cboCargos.SelectedItem;

            _servicioEmpleado.ValidarEmpleado(_empleadoAModificar);
        }

        private void ActualizarEmpleado()
        {
            _servicioEmpleado.Actualizar(_empleadoAModificar);
            MessageBox.Show("Se actualizó el empleado con éxito", "Información");
        }

        private void btnAgregarCargo_Click(object sender, EventArgs e)
        {
            // new AltaCargo(_unidadDeTrabajo).ShowDialog();
            CargarCargos(cboCargos);
        }
    }
}
