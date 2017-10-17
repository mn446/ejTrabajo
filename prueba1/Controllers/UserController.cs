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
            return View();
        }

        public JsonResult GetUsers()
        {
            List<Usuario> usersList = db.usuarios.ToList();
            return Json(usersList, JsonRequestBehavior.AllowGet);
        }
        

        // Datos completos de un usuario ---------------------------------------------------------------

        //public ActionResult Details(string id = null)
        //{
        //    Usuario usuario = db.usuarios.Find(id);
        //    if (usuario == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(usuario);
        //}


        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUserByMail(string mail)
        {
            Usuario user = db.usuarios.Find(mail);
            return Json(user, JsonRequestBehavior.AllowGet);
        }

        // Dar de alta un usuario -----------------------------------------------------------------------

        public ActionResult Create()
        {
            //Tuple<Usuario, Telefono> tuple = new Tuple<Usuario, Telefono>(new Usuario(), new Telefono());
            return View();
        }

        // POST:

        //[HttpPost, ActionName("Create")]
        //[ValidateAntiForgeryToken]
        //public ActionResult PostCreate(Tuple<Usuario, Telefono> tupla)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        tupla.Item1.activo = true;
        //        //List<Telefono> tels = new List<Telefono>();
        //        //tels.Add(tupla.Item2);
        //        //tupla.Item1.telefonos = tels;

        //        db.usuarios.Add(tupla.Item1);
        //        //db.telefonos.Add(tupla.Item2);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View();
        //}

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult PostCreate(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.activo = true;
                //List<Telefono> tels = new List<Telefono>();
                //tels.Add(tupla.Item2);
                //tupla.Item1.telefonos = tels;

                db.usuarios.Add(usuario);
                //db.telefonos.Add(tupla.Item2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
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