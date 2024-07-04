using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sistema_Inmobiliaria.Models;
using System.Web.Configuration;

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
            return View("Nosotros");
        }
        public ActionResult Catalogo()
        {
            return View("Catalogo");
        }
        public ActionResult Contacto()
        {
            return PartialView("~/Views/Shared/Contacto.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnviarCorreo(Contacto model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var fromAddress = new MailAddress(WebConfigurationManager.AppSettings["Email"], "Inmobiliaria Thiagos");
                    var toAddress = new MailAddress("ar2019063327@virtual.upt.pe", "Destinatario"); // Cambia esta línea si deseas enviar el correo a otra dirección
                    string fromPassword = WebConfigurationManager.AppSettings["EmailPassword"];
                    string smtpServer = WebConfigurationManager.AppSettings["SmtpServer"];
                    int smtpPort = int.Parse(WebConfigurationManager.AppSettings["SmtpPort"]);

                    string subject = model.Asunto;
                    string body = $"Nombre: {model.Nombre}\n" +
                                  $"Telefono: {model.Telefono}\n" +
                                  $"Correo: {model.Correo}\n" +
                                  $"Asunto: {model.Asunto}\n" +
                                  $"Mensaje:\n{model.Mensaje}";

                    // Configurar el cliente SMTP
                    var smtp = new SmtpClient
                    {
                        Host = smtpServer,
                        Port = smtpPort,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                    };

                    // Crear y enviar el mensaje
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }

                    ViewBag.Message = "Correo enviado exitosamente.";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = $"Error al enviar el correo: {ex.Message}";
                }
            }

            return View("Contacto", model);
        }
    }
}