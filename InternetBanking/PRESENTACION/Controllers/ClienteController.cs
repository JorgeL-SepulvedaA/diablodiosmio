using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NEGOCIOS;
using ENTIDADES;

namespace PRESENTACION.Controllers
{
    public class ClienteController : Controller
    {
        Clientenegocio negocio = new Clientenegocio();
        // GET: Cliente
        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult Cliente()
        {
            int id = Convert.ToInt32(Session["Id"]);
            var datos = negocio.Cuenta();

            foreach (Cuenta_ahorro usuario in datos)
            {
                if (usuario.Id_usuario == id)
                {
                    ViewBag.numero = usuario.Numero_cuenta;
                    ViewBag.saldo = usuario.Saldo;
                    return View(datos);
                }
            }

            return View();


        }

        public ActionResult Prestamo()
        {
            int id = Convert.ToInt32(Session["Id"]);
            var datos = negocio.Prestamo();

            foreach (Prestamos usuario in datos)
            {
                if (usuario.Id_usuario == id)
                {
                    ViewBag.monto = usuario.Monto_pendiente;
                    ViewBag.cuotas = usuario.Cuotas;
                    return View(datos);

                }
            }

            return View();
        }

        public ActionResult Tarjeta()
        {
            int id = Convert.ToInt32(Session["Id"]);
            var datos = negocio.Tarjetas();

            foreach (Tarjetas_Credito usuario in datos)
            {
                if (usuario.Id_usuario == id)
                {
                    ViewBag.numero = usuario.Numero_Tarjeta;
                    ViewBag.consumido = usuario.Balance_Consumido;
                    ViewBag.monto = usuario.Monto_Disponible;
                    ViewBag.limite = usuario.Limite;
                    return View(datos);
                }
            }
            return View();
        }

        public ActionResult TransferenciaCuenta()
        {
            return View();
        }

        public ActionResult Depostio()
        {
            return View();
        }

        public ActionResult PagoPrestamo()
        {
            return View();
        }

        public ActionResult ConsumoTarjeta()
        {
            return View();
        }

        public ActionResult AvanceEfectivo()
        {
            return View();
        }

        public ActionResult PagarTarjeta()
        {
            return View();
        }


        public ActionResult Historial()
        {
            int id = Convert.ToInt32(Session["Id"]);
            var datos = negocio.Historialahorro(id);
            return View(datos);
        }

        public ActionResult Historialprestamos()
        {
            int id = Convert.ToInt32(Session["Id"]);
            var datos = negocio.Historialprestamo(id);
            return View(datos);
        }

        [HttpPost]

