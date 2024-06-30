namespace Sistema_Inmobiliaria.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class citas
    {
        [Key]
        public int codcita { get; set; }

       
        public int codcliente { get; set; }

        
        public int codlocal { get; set; }

        
        [Column(TypeName = "date")]
        public DateTime fecha { get; set; }

        
        public TimeSpan hora { get; set; }

        public virtual clientes clientes { get; set; }

        public virtual locales locales { get; set; }
    }
}

