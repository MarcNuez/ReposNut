using DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DiasVacacionesModel
    {

        DiasVacacionesDAO vacasDAO = new DiasVacacionesDAO();

        private int diasPermitidos;
       

        public int obtenerDias()
        {
           
            return vacasDAO.obtenerDias();
        }

        public int obtenerDiasMaximo()
        {

            return vacasDAO.obtenerDiasMaximo();
        }

        public void gastarDias(int diasQueMeFaltan)
        {

           

            vacasDAO.cambiarDiasGastados(diasQueMeFaltan);
        }


        public void sumarDiasCancelados(int diasSumar)
        {
            vacasDAO.sumarDiasCancelados(diasSumar);
        }
    }
}
