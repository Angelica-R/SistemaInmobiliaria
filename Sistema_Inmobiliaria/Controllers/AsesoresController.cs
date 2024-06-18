using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Sistema_Inmobiliaria.Models;

namespace Sistema_Inmobiliaria.Controllers
{
    public class AsesoresController : Controller
    {
        private Model_Sistema db = new Model_Sistema();
        // GET: Asesores
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Asesores()
        {
            var asesores = db.usuarios.Include("roles").ToList();
            return View(asesores);
        }
    }
}