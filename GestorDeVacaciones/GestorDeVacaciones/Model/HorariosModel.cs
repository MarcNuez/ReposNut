using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.Model
{
    public class HorariosModel
    {
        public int Id { get; set; }
        public bool lunes { get; set; }
        public bool martes { get; set; }
        public bool miercoles { get; set; }
        public bool jueves { get; set; }
        public bool viernes { get; set; }
        public bool sabado { get; set; }
        public bool domingo { get; set; }
        public bool jornadaCompleta { get; set; }
        public TimeSpan entrada1 { get; set; }
        public TimeSpan salida1 { get; set; }
        public TimeSpan entrada2 { get; set; }
        public TimeSpan salida2 { get; set; }
    }
}
