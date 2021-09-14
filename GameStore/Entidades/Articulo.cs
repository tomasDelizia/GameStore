namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Articulos")]
    public partial class Articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articulo()
        {
            DetallesDeAlquiler = new HashSet<DetalleAlquiler>();
            DetallesDeCompra = new HashSet<DetalleCompra>();
            DetallesDeVenta = new HashSet<DetalleVenta>();
        }

        [Key]
        public int Codigo { get; set; }

        public int? IdTipoArticulo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public decimal PrecioUnitario { get; set; }

        public int Stock { get; set; }

        public int? IdEstado { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaSalida { get; set; }

        public int? IdMarca { get; set; }

        public int? IdClasificacion { get; set; }

        public int? IdGenero { get; set; }

        public int? IdDesarrollador { get; set; }

        public int? IdPublicante { get; set; }

        public int? IdPlataforma { get; set; }

        [StringLength(100)]
        public string Imagen { get; set; }

        public string Descripcion { get; set; }

        public virtual Clasificacion Clasificacione { get; set; }

        public virtual Desarrollador Desarrolladore { get; set; }

        public virtual EstadoVideojuego EstadosDeVideojuego { get; set; }

        public virtual Genero Genero { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual Plataforma Plataforma { get; set; }

        public virtual Publicante Publicante { get; set; }

        public virtual TipoArticulo TiposDeArticulo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleAlquiler> DetallesDeAlquiler { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompra> DetallesDeCompra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetallesDeVenta { get; set; }
    }
}
