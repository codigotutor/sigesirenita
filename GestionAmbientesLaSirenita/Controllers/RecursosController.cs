using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionAmbientesLaSirenita.Models;

namespace GestionAmbientesLaSirenita.Controllers
{
    public class RecursosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Recursos
        public ActionResult Index()
        {
            return View(db.Recursos.ToList());
        }

        // GET: Recursos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = db.Recursos.Find(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // GET: Recursos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recursos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Valor,Minimo,Maximo")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                db.Recursos.Add(recurso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(recurso);
        }

        // GET: Recursos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = db.Recursos.Find(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // POST: Recursos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Valor,Minimo,Maximo")] Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recurso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recurso);
        }

        // GET: Recursos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recurso recurso = db.Recursos.Find(id);
            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        // POST: Recursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recurso recurso = db.Recursos.Find(id);
            db.Recursos.Remove(recurso);
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
