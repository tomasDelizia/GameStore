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

namespace GameStore.InterfacesDeUsuario.PresentacionUsuarios
{
    public partial class ModificacionPerfil : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioPerfil _servicioPerfil;
        private Perfil _perfilAModificar;
        public ModificacionPerfil(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioPerfil = new ServicioPerfil(_unidadDeTrabajo.RepositorioPerfil);
            _perfilAModificar = _servicioPerfil.GetPorId(id);
        }

        private void ModificacionPerfil_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _perfilAModificar.Nombre;
            txtDescripcion.Text = _perfilAModificar.Descripcion;
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
                if (!EsPerfilValido())
                    return;
                ModificarPerfil();
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

        private void ModificarPerfil()
        {
            _servicioPerfil.Actualizar(_perfilAModificar);
            MessageBox.Show("Se modificó con éxito el perfil", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsOperacionConfirmada()
        {
            var respuesta = MessageBox.Show("¿Desea confirmar la operación?", "Confirmación", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
                return true;
            return false;
        }
        private bool EsPerfilValido()
        {
            _perfilAModificar.Nombre = txtNombre.Text;
            _perfilAModificar.Descripcion = txtDescripcion.Text;
            _servicioPerfil.ValidarPerfil(_perfilAModificar);
            return true;
        }
    }
}
