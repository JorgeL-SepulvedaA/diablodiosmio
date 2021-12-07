using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;
using DATOS;

namespace NEGOCIOS
{
    public class UsuarioNegocio
    {
        Usuariodatos Usuariodatos = new Usuariodatos();


        public List<Usuarios> LeerUsuarios()
        {
            return Usuariodatos.LeerUsuarios();
        }

       

    }
}
