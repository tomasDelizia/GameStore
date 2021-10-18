using GameStore.Entidades;
using GameStore.InterfacesDeUsuario.PresentacionArticulos;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using GameStore.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.PresentacionCompras
{
    public partial class RegistrarCompra : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private ConsultaProveedor _consultaProveedor;
        private Proveedor _proveedor;
        private IServicioProveedor _servicioProveedor;
        private ConsultaArticulo _consultaArticulo;
        private IServicioTipoFactura _servicioTipoFactura;
        private IServicioArticulo _servicioArticulo;
        private Empleado _empleadoLogueado;
        private ICollection<DetalleCompra> _detallesCompra;
        private IServicioCompra _servicioCompra;
        private Compra _nuevaCompra;
        private List<DetalleCompra> _detallesDeCompra;
        private string[][] _ArticulosSeleccionados;
        public RegistrarCompra(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvArticulos.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvArticulos.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioProveedor = new ServicioProveedor(_unidadDeTrabajo.RepositorioProveedor);
            _servicioArticulo = new ServicioArticulo(_unidadDeTrabajo.RepositorioArticulo);
            IServicioUsuario servicioUsuario = new ServicioUsuario(_unidadDeTrabajo.RepositorioUsuario);
            _empleadoLogueado = servicioUsuario.GetEmpleadoLogueado();
            _servicioTipoFactura = new ServicioTipoFactura(_unidadDeTrabajo.RepositorioTipoFactura);
            _servicioCompra = new ServicioCompra(_unidadDeTrabajo.RepositorioCompra);
            _detallesDeCompra = new List<DetalleCompra>();
        }

        private void RegistrarCompra_Load(object sender, EventArgs e)
        {
            lblFechaActual.Text = "Fecha actual: " + DateTime.Today.ToShortDateString();
            CargarTiposFactura();
        }

        private void CargarTiposFactura()
        {
            var tiposFactura = _servicioTipoFactura.ListarTiposDeFactura();
            FormUtils.CargarCombo(ref cboTiposFactura, new BindingSource() { DataSource = tiposFactura }, "Nombre", "IdTipoFactura");
        }
        private void btnConsultarProveedor_Click(object sender, EventArgs e)
        {
            _consultaProveedor = new ConsultaProveedor(_unidadDeTrabajo, this);
            _consultaProveedor.ShowDialog();
            string datosProveedor = _proveedor.GetRazonSocial();
            lblProveedor.Text = "Proveedor: " + datosProveedor;
        }
        public void BuscarProveedor(int id)
        {
            _proveedor = _servicioProveedor.GetPorId(id);
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
                int idArticulo = Convert.ToInt32(dgvArticulos.SelectedRows[0].Cells["Codigo"].Value);
                Articulo articuloSeleccionado = _servicioArticulo.GetPorId(idArticulo);
                dgvArticulos.Rows.Remove(dgvArticulos.SelectedRows[0]);
                _detallesDeCompra.RemoveAll(detalle => detalle.Articulo == articuloSeleccionado);
                CalcularTotal();
                return;
            }
            if (dgvArticulos.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }
        public void AgregarArticulo(Articulo articulo, int cantidad)
        {
            DetalleCompra nuevoDetalle = new DetalleCompra
            {
                Articulo = articulo,
                Cantidad = cantidad,
                PrecioUnitario = articulo.PrecioUnitario
            };
            _detallesDeCompra.Add(nuevoDetalle);
        }
		
        private void ConsultarArticulos()
        {
            CargarDgvArticulos(_detallesDeCompra);
            dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CalcularTotal();
        }
        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (var detalle in _detallesDeCompra)
            {
                var subtotal = detalle.CalcularSubtotal();
                total += subtotal;
            }
            txtTotal.Text = "$ " + total;
        }

        private void CargarDgvArticulos(List<DetalleCompra> detalles)
        {
            dgvArticulos.Rows.Clear();
            foreach (var detalle in detalles)
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
        public List<Articulo> GetArticulos()
        {
            var articulosSeleccionados = new List<Articulo>();
            foreach (var detalle in _detallesDeCompra)
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
                if (!EsCompraValida())
                    return;
                CrearCompra();
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

        private bool EsCompraValida()
        {
            Compra nuevaCompra = new Compra()
            {
                EncargadoCompra = _empleadoLogueado,
                FechaCompra = DateTime.Today,
                Proveedor = _proveedor,
                TipoFactura = (TipoFactura)cboTiposFactura.SelectedItem,
            };
            foreach (var detalle in _detallesDeCompra)
            {
                nuevaCompra.AgregarDetalle(detalle);
            }
            _servicioCompra.ValidarCompra(nuevaCompra);
            _nuevaCompra = nuevaCompra;
            return true;
        }
        private void CrearCompra()
        {
            foreach (var detalle in _detallesDeCompra)
            {
                var articulo = detalle.Articulo;
                articulo.Stock += detalle.Cantidad;
                _servicioArticulo.Actualizar(articulo);
            }
            _servicioCompra.Guardar(_nuevaCompra);
            _unidadDeTrabajo.Guardar();
            MessageBox.Show("Se registró con éxito la compra", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

    }
}
