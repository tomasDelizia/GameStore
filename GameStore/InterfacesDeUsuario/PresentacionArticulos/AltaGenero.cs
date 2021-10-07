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
    public partial class AltaGenero : Form
    {
        private Genero _nuevoGenero;
        private readonly IServicioGenero _servicioGenero;
        public AltaGenero(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioGenero = new ServicioGenero(unidadDeTrabajo.RepositorioGenero);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsGeneroValido())
                    return;
                RegistrarGenero();
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

        private bool EsGeneroValido()
        {
            Genero nuevoGenero = new Genero();
            nuevoGenero.Nombre = TxtNombre.Text;
            nuevoGenero.Descripcion = TxtDescripcion.Text;
            _servicioGenero.ValidarGenero(nuevoGenero);
            _nuevoGenero = nuevoGenero;
            return true;
        }

        private void RegistrarGenero()
        {
            bool insertarGenero = _servicioGenero.Insertar(_nuevoGenero);
            if (!insertarGenero)
            {
                MessageBox.Show("Ocurrió un problema al registrar el genero", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito el genero", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
