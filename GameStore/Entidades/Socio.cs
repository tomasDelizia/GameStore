namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Socios")]
    public partial class Socio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Socio()
        {
            Alquileres = new HashSet<Alquiler>();
            Ventas = new HashSet<Venta>();
        }

        [Key]
        public int IdSocio { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        public int NroDocumento { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Telefono { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaNacimiento { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaAlta { get; set; }

        [StringLength(50)]
        public string CalleNombre { get; set; }

        public int? CalleNumero { get; set; }

        public int? IdBarrio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Alquiler> Alquileres { get; set; }

        public virtual Barrio Barrio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Ventas { get; set; }
        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new ApplicationException("El nombre es requerido.");
            if (Nombre.Length > 50)
                throw new ApplicationException("El nombre no debe superar los 50 caracteres.");
        }
        public void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
                throw new ApplicationException("El apellido es requerido.");
            if (Nombre.Length > 50)
                throw new ApplicationException("El apellido no debe superar los 50 caracteres.");
        }

        internal string GetApellidoYNombre()
        {
            string Datos = this.Apellido + " " + this.Nombre;
            return Datos;
        }


        public void ValidarDocumento()
        {
            string documento = NroDocumento.ToString();
            if (string.IsNullOrEmpty(documento))
                throw new ApplicationException("El documento es requerido");
            if (NroDocumento < 0)
                throw new ApplicationException("Ingrese un documento vlido.");
        }
        /// <summary>
        /// Este metodo esta replicado en Proveedor. Corregir.
        /// </summary>
        public void ValidarTelefono()
        {
            if (Telefono.Length > 30)
                throw new ApplicationException("El telfono no debe superar los 30 caracteres.");
        }
        /// <summary>
        /// Este metodo esta replicado en Proveedor. Corregir.
        /// </summary>
        public void ValidarCalle()
        {
            if (CalleNombre.Length > 50)
                throw new ApplicationException("El nombre de la calle no debe superar los 50 caracteres.");
        }
        /// <summary>
        /// Este metodo esta replicado en proveedor. Corregir.
        /// </summary>
        public void ValidarNumeroCalle()
        {
            if (CalleNumero < 0)
                throw new ApplicationException("No existen alturas de calles negativas. Debe ingresar un valor vlido.");
        }

        public void ValidarEmail()
        {
            if (string.IsNullOrEmpty(Email))
                throw new ApplicationException("El email es requerido.");
            if (Email.Length > 50)
                throw new ApplicationException("El email no debe superar los 50 caracteres.");
        }
    }
}
