using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Net;
using T04R.Models;

namespace T04R.Controllers
{
    public class TipoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Tipos.ToList());
        }

        public ActionResult Detalles(int? id)
        {
            var tipo = db.Tipos.Find(id);

            if (tipo == null)
            {
                return HttpNotFound();
            }

            return View(tipo);
        }

        [HttpPost]
        public ActionResult Crear(Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Tipos.Add(tipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(Tipo tipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("Borrar")]
        public ActionResult Borrado(IEnumerable<int> ID)
        {
            var tipos = db.Tipos.ToList();

            foreach (var item in tipos)
            {
                foreach (var id in ID)
                {
                    if (id == item.ID)
                    {
                        var tipo = db.Tipos.FirstOrDefault(p => p.ID == id);
                        db.Tipos.Remove(tipo);
                    }
                }
            }

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