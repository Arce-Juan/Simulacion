using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPaie.Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Imagen { get; set; }
    }
}