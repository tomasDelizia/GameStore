namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    // Para después.
    [Table("Sesiones")]
    public partial class Sesion
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdUsuario { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime FechaYHoraInicio { get; set; }

        public DateTime? FechaYHoraFin { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
