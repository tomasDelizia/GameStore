using GameStore.Entidades;
using GameStore.Servicios;
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
    public partial class BajaTarifaAlquiler : Form
    {
        private IServicioTarifaAlquiler _servicioTarifaAlquiler;
        private TarifaAlquiler _tarifaABorrar;
        public BajaTarifaAlquiler(IServicioTarifaAlquiler servicioTarifaAlquiler, int id)
        {
            InitializeComponent();
            _servicioTarifaAlquiler = servicioTarifaAlquiler;
            _tarifaABorrar = _servicioTarifaAlquiler.GetPorId(id);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void BajaTarifaAlquiler_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _tarifaABorrar.Nombre;
            txtPrecio.Text = _tarifaABorrar.MontoAlquilerPorDia.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult resultado = MessageBox.Show("Confirmar operación", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.Cancel)
                    return;
                DarBajaCategoria();
                this.Dispose();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un problema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DarBajaCategoria()
        {
            _servicioTarifaAlquiler.Borrar(_tarifaABorrar);
            MessageBox.Show("La operación se realizó con éxito", "Información");
        }
    }
}
