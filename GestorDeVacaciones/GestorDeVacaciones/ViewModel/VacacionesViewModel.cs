using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorDeVacaciones.ViewModel
{
    public class VacacionesViewModel : BaseViewModel
    {


		private string _diaElegido;

		public string DiaElegido
		{
			get { return _diaElegido; }
			set { _diaElegido = value; }
		}

	}
}
