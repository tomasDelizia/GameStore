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
    public class ServicioAlquiler : Servicio<Alquiler>, IServicioAlquiler
    {
        private IRepositorioAlquiler _repositorioAlquiler;

        public ServicioAlquiler(IRepositorioAlquiler repositorioAlquiler) : base(repositorioAlquiler)
        {
            _repositorioAlquiler = repositorioAlquiler;
        }

        public List<Alquiler> ListarAlquileres()
        {
            return _repositorioAlquiler.GetTodos().ToList();
        }

        public List<Alquiler> ListarAlquileresNoDevueltos()
        {
            return _repositorioAlquiler.Encontrar(a => a.FechaFinReal == null).ToList();
        }

        public void ValidarAlquiler(Alquiler nuevoAlquiler)
        {
            nuevoAlquiler.ValidarSocio();
            nuevoAlquiler.ValidarFormaPago();
            nuevoAlquiler.ValidarTipoFactura();
            nuevoAlquiler.ValidarDetallesDeAlquiler();
        }
    }
}
