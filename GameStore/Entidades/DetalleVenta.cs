namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetallesDeVenta")]
    public partial class DetalleVenta
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NroFactura { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public virtual Articulo Articulo { get; set; }

        // public virtual Venta Venta { get; set; }

        public decimal CalcularSubtotal()
        {
            return Cantidad * PrecioUnitario;
        }
    }
}
