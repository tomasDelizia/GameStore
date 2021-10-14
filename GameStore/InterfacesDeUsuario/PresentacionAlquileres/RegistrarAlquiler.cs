using GameStore.Entidades;
using GameStore.InterfacesDeUsuario.PresentacionArticulos;
using GameStore.InterfacesDeUsuario.PresentacionSocios;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStore.Utils;

namespace GameStore.InterfacesDeUsuario.PresentacionAlquileres
{
    public partial class RegistrarAlquiler : Form
    {
        private IServicioTipoFactura _servicioTipoFactura;
        private IServicioSocio _servicioSocio;
        private IServicioFormaPago _servicioFormaPago;
        private IServicioUsuario _servicioUsuario;
        private IServicioArticulo _servicioArticulo;
        private IServicioAlquiler _servicioAlquiler;
        private IUnidadDeTrabajo _unidadDeTrabajo;        
        private ConsultaSocio _consultaSocio;
        private ConsultaArticulo _consultaArticulo;
        private List<Articulo> _Articulos;
        private List<DetalleAlquiler> _detalleAlquilers;
        private Empleado _empleadoLogueado;
        private Socio _socio;
        private Alquiler _nuevoAlquiler;
        private int idSocio;
        private decimal _MontoSenia;

        public RegistrarAlquiler(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvJuegos.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvJuegos.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioArticulo = new ServicioArticulo(_unidadDeTrabajo.RepositorioArticulo);
            _servicioSocio = new ServicioSocio(_unidadDeTrabajo.RepositorioSocio);
            _servicioTipoFactura = new ServicioTipoFactura(_unidadDeTrabajo.RepositorioTipoFactura);
            _servicioUsuario = new ServicioUsuario(_unidadDeTrabajo.RepositorioUsuario);
            _servicioFormaPago = new ServicioFormaPago(_unidadDeTrabajo.RepositorioFormaPago);
            _Articulos = new List<Articulo>();
            _detalleAlquilers = new List<DetalleAlquiler>();
            IServicioUsuario servicioUsuario = new ServicioUsuario(_unidadDeTrabajo.RepositorioUsuario);
            _servicioAlquiler = new ServicioAlquiler(_unidadDeTrabajo.RepositorioAlquiler);
            _empleadoLogueado = servicioUsuario.GetEmpleadoLogueado();
        }

        private void RegistrarAlquiler_Load(object sender, EventArgs e)
        {
            lblFechaActual.Text = "Fecha actual: " + DateTime.Today.ToShortDateString();
            CargarTiposFactura();
            CargarFormasPago();
        }

        private void CargarFormasPago()
        {
            var formaPago = _servicioFormaPago.ListarFormaPago();
            FormUtils.CargarCombo(ref cboFormaPago, new BindingSource() { DataSource = formaPago }, "Nombre", "IdFormaPago");
        }

        private void CargarTiposFactura()
        {
            var tiposFactura = _servicioTipoFactura.ListarTiposDeFactura();
            FormUtils.CargarCombo(ref cboTiposFactura, new BindingSource() { DataSource = tiposFactura }, "Nombre", "IdTipoFactura");
        }

        private void btnConsultarSocio_Click(object sender, EventArgs e)
        {
            _consultaSocio = new ConsultaSocio(_unidadDeTrabajo, this);
            _consultaSocio.ShowDialog();
            _socio = _servicioSocio.GetPorId(idSocio);
            string datos = _socio.GetApellidoYNombre();
            lblSocio.Text = datos;
        }

