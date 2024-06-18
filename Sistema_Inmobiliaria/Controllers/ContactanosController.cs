using Sistema_Inmobiliaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_Inmobiliaria.Controllers
{
    public class ContactanosController : Controller
    {
        private Model_Sistema db = new Model_Sistema();

        public ActionResult Contactanos()
        {
            if (Session["UsuarioID"] == null)
            {
                return View("SinSesion");
            }
            else
            {
                int clienteID = (int)Session["UsuarioID"];
                var cliente = db.clientes.Find(clienteID);

                var model = new citas
                {
                    codcliente = clienteID,
                    clientes = cliente
                };

                ViewBag.Locales = new SelectList(db.locales, "codlocal", "localNombre");
                return View("ConSesion", model);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarCita(citas cita)
        {
            if (ModelState.IsValid)
            {
                db.citas.Add(cita);
                db.SaveChanges();
                TempData["MensajeCita"] = "¡Cita reservada exitosamente!";
                return RedirectToAction("Contactanos");
            }

            ViewBag.Locales = new SelectList(db.locales, "codlocal", "localNombre", cita.codlocal);
            return View("ConSesion", cita);
        }
    }
}