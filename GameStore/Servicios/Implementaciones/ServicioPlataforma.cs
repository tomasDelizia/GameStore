using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioPlataforma : Servicio<Plataforma>, IServicioPlataforma
    {
        private IRepositorioPlataforma _repositorioPlataforma;

        public ServicioPlataforma(IRepositorioPlataforma repositorioPlataforma) : base(repositorioPlataforma)
        {
            _repositorioPlataforma = repositorioPlataforma;
        }

        public List<Plataforma> ListarPlataformas()
        {
            return _repositorioPlataforma.GetTodos().ToList();
        }
        public void ValidarPlataforma(Plataforma plataforma)
        {
            plataforma.ValidarNombre();
        }
    }
}
