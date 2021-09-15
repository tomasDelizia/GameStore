namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Marcas")]
    public partial class Marca
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Marca()
        {
        }

        [Key]
        public int IdMarca { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
    }
}
