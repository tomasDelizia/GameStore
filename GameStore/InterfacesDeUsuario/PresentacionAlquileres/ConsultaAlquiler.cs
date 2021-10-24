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
using GameStore.InterfacesDeUsuario.PresentacionEmpleados;
using GameStore.InterfacesDeUsuario.PresentacionSocios;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using GameStore.Utils;

namespace GameStore.InterfacesDeUsuario.PresentacionAlquileres
{
    public partial class ConsultaAlquiler : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IServicioAlquiler _servicioAlquiler;
        private IServicioTipoFactura _servicioTipoFactura;
        private IServicioFormaPago _servicioFormaPago;
        private ConsultaSocio _consultaSocio;
        private ConsultaEmpleado _consultaEmpleado;
        private Socio _socioFiltro;
        private Empleado _vendedorFiltro;

        public ConsultaAlquiler(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvAlquiler.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvAlquiler.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioAlquiler = new ServicioAlquiler(unidadDeTrabajo.RepositorioAlquiler);
            _servicioFormaPago = new ServicioFormaPago(unidadDeTrabajo.RepositorioFormaPago);
            _servicioTipoFactura = new ServicioTipoFactura(unidadDeTrabajo.RepositorioTipoFactura);
        }

        private void ConsultaAlquiler_Load(object sender, EventArgs e)
        {
            CargarFormasDePago();
            CargarTiposDeFactura();
            ConsultarAlquileres();
        }

        private void CargarTiposDeFactura()
        {
            var tiposFactura = _servicioTipoFactura.ListarTiposDeFactura();
            FormUtils.CargarCombo(ref cboTiposFactura, new BindingSource() { DataSource = tiposFactura }, "Nombre", "IdTipoFactura");
        }


        private void CargarFormasDePago()
        {
            var formasPago = _servicioFormaPago.ListarFormaPago();
            FormUtils.CargarCombo(ref cboFormasPago, new BindingSource() { DataSource = formasPago }, "Nombre", "IdFormaPago");
        }

        private void ConsultarAlquileres()
        {
            var alquileres = _servicioAlquiler.ListarAlquileres();
            CargarDgvAlquileres(alquileres);
            dgvAlquiler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvAlquileres(List<Alquiler> alquileres)
        {
            dgvAlquiler.Rows.Clear();
            foreach (var alquiler in alquileres)
            {
                var fila = new string[]
                {
                    alquiler.NroAlquiler.ToString(),
                    alquiler.TipoFactura.Nombre,
                    alquiler.FormaPago.Nombre,
                    alquiler.Socio.Nombre + " " + alquiler.Socio.Apellido,
                    alquiler.Vendedor.Nombre + " " + alquiler.Vendedor.Apellido,
                    alquiler.FechaInicio.ToShortDateString(),
                    "$ "  + alquiler.CalcularTotal().ToString()
                };
                dgvAlquiler.Rows.Add(fila);
            }
        }

        private void btnNuevoAlquiler_Click(object sender, EventArgs e)
        {
            new RegistrarAlquiler(_unidadDeTrabajo).ShowDialog();
            ConsultarAlquileres();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            CargarFormasDePago();
            CargarTiposDeFactura();
            lblSocio.Text = "Socio: ";
            _socioFiltro = null;
            lblVendedor.Text = "Vendedor: ";
            _vendedorFiltro = null;
            ConsultarAlquileres();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            var nroAlquiler = Convert.ToInt32(dgvAlquiler.CurrentRow.Cells["NroAlquiler"].Value);
            var alquiler = _servicioAlquiler.GetPorId(nroAlquiler);
            new ConsultarDetalleAlquiler(alquiler.DetallesDeAlquiler, alquiler.CantidadDias()).ShowDialog();
        }

        private void btnConsultarSocio_Click(object sender, EventArgs e)
        {
            _consultaSocio = new ConsultaSocio(_unidadDeTrabajo, this);
            _consultaSocio.ShowDialog();
            string datos = _socioFiltro.GetNombreYApellido();
            lblSocio.Text = "Socio: " + datos;
        }

        public void SetSocioFiltro(Socio socio)
        {
            _socioFiltro = socio;
        }

        private void btnConsultarVendedor_Click(object sender, EventArgs e)
        {
            _consultaEmpleado = new ConsultaEmpleado(_unidadDeTrabajo, this);
            _consultaEmpleado.ShowDialog();
            string datos = _vendedorFiltro.GetNombreYApellido();
            lblVendedor.Text = "Vendedor: " + datos;
        }

        public void SetVendedorFiltro(Empleado empleado)
        {
            _vendedorFiltro = empleado;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Alquiler> alquileresFiltrados;
                if (!string.IsNullOrEmpty(txtNroAlquiler.Text))
                {
                    var nroAlquiler = Convert.ToInt32(txtNroAlquiler.Text);
                    alquileresFiltrados = _servicioAlquiler.Encontrar(alq => alq.NroAlquiler == nroAlquiler).ToList();
                    CargarDgvAlquileres(alquileresFiltrados);
                    return;
                }

                if (_socioFiltro == null)
                    _socioFiltro = new Socio() { Nombre = "", Apellido = "" };

                if (_vendedorFiltro == null)
                    _vendedorFiltro = new Empleado() { Nombre = "", Apellido = "" };

                var precioMin = numPrecioMin.Value;
                var precioMax = numPrecioMax.Value;
                if (precioMin > precioMax)
                    throw new ApplicationException("Ingrese un rango de precios válido.");

                var fechaDesde = dtpFechaDesde.Value;
                var fechaHasta = dtpFechaHasta.Value;
                if (fechaDesde > fechaHasta)
                    throw new ApplicationException("Ingrese un rango de fechas válido");

                var tipoFactura = (TipoFactura)cboTiposFactura.SelectedItem;
                if (tipoFactura == null)
                    tipoFactura = new TipoFactura() { Nombre = "" };

                var formaPago = (FormaPago)cboFormasPago.SelectedItem;
                if (formaPago == null)
                    formaPago = new FormaPago { Nombre = "" };

                var alquileres = _servicioAlquiler.ListarAlquileres();
                alquileresFiltrados = new List<Alquiler>();
                foreach (var alq in alquileres)
                {
                    if (alq.Socio.ContieneMismoNombreYApellido(_socioFiltro)
                   && alq.Vendedor.ContieneMismoNombreYApellido(_vendedorFiltro)
                   && alq.TipoFactura.Nombre.Contains(tipoFactura.Nombre) && alq.FormaPago.Nombre.Contains(formaPago.Nombre)
                   && alq.CalcularTotal() >= precioMin && alq.CalcularTotal() <= precioMax
                   && alq.FechaInicio >= fechaDesde && alq.FechaInicio <= fechaHasta)
                        alquileresFiltrados.Add(alq);
                }
                CargarDgvAlquileres(alquileresFiltrados);

            } 
            
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Información", MessageBoxButtons.OK);
            } 
            
            catch (FormatException)
            {
                MessageBox.Show("Ingrese un número válido", "Información", MessageBoxButtons.OK);
            }
        }
    }
}