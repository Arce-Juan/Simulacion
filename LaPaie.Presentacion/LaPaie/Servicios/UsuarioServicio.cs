using LaPaie.Dominio;
using LaPaie.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaPaie.Servicios
{
    public class UsuarioServicio
    {
        public void CargarUsuariosAutomaticamente()
        {
            var lista = new List<Usuario>()
            {
                new Usuario()
                {
                    Id = 1,
                    Nick = "abuidj",
                    Contrasena = "123",
                    Nombre = "Abuin, Juan José",
                    Imagen = "/Resource/images/juanjo.jpg"
                },
                new Usuario()
                {
                    Id = 2,
                    Nick = "arcej",
                    Contrasena = "456",
                    Nombre = "Arce, Juan Eduardo",
                    Imagen = "/Resource/images/juanedu.jpg"
                },
                new Usuario()
                {
                    Id = 1,
                    Nick = "charcash",
                    Contrasena = "789",
                    Nombre = "Charcas, Hugo Alberto",
                    Imagen = "/Resource/images/hugo.jpg"
                },
                new Usuario()
                {
                    Id = 1,
                    Nick = "diazj",
                    Contrasena = "987",
                    Nombre = "Diaz, Galvan Jose Luis",
                    Imagen = "/Resource/images/joseluis.jpg"
                },
                new Usuario()
                {
                    Id = 1,
                    Nick = "lagunac",
                    Contrasena = "654",
                    Nombre = "Laguna Racedo, Camila Maria",
                    Imagen = "/Resource/images/cami.jpg"
                },
                new Usuario()
                {
                    Id = 1,
                    Nick = "gomezm",
                    Contrasena = "321",
                    Nombre = "Gómez, Martín Eduardo",
                    Imagen = "/Resource/images/martin.jpg"
                }
            };
            Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaUsuarios = new List<Usuario>();
            Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaUsuarios.AddRange(lista);
        }

        public void ObtenerUsuarioPorNickContrasena(string nick, string contrasena)
        {
            var lista = Singleton.getInstancia().ObtenerDatosDeEmpresa().ListaUsuarios;
            var usuario = lista.Where(x => x.Nick == nick && x.Contrasena == contrasena).FirstOrDefault();
            if (usuario != null)
                Singleton.getInstancia().ObtenerDatosDeEmpresa().UsuarioLogueado = usuario;
        }

        public Usuario ObtenerUsuarioLogueado()
        {
            return Singleton.getInstancia().ObtenerDatosDeEmpresa().UsuarioLogueado;
        }
    }
}