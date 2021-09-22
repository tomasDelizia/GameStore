using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios
{
    public interface IServicioDesarrollador : IServicio<Desarrollador>
    {
        void ValidarDesarrollador(Desarrollador desarrollador);
        Desarrollador GetPorId(int id);

        List<Desarrollador> ListarDesarrolladores();
    }
}
