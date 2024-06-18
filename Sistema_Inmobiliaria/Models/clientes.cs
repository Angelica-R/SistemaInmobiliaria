namespace Sistema_Inmobiliaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientes()
        {
            citas = new HashSet<citas>();
        }

        [Key]
        public int codcliente { get; set; }

        [Required(ErrorMessage = "El campo DNI es obligatorio.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El DNI debe tener 8 caracteres.")]
        public string cliDni { get; set; }

        [Required(ErrorMessage = "El campo Nombres es obligatorio.")]
        [DisplayName("Nombres")]
        public string cliNombre { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Apellidos")]
        public string cliApellido { get; set; }

        [Required]
        [StringLength(12)]
        public string cliTelefono { get; set; }

        [Required]
        [StringLength(50)]
        public string cliEmail { get; set; }

        [Required]
        [StringLength(10)]
        public string cliClave { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<citas> citas { get; set; }
    }
}
