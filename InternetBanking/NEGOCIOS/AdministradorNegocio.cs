using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class AdministradorNegocio
    {
        Administadordatos Administadordatos = new Administadordatos();

        // Insertar
        public void InsertarUsuario(Usuarios usuario)
        {
            Administadordatos.InsertarUsuario(usuario);

        }
        public void AgregarCuenta(Cuenta_ahorro cuenta)
        {
            Administadordatos.AgregarCuenta(cuenta);
        }
        public void Agregarprestamo(Prestamos prestamos)
        {
            Administadordatos.Agregarprestamo(prestamos);
        }

        public void Agregartarjeta(Tarjetas_Credito tarjetas)
        {
            Administadordatos.Agregartarjeta(tarjetas);
        }

        // Editar

        public void EditarCliente(int id, Usuarios usuario)
        {
            Administadordatos.EditarCliente(id, usuario);

        }

        //Listas
        public List<CvCuentas> VistaCuentas()
        {
            return Administadordatos.VistaCuentas();
        }

        public List<CvPrestamos> VistaPrestamos()
        {
            return Administadordatos.VistaPrestamos();
        }

        public List<CvTarjetas> VistaTarjetas()
        {
            return Administadordatos.VistaTarjetas();
        }

        public List<CvClientes> VistaClientes()
        {
            return Administadordatos.VistaClientes();
        }

    }
}
