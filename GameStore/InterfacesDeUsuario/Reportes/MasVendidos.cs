using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameStore.RepositoriosBD;
using GameStore.RepositoriosBD.Implementaciones;
using Microsoft.Reporting.WinForms;

namespace GameStore.InterfacesDeUsuario.Reportes
{
    public partial class MasVendidos : Form
    {
        private RepositorioReporte _repositorioReporte;
        private string fechaHoy;
        private string fechaMesPasado;

        public MasVendidos()
        {
            _repositorioReporte = new RepositorioReporte();
            fechaHoy = DateTime.Now.ToShortDateString();
            fechaMesPasado = DateTime.Now.AddDays(-31).ToShortDateString();
            InitializeComponent();
        }

        private void MasVendidos_Load(object sender, EventArgs e)
        {
            this.CargarReporte(fechaMesPasado, fechaHoy);
        }

        private void CargarReporte(string fechaDesde, string fechaHasta)
        {
            var datos = _repositorioReporte.GetVideojuegosPorCantidadVendida(fechaDesde, fechaHasta);
            var datos2 = _repositorioReporte.GetPerifericosPorCantidadVendida(fechaDesde, fechaHasta);
            var datos3 = _repositorioReporte.GetConsolasPorCantidadVendida(fechaDesde, fechaHasta);

            this.RwMasVendidos.LocalReport.DataSources.Clear();

            var dsVideoJuegos = new ReportDataSource("DTCantidadesJuegos", datos);
            var dsPerifericos = new ReportDataSource("DTCantidadesPerifericos", datos2);
            var dsConsolas = new ReportDataSource("DTCantidadesConsolas", datos3);

            this.RwMasVendidos.LocalReport.DataSources.Add(dsVideoJuegos);
            this.RwMasVendidos.LocalReport.DataSources.Add(dsPerifericos);
            this.RwMasVendidos.LocalReport.DataSources.Add(dsConsolas);

            var parametros = new List<ReportParameter>();
            var paramFechaDesde = new ReportParameter("ParamFechaDesde", fechaDesde);
            var paramFechaHasta = new ReportParameter("ParamFechaHasta", fechaHasta);
            parametros.Add(paramFechaDesde);
            parametros.Add(paramFechaHasta);
            this.RwMasVendidos.LocalReport.SetParameters(parametros);
            this.RwMasVendidos.RefreshReport();
        }

        private void btnFiltrarMasVen_Click(object sender, EventArgs e)
        {
            var fechaDesde = dtpFechaDesdeMasVen.Value;
            var fechaHasta = dtpFechaHastaMasVen.Value;
            try
            {
                if (fechaDesde > fechaHasta)
                    throw new ApplicationException("Ingrese un rango de fechas válido");
                RwMasVendidos.Clear();
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
