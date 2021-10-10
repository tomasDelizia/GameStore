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
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private IServicioTipoFactura _servicioTipoFactura;
        private IServicioFormaPago _servicioFormaPago;
        private IServicioSocio _servicioSocio;
        private IServicioArticulo _servicioArticulo;
        private ConsultaSocio _consultaSocio;
        private ConsultaArticulo _consultaArticulo;
        private List<Articulo> _Articulos;
        private Empleado _empleadoLogueado;
        private Socio _socio;
        private ICollection<Alquiler> _detalleAlquiler;
        private int idSocio;

        public RegistrarAlquiler(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            dgvJuegos.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            dgvJuegos.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioArticulo = new ServicioArticulo(_unidadDeTrabajo.RepositorioArticulo);
            _servicioSocio = new ServicioSocio(_unidadDeTrabajo.RepositorioSocio);
            _servicioTipoFactura = new ServicioTipoFactura(_unidadDeTrabajo.RepositorioTipoFactura);
            _servicioFormaPago = new ServicioFormaPago(_unidadDeTrabajo.RepositorioFormaPago);
            _Articulos = new List<Articulo>();
            IServicioUsuario servicioUsuario = new ServicioUsuario(_unidadDeTrabajo.RepositorioUsuario);
            _empleadoLogueado = servicioUsuario.GetEmpleadoLogueado();
        }

        private void RegistrarAlquiler_Load(object sender, EventArgs e)
        {
            lblFechaActual.Text = "Fecha actual: " + DateTime.Today.ToShortDateString();
            CargarTiposFactura();
            CargarFormasPago();
        }

        internal void setIdSocio(int id)
        {
            this.idSocio = id;
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _consultaSocio = new ConsultaSocio(_unidadDeTrabajo, this);
            _consultaSocio.ShowDialog();
            _socio = _servicioSocio.GetPorId(idSocio);
            string datos = _socio.GetApellidoYNombre();
            lblSocio.Text = datos;
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            //_consultaArticulo = new ConsultaArticulo(_unidadDeTrabajo, this);
            _consultaArticulo.ShowDialog();
            ConsultarArticulos();
        }

        private void ConsultarArticulos()
        {
            CargarDgvJuegos(_Articulos);
            dgvJuegos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //falta terminar de completar esto que nose que mas poner y preguntar que son los metodos de abajo que 
        //uso gaston en su transaccion y agregarle el tipo de factura a su transaccion
        private void CargarDgvJuegos(List<Articulo> articulos)
        {
            dgvJuegos.Rows.Clear();

            foreach (var articulo in articulos)
            {
                var fila = new string[]
                {
                    articulo.Codigo.ToString(),
                    articulo.Nombre,
                    "$ " + articulo.PrecioUnitario.ToString(),
                    articulo.TipoArticulo.Nombre,
                    articulo.Plataforma.Nombre.ToString(),
                };
                dgvJuegos.Rows.Add(fila);
            }
        }


    }
}
