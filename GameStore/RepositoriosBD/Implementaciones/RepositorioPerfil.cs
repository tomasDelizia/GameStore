using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class RepositorioPerfil : Repositorio<Perfil>, IRepositorioPerfil
    {
        public RepositorioPerfil(ContextoGameStore contextoBd) : base(contextoBd)
        {
        }
    }
}
