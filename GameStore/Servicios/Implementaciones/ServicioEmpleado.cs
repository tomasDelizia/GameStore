using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;
using GameStore.RepositoriosBD;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioEmpleado : Servicio<Empleado> , IServicioEmpleado
    {
        private IRepositorioEmpleado _repositorioEmpleado;

        public ServicioEmpleado(IRepositorioEmpleado repositorioEmpleado) : base(repositorioEmpleado)
        {
            _repositorioEmpleado = repositorioEmpleado;
        }

        public List<Empleado> ListarEmpleados()
        {
            return _repositorioEmpleado.GetTodos().ToList();
        }
    }
}