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
        public Resumen()
        {
            _repositorioReporte = new RepositorioReporte();
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            string fechaHoy = DateTime.Now.ToShortDateString();
            string fechaMesPasado = DateTime.Now.AddDays(-30).ToShortDateString();
            CargarReporte(fechaMesPasado, fechaHoy);
        }

        private void btnVerResumen_Click(object sender, EventArgs e)
        {
            string fechaDesde = dtpFechaDesde.Value.ToShortDateString();
            string fechaHasta = dtpFechaHasta.Value.ToShortDateString();
            CargarReporte(fechaDesde, fechaHasta);
        }

        private void CargarReporte(string fechaDesde, string fechaHasta)
        {
            var reporteCompras = _repositorioReporte.GetComprasPorFecha(fechaDesde, fechaHasta);
            RwResumen.LocalReport.DataSources.Clear();
            var dsCompras = new ReportDataSource("DTCompras", reporteCompras);
            RwResumen.LocalReport.DataSources.Add(dsCompras);
            var parametros = new List<ReportParameter>();
            var paramFechaDesde = new ReportParameter("ParamFechaDesde", fechaDesde);
            var paramFechaHasta = new ReportParameter("ParamFechaHasta", fechaHasta);
            parametros.Add(paramFechaDesde);
            parametros.Add(paramFechaHasta);
            RwResumen.LocalReport.SetParameters(parametros);
            RwResumen.RefreshReport();
        }
    }
}
