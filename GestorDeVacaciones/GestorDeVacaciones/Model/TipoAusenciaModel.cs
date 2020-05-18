using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.Model
{
    public class TipoAusenciaModel
    {

        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public bool Denegable { get; set; }
        public virtual List<AusenciasModel> Ausencias { get; set; }
    }
}
