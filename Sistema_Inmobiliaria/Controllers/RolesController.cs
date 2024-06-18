using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Inmobiliaria.Models;

namespace Sistema_Inmobiliaria.Controllers
{

    public class RolesController : Controller
    {
        private roles objRoles = new roles();
        // GET: Roles
        public ActionResult Index()
        {
            return View(objRoles.Listar());
        }
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Roles = objRoles.Listar();//Llenar combo 
            return View(id == 0 ? new roles() //Agregar un nuevo objeto
                        : objRoles.Obtener(id)); //Modificar un objeto existente
        }

        public ActionResult Guardar(roles model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("/Roles");
            }
            else
            {
                return View("~/Views/Roles/AgregarEditar.cshtml", model);
            }

        }
        public ActionResult Eliminar(int id)
        {
            objRoles.codrol = id;
            objRoles.Eliminar();
            return Redirect("~/Roles");
        }
    }
}