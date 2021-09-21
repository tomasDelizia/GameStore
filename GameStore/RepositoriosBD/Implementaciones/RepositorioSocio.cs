using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class RepositorioSocio : Repositorio<Socio>, IRepositorioSocio
    {
        public RepositorioSocio(ContextoGameStore contextoBd) : base(contextoBd)
        {
        }
    }
}
