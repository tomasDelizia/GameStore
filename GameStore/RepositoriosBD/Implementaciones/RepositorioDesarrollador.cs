using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class RepositorioDesarrollador : Repositorio<Desarrollador>, IRepositorioDesarrollador
    {
        public RepositorioDesarrollador(ContextoGameStore contextoBd) : base(contextoBd)
        {

        }
    }
}
