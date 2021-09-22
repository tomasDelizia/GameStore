using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionVentas
{
    public partial class ModificacionFormaPago : Form
    {
        private IServicioFormaPago _servicioFormaPago;
        private FormaPago _formaPagoAModificar;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        public ModificacionFormaPago(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioFormaPago = new ServicioFormaPago(_unidadDeTrabajo.RepositorioFormaPago);
            _formaPagoAModificar = _servicioFormaPago.GetPorId(id);
        }

        private void ModificacionFormaPago_Load(object sender, EventArgs e)
        {
            CargarNombre(TxtNombre);
            CargarDescripcion(TxtDescripcion);
        }

        private void CargarNombre(TextBox TxtNombre)
        {
            TxtNombre.Text = _formaPagoAModificar.Nombre;
        }

        private void CargarDescripcion(RichTextBox TxtDescripcion)
        {
            TxtDescripcion.Text = _formaPagoAModificar.Descripcion;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsFormaPagoValida())
                    return;
                ModificarFormaPago();
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

        private void ModificarFormaPago()
        {
            _servicioFormaPago.Actualizar(_formaPagoAModificar);
            MessageBox.Show("Se modificó con éxito la forma de pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsFormaPagoValida()
        {
            _formaPagoAModificar.Nombre = TxtNombre.Text;
            _formaPagoAModificar.Descripcion = TxtDescripcion.Text;
            _servicioFormaPago.ValidarFormaPago(_formaPagoAModificar);
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

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
