using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class ModificacionClasificacion : Form
    {
        private IServicioClasificacion _servicioClasificacion;
        private Clasificacion _clasificacionAModificar;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        public ModificacionClasificacion(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioClasificacion = new ServicioClasificacion(_unidadDeTrabajo.RepositorioClasificacion);
            _clasificacionAModificar = _servicioClasificacion.GetPorId(id);
        }

        private void ModificacionClasificacion_Load_1(object sender, EventArgs e)
        {
            CargarNombre(TxtNombre);
            CargarDescripcion(TxtDescripcion);
        }

        private void CargarNombre(TextBox txtNombre)
        {
            txtNombre.Text = _clasificacionAModificar.Nombre;
        }
        private void CargarDescripcion(RichTextBox txtDescripcion)
        {
            txtDescripcion.Text = _clasificacionAModificar.Descripcion;
        }

        private void BtnModificar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsClasificacionValida())
                    return;
                ModificarClasificacion();
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
        private void ModificarClasificacion()
        {
            _servicioClasificacion.Actualizar(_clasificacionAModificar);
            MessageBox.Show("Se modificó con éxito la clasificacion", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
        private bool EsClasificacionValida()
        {
            _clasificacionAModificar.Nombre = TxtNombre.Text;
            _clasificacionAModificar.Descripcion = TxtDescripcion.Text;
            return true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}


