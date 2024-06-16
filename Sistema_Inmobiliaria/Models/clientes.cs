namespace Sistema_Inmobiliaria.Models
{
    using System;
    using System.Collections.Generic;
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

        [Required]
        [StringLength(8)]
        public string cliDni { get; set; }

        [Required]
        [StringLength(50)]
        public string cliNombre { get; set; }

        [Required]
        [StringLength(50)]
        public string cliApellido { get; set; }

        [Required]
        [StringLength(15)]
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
