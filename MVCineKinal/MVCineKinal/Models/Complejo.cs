using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCCine.Models
{
    public class Complejo
    {
        public int Id {get;set;}
        [Required]
        public string Nombre {get;set;}
        public string Direccion {get;set;}
        public int Telefono {get;set;}
        public string Longitud {get;set;}
        public string Latitud {get; set;}
        public string Imagen {get; set;}
    }
}