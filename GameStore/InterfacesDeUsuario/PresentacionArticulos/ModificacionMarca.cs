using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class ModificacionMarca : Form
    {
        private IServicioMarca _servicioMarca;
        private Marca _marcaAModificar;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        public ModificacionMarca(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioMarca = new ServicioMarca(_unidadDeTrabajo.RepositorioMarca);
            _marcaAModificar = _servicioMarca.GetPorId(id);
        }

        private void ModificacionMarca_Load(object sender, EventArgs e)
        {
            CargarNombre(TxtNombre);
            CargarDescripcion(TxtDescripcion);
        }

        private void CargarNombre(TextBox TxtNombre)
        {
            TxtNombre.Text = _marcaAModificar.Nombre;
        }

        private void CargarDescripcion(RichTextBox TxtDescripcion)
        {
            TxtDescripcion.Text = _marcaAModificar.Descripcion;
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsMarcaValida())
                    return;
                ModificarMarca();
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

        private void ModificarMarca()
        {
            _servicioMarca.Actualizar(_marcaAModificar);
            MessageBox.Show("Se modificó con éxito la marca", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsMarcaValida()
        {
            _marcaAModificar.Nombre = TxtNombre.Text;
            _marcaAModificar.Descripcion = TxtDescripcion.Text;
            _servicioMarca.ValidarMarca(_marcaAModificar);
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
