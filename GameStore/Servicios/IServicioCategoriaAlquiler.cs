using GameStore.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios
{
    public interface IServicioCategoriaAlquiler : IServicio<CategoriaAlquiler>
    {
        List<CategoriaAlquiler> ListarCategorias();
        void ValidarCategoria(CategoriaAlquiler categoria);

        CategoriaAlquiler GetPorNombre(string nombre);
    }
}
