using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class ModificacionDesarrollador : Form
    {
        private IServicioDesarrollador _servicioDesarrollador;
        private Desarrollador _desarrolladorAModificar;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        public ModificacionDesarrollador(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioDesarrollador = new ServicioDesarrollador(_unidadDeTrabajo.RepositorioDesarrollador);
            _desarrolladorAModificar = _servicioDesarrollador.GetPorId(id);
        }

        private void ModificacionDesarrollador_Load(object sender, EventArgs e)
        {
            CargarNombre(TxtNombre);
            CargarDescripcion(TxtDescripcion);
        }

        private void CargarNombre(TextBox TxtNombre)
        {
            TxtNombre.Text = _desarrolladorAModificar.Nombre;
        }

        private void CargarDescripcion(RichTextBox TxtDescripcion)
        {
            TxtDescripcion.Text = _desarrolladorAModificar.Descripcion;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsDesarrolladorValido())
                    return;
                ModificarDesarrollador();
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

        private void ModificarDesarrollador()
        {
            _servicioDesarrollador.Actualizar(_desarrolladorAModificar);
            MessageBox.Show("Se modificó con éxito el desarrollador", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsDesarrolladorValido()
        {
            _desarrolladorAModificar.Nombre = TxtNombre.Text;
            _desarrolladorAModificar.Descripcion = TxtDescripcion.Text;
            _servicioDesarrollador.ValidarDesarrollador(_desarrolladorAModificar);
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
