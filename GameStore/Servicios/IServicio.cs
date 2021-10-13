using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace GameStore.Servicios
{
    public interface IServicio<TEntidad> where TEntidad : class
    {
        TEntidad GetPorId(int id);

        IEnumerable<TEntidad> GetTodos();

        IEnumerable<TEntidad> Encontrar(Expression<Func<TEntidad, bool>> predicado);

        bool Insertar(TEntidad entidad);

        void InsertarRango(IEnumerable<TEntidad> entidades);

        void Borrar(TEntidad entidadABorrar);

        void BorrarRango(IEnumerable<TEntidad> entidadesABorrar);

        void Actualizar(TEntidad entidad);

        void Guardar(TEntidad entidad);
    }
}