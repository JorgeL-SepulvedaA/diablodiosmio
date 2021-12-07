using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDADES;


namespace DATOS
{
    public class Usuariodatos
    {
        BancoEntities Bd = new BancoEntities();



        public List<Usuarios> LeerUsuarios()
        {
            return Bd.Usuarios.ToList();
        }

       
    }
}
