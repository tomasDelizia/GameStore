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

        public ModificacionSocio(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioSocio = new ServicioSocio(_unidadDeTrabajo.RepositorioSocio);
            _socioAModificar = _servicioSocio.GetPorId(id);
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
            _servicioSocio.Actualizar(_proveedorAModificar);
            MessageBox.Show("Se modificó con éxito el proveedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsSocioValido()
        {
            Socio socioAModificar = new Socio();
            socioAModificar.Nombre = txtNombre.Text;
            socioAModificar.Apellido = txtApellido.Text;
            socioAModificar.NroDocumento = Convert.ToInt32(txtDocumento.Text);
            socioAModificar.Email = txtEmail.Text;
            socioAModificar.CalleNombre = txtCalle.Text;
            socioAModificar.CalleNumero = Convert.ToInt32(txtNroCalle.Text);
            socioAModificar.Barrio = (Barrio)cmbBarrios.SelectedItem;
            socioAModificar.FechaNacimiento = dateNacimiento.Value;
            socioAModificar.Telefono = txtTelefono.Text;
            _servicioSocio.ValidarSocio(socioAModificar);
            _socioAModificar = socioAModificar;
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
    }
}
