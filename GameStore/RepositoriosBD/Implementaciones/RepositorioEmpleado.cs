using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class RepositorioEmpleado : Repositorio<Empleado> , IRepositorioEmpleado
    {
        public RepositorioEmpleado(ContextoGameStore contextoBd) : base(contextoBd)
        {
        }
    }
}
