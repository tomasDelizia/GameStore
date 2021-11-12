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
    public partial class AltaPerfil : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioPerfil _servicioPerfil;
        private Perfil _nuevoPerfil;
        public AltaPerfil(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioPerfil = new ServicioPerfil(_unidadDeTrabajo.RepositorioPerfil);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsPerfilValido())
                    return;
                RegistrarPerfil();
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

        private void RegistrarPerfil()
        {
            bool insertarPerfil = _servicioPerfil.Insertar(_nuevoPerfil);
            if (!insertarPerfil)
            {
                MessageBox.Show("Ocurrió un problema al registrar el perfil", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito el perfil", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsPerfilValido()
        {
            Perfil nuevoPerfil = new Perfil();
            nuevoPerfil.Nombre = txtNombre.Text;
            nuevoPerfil.Descripcion = txtDescripcion.Text;
            _servicioPerfil.ValidarPerfil(nuevoPerfil);
            _nuevoPerfil = nuevoPerfil;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
