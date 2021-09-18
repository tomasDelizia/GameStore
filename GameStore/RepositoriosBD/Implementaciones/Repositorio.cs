using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class Repositorio<TEntidad> : IRepositorio<TEntidad> where TEntidad : class
    {
        private readonly ContextoGameStore _contextoBd;

        public Repositorio(ContextoGameStore contextoBd)
        {
            _contextoBd = contextoBd;
        }

        public TEntidad GetPorId(int id)
        {
            return _contextoBd.Set<TEntidad>().Find(id);
        }

        public IEnumerable<TEntidad> GetTodos()
        {
            return _contextoBd.Set<TEntidad>().ToList();
        }

        public IEnumerable<TEntidad> Encontrar(Expression<Func<TEntidad, bool>> predicado)
        {
            return _contextoBd.Set<TEntidad>().Where(predicado);
        }

        public void Insertar(TEntidad entidad)
        {
            _contextoBd.Set<TEntidad>().Add(entidad);
            _contextoBd.SaveChanges();
        }

        public void InsertarRango(IEnumerable<TEntidad> entidades)
        {
            _contextoBd.Set<TEntidad>().AddRange(entidades);
            _contextoBd.SaveChanges();
        }

        public void Borrar(TEntidad entidadABorrar)
        {
            _contextoBd.Set<TEntidad>().Remove(entidadABorrar);
            _contextoBd.SaveChanges();
        }

        public void BorrarRango(IEnumerable<TEntidad> entidadesABorrar)
        {
            _contextoBd.Set<TEntidad>().RemoveRange(entidadesABorrar);
            _contextoBd.SaveChanges();
        }

        public void Actualizar(TEntidad entidad)
        {
            _contextoBd.Entry(entidad).State = EntityState.Modified;
            _contextoBd.SaveChanges();
        }
    }
}
