using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios
{
    public interface IServicioSocio : IServicio<Socio>
    {
        List<Socio> ListarSocios();
        List<Socio> ListarSociosActivos();
        void ValidarSocio(Socio socio);
        void DarDeBaja(Socio socio);
    }
}
