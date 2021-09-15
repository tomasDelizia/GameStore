namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Barrios")]
    public partial class Barrio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Barrio()
        {
        }

        [Key]
        public int IdBarrio { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
