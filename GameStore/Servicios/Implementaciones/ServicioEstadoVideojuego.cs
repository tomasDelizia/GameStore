using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;
using GameStore.RepositoriosBD;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioEstadoVideojuego : Servicio<EstadoVideojuego>, IServicioEstadoVideojuego
    {
        private IRepositorioEstadoVideojuego _repositorioEstadoVideojuego;

        public ServicioEstadoVideojuego(IRepositorioEstadoVideojuego repositorioEstadoVideojuego) : base(repositorioEstadoVideojuego)
        {
            _repositorioEstadoVideojuego = repositorioEstadoVideojuego;
        }

        public List<EstadoVideojuego> ListarEstadosVideojuego()
        {
            return _repositorioEstadoVideojuego.GetTodos().ToList();
        }

        public EstadoVideojuego GetEstadoRegistrado()
        {
            var estadoRegistrado = _repositorioEstadoVideojuego.Encontrar(estado => estado.Nombre == "Registrado").ToList();
            return estadoRegistrado[0];
        }

        public EstadoVideojuego GetEstadoEliminado()
        {
            var estadoEliminado = _repositorioEstadoVideojuego.Encontrar(estado => estado.Nombre == "Eliminado").ToList();
            return estadoEliminado[0];
        }
    }
}
