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
    public class NominaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Nominas.ToList());
        }

        public ActionResult Detalles(int? id)
        {
            var nomina = db.Nominas.Find(id);

            if (nomina == null)
            {
                return HttpNotFound();
            }

            return View(nomina);
        }

        [HttpPost]
        public ActionResult Crear(Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Nominas.Add(nomina);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nomina).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("Borrar")]
        public ActionResult Borrado(IEnumerable<int> ID)
        {
            var nominas = db.Nominas.ToList();

            foreach (var item in nominas)
            {
                foreach (var id in ID)
                {
                    if (id == item.ID)
                    {
                        var nomina = db.Nominas.FirstOrDefault(p => p.ID == id);
                        db.Nominas.Remove(nomina);
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