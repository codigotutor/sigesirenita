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
    public class MovimientosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Movimientos
        public ActionResult Index()
        {
            var movimientos = db.Movimientos.Include(m => m.Ambiente).Include(m => m.Recurso);
            return View(movimientos.ToList());
        }

        // GET: Movimientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimiento movimiento = db.Movimientos.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        // GET: Movimientos/Create
        public ActionResult Create()
        {
            ViewBag.AmbienteId = new SelectList(db.Ambientes, "Id", "Nombre");
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Nombre");
            return View();
        }

        // POST: Movimientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,Cantidad,Fecha,RecursoId,AmbienteId")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Movimientos.Add(movimiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AmbienteId = new SelectList(db.Ambientes, "Id", "Nombre", movimiento.AmbienteId);
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Nombre", movimiento.RecursoId);
            return View(movimiento);
        }

        // GET: Movimientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimiento movimiento = db.Movimientos.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.AmbienteId = new SelectList(db.Ambientes, "Id", "Nombre", movimiento.AmbienteId);
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Nombre", movimiento.RecursoId);
            return View(movimiento);
        }

        // POST: Movimientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Cantidad,Fecha,RecursoId,AmbienteId")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movimiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AmbienteId = new SelectList(db.Ambientes, "Id", "Nombre", movimiento.AmbienteId);
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Nombre", movimiento.RecursoId);
            return View(movimiento);
        }

        // GET: Movimientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movimiento movimiento = db.Movimientos.Find(id);
            if (movimiento == null)
            {
                return HttpNotFound();
            }
            return View(movimiento);
        }

        // POST: Movimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movimiento movimiento = db.Movimientos.Find(id);
            db.Movimientos.Remove(movimiento);
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
