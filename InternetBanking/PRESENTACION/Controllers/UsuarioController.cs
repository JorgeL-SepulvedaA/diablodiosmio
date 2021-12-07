using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ENTIDADES;
using NEGOCIOS;

namespace PRESENTACION.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioNegocio negocio = new UsuarioNegocio();

        public ActionResult Inicio()
        {
            return View();
        }

        // GET: Usuario
        [HttpPost]
        public ActionResult Login(string email, string contraseña)
        {
            var datos = negocio.LeerUsuarios();
            foreach (var Usuario in datos)
            {
                if (Usuario.Correo == email && Usuario.Contraseña == contraseña && Usuario.Rol == "Administrador")
                {
                    return RedirectToAction("Inicio", "Administrador");
                }
                if (Usuario.Correo == email && Usuario.Contraseña == contraseña && Usuario.Rol == "Cliente")
                {
                    Session["Id"] = Usuario.Id;
                    return RedirectToAction("Inicio", "Cliente");                   
                }

                
            }

            

            return View();
        }
    }
}