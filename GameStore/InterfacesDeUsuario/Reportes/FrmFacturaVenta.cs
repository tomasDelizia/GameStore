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
    public partial class FrmFacturaVenta : Form
    {
        private int _nroFactura;
        private IRepositorioReporte _repositorioReporte;

        public FrmFacturaVenta(int nroFactura)
        {
            InitializeComponent();
            _nroFactura = nroFactura;
            _repositorioReporte = new RepositorioReporte();
        }

        private void FrmFacturaVenta_Load(object sender, EventArgs e)
        {
            CargarFactura();
        }

        private void CargarFactura()
        {
            var datosFactura = _repositorioReporte.GetVenta(_nroFactura);
            var totalFactura = _repositorioReporte.GetTotalVenta(_nroFactura);
            rwFacturaVenta.LocalReport.DataSources.Clear();

            var ds = new ReportDataSource("DSFacturaVenta", datosFactura);
            rwFacturaVenta.LocalReport.DataSources.Add(ds);

            var nroFactura = datosFactura.Rows[0]["NroFactura"].ToString();
            var fecha = datosFactura.Rows[0]["FechaVenta"].ToString();
            var nroSocio = datosFactura.Rows[0]["IdSocio"].ToString();
            var formaPago = datosFactura.Rows[0]["FormaPago"].ToString();
            var tipoFactura = datosFactura.Rows[0]["TipoFactura"].ToString();
            var socio = datosFactura.Rows[0]["Socio"].ToString();
            var domicilio = datosFactura.Rows[0]["Domicilio"].ToString();
            var barrio = datosFactura.Rows[0]["Barrio"].ToString();
            var email = datosFactura.Rows[0]["Email"].ToString();

            var paramNroFactura = new ReportParameter("ParamNroFactura", nroFactura);
            var paramFecha = new ReportParameter("ParamFecha", fecha);
            var paramNroSocio = new ReportParameter("ParamNroSocio", nroSocio);
            var paramFormaPago = new ReportParameter("ParamFormaPago", formaPago);
            var paramTipoFac = new ReportParameter("ParamTipoFac", tipoFactura);
            var paramSocio = new ReportParameter("ParamNombreYApellido", socio);
            var paramDomicilio = new ReportParameter("ParamDomicilio", domicilio);
            var paramBarrio = new ReportParameter("ParamBarrio", barrio);
            var paramEmail = new ReportParameter("ParamEmail", email);
            var paramTotal = new ReportParameter("ParamTotal", totalFactura);

            var parametros = new List<ReportParameter>();
            parametros.Add(paramNroFactura);
            parametros.Add(paramFecha);
            parametros.Add(paramNroSocio);
            parametros.Add(paramFormaPago);
            parametros.Add(paramTipoFac);
            parametros.Add(paramSocio);
            parametros.Add(paramDomicilio);
            parametros.Add(paramBarrio);
            parametros.Add(paramEmail);
            parametros.Add(paramTotal);

            rwFacturaVenta.LocalReport.SetParameters(parametros);

            rwFacturaVenta.RefreshReport();
        }
    }
}
