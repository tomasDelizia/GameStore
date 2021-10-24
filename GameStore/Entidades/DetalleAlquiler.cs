namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DetallesDeAlquiler")]
    public partial class DetalleAlquiler
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NroAlquiler { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }

        public decimal MontoAlquilerPorDia { get; set; }

        public decimal MontoDevolucionTardiaPorDia { get; set; }

        public virtual Articulo Articulo { get; set; }

        public decimal CalcularSubtotal( int dias)
        {           
            return dias * MontoAlquilerPorDia;
        }
    }
}
