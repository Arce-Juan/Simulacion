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

        public SimuladorController()
        {
        }

        public ActionResult IngresarParametros()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            var aux = collection["nCostoFijoGas"];

            var diasSumilacion = int.Parse(collection["nDiasSumilacion"]);
            var costoFijoGas = double.Parse(collection["nCostoFijoGas"]);
            var costoMetro3Gas = double.Parse(collection["nCostoMetro3Gas"]);
            var minimoBolsasProcesar = int.Parse(collection["nMinimoBolsasProcesar"]);
            var maximoBolsasProcesar = int.Parse(collection["nMaximoBolsasProcesar"]);
            var minimoTiempoHorneado = int.Parse(collection["nMinimoTiempoHorneado"]);
            var maximoTiempoHorneado = int.Parse(collection["nMaximoTiempoHorneado"]);

            //INICIO
            int totalMinutosEnHorno = 0;
            double totalCafeTostado = 0;
            double totalMinutosEncendidoHorno = 0;
            int bolsasCafeGranosCrema = 0;
            int bolsasCafeGranosTorrado = 0;
            int bolsasCafeMolidoCrema = 0;
            int bolsasCafeMolidoTorrado = 0;

            double cafeGranosCremaSinEnvolsar = 0;
            double cafeGranosTorradoSinEnvolsar = 0;
            double cafeMolidoCremaSinEnvolsar = 0;
            double cafeMolidoTorradoSinEnvolsar = 0;

            for (int dia = 1; dia < diasSumilacion; dia++)  // bucle de dias
            {
                var bolsasAProcesarPorDia = DistribucionesProbabilidad.Uniforme(minimoBolsasProcesar, maximoBolsasProcesar);
                totalMinutosEncendidoHorno += DistribucionesProbabilidad.Exponencial(5);

                for (int j = 1; j <= bolsasAProcesarPorDia; j++)  // Bucle de Bolsas
                {
                    totalMinutosEncendidoHorno += DistribucionesProbabilidad.Uniforme(minimoTiempoHorneado, maximoTiempoHorneado);
                    var pesoBolsaCafeVerde = DistribucionesProbabilidad.Normal(50000, 1000);
                    var porcentagePerdidaEnTostado = DistribucionesProbabilidad.Normal(0.13, 0.15);
                    var cafeTostado = pesoBolsaCafeVerde - (pesoBolsaCafeVerde * porcentagePerdidaEnTostado);  // para corregir en el diagrama
                    
                    totalCafeTostado += cafeTostado;
                    var pesoCafeParaMoler = cafeTostado * 0.2;
                    var pesoCafeEnGranos = cafeTostado * 0.8;
                    var cafeGranosCrema = pesoCafeParaMoler * 0.7;
                    var cafeGranosTorrado = pesoCafeParaMoler * 0.3;
                    var cafeMolidoCrema = pesoCafeEnGranos * 0.7;
                    var cafeMolidoTorrado = pesoCafeEnGranos * 0.3;

                    while (cafeGranosCrema >= 1000)
                    {
                        bolsasCafeGranosCrema += 1;
                        cafeGranosCrema -= 1000;
                    }
                    cafeGranosCremaSinEnvolsar += cafeGranosCrema;

                    while (cafeGranosTorrado >= 1000)
                    {
                        bolsasCafeGranosTorrado += 1;
                        cafeGranosTorrado -= 1000;
                    }
                    cafeGranosTorradoSinEnvolsar += cafeGranosTorrado;

                    while (cafeMolidoCrema >= 1000)
                    {
                        bolsasCafeMolidoCrema += 1;
                        cafeMolidoCrema -= 1000;
                    }
                    cafeMolidoCremaSinEnvolsar += cafeGranosCrema;

                    while (cafeMolidoTorrado >= 1000)
                    {
                        bolsasCafeMolidoTorrado += 1;
                        cafeMolidoTorrado -= 1000;
                    }
                    cafeMolidoTorradoSinEnvolsar += cafeGranosTorrado;

                } // fin Bucle de Bolsas

            } // fin bucle de dias

            var cafeSinEnvasar = cafeGranosTorradoSinEnvolsar + cafeGranosCremaSinEnvolsar + cafeMolidoTorradoSinEnvolsar + cafeMolidoCremaSinEnvolsar;
            var costoTotalGas = costoFijoGas + (totalMinutosEncendidoHorno * costoMetro3Gas);

            var model = new SimuladorViewModel()
            {
                TotalCafeTostado = totalCafeTostado.ToString(),
                BolsaCafeMolidoCrema = bolsasCafeMolidoCrema.ToString(),
                BolsaCafeMolidoTorrado = bolsasCafeMolidoTorrado.ToString(),
                BolsaCafeGranosCrema = bolsasCafeGranosCrema.ToString(),
                BolsaCafeGranosTorrado = bolsasCafeGranosTorrado.ToString(),
                CostoTotalGas = costoTotalGas.ToString(),
                CafeSinEnvasar = cafeSinEnvasar.ToString(),
                Mensaje = cafeSinEnvasar > 10000 ? "Embolsar en menos cantidad" : "Seguir embolsando igual"
            };

            return View(model);
        }


    }
}