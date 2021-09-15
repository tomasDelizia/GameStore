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

        [Key]
        public int NroFactura { get; set; }

        public int? IdTipoFactura { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaCompra { get; set; }

        public int? IdProveedor { get; set; }

        public int? IdEncargadoCompra { get; set; }

        public virtual Empleado Empleado { get; set; }

        public virtual Proveedor Proveedor { get; set; }

        public virtual TipoFactura TipoFactura { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleCompra> DetallesDeCompra { get; set; }
    }
}
