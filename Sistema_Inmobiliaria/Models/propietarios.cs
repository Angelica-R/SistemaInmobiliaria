namespace Sistema_Inmobiliaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class propietarios
    {
        [Key]
        public int codpropietario { get; set; }

        [Required]
        [StringLength(50)]
        public string propnombre { get; set; }

        [Required]
        [StringLength(50)]
        public string propapellido { get; set; }

        [Required]
        [StringLength(8)]
        public string propdni { get; set; }

        [Required]
        [StringLength(15)]
        public string proptelefono { get; set; }

        [Required]
        [StringLength(50)]
        public string propemail { get; set; }
    }
}
