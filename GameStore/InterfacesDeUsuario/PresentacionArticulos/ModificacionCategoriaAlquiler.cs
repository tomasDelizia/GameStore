using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class ModificacionCategoriaAlquiler : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioCategoriaAlquiler _servicioCategoriaAlquiler;
        private CategoriaAlquiler _categoriaAModificar;
        public ModificacionCategoriaAlquiler(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioCategoriaAlquiler = new ServicioCategoriaAlquiler(_unidadDeTrabajo.RepositorioCategoriaAlquiler);
            _categoriaAModificar = _servicioCategoriaAlquiler.GetPorId(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ModificacionCategoriaAlquiler_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _categoriaAModificar.Nombre;
            txtDescripcion.Text = _categoriaAModificar.Descripcion;
            numMontoAlquiler.Value = _categoriaAModificar.MontoAlquilerPorDia;
            numMontoTardio.Value = _categoriaAModificar.MontoDevolucionTardiaPorDia;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsCategoriaValida())
                    return;
                ModificarCategoria();
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

        private void ModificarCategoria()
        {
            _servicioCategoriaAlquiler.Actualizar(_categoriaAModificar);
            MessageBox.Show("Se modificó con éxito la categoría de alquiler", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsCategoriaValida()
        {
            _categoriaAModificar.Nombre = txtNombre.Text;
            _categoriaAModificar.MontoAlquilerPorDia = numMontoAlquiler.Value;
            _categoriaAModificar.MontoDevolucionTardiaPorDia = numMontoTardio.Value;
            _categoriaAModificar.Descripcion = txtDescripcion.Text;
            _servicioCategoriaAlquiler.ValidarCategoria(_categoriaAModificar);
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
    }
}
