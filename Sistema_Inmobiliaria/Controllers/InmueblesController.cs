using Sistema_Inmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Inmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {
        private Model_Sistema db = new Model_Sistema();

        public ActionResult Casas()
        {
            var casas = db.inmuebles.Where(i => i.categoria.descripcion == "Casa").ToList();
            return View(casas);
        }
        public ActionResult Departamentos()
        {
            var departamentos = db.inmuebles.Where(i => i.categoria.descripcion == "Departamento").ToList();
            return View(departamentos);
        }
        public ActionResult Terrenos()
        {
            var terrenos = db.inmuebles.Where(i => i.categoria.descripcion == "Terreno").ToList();
            return View(terrenos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReservarGuias(string nombre, string telefono, string correo, string mensaje, int idinmueble)
        {
            if (ModelState.IsValid)
            {
                var nuevaGuia = new guias_programadas
                {
                    nombre = nombre,
                    telefono = telefono,
                    correo = correo,
                    mensaje = mensaje,
                    inmueble = idinmueble
                };

                db.guias_programadas.Add(nuevaGuia);
                db.SaveChanges();

                TempData["MensajeCita"] = "¡Cita reservada exitosamente!";
                return RedirectToAction("Detalles", new { id = idinmueble });
            }

            var inmueble = db.inmuebles.Find(idinmueble);
            if (inmueble == null)
            {
                return HttpNotFound();
            }
            return View("Detalles", inmueble);
        }
        public ActionResult Detalles(int id)
        {
            var inmueble = db.inmuebles.Find(id);
            if (inmueble == null)
            {
                return HttpNotFound();
            }
            return View(inmueble);
        }

        public ActionResult Visualizar(int id)
        {
            var inmueble = db.inmuebles.Find(id);
            if (inmueble == null)
            {
                return HttpNotFound();
            }
            return View(inmueble);
        }
    }
}