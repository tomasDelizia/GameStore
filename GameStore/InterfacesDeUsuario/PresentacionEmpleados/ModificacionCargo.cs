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
    public partial class ModificacionCargo : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioCargo _servicioCargo;
        private Cargo _cargoAModificar;
        public ModificacionCargo(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioCargo = new ServicioCargo(unidadDeTrabajo.RepositorioCargo);
            _cargoAModificar = _servicioCargo.GetPorId(id);
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
                if (!EsCargoValido())
                    return;
                ModificarCargo();
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

        private void ModificarCargo()
        {
            _servicioCargo.Actualizar(_cargoAModificar);
            MessageBox.Show("Se modificó con éxito el cargo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsCargoValido()
        {
            _cargoAModificar.Nombre = txtNombre.Text;
            _cargoAModificar.Descripcion = txtDescripcion.Text;
            _servicioCargo.ValidarCargo(_cargoAModificar);
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

        private void ModificacionCargo_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _cargoAModificar.Nombre;
            txtDescripcion.Text = _cargoAModificar.Descripcion;
        }
    }
}
