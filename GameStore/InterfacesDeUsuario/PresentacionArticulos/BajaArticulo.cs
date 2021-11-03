using System;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class BajaArticulo : Form
    {
        private Articulo _articuloABorrar;
        private IServicioArticulo _servicioArticulo;
        private IServicioEstadoVideojuego _servicioEstadoVideojuego;
        private EstadoVideojuego _estadoEliminado;

        public BajaArticulo(IUnidadDeTrabajo unidadDeTrabajo, long codigo)
        {
            InitializeComponent();
            _servicioArticulo = new ServicioArticulo(unidadDeTrabajo.RepositorioArticulo);
            _servicioEstadoVideojuego = new ServicioEstadoVideojuego(unidadDeTrabajo.RepositorioEstadoVideojuego);
            _articuloABorrar = _servicioArticulo.GetPorId(codigo);
        }

        private void BajaArticulo_Load(object sender, System.EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _articuloABorrar.Nombre;
            txtUPC.Text = _articuloABorrar.Codigo.ToString();
            txtPrecio.Text = _articuloABorrar.PrecioUnitario.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaArticulo();
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

        private void DarBajaArticulo()
        {
            buscarEstadoEliminado();
            _servicioArticulo.DarBajaArticulo(_articuloABorrar, _estadoEliminado);        
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }

        private void buscarEstadoEliminado()
        {
            _estadoEliminado = _servicioEstadoVideojuego.GetEstadoEliminado();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
