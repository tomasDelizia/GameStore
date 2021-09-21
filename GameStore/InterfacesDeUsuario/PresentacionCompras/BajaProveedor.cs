using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionCompras
{
    public partial class BajaProveedor : Form
    {
        private Proveedor _proveedorABorrar;
        private IServicioProveedor _servicioProveedor;
        public BajaProveedor(IServicioProveedor servicioProveedor, int id)
        {
            InitializeComponent();
            _servicioProveedor = servicioProveedor;
            _proveedorABorrar = _servicioProveedor.GetPorId(id);
        }

        private void BajaProveedor_Load(object sender, System.EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtRazonSocial.Text = _proveedorABorrar.RazonSocial;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaProveedor();
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

        private void DarBajaProveedor()
        {
            _servicioProveedor.Borrar(_proveedorABorrar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
