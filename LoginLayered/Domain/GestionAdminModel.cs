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
            var dtListaParaElGrid = gDao.obtenerVacacionesUsuarios();
          
           
           
            


            return gDao.obtenerVacacionesUsuarios();
        }



    }
}
