using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema_Inmobiliaria.Models
{
    public class DniResponse
    {
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string codigoVerificacion { get; set; }
    }
}