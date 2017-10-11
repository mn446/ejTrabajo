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
    public class UserController : Controller
    {
        private ModelContext db = new ModelContext();

        // Listado de usuarios ------------------------------------------------------------------------

        public ActionResult Index()
        {
            return View(db.usuarios.ToList());
        }

        // Datos completos de un usuario ---------------------------------------------------------------

        public ActionResult Details(string id = null)
        {
            Usuario usuario = db.usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // Dar de alta un usuario -----------------------------------------------------------------------

        public ActionResult Create()
        {
            return View();
        }

        // POST:

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult PostCreate(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.activo = true;
                db.usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // Modificar datos de usuario -----------------------------------------------------------------------

        public ActionResult Edit(string id = null)
        {
            Usuario usuario = db.usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST:

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // Baja Logica ------------------------------------------------------------------------------------------

        public ActionResult LogicDelete(string id = null)
        {
            Usuario usuario = db.usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /User/Delete

        [HttpPost, ActionName("LogicDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult LocigDeleteConfirmed(string id)
        {
            Usuario usuario = db.usuarios.Find(id);
            usuario.activo = false; // baja lógica
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // Baja Fisica ------------------------------------------------------------------------------------------

        public ActionResult Delete(string id = null)
        {
            Usuario usuario = db.usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /User/Delete

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Usuario usuario = db.usuarios.Find(id);
            db.usuarios.Remove(usuario);
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