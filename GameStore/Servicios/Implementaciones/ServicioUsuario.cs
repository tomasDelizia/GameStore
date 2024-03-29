﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.Entidades;
using GameStore.RepositoriosBD;

namespace GameStore.Servicios.Implementaciones
{
    public class ServicioUsuario : Servicio<Usuario>, IServicioUsuario
    {
        private IRepositorioUsuario _repositorioUsuario;
        public static Usuario UsuarioLogueado;

        public ServicioUsuario(IRepositorioUsuario repositorioUsuario) : base(repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public List<Usuario> ListarUsuarios()
        {
            return _repositorioUsuario.GetTodos().ToList();
        }

        public Usuario Login(string nombreUsuario, string contrasenia)
        {
            List<Usuario> listaUsuarios = ListarUsuarios();
            foreach (Usuario usuario in listaUsuarios)
            {
                if (usuario.NombreUsuario == nombreUsuario && usuario.Contrasenia == contrasenia)
                {
                    UsuarioLogueado = usuario;
                    return usuario;
                }
            }
            return null;
        }

        public void ValidarUsuario(Usuario usuario)
        {
            usuario.ValidarNombre();
            usuario.ValidarContrasenia();
        }

        public void BorrarUsuario(Usuario usuario)
        {
            usuario.Estado = false;
            _repositorioUsuario.Actualizar(usuario);
        }
        public Empleado GetEmpleadoLogueado()
        {
            return UsuarioLogueado.Empleado;
        }

        public List<Usuario> ListarUsuariosActivos()
        {
            return _repositorioUsuario.Encontrar(u => (bool)u.Estado).ToList();
        }

        public Usuario GetUsuarioLogueado()
        {
            return UsuarioLogueado;
        }
    }
}
