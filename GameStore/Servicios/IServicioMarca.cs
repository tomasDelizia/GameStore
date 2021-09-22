using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;

namespace GameStore.Servicios
{
    public interface IServicioMarca : IServicio<Marca>
    {
        void ValidarMarca(Marca marca);
        Marca GetPorId(int id);
        List<Marca> ListarMarcas();
    }
}
