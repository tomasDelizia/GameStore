using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GameStore.RepositoriosBD
{
    public interface IRepositorio<TEntidad> where TEntidad: class
    {
        TEntidad GetPorId(int id);

        IEnumerable<TEntidad> GetTodos();

        IEnumerable<TEntidad> Encontrar(Expression<Func<TEntidad, bool>> predicado);

        int Insertar(TEntidad entidad);
        void Guardar(TEntidad entidad);

        void InsertarRango(IEnumerable<TEntidad> entidades);

        void Borrar(TEntidad entidadABorrar);

        void BorrarRango(IEnumerable<TEntidad> entidadesABorrar);

        void Actualizar(TEntidad entidad);
    }
}
