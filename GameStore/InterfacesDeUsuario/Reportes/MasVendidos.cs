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

        private IRepositorioReporte repositorioReporte;
        public MasVendidos()
        {
            repositorioReporte = new RepositorioReporte();
            InitializeComponent();
        }

        private void MasVendidos_Load(object sender, EventArgs e)
        {
            this.CargarReporte();
        }

        private void CargarReporte()
        {
            var datos = repositorioReporte.GetVideojuegosPorCantidadVendida();
            var datos2 = repositorioReporte.GetPerifericosPorCantidadVendida();
            var datos3 = repositorioReporte.GetConsolasPorCantidadVendida();

            this.RwMasVendidos.LocalReport.DataSources.Clear();

            var dsVideoJuegos = new ReportDataSource("DTCantidadesJuegos", datos);
            var dsPerifericos = new ReportDataSource("DTCantidadesPerifericos", datos2);
            var dsConsolas = new ReportDataSource("DTCantidadesConsolas", datos3);

            this.RwMasVendidos.LocalReport.DataSources.Add(dsVideoJuegos);
            this.RwMasVendidos.LocalReport.DataSources.Add(dsPerifericos);
            this.RwMasVendidos.LocalReport.DataSources.Add(dsConsolas);

            var parametros = new List<ReportParameter>();
            var fechaHoy = DateTime.Now.ToString("dd/MM/yyyy");
            var paramFechaHoy = new ReportParameter("ParamFechaHoy", fechaHoy);
            parametros.Add(paramFechaHoy);
            this.RwMasVendidos.LocalReport.SetParameters(parametros);

            this.RwMasVendidos.RefreshReport();
        }
    }
}
