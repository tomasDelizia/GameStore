using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;

namespace GameStore.Servicios
{
    public interface IServicioCargo : IServicio<Cargo>
    {
        List<Cargo> ListarCargos();
        void ValidarCargo(Cargo nuevoCargo);
    }
}
