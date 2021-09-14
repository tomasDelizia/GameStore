using GameStore.Entidades;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class RepositorioClasificacion : Repositorio<Clasificacion>, IRepositorioClasificacion
    {
        public RepositorioClasificacion(ContextoGameStore contextoBd) : base(contextoBd)
        {

        }
    }
}
