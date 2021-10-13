using GameStore.Entidades;
using GameStore.InterfacesDeUsuario.PresentacionArticulos;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
<<<<<<< HEAD
using GameStore.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
=======
using System;
using System.Collections.Generic;
>>>>>>> tomas
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
        private int _idProveedor;
        private Proveedor _proveedor;
        private IServicioProveedor _servicioProveedor;
        private ConsultaArticulo _consultaArticulo;
        private ICollection<DetalleCompra> _detallesCompra;
        private IServicioTipoFactura _servicioTipoFactura;
        private TipoFactura _tipoFactura;
        private List<Articulo> _Articulos;
        private IServicioArticulo _servicioArticulo;
        private Empleado _empleadoLogueado;
        public RegistrarCompra(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvArticulos.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvArticulos.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioProveedor = new ServicioProveedor(_unidadDeTrabajo.RepositorioProveedor);
            _servicioArticulo = new ServicioArticulo(_unidadDeTrabajo.RepositorioArticulo);
            _empleadoLogueado = servicioUsuario.GetEmpleadoLogueado();
            _servicioTipoFactura = new ServicioTipoFactura(_unidadDeTrabajo.RepositorioTipoFactura);
            _Articulos = new List<Articulo>();
            IServicioUsuario servicioUsuario = new ServicioUsuario(_unidadDeTrabajo.RepositorioUsuario);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        internal void setIdProveedor(int id)
        {
            this._idProveedor = id;
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            _consultaArticulo = new ConsultaArticulo(_unidadDeTrabajo, this);
            _consultaArticulo.ShowDialog();
            ConsultarArticulos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _consultaProveedor = new ConsultaProveedor(_unidadDeTrabajo, this);
            _consultaProveedor.ShowDialog();
            _proveedor = _servicioProveedor.GetPorId(_idProveedor);
            string datosProveedor = _proveedor.GetRazonSocial();
            lblProveedor.Text = datosProveedor;
        }

        private void RegistrarCompra_Load(object sender, EventArgs e)
        {
            lblFechaActual.Text = "Fecha actual: " + DateTime.Today.ToShortDateString();
            dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CargarTiposFactura();
        }

        private void CargarTiposFactura()
        {
            var tiposFactura = _servicioTipoFactura.ListarTiposDeFactura();
            FormUtils.CargarCombo(ref cboTiposFactura, new BindingSource() { DataSource = tiposFactura }, "Nombre", "IdTipoFactura");
        }
        public void AgregarArticulo(Articulo articulo)
        {
            _articulos.Add(articulo);
        }
        private void ConsultarArticulos()
        {
            CargarDgvArticulos(_Articulos);
	}
        private void CargarDgvArticulos(List<Articulo> articulos)
        {
            dgvArticulos.Rows.Clear();

            foreach (var articulo in articulos)
            {
                var fila = new string[]
                {
                    articulo.Codigo.ToString(),
                    articulo.Nombre,
                    "$ " + articulo.PrecioUnitario.ToString(),
                    articulo.Stock.ToString(),
                    articulo.TipoArticulo.Nombre,
                    articulo.Plataforma.Nombre.ToString(),
                };
                dgvArticulos.Rows.Add(fila);
            }
        }
        public List<Articulo> GetArticulos()
        {
            return this._Articulos;
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            
            if (dgvArticulos.SelectedRows.Count == 1)
            {
                int idArticulo = Convert.ToInt32(dgvArticulos.SelectedRows[0].Cells["Codigo"].Value);
                Articulo articuloSeleccionado = _servicioArticulo.GetPorId(idArticulo);
                dgvArticulos.Rows.Remove(dgvArticulos.SelectedRows[0]);
                _Articulos.Remove(articuloSeleccionado);
                return;
            }
            if (dgvArticulos.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }
        public void AgregarArticulo(string[] fila)
        {
            dgvArticulos.Rows.Add(fila);
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                _tipoFactura = (TipoFactura)cboTiposFactura.SelectedItem;
                ICollection<DetalleCompra> detallesCompra = CrearDetallesCompra();

                Compra nuevaCompra = new Compra()
                {
                    Empleado = _empleadoLogueado,
                    FechaCompra = DateTime.Today,
                    Proveedor = _proveedor,
                    TipoFactura = _tipoFactura,
                    DetallesDeCompra = detallesCompra,
                };
            }
            catch(Exception ex)
            {

            }
        }

        private ICollection<DetalleCompra> CrearDetallesCompra()
        {
            ICollection<DetalleCompra> detalles = new Collection<DetalleCompra>();
            foreach (Articulo articulo in _articulos)
            {
                DetalleCompra detalle = new DetalleCompra()
                {
                    Articulo = articulo,
                    PrecioUnitario = articulo.PrecioUnitario,
                    Cantidad = Convert.ToInt32(dgvArticulos.SelectedRows[0].Cells["Cantidad"].Value),
                };
                detalles.Add(detalle);
            };
            return detalles;
        }
        //private ICollection<DetalleCompra> CrearDetallesCompra()
        //{
        //    foreach (Articulo articulo in _Articulos)
        //    {
        //        DetalleCompra detalle = new DetalleCompra()
        //        {
        //            Articulo = articulo,
        //            PrecioUnitario = articulo.PrecioUnitario,
        //            Cantidad = Convert.ToInt32(dgvArticulos.SelectedRows[0].Cells["Cantidad"]),
        //        };
        //    };
        //}
    }
}
