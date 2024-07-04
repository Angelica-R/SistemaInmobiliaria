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
    public class CategoriasController : Controller
    {
        private categoria objCategoria = new categoria();
        private Model_Sistema db = new Model_Sistema();

        public async Task<ActionResult> Index(int? id)
        {
            ViewBag.Categorias = await db.categoria.ToListAsync();
            ViewBag.Categoria = id == null ? new categoria() : await db.categoria.FindAsync(id);
            return View();
        }


        // POST: Categorias/Guardar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Guardar([Bind(Include = "idcategoria,descripcion")] categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (categoria.idcategoria == 0)
                {
                    db.categoria.Add(categoria);
                }
                else
                {
                    db.Entry(categoria).State = EntityState.Modified;
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Categorias = await db.categoria.ToListAsync();
            ViewBag.Categoria = categoria;
            return View("Index");
        }

        // POST: Categorias/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int id)
        {
            var inmueblesRelacionados = db.inmuebles.Where(i => i.idcategoria == id).ToList();
            foreach (var inmueble in inmueblesRelacionados)
            {
                db.inmuebles.Remove(inmueble);
            }

            var categoria = await db.categoria.FindAsync(id);
            if (categoria != null)
            {
                db.categoria.Remove(categoria);
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