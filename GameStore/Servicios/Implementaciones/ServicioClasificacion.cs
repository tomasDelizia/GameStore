using System.Collections.Generic;
using System.Linq;
using GameStore.Entidades;
using GameStore.RepositoriosBD;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioClasificacion : Servicio<Clasificacion>, IServicioClasificacion
    {
        private IRepositorioClasificacion _repositorioClasificacion;

        public ServicioClasificacion(IRepositorioClasificacion repositorioClasificacion) : base(repositorioClasificacion)
        {
            _repositorioClasificacion = repositorioClasificacion;
        }
        public void ValidarClasificacion(Clasificacion clasificacion)
        {
            clasificacion.ValidarNombre();
            
        }

        public List<Clasificacion> ListarClasificaciones()
        {
            return _repositorioClasificacion.GetTodos().ToList();
        }
    }
}
