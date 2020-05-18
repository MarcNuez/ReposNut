using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.Model
{
    public class AusenciasModel
    {

        public int Id { get; set; }
        public UserModel Usuario { get; set; }
        public int UserModelId  { get; set; }
        public TipoAusenciaModel Tipo { get; set; }
        public int TipoAusenciaModelId { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }

        public string Comentario { get; set; }

        public bool Denegada { get; set; }


    }
}
