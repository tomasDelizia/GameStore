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
        DataTable GetVideojuegosPorCantidadVendida(string desde, string hasta);
        DataTable GetPerifericosPorCantidadVendida(string desde, string hasta);
        DataTable GetConsolasPorCantidadVendida(string desde, string hasta);
        DataTable GetSociosPorCantidadComprada(string desde, string hasta);
        DataTable GetSociosPorCantidadAlquilada(string desde, string hasta);
        DataTable GetVenta(int nroFactura);
        string GetTotalVenta(int nroFactura);
    }
}
