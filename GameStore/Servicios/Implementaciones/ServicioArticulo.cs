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

        public void DarBajaArticulo(Articulo articulo, EstadoVideojuego estadoEliminado)
        {
            articulo.EstadoVideojuego = estadoEliminado;
            _repositorioArticulo.Actualizar(articulo);
        }

        public List<Articulo> ListarArticulos()
        {
            return _repositorioArticulo.GetTodos().ToList();
        }

        public List<Articulo> ListarArticulosActivos()
        {
            return _repositorioArticulo.Encontrar(art => art.EstadoVideojuego.Nombre == "Registrado").ToList();
        }

        public void ValidarArticulo(Articulo articulo)
        {
            articulo.ValidarCodigo();
            articulo.ValidarNombre();
            articulo.ValidarPrecio();
            articulo.ValidarTipoArticulo();
            articulo.ValidarFechaSalida();
            articulo.ValidarPlataforma();
        }
    }
}
