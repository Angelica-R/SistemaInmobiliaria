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
    }
}