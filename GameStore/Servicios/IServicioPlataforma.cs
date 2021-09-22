using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios
{
    public interface IServicioPlataforma : IServicio<Plataforma>
    {
        List<Plataforma> ListarPlataformas();
        void ValidarPlataforma(Plataforma plataforma);
    }
}
