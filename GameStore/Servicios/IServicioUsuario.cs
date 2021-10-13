using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;

namespace GameStore.Servicios
{
    public interface IServicioUsuario : IServicio<Usuario>
    {
        List<Usuario> ListarUsuarios();

        Usuario Login(string nombreUsuario, string contrasenia);

        void ValidarUsuario(Usuario usuario);

        void BorrarUsuario(Usuario usuario);
        Empleado GetEmpleadoLogueado();
    }
}
