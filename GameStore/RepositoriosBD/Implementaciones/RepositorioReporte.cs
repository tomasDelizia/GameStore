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

        public DataTable GetVideojuegosPorCantidadVendida(string desde, string hasta)
        {
            string fechaDesde = desde.ToString();
            string fechaHasta = hasta.ToString();
            var sentenciaSql = "SELECT TOP 5 SUM(det.Cantidad) AS Cantidad, art.Nombre AS Nombre " +
                "FROM Ventas v JOIN DetallesDeVenta det ON(det.NroFactura = v.NroFactura) JOIN Articulos art ON(det.Codigo = art.Codigo)  " +
                $"WHERE art.IdTipoArticulo = 1 AND v.FechaVenta BETWEEN '{fechaDesde}' AND '{fechaHasta}' " +
                "GROUP BY art.Nombre " +
                "ORDER BY 1 DESC";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }

        public DataTable GetPerifericosPorCantidadVendida(string desde, string hasta)
        {
            string fechaDesde = desde.ToString();
            string fechaHasta = hasta.ToString();
            var sentenciaSql = "SELECT TOP 5 SUM(det.Cantidad) AS Cantidad, art.Nombre AS Nombre " +
                "FROM Ventas v JOIN DetallesDeVenta det ON(det.NroFactura = v.NroFactura) JOIN Articulos art ON(det.Codigo = art.Codigo) " +
                $"WHERE art.IdTipoArticulo = 2 AND v.FechaVenta BETWEEN '{fechaDesde}' AND '{fechaHasta}' " +
                "GROUP BY art.Nombre " +
                "ORDER BY 1 DESC";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }

        public DataTable GetConsolasPorCantidadVendida(string desde, string hasta)
        {
            string fechaDesde = desde.ToString();
            string fechaHasta = hasta.ToString();
            var sentenciaSql = "SELECT TOP 5 SUM(det.Cantidad) AS Cantidad, art.Nombre AS Nombre " +
                "FROM Ventas v JOIN DetallesDeVenta det ON(det.NroFactura = v.NroFactura) JOIN Articulos art ON(det.Codigo = art.Codigo) " +
                $"WHERE art.IdTipoArticulo = 3 AND v.FechaVenta BETWEEN '{fechaDesde}' AND '{fechaHasta}' " +
                "GROUP BY art.Nombre " +
                "ORDER BY 1 DESC";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }

        public DataTable GetSociosPorCantidadComprada(string desde, string hasta)
        {
            string fechaDesde = desde.ToString();
            string fechaHasta = hasta.ToString();
            var sentenciaSql = "SELECT TOP 5 SUM (det.cantidad) Cantidad, soc.Nombre Nombre, soc.Apellido Apellido, SUM(det.PrecioUnitario) Monto " +
                "FROM DetallesDeVenta det JOIN Ventas v ON(v.NroFactura = det.NroFactura) JOIN Socios soc ON(v.IdSocio = soc.IdSocio) " +
                $"WHERE v.FechaVenta BETWEEN '{fechaDesde}' AND '{fechaHasta}' " +
                "GROUP BY soc.IdSocio, soc.Nombre, soc.Apellido " +
                "ORDER BY 1 DESC";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }

        public DataTable GetSociosPorCantidadAlquilada(string desde, string hasta)
        {
            string fechaDesde = desde.ToString();
            string fechaHasta = hasta.ToString();
            var sentenciaSql = "SELECT TOP 5 COUNT(soc.Nombre) Cantidad, soc.Nombre Nombre, soc.Apellido Apellido, SUM(Datediff(DAY, FechaInicio, FechaFin) * det.MontoAlquilerPorDia) Monto " +
                "FROM Alquileres a JOIN Socios soc ON(soc.IdSocio = a.IdSocio) JOIN DetallesDeAlquiler det ON(a.NroAlquiler = det.NroAlquiler) " +
                $"WHERE a.FechaInicio BETWEEN '{fechaDesde}' AND '{fechaHasta}' " +
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

        public DataTable GetVenta(int nroFactura)
        {
            var sentenciaSql = $@"SELECT v.NroFactura, CONVERT(char(10), v.FechaVenta, 103) FechaVenta,
            tf.Nombre TipoFactura, fp.Nombre FormaPago,
            s.IdSocio, s.Nombre + ' ' + s.Apellido Socio, s.Email, s.CalleNombre + ' ' + CONVERT(VARCHAR, s.CalleNumero) Domicilio, b.Nombre Barrio,
            a.Codigo UPC, a.Nombre Articulo, dv.Cantidad, CONCAT('$ ', dv.PrecioUnitario) PrecioUnitario, CONCAT('$ ', dv.Cantidad * dv.PrecioUnitario) Subtotal
            
            FROM Ventas v JOIN TiposDeFactura tf ON v.IdTipoFactura = tf.IdTipoFactura
            JOIN FormasDePago fp ON v.IdFormaPago = fp.IdFormaPago
            JOIN Socios s ON v.IdSocio = s.IdSocio
            JOIN Barrios b ON s.IdBarrio = b.IdBarrio
            JOIN DetallesDeVenta dv ON dv.NroFactura = v.NroFactura
            JOIN Articulos a ON a.Codigo = dv.Codigo
            WHERE v.NroFactura = {nroFactura}";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }

        public string GetTotalVenta(int nroFactura)
        {
            var sentenciaSql = $@"SELECT CONCAT('$ ', SUM(dv.Cantidad * dv.PrecioUnitario))
            FROM Ventas v JOIN DetallesDeVenta dv ON v.NroFactura = dv.NroFactura
            WHERE v.NroFactura = {nroFactura}
            GROUP BY v.NroFactura";
            
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla.Rows[0][0].ToString();
        }

        public DataTable GetVentas(string desde, string hasta)
        {
            string fechaDesde = desde.ToString();
            string fechaHasta = hasta.ToString();
            var sentenciaSql = "SELECT  det.Cantidad AS Cantidad, art.Nombre AS Nombre, (det.PrecioUnitario * det.Cantidad) AS Subtotal, CONVERT(char(10), v.FechaVenta, 103) AS Fecha, art.Codigo AS UPC, CONCAT('$ ', det.PrecioUnitario) AS PrecioArticulo  " +
                "FROM Ventas v JOIN DetallesDeVenta det ON(det.NroFactura = v.NroFactura) JOIN Articulos art ON(det.Codigo = art.Codigo) " +
                $"WHERE v.FechaVenta BETWEEN '{fechaDesde}' AND '{fechaHasta}' ";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }

        public DataTable GetAlquiler(int nroAlquiler)
        {
            var sentenciaSql = "SELECT art.Codigo UPC, art.Nombre Articulo, deta.MontoAlquilerPorDia PrecioDiario, deta.MontoDevolucionTardiaPorDia PrecioDiaExtra, deta.MontoAlquilerPorDia * DATEDIFF(day, a.FechaInicio, a.FechaFin ) Subtotal " + /*deta.MontoDevolucionTardiaPorDia * DATEDIFF(DAY, a.FechaFin, a.FechaFinReal) Subtotal " +*/
                                "FROM Alquileres a JOIN DetallesDeAlquiler deta ON(a.NroAlquiler = deta.NroAlquiler) join Articulos art on art.Codigo = deta.Codigo " +
                                $"WHERE a.NroAlquiler = {nroAlquiler} " +
                                "GROUP BY  a.NroAlquiler, a.FechaFin, a.FechaInicio, a.FechaFinReal, deta.MontoDevolucionTardiaPorDia, DETA.MontoAlquilerPorDia, art.nombre, art.codigo ";
            var tabla = DBHelper.GetDBHelper().ConsultaSQL(sentenciaSql);
            return tabla;
        }
    }
}
