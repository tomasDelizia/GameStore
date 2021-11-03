namespace GameStore.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Text.RegularExpressions;

    [Table("Articulos")]
    public partial class Articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articulo()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Codigo { get; set; }

        public int IdTipoArticulo { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public decimal PrecioUnitario { get; set; }

        public int Stock { get; set; }

        public int IdEstado { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaSalida { get; set; }

        public int? IdMarca { get; set; }

        public int? IdClasificacion { get; set; }

        public int? IdGenero { get; set; }

        public int? IdDesarrollador { get; set; }

        public int IdPlataforma { get; set; }

        [ForeignKey("Archivo")]
        public int IdImagen { get; set; }

        public string Descripcion { get; set; }

        public virtual Clasificacion Clasificacion { get; set; }

        public virtual Desarrollador Desarrollador { get; set; }

        public virtual EstadoVideojuego EstadoVideojuego { get; set; }

        public virtual Genero Genero { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual Plataforma Plataforma { get; set; }

        public virtual TipoArticulo TipoArticulo { get; set; }

        public virtual Archivo Archivo { get; set; }

        public int IdTarifaAlquiler { get; set; }

        public virtual TarifaAlquiler TarifaAlquiler { get; set; }

        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new ApplicationException("El nombre es requerido.");
            if (Nombre.Length > 50)
                throw new ApplicationException("El nombre no debe superar los 50 caracteres.");
        }

        public void ValidarPrecio()
        {
            if (PrecioUnitario <= 0 || PrecioUnitario >= 10000000)
                throw new ApplicationException("Ingrese un precio válido.");
        }

        internal void ValidarCodigo()
        {
            if (Codigo.ToString().Length != 12)
                throw new ApplicationException("El UPC debe tener 12 caracteres");
        }

        internal void ValidarTipoArticulo()
        {
            if (TipoArticulo == null)
                throw new ApplicationException("El tipo de artículo es requerido");
        }

        internal void ValidarPlataforma()
        {
            if (Plataforma == null)
                throw new ApplicationException("La plataforma es requerida");
        }

        internal void ValidarFechaSalida()
        {
            if (FechaSalida.Year < 2000 || FechaSalida.Year > 2022)
                throw new ApplicationException("Ingrese una fecha válida");
        }

        public int GetDiferenciaDias()
        {
            var fechaActual = DateTime.Today;
            return (fechaActual - FechaSalida).Days;
        }

        public decimal GetMontoAlquilerTardio()
        {
            decimal monto = 0;
            if (EsVideojuego())
                monto = TarifaAlquiler.MontoDevolucionTardiaPorDia;
            return monto;
        }

        public decimal GetMontoAlquiler()
        {
            decimal monto = 0;
            if (EsVideojuego())
                monto = TarifaAlquiler.MontoAlquilerPorDia;
            return monto;
        }

        public bool EsVideojuego()
        {
            return TipoArticulo.Nombre.Equals("Videojuego");
        }
    }
}
