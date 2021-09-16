using System;

namespace GameStore.RepositoriosBD
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IRepositorioClasificacion RepositorioClasificacion { get; }
        IRepositorioUsuario RepositorioUsuario { get; }
        IRepositorioTipoArticulo RepositorioTipoArticulo { get; }
        IRepositorioDesarrollador RepositorioDesarrollador { get; }
        IRepositorioGenero RepositorioGenero { get; }
        IRepositorioPlataforma RepositorioPlataforma { get; }
        int Guardar();
    }
}
