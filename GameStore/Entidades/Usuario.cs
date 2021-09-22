namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuarios")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Roles = new HashSet<Rol>();
        }

        [Key]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Contrasenia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaAlta { get; set; }

        public bool? Estado { get; set; }

        public int? IdPerfil { get; set; }

        public virtual Perfil Perfil { get; set; }

        public int? IdEmpleado { get; set; }

        public virtual Empleado Empleado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rol> Roles { get; set; }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(NombreUsuario))
                throw new ApplicationException("El nombre de usuario es requerido.");
            if (NombreUsuario.Length > 50)
                throw new ApplicationException("El nombre de usuario no debe superar los 50 caracteres.");
        }

        public void ValidarContrasenia()
        {
            if (string.IsNullOrEmpty(this.Contrasenia))
                throw new ApplicationException("La contraseña es requerida");
            if (this.Contrasenia.Length > 50)
                throw new ApplicationException("Contraseña inválida. La contraseña no debe superar los 50 caracteres");
        }
    }
}
