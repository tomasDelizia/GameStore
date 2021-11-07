using GameStore.Entidades;
using GameStore.InterfacesDeUsuario.PresentacionEmpleados;
using GameStore.InterfacesDeUsuario.PresentacionVentas;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using GameStore.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionCompras
{
    public partial class ConsultaCompra : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IServicioCompra _servicioCompra;
        private IServicioTipoFactura _servicioTipoFactura;
        private ConsultaEmpleado _consultaEmpleado;
        private ConsultaProveedor _consultaProveedor;
        private Proveedor _proveedorFiltro;
        private Empleado _compradorFiltro;

        public ConsultaCompra(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvCompras.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvCompras.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioCompra = new ServicioCompra(_unidadDeTrabajo.RepositorioCompra);
            _servicioTipoFactura = new ServicioTipoFactura(_unidadDeTrabajo.RepositorioTipoFactura);
        }

        private void ConsultaCompra_Load(object sender, EventArgs e)
        {
            CargarTiposDeFactura();
            ConsultarCompras();
        }

        private void ConsultarCompras()
        {
            var compras = _servicioCompra.ListarCompras();
            CargarDgvCompras(compras);
        }

        private void CargarDgvCompras(List<Compra> compras)
        {
            dgvCompras.Rows.Clear();
            foreach (var compra in compras)
            {
                var fila = new string[]
                {
                    compra.NroFactura.ToString(),
                    compra.TipoFactura.Nombre,
                    compra.Proveedor.RazonSocial,
                    compra.EncargadoCompra.Nombre + " " + compra.EncargadoCompra.Apellido,
                    compra.FechaCompra.ToShortDateString(),
                    "$ "  + compra.CalcularTotal().ToString()
                };
                dgvCompras.Rows.Add(fila);
            }
        }

        private void CargarTiposDeFactura()
        {
            var tiposFactura = _servicioTipoFactura.ListarTiposDeFactura();
            FormUtils.CargarCombo(ref cboTiposFactura, new BindingSource() { DataSource = tiposFactura }, "Nombre", "IdTipoFactura");
        }

        private void btnNuevaCompra_Click(object sender, EventArgs e)
        {
            new RegistrarCompra(_unidadDeTrabajo).ShowDialog();
            ConsultarCompras();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnReiniciarFiltros_Click(object sender, EventArgs e)
        {
            CargarTiposDeFactura();
            lblProveedor.Text = "Proveedor: ";
            _proveedorFiltro = null;
            lblComprador.Text = "Comprador: ";
            _compradorFiltro = null;
            ConsultarCompras();
        }

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            var nroFactura = Convert.ToInt32(dgvCompras.CurrentRow.Cells["NroFactura"].Value);
            var compra = _servicioCompra.GetPorId(nroFactura);
            new ConsultaDetalleCompra(compra.DetallesDeCompra).ShowDialog();
        }

        private void btnConsultarProveedor_Click(object sender, EventArgs e)
        {
            _consultaProveedor = new ConsultaProveedor(_unidadDeTrabajo, this);
            _consultaProveedor.ShowDialog();
            string datos = _proveedorFiltro.GetRazonSocial();
            lblProveedor.Text = "Socio: " + datos;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Compra> comprasFiltradas;
                if (!string.IsNullOrEmpty(txtNroFactura.Text))
                {
                    var nroFactura = Convert.ToInt32(txtNroFactura.Text);
                    comprasFiltradas = _servicioCompra.Encontrar(v => v.NroFactura == nroFactura).ToList();
                    CargarDgvCompras(comprasFiltradas);
                    return;
                }
                if (_proveedorFiltro == null)
                    _proveedorFiltro = new Proveedor() { RazonSocial = "" };

                if (_compradorFiltro == null)
                    _compradorFiltro = new Empleado() { Nombre = "", Apellido = "" };

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

                var compras = _servicioCompra.ListarCompras();
                comprasFiltradas = new List<Compra>();
                foreach (var c in compras)
                {
                    if (c.Proveedor.ContieneMismaRazonSocial(_proveedorFiltro)
                   && c.EncargadoCompra.ContieneMismoNombreYApellido(_compradorFiltro)
                   && c.TipoFactura.Nombre.Contains(tipoFactura.Nombre)
                   && c.CalcularTotal() >= precioMin && c.CalcularTotal() <= precioMax
                   && c.FechaCompra >= fechaDesde && c.FechaCompra <= fechaHasta)
                        comprasFiltradas.Add(c);
                }
                CargarDgvCompras(comprasFiltradas);

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

        private void btnConsultarComprador_Click(object sender, EventArgs e)
        {
            _consultaEmpleado = new ConsultaEmpleado(_unidadDeTrabajo, this);
            _consultaEmpleado.ShowDialog();
            string datos = _compradorFiltro.GetNombreYApellido();
            lblComprador.Text = "Comprador: " + datos;
        }

        public void SetCompradorFiltro(Empleado empleado)
        {
            _compradorFiltro = empleado;
        }
    }
}
