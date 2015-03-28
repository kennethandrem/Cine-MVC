using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCCine.Models
{
    public class Clasificacion
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descricion { get; set; }
    }
}