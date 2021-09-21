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
            RepositorioEmpleado = new RepositorioEmpleado(_contextoBd);
            RepositorioCargo = new RepositorioCargo(_contextoBd);
        }

        public IRepositorioClasificacion RepositorioClasificacion { get; private set; }
        public IRepositorioUsuario RepositorioUsuario { get; private set; }
        public IRepositorioTipoArticulo RepositorioTipoArticulo {get; private set;}
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
        public int Guardar()
        {
            return _contextoBd.SaveChanges();
        }

        public void Dispose()
        {
            _contextoBd.Dispose();
        }
    }
}
