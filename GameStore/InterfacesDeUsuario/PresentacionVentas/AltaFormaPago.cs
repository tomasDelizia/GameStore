using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario.PresentacionVentas
{
    public partial class AltaFormaPago : Form
    {
        private FormaPago _nuevaFormaPago;
        private readonly IServicioFormaPago _servicioFormaPago;
        public AltaFormaPago(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioFormaPago = new ServicioFormaPago(unidadDeTrabajo.RepositorioFormaPago);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsFormaPagoValida())
                    return;
                RegistrarFormaPago();
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
            var respuesta = MessageBox.Show("¿Desea confirmar la operación?", "Confirmación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                return true;
            return false;
        }

        private bool EsFormaPagoValida()
        {
            FormaPago nuevaFormaPago = new FormaPago();
            nuevaFormaPago.Nombre = TxtNombre.Text;
            nuevaFormaPago.Descripcion = TxtDescripcion.Text;
            _servicioFormaPago.ValidarFormaPago(nuevaFormaPago);
            _nuevaFormaPago = nuevaFormaPago;
            return true;
        }
        private void RegistrarFormaPago()
        {
            bool insertarFormaPago = _servicioFormaPago.Insertar(_nuevaFormaPago);
            if (!insertarFormaPago)
            {
                MessageBox.Show("Ocurrió un problema al registrar la forma de pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito la forma de pago", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
