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
        private IRepositorioCompra _repositorioCompra;
        public ServicioCompra(IRepositorioCompra repositorio) : base(repositorio)
        {
            _repositorioCompra = repositorio;
        }
        public void ValidarCompra(Compra nuevaCompra)
        {
            nuevaCompra.ValidarProveedor();
            nuevaCompra.ValidarTipoFactura();
            nuevaCompra.ValidarDetallesDeCompra();

        }
        public List<Compra> ListarCompras()
        {
            return _repositorioCompra.GetTodos().ToList();
        }
    }
}
