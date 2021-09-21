using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioBarrio : Servicio<Barrio>, IServicioBarrio
    {
        private IRepositorioBarrio _repositorioBarrio;
        public ServicioBarrio(IRepositorioBarrio repositorioBarrio) : base(repositorioBarrio)
        {
            _repositorioBarrio = repositorioBarrio;
        }
        public List<Barrio> ListarBarrios()
        {
            return _repositorioBarrio.GetTodos().ToList();
        }
    }
}
