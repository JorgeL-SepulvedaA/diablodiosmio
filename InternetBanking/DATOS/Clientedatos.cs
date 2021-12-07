using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    public class Clientedatos
    {
        BancoEntities bd = new BancoEntities();


        public List<Cuenta_ahorro> Cuenta()
        {
            return bd.Cuenta_ahorro.ToList();
        }

        public List<Prestamos> Prestamo()
        {
            return bd.Prestamos.ToList();
        }

        public List<Tarjetas_Credito> Tarjetas()
        {
            return bd.Tarjetas_Credito.ToList();
        }

        public void Cuentatrans(int Id, string saldo)
        {
            Cuenta_ahorro cuenta_Ahorro = bd.Cuenta_ahorro.Where(d => d.Id_usuario == Id).First();

            cuenta_Ahorro.Saldo = saldo;

            bd.Entry(cuenta_Ahorro).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();
        }

        public void Cuentadepo(string cuenta, string saldo)
        {
            Cuenta_ahorro cuenta_Ahorro = bd.Cuenta_ahorro.Where(d => d.Numero_cuenta == cuenta).First();

            cuenta_Ahorro.Saldo = saldo;

            bd.Entry(cuenta_Ahorro).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();
        }

        public void ingresoha(string cuenta, string depo)
        {
            Transacciones status = new Transacciones();

            status.Numero_cuenta = cuenta;

            status.Monto = depo;
            status.Tipo = "Deposito";
            DateTime dateTime = DateTime.Now;
            status.Fecha = dateTime;

            bd.Transacciones.Add(status);
            bd.SaveChanges();
        }

        public void retiroha(string cuenta, string depo)
        {
            Transacciones status = new Transacciones();

            status.Numero_cuenta = cuenta;

            status.Monto = depo;
            status.Tipo = "Retiro";
            DateTime dateTime = DateTime.Now;
            status.Fecha = dateTime;

            bd.Transacciones.Add(status);
            bd.SaveChanges();
        }

        public List<Transacciones>Historialahorro(int Id)
        {
            Cuenta_ahorro cuenta_Ahorro = bd.Cuenta_ahorro.Where(d => d.Id_usuario == Id).First();

            var cuenta = cuenta_Ahorro.Numero_cuenta;
            //Status_Cuenta status = bd.Status_Cuenta.Where(d => d.Numero_cuenta == cuenta).First();

            var query =
                from emp in bd.Transacciones
                where emp.Numero_cuenta == cuenta
                select emp;
            List<Transacciones> lista = query.ToList();

            return lista;

        }

        public void Depositoprestamo(int id, string depo)
        {

            Prestamos prestamos = bd.Prestamos.Where(d => d.Id_usuario == id).First();

            prestamos.Monto_pendiente = Convert.ToInt32(depo);

            bd.Entry(prestamos).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();

        }

        public void pagoprestamos(int id, string monto, string restante)
        {
            Historial_Prestamos prestamos = new Historial_Prestamos();

            if (restante != null || restante != "0")
            {
                prestamos.Id_prestamo = id;
                prestamos.Monto = monto;
                prestamos.Restante = restante;
                DateTime dateTime = DateTime.Now;
                prestamos.Fecha = dateTime;
                prestamos.Concepto = "Pago cuotas";

                bd.Historial_Prestamos.Add(prestamos);
                bd.SaveChanges();
            }
            else
            {
                prestamos.Id_prestamo = id;
                prestamos.Monto = monto;
                DateTime dateTime = DateTime.Now;
                prestamos.Fecha = dateTime;
                prestamos.Concepto = "Pago completo";

                bd.Historial_Prestamos.Add(prestamos);
                bd.SaveChanges();

            }

        }
        public List<Historial_Prestamos> Historialprestamo(int Id)
        {
            Prestamos prestamo = bd.Prestamos.Where(d => d.Id_usuario == Id).First();

            var cuenta = prestamo.Id;

            var query =
                from emp in bd.Historial_Prestamos
                where emp.Id_prestamo == cuenta
                select emp;
            List<Historial_Prestamos> lista = query.ToList();

            return lista;

        }


        public void consumotarjeta(int n, string md, string mc)
        {
            Tarjetas_Credito tarjetas_Credito = bd.Tarjetas_Credito.Where(d => d.Id_usuario == n).First();

            tarjetas_Credito.Monto_Disponible = md;
            tarjetas_Credito.Balance_Consumido = mc;

            bd.Entry(tarjetas_Credito).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();
        }

        public void transferiracuenta(int id_tarjeta, string montod, string montoc, string cuenta, string transferencia, string saldo)
        {
            Tarjetas_Credito tarjetas_Credito = bd.Tarjetas_Credito.Where(d => d.Id_usuario == id_tarjeta).First();

            tarjetas_Credito.Monto_Disponible = montod;
            tarjetas_Credito.Balance_Consumido = montoc;

            Cuenta_ahorro cuenta_Ahorro = bd.Cuenta_ahorro.Where(d => d.Numero_cuenta == cuenta).First();

            cuenta_Ahorro.Saldo = saldo;

            Transacciones status = new Transacciones();

            status.Numero_cuenta = cuenta;

            status.Monto = transferencia;
            status.Tipo = "Deposito";
            DateTime dateTime = DateTime.Now;
            status.Fecha = dateTime;


            bd.Transacciones.Add(status);
            bd.Entry(cuenta_Ahorro).State = System.Data.Entity.EntityState.Modified;
            bd.Entry(tarjetas_Credito).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();
        }

        public void pagartarjeta(int id_tarjeta, string montod, string montoc, string cuenta, string transferencia, string saldo)
        {
            Tarjetas_Credito tarjetas_Credito = bd.Tarjetas_Credito.Where(d => d.Id_usuario == id_tarjeta).First();

            tarjetas_Credito.Monto_Disponible = montod;
            tarjetas_Credito.Balance_Consumido = montoc;

            Cuenta_ahorro cuenta_Ahorro = bd.Cuenta_ahorro.Where(d => d.Numero_cuenta == cuenta).First();

            cuenta_Ahorro.Saldo = saldo;

            Transacciones status = new Transacciones();

            status.Numero_cuenta = cuenta;

            status.Monto = transferencia;
            status.Tipo = "Pago tarjeta de credito";
            DateTime dateTime = DateTime.Now;
            status.Fecha = dateTime;


            bd.Transacciones.Add(status);
            bd.Entry(cuenta_Ahorro).State = System.Data.Entity.EntityState.Modified;
            bd.Entry(tarjetas_Credito).State = System.Data.Entity.EntityState.Modified;
            bd.SaveChanges();

        }

    }
}
