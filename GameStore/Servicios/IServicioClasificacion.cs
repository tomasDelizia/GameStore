using System.Collections.Generic;
using GameStore.Entidades;

namespace GameStore.Servicios
{
    public interface IServicioClasificacion : IServicio<Clasificacion>
    {
        void ValidarClasificacion(Clasificacion clasificacion);
        List<Clasificacion> ListarClasificaciones();
        
    }
}
