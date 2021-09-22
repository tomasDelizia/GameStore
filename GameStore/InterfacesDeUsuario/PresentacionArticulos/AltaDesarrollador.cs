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
    public partial class AltaDesarrollador : Form
    {
        private Desarrollador _nuevoDesarrollador;
        private readonly IServicioDesarrollador _servicioDesarrollador;
        public AltaDesarrollador(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _servicioDesarrollador = new ServicioDesarrollador(unidadDeTrabajo.RepositorioDesarrollador);
        }

        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsDesarrolladorValido())
                    return;
                RegistrarDesarrollador();
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

        private bool EsDesarrolladorValido()
        {
            Desarrollador nuevoDesarrollador = new Desarrollador();
            nuevoDesarrollador.Nombre = TxtNombre.Text;
            nuevoDesarrollador.Descripcion = TxtDescripcion.Text;
            _servicioDesarrollador.ValidarDesarrollador(nuevoDesarrollador);
            _nuevoDesarrollador = nuevoDesarrollador;
            return true;
        }

        private void RegistrarDesarrollador() 
        {
            bool insertarDesarrollador = _servicioDesarrollador.Insertar(_nuevoDesarrollador);
            if (!insertarDesarrollador)
            {
                MessageBox.Show("Ocurrió un problema al registrar el desarrollador", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito el desarrollador", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
