using GameStore.Entidades;
using GameStore.Servicios;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class BajaClasificacion : Form
    {
        private Clasificacion _clasificacionABorrar;
        private IServicioClasificacion _servicioClasificacion;
        public BajaClasificacion(IServicioClasificacion servicioClasificacion, int id)
        {
            InitializeComponent();
            _servicioClasificacion = servicioClasificacion;
            _clasificacionABorrar = _servicioClasificacion.GetPorId(id);
        }
        private void BajaClasificacion_Load(object sender, System.EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            TxtNombre.Text = _clasificacionABorrar.Nombre;
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaClasificacion();
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
        private void DarBajaClasificacion()
        {
            _servicioClasificacion.Borrar(_clasificacionABorrar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
