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
    public class PropietariosController : Controller
    {
        private Model_Sistema db = new Model_Sistema();
        private ReniecService reniecService = new ReniecService();

        // GET: Propietarios
        public async Task<ActionResult> Index(string nombre = null, int id = 0)
        {
            ViewBag.Propietarios = string.IsNullOrEmpty(nombre)
                ? await db.propietarios.ToListAsync()
                : await db.propietarios.Where(p => p.propnombre.Contains(nombre)).ToListAsync();
            ViewBag.Propietario = id == 0 ? new propietarios() : await db.propietarios.FindAsync(id);
            return View();
        }
        // GET: ConsultarDni
        [HttpGet]
        public async Task<JsonResult> ConsultarDni(string dni)
        {
            var datosReniec = await reniecService.ConsultarDniAsync(dni);
            if (datosReniec != null)
            {
                return Json(new { success = true, nombre = datosReniec.nombres, apellido = datosReniec.apellidoPaterno + " " + datosReniec.apellidoMaterno }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "DNI no encontrado" }, JsonRequestBehavior.AllowGet);
            }
        }
        // POST: Propietarios/Guardar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Guardar([Bind(Include = "codpropietario,propdni,propnombre,propapellido,proptelefono,propemail")] propietarios propietario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Verificar si el propietario ya existe por DNI
                    var existingPropietario = await db.propietarios.FirstOrDefaultAsync(p => p.propdni == propietario.propdni);
                    if (existingPropietario != null && existingPropietario.codpropietario != propietario.codpropietario)
                    {
                        ViewBag.ErrorMessage = "Este propietario ya ha sido agregado.";
                        ViewBag.Propietarios = await db.propietarios.ToListAsync();
                        ViewBag.Propietario = propietario;
                        return View("Index");
                    }

                    if (propietario.codpropietario == 0)
                    {
                        db.propietarios.Add(propietario);
                    }
                    else
                    {
                        var propietarioExistente = await db.propietarios.FindAsync(propietario.codpropietario);
                        if (propietarioExistente != null)
                        {
                            // Actualizar los datos del propietario existente
                            propietarioExistente.propdni = propietario.propdni;
                            propietarioExistente.propnombre = propietario.propnombre;
                            propietarioExistente.propapellido = propietario.propapellido;
                            propietarioExistente.proptelefono = propietario.proptelefono;
                            propietarioExistente.propemail = propietario.propemail;
                        }
                    }

                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al guardar el propietario: " + ex.Message);
                }
            }

            ViewBag.Propietarios = await db.propietarios.ToListAsync();
            ViewBag.Propietario = propietario;
            return View("Index");
        }

        // POST: Propietarios/Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                propietarios propietario = await db.propietarios.FindAsync(id);
                if (propietario != null)
                {
                    db.propietarios.Remove(propietario);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar el propietario: " + ex.Message);
                ViewBag.Propietarios = await db.propietarios.ToListAsync();
                return View("Index");
            }
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