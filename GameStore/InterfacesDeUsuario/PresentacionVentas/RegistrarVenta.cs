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
            FormUtils.CargarCombo(ref cboTiposFactura, new BindingSource() { DataSource = tiposFactura }, "Nombre", "IdTipoFactura");
        }

        private void CargarFormasDePago()
        {
            var formasPago = _servicioFormaPago.ListarFormaPago();
            FormUtils.CargarCombo(ref cboFormasPago, new BindingSource() { DataSource = formasPago }, "Nombre", "IdFormaPago");
        }

        private void btnConsultarSocio_Click(object sender, EventArgs e)
        {
            //_consultaSocio = new ConsultaSocio(_unidadDeTrabajo, this);
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

        }

        private void btnEliminarArticulo_Click(object sender, EventArgs e)
        {

        }

        internal void AgregarArticulo(Articulo articulo)
        {
            _articulosSeleccionados.Add(articulo);
        }

        internal List<Articulo> GetArticulos()
        {
            return _articulosSeleccionados;
        }
    }
}
