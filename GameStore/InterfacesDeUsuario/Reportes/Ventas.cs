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
    public partial class Ventas : Form
    {
        private RepositorioReporte _repositorioReporte;
        private string fechaHoy;
        private string fechaMesPasado;

        public Ventas()
        {
            _repositorioReporte = new RepositorioReporte();
            fechaHoy = DateTime.Now.ToShortDateString();
            fechaMesPasado = DateTime.Now.AddDays(-10).ToShortDateString();
            InitializeComponent();
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            CargarVentas(fechaMesPasado, fechaHoy);
        }

        private void CargarVentas(string fechaDesde, string fechaHasta)
        {
            var ventas = _repositorioReporte.GetVentas(fechaDesde, fechaHasta);
            RwVentas.LocalReport.DataSources.Clear();
            var dsVentas = new ReportDataSource("DTVentasPorPeriodo", ventas);
            RwVentas.LocalReport.DataSources.Add(dsVentas);
            var parametros = new List<ReportParameter>();
            var paramFechaDesde = new ReportParameter("ParamFechaDesde", fechaDesde);
            var paramFechaHasta = new ReportParameter("ParamFechaHasta", fechaHasta);
            parametros.Add(paramFechaDesde);
            parametros.Add(paramFechaHasta);
            RwVentas.LocalReport.SetParameters(parametros);
            RwVentas.RefreshReport();
        }

        private void btnFiltrarVen_Click(object sender, EventArgs e)
        {
            var fechaDesde = dtpFechaDesdeVen.Value;
            var fechaHasta = dtpFechaHastaVen.Value;
            try
            {
                if (fechaDesde > fechaHasta)
                    throw new ApplicationException("Ingrese un rango de fechas válido");
                RwVentas.Clear();
                CargarVentas(fechaDesde.ToShortDateString(), fechaHasta.ToShortDateString());
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
