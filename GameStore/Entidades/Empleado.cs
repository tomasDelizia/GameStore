namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleados")]
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
        }

        [Key]
        public int IdEmpleado { get; set; }

        public int NroDocumento { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Telefono { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaAlta { get; set; }

        [StringLength(50)]
        public string CalleNombre { get; set; }

        public int? CalleNumero { get; set; }

        public int? IdCargo { get; set; }

        public int? IdBarrio { get; set; }

        public virtual Barrio Barrio { get; set; }

        public virtual Cargo Cargo { get; set; }
    }
}
