using System.Data.Entity;
using MVCCine.Models;

namespace MVCineKinal.Models
{
    public class CineDBContext : DbContext
    {
        public DbSet<Pelicula> Pelicula { get; set; }

        public System.Data.Entity.DbSet<MVCCine.Models.Clasificacion> Clasificacions { get; set; }

        public System.Data.Entity.DbSet<MVCCine.Models.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<MVCCine.Models.Complejo> Complejoes { get; set; }

        public System.Data.Entity.DbSet<CIneKinalMVC.Models.Sala> Salas { get; set; }

        public System.Data.Entity.DbSet<CineMVC.Models.Estreno> Estrenoes { get; set; }

        public System.Data.Entity.DbSet<CIneKinalMVC.Models.ComplejoSala> ComplejoSalas { get; set; }
    }
}