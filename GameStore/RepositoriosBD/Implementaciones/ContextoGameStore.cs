using System.Data.Entity;
using GameStore.Entidades;

namespace GameStore.RepositoriosBD.Implementaciones
{
    public partial class ContextoGameStore : DbContext
    {
        public ContextoGameStore()
            : base("name=ContextoGamestore")
        {
        }

        public virtual DbSet<Alquiler> Alquileres { get; set; }
        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Barrio> Barrios { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Clasificacion> Clasificaciones { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Desarrollador> Desarrolladores { get; set; }
        public virtual DbSet<DetalleAlquiler> DetallesDeAlquilers { get; set; }
        public virtual DbSet<DetalleCompra> DetallesDeCompras { get; set; }
        public virtual DbSet<DetalleVenta> DetallesDeVentas { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<EstadoVideojuego> EstadosDeVideojuegoes { get; set; }
        public virtual DbSet<FormaPago> FormasDePagoes { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Permiso> Permisos { get; set; }
        public virtual DbSet<Plataforma> Plataformas { get; set; }
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Sesion> Sesiones { get; set; }
        public virtual DbSet<Socio> Socios { get; set; }
        public virtual DbSet<TipoArticulo> TiposDeArticuloes { get; set; }
        public virtual DbSet<TipoFactura> TiposDeFacturas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alquiler>()
                .Property(e => e.MontoSenia)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Articulo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Articulo>()
                .Property(e => e.PrecioUnitario)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Articulo>()
                .Property(e => e.Imagen)
                .IsUnicode(false);

            modelBuilder.Entity<Articulo>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Barrio>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cargo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cargo>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaAlquiler>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaAlquiler>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<CategoriaAlquiler>()
                .Property(e => e.MontoAlquilerPorDia)
                .HasPrecision(9, 2);

            modelBuilder.Entity<CategoriaAlquiler>()
                .Property(e => e.MontoDevolucionTardiaPorDia)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Clasificacion>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Clasificacion>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Desarrollador>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Desarrollador>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<DetalleAlquiler>()
                .Property(e => e.MontoAlquilerPorDia)
                .HasPrecision(9, 2);

            modelBuilder.Entity<DetalleAlquiler>()
                .Property(e => e.MontoDevolucionTardiaPorDia)
                .HasPrecision(9, 2);

            modelBuilder.Entity<DetalleCompra>()
                .Property(e => e.PrecioUnitario)
                .HasPrecision(9, 2);

            modelBuilder.Entity<DetalleVenta>()
                .Property(e => e.PrecioUnitario)
                .HasPrecision(9, 2);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.CalleNombre)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoVideojuego>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<EstadoVideojuego>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<FormaPago>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<FormaPago>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Genero>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Genero>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Marca>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Marca>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Permiso>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Plataforma>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Plataforma>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.RazonSocial)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Proveedor>()
                .Property(e => e.CalleNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Socio>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Socio>()
                .Property(e => e.Apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Socio>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Socio>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Socio>()
                .Property(e => e.CalleNombre)
                .IsUnicode(false);

            modelBuilder.Entity<Socio>()
                .HasMany(e => e.Alquileres)
                .WithOptional(e => e.Socio)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Socio>()
                .HasMany(e => e.Ventas)
                .WithOptional(e => e.Socio)
                .WillCascadeOnDelete();

            modelBuilder.Entity<TipoArticulo>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoArticulo>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoFactura>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<TipoFactura>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Contrasenia)
                .IsUnicode(false);
        }
    }
}
