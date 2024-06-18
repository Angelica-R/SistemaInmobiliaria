using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Inmobiliaria.Models;

namespace Sistema_Inmobiliaria.Controllers
{
    public class ClienteController : Controller
    {
        private Model_Sistema db = new Model_Sistema();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            using (var db = new Model_Sistema())
            {
                var usuario = db.clientes.FirstOrDefault(u => u.cliEmail == email && u.cliClave == password);
                if (usuario != null)
                {
                    Session["UsuarioID"] = usuario.codcliente;
                    return RedirectToAction("Contactanos", "Contactanos");
                }
                else
                {
                    ViewBag.ErrorMessage = "Credenciales incorrectas. Inténtalo de nuevo.";
                    return View();
                }
            }
        }
        public ActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(clientes model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Model_Sistema())
                {
                    if (db.clientes.Any(c => c.cliEmail == model.cliEmail))
                    {
                        ModelState.AddModelError("cliEmail", "Ya existe un usuario registrado con este correo electrónico.");
                        return View(model);
                    }

                    db.clientes.Add(model);
                    db.SaveChanges();
                }

                TempData["MensajeRegistro"] = "¡Registro exitoso! Ahora puedes iniciar sesión.";
                return RedirectToAction("Login");
            }

            return View(model);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Contactanos", "Contactanos");
        }
    }
}