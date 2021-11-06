using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.RepositoriosBD
{
    public interface IRepositorioReporte
    {
        DataTable GetVideojuegosPorCantidadVendida();
        DataTable GetPerifericosPorCantidadVendida();
        DataTable GetConsolasPorCantidadVendida();
        DataTable GetSociosPorCantidadComprada();
        DataTable GetSociosPorCantidadAlquilada();
        DataTable GetVenta(int nroFactura);
        string GetTotalVenta(int nroFactura);
    }
}
