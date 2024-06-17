using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_Inmobiliaria.Models;

namespace Sistema_Inmobiliaria.Controllers
{
    public class UsuariosController : Controller
    {

        // GET: Usuarios
        private usuarios objUsuarios = new usuarios();
        private roles objRoles = new roles();
        private DbContext DbContext;

        public ActionResult Index(string nombre)
        {
            if (nombre == null || nombre == "")
            {
                return View(objUsuarios.Listar());
            }
            else
            {
                return View(objUsuarios.Buscar(nombre));
            }
        }

        public ActionResult Visualizar(int id)
        {
            return View(objUsuarios.Obtener(id));
        }

        public ActionResult Buscar(string nombre)
        {
            return View(nombre == null || nombre == String.Empty ? objUsuarios.Listar() : objUsuarios.Buscar(nombre));

        }

        public ActionResult AgregarEditar(int id = 0)
        {
            /*ViewBag.Usuarios = objUsuarios.Listar();*///Llenar combo 
            ViewBag.roles = objRoles.Listar();
            return View(id == 0 ? new usuarios() //Agregar un nuevo objeto
                        : objUsuarios.Obtener(id)); //Modificar un objeto existente
        }

        public ActionResult Guardar(usuarios model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Guardar();
                    return Redirect("/Usuario");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al guardar el usuario: " + ex.Message);
                }

            }
            ViewBag.Roles = objRoles.Listar(); // Llenar combo con roles
            return View("AgregarEditar", model);
            //else
            //{
            //    return View("~/Views/Usuario/AgregarEditar.cshtml", model);
            //}

        }

        public ActionResult Eliminar(int id)
        {
            objUsuarios.codusuario = id;
            objUsuarios.Eliminar();
            return Redirect("~/Usuario");
        }
    }
}