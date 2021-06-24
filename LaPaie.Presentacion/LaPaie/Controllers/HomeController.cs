using LaPaie.Models;
using LaPaie.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LaPaie.Controllers
{
    public class HomeController : Controller
    {
        private UsuarioServicio _usuarioServicio;

        public HomeController()
        {
            _usuarioServicio = new UsuarioServicio();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Alumnos()
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Materia()
        {
            if (Session["Session_Usuario_Id"] == null)
                return RedirectToAction("Login", "Home");

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login(string esInvitado = "NO")
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string ReturnUrl, string esInvitado)
        {
            if (!ModelState.IsValid)
                return View(model);

            _usuarioServicio.ObtenerUsuarioPorNickContrasena(model.Nick, model.Password);
            var usuario = _usuarioServicio.ObtenerUsuarioLogueado();
            if (usuario != null)
            {
                Session["Session_Usuario_Id"] = usuario.Id;
                return RedirectToAction("IngresarParametros", "Simulador");
            }
            else
            {
                model.ErrorLogin = "El usuario o contraseña no son validos. Intente nuevamente";
                return View(model);
            }
        }
    }
}