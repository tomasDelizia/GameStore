using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioArticulo : Servicio<Articulo>, IServicioArticulo
    {
        private IRepositorioArticulo _repositorioArticulo;

        public ServicioArticulo(IRepositorioArticulo repositorioArticulo) : base(repositorioArticulo)
        {
            _repositorioArticulo = repositorioArticulo;
        }

        public List<Articulo> ListarArticulos()
        {
            return _repositorioArticulo.GetTodos().ToList();
        }
    }
}
