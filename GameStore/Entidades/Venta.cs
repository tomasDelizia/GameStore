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

        public int? IdVendedor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleVenta> DetallesDeVenta { get; set; }

        public virtual Empleado Empleado { get; set; }

        public virtual FormaPago FormaPago { get; set; }

        public virtual Socio Socio { get; set; }

        public virtual TipoFactura TiposDeFactura { get; set; }
    }
}
