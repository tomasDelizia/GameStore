using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;
using GameStore.RepositoriosBD;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioCargo : Servicio<Cargo> , IServicioCargo
    {
        private IRepositorioCargo _repositorioCargo;

        public ServicioCargo(IRepositorioCargo repositorioCargo) : base(repositorioCargo)
        {
            _repositorioCargo = repositorioCargo;
        }

        public List<Cargo> ListarCargos()
        {
            return _repositorioCargo.GetTodos().ToList();
        }
        public void ValidarCargo(Cargo cargo)
        {
            cargo.ValidarNombre();
        }
    }
}
