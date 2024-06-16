namespace Sistema_Inmobiliaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class inmuebles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inmuebles()
        {
            guias_programadas = new HashSet<guias_programadas>();
        }

        [Key]
        public int idinmueble { get; set; }

        [Required]
        [StringLength(50)]
        public string titulo { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string descripcion { get; set; }

        [Required]
        [StringLength(20)]
        public string precio { get; set; }

        [Required]
        [StringLength(100)]
        public string imagen { get; set; }

        public int idcategoria { get; set; }

        [Required]
        [StringLength(200)]
        public string ruta { get; set; }

        public virtual categoria categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<guias_programadas> guias_programadas { get; set; }
    }
}
