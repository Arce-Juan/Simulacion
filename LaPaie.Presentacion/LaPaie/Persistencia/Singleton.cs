using LaPaie.Dominio;
using LaPaie.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPaie.Persistencia
{
    public class Singleton
    {
        public static Singleton unicaInstancia;
        private CafeLaPaie cafeLaPaie = null;
        private Usuario sesionDeUsuario;
        public UsuarioServicio _usuarioServicio { get; set; }

        private Singleton()
        {
            if (cafeLaPaie == null)
            {
                cafeLaPaie = new CafeLaPaie();
            }
        }

        public static Singleton getInstancia()
        {
            if (unicaInstancia == null)
            {
                unicaInstancia = new Singleton();
            }
            return unicaInstancia;
        }

        public CafeLaPaie ObtenerDatosDeEmpresa()
        {
            return cafeLaPaie;
        }

        public void AsignarDatosAEmpresa(CafeLaPaie _cafeLaPaie)
        {
            cafeLaPaie = _cafeLaPaie;
        }

        public Usuario SessionDeUsuario
        {
            get { return sesionDeUsuario; }
            set { sesionDeUsuario = value; }
        }
    }
}
