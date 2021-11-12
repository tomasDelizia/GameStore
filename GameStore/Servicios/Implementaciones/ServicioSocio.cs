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

        public void DarDeBaja(Socio socio)
        {
            socio.Estado = false;
            _repositorioSocio.Actualizar(socio);
        }

        public List<Socio> ListarSocios()
        {
            return _repositorioSocio.GetTodos().ToList();
        }

        public List<Socio> ListarSociosActivos()
        {
            return _repositorioSocio.Encontrar(u => (bool)u.Estado).ToList();
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
            var dni = socio.NroDocumento;
            int repetido = Encontrar(s => s.NroDocumento == dni).ToList().Count;
            if (repetido != 0)
                throw new ApplicationException("Ya existe un socio con ese número de documento");
        }
    }
}
