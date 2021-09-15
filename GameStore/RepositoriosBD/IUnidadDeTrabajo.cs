using System;

namespace GameStore.RepositoriosBD
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IRepositorioClasificacion RepositorioClasificacion { get; }
        IRepositorioUsuario RepositorioUsuario { get; }
        int Guardar();
    }
}
