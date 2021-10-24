using GameStore.Entidades;
using GameStore.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.RepositoriosBD
{
    public interface IServicioCompra : IServicio<Compra>
    {
        void ValidarCompra(Compra nuevaCompra);
        List<Compra> ListarCompras();
    }
}
