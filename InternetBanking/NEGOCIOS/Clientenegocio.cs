using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS;
using ENTIDADES;

namespace NEGOCIOS
{
    public class Clientenegocio
    {
        Clientedatos Clientedatos = new Clientedatos();

        //public void Cuenta()
        //{
        //    Clientedatos.Cuenta();
        //}

        public List<Cuenta_ahorro> Cuenta()
        {
            return Clientedatos.Cuenta();
        }

        public List<Prestamos> Prestamo()
        {
            return Clientedatos.Prestamo();
        }

        public List<Tarjetas_Credito> Tarjetas()
        {
            return Clientedatos.Tarjetas();
        }

        public void Cuentatrans(int Id, string saldo)
        {
            Clientedatos.Cuentatrans(Id, saldo);
        }

        public void Cuentadepo(string cuenta, string saldo)
        {
            Clientedatos.Cuentadepo(cuenta, saldo);
        }

        public void ingresoha(string cuenta, string depo)
        {
            Clientedatos.ingresoha(cuenta, depo);
        }
        public void retiroha(string cuenta, string depo)
        {
            Clientedatos.retiroha(cuenta, depo);
        }

        public void pagoprestamos(int id, string monto, string restante)
        {

            Clientedatos.pagoprestamos(id, monto, restante);
        }

        public List<Transacciones> Historialahorro(int Id)
        {
            return Clientedatos.Historialahorro(Id);
        }

        public void Depositoprestamo(int id, string depo)
        {
            Clientedatos.Depositoprestamo(id, depo);

        }

        public void consumotarjeta(int n, string md, string mc)
        {
            Clientedatos.consumotarjeta(n, md, mc);
        }
        public void transferiracuenta(int id_tarjeta, string montod, string montoc, string cuenta, string transferencia, string saldo)
        {
            Clientedatos.transferiracuenta(id_tarjeta, montod, montoc, cuenta, transferencia, saldo);        
        }
        public void pagartarjeta(int id_tarjeta, string montod, string montoc, string cuenta, string transferencia, string saldo)
        {
            Clientedatos.pagartarjeta(id_tarjeta, montod, montoc, cuenta, transferencia, saldo);
        }
        public List<Historial_Prestamos> Historialprestamo(int Id)
        {
            return Clientedatos.Historialprestamo(Id);

        }
    }
}
