using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioCompra : Servicio<Compra>, IServicioCompra
    {
        public ServicioCompra(IRepositorioCompra repositorio) : base(repositorio)
        {

        }
        public void ValidarCompra(Compra nuevaCompra)
        {
            nuevaCompra.ValidarProveedor();
            nuevaCompra.ValidarTipoFactura();
            nuevaCompra.ValidarDetallesDeCompra();

        }
    }
}
