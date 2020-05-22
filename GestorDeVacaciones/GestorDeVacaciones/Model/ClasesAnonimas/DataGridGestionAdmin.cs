using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.Model.ClasesAnonimas
{
    public class DataGridGestionAdmin
    {

        public string NombreCompleto { get; set; }
        
        public bool Estado { get; set; }

        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Año { get; set; }

        public string Dias { get { return Dia.ToString() + "/" + Mes.ToString() + "/" + Año.ToString(); } }

    }
}
