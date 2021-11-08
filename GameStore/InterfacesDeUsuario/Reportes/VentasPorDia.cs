using GameStore.RepositoriosBD.Implementaciones;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameStore.InterfacesDeUsuario.Reportes
{
    public partial class VentasPorDia : Form
    {
        private RepositorioReporte _repositorioReporte;
        private string fechaHoy;
        private string fechaMesPasado;

        public VentasPorDia()
        {
            _repositorioReporte = new RepositorioReporte();
            fechaHoy = DateTime.Now.ToShortDateString();
            fechaMesPasado = DateTime.Now.AddDays(-31).ToShortDateString();
            InitializeComponent();
        }

        private void VentasPorDia_Load(object sender, EventArgs e)
        {
            CargarReporteVenta(fechaMesPasado, fechaHoy);
        }

        private void CargarReporteVenta(string fechaDesde, string fechaHasta)
        {
            var ventas = _repositorioReporte.GetVentasDelMes(fechaDesde, fechaHasta);
        }
    }
}
