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
    public partial class Resumen : Form
    {
        private RepositorioReporte _repositorioReporte;
        private string fechaHoy;
        private string fechaMesPasado;
        public Resumen()
        {
            _repositorioReporte = new RepositorioReporte();
            fechaHoy = DateTime.Now.ToShortDateString();
            fechaMesPasado = DateTime.Now.AddDays(-31).ToShortDateString();
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void CargarReporte()
        {
            var compras = _repositorioReporte.GetComprasDelMes(fechaMesPasado, fechaHoy);
            var ventas = _repositorioReporte.GetVentasDelMes(fechaMesPasado, fechaHoy);
            RwResumen.LocalReport.DataSources.Clear();
            var dsCompras = new ReportDataSource("DTCompras", compras);
            var dsVentas = new ReportDataSource("DTVentas", ventas);
            RwResumen.LocalReport.DataSources.Add(dsCompras);
            RwResumen.LocalReport.DataSources.Add(dsVentas);
            var parametros = new List<ReportParameter>();
            var paramFechaDesde = new ReportParameter("ParamFechaDesde", fechaHoy);
            var paramFechaHasta = new ReportParameter("ParamFechaHasta", fechaMesPasado);
            parametros.Add(paramFechaDesde);
            parametros.Add(paramFechaHasta);
            RwResumen.LocalReport.SetParameters(parametros);
            RwResumen.RefreshReport();
        }
    }
}
