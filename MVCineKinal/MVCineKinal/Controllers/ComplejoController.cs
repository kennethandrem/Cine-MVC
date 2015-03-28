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
    public class ComplejoController : Controller
    {
        private CineDBContext db = new CineDBContext();

        // GET: /Complejo/
        public ActionResult Index()
        {
            return View(db.Complejoes.ToList());
        }

        // GET: /Complejo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complejo complejo = db.Complejoes.Find(id);
            if (complejo == null)
            {
                return HttpNotFound();
            }
            return View(complejo);
        }

        // GET: /Complejo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Complejo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,Nombre,Direccion,Telefono,Longitud,Latitud,Imagen")] Complejo complejo)
        {
            if (ModelState.IsValid)
            {
                db.Complejoes.Add(complejo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complejo);
        }

        // GET: /Complejo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complejo complejo = db.Complejoes.Find(id);
            if (complejo == null)
            {
                return HttpNotFound();
            }
            return View(complejo);
        }

        // POST: /Complejo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,Nombre,Direccion,Telefono,Longitud,Latitud,Imagen")] Complejo complejo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complejo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complejo);
        }

        // GET: /Complejo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complejo complejo = db.Complejoes.Find(id);
            if (complejo == null)
            {
                return HttpNotFound();
            }
            return View(complejo);
        }

        // POST: /Complejo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complejo complejo = db.Complejoes.Find(id);
            db.Complejoes.Remove(complejo);
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
