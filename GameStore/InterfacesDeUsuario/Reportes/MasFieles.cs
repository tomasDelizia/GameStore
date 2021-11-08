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
    public partial class MasFieles : Form
    {
        private RepositorioReporte _repositorioReporte;
        private string fechaHoy;
        private string fechaMesPasado;

        public MasFieles()
        {
            _repositorioReporte = new RepositorioReporte();
            fechaHoy = DateTime.Now.ToShortDateString();
            fechaMesPasado = DateTime.Now.AddDays(-31).ToShortDateString();
            InitializeComponent();
        }

        private void MasFieles_Load(object sender, EventArgs e)
        {
            CargarReporte(fechaMesPasado, fechaHoy);
        }

        private void CargarReporte(string fechaDesde, string fechaHasta)
        {
            var reporteVentas = _repositorioReporte.GetSociosPorCantidadComprada(fechaDesde, fechaHasta);
            var reporteAlquileres = _repositorioReporte.GetSociosPorCantidadAlquilada(fechaDesde, fechaHasta);
            RwMasFieles.LocalReport.DataSources.Clear();
            var dsVentas = new ReportDataSource("DTCantidadesCompradas", reporteVentas);
            var dsAlquileres = new ReportDataSource("DTCantidadesAlquiladas", reporteAlquileres);
            RwMasFieles.LocalReport.DataSources.Add(dsVentas);
            RwMasFieles.LocalReport.DataSources.Add(dsAlquileres);
            var parametros = new List<ReportParameter>();
            var paramFechaDesde = new ReportParameter("ParamFechaDesde", fechaDesde);
            var paramFechaHasta = new ReportParameter("ParamFechaHasta", fechaHasta);
            parametros.Add(paramFechaDesde);
            parametros.Add(paramFechaHasta);
            RwMasFieles.LocalReport.SetParameters(parametros);
            RwMasFieles.RefreshReport();
        }

        private void btnFiltrarMasFie_Click(object sender, EventArgs e)
        {
            var fechaDesde = dtpFechaDesdeMasFie.Value;
            var fechaHasta = dtpFechaHastaMasFie.Value;
            try
            {
                if (fechaDesde > fechaHasta)
                    throw new ApplicationException("Ingrese un rango de fechas válido");
                RwMasFieles.Clear();
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
