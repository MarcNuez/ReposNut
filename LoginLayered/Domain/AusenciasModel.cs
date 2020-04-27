using Comun.Cache;
using DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AusenciasModel
    {
        AusenciasDAO ausDAO = new AusenciasDAO();

     


        public void guardarAusencias(string tipo, DateTime inicio, DateTime fin, string comentario)
        {
            ausDAO.guardarAusencia(UserLoginCache.IdUser,tipo,inicio,fin,comentario);
        }

        


    }
}
