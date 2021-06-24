using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPaie.Dominio
{
    public class CafeLaPaie
    {
        public Usuario UsuarioLogueado { get; set; }
        public List<Usuario> ListaUsuarios { get; set; }
    }
}