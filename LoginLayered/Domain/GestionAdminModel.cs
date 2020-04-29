using Comun.Cache;
using DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class GestionAdminModel
    {
        GestionAdminDAO gDao = new GestionAdminDAO();




        public DataTable obtenerVacacionesUsuarios()
        {


            return gDao.obtenerVacacionesUsuarios();
        }


        public void aprobarVacaciones(int id)
        {
            gDao.aprobarVacaciones(id);
        }

        public void denegarVacaciones(int id, int id_user, DateTime dia, string comentario)
        {
            var nombre_admin = UserLoginCache.FirstName + " " + UserLoginCache.LastName;
            gDao.denegarVacaciones(id,id_user,dia,UserLoginCache.IdUser,nombre_admin,comentario);
        }



    }
}
