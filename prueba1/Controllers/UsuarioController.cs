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
    public class UsuarioController : Controller
    {
        private ModelContext db = new ModelContext();
        private Usuario user = null; // Aqui se guarda la seleccion del usuario a modificar, borrar, etc.

        // Consultar usuarios ------------------------------------------------------------------------------------------

        public ActionResult Details()
        {
            return View(db.usuarios.ToList());
        }

        // Crear usuario --------------------------------------------------------------------------------------------------

        public ActionResult Create()
        {
            return View();
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.activo = true;
                db.usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(usuario);
        }

        // Modificar usuario ------------------------------------------------------------------------------------------------
        
        // GET:

        public ActionResult B_Edit()
        {
            return View("Edit");
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

        // Buscar usuario ------------------------------------------------------------------------------------------------
        // GET: 

        public ActionResult Find()
        {
            return View();
        }

        public ActionResult MostrarUsuario(string mail)
        {
            user = db.usuarios.Find(mail);
            ViewBag.Nombre = user.Nombre;
            ViewBag.Apellido = user.Apellido;
            ViewBag.Mail = user.mail;
            return View("PostFind");
        }

        // Borrar usuario ------------------------------------------------------------------------------------------------
        // GET: 

        public ActionResult Delete()
        {
            ViewBag.Nombre = user.Nombre;
            ViewBag.Apellido = user.Apellido;
            ViewBag.Mail = user.mail;
            return View("Delete");
        }

        // POST: 

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed()
        {
            db.usuarios.Remove(user);
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