        internal void setIdSocio(int id)
        {
            this.idSocio = id;
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblDias.Text == "")
                    throw new ApplicationException("Ingrese cantidad de dias de alquiler");
                _consultaArticulo = new ConsultaArticulo(_unidadDeTrabajo, this);
                _consultaArticulo.ShowDialog();
                ConsultarArticulos();
            }
            catch (ApplicationException aex){
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            if (dgvJuegos.SelectedRows.Count == 1)
            {
                int idArticulo = Convert.ToInt32(dgvJuegos.SelectedRows[0].Cells["Codigo"].Value);
                Articulo articuloSeleccionado = _servicioArticulo.GetPorId(idArticulo);
                dgvJuegos.Rows.Remove(dgvJuegos.SelectedRows[0]);
                _Articulos.Remove(articuloSeleccionado);
                return;
            }
            if (dgvJuegos.SelectedRows.Count > 1)
                MessageBox.Show("Debe seleccionar un solo registro, no muchos.", "Información", MessageBoxButtons.OK);
        }

        internal void AgregarArticulo(Articulo articulo)
        {
            DetalleAlquiler nuevoDetalle = new DetalleAlquiler
            {
                Articulo = articulo,
                MontoAlquilerPorDia = articulo.GetMontoAlquiler(),
                MontoDevolucionTardiaPorDia = articulo.GetMontoAlquilerTardio()
            };
            _detalleAlquilers.Add(nuevoDetalle);
        }

        private void ConsultarArticulos()
        {
            CargarDgvJuegos(_detalleAlquilers);
            dgvJuegos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CalcularTotal();

        }

        private void CalcularTotal()
        {
            decimal total = 0;
            decimal seña = 0;
            decimal porcentajeSeña = 0.30m;
            int cantidadDias = Convert.ToInt32(lblDias.Text);
            foreach (var detalle in _detalleAlquilers)
            {
                var subtotal = detalle.MontoAlquilerPorDia * cantidadDias;
                total += subtotal;
            }
            lblTotal.Text = total.ToString();
            seña = total * porcentajeSeña;
            lblSeña.Text = seña.ToString();
        }

        private void CargarDgvJuegos(List<DetalleAlquiler> detalles)
        {
            dgvJuegos.Rows.Clear();

            foreach (var detalle in detalles)
            {
                var fila = new string[]
                {
                    detalle.Articulo.Codigo.ToString(),
                    detalle.Articulo.Nombre,
                    detalle.Articulo.TipoArticulo.Nombre,
                    detalle.Articulo.Plataforma.Nombre.ToString(),
                    "$ " + detalle.MontoAlquilerPorDia.ToString(),
                };
                dgvJuegos.Rows.Add(fila);
            }
        }

        public List<Articulo> GetArticulos()
        {
            var articulosSeleccionados = new List<Articulo>();
            foreach (var detalle in _detalleAlquilers)
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
                if (!EsAlquilerValido())
                    return;
                CrearAlquiler();
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo concretar la transacción", "Error", MessageBoxButtons.OK);
                _unidadDeTrabajo.Deshacer();
            }
        }

        private bool EsAlquilerValido()
        {
            Alquiler nuevoAlquiler = new Alquiler()
            {
                TipoFactura = (TipoFactura)cboTiposFactura.SelectedItem,
                FormaPago = (FormaPago)cboFormaPago.SelectedItem,
                Socio = _socio,
                MontoSenia = _MontoSenia,
                Vendedor = _empleadoLogueado,
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today.AddDays(Convert.ToInt32(lblDias))

            };
            foreach (var detalle in _detalleAlquilers)
            {
                nuevoAlquiler.AgregarDetalle(detalle);
            }
            _servicioAlquiler.ValidarAlquiler(nuevoAlquiler);
            _nuevoAlquiler = nuevoAlquiler;
            return true;
        }

        private void CrearAlquiler()
        {
            foreach (var detalle in _detalleAlquilers)
            {
                var articulo = detalle.Articulo;
                articulo.Stock -= 1;
                _servicioArticulo.Actualizar(articulo);
            }
            _servicioAlquiler.Guardar(_nuevoAlquiler);
            _unidadDeTrabajo.Guardar();
            MessageBox.Show("Se registró con éxito el alquiler", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
    }
}
