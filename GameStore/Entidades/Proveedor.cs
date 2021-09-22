namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Proveedores")]
    public partial class Proveedor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Proveedor()
        {
        }

        [Key]
        public int IdProveedor { get; set; }

        [Required]
        [StringLength(50)]
        public string RazonSocial { get; set; }

        public int? Cuit { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Telefono { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaAlta { get; set; }

        [StringLength(50)]
        public string CalleNombre { get; set; }

        public int? CalleNumero { get; set; }

        public int? IdBarrio { get; set; }

        public virtual Barrio Barrio { get; set; }

        public void ValidarRazonSocial()
        {
            if (string.IsNullOrEmpty(RazonSocial))
                throw new ApplicationException("La razón social es requerida.");
            if (RazonSocial.Length > 50)
                throw new ApplicationException("La razón social no debe superar los 50 caracteres.");
        }

        public void ValidarCuit()
        {
            string cuit = Cuit.ToString();
            if (string.IsNullOrEmpty(cuit))
                throw new ApplicationException("El cuit es requerido");
            if (Cuit < 0)
                throw new ApplicationException("Ingrese un CUIT válido.");
        }

        public void ValidarTelefono()
        {
            if (Telefono.Length > 30)
                throw new ApplicationException("El teléfono no debe superar los 30 caracteres.");
        }

        public void ValidarCalle()
        {
            if (CalleNombre.Length > 50)
                throw new ApplicationException("El nombre de la calle no debe superar los 50 caracteres.");
        }

        public void ValidarNumeroCalle()
        {
            if (CalleNumero < 0)
                throw new ApplicationException("No existen alturas de calles negativas. Debe ingresar un valor válido.");
        }
    }
}
