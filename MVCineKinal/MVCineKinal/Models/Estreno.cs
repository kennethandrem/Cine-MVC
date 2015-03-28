using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MVCCine.Models;

namespace CineMVC.Models
{
    public class Estreno
    {
        public int Id { get; set; }
        [Required]
        public DateTime Fecha { get; set; }

        public int PeliculaID { get; set; }
        public Pelicula Pelicula { get; set; }

        public int ComplejoId { get; set; }
        public Complejo Complejo { get; set; }
    }
}
