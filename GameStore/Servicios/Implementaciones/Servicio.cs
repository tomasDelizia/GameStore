using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GameStore.RepositoriosBD;

namespace GameStore.Servicios.Implementaciones
{
    public class Servicio<TEntidad> : IServicio<TEntidad> where TEntidad : class
    {
        private IRepositorio<TEntidad> _repositorio;

        public Servicio(IRepositorio<TEntidad> repositorio)
        {
            _repositorio = repositorio;
        }

        public TEntidad GetPorId(int id)
        {
            return _repositorio.GetPorId(id);
        }

        public TEntidad GetPorId(long id)
        {
            return _repositorio.GetPorId(id);
        }

        public IEnumerable<TEntidad> GetTodos()
        {
            return _repositorio.GetTodos();
        }

        public IEnumerable<TEntidad> Encontrar(Expression<Func<TEntidad, bool>> predicado)
        {
            return _repositorio.Encontrar(predicado);
        }

        public bool Insertar(TEntidad entidad)
        {
            var filasAfectadas = _repositorio.Insertar(entidad);
            if (filasAfectadas == 1)
                return true;
            return false;
        }

        public void InsertarRango(IEnumerable<TEntidad> entidades)
        {
            _repositorio.InsertarRango(entidades);
        }

        public void Borrar(TEntidad entidadABorrar)
        {
            _repositorio.Borrar(entidadABorrar);
        }

        public void BorrarRango(IEnumerable<TEntidad> entidadesABorrar)
        {
            _repositorio.BorrarRango(entidadesABorrar);
        }

        public void Actualizar(TEntidad entidad)
        {
            _repositorio.Actualizar(entidad);
        }

        public void Guardar(TEntidad entidad)
        {
            _repositorio.Guardar(entidad);
        }


    }
}