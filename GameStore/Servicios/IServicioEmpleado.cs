using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;

namespace GameStore.Servicios
{

    public interface IServicioEmpleado : IServicio<Empleado>
    {
        /// <summary>
        /// Devuelve una lista de empleados
        /// </summary>
        List<Empleado> ListarEmpleados();
    }
}
