using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class RepositorioEstadoVideojuego : Repositorio<EstadoVideojuego>, IRepositorioEstadoVideojuego
    {
        public RepositorioEstadoVideojuego(ContextoGameStore contextoBd) : base(contextoBd)
        {
        }
    }
}
