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
        //private DbContext DbContext;

        public ActionResult Index(string nombre = null, int id = 0)
        {
            ViewBag.Roles = objRoles.Listar();
            ViewBag.Usuarios = string.IsNullOrEmpty(nombre) ? objUsuarios.Listar() : objUsuarios.Buscar(nombre);
            ViewBag.Usuario = id == 0 ? new usuarios() : objUsuarios.Obtener(id);
            return View();
        }

        [HttpPost]
        public ActionResult Guardar(usuarios model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Guardar();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al guardar el usuario: " + ex.Message + " " + ex.StackTrace);
                }
            }
            ViewBag.Roles = objRoles.Listar();
            ViewBag.Usuarios = objUsuarios.Listar();
            ViewBag.Usuario = model;
            return View("Index");
        }

        public ActionResult Eliminar(int id)
        {
            objUsuarios.codusuario = id;
            objUsuarios.Eliminar();
            return RedirectToAction("Index");
        }



        //public ActionResult Index(string nombre)
        //{
        //    if (string.IsNullOrEmpty(nombre))
        //    {
        //        return View(objUsuarios.Listar());
        //    }
        //    else
        //    {
        //        return View(objUsuarios.Buscar(nombre));
        //    }
        //}
        //public ActionResult Visualizar(int id)
        //{
        //    return View(objUsuarios.Obtener(id));
        //}

        //public ActionResult Buscar(string nombre)
        //{
        //    return View(string.IsNullOrEmpty(nombre) ? objUsuarios.Listar() : objUsuarios.Buscar(nombre));
        //}

        //public ActionResult AgregarEditar(int id = 0)
        //{
        //    ViewBag.Roles = objRoles.Listar();
        //    return View(id == 0 ? new usuarios() : objUsuarios.Obtener(id));
        //}

        //[HttpPost]
        //public ActionResult Guardar(usuarios model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            model.Guardar(); // Asegúrate de que este método funcione correctamente
        //            return RedirectToAction("Index");
        //        }
        //        catch (Exception ex)
        //        {
        //            ModelState.AddModelError("", "Error al guardar el usuario: " + ex.Message);
        //        }
        //    }
        //    ViewBag.Roles = objRoles.Listar();
        //    return View("AgregarEditar", model);
        //}

        //public ActionResult Eliminar(int id)
        //{
        //    objUsuarios.codusuario = id;
        //    objUsuarios.Eliminar(); // Verifica que este método esté implementado correctamente
        //    return RedirectToAction("Index");
        //}


        //public ActionResult Guardar(usuarios model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.Guardar();
        //        return Redirect("~/Usuarios/Index");
        //    }
        //    else
        //    {
        //        return View("~/Views/Usuarios/AgregarEditar");

        //    }
        //}


    }
}