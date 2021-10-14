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
        private int _idProveedor;
        private Proveedor _proveedor;
        private IServicioProveedor _servicioProveedor;
        private ConsultaArticulo _consultaArticulo;
        private IServicioTipoFactura _servicioTipoFactura;
        private TipoFactura _tipoFactura;
        private List<Articulo> _Articulos;
        private IServicioArticulo _servicioArticulo;
        private Empleado _empleadoLogueado;
        private ICollection<DetalleCompra> _detallesCompra;
        private IServicioCompra _servicioCompra;
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
            _Articulos = new List<Articulo>();
            _servicioCompra = new ServicioCompra(_unidadDeTrabajo.RepositorioCompra);
            _ArticulosSeleccionados = new string[999999][];
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
            FormUtils.CargarCombo(ref cboTipoFactura, new BindingSource() { DataSource = tiposFactura }, "Nombre", "IdTipoFactura");
        }

        public void AgregarArticulo(Articulo articulo, int cantidad)
        {
            _Articulos.Add(articulo);
            string[] tupla = new string[]
                {
                    articulo.Codigo.ToString(),
                    articulo.Nombre,
                    "$ " + articulo.PrecioUnitario.ToString(),
                    articulo.Stock.ToString(),
                    articulo.TipoArticulo.Nombre,
                    articulo.Plataforma.Nombre.ToString(),
                    cantidad.ToString(),
                };
            _ArticulosSeleccionados[_Articulos.Count-1] = tupla;
        }
		
        private void ConsultarArticulos()
        {
            CargarDgvArticulos();
		}
		
        private void CargarDgvArticulos()
        {
            dgvArticulos.Rows.Clear();
            int length = _ArticulosSeleccionados.Count();
            for (int i = 0; i < length; i++)
            {
                if (_ArticulosSeleccionados[i] != null)
                    dgvArticulos.Rows.Add(_ArticulosSeleccionados[i]);
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
                Compra compra = CrearCompra();
                _servicioCompra.Guardar(compra);
                _unidadDeTrabajo.Guardar();
                MessageBox.Show("Se registró la compra con éxito", "Información", MessageBoxButtons.OK);
                this.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se pudo concretar la transacción", "Error", MessageBoxButtons.OK);
                //_unidadDeTrabajo.Deshacer();
            }
        }

        private Compra CrearCompra()
        {
            _tipoFactura = (TipoFactura)cboTipoFactura.SelectedItem;
            Compra nuevaCompra = new Compra()
            {
                EncargadoCompra = _empleadoLogueado,
                FechaCompra = DateTime.Today,
                Proveedor = _proveedor,
                TipoFactura = _tipoFactura,
            };
            int length = _Articulos.Count;
            for (int i = 0; i < length; i++)
            {
                int cant = Convert.ToInt32(dgvArticulos.Rows[i].Cells["Cantidad"].Value);
                Articulo articulo = _Articulos[i];
                DetalleCompra detalle = new DetalleCompra()
                {
                    Articulo = articulo,
                    PrecioUnitario = articulo.PrecioUnitario,
                    Cantidad = cant,
                };
                nuevaCompra.AddDetalle(detalle);
                ActualizarStock(articulo, cant);
            }       
            return nuevaCompra;
        }

        private void ActualizarStock(Articulo articulo, int cantidad)
        {
            articulo.Stock += cantidad;
        }
    }
}
