namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Compras")]
    public partial class Compra
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compra()
        {
            DetallesDeCompra = new HashSet<DetalleCompra>();
        }

        internal void ValidarTipoFactura()
        {
            if (TipoFactura == null)
                throw new ApplicationException("El tipo de factura es requerido.");
        }

        internal void ValidarProveedor()
        {
            if (Proveedor == null)
                throw new ApplicationException("El proveedor es requerido");
        }

        [Key]
        public int NroFactura { get; set; }

        internal void ValidarDetallesDeCompra()
        {
            if (DetallesDeCompra.Count == 0)
                throw new ApplicationException("Debe seleccionar al menos un artículo.");
        }

        public int? IdTipoFactura { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaCompra { get; set; }

        public int? IdProveedor { get; set; }
        [ForeignKey("EncargadoCompra")]
        public int? IdEncargadoCompra { get; set; }

        public virtual Empleado EncargadoCompra { get; set; }

        public virtual Proveedor Proveedor { get; set; }
        public virtual TipoFactura TipoFactura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompra> DetallesDeCompra { get; set; }

        internal void AgregarDetalle(DetalleCompra detalle)
        {
            DetallesDeCompra.Add(detalle);
        }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var detalle in DetallesDeCompra)
            {
                total += detalle.CalcularSubtotal();
            }
            return total;

        }
    }
}
