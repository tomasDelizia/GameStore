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
    public partial class AltaTarifaAlquiler : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioTarifaAlquiler _servicioTarifaAlquiler;
        private TarifaAlquiler _nuevaCategoria;
        public AltaTarifaAlquiler(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioTarifaAlquiler = new ServicioTarifaAlquiler(_unidadDeTrabajo.RepositorioTarifaAlquiler);
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
                if (!EsTarifaValida())
                    return;
                RegistrarTarifa();
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

        private void RegistrarTarifa()
        {
            bool insertarCategoria = _servicioTarifaAlquiler.Insertar(_nuevaCategoria);
            if (!insertarCategoria)
            {
                MessageBox.Show("Ocurrió un problema al registrar la tarifa de alquiler", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            MessageBox.Show("Se registró con éxito la tarifa de alquiler", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private bool EsTarifaValida()
        {
            TarifaAlquiler nuevaTarifa = new TarifaAlquiler();
            nuevaTarifa.Nombre = TxtNombre.Text;
            nuevaTarifa.MontoAlquilerPorDia = numMontoAlquiler.Value;
            nuevaTarifa.MontoDevolucionTardiaPorDia = numMontoTardio.Value;
            nuevaTarifa.Descripcion = txtDescripcion.Text;
            _servicioTarifaAlquiler.ValidarCategoria(nuevaTarifa);
            _nuevaCategoria = nuevaTarifa;
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
