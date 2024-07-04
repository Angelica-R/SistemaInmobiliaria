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
    public class LocalesController : Controller
    {
        private Model_Sistema db = new Model_Sistema();

        // GET: Locales
        public async Task<ActionResult> Index(int? id)
        {
            ViewBag.Locales = await db.locales.ToListAsync();
            ViewBag.Local = id == null ? new locales() : await db.locales.FindAsync(id);
            return View();
        }

        // POST: Locales/Guardar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Guardar([Bind(Include = "codlocal,localNombre,localDireccion")] locales local)
        {
            if (ModelState.IsValid)
            {
                if (local.codlocal == 0)
                {
                    db.locales.Add(local);
                }
                else
                {
                    db.Entry(local).State = EntityState.Modified;
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Locales = await db.locales.ToListAsync();
            ViewBag.Local = local;
            return View("Index");
        }

        // POST: Locales/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int id)
        {
            var citasRelacionadas = db.citas.Where(c => c.codlocal == id).ToList();
            foreach (var cita in citasRelacionadas)
            {
                db.citas.Remove(cita);
            }

            var local = await db.locales.FindAsync(id);
            if (local != null)
            {
                db.locales.Remove(local);
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