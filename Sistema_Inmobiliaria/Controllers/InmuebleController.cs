using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Inmobiliaria.Models;

namespace Sistema_Inmobiliaria.Controllers
{
    public class InmuebleController : Controller
    {
        private inmuebles objInmuebles = new inmuebles();
        private categoria objCategoria = new categoria();
        private DbContext DbContext;
        // GET: Inmueble
        public ActionResult Index(string nombre)
        {
            if (nombre == null || nombre == "")
            {
                return View(objInmuebles.Listar());
            }
            else
            {
                return View(objInmuebles.Buscar(nombre));
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objInmuebles.Obtener(id));
        }


        public ActionResult Buscar(string nombre)
        {
            return View(nombre == null || nombre == String.Empty ? objInmuebles.Listar() : objInmuebles.Buscar(nombre));

        }

        public ActionResult AgregarEditar(int id = 0)
        {
            /*ViewBag.Usuarios = objUsuarios.Listar();*///Llenar combo 
            ViewBag.categoria = objCategoria.Listar();
            return View(id == 0 ? new inmuebles() //Agregar un nuevo objeto
                        : objInmuebles.Obtener(id)); //Modificar un objeto existente
        }

        public ActionResult Guardar(inmuebles model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Guardar();
                    return Redirect("/Inmuebles");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al guardar el usuario: " + ex.Message);
                }

            }
            ViewBag.categoria = objCategoria.Listar(); // Llenar combo con roles
            return View("AgregarEditar", model);
            //else
            //{
            //    return View("~/Views/Usuario/AgregarEditar.cshtml", model);
            //}

        }

        public ActionResult Eliminar(int id)
        {
            objInmuebles.idinmueble = id;
            objInmuebles.Eliminar();
            return Redirect("~/Inmuebles");
        }
    }
}