        public ActionResult TransferenciaCuenta(int saldo)
        {
            int id = Convert.ToInt32(Session["Id"]);

            saldo = Convert.ToInt32(Request.Form["saldo"]);

            string cuenta = Request.Form["cuenta"];

            var datos = negocio.Cuenta();

            foreach (Cuenta_ahorro usuario in datos)
            {
                if (usuario.Id_usuario == id)
                {
                    int saldo1 = Convert.ToInt32(usuario.Saldo) - saldo;
                    string saldo2 = Convert.ToString(saldo1);
                    negocio.Cuentatrans(id, saldo2);
                    string retiro = Convert.ToString(saldo);
                    negocio.retiroha(usuario.Numero_cuenta, retiro);
                }
            }

            foreach (Cuenta_ahorro usuario in datos)
            {
                if (usuario.Numero_cuenta == cuenta)
                {
                    int saldo2 = Convert.ToInt32(usuario.Saldo) + saldo;
                    string saldo20 = Convert.ToString(saldo2);
                    string monto = Convert.ToString(saldo);
                    negocio.Cuentadepo(usuario.Numero_cuenta, saldo20);
                    negocio.ingresoha(usuario.Numero_cuenta, monto);
                }
            }

            return View();
        }
        [HttpPost]
        public ActionResult PagoPrestamo(string depo)
        {
            int id = Convert.ToInt32(Session["Id"]);
            depo = Request.Form["deposito"];
            var datos = negocio.Prestamo();
            var datos2 = negocio.Cuenta();

            foreach (Prestamos cuenta in datos)
            {
                if (id == cuenta.Id_usuario)
                {
                    foreach (Cuenta_ahorro ahorro in datos2)
                    {
                        if (id == ahorro.Id_usuario)
                        {
                            if (Convert.ToInt32(ahorro.Saldo) >= Convert.ToInt32(depo))
                            {
                                int montopend = (int)cuenta.Monto_pendiente - Convert.ToInt32(depo);

                                int id_pre = cuenta.Id;
                                string monto = depo;
                                string restante = Convert.ToString(montopend);

                                negocio.pagoprestamos(id_pre, monto, restante);
                                negocio.Depositoprestamo(id, Convert.ToString(montopend));
                            }
                        }

                    }
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult Depostio(string depo)
        {
            depo = Request.Form["deposito"];
            int id = Convert.ToInt32(Session["Id"]);
            var datos = negocio.Cuenta();

            foreach (Cuenta_ahorro cuenta in datos)
            {
                if (cuenta.Id_usuario == id)
                {
                    int saldo = Convert.ToInt32(cuenta.Saldo) + Convert.ToInt32(depo);
                    negocio.Cuentadepo(cuenta.Numero_cuenta, Convert.ToString(saldo));
                    negocio.ingresoha(cuenta.Numero_cuenta, depo);
                }
            }

            return View();
        }

        [HttpPost]
        public ActionResult ConsumoTarjeta(string monto)
        {
            int id = Convert.ToInt32(Session["Id"]);
            monto = Request.Form["consumo"];

            var datos = negocio.Tarjetas();

            foreach (Tarjetas_Credito tarjetas in datos)
            {
                if (tarjetas.Id_usuario == id)
                {
                    if (Convert.ToInt32(monto) <= Convert.ToInt32(tarjetas.Monto_Disponible))
                    {
                        int md = Convert.ToInt32(tarjetas.Monto_Disponible) - Convert.ToInt32(monto);


                        negocio.consumotarjeta(id, Convert.ToString(md), Convert.ToString(monto));
                    }
                }
            }

            return View();
        }

        [HttpPost]

        public ActionResult AvanceEfectivo(string cuenta, string deposito)
        {
            int id = Convert.ToInt32(Session["Id"]);
            cuenta = Request.Form["cuenta"];
            deposito = Request.Form["saldo"];

            var datos1 = negocio.Tarjetas();
            var datos2 = negocio.Cuenta();

            foreach (Tarjetas_Credito tarjetas in datos1)
            {
                if (tarjetas.Id_usuario == id)
                {
                    if (Convert.ToInt32(deposito) <= Convert.ToInt32(tarjetas.Monto_Disponible))
                    {
                        foreach (Cuenta_ahorro ahorro in datos2)
                        {
                            if (ahorro.Numero_cuenta == cuenta)
                            {
                                int md = Convert.ToInt32(tarjetas.Monto_Disponible) - Convert.ToInt32(deposito);

                                int saldo = Convert.ToInt32(ahorro.Saldo) + Convert.ToInt32(deposito);


                                negocio.transferiracuenta(id, Convert.ToString(md), deposito, cuenta, deposito, Convert.ToString(saldo));

                            }
                        }
                    }
                }
            }

            return View();
        }

        [HttpPost]

        public ActionResult PagarTarjeta(int id, string cuenta, string monto)
        {
            id = Convert.ToInt32(Session["Id"]);
            cuenta = Request.Form["cuenta"];
            monto = Request.Form["saldo"];

            var datos1 = negocio.Tarjetas();
            var datos2 = negocio.Cuenta();

            foreach (Tarjetas_Credito tarjetas in datos1)
            {
                if (tarjetas.Id_usuario == id)
                {
                    if (Convert.ToInt32(monto) <= Convert.ToInt32(tarjetas.Limite))
                    {
                        foreach (Cuenta_ahorro ahorro in datos2)
                        {
                            if (ahorro.Numero_cuenta == cuenta)
                            {
                                int md = Convert.ToInt32(tarjetas.Monto_Disponible) + Convert.ToInt32(monto);

                                int saldo = Convert.ToInt32(ahorro.Saldo) - Convert.ToInt32(monto);

                                int mc = Convert.ToInt32(tarjetas.Balance_Consumido) - Convert.ToInt32(monto);


                                negocio.pagartarjeta(id, Convert.ToString(md), Convert.ToString(mc), cuenta, monto, Convert.ToString(saldo));
                                negocio.ahistorialtarjeta(tarjetas.Numero_Tarjeta, monto, Convert.ToString(mc), Convert.ToString(md));

                            }
                        }
                    }
                }
            }



            return View();
        }


    }
}