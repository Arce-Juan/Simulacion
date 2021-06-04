using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPaie.Models
{
    public class SimuladorViewModel
    {
        public string TotalCafeTostado { get; set; }
        public string BolsaCafeMolidoCrema { get; set; }
        public string BolsaCafeMolidoTorrado { get; set; }
        public string BolsaCafeGranosCrema { get; set; }
        public string BolsaCafeGranosTorrado { get; set; }
        public string CostoTotalGas { get; set; }
        public string CafeSinEnvasar { get; set; }
        public string Mensaje { get; set; }
    }
}