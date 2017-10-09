using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba1.Models;

namespace prueba1.Controllers
{
    public class TelefonoController : Controller
    {
        private ModelContext db = new ModelContext();

        //
        // GET: /Telefono/

        public ActionResult Index()
        {
            return View(db.telefonos.ToList());
        }

        //
        // GET: /Telefono/Details/5

        public ActionResult Details(int id = 0)
        {
            Telefono telefono = db.telefonos.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        //
        // GET: /Telefono/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Telefono/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.telefonos.Add(telefono);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(telefono);
        }

        //
        // GET: /Telefono/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Telefono telefono = db.telefonos.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        //
        // POST: /Telefono/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Telefono telefono)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefono).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(telefono);
        }

        //
        // GET: /Telefono/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Telefono telefono = db.telefonos.Find(id);
            if (telefono == null)
            {
                return HttpNotFound();
            }
            return View(telefono);
        }

        //
        // POST: /Telefono/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telefono telefono = db.telefonos.Find(id);
            db.telefonos.Remove(telefono);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}