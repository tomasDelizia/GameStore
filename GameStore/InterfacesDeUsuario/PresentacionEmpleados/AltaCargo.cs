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

namespace GameStore.InterfacesDeUsuario.PresentacionEmpleados
{
    public partial class AltaCargo : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioCargo _servicioCargo;
        private Cargo _nuevoCargo;
        public AltaCargo(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioCargo = new ServicioCargo(unidadDeTrabajo.RepositorioCargo);
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
                if (!EsCargoValido())
                    return;
                RegistrarCargo();
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

        private void RegistrarCargo()
        {
            bool insertarCargo = _servicioCargo.Insertar(_nuevoCargo);
            if (!insertarCargo)
            {
                MessageBox.Show("Ocurrió un problema al registrar el cargo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito el cargo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsCargoValido()
        {
            Cargo nuevoCargo = new Cargo();
            nuevoCargo.Nombre = txtNombre.Text;
            nuevoCargo.Descripcion = txtDescripcion.Text;
            _servicioCargo.ValidarCargo(nuevoCargo);
            _nuevoCargo = nuevoCargo;
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
