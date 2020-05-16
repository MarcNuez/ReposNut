using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.Model
{
    public class VacacionesElegidasModel
    {

        public int Id { get; set; }
        public UserModel Usuario { get; set; }
        public int UserModelId { get; set; }
        public virtual List<DiasElegidosModel> DiasElegidos { get; set; }

        public int TotalDias { get; set; }

    }
}
