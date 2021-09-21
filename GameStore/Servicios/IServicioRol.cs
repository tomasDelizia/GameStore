using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios
{
    interface IServicioRol : IServicio<Rol>
    {
        List<Rol> ListarRoles();
    }
}
