using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;
using GameStore.RepositoriosBD;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioPerfil : Servicio<Perfil>, IServicioPerfil
    {
        private IRepositorioPerfil _repositorioPerfil;

        public ServicioPerfil(IRepositorioPerfil repositorioPerfil) : base(repositorioPerfil)
        {
            _repositorioPerfil = repositorioPerfil;
        }

        public List<Perfil> ListarPerfiles()
        {
            return _repositorioPerfil.GetTodos().ToList();
        }
        public void ValidarPerfil(Perfil perfil)
        {
            perfil.ValidarNombre();
            perfil.ValidarDescripcion();
        }
    }
}
