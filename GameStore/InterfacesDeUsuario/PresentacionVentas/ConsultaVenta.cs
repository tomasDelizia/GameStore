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

namespace GameStore.InterfacesDeUsuario.PresentacionVentas
{
    public partial class ConsultaVenta : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IServicioVenta _servicioVenta;
        private IServicioTipoFactura _servicioTipoFactura;
        private IServicioFormaPago _servicioFormaPago;
        private ConsultaSocio _consultaSocio;
        private ConsultaEmpleado _consultaEmpleado;
        private Socio _socioFiltro;
        private Empleado _vendedorFiltro;


        public ConsultaVenta(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvVentas.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvVentas.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioVenta = new ServicioVenta(unidadDeTrabajo.RepositorioVenta);
            _servicioFormaPago = new ServicioFormaPago(unidadDeTrabajo.RepositorioFormaPago);
            _servicioTipoFactura = new ServicioTipoFactura(unidadDeTrabajo.RepositorioTipoFactura);
        }

        private void ConsultaVenta_Load(object sender, EventArgs e)
        {
            CargarFormasDePago();
            CargarTiposDeFactura();
            ConsultarVentas();
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

        private void ConsultarVentas()
        {
            var ventas = _servicioVenta.ListarVentas();
            CargarDgvVentas(ventas);
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarDgvVentas(List<Venta> ventas)
        {
            dgvVentas.Rows.Clear();
            foreach (var venta in ventas)
            {
                var fila = new string[]
                {
                    venta.NroFactura.ToString(),
                    venta.TipoFactura.Nombre,
                    venta.FormaPago.Nombre,
                    venta.Socio.Nombre + " " + venta.Socio.Apellido,
                    venta.Vendedor.Nombre + " " + venta.Vendedor.Apellido,
                    venta.FechaVenta.ToShortDateString(),
                    "$ "  + venta.CalcularTotal().ToString()
                };
                dgvVentas.Rows.Add(fila);
            }
        }

        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            new RegistrarVenta(_unidadDeTrabajo).ShowDialog();
            ConsultarVentas();
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
            ConsultarVentas();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            var nroFactura = Convert.ToInt32(dgvVentas.CurrentRow.Cells["NroFactura"].Value);
            var venta = _servicioVenta.GetPorId(nroFactura);
            new ConsultaDetalleVenta(venta.DetallesDeVenta).ShowDialog();
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
                List<Venta> ventasFiltradas;
                if (!string.IsNullOrEmpty(txtNroFactura.Text))
                {
                    var nroFactura = Convert.ToInt32(txtNroFactura.Text);
                    ventasFiltradas = _servicioVenta.Encontrar(v => v.NroFactura == nroFactura).ToList();
                    CargarDgvVentas(ventasFiltradas);
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

                var ventas = _servicioVenta.ListarVentas();
                ventasFiltradas = new List<Venta>();
                foreach(var v in ventas)
                {
                    if (v.Socio.ContieneMismoNombreYApellido(_socioFiltro)
                   && v.Vendedor.ContieneMismoNombreYApellido(_vendedorFiltro)
                   && v.TipoFactura.Nombre.Contains(tipoFactura.Nombre) && v.FormaPago.Nombre.Contains(formaPago.Nombre)
                   && v.CalcularTotal() >= precioMin && v.CalcularTotal() <= precioMax
                   && v.FechaVenta >= fechaDesde && v.FechaVenta <= fechaHasta)
                        ventasFiltradas.Add(v);
                }
                CargarDgvVentas(ventasFiltradas);

            } catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Información", MessageBoxButtons.OK);
            } catch (FormatException)
            {
                MessageBox.Show("Ingrese un número válido", "Información", MessageBoxButtons.OK);
            }

        }
    }
}
