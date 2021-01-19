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
    public class EmpleadoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index(EmpleadoViewModel EVM)
        {
            var empleados = db.Empleados.Include(e => e.Departamentos)
                .Include(e => e.Tipos).Include(e => e.Nominas).ToList();
            var departamentos = db.Departamentos.ToList();
            var tipos = db.Tipos.ToList();
            var nominas = db.Nominas.ToList();

            EVM.Empleados = empleados;
            EVM.Departamentos = departamentos;
            EVM.Tipos = tipos;
            EVM.Nominas = nominas;

            return View(EVM);
        }
        public ActionResult Detalles(int? id)
        {
            var empleado = db.Empleados.Include(e => e.Tipo)
                .Include(e => e.Departamento).Include(e => e.Nomina).FirstOrDefault(p => p.ID == id);
            if (empleado == null)
            {
                return HttpNotFound();
            }

            return View(empleado);
        }

        [HttpPost]
        public ActionResult Crear(Empleado empleado)
        {          
            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult Editar(Empleado empleado)
        {           
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("Borrar")]
        public ActionResult Borrado(IEnumerable<int> ID)
        {
            var empleados = db.Empleados.Include(e => e.Departamentos)
                .Include(e => e.Tipos).Include(e => e.Nominas).ToList();

            foreach (var item in empleados)
            {
                foreach (var id in ID)
                {
                    if (id == item.ID)
                    {
                        var empleado = db.Empleados.Include(e => e.Departamentos)
                .Include(e => e.Tipos).Include(e => e.Nominas).FirstOrDefault(p => p.ID == id);
                        db.Empleados.Remove(empleado);
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