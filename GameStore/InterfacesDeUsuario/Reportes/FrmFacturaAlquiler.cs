using GameStore.Entidades;
using GameStore.RepositoriosBD;
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
    public partial class FrmFacturaAlquiler : Form
    {
        private int _nroFactura;
        private IRepositorioReporte _repositorioReporte;
        private Alquiler _alquiler;
        public FrmFacturaAlquiler(Alquiler alquiler)
        {
            InitializeComponent();
            _nroFactura = alquiler.NroAlquiler;
            _repositorioReporte = new RepositorioReporte();
            _alquiler = alquiler;
        }

        private void FrmFacturaAlquiler_Load(object sender, EventArgs e)
        {
            CargarFactura();
        }

        private void CargarFactura()
        {
            var datosFactura = _repositorioReporte.GetAlquiler(_alquiler.NroAlquiler);
            rwFacturaAlquiler.LocalReport.DataSources.Clear();

            var ds = new ReportDataSource("DTFacturaAlquiler", datosFactura);
            rwFacturaAlquiler.LocalReport.DataSources.Add(ds);

            var totalFactura = _alquiler.CalcularTotal().ToString();
            var nroFactura = _alquiler.NroAlquiler.ToString();
            var fechaInicio = _alquiler.FechaInicio.ToShortDateString();
            var fechaFin = _alquiler.FechaFin.ToShortDateString();
            var fechaFinReal = _alquiler.FechaFinReal.Value.ToShortDateString();
            var nroSocio = _alquiler.IdSocio.ToString();
            var formaPago = _alquiler.FormaPago.Nombre;
            var tipoFactura = _alquiler.TipoFactura.Nombre;
            var socio = _alquiler.Socio;
            var nombreYApellido = socio.Nombre + " " + socio.Apellido;
            var domicilio = socio.CalleNombre + " " + socio.CalleNumero.ToString();
            var barrio = socio.Barrio.Nombre;
            var email = socio.Email;
            var descuento = _alquiler.MontoSenia.ToString();
            var montoAdicional = _alquiler.CalcularAdicional().ToString();
            var importeFinal = _alquiler.CalcularImporteFinal().ToString();

            var paramNroFactura = new ReportParameter("ParamNroFactura", nroFactura);
            var paramFechaInicio = new ReportParameter("ParamFechaInicio", fechaInicio);
            var paramFechaFin = new ReportParameter("ParamFechaFin", fechaFin);
            var paramFechaFinReal = new ReportParameter("ParamFechaFinReal", fechaFinReal);
            var paramNroSocio = new ReportParameter("ParamNroSocio", nroSocio);
            var paramFormaPago = new ReportParameter("ParamFormaPago", formaPago);
            var paramTipoFac = new ReportParameter("ParamTipoFac", tipoFactura);
            var paramSocio = new ReportParameter("ParamNombreYApellido", nombreYApellido);
            var paramDomicilio = new ReportParameter("ParamDomicilio", domicilio);
            var paramBarrio = new ReportParameter("ParamBarrio", barrio);
            var paramEmail = new ReportParameter("ParamEmail", email);
            var paramTotal = new ReportParameter("ParamTotal", totalFactura);
            var paramDescuentoSenia = new ReportParameter("ParamDescuentoSenia", descuento);
            var paramDevolucionTardia = new ReportParameter("ParamDevolucionTardia", montoAdicional);
            var paramImporteFinal = new ReportParameter("ParamImporteFinal", importeFinal);

            var parametros = new List<ReportParameter>();
            parametros.Add(paramNroFactura);
            parametros.Add(paramFechaInicio);
            parametros.Add(paramFechaFin);
            parametros.Add(paramFechaFinReal);
            parametros.Add(paramNroSocio);
            parametros.Add(paramFormaPago);
            parametros.Add(paramTipoFac);
            parametros.Add(paramSocio);
            parametros.Add(paramDomicilio);
            parametros.Add(paramBarrio);
            parametros.Add(paramEmail);
            parametros.Add(paramTotal);
            parametros.Add(paramDescuentoSenia);
            parametros.Add(paramDevolucionTardia);
            parametros.Add(paramImporteFinal);

            rwFacturaAlquiler.LocalReport.SetParameters(parametros);

            rwFacturaAlquiler.RefreshReport();
        }
    }
}
