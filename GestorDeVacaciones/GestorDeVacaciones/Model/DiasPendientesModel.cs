using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.Model
{
    public class DiasPendientesModel
    {

        public int Id { get; set; }
        public int UserModelId { get; set; }
        public int DiasQueCorresponden { get; set; }
        public int DiasQueMeQuedan { get; set; }
        
       
    }
}
