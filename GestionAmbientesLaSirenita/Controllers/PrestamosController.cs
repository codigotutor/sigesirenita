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
    public class PrestamosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Prestamos
        public ActionResult Index()
        {
            var prestamoes = db.Prestamoes.Include(p => p.Ambiente).Include(p => p.Recurso).Include(p => p.Usuario);
            return View(prestamoes.ToList());
        }

        // GET: Prestamos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamoes.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // GET: Prestamos/Create
        public ActionResult Create()
        {
            ViewBag.AmbienteId = new SelectList(db.Ambientes, "Id", "Nombre");
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Nombre");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre");
            return View();
        }

        // POST: Prestamos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tipo,Fecha,RecursoId,AmbienteId,UsuarioId")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Prestamoes.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AmbienteId = new SelectList(db.Ambientes, "Id", "Nombre", prestamo.AmbienteId);
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Nombre", prestamo.RecursoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", prestamo.UsuarioId);
            return View(prestamo);
        }

        // GET: Prestamos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamoes.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.AmbienteId = new SelectList(db.Ambientes, "Id", "Nombre", prestamo.AmbienteId);
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Nombre", prestamo.RecursoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", prestamo.UsuarioId);
            return View(prestamo);
        }

        // POST: Prestamos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tipo,Fecha,RecursoId,AmbienteId,UsuarioId")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AmbienteId = new SelectList(db.Ambientes, "Id", "Nombre", prestamo.AmbienteId);
            ViewBag.RecursoId = new SelectList(db.Recursos, "Id", "Nombre", prestamo.RecursoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nombre", prestamo.UsuarioId);
            return View(prestamo);
        }

        // GET: Prestamos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamoes.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: Prestamos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamo prestamo = db.Prestamoes.Find(id);
            db.Prestamoes.Remove(prestamo);
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
