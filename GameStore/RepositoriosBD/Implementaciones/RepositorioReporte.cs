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
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }

        public DataTable GetConsolasPorCantidadVendida()
        {
            var sentenciaSql = "SELECT TOP 5 SUM(det.Cantidad) AS Cantidad, art.Nombre AS Nombre " +
                "FROM DetallesDeVenta det JOIN Articulos art ON(det.Codigo = art.Codigo) " +
                "WHERE art.IdTipoArticulo = 3 " +
                "GROUP BY art.Nombre " +
                "ORDER BY 1 DESC";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }

        public DataTable GetSociosPorCantidadComprada()
        {
            var sentenciaSql = "SELECT TOP 5 SUM (det.cantidad) Cantidad, soc.Nombre Nombre, soc.Apellido Apellido " +
                "FROM DetallesDeVenta det JOIN Ventas v ON(v.NroFactura = det.NroFactura) " +
                "JOIN Socios soc ON(v.IdSocio = soc.IdSocio) " +
                "GROUP BY soc.IdSocio, soc.Nombre, soc.Apellido " +
                "ORDER BY 1 DESC";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }

        public DataTable GetSociosPorCantidadAlquilada()
        {
            var sentenciaSql = "SELECT TOP 5 COUNT(soc.Nombre) Cantidad, soc.Nombre Nombre, soc.Apellido Apellido " +
                "FROM Alquileres a JOIN Socios soc ON(soc.IdSocio = a.IdSocio) " +
                "GROUP BY soc.IdSocio, soc.Nombre, soc.Apellido " +
                "ORDER BY 1 DESC";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }

        public DataTable GetComprasDelMes(string desde, string hasta)
        {
            string fechaDesde = desde.ToString();
            string fechaHasta = hasta.ToString();
            var sentenciaSql = "SELECT (detc.PrecioUnitario * detc.Cantidad) MontoCompras, c.FechaCompra Fecha " +
                "FROM Compras c JOIN DetallesDeCompra detc ON(detc.NroFactura = c.NroFactura) " +
                $"WHERE c.FechaCompra BETWEEN '{fechaDesde}' AND '{fechaHasta}' " +
                "ORDER BY 2";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }

        public DataTable GetVentasDelMes(string desde, string hasta)
        {
            string fechaDesde = desde.ToString();
            string fechaHasta = hasta.ToString();
            var sentenciaSql = "SELECT (detv.PrecioUnitario * detv.Cantidad) MontoVentas, v.FechaVenta Fecha " +
                "FROM Ventas v JOIN DetallesDeVenta detv ON (detv.NroFactura = v.NroFactura) " +
                $"WHERE v.FechaVenta BETWEEN '{fechaDesde}' AND '{fechaHasta}' " +
                "ORDER BY 2";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }
    }
}
