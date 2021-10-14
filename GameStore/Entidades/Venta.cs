namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ventas")]
    public partial class Venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Venta()
        {
            DetallesDeVenta = new HashSet<DetalleVenta>();
        }

        [Key]
        public int NroFactura { get; set; }

        public int? IdTipoFactura { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaVenta { get; set; }

        public int? IdFormaPago { get; set; }

        public int? IdSocio { get; set; }

        [ForeignKey("Vendedor")]
        public int? IdVendedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetallesDeVenta { get; set; }

        public virtual Empleado Vendedor { get; set; }

        public virtual FormaPago FormaPago { get; set; }

        public virtual Socio Socio { get; set; }

        public virtual TipoFactura TipoFactura { get; set; }

        public void AgregarDetalle(DetalleVenta detalle)
        {
            DetallesDeVenta.Add(detalle);
        }

        public void ValidarFormaPago()
        {
            if (FormaPago == null)
                throw new ApplicationException("La forma de pago es requerida.");
        }

        public void ValidarTipoFactura()
        {
            if (TipoFactura == null)
                throw new ApplicationException("El tipo de factura es requerido.");
        }

        public void ValidarSocio()
        {
            if (Socio == null)
                throw new ApplicationException("El socio es requerido.");
        }

        public void ValidarDetallesDeVenta()
        {
            if (DetallesDeVenta.Count == 0)
                throw new ApplicationException("Debe seleccionar al menos un artículo.");
        }
    }
}
