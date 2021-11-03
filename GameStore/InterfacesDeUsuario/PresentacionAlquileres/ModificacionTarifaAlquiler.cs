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

namespace GameStore.InterfacesDeUsuario.PresentacionAlquileres
{
    public partial class ModificacionTarifaAlquiler : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioTarifaAlquiler _servicioTarifaAlquiler;
        private TarifaAlquiler _tarifaAModificar;
        public ModificacionTarifaAlquiler(IUnidadDeTrabajo unidadDeTrabajo, int id)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioTarifaAlquiler = new ServicioTarifaAlquiler(_unidadDeTrabajo.RepositorioTarifaAlquiler);
            _tarifaAModificar = _servicioTarifaAlquiler.GetPorId(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void ModificacionCategoriaAlquiler_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _tarifaAModificar.Nombre;
            txtDescripcion.Text = _tarifaAModificar.Descripcion;
            numMontoAlquiler.Value = _tarifaAModificar.MontoAlquilerPorDia;
            numMontoTardio.Value = _tarifaAModificar.MontoDevolucionTardiaPorDia;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!EsOperacionConfirmada())
                    return;
                if (!EsTarifaValida())
                    return;
                ModificarTarifa();
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

        private void ModificarTarifa()
        {
            _servicioTarifaAlquiler.Actualizar(_tarifaAModificar);
            MessageBox.Show("Se modificó con éxito la tarifa de alquiler", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsTarifaValida()
        {
            _tarifaAModificar.Nombre = txtNombre.Text;
            _tarifaAModificar.MontoAlquilerPorDia = numMontoAlquiler.Value;
            _tarifaAModificar.MontoDevolucionTardiaPorDia = numMontoTardio.Value;
            _tarifaAModificar.Descripcion = txtDescripcion.Text;
            _servicioTarifaAlquiler.ValidarTarifa(_tarifaAModificar);
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
