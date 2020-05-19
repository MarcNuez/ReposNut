using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.Model
{
    public class FicharModel
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public DateTime dia { get; set; }
        public bool diaLaboral { get; set; }
        public int horarioID { get; set; }
        public TimeSpan entrada1 { get; set; }
        public TimeSpan salida1 { get; set; }
        public TimeSpan entrada2 { get; set; }
        public TimeSpan salida2 { get; set; }
        public int warning { get; set; }
    }
}
