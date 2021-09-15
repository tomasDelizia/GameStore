using System;

namespace GameStore.RepositoriosBD
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IRepositorioClasificacion RepositorioClasificacion { get; }
        IRepositorioUsuario RepositorioUsuario { get; }
        IRepositorioArticulo RepositorioArticulo { get; }
        int Guardar();
    }
}
