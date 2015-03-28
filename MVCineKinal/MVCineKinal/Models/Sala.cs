using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CIneKinalMVC.Models
{
    public class Sala
    {
        public int ID { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
