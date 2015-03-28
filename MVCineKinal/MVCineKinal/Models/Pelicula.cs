using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCine.Models
{
    public class Pelicula
    {
        public int Id {get;set;}
        public string Nombre {get; set;}
        public string Descripcion {get; set;}
        public string Tryler {get; set;}
        public string Imagen {get; set;}


        public int CategoriaID {get; set;}
        public Categoria Categoria{get; set;}

        public int ClasificacionID{get; set;}
        public Clasificacion Clasificacion {get; set;}
    }
}