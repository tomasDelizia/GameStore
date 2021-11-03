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
            var estados = ListarEstadosVideojuego();
            EstadoVideojuego estadoRegistrado = null;
            foreach(var e in estados)
            {
                if (e.EsRegistrado())
                {
                    estadoRegistrado = e;
                    break;
                }
            }
            return estadoRegistrado;
        }
    }
}
