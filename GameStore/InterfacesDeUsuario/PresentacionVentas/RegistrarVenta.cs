using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStore.InterfacesDeUsuario.PresentacionArticulos;
using GameStore.RepositoriosBD;

namespace GameStore.InterfacesDeUsuario.PresentacionVentas
{
    public partial class RegistrarVenta : Form
    {
        private IServicioTipoFactura _servicioTipoFactura;
        private ConsultaArticulo consultaArticulo;
        private IUnidadDeTrabajo _unidadDeTrabajo;

        public RegistrarVenta(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        private void NuevaVenta_Load(object sender, EventArgs e)
        {
            lblFechaActual.Text = "Fecha actual: " + DateTime.Today.ToShortDateString();
            CargarTiposFactura();
        }

        private void CargarTiposFactura()
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            consultaArticulo = new ConsultaArticulo(_unidadDeTrabajo);
            consultaArticulo.SetBotonesParaVenta();
            consultaArticulo.ShowDialog();
        }
    }
}
