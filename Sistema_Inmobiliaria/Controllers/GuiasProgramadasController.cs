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
    public class GuiasProgramadasController : Controller
    {
        private Model_Sistema db = new Model_Sistema();

        // GET: GuiasProgramadas
        public async Task<ActionResult> Index()
        {
            var guias = await db.guias_programadas.Include(g => g.inmuebles).ToListAsync();
            return View(guias);
        }

        // POST: GuiasProgramadas/Guardar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Guardar([Bind(Include = "idguia,nombre,telefono,inmueble,correo,mensaje")] guias_programadas guia)
        {
            if (ModelState.IsValid)
            {
                if (guia.idguia == 0)
                {
                    db.guias_programadas.Add(guia);
                }
                else
                {
                    db.Entry(guia).State = EntityState.Modified;
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Inmuebles = new SelectList(db.inmuebles, "id", "nombre", guia.inmueble);
            return View("Crear", guia);
        }

        // POST: GuiasProgramadas/Eliminar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int id)
        {
            guias_programadas guia = await db.guias_programadas.FindAsync(id);
            if (guia != null)
            {
                db.guias_programadas.Remove(guia);
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