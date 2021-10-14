using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;

namespace GameStore.Servicios.Implementaciones
{
    public interface IServicioAlquiler : IServicio<Alquiler>
    {
        List<Alquiler> ListarAlquileres();

        void ValidarAlquiler(Alquiler nuevoAlquiler);
    }
}
