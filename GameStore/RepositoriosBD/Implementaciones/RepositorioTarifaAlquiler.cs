using GameStore.Entidades;
using GameStore.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class RepositorioTarifaAlquiler : Repositorio<TarifaAlquiler>, IRepositorioTarifaAlquiler
    {
        public RepositorioTarifaAlquiler(ContextoGameStore contextoBd) : base(contextoBd)
        {
        }
    }
}
