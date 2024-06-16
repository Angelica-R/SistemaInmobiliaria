namespace Sistema_Inmobiliaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class usuarios
    {
        [Key]
        public int codusuario { get; set; }

        [Required]
        [StringLength(8)]
        public string dni { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Required]
        [StringLength(30)]
        public string apellido { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(10)]
        public string clave { get; set; }

        [Required]
        [StringLength(50)]
        public string direccion { get; set; }

        [Required]
        [StringLength(15)]
        public string telefono { get; set; }

        [StringLength(50)]
        public string foto { get; set; }

        public int codrol { get; set; }

        public virtual roles roles { get; set; }
    }
}
