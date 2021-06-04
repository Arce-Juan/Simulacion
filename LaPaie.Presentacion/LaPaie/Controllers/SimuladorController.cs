using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaPaie.Dominio;
using LaPaie.Models;

namespace LaPaie.Controllers
{
    public class SimuladorController : Controller
    {
        // GET: Simulador
        public GeneradoresAleatorios Generador { get; set; }

        public SimuladorController()
        {
            Generador = new GeneradoresAleatorios();
        }

        public ActionResult Index()
        {
            var model = new SimuladorViewModel()
            {
                //ValorPoisson = Generador.Poisson(2.67).ToString()
                ValorPoisson = 1.ToString()
            };

            return View(model);
        }
    }
}