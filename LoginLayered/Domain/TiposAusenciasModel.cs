using DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TiposAusenciasModel
    {


        TiposAusenciasDAO tiposDAO = new TiposAusenciasDAO();


        public DataTable obtenerTiposAusencias()
        {
            return tiposDAO.obtenerTiposAusencia();
        }



    }
}
