using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCCine.Models;
using MVCineKinal.Models;

namespace MVCineKinal.Controllers
{
    public class PeliculaController : Controller
    {
        private CineDBContext db = new CineDBContext();

        // GET: /Pelicula/
        public ActionResult Index()
        {
            var pelicula = db.Pelicula.Include(p => p.Categoria).Include(p => p.Clasificacion);
            return View(pelicula.ToList());
        }

        // GET: /Pelicula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Pelicula.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // GET: /Pelicula/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "Id", "Nombre");
            ViewBag.ClasificacionID = new SelectList(db.Clasificacions, "Id", "Nombre");
            return View();
        }

        // POST: /Pelicula/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombre,Descripcion,Tryler,Imagen,CategoriaID,ClasificacionID")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Pelicula.Add(pelicula);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "Id", "Nombre", pelicula.CategoriaID);
            ViewBag.ClasificacionID = new SelectList(db.Clasificacions, "Id", "Nombre", pelicula.ClasificacionID);
            return View(pelicula);
        }

        // GET: /Pelicula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Pelicula.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "Id", "Nombre", pelicula.CategoriaID);
            ViewBag.ClasificacionID = new SelectList(db.Clasificacions, "Id", "Nombre", pelicula.ClasificacionID);
            return View(pelicula);
        }

        // POST: /Pelicula/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombre,Descripcion,Tryler,Imagen,CategoriaID,ClasificacionID")] Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelicula).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "Id", "Nombre", pelicula.CategoriaID);
            ViewBag.ClasificacionID = new SelectList(db.Clasificacions, "Id", "Nombre", pelicula.ClasificacionID);
            return View(pelicula);
        }

        // GET: /Pelicula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelicula pelicula = db.Pelicula.Find(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }
            return View(pelicula);
        }

        // POST: /Pelicula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelicula pelicula = db.Pelicula.Find(id);
            db.Pelicula.Remove(pelicula);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
