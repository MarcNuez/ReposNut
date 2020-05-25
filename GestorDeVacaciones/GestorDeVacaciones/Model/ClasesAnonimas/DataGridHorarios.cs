using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.Model.ClasesAnonimas
{
    public class DataGridHorarios
    {
        public string nombre { get; set; }
        public string lunes { get; set; }
        public string martes { get; set; }
        public string miercoles { get; set; }
        public string jueves { get; set; }
        public string viernes { get; set; }
        public string sabado { get; set; }
        public string domingo { get; set; }
        public string jornadaCompleta { get; set; }
        public TimeSpan entrada1 { get; set; }
        public TimeSpan salida1 { get; set; }
        public TimeSpan entrada2 { get; set; }
        public TimeSpan salida2 { get; set; }
    }
}
