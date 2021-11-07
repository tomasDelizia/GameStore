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
            CargarReporte(fechaMesPasado, fechaHoy);
        }

        private void CargarReporte(string fechaDesde, string fechaHasta)
        {
            var compras = _repositorioReporte.GetComprasDelMes(fechaDesde, fechaHasta);
            var ventas = _repositorioReporte.GetVentasDelMes(fechaDesde, fechaHasta);
            RwResumen.LocalReport.DataSources.Clear();
            var dsCompras = new ReportDataSource("DTCompras", compras);
            var dsVentas = new ReportDataSource("DTVentas", ventas);
            RwResumen.LocalReport.DataSources.Add(dsCompras);
            RwResumen.LocalReport.DataSources.Add(dsVentas);
            var parametros = new List<ReportParameter>();
            var paramFechaDesde = new ReportParameter("ParamFechaDesde", fechaDesde);
            var paramFechaHasta = new ReportParameter("ParamFechaHasta", fechaHasta);
            parametros.Add(paramFechaDesde);
            parametros.Add(paramFechaHasta);
            RwResumen.LocalReport.SetParameters(parametros);
            RwResumen.RefreshReport();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            var fechaDesde = dtpFechaDesde.Value;
            var fechaHasta = dtpFechaHasta.Value;
            try
            {
                if (fechaDesde > fechaHasta)
                    throw new ApplicationException("Ingrese un rango de fechas válido");
                RwResumen.Clear();
                CargarReporte(fechaDesde.ToShortDateString(), fechaHasta.ToShortDateString());
            }
            catch (ApplicationException aex)
            {
                MessageBox.Show(aex.Message, "Error", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK);
            }

        }
    }
}
