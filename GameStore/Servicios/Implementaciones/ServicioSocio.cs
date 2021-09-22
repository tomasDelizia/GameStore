using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioSocio : Servicio<Socio>, IServicioSocio
    {
        private IRepositorioSocio _repositorioSocio;
        public ServicioSocio(IRepositorioSocio repositorioSocio) : base(repositorioSocio)
        {
            _repositorioSocio = repositorioSocio;
        }

        public List<Socio> ListarSocios()
        {
            return _repositorioSocio.GetTodos().ToList();
        }

        public void ValidarSocio(Socio socio)
        {
            socio.ValidarNombre();
            socio.ValidarApellido();
            socio.ValidarDocumento();
            socio.ValidarTelefono();
            socio.ValidarEmail();
            socio.ValidarCalle();
            socio.ValidarNumeroCalle();
        }
    }
}
