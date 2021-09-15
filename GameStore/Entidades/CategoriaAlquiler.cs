namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoriasDeAlquiler")]
    public partial class CategoriaAlquiler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CategoriaAlquiler()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdCategoriaAlquiler { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal MontoAlquilerPorDia { get; set; }

        public decimal MontoDevolucionTardiaPorDia { get; set; }
    }
}
