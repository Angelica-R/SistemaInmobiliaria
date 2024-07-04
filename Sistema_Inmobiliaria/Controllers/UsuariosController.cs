using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Sistema_Inmobiliaria.Models;

namespace Sistema_Inmobiliaria.Controllers
{
    public class UsuariosController : Controller
    {

        private usuarios objUsuarios = new usuarios();
        private roles objRoles = new roles();
        private Model_Sistema db = new Model_Sistema();
        private ReniecService reniecService = new ReniecService();

        // GET: Usuarios
        public async Task<ActionResult> Index(string nombre = null, int id = 0)
        {
            ViewBag.Roles = await db.roles.ToListAsync();
            ViewBag.Usuarios = string.IsNullOrEmpty(nombre)
                ? await db.usuarios.Include(u => u.roles).ToListAsync()
                : await db.usuarios.Include(u => u.roles).Where(u => u.nombre.Contains(nombre)).ToListAsync();
            ViewBag.Usuario = id == 0 ? new usuarios() : await db.usuarios.FindAsync(id);
            return View();
        }
        // GET: ConsultarDni

        [HttpGet]
        public async Task<JsonResult> ConsultarDni(string dni)
        {
            var datosReniec = await reniecService.ConsultarDniAsync(dni);
            if (datosReniec != null)
            {
                return Json(new { success = true, nombre = datosReniec.nombres, apellido = datosReniec.apellidoPaterno + " " + datosReniec.apellidoMaterno }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, message = "DNI no encontrado" }, JsonRequestBehavior.AllowGet);
            }
        }
        // POST: Usuarios/Guardar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Guardar([Bind(Include = "codusuario,dni,nombre,apellido,email,clave,direccion,telefono,codrol")] usuarios usuario, HttpPostedFileBase Foto)

        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Verificar si el usuario ya existe por DNI
                    var existingUser = await db.usuarios.FirstOrDefaultAsync(u => u.dni == usuario.dni);
                    if (existingUser != null && existingUser.codusuario != usuario.codusuario)
                    {
                        ViewBag.ErrorMessage = "Este usuario ya ha sido agregado.";
                        ViewBag.Roles = await db.roles.ToListAsync();
                        ViewBag.Usuarios = await db.usuarios.Include(u => u.roles).ToListAsync();
                        ViewBag.Usuario = usuario;
                        return View("Index");
                    }

                    if (Foto != null && Foto.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(Foto.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/Usuarios"), fileName);
                        Foto.SaveAs(path);
                        usuario.foto = "/Images/Usuarios/" + fileName;
                    }


                    if (usuario.codusuario == 0)
                    {
                        db.usuarios.Add(usuario);
                    }
                    else
                    {
                        var usuarioExistente = await db.usuarios.FindAsync(usuario.codusuario);
                        if (usuarioExistente != null)
                        {
                            // Actualizar los datos del usuario existente
                            usuarioExistente.dni = usuario.dni;
                            usuarioExistente.nombre = usuario.nombre;
                            usuarioExistente.apellido = usuario.apellido;
                            usuarioExistente.email = usuario.email;
                            usuarioExistente.clave = usuario.clave;
                            usuarioExistente.direccion = usuario.direccion;
                            usuarioExistente.telefono = usuario.telefono;
                            usuarioExistente.codrol = usuario.codrol;
                            if (Foto != null && Foto.ContentLength > 0)
                            {
                                usuarioExistente.foto = usuario.foto;
                            }
                        }
                    }

                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error al guardar el usuario: " + ex.Message);
                }
            }

            ViewBag.Roles = await db.roles.ToListAsync();
            ViewBag.Usuarios = await db.usuarios.Include(u => u.roles).ToListAsync();
            ViewBag.Usuario = usuario;
            return View("Index");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Eliminar(int id)
        {
            try
            {
                usuarios usuario = await db.usuarios.FindAsync(id);
                if (usuario != null)
                {
                    db.usuarios.Remove(usuario);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error al eliminar el usuario: " + ex.Message);
                ViewBag.Roles = await db.roles.ToListAsync();
                ViewBag.Usuarios = await db.usuarios.Include(u => u.roles).ToListAsync();
                return View("Index");
            }
        }


        // En UsuariosController.cs
        public async Task<ActionResult> Visualizar(int id)
        {
            var usuario = await db.usuarios.Include(u => u.roles).FirstOrDefaultAsync(u => u.codusuario == id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }





    }
}