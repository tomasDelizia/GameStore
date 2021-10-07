using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioDetalleVenta : Servicio<DetalleVenta>
    {
        public ServicioDetalleVenta(IRepositorioDetalleVenta repositorio) : base(repositorio)
        {
        }
    }
}
