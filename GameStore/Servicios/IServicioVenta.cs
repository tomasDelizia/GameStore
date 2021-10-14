using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;

namespace GameStore.Servicios
{
    public interface IServicioVenta : IServicio<Venta>
    {
        List<Venta> ListarVentas();

        void ValidarVenta(Venta nuevaVenta);
    }
}
