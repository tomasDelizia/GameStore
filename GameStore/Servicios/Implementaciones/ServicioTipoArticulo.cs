using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;
using GameStore.RepositoriosBD;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioTipoArticulo : Servicio<TipoArticulo>, IServicioTipoArticulo
    {
        private IRepositorioTipoArticulo _repositorioTipoArticulo;

        public ServicioTipoArticulo(IRepositorioTipoArticulo repositorioTipoArticulo) : base(repositorioTipoArticulo)
        {
            _repositorioTipoArticulo = repositorioTipoArticulo;
        }

        public List<TipoArticulo> ListarTiposDeArticulo()
        {
            return _repositorioTipoArticulo.GetTodos().ToList();
        }
    }
}
