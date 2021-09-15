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

        public int? IdPlataforma { get; set; }

        [StringLength(100)]
        public string Imagen { get; set; }

        public string Descripcion { get; set; }

        public virtual Clasificacion Clasificacion { get; set; }

        public virtual Desarrollador Desarrollador { get; set; }

        public virtual EstadoVideojuego EstadoVideojuego { get; set; }

        public virtual Genero Genero { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual Plataforma Plataforma { get; set; }

        public virtual TipoArticulo TipoArticulo { get; set; }
    }
}
