using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class RepositorioCargo : Repositorio<Cargo>, IRepositorioCargo
    {
        public RepositorioCargo(ContextoGameStore contextoBd) : base(contextoBd)
        {
        }
    }
}
