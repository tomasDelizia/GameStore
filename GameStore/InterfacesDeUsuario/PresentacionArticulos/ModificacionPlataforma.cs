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
    public partial class ModificacionPlataforma : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioPlataforma _servicioPlataforma;
        private Plataforma _plataformaAModificar;
        public ModificacionPlataforma(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioPlataforma = new ServicioPlataforma(unidadDeTrabajo.RepositorioPlataforma);
            _plataformaAModificar = _servicioPlataforma.GetPorId(id);
        }

        private void ModificacionPlataforma_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _plataformaAModificar.Nombre;
            txtDescripcion.Text = _plataformaAModificar.Descripcion;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsPlataformaValida())
                    return;
                ModificarPlataforma();
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

        private void ModificarPlataforma()
        {
            _servicioPlataforma.Actualizar(_plataformaAModificar);
            MessageBox.Show("Se modificó con éxito el proveedor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsPlataformaValida()
        {
            _plataformaAModificar.Nombre = txtNombre.Text;
            _plataformaAModificar.Descripcion = txtDescripcion.Text;
            _servicioPlataforma.ValidarPlataforma(_plataformaAModificar);
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
