using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Inmobiliaria.Models;

namespace Sistema_Inmobiliaria.Controllers
{
    public class HomeController : Controller
    {
        private Model_Sistema db = new Model_Sistema();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Nosotros()
        {
            return View("_Nosotros");
        }
        public ActionResult Catalogo()
        {
            return View("_Catalogo");
        }
        public ActionResult Contacto()
        {
            return PartialView("~/Views/Shared/_Contacto.cshtml");
        }
    }
}