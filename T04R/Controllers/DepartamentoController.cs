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
    public class DepartamentoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Departamentos.ToList());
        }

        public ActionResult Detalles(int? id)
        {
            var depto = db.Departamentos.Find(id);

            if (depto == null)
            {
                return HttpNotFound();
            }

            return View(depto);
        }

        [HttpPost]
        public ActionResult Crear(Departamento depto)
        {
            if (ModelState.IsValid)
            {
                db.Departamentos.Add(depto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Editar(Departamento depto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(depto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("Borrar")]
        public ActionResult Borrado(IEnumerable<int> ID)
        {
            var deptos = db.Departamentos.ToList();

            foreach (var item in deptos)
            {
                foreach (var id in ID)
                {
                    if (id == item.ID)
                    {
                        var depto = db.Departamentos.FirstOrDefault(p => p.ID == id);
                        db.Departamentos.Remove(depto);
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