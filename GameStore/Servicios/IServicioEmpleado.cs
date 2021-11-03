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
        List<Empleado> ListarEmpleados();
        void ValidarEmpleado(Empleado empleado);
        List<Empleado> ListarEmpleadosActivos();
        void DarDeBaja(Empleado empleado);
    }
}
