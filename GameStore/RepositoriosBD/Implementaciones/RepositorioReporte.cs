using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class RepositorioReporte : IRepositorioReporte
    {

        public DataTable GetVideojuegosPorCantidadVendida()
        {
            var sentenciaSql = "SELECT TOP 5 SUM(det.Cantidad) AS Cantidad, art.Nombre AS Nombre " +
                "FROM DetallesDeVenta det JOIN Articulos art ON(det.Codigo = art.Codigo) " +
                "WHERE art.IdTipoArticulo = 1 " +
                "GROUP BY art.Nombre " +
                "ORDER BY 1 DESC";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }

        public DataTable GetPerifericosPorCantidadVendida()
        {
            var sentenciaSql = "SELECT TOP 5 SUM(det.Cantidad) AS Cantidad, art.Nombre AS Nombre " +
                "FROM DetallesDeVenta det JOIN Articulos art ON(det.Codigo = art.Codigo) " +
                "WHERE art.IdTipoArticulo = 2 " +
                "GROUP BY art.Nombre " +
                "ORDER BY 1 DESC";
            var tabla2 = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla2;
        }

        public DataTable GetConsolasPorCantidadVendida()
        {
            var sentenciaSql = "SELECT TOP 5 SUM(det.Cantidad) AS Cantidad, art.Nombre AS Nombre " +
                "FROM DetallesDeVenta det JOIN Articulos art ON(det.Codigo = art.Codigo) " +
                "WHERE art.IdTipoArticulo = 3 " +
                "GROUP BY art.Nombre " +
                "ORDER BY 1 DESC";
            var tabla3 = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla3;
        }

        public DataTable GetSociosPorCantidadComprada()
        {
            var sentenciaSql = "SELECT TOP 5 SUM (det.cantidad) Cantidad, soc.Nombre Nombre, soc.Apellido Apellido, SUM(det.PrecioUnitario) Monto " +
                "FROM DetallesDeVenta det JOIN Ventas v ON(v.NroFactura = det.NroFactura) " +
                "JOIN Socios soc ON(v.IdSocio = soc.IdSocio) " +
                "GROUP BY soc.IdSocio, soc.Nombre, soc.Apellido " +
                "ORDER BY 1 DESC";
            var tabla4 = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla4;
        }

        public DataTable GetSociosPorCantidadAlquilada()
        {
            var sentenciaSql = "SELECT TOP 5 COUNT(soc.Nombre) Cantidad, soc.Nombre Nombre, soc.Apellido Apellido, SUM(Datediff(DAY, FechaInicio, FechaFin) * det.MontoAlquilerPorDia) Monto " +
                "FROM Alquileres a JOIN Socios soc ON(soc.IdSocio = a.IdSocio) JOIN DetallesDeAlquiler det ON(a.NroAlquiler = det.NroAlquiler) " +
                "GROUP BY soc.IdSocio, soc.Nombre, soc.Apellido " +
                "ORDER BY 1 DESC";
            var tabla5 = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla5;
        }

        public DataTable GetComprasPorFecha(string desde, string hasta)
        {
            string fechaDesde = desde.ToString();
            string fechaHasta = hasta.ToString();
            var sentenciaSql = "SELECT detc.PrecioUnitario MontoCompras, c.FechaCompra Fecha, detv.PrecioUnitario MontoVentas " +
                "FROM Compras c JOIN DetallesDeCompra detc ON(detc.NroFactura = c.NroFactura) JOIN " +
                "Ventas v ON(v.FechaVenta = c.FechaCompra) JOIN DetallesDeVenta detv ON(v.NroFactura = detv.NroFactura) " +
                $"WHERE c.FechaCompra BETWEEN '{fechaDesde}' AND '{fechaHasta}' " +
                "ORDER BY 2; ";
            var tabla6 = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla6;
        }
    }
}
