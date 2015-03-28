using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CIneKinalMVC.Models;
using MVCineKinal.Models;

namespace MVCineKinal.Controllers
{
    public class ComplejoSalaController : Controller
    {
        private CineDBContext db = new CineDBContext();

        // GET: /ComplejoSala/
        public ActionResult Index()
        {
            var complejosalas = db.ComplejoSalas.Include(c => c.Complejo).Include(c => c.Sala);
            return View(complejosalas.ToList());
        }

        // GET: /ComplejoSala/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplejoSala complejosala = db.ComplejoSalas.Find(id);
            if (complejosala == null)
            {
                return HttpNotFound();
            }
            return View(complejosala);
        }

        // GET: /ComplejoSala/Create
        public ActionResult Create()
        {
            ViewBag.ComplejoID = new SelectList(db.Complejoes, "Id", "Nombre");
            ViewBag.SalaID = new SelectList(db.Salas, "ID", "Nombre");
            return View();
        }

        // POST: /ComplejoSala/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,ComplejoID,SalaID")] ComplejoSala complejosala)
        {
            if (ModelState.IsValid)
            {
                db.ComplejoSalas.Add(complejosala);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ComplejoID = new SelectList(db.Complejoes, "Id", "Nombre", complejosala.ComplejoID);
            ViewBag.SalaID = new SelectList(db.Salas, "ID", "Nombre", complejosala.SalaID);
            return View(complejosala);
        }

        // GET: /ComplejoSala/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplejoSala complejosala = db.ComplejoSalas.Find(id);
            if (complejosala == null)
            {
                return HttpNotFound();
            }
            ViewBag.ComplejoID = new SelectList(db.Complejoes, "Id", "Nombre", complejosala.ComplejoID);
            ViewBag.SalaID = new SelectList(db.Salas, "ID", "Nombre", complejosala.SalaID);
            return View(complejosala);
        }

        // POST: /ComplejoSala/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,ComplejoID,SalaID")] ComplejoSala complejosala)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complejosala).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ComplejoID = new SelectList(db.Complejoes, "Id", "Nombre", complejosala.ComplejoID);
            ViewBag.SalaID = new SelectList(db.Salas, "ID", "Nombre", complejosala.SalaID);
            return View(complejosala);
        }

        // GET: /ComplejoSala/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ComplejoSala complejosala = db.ComplejoSalas.Find(id);
            if (complejosala == null)
            {
                return HttpNotFound();
            }
            return View(complejosala);
        }

        // POST: /ComplejoSala/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ComplejoSala complejosala = db.ComplejoSalas.Find(id);
            db.ComplejoSalas.Remove(complejosala);
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
