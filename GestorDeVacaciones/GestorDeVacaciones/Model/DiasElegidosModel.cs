using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace GestorDeVacaciones.Model
{
    public class DiasElegidosModel 
    {
        public int Id { get; set; }

        public UserModel Usuario { get; set; }
        public int UserModelId { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }

        public int Año { get; set; }

        public bool Aprobado { get; set; }

        public bool Denegado { get; set; }

        public string diaFormato { get {

                return Dia.ToString() + "/" + Mes.ToString() + "/" + Año.ToString(); } }


        

        

    }
}
