using GameStore.Entidades;
using GameStore.RepositoriosBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioTarifaAlquiler : Servicio<TarifaAlquiler>, IServicioTarifaAlquiler
    {
        private readonly IRepositorioTarifaAlquiler _repositorioTarifa;
        public ServicioTarifaAlquiler(IRepositorioTarifaAlquiler repositorioTarifa) : base(repositorioTarifa)
        {
            _repositorioTarifa = repositorioTarifa;
        }

        public List<TarifaAlquiler> ListarTarifasDeAlquiler()
        {
            return _repositorioTarifa.GetTodos().ToList();
        }
        public void ValidarCategoria(TarifaAlquiler categoria)
        {
            categoria.ValidarNombre();
            categoria.ValidarMontoAlquilerDiario();
            categoria.ValidarMontoAlquilerTardio();
        }

        public TarifaAlquiler GetPorNombre(string nombre)
        {
            var tarifas = ListarTarifasDeAlquiler();
            var tarifaBuscada = Encontrar(c => c.Nombre == nombre).ToList();
            var primeraTarifa = tarifaBuscada[0];
            return primeraTarifa;         
        }
    }
}
