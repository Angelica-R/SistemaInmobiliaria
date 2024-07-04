using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Sistema_Inmobiliaria.Models;

namespace Sistema_Inmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {
        private inmuebles objInmueble = new inmuebles();

        private Model_Sistema db = new Model_Sistema();

        // GET: Inmuebles
        public async Task<ActionResult> Index(int? id)
        {
            ViewBag.Inmuebles = await db.inmuebles.Include(i => i.categoria).ToListAsync();
            ViewBag.Categorias = await db.categoria.ToListAsync();
            ViewBag.Inmueble = id == null ? new inmuebles() : await db.inmuebles.FindAsync(id);
            return View();
        }

        // POST: Inmuebles/Guardar
        public async Task<ActionResult> Guardar([Bind(Include = "idinmueble,titulo,descripcion,precio,imagen,idcategoria,ruta")] inmuebles inmueble, HttpPostedFileBase Foto)
        {
            if (ModelState.IsValid)
            {
                if (Foto != null && Foto.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(Foto.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/Inmuebles"), fileName);
                    Foto.SaveAs(path);
                    inmueble.imagen = "/Images/Inmuebles/" + fileName;
                }

                if (inmueble.idinmueble == 0)
                {
                    db.inmuebles.Add(inmueble);
                }
                else
                {
                    var inmuebleExistente = await db.inmuebles.FindAsync(inmueble.idinmueble);
                    if (inmuebleExistente != null)
                    {
                        // Actualizar los datos del inmueble existente
                        inmuebleExistente.titulo = inmueble.titulo;
                        inmuebleExistente.descripcion = inmueble.descripcion;
                        inmuebleExistente.precio = inmueble.precio;
                        inmuebleExistente.ruta = inmueble.ruta;
                        inmuebleExistente.idcategoria = inmueble.idcategoria;

                        if (Foto != null && Foto.ContentLength > 0)
                        {
                            inmuebleExistente.imagen = inmueble.imagen;
                        }
                    }
                }

                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Inmuebles = await db.inmuebles.Include(i => i.categoria).ToListAsync();
            ViewBag.Categorias = await db.categoria.ToListAsync();
            ViewBag.Inmueble = inmueble;
            return View("Index");
        }



        // POST: Inmuebles/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int id)
        {
            var inmueble = await db.inmuebles.FindAsync(id);
            if (inmueble != null)
            {
                db.inmuebles.Remove(inmueble);
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