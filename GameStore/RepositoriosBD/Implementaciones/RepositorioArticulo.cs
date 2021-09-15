using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class RepositorioArticulo : Repositorio<Articulo>, IRepositorioArticulo //repositorio articulo hereda de repositorio los comportamientos e implementa la interfaz
    {
        public RepositorioArticulo(ContextoGameStore contextoBd) : base(contextoBd)
        {

        }
    }
}
