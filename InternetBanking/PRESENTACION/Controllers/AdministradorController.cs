using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEGOCIOS;
using ENTIDADES;

namespace PRESENTACION.Controllers
{
    public class AdministradorController : Controller
    {


        AdministradorNegocio negocio = new AdministradorNegocio();
        // GET: Administrador

        // Ingresos
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Registro(Usuarios usuario)
        {
            if(usuario.Nombre != null)
            negocio.InsertarUsuario(usuario);
            return View();
        }

        public ActionResult IngresarCuenta()
        {
            return View();
        }

        public ActionResult Prestamo(Prestamos prestamos)
        {
            if (prestamos.Monto_pendiente != null)
                negocio.Agregarprestamo(prestamos);
            return View();
        }

        public ActionResult CrearTarjeta (Tarjetas_Credito tarjetas)
        {
            if (tarjetas.Id_usuario != null)
                negocio.Agregartarjeta(tarjetas);
            return View();
        }

        // Editar

        public ActionResult EditarCliente()
        {
            return View();
        }


        // Vistas de lectura

        public ActionResult VistaAhorro()
        {
            var datos = negocio.VistaCuentas();

            return View(datos);
        }

        public ActionResult VistaPrestamos()
        {
            var datos = negocio.VistaPrestamos();

            return View(datos);
        }
        public ActionResult VistaTarjetas()
        {
            var datos = negocio.VistaTarjetas();

            return View(datos);
        }

        public ActionResult VistaClientes()
        {
            var datos = negocio.VistaClientes();

            return View(datos);
        }

        [HttpPost]
        public ActionResult IngresarCuenta(Cuenta_ahorro cuenta)
        {
            negocio.AgregarCuenta(cuenta);
            return View();
        }

        public ActionResult EditarCliente(Usuarios usuarios)
        {
            int id = usuarios.Id;
            negocio.EditarCliente(id, usuarios);
            return View();
        }
    }
}