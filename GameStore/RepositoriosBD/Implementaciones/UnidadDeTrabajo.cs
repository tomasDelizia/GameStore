﻿namespace GameStore.RepositoriosBD.Implementaciones
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly ContextoGameStore _contextoBd;

        public UnidadDeTrabajo(ContextoGameStore contextoBd)
        {
            _contextoBd = contextoBd;
            RepositorioClasificacion = new RepositorioClasificacion(_contextoBd);
            RepositorioUsuario = new RepositorioUsuario(_contextoBd);
            RepositorioTipoArticulo = new RepositorioTipoArticulo(_contextoBd);
            RepositorioDesarrollador = new RepositorioDesarrollador(_contextoBd);
            RepositorioGenero = new RepositorioGenero(_contextoBd);
            RepositorioPlataforma = new RepositorioPlataforma(_contextoBd);
        }

        public IRepositorioClasificacion RepositorioClasificacion { get; private set; }
        public IRepositorioUsuario RepositorioUsuario { get; private set; }
        public IRepositorioTipoArticulo RepositorioTipoArticulo {get; private set;}
        public IRepositorioDesarrollador RepositorioDesarrollador { get; private set; }
        public IRepositorioGenero RepositorioGenero { get; private set; }
        public IRepositorioPlataforma RepositorioPlataforma { get; private set; }


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
