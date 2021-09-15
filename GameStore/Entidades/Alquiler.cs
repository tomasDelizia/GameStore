namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Alquileres")]
    public partial class Alquiler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Alquiler()
        {
            DetallesDeAlquiler = new HashSet<DetalleAlquiler>();
        }

        [Key]
        public int NroAlquiler { get; set; }

        public int? IdTipoFactura { get; set; }

        public int? IdFormaPago { get; set; }

        public decimal MontoSenia { get; set; }

        public int FechaInicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaFin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaFinReal { get; set; }

        public int? IdSocio { get; set; }

        public int? IdVendedor { get; set; }

        public virtual FormaPago FormasDePago { get; set; }

        public virtual Socio Socio { get; set; }

        public virtual TipoFactura TiposDeFactura { get; set; }

        public virtual Empleado Empleado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleAlquiler> DetallesDeAlquiler { get; set; }
    }
}
