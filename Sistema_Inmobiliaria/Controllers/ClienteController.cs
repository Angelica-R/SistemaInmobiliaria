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
    }
}