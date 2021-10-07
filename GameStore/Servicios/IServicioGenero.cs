using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios
{
    public interface IServicioGenero : IServicio<Genero>
    {
        void ValidarGenero(Genero genero);
        Genero GetPorId(int id);
        List<Genero> ListarGeneros();
    }
}
