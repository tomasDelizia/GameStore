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
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdMarca { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new ApplicationException("El nombre es requerido.");
            if (Nombre.Length > 50)
                throw new ApplicationException("El nombre no debe superar los 50 caracteres.");
        }
    }
}
