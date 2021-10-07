using GameStore.Entidades;
using GameStore.InterfacesDeUsuario.PresentacionArticulos;
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
        public RegistrarCompra(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioProveedor = new ServicioProveedor(_unidadDeTrabajo.RepositorioProveedor);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            _consultaProveedor = new ConsultaProveedor(_unidadDeTrabajo, this);
            _consultaProveedor.ShowDialog();
            _proveedor = _servicioProveedor.GetPorId(_idProveedor);
            string datosProveedor = _proveedor.GetRazonSocial();
            lblProveedor.Text = datosProveedor;
        }

        internal void setIdProveedor(int id)
        {
            this._idProveedor = id;
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            _consultaArticulo = new ConsultaArticulo(_unidadDeTrabajo);
            _consultaArticulo.ShowDialog();
        }
    }
}
