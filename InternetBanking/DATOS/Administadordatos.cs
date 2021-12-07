using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;

namespace DATOS
{
    public class Administadordatos
    {
        BancoEntities Bd = new BancoEntities();
        
        //Insertar datos
        public void InsertarUsuario(Usuarios usuario)
        {
            Bd.Usuarios.Add(usuario);
            Bd.SaveChanges();
        }

        public void AgregarCuenta(Cuenta_ahorro cuenta)
        {
            Bd.Cuenta_ahorro.Add(cuenta);
            Bd.SaveChanges();
        }

        public void Agregarprestamo(Prestamos prestamos)
        {
            Bd.Prestamos.Add(prestamos);
            Bd.SaveChanges();
        }

        public void Agregartarjeta(Tarjetas_Credito tarjetas)
        {
            Bd.Tarjetas_Credito.Add(tarjetas);
            Bd.SaveChanges();
        }
        // Editar datos

        public void EditarCliente(int id, Usuarios usuario)
        {
            var editar = Bd.CvClientes.Find(id);

            if (editar != null)
            {
                Bd.Entry(usuario).CurrentValues.SetValues(editar);

            }
        }
        public List<CvCuentas> VistaCuentas()
        {
            return Bd.CvCuentas.ToList();
        }

        public List<CvPrestamos> VistaPrestamos()
        {
            return Bd.CvPrestamos.ToList();
        }

        public List<CvTarjetas> VistaTarjetas()
        {
            return Bd.CvTarjetas.ToList();
        }

        public List<CvClientes> VistaClientes()
        {
            return Bd.CvClientes.ToList();
        }

    }
}
