using System;

namespace GameStore.RepositoriosBD
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IRepositorioClasificacion RepositorioClasificacion { get; }
        int Guardar();
    }
}
