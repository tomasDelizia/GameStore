using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioRol : Servicio<Rol>, IServicioRol
    {
        private IRepositorioRol _repositorioRol;
        public ServicioRol(IRepositorioRol repositorioRol) : base(repositorioRol)
        {
            _repositorioRol = repositorioRol;
        }

        public List<Rol> ListarRoles()
        {
            return _repositorioRol.GetTodos().ToList();
        }
    }
}
