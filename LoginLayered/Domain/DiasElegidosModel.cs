using Comun.Cache;
using DataAccess.SqlServer;
using System;
using System.Collections.Generic;


namespace Domain
{
    public class DiasElegidosModel
    {
        DiasElegidosDAO diasElegidosDAO = new DiasElegidosDAO();

        private int diasID;
        private int userID;
        private List<ClaseDiasElegidosVacaciones> listaDiasElegidos;

        public DiasElegidosModel()
        {
            this.userID = UserLoginCache.IdUser;
        }
        public DiasElegidosModel(List<ClaseDiasElegidosVacaciones> ld)
        {
            this.userID = UserLoginCache.IdUser;
            this.listaDiasElegidos = ld;
        }
        
        public void guardarDias()
        {
            foreach (ClaseDiasElegidosVacaciones d in listaDiasElegidos)
            {
                diasElegidosDAO.guardarDiasSeleccionados(userID,d.obtenerFechaFormato());
            }
           
        }


        public bool comprobarSiEstaElegido(DateTime dt)
        {
            if (diasElegidosDAO.comprobarSiEstaElegido(userID, dt))
                return true;

            return false;
        }

        public void quitarDiaElegido(DateTime dt)
        {
            diasElegidosDAO.quitarDiaElegido(userID,dt);

        }







    }
}
