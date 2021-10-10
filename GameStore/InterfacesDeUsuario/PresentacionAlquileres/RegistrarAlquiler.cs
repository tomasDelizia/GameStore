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
            _servicioTipoFactura = new ServicioTipoFactura(_unidadDeTrabajo.RepositorioTipoFactura);
            _servicioFormaPago = new ServicioFormaPago(_unidadDeTrabajo.RepositorioFormaPago);
            _Articulos = new List<Articulo>();
            IServicioUsuario servicioUsuario = new ServicioUsuario(_unidadDeTrabajo.RepositorioUsuario);
            _empleadoLogueado = servicioUsuario.GetEmpleadoLogueado();
        }

        private void RegistrarAlquiler_Load(object sender, EventArgs e)
        {
            lblFechaActual.Text = "Fecha actual: " + DateTime.Today.ToShortDateString();
            lblSocio.Text = "asd";
            CargarTiposFactura();
            CargarFormasPago();
        }

        private void CargarFormasPago()
        {
            var formaPago = _servicioTipoFactura.ListarTiposDeFactura();
            FormUtils.CargarCombo(ref cboTiposFactura, new BindingSource() { DataSource = formaPago }, "Nombre", "IdFormaPago");
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
            lblSocio.Text = _socio.Nombre;
        }
    }
}
