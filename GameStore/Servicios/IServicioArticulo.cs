using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios
{
    public interface IServicioArticulo : IServicio<Articulo>
    {
        void ValidarArticulo(Articulo articulo);

        List<Articulo> ListarArticulos();
    }
}
