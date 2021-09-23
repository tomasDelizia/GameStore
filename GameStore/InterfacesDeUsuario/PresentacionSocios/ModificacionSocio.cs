using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionSocios
{
    public partial class ModificacionSocio : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IServicioSocio _servicioSocio;
        private Socio _socioAModificar;
        private IServicioBarrio _servicioBarrio;

        public ModificacionSocio(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioSocio = new ServicioSocio(_unidadDeTrabajo.RepositorioSocio);
            _socioAModificar = _servicioSocio.GetPorId(id);
            _servicioBarrio = new ServicioBarrio(_unidadDeTrabajo.RepositorioBarrio);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsSocioValido())
                    return;
                ModificarSocio();
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

        private void ModificarSocio()
        {
            _servicioSocio.Actualizar(_socioAModificar);
            MessageBox.Show("Se modificó con éxito el socio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsSocioValido()
        {
            _socioAModificar.Nombre = txtNombre.Text;
            _socioAModificar.Apellido = txtApellido.Text;
            _socioAModificar.NroDocumento = Convert.ToInt32(txtDocumento.Text);
            _socioAModificar.Email = txtEmail.Text;
            _socioAModificar.CalleNombre = txtCalle.Text;
            _socioAModificar.CalleNumero = Convert.ToInt32(txtNroCalle.Text);
            _socioAModificar.Barrio = (Barrio)cmbBarrios.SelectedItem;
            _socioAModificar.FechaNacimiento = dateNacimiento.Value;
            _socioAModificar.Telefono = txtTelefono.Text;
            _servicioSocio.ValidarSocio(_socioAModificar);
            return true;
        }

        private bool EsOperacionConfirmada()
        {
            var respuesta = MessageBox.Show("¿Desea confirmar la operación?", "Confirmación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                return true;
            return false;
        }

        private void ModificacionSocio_Load(object sender, EventArgs e)
        {
            CargarNombre(txtNombre);
            CargarApellido(txtApellido);
            CargarNroDocumento(txtDocumento);
            CargarCalle(txtCalle);
            CargarNroCalle(txtNroCalle);
            CargarBarrio(cmbBarrios);
            CargarTelefono(txtTelefono);
            CargarEmail(txtEmail);
            CargarFechaNacimiento(dateNacimiento);
        }

        private void CargarFechaNacimiento(DateTimePicker dateNacimiento)
        {
            dateNacimiento.Value = (DateTime)_socioAModificar.FechaNacimiento;
        }

        private void CargarEmail(TextBox txtEmail)
        {
            txtEmail.Text = _socioAModificar.Email;
        }

        private void CargarTelefono(TextBox txtTelefono)
        {
            txtTelefono.Text = _socioAModificar.Telefono;
        }

        private void CargarBarrio(ComboBox cmbBarrios)
        {
            var barrios = _servicioBarrio.ListarBarrios();
            var bindingSource = new BindingSource();
            bindingSource.DataSource = barrios;
            cmbBarrios.DataSource = bindingSource;
            cmbBarrios.DisplayMember = "Nombre";
            cmbBarrios.ValueMember = "IdBarrio";
            cmbBarrios.SelectedItem = _socioAModificar.Barrio;
        }

        private void CargarNroCalle(TextBox txtNroCalle)
        {
            txtNroCalle.Text = _socioAModificar.CalleNumero.ToString();
        }

        private void CargarCalle(TextBox txtCalle)
        {
            txtCalle.Text = _socioAModificar.CalleNombre;
        }

        private void CargarNroDocumento(TextBox txtDocumento)
        {
            txtDocumento.Text = _socioAModificar.NroDocumento.ToString();
        }

        private void CargarApellido(TextBox txtApellido)
        {
            txtApellido.Text = _socioAModificar.Apellido;
        }

        private void CargarNombre(TextBox txtNombre)
        {
            txtNombre.Text = _socioAModificar.Nombre;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
