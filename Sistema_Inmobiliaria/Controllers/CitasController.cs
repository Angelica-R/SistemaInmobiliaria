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
    public class CitasController : Controller
    {
        private Model_Sistema db = new Model_Sistema();

        // GET: Citas
        public async Task<ActionResult> Index(/*int? id*/)
        {
            var citas = await db.citas.Include(c => c.clientes).Include(c => c.locales).ToListAsync();
            return View(citas);

            //ViewBag.Clientes = await db.clientes.ToListAsync();
            //ViewBag.Locales = await db.locales.ToListAsync();
            //ViewBag.Citas = await db.citas.Include(c => c.clientes).Include(c => c.locales).ToListAsync();
            //ViewBag.Cita = id == null ? new citas() : await db.citas.FindAsync(id);
            //return View();
        }

        // POST: Citas/Guardar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Guardar([Bind(Include = "codcita,codcliente,codlocal,fecha,hora")] citas cita)
        {
            if (ModelState.IsValid)
            {
                if (cita.codcita == 0)
                {
                    db.citas.Add(cita);
                }
                else
                {
                    db.Entry(cita).State = EntityState.Modified;
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Clientes = await db.clientes.ToListAsync();
            ViewBag.Locales = await db.locales.ToListAsync();
            ViewBag.Citas = await db.citas.Include(c => c.clientes).Include(c => c.locales).ToListAsync();
            ViewBag.Cita = cita;
            return View("Index");
        }


        // POST: Citas/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int id)
        {
            citas cita = await db.citas.FindAsync(id);
            if (cita != null)
            {
                db.citas.Remove(cita);
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