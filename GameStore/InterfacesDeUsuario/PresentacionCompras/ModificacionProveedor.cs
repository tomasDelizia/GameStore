using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionCompras
{
    public partial class ModificacionProveedor : Form
    {
        private IServicioProveedor _servicioProveedor;
        private Proveedor _proveedorAModificar;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        public ModificacionProveedor(IUnidadDeTrabajo unidadDeTrabajo, int cuit)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioProveedor = new ServicioProveedor(_unidadDeTrabajo.RepositorioProveedor);
            _proveedorAModificar = _servicioProveedor.GetPorId(cuit);

        }

        private void ModificacionProveedor_Load(object sender, System.EventArgs e)
        {
            CargarRazonSocial(txtRazonSocial);
            CargarCuit(txtCuit);
            CargarCalle(txtCalle);
            CargarNroCalle(txtNroCalle);
            CargarBarrio(cmbBarrios);
            CargarTelefono(txtTelefono);
            CargarEmail(txtEmail);
        }

        private void CargarEmail(TextBox txtEmail)
        {
            txtEmail.Text = _proveedorAModificar.Email;
        }

        private void CargarTelefono(TextBox txtTelefono)
        {
            txtTelefono.Text = _proveedorAModificar.Telefono;
        }

        private void CargarBarrio(ComboBox cmbBarrios)
        {
            cmbBarrios.SelectedItem = _proveedorAModificar.Barrio;
        }

        private void CargarNroCalle(TextBox txtNroCalle)
        {
            txtNroCalle.Text = _proveedorAModificar.CalleNumero.ToString();
        }

        private void CargarCalle(TextBox txtCalle)
        {
            txtCalle.Text = _proveedorAModificar.CalleNombre;
        }

        private void CargarCuit(TextBox txtCuit)
        {
            txtCuit.Text = _proveedorAModificar.Cuit.ToString();
        }

        private void CargarRazonSocial(TextBox txtRazonSocial)
        {
            txtRazonSocial.Text = _proveedorAModificar.RazonSocial;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsProveedorValido())
                    return;
                ModificarProveedor();
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

        private void ModificarProveedor()
        {
            _servicioProveedor.Actualizar(_proveedorAModificar);
            MessageBox.Show("Se modificó con éxito el proveedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsProveedorValido() 
        {
            _proveedorAModificar.RazonSocial = txtRazonSocial.Text;
            _proveedorAModificar.Cuit = Convert.ToInt32(txtCuit.Text);
            _proveedorAModificar.Telefono = txtTelefono.Text;
            _proveedorAModificar.Email = txtEmail.Text;
            _proveedorAModificar.CalleNombre = txtCalle.Text;
            _proveedorAModificar.CalleNumero = Convert.ToInt32(txtNroCalle.Text);
            _servicioProveedor.ValidarProveedor(_proveedorAModificar);
            return true;
        }

        /// <summary>
        /// Devuelve true en el caso de que el usuario confirme la operacion. Este metodo se implemento 2 veces, en Modificar proveedor y en modificar articulo. Corregir.
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
    }
}
