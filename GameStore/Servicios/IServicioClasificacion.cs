using System.Collections.Generic;
using GameStore.Entidades;

namespace GameStore.Servicios
{
    public interface IServicioClasificacion : IServicio<Clasificacion>
    {
        List<Clasificacion> ListarClasificaciones();
    }
}
