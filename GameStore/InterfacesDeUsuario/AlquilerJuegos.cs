using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.Servicios;
using GameStore.Servicios.Implementaciones;

namespace GameStore.InterfacesDeUsuario
{
    public partial class AlquilerJuegos : Form
    {
        private IUnidadDeTrabajo _unidadDeTrabajo;
        private readonly IServicioArticulo _servicioArticulo;
        private readonly IServicioFormaPago _servicioFormaPago;
        private readonly IServicioTipoFactura _servicioTipoFactura;

        public AlquilerJuegos(IUnidadDeTrabajo unidadDeTrabajo)
        {
            InitializeComponent();
            //dgvArticulo.ColumnHeadersDefaultCellStyle.Font = new Font("Century Gothic", 10);
            //dgv.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            _unidadDeTrabajo = unidadDeTrabajo;
            _servicioArticulo = new ServicioArticulo(unidadDeTrabajo.RepositorioArticulo);
        }

        private void Alquiler_Load(object sender, EventArgs e)
        {
            CargarFormaPago(cboFormaPago);
            CargarTipoFactura(cboTipoFactura);
              
        }

        private void CargarTipoFactura(object cboTipoFactura)
        {
            throw new NotImplementedException();
        }

        private void CargarFormaPago(object cboFormaPago)
        {
            throw new NotImplementedException();
        }
    }
}
