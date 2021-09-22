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
    public partial class AltaPlataforma : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IServicioPlataforma _servicioPlataforma;
        private Plataforma _nuevaPlataforma;

        public AltaPlataforma(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioPlataforma = new ServicioPlataforma(_unidadDeTrabajo.RepositorioPlataforma);
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
                if (!EsPlataformaValida())
                    return;
                RegistrarPlataforma();
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

        private void RegistrarPlataforma()
        {
            bool insertarPlataforma = _servicioPlataforma.Insertar(_nuevaPlataforma);
            if (!insertarPlataforma)
            {
                MessageBox.Show("Ocurrió un problema al registrar la plataforma", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito la plataforma", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsPlataformaValida()
        {
            Plataforma nuevaPlataforma = new Plataforma();
            nuevaPlataforma.Nombre = txtNombre.Text;
            nuevaPlataforma.Descripcion = txtDescripcion.Text;
            _servicioPlataforma.ValidarPlataforma(nuevaPlataforma);
            _nuevaPlataforma = nuevaPlataforma;
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
