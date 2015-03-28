using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MVCCine.Models;

namespace CIneKinalMVC.Models
{
    public class ComplejoSala
    {
        public int Id { get; set; }

        public int ComplejoID{get; set;}
        public Complejo Complejo { get; set; }

        public int SalaID { get; set; }
        public Sala Sala { get; set; }
    }
}
