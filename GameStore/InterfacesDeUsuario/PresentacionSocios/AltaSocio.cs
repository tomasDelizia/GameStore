using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionSocios
{
    public partial class AltaSocio : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IServicioSocio _servicioSocio;
        private IServicioBarrio _servicioBarrio;
        private Socio _nuevoSocio;

        public AltaSocio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioSocio = new ServicioSocio(_unidadDeTrabajo.RepositorioSocio);
            _servicioBarrio = new ServicioBarrio(_unidadDeTrabajo.RepositorioBarrio);

        }

        private void AltaSocio_Load(object sender, EventArgs e)
        {
            CargarBarrios(cmbBarrios);
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

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsSocioValido())
                    return;
                RegistrarSocio();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("El documento solo acepta valores numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                MessageBox.Show("Ha ocurrido un problema, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrarSocio()
        {
            _nuevoSocio.FechaAlta = DateTime.Now;
            bool insertarSocio = _servicioSocio.Insertar(_nuevoSocio);
            if (!insertarSocio)
            {
                MessageBox.Show("Ocurrió un problema al registrar el socio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito el socio", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Este metodo esta duplicado en alta proveedor y alta articulo. Corregir
        /// </summary>
        /// <returns></returns>
        private bool EsOperacionConfirmada()
        {
            var respuesta = MessageBox.Show("¿Desea confirmar la operación?", "Confirmación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                return true;
            return false;
        }

        private bool EsSocioValido()
        {
            Socio nuevoSocio = new Socio();
            nuevoSocio.Estado = true;
            nuevoSocio.Nombre = txtNombre.Text;
            nuevoSocio.Apellido = txtApellido.Text;
            nuevoSocio.NroDocumento = Convert.ToInt32(txtDocumento.Text);
            nuevoSocio.Email = txtEmail.Text;
            nuevoSocio.CalleNombre = txtCalle.Text;
            nuevoSocio.CalleNumero = Convert.ToInt32(txtNroCalle.Text);
            nuevoSocio.Barrio = (Barrio)cmbBarrios.SelectedItem;
            nuevoSocio.FechaNacimiento = dateNacimiento.Value;
            nuevoSocio.Telefono = txtTelefono.Text;
            _servicioSocio.ValidarSocio(nuevoSocio);
            _nuevoSocio = nuevoSocio;
            return true;
            
        }


    }
}
