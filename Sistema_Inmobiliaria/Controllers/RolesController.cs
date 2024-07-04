using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Sistema_Inmobiliaria.Models;

namespace Sistema_Inmobiliaria.Controllers
{

    public class RolesController : Controller
    {
        private roles objRoles = new roles();
        private Model_Sistema db = new Model_Sistema();

        public async Task<ActionResult> Index(int? id)
        {
            ViewBag.Roles = await db.roles.ToListAsync();
            ViewBag.Rol = id == null ? new roles() : await db.roles.FindAsync(id);
            return View();
        }

        // POST: Roles/Guardar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Guardar([Bind(Include = "codrol,descripcion")] roles rol)
        {
            if (ModelState.IsValid)
            {
                if (rol.codrol == 0)
                {
                    db.roles.Add(rol);
                }
                else
                {
                    db.Entry(rol).State = EntityState.Modified;
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Roles = await db.roles.ToListAsync();
            ViewBag.Rol = rol;
            return View("Index");
        }

        // POST: Roles/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int id)
        {
            roles rol = await db.roles.FindAsync(id);
            if (rol != null)
            {
                db.roles.Remove(rol);
                await db.SaveChangesAsync();
            }
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