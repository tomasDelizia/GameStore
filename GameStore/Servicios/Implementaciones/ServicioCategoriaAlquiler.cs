using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioCategoriaAlquiler : Servicio<CategoriaAlquiler>, IServicioCategoriaAlquiler
    {
        private readonly IRepositorioCategoriaAlquiler _repositorioCategoria;
        public ServicioCategoriaAlquiler(IRepositorioCategoriaAlquiler repositorioCategoria) : base(repositorioCategoria)
        {
            _repositorioCategoria = repositorioCategoria;
        }

        public List<CategoriaAlquiler> ListarCategorias()
        {
            return _repositorioCategoria.GetTodos().ToList();
        }
        public void ValidarCategoria(CategoriaAlquiler categoria)
        {
            categoria.ValidarNombre();
            categoria.ValidarMontoAlquilerDiario();
            categoria.ValidarMontoAlquilerTardio();
        }

        public CategoriaAlquiler GetPorNombre(string nombre)
        {
            var Categorias = ListarCategorias();
            var categoriaBuscada = Encontrar(c => c.Nombre == nombre).ToList();
            var primeraCategoria = categoriaBuscada[0];
            return primeraCategoria;         
        }
    }
}
