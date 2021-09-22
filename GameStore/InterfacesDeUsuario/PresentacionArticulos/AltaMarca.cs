using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario.PresentacionArticulos
{
    public partial class AltaMarca : Form
    {
        private Marca _nuevaMarca;
        private readonly IServicioMarca _servicioMarca;
        public AltaMarca(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioMarca = new ServicioMarca(unidadDeTrabajo.RepositorioMarca);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsMarcaValida())
                    return;
                RegistrarMarca();
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

        private bool EsMarcaValida()
        {
            Marca nuevaMarca = new Marca();
            nuevaMarca.Nombre = TxtNombre.Text;
            nuevaMarca.Descripcion = TxtDescripcion.Text;
            _servicioMarca.ValidarMarca(nuevaMarca);
            _nuevaMarca = nuevaMarca;
            return true;
        }

        private void RegistrarMarca()
        {
            bool insertarMarca = _servicioMarca.Insertar(_nuevaMarca);
            if (!insertarMarca)
            {
                MessageBox.Show("Ocurrió un problema al registrar la marca", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito la marca", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
