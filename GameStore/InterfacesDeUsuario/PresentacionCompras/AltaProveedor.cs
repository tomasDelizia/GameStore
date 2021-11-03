using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionCompras
{
    public partial class AltaProveedor : Form
    {
        private IServicioBarrio _servicioBarrio;
        private Proveedor _nuevoProveedor;
        private readonly IServicioProveedor _servicioProveedor;

        public AltaProveedor(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioProveedor = new ServicioProveedor(unidadDeTrabajo.RepositorioProveedor);
            _servicioBarrio = new ServicioBarrio(unidadDeTrabajo.RepositorioBarrio);
        }

        private void btnRegistrar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsProveedorValido())
                    return;
                RegistrarProveedor();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException fe)
            {
                MessageBox.Show("El documento y la altura de la calle solo aceptan valores numéricos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                var mensaje = ex.Message;
                MessageBox.Show("Ha ocurrido un problema, intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrarProveedor()
        {
            _nuevoProveedor.FechaAlta = DateTime.Now;
            bool insertarProveedor = _servicioProveedor.Insertar(_nuevoProveedor);
            if (!insertarProveedor)
            {
                MessageBox.Show("Ocurrió un problema al registrar el proveedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito el proveedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsOperacionConfirmada()
        {
            var respuesta = MessageBox.Show("¿Desea confirmar la operación?", "Confirmación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                return true;
            return false;
        }
        /// <summary>
        /// Devuelve true en el caso que los datos ingresados del proveedor sean validos en la estructura de datos y pueda registrarse. Este metodo esta implementado 2 veces, en alta proveedor y modificacion proveedor. Corregir.
        /// </summary>
        /// <returns></returns>
        private bool EsProveedorValido()
        {
            Proveedor nuevoProveedor = new Proveedor();
            nuevoProveedor.Estado = true;
            nuevoProveedor.RazonSocial = txtRazonSocial.Text;
            nuevoProveedor.Cuit = Convert.ToInt32(txtCuit.Text);
            nuevoProveedor.Telefono = txtTelefono.Text;
            nuevoProveedor.Email = txtEmail.Text;
            nuevoProveedor.CalleNombre = txtCalle.Text;
            nuevoProveedor.CalleNumero = Convert.ToInt32(txtNroCalle.Text);
            nuevoProveedor.Barrio = (Barrio)cmbBarrios.SelectedItem;
            _servicioProveedor.ValidarProveedor(nuevoProveedor);
            _nuevoProveedor = nuevoProveedor;
            return true;
        }

        private void AltaProveedor_Load(object sender, EventArgs e)
        {
            CargarBarrios(cmbBarrios);
        }

        /// <summary>
        /// Carga el combo de barrios. Este metodo esta duplicado aca y en ConsultaProveedor
        /// </summary>
        /// <param name="combo"></param>
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
