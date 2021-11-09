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

        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; } 

        [Column(TypeName = "date")]
        public DateTime FechaFin { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaFinReal { get; set; }

        public int? IdSocio { get; set; }
        [ForeignKey("Vendedor")]
        public int? IdVendedor { get; set; }

        public virtual FormaPago FormaPago { get; set; }

        public virtual Socio Socio { get; set; }

        public virtual TipoFactura TipoFactura { get; set; }

        public virtual Empleado Vendedor { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleAlquiler> DetallesDeAlquiler { get; set; }

        public void AgregarDetalle(DetalleAlquiler detalle)
        {
            DetallesDeAlquiler.Add(detalle);
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

        public void ValidarDetallesDeAlquiler()
        {
            if (DetallesDeAlquiler.Count == 0)
                throw new ApplicationException("Debe seleccionar al menos un videojuego.");
        }

        public decimal CalcularTotal()
        {
            int dias = CantidadDias();
            decimal total = 0;
            foreach (var detalle in DetallesDeAlquiler)
            {
                total += detalle.CalcularSubtotal(dias);
            }
            return total;
        }

        public bool EsDevuelto()
        {
            if (FechaFinReal != null)
                return true;
            return false;
        }

        public decimal CalcularImporteDevolucionTardia()
        {
            decimal total = 0;
            var fechaDevolucionReal = DateTime.Today;
            if (fechaDevolucionReal > FechaFin)
                total = CalcularAdicional();
            return total;
        }

        public decimal CalcularAdicional()
        {
            decimal adicional = 0;
            int cantDiasExtra = (DateTime.Today - FechaFin).Days;
            foreach(var detalle in DetallesDeAlquiler)
            {
                adicional += detalle.MontoDevolucionTardiaPorDia * cantDiasExtra;
            }
            return adicional;
        }

        public decimal CalcularImporteFinal()
        {
            return CalcularTotal() - MontoSenia + CalcularImporteDevolucionTardia();
        }

        public int CantidadDias()
        {
            return (FechaFin - FechaInicio).Days; 
        }
    }
}
