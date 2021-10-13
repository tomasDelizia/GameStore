using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class RepositorioTipoFactura : Repositorio<TipoFactura>, IRepositorioTipoFactura
    {
        public RepositorioTipoFactura(ContextoGameStore contextoBd) : base(contextoBd)
        { 
        }
    }
}
