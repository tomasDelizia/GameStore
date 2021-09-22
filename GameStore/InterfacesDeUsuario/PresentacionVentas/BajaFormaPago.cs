using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionVentas
{
    public partial class BajaFormaPago : Form
    {
        private FormaPago _formaPagoABorrar;
        private IServicioFormaPago _servicioFormaPago;
        public BajaFormaPago(IServicioFormaPago servicioFormaPago, int id)
        {
            InitializeComponent();
            _servicioFormaPago = servicioFormaPago;
            _formaPagoABorrar = _servicioFormaPago.GetPorId(id);
        }

        private void BajaFormaPago_Load(object sender, EventArgs e)
        {
            CargarNombre(TxtNombre);
        }

        private void CargarNombre(TextBox TxtNombre)
        {
            TxtNombre.Text = _formaPagoABorrar.Nombre;
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaFormaPago();
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

        private void DarBajaFormaPago()
        {
            _servicioFormaPago.Borrar(_formaPagoABorrar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
