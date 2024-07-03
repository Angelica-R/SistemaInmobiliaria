using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Inmobiliaria.Models
{
    public class Contacto
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Asunto { get; set; }
        public string Mensaje { get; set; }
    }
}