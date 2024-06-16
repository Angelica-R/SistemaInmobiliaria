namespace Sistema_Inmobiliaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class guias_programadas
    {
        [Key]
        public int idguia { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        [Required]
        [StringLength(15)]
        public string telefono { get; set; }

        public int inmueble { get; set; }

        [Required]
        [StringLength(50)]
        public string correo { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string mensaje { get; set; }

        public virtual inmuebles inmuebles { get; set; }
    }
}
