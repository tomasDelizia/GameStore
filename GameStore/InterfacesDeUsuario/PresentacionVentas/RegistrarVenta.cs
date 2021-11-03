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
using GameStore.InterfacesDeUsuario.PresentacionArticulos;
using GameStore.InterfacesDeUsuario.PresentacionSocios;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using GameStore.Utils;

namespace GameStore.InterfacesDeUsuario.PresentacionVentas
{
    public partial class RegistrarVenta : Form
    {
        private IServicioTipoFactura _servicioTipoFactura;
        private IServicioFormaPago _servicioFormaPago;
        private Empleado _empleadoLogueado;
        private IServicioArticulo _servicioArticulo;
        private IServicioVenta _servicioVenta;
        private ConsultaArticulo _consultaArticulo;
        private ConsultaSocio _consultaSocio;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private Socio _socio;
        private List<DetalleVenta> _detallesDeVenta;
        private Venta _nuevaVenta;

        public RegistrarVenta(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvArticulos.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvArticulos.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioTipoFactura = new ServicioTipoFactura(_unidadDeTrabajo.RepositorioTipoFactura);
            _servicioFormaPago = new ServicioFormaPago(_unidadDeTrabajo.RepositorioFormaPago);
            IServicioUsuario servicioUsuario = new ServicioUsuario(_unidadDeTrabajo.RepositorioUsuario);
            _empleadoLogueado = servicioUsuario.GetEmpleadoLogueado();
            _servicioArticulo = new ServicioArticulo(_unidadDeTrabajo.RepositorioArticulo);
            _detallesDeVenta = new List<DetalleVenta>();
            _servicioVenta = new ServicioVenta(_unidadDeTrabajo.RepositorioVenta);
        }

        private void RegistrarVenta_Load(object sender, EventArgs e)
        {
            lblFechaActual.Text = "Fecha actual: " + DateTime.Today.ToShortDateString();
            CargarTiposFactura();
            CargarFormasDePago();
        }

        private void CargarTiposFactura()
        {
            var tiposFactura = _servicioTipoFactura.ListarTiposDeFactura();
            FormUtils.CargarCombo(ref cboTiposFactura, new BindingSource() { DataSource = tiposFactura}, "Nombre", "IdTipoFactura");
        }

        private void CargarFormasDePago()
        {
            var formasPago = _servicioFormaPago.ListarFormaPago();
            FormUtils.CargarCombo(ref cboFormasPago, new BindingSource() { DataSource = formasPago }, "Nombre", "IdFormaPago");
        }

        private void btnConsultarSocio_Click(object sender, EventArgs e)
        {
            _consultaSocio = new ConsultaSocio(_unidadDeTrabajo, this);
            _consultaSocio.ShowDialog();
            string datos = _socio.GetNombreYApellido();
            lblSocio.Text = "Socio: " + datos;

        }

        public void SetSocio(Socio socio)
        {
            _socio = socio;
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            _consultaArticulo = new ConsultaArticulo(_unidadDeTrabajo, this);
            _consultaArticulo.ShowDialog();
            ConsultarArticulos();
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.SelectedRows.Count == 1)
            {
                long idArticulo = Convert.ToInt64(dgvArticulos.SelectedRows[0].Cells["Codigo"].Value);
                Articulo articuloSeleccionado = _servicioArticulo.GetPorId(idArticulo);
                dgvArticulos.Rows.Remove(dgvArticulos.SelectedRows[0]);
                _detallesDeVenta.RemoveAll(detalle => detalle.Articulo == articuloSeleccionado);
                CalcularTotal();
                return;
            }
            if (dgvArticulos.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        internal void AgregarArticulo(Articulo articulo, int cantidad)
        {
            DetalleVenta nuevoDetalle = new DetalleVenta {
                Articulo = articulo,
                Cantidad = cantidad,
                PrecioUnitario = articulo.PrecioUnitario
            };
            _detallesDeVenta.Add(nuevoDetalle);
        }

        private void ConsultarArticulos()
        {
            CargarDgvArticulos(_detallesDeVenta);
            dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (var detalle in _detallesDeVenta)
            {
                var subtotal = detalle.CalcularSubtotal();
                total += subtotal;
            }
            txtTotal.Text = total.ToString();    
        }

        private void CargarDgvArticulos(List<DetalleVenta> detalles)
        {
            dgvArticulos.Rows.Clear();
            foreach(var detalle in detalles)
            {
                var fila = new string[]
                {
                    detalle.Articulo.Codigo.ToString(),
                    detalle.Articulo.Nombre,
                    "$ " + detalle.Articulo.PrecioUnitario.ToString(),
                    detalle.Articulo.Stock.ToString(),
                    detalle.Articulo.TipoArticulo.Nombre,
                    detalle.Articulo.Plataforma.Nombre,
                    detalle.Cantidad.ToString()
                };
                dgvArticulos.Rows.Add(fila);
            }
        }

        internal List<Articulo> GetArticulos()
        {
            var articulosSeleccionados = new List<Articulo>();
            foreach (var detalle in _detallesDeVenta)
                articulosSeleccionados.Add(detalle.Articulo);
            return articulosSeleccionados;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormUtils.EsOperacionConfirmada())
                    return;
                if (!EsVentaValida())
                    return;
                CrearVenta();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo concretar la transacción", "Error", MessageBoxButtons.OK);
                //_unidadDeTrabajo.Deshacer();
            }
        }

        private bool EsVentaValida()
        {
            Venta nuevaVenta = new Venta()
            {
                TipoFactura = (TipoFactura)cboTiposFactura.SelectedItem,
                FormaPago = (FormaPago)cboFormasPago.SelectedItem,
                Socio = _socio,
                Vendedor = _empleadoLogueado,
                FechaVenta = DateTime.Today,
            };
            foreach (var detalle in _detallesDeVenta)
            {
                nuevaVenta.AgregarDetalle(detalle);
            }
            _servicioVenta.ValidarVenta(nuevaVenta);
            _nuevaVenta = nuevaVenta;
            return true;
        }

        private void CrearVenta()
        {
            foreach (var detalle in _detallesDeVenta)
            {
                var articulo = detalle.Articulo;
                articulo.Stock -= detalle.Cantidad;
                _servicioArticulo.Actualizar(articulo);
            }
            _servicioVenta.Guardar(_nuevaVenta);
            _unidadDeTrabajo.Guardar();
            MessageBox.Show("Se registró con éxito la venta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
    }
}
