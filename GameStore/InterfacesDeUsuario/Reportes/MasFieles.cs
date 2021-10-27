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
        public MasFieles()
        {
            _repositorioReporte = new RepositorioReporte();
            InitializeComponent();
        }

        private void MasFieles_Load(object sender, EventArgs e)
        {
            CargarReporte();
        }

        private void CargarReporte()
        {
            var reporteVentas = _repositorioReporte.GetSociosPorCantidadComprada();
            var reporteAlquileres = _repositorioReporte.GetSociosPorCantidadAlquilada();
            RwMasFieles.LocalReport.DataSources.Clear();
            var dsVentas = new ReportDataSource("DTCantidadesCompradas", reporteVentas);
            var dsAlquileres = new ReportDataSource("DTCantidadesAlquiladas", reporteAlquileres);
            RwMasFieles.LocalReport.DataSources.Add(dsVentas);
            RwMasFieles.LocalReport.DataSources.Add(dsAlquileres);
            var parametros = new List<ReportParameter>();
            var fechaHoy = DateTime.Now.ToString("dd/MM/yyyy");
            var paramFechaHoy = new ReportParameter("ParamFecha", fechaHoy);
            parametros.Add(paramFechaHoy);
            RwMasFieles.LocalReport.SetParameters(parametros);
            RwMasFieles.RefreshReport();
        }
    }
}
