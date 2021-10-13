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
        private IServicioSocio _servicioSocio;
        private IServicioFormaPago _servicioFormaPago;
        private IServicioUsuario _servicioUsuario;
        private IServicioArticulo _servicioArticulo;
        private ConsultaArticulo _consultaArticulo;
        private ConsultaSocio _consultaSocio;
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private Socio _socio;
        private List<Articulo> _articulosSeleccionados;

        public RegistrarVenta(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioTipoFactura = new ServicioTipoFactura(_unidadDeTrabajo.RepositorioTipoFactura);
            _servicioSocio = new ServicioSocio(_unidadDeTrabajo.RepositorioSocio);
            _servicioFormaPago = new ServicioFormaPago(_unidadDeTrabajo.RepositorioFormaPago);
            _servicioUsuario = new ServicioUsuario(_unidadDeTrabajo.RepositorioUsuario);
            _servicioArticulo = new ServicioArticulo(_unidadDeTrabajo.RepositorioArticulo);
            _articulosSeleccionados = new List<Articulo>();
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
            string datos = _socio.GetApellidoYNombre();
            lblSocio.Text = "Socio: " + datos;

        }

        public void BuscarSocio(int idSocio)
        {
            _socio = _servicioSocio.GetPorId(idSocio);
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
                _articulosSeleccionados.Remove(articuloSeleccionado);
                return;
            }
            if (dgvArticulos.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        internal void AgregarArticulo(Articulo articulo)
        {
            _articulosSeleccionados.Add(articulo);
        }

        private void ConsultarArticulos()
        {
            CargarDgvArticulos(_articulosSeleccionados);
            dgvArticulos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        internal List<Articulo> GetArticulos()
        {
            return _articulosSeleccionados;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
