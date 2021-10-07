using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class ModificacionGenero : Form
    {
        private IServicioGenero _servicioGenero;
        private Genero _generoAModificar;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        public ModificacionGenero(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent(); 
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioGenero = new ServicioGenero(_unidadDeTrabajo.RepositorioGenero);
            _generoAModificar = _servicioGenero.GetPorId(id);
        }

        private void ModificacionGenero_Load(object sender, EventArgs e)
        {
            CargarNombre(TxtNombre);
            CargarDescripcion(TxtDescripcion);
        }
        private void CargarNombre(TextBox TxtNombre)
        {
            TxtNombre.Text = _generoAModificar.Nombre;
        }

        private void CargarDescripcion(RichTextBox TxtDescripcion)
        {
            TxtDescripcion.Text = _generoAModificar.Descripcion;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsGeneroValido())
                    return;
                ModificarGenero();
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

        private void ModificarGenero()
        {
            _servicioGenero.Actualizar(_generoAModificar);
            MessageBox.Show("Se modificó con éxito el genero", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsGeneroValido()
        {
            _generoAModificar.Nombre = TxtNombre.Text;
            _generoAModificar.Descripcion = TxtDescripcion.Text;
            _servicioGenero.ValidarGenero(_generoAModificar);
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