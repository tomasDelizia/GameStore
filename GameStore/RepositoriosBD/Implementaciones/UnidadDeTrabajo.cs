using System.Data.Entity;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly ContextoGameStore _contextoBd;

        public UnidadDeTrabajo(ContextoGameStore contextoBd)
        {
            _contextoBd = contextoBd;
            RepositorioArticulo = new RepositorioArticulo(_contextoBd);
            RepositorioClasificacion = new RepositorioClasificacion(_contextoBd);
            RepositorioUsuario = new RepositorioUsuario(_contextoBd);
            RepositorioTipoArticulo = new RepositorioTipoArticulo(_contextoBd);
            RepositorioDesarrollador = new RepositorioDesarrollador(_contextoBd);
            RepositorioGenero = new RepositorioGenero(_contextoBd);
            RepositorioPlataforma = new RepositorioPlataforma(_contextoBd);
            RepositorioArchivo = new RepositorioArchivo(_contextoBd);
            RepositorioMarca = new RepositorioMarca(_contextoBd);
            RepositorioRol = new RepositorioRol(_contextoBd);
            RepositorioProveedor = new RepositorioProveedor(_contextoBd);
            RepositorioBarrio = new RepositorioBarrio(_contextoBd);
            RepositorioPerfil = new RepositorioPerfil(_contextoBd);
            RepositorioCargo = new RepositorioCargo(_contextoBd);
            RepositorioEmpleado = new RepositorioEmpleado(_contextoBd);
            RepositorioSocio = new RepositorioSocio(_contextoBd);
            RepositorioFormaPago = new RepositorioFormaPago(_contextoBd);
            RepositorioTarifaAlquiler = new RepositorioTarifaAlquiler(_contextoBd);
            RepositorioTipoFactura = new RepositorioTipoFactura(_contextoBd);
            RepositorioVenta = new RepositorioVenta(_contextoBd);
            RepositorioDetalleVenta = new RepositorioDetalleVenta(_contextoBd);
            RepositorioCompra = new RepositorioCompra(_contextoBd);
            RepositorioAlquiler = new RepositorioAlquiler(_contextoBd);
            RepositorioEstadoVideojuego = new RepositorioEstadoVideojuego(_contextoBd);
        }

        public IRepositorioClasificacion RepositorioClasificacion { get; private set; }
        public IRepositorioUsuario RepositorioUsuario { get; private set; }
        public IRepositorioTipoArticulo RepositorioTipoArticulo { get; private set; }
        public IRepositorioDesarrollador RepositorioDesarrollador { get; private set; }
        public IRepositorioGenero RepositorioGenero { get; private set; }
        public IRepositorioPlataforma RepositorioPlataforma { get; private set; }
        public IRepositorioArchivo RepositorioArchivo { get; private set; }
        public IRepositorioArticulo RepositorioArticulo { get; private set; }
        public IRepositorioMarca RepositorioMarca { get; private set; }
        public IRepositorioRol RepositorioRol { get; private set; }
        public IRepositorioProveedor RepositorioProveedor { get; private set; }
        public IRepositorioBarrio RepositorioBarrio { get; private set; }
        public IRepositorioPerfil RepositorioPerfil { get; private set; }
        public IRepositorioEmpleado RepositorioEmpleado { get; private set; }
        public IRepositorioCargo RepositorioCargo { get; private set; }
        public IRepositorioSocio RepositorioSocio { get; private set; }
        public IRepositorioFormaPago RepositorioFormaPago { get; private set; }
        public IRepositorioTarifaAlquiler RepositorioTarifaAlquiler { get; private set; }
        public IRepositorioTipoFactura RepositorioTipoFactura { get; private set; }
        public IRepositorioDetalleVenta RepositorioDetalleVenta { get; private set; }
        public IRepositorioVenta RepositorioVenta { get; private set; }
        public IRepositorioCompra RepositorioCompra { get; private set; }
        public IRepositorioAlquiler RepositorioAlquiler { get; private set; }

        public IRepositorioEstadoVideojuego RepositorioEstadoVideojuego { get; private set; }

        public int Guardar()
        {
            return _contextoBd.SaveChanges();
        }

        public void Dispose()
        {
            _contextoBd.Dispose();
        }

        public void Deshacer()
        {
            Dispose();
        }
    }
}
