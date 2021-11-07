namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleados")]
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
        }

        [Key]
        public int IdEmpleado { get; set; }

        public int NroDocumento { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Telefono { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaAlta { get; set; }

        [StringLength(50)]
        public string CalleNombre { get; set; }

        public int? CalleNumero { get; set; }

        public int? IdCargo { get; set; }

        public int? IdBarrio { get; set; }

        public virtual Barrio Barrio { get; set; }

        public virtual Cargo Cargo { get; set; }

        public bool? Estado { get; set; }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new ApplicationException("El nombre es requerido.");
            if (Nombre.Length > 50)
                throw new ApplicationException("El nombre no debe superar los 50 caracteres.");
            if (!Utils.Utils.TieneSoloValoresAlfabeticos(Nombre))
                throw new ApplicationException("El nombre solo puede contener letras de la A a la Z");
        }
        
        public void ValidarApellido()
        {
            if (string.IsNullOrEmpty(Apellido))
                throw new ApplicationException("El apellido es requerido.");
            if (Apellido.Length > 50)
                throw new ApplicationException("El apellido no debe superar los 50 caracteres.");
            if (!Utils.Utils.TieneSoloValoresAlfabeticos(Apellido))
                throw new ApplicationException("El apellido solo puede contener letras de la A a la Z");
        }

        public void ValidarMail()
        {
            if (Email.Length > 50)
                throw new ApplicationException("El mail no debe superar los 50 caracteres.");
        }
        
        public void ValidarCalleNombre()
        {
            if (CalleNombre.Length > 50)
                throw new ApplicationException("El nombre de la calle no debe superar los 50 caracteres.");
        }
        
        public void ValidarCalleNumero()
        {
            if (CalleNumero > 10000 || CalleNumero < 0)
                throw new ApplicationException("La altura de la calle no es válida.");
        }

        public void ValidarDocumento()
        {
            if (string.IsNullOrEmpty(NroDocumento.ToString()))
                throw new ApplicationException("El documento es requerido.");
            if (NroDocumento > 100000000)
                throw new ApplicationException("El documento es inválido.");
        }

        public void ValidarTelefono()
        {
            if (Telefono.Length > 30)
                throw new ApplicationException("El teléfono no debe superar los 30 caracteres.");
        }

        public string GetNombreYApellido()
        {
            return Nombre + " " + Apellido;
        }

        public bool ContieneMismoNombreYApellido(Empleado empleadoAComparar)
        {
            return Nombre.Contains(empleadoAComparar.Nombre) && Apellido.Contains(empleadoAComparar.Apellido);
        }
    }
}
