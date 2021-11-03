namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TarifasDeAlquiler")]
    public partial class TarifaAlquiler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TarifaAlquiler()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTarifaAlquiler { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public decimal MontoAlquilerPorDia { get; set; }

        public decimal MontoDevolucionTardiaPorDia { get; set; }

        internal void ValidarMontoAlquilerDiario()
        {
            if (MontoAlquilerPorDia <= 0 || MontoAlquilerPorDia >= 10000000)
                throw new ApplicationException("Ingrese un precio válido.");
        }

        internal void ValidarMontoAlquilerTardio()
        {
            if (MontoDevolucionTardiaPorDia <= 0 || MontoDevolucionTardiaPorDia >= 10000000)
                throw new ApplicationException("Ingrese un precio válido.");
        }

        internal void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new ApplicationException("El nombre es requerido.");
            if (Nombre.Length > 50)
                throw new ApplicationException("El nombre no debe superar los 50 caracteres.");
        }
    }
}
