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
    public partial class AltaCategoriaAlquiler : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioCategoriaAlquiler _servicioCategoriaAlquiler;
        private CategoriaAlquiler _nuevaCategoria;
        public AltaCategoriaAlquiler(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioCategoriaAlquiler = new ServicioCategoriaAlquiler(_unidadDeTrabajo.RepositorioCategoriaAlquiler);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsCategoriaValida())
                    return;
                RegistrarCategoria();
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

        private void RegistrarCategoria()
        {
            bool insertarCategoria = _servicioCategoriaAlquiler.Insertar(_nuevaCategoria);
            if (!insertarCategoria)
            {
                MessageBox.Show("Ocurrió un problema al registrar la categoría de alquiler", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito la categoría", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsCategoriaValida()
        {
            CategoriaAlquiler nuevaCategoria = new CategoriaAlquiler();
            nuevaCategoria.Nombre = TxtNombre.Text;
            nuevaCategoria.MontoAlquilerPorDia = numMontoAlquiler.Value;
            nuevaCategoria.MontoDevolucionTardiaPorDia = numMontoTardio.Value;
            nuevaCategoria.Descripcion = txtDescripcion.Text;
            _servicioCategoriaAlquiler.ValidarCategoria(nuevaCategoria);
            _nuevaCategoria = nuevaCategoria;
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
