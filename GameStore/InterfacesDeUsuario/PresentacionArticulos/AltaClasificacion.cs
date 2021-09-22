using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class AltaClasificacion : Form
    {
        private IServicioClasificacion _servicioClasificacion;
        private Clasificacion _nuevaClasificacion;

        public AltaClasificacion(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioClasificacion = new ServicioClasificacion(unidadDeTrabajo.RepositorioClasificacion);
        }

        private void btnRegistrar_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsClasificacionValida())
                    return;
                RegistrarClasificacion();
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

        private bool EsClasificacionValida()
        {
            Clasificacion nuevaClasificacion = new Clasificacion();
            nuevaClasificacion.Nombre =TxtNombre.Text;

            _servicioClasificacion.ValidarClasificacion(nuevaClasificacion);
            _nuevaClasificacion = nuevaClasificacion;
            return true;
        }
        private void RegistrarClasificacion()
        {
            
            bool insertarClasificacion = _servicioClasificacion.Insertar(_nuevaClasificacion);
            if (!insertarClasificacion)
            {
                MessageBox.Show("Ocurrió un problema al registrar el proveedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito el artículo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
