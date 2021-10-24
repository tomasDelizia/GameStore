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

    }
}
