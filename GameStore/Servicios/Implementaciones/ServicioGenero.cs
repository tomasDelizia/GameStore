using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioGenero : Servicio<Genero>, IServicioGenero
    {
        private IRepositorioGenero _repositorioGenero;
        public ServicioGenero(IRepositorioGenero repositorioGenero) : base(repositorioGenero)
        {
            _repositorioGenero = repositorioGenero;
        }

        public void ValidarGenero(Genero genero)
        {
            genero.ValidarNombre();
        }

        public List<Genero> ListarGeneros()
        {
            return _repositorioGenero.GetTodos().ToList();
        }

        public Genero GetPorId(int id)
        {
            return _repositorioGenero.GetPorId(id);
        }
    }
}
