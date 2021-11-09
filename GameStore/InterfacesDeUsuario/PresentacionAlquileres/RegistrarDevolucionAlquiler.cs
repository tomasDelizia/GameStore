using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios.Implementaciones;
using GameStore.Utils;

namespace GameStore.InterfacesDeUsuario.PresentacionAlquileres
{
    public partial class RegistrarDevolucionAlquiler : Form
    {
        private Alquiler _alquiler;
        private IServicioAlquiler _servicioAlquiler;

        public RegistrarDevolucionAlquiler(Alquiler alquiler, IUnidadDeTrabajo unidadDeTrabajo)
        {
            _alquiler = alquiler;
            _servicioAlquiler = new ServicioAlquiler(unidadDeTrabajo.RepositorioAlquiler);
            InitializeComponent();
        }

        private void RegistrarDevolucionAlquiler_Load(object sender, EventArgs e)
        {
            dgvDetallesDeAlquileres.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvDetallesDeAlquileres.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            CargarDetallesDeAlquiler();
            lblFechaInicio.Text += " " + _alquiler.FechaInicio.ToShortDateString();
            lblFechaDevPrevista.Text += " " + _alquiler.FechaFin.ToShortDateString();
            lblFechaDevReal.Text += " " + DateTime.Today.ToShortDateString();
            lblCantidadDias.Text += " " + (_alquiler.FechaFin - _alquiler.FechaInicio).Days.ToString();
            lblDiasExtra.Text += " " + (DateTime.Today - _alquiler.FechaFin).Days.ToString();
            txtTotal.Text = _alquiler.CalcularTotal().ToString();
            txtSenia.Text = _alquiler.MontoSenia.ToString();
            txtImporteDevTardia.Text = _alquiler.CalcularImporteDevolucionTardia().ToString();
            txtImporteFinal.Text = _alquiler.CalcularImporteFinal().ToString();
        }

        private void CargarDetallesDeAlquiler()
        {
            dgvDetallesDeAlquileres.Rows.Clear();
            var dias = _alquiler.CantidadDias();
            foreach (var detalle in _alquiler.DetallesDeAlquiler)
            {
                var fila = new string[]
                {
                    detalle.NroAlquiler.ToString(),
                    detalle.Codigo.ToString(),
                    detalle.Articulo.Nombre,
                    "$ " + detalle.MontoAlquilerPorDia.ToString(),
                    "$ " + detalle.MontoDevolucionTardiaPorDia.ToString(),
                    "$ " + detalle.CalcularSubtotal(dias),
                    detalle.Articulo.TipoArticulo.Nombre,
                    detalle.Articulo.Plataforma.Nombre

                };
                dgvDetallesDeAlquileres.Rows.Add(fila);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormUtils.EsOperacionConfirmada())
                    return;
                DevolverAlquiler();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo concretar la transacción", "Error", MessageBoxButtons.OK);
            }
        }

        private void DevolverAlquiler()
        {
            _alquiler.FechaFinReal = DateTime.Today;
            _servicioAlquiler.Actualizar(_alquiler);
            MessageBox.Show("Se registró con éxito la devolución del alquiler", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
    }
}
