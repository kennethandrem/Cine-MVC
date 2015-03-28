using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CineMVC.Models;
using MVCineKinal.Models;

namespace MVCineKinal.Controllers
{
    public class EstrenoController : Controller
    {
        private CineDBContext db = new CineDBContext();

        // GET: /Estreno/
        public ActionResult Index()
        {
            var estrenoes = db.Estrenoes.Include(e => e.Complejo).Include(e => e.Pelicula);
            return View(estrenoes.ToList());
        }

        // GET: /Estreno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estreno estreno = db.Estrenoes.Find(id);
            if (estreno == null)
            {
                return HttpNotFound();
            }
            return View(estreno);
        }

        // GET: /Estreno/Create
        public ActionResult Create()
        {
            ViewBag.ComplejoId = new SelectList(db.Complejoes, "Id", "Nombre");
            ViewBag.PeliculaID = new SelectList(db.Pelicula, "Id", "Nombre");
            return View();
        }

        // POST: /Estreno/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Fecha,PeliculaID,ComplejoId")] Estreno estreno)
        {
            if (ModelState.IsValid)
            {
                db.Estrenoes.Add(estreno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComplejoId = new SelectList(db.Complejoes, "Id", "Nombre", estreno.ComplejoId);
            ViewBag.PeliculaID = new SelectList(db.Pelicula, "Id", "Nombre", estreno.PeliculaID);
            return View(estreno);
        }

        // GET: /Estreno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estreno estreno = db.Estrenoes.Find(id);
            if (estreno == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplejoId = new SelectList(db.Complejoes, "Id", "Nombre", estreno.ComplejoId);
            ViewBag.PeliculaID = new SelectList(db.Pelicula, "Id", "Nombre", estreno.PeliculaID);
            return View(estreno);
        }

        // POST: /Estreno/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Fecha,PeliculaID,ComplejoId")] Estreno estreno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estreno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComplejoId = new SelectList(db.Complejoes, "Id", "Nombre", estreno.ComplejoId);
            ViewBag.PeliculaID = new SelectList(db.Pelicula, "Id", "Nombre", estreno.PeliculaID);
            return View(estreno);
        }

        // GET: /Estreno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Estreno estreno = db.Estrenoes.Find(id);
            if (estreno == null)
            {
                return HttpNotFound();
            }
            return View(estreno);
        }

        // POST: /Estreno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Estreno estreno = db.Estrenoes.Find(id);
            db.Estrenoes.Remove(estreno);
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
