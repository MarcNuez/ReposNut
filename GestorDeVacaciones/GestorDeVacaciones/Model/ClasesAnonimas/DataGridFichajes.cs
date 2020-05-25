using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.Model.ClasesAnonimas
{
    public class DataGridFichajes
    {
        public string Nombre { get; set; }
        public DateTime Dia { get; set; }
        public TimeSpan Entrada1 { get; set; }
        public TimeSpan Salida1 { get; set; }
        public TimeSpan Entrada2 { get; set; }
        public TimeSpan Salida2 { get; set; }
        public string Warning { get; set; }
    }
}
