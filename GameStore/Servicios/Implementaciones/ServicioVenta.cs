using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;
using GameStore.RepositoriosBD;
using GameStore.RepositoriosBD.Implementaciones;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioVenta : Servicio<Venta>, IServicioVenta
    {
        private IRepositorioVenta _repositorioVenta;

        public ServicioVenta(IRepositorioVenta repositorioVenta) : base(repositorioVenta)
        {
            _repositorioVenta = repositorioVenta;
        }

        public List<Venta> ListarVentas()
        {
            return _repositorioVenta.GetTodos().ToList();
        }
    }
}
