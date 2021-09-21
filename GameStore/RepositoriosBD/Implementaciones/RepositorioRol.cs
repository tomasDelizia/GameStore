using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class RepositorioRol : Repositorio<Rol>, IRepositorioRol
    {
        public RepositorioRol(ContextoGameStore contextoBd) : base(contextoBd)
        {
        }
    }
}
