using System;

namespace GameStore.RepositoriosBD
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IRepositorioArchivo RepositorioArchivo { get; }
        IRepositorioArticulo RepositorioArticulo { get; }
        IRepositorioClasificacion RepositorioClasificacion { get; }
        IRepositorioTipoArticulo RepositorioTipoArticulo { get; }
        IRepositorioDesarrollador RepositorioDesarrollador { get; }
        IRepositorioGenero RepositorioGenero { get; }
        IRepositorioPlataforma RepositorioPlataforma { get; }
        IRepositorioUsuario RepositorioUsuario { get; }
        IRepositorioMarca RepositorioMarca { get; }
        IRepositorioRol RepositorioRol { get; }
        IRepositorioProveedor RepositorioProveedor { get; }
        IRepositorioBarrio RepositorioBarrio { get; }
        IRepositorioPerfil RepositorioPerfil { get; }
        IRepositorioEmpleado RepositorioEmpleado { get; }
        IRepositorioCargo RepositorioCargo { get; }
        int Guardar();
    }
}
