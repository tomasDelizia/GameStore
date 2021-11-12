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

        public void DarDeBaja(Empleado empleado)
        {
            empleado.Estado = false;
            _repositorioEmpleado.Actualizar(empleado);
        }

        public List<Empleado> ListarEmpleados()
        {
            return _repositorioEmpleado.GetTodos().ToList();
        }

        public List<Empleado> ListarEmpleadosActivos()
        {
            return _repositorioEmpleado.Encontrar(u => (bool)u.Estado).ToList();
        }

        public void ValidarEmpleado(Empleado empleado)
        {
            empleado.ValidarNombre();
            empleado.ValidarApellido();
            empleado.ValidarMail();
            empleado.ValidarCalleNombre();
            empleado.ValidarCalleNumero();
            empleado.ValidarDocumento();
            empleado.ValidarTelefono();
            var dni = empleado.NroDocumento;
            int repetido = Encontrar(e => e.NroDocumento == dni).ToList().Count;
            if (repetido != 0)
                throw new ApplicationException("Ya existe un empleado con ese número de documento");
        }
    }